using System.Security.Cryptography;
using System.Text;

namespace Sentry.Internal.Extensions
{
	internal static class HashExtensions
	{
		public static string GetHashString(this string str, bool upperCase = true)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(str);
			using SHA1 sHA = SHA1.Create();
			return sHA.ComputeHash(bytes).ToHexString(upperCase);
		}
	}
}
