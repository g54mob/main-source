using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Mirror.Cloud.ListServerService
{
	public sealed class ListServerClientApi : ListServerBaseApi, IListServerClientApi, IBaseApi
	{
		private readonly ServerListEvent _onServerListUpdated;

		private Coroutine getServerListRepeatCoroutine;

		public event UnityAction<ServerCollectionJson> onServerListUpdated
		{
			add
			{
			}
			remove
			{
			}
		}

		public ListServerClientApi(ICoroutineRunner runner, IRequestCreator requestCreator, ServerListEvent onServerListUpdated)
			: base(null, null)
		{
		}

		public void Shutdown()
		{
		}

		public void GetServerList()
		{
		}

		public void StartGetServerListRepeat(int interval)
		{
		}

		public void StopGetServerListRepeat()
		{
		}

		private IEnumerator GetServerListRepeat(int interval)
		{
			return null;
		}

		private IEnumerator getServerList()
		{
			return null;
		}
	}
}
