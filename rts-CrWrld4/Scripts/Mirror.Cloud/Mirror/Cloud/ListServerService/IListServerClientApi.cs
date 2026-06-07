using UnityEngine.Events;

namespace Mirror.Cloud.ListServerService
{
	public interface IListServerClientApi : IBaseApi
	{
		event UnityAction<ServerCollectionJson> onServerListUpdated;

		void GetServerList();

		void StartGetServerListRepeat(int interval);

		void StopGetServerListRepeat();
	}
}
