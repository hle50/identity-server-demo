using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer.Core.Data
{
    public static class Config
    {
        public static List<IdentityResource> GetIdentityResources()
        {
            // Claims automatically included in OpenId scope
            var openIdScope = new IdentityResources.OpenId();
            openIdScope.UserClaims.Add(JwtClaimTypes.Locale);

            // Available scopes
            return new List<IdentityResource>
  {
    openIdScope,
    new IdentityResources.Profile(),
    new IdentityResources.Email(),
   
  };
        }
        public static List<Client> Clients = new List<Client>
        {
                new Client
                {
                    ClientId = "yu-1",
                    AllowedGrantTypes = new List<string> { GrantType.AuthorizationCode },
                    RequireClientSecret = true,
                    RequireConsent = false,
                    RedirectUris = new List<string> { "http://localhost:3006/signin-callback.html" },
                    PostLogoutRedirectUris = new List<string> { "http://localhost:3006/" },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "yu-api", "write", "read", "openid", "profile", "email" },
                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:3006",
                    },
                    AccessTokenLifetime = 86400
                },

                 new Client
                {
                    ClientId = "yu-2",
                    AllowedGrantTypes = new List<string> { GrantType.ResourceOwnerPassword },
                    RequireClientSecret = true,
                    RequireConsent = false,                  
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "yu-api", "write", "read", "openid", "profile", "email" },
                    AccessTokenLifetime = 86400,
                    
                }
        };

        public static List<ApiResource> ApiResources = new List<ApiResource>
        {
            new ApiResource
            {
                Name = "yu-api",
                DisplayName = "Yu API",
                Scopes = new List<string>
                {
                    "write",
                    "read"
                }
            }
        };

        public static IEnumerable<ApiScope> ApiScopes = new List<ApiScope>
        {
            new ApiScope("openid"),
            new ApiScope("profile"),
            new ApiScope("email"),
            new ApiScope("read"),
            new ApiScope("write"),
            new ApiScope("yu-api")
        };
    }
}
