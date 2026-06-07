using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Mirror
{
	[Obsolete]
	[DisallowMultipleComponent]
	public class NetworkMatchChecker : NetworkVisibility
	{
		private static readonly Dictionary<Guid, HashSet<NetworkIdentity>> matchPlayers;

		private Guid currentMatch;

		[SyncVar]
		public string currentMatchDebug;

		public Guid matchId
		{
			get
			{
				return default(Guid);
			}
			set
			{
			}
		}

		public string NetworkcurrentMatchDebug
		{
			get
			{
				return null;
			}
			[param: In]
			set
			{
			}
		}

		public override void OnStartServer()
		{
		}

		public override void OnStopServer()
		{
		}

		private void RebuildMatchObservers(Guid specificMatch)
		{
		}

		public override bool OnCheckObserver(NetworkConnection conn)
		{
			return false;
		}

		public override void OnRebuildObservers(HashSet<NetworkConnection> observers, bool initialize)
		{
		}

		private void MirrorProcessed()
		{
		}

		public override bool SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
			return false;
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
