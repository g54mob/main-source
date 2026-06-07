using System.Collections.Specialized;
using System.Security.Principal;

namespace UnityWebSocketSharp.Net
{
	internal class HttpDigestIdentity : GenericIdentity
	{
		private NameValueCollection _parameters;

		public string Algorithm => null;

		public string Cnonce => null;

		public string Nc => null;

		public string Nonce => null;

		public string Opaque => null;

		public string Qop => null;

		public string Realm => null;

		public string Response => null;

		public string Uri => null;

		internal HttpDigestIdentity(NameValueCollection parameters)
			: base(null, null)
		{
		}

		internal bool IsValid(string password, string realm, string method, string entity)
		{
			return false;
		}
	}
}
