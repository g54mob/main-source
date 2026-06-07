using System.Collections;

namespace Mirror.Authenticators
{
	public class TimeoutAuthenticator : NetworkAuthenticator
	{
		public NetworkAuthenticator authenticator;

		public float timeout;

		public void Awake()
		{
		}

		public override void OnStartServer()
		{
		}

		public override void OnStopServer()
		{
		}

		public override void OnStartClient()
		{
		}

		public override void OnStopClient()
		{
		}

		public override void OnServerAuthenticate(NetworkConnection conn)
		{
		}

		public override void OnClientAuthenticate(NetworkConnection conn)
		{
		}

		private IEnumerator BeginAuthentication(NetworkConnection conn)
		{
			return null;
		}
	}
}
