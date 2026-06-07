namespace Helpers.GameCenter
{
	public class NullGameCenterAuthentication : IGameCenterAuthentication
	{
		public bool IsAuthenticated => false;

		public bool RequiresRetry => false;

		public void Authenticate()
		{
		}
	}
}
