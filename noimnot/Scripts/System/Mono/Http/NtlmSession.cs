using System.Net;
using Mono.Security.Protocol.Ntlm;

namespace Mono.Http
{
	internal class NtlmSession
	{
		private MessageBase message;

		public Authorization Authenticate(string challenge, WebRequest webRequest, ICredentials credentials)
		{
			return null;
		}
	}
}
