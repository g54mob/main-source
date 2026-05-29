using System;
using System.Runtime.CompilerServices;
using FishNet.Managing;
using FishNet.Serializing;
using FishNet.Transporting;

namespace FishNet.Object.Synchronizing.Internal
{
	public class SyncBase : ISyncType
	{
		public Settings Settings;

		public NetworkManager NetworkManager;

		public NetworkBehaviour NetworkBehaviour;

		public uint NextSyncTick;

		private uint _timeToTicks;

		private Channel _currentChannel;

		public bool IsRegistered { get; private set; }

		public bool IsNetworkInitialized => false;

		public bool IsSyncObject { get; private set; }

		public float SendRate => 0f;

		public bool IsDirty { get; private set; }

		public bool OnStartServerCalled { get; private set; }

		public bool OnStartClientCalled { get; private set; }

		public uint SyncIndex { get; protected set; }

		internal Channel Channel => default(Channel);

		public void InitializeInstance(NetworkBehaviour nb, uint syncIndex, WritePermission writePermissions, ReadPermission readPermissions, float tickRate, Channel channel, bool isSyncObject)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetRegistered()
		{
		}

		protected virtual void Registered()
		{
		}

		public void PreInitialize(NetworkManager networkManager)
		{
		}

		public virtual void OnStartCallback(bool asServer)
		{
		}

		public virtual void OnStopCallback(bool asServer)
		{
		}

		protected bool CanNetworkSetValues(bool warn = true)
		{
			return false;
		}

		protected void LogServerNotActiveWarning()
		{
		}

		public bool Dirty()
		{
			return false;
		}

		internal void ResetDirty()
		{
		}

		internal bool SyncTimeMet(uint tick)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public virtual void WriteDelta(PooledWriter writer, bool resetSyncTick = true)
		{
		}

		protected virtual void WriteHeader(PooledWriter writer, bool resetSyncTick = true)
		{
		}

		public virtual void WriteFull(PooledWriter writer)
		{
		}

		[Obsolete("Use Read(PooledReader, bool).")]
		public virtual void Read(PooledReader reader)
		{
		}

		public virtual void Read(PooledReader reader, bool asServer)
		{
		}

		[Obsolete("Use ResetState().")]
		public virtual void Reset()
		{
		}

		public virtual void ResetState()
		{
		}
	}
}
