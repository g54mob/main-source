using System.Collections.Specialized;

namespace UnityWebSocketSharp.Net
{
	internal class AuthenticationChallenge
	{
		private NameValueCollection _parameters;

		private AuthenticationSchemes _scheme;

		internal NameValueCollection Parameters => null;

		public string Algorithm => null;

		public string Domain => null;

		public string Nonce => null;

		public string Opaque => null;

		public string Qop => null;

		public string Realm => null;

		public AuthenticationSchemes Scheme => default(AuthenticationSchemes);

		public string Stale => null;

		private AuthenticationChallenge(AuthenticationSchemes scheme, NameValueCollection parameters)
		{
		}

		internal AuthenticationChallenge(AuthenticationSchemes scheme, string realm)
		{
		}

		internal static AuthenticationChallenge CreateBasicChallenge(string realm)
		{
			return null;
		}

		internal static AuthenticationChallenge CreateDigestChallenge(string realm)
		{
			return null;
		}

		internal static string CreateNonceValue()
		{
			return null;
		}

		internal static AuthenticationChallenge Parse(string value)
		{
			return null;
		}

		internal static NameValueCollection ParseParameters(string value)
		{
			return null;
		}

		internal string ToBasicString()
		{
			return null;
		}

		internal string ToDigestString()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
