using System.Collections;
using UnityEngine;

namespace Mirror.Cloud.ListServerService
{
	public sealed class ListServerServerApi : ListServerBaseApi, IListServerServerApi, IBaseApi
	{
		private const int PingInterval = 20;

		private const int MaxPingFails = 15;

		private ServerJson currentServer;

		private string serverId;

		private Coroutine _pingCoroutine;

		private bool added;

		private bool sending;

		private bool skipNextPing;

		private int pingFails;

		public bool ServerInList => false;

		public ListServerServerApi(ICoroutineRunner runner, IRequestCreator requestCreator)
			: base(null, null)
		{
		}

		public void Shutdown()
		{
		}

		public void AddServer(ServerJson server)
		{
		}

		public void UpdateServer(int newPlayerCount)
		{
		}

		public void UpdateServer(ServerJson server)
		{
		}

		public void RemoveServer()
		{
		}

		private void stopPingCoroutine()
		{
		}

		private IEnumerator addServer(ServerJson server)
		{
			return null;
		}

		private IEnumerator updateServer(PartialServerJson server)
		{
			return null;
		}

		private IEnumerator ping()
		{
			return null;
		}

		private IEnumerator removeServer()
		{
			return null;
		}

		private void removeServerWithoutCoroutine()
		{
		}
	}
}
