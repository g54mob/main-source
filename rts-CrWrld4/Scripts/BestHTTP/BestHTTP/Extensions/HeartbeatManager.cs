using System;
using System.Collections.Generic;
using System.Threading;

namespace BestHTTP.Extensions
{
	public sealed class HeartbeatManager
	{
		private ReaderWriterLockSlim rwLock;

		private List<IHeartbeat> Heartbeats;

		private IHeartbeat[] UpdateArray;

		private DateTime LastUpdate;

		public void Subscribe(IHeartbeat heartbeat)
		{
		}

		public void Unsubscribe(IHeartbeat heartbeat)
		{
		}

		public void Update()
		{
		}

		public void Clear()
		{
		}
	}
}
