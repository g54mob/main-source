namespace Helpers.GameCenter
{
	public interface IGameCenterAuthentication
	{
		bool IsAuthenticated { get; }

		bool RequiresRetry { get; }

		void Authenticate();
	}
}
