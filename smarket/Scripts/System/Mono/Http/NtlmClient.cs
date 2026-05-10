using System.Net;
using System.Runtime.CompilerServices;

namespace Mono.Http
{
	internal class NtlmClient : IAuthenticationModule
	{
		private static readonly ConditionalWeakTable<HttpWebRequest, NtlmSession> cache;

		public string AuthenticationType => null;

		public Authorization Authenticate(string challenge, WebRequest webRequest, ICredentials credentials)
		{
			return null;
		}

		public Authorization PreAuthenticate(WebRequest webRequest, ICredentials credentials)
		{
			return null;
		}
	}
}
