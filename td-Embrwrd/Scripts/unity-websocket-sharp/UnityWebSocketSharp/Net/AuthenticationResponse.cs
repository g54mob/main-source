using System.Collections.Specialized;
using System.Security.Principal;

namespace UnityWebSocketSharp.Net
{
	internal class AuthenticationResponse
	{
		private uint _nonceCount;

		private NameValueCollection _parameters;

		private AuthenticationSchemes _scheme;

		internal uint NonceCount => 0u;

		internal NameValueCollection Parameters => null;

		public string Algorithm => null;

		public string Cnonce => null;

		public string Nc => null;

		public string Nonce => null;

		public string Opaque => null;

		public string Password => null;

		public string Qop => null;

		public string Realm => null;

		public string Response => null;

		public AuthenticationSchemes Scheme => default(AuthenticationSchemes);

		public string Uri => null;

		public string UserName => null;

		private AuthenticationResponse(AuthenticationSchemes scheme, NameValueCollection parameters)
		{
		}

		internal AuthenticationResponse(NetworkCredential credentials)
		{
		}

		internal AuthenticationResponse(AuthenticationChallenge challenge, NetworkCredential credentials, uint nonceCount)
		{
		}

		internal AuthenticationResponse(AuthenticationSchemes scheme, NameValueCollection parameters, NetworkCredential credentials, uint nonceCount)
		{
		}

		private static string createA1(string username, string password, string realm)
		{
			return null;
		}

		private static string createA1(string username, string password, string realm, string nonce, string cnonce)
		{
			return null;
		}

		private static string createA2(string method, string uri)
		{
			return null;
		}

		private static string createA2(string method, string uri, string entity)
		{
			return null;
		}

		private static string hash(string value)
		{
			return null;
		}

		private void initAsDigest()
		{
		}

		internal static string CreateRequestDigest(NameValueCollection parameters)
		{
			return null;
		}

		internal static AuthenticationResponse Parse(string value)
		{
			return null;
		}

		internal static NameValueCollection ParseBasicCredentials(string value)
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

		public IIdentity ToIdentity()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
