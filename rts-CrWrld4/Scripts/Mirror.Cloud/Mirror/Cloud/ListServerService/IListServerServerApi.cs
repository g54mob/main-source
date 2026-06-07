namespace Mirror.Cloud.ListServerService
{
	public interface IListServerServerApi : IBaseApi
	{
		bool ServerInList { get; }

		void AddServer(ServerJson server);

		void UpdateServer(int newPlayerCount);

		void UpdateServer(ServerJson server);

		void RemoveServer();
	}
}
