using System.Security.Cryptography;
using System.Text;

namespace WebApplication2rrr
{
    public static class Hash
    {
        public static string GetHashPass(string pass) =>
           String.Concat(SHA256.Create().ComputeHash(Encoding.Unicode.GetBytes(pass)).AsParallel()
               .AsOrdered().Select(p => String.Format("{0:x2}", p)));
    }
}
