namespace UnityWebSocketSharp.Net
{
	internal class NetworkCredential
	{
		private string _domain;

		private static readonly string[] _noRoles;

		private string _password;

		private string[] _roles;

		private string _username;

		public string Domain
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public string Password
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public string[] Roles
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public string Username
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		static NetworkCredential()
		{
		}

		public NetworkCredential(string username, string password)
		{
		}

		public NetworkCredential(string username, string password, string domain, params string[] roles)
		{
		}
	}
}
