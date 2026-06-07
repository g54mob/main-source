using System.Security.Principal;

namespace UnityWebSocketSharp.Net
{
	internal class HttpBasicIdentity : GenericIdentity
	{
		private string _password;

		public virtual string Password => null;

		internal HttpBasicIdentity(string username, string password)
			: base(null, null)
		{
		}
	}
}
