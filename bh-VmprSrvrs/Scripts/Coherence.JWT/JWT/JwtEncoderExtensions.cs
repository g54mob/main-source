using System.Collections.Generic;

namespace JWT
{
	public static class JwtEncoderExtensions
	{
		public static string Encode(this IJwtEncoder encoder, object payload, string key)
		{
			return null;
		}

		public static string Encode(this IJwtEncoder encoder, object payload, byte[] key)
		{
			return null;
		}

		public static string Encode(this IJwtEncoder encoder, IDictionary<string, object> extraHeaders, object payload, string key)
		{
			return null;
		}
	}
}
