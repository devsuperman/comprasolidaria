using System.Linq;
using System.Security.Claims;

namespace Web.Extensoes
{
    public static class ClaimsPrincipalExtensoes
    {
        public static string Nome(this ClaimsPrincipal user) =>
            user.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
    }
}
