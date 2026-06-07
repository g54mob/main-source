using System;
using System.Runtime.CompilerServices;

namespace BestHTTP.SignalRCore.Authentication
{
	public sealed class DefaultAccessTokenAuthenticator : IAuthenticationProvider
	{
		private HubConnection _connection;

		public bool IsPreAuthRequired => false;

		public event OnAuthenticationSuccededDelegate OnAuthenticationSucceded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnAuthenticationFailedDelegate OnAuthenticationFailed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public DefaultAccessTokenAuthenticator(HubConnection connection)
		{
		}

		public void StartAuthentication()
		{
		}

		public void PrepareRequest(HTTPRequest request)
		{
		}

		public Uri PrepareUri(Uri uri)
		{
			return null;
		}

		private Uri PrepareUriImpl(Uri uri)
		{
			return null;
		}

		public void Cancel()
		{
		}
	}
}
