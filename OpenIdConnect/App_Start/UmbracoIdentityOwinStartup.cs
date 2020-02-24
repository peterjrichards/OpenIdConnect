using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Configuration;
using System.Linq;
using UmbracoIdentity;
using OpenIdConnect;
using OpenIdConnect.Models.UmbracoIdentity;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security;

[assembly: OwinStartup("UmbracoIdentityStartup", typeof(UmbracoIdentityOwinStartup))]
namespace OpenIdConnect
{

    /// <summary>
    /// OWIN Startup class for UmbracoIdentity 
    /// </summary>
    public class UmbracoIdentityOwinStartup : UmbracoIdentityOwinStartupBase
    {
        protected override void ConfigureUmbracoUserManager(IAppBuilder app)
        {
            base.ConfigureUmbracoUserManager(app);

            //Single method to configure the Identity user manager for use with Umbraco
            app.ConfigureUserManagerForUmbracoMembers<UmbracoApplicationMember>();

            //Single method to configure the Identity user manager for use with Umbraco
            app.ConfigureRoleManagerForUmbracoMembers<UmbracoApplicationRole>();
        }

        protected override void ConfigureUmbracoAuthentication(IAppBuilder app)
        {
            base.ConfigureUmbracoAuthentication(app);

            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            // Enable the application to use a cookie to store information for the 
            // signed in user and to use a cookie to temporarily store information 
            // about a user logging in with a third party login provider 
            // Configure the sign in cookie

            var cookieOptions = CreateFrontEndCookieAuthenticationOptions();

            // You can change the cookie options here. The cookie options will be automatically set
            // based on what is configured in the security section of umbracoSettings.config and the web.config.
            // For example:
            // cookieOptions.CookieName = "testing";
            // cookieOptions.ExpireTimeSpan = TimeSpan.FromDays(20);

            cookieOptions.Provider = new CookieAuthenticationProvider
            {               
                // Enables the application to validate the security stamp when the user 
                // logs in. This is a security feature which is used when you 
                // change a password or add an external login to your account.  
                OnValidateIdentity = SecurityStampValidator
                        .OnValidateIdentity<UmbracoMembersUserManager<UmbracoApplicationMember>, UmbracoApplicationMember, int>(
                            TimeSpan.FromMinutes(30),
                            (manager, user) => user.GenerateUserIdentityAsync(manager),
                            identity => identity.GetUserId<int>())
            };

            app.UseCookieAuthentication(cookieOptions, PipelineStage.Authenticate);

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = "d71c88d1-f3d3-47e9-8313-06bc9af9a991",
                    Authority = "https://keycloak-pr.herokuapp.com/auth/realms/master/",
                    RedirectUri = "https://localhost:44300/home/",
                });
        }
    }
}

