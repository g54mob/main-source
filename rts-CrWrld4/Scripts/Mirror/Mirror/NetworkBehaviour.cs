using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror
{
	public abstract class NetworkBehaviour : MonoBehaviour
	{
		public struct NetworkBehaviourSyncVar : IEquatable<NetworkBehaviourSyncVar>
		{
			public uint netId;

			public byte componentIndex;

			public NetworkBehaviourSyncVar(uint netId, int componentIndex)
			{
				this.netId = 0u;
				this.componentIndex = 0;
			}

			public bool Equals(NetworkBehaviourSyncVar other)
			{
				return false;
			}

			public bool Equals(uint netId, int componentIndex)
			{
				return false;
			}

			public override string ToString()
			{
				return null;
			}
		}

		internal float lastSyncTime;

		[HideInInspector]
		public SyncMode syncMode;

		[HideInInspector]
		public float syncInterval;

		private ulong syncVarHookGuard;

		protected readonly List<SyncObject> syncObjects;

		private NetworkIdentity netIdentityCache;

		public bool isServer => false;

		public bool isClient => false;

		public bool isLocalPlayer => false;

		public bool isServerOnly => false;

		public bool isClientOnly => false;

		public bool hasAuthority => false;

		public uint netId => 0u;

		public NetworkConnection connectionToServer => null;

		public NetworkConnection connectionToClient => null;

		protected ulong syncVarDirtyBits { get; private set; }

		public NetworkIdentity netIdentity => null;

		public int ComponentIndex => 0;

		protected bool getSyncVarHookGuard(ulong dirtyBit)
		{
			return false;
		}

		protected void setSyncVarHookGuard(ulong dirtyBit, bool value)
		{
		}

		protected void InitSyncObject(SyncObject syncObject)
		{
		}

		protected void SendCommandInternal(Type invokeClass, string cmdName, NetworkWriter writer, int channelId, bool requiresAuthority = true)
		{
		}

		protected void SendRPCInternal(Type invokeClass, string rpcName, NetworkWriter writer, int channelId, bool includeOwner)
		{
		}

		protected void SendTargetRPCInternal(NetworkConnection conn, Type invokeClass, string rpcName, NetworkWriter writer, int channelId)
		{
		}

		protected bool SyncVarGameObjectEqual(GameObject newGameObject, uint netIdField)
		{
			return false;
		}

		protected void SetSyncVarGameObject(GameObject newGameObject, ref GameObject gameObjectField, ulong dirtyBit, ref uint netIdField)
		{
		}

		protected GameObject GetSyncVarGameObject(uint netId, ref GameObject gameObjectField)
		{
			return null;
		}

		protected bool SyncVarNetworkIdentityEqual(NetworkIdentity newIdentity, uint netIdField)
		{
			return false;
		}

		protected void SetSyncVarNetworkIdentity(NetworkIdentity newIdentity, ref NetworkIdentity identityField, ulong dirtyBit, ref uint netIdField)
		{
		}

		protected NetworkIdentity GetSyncVarNetworkIdentity(uint netId, ref NetworkIdentity identityField)
		{
			return null;
		}

		protected bool SyncVarNetworkBehaviourEqual<T>(T newBehaviour, NetworkBehaviourSyncVar syncField) where T : NetworkBehaviour
		{
			return false;
		}

		protected void SetSyncVarNetworkBehaviour<T>(T newBehaviour, ref T behaviourField, ulong dirtyBit, ref NetworkBehaviourSyncVar syncField) where T : NetworkBehaviour
		{
		}

		protected T GetSyncVarNetworkBehaviour<T>(NetworkBehaviourSyncVar syncNetBehaviour, ref T behaviourField) where T : NetworkBehaviour
		{
			return null;
		}

		protected bool SyncVarEqual<T>(T value, ref T fieldValue)
		{
			return false;
		}

		protected void SetSyncVar<T>(T value, ref T fieldValue, ulong dirtyBit)
		{
		}

		public void SetDirtyBit(ulong dirtyBit)
		{
		}

		public void ClearAllDirtyBits()
		{
		}

		private bool AnySyncObjectDirty()
		{
			return false;
		}

		public bool IsDirty()
		{
			return false;
		}

		public virtual bool OnSerialize(NetworkWriter writer, bool initialState)
		{
			return false;
		}

		public virtual void OnDeserialize(NetworkReader reader, bool initialState)
		{
		}

		protected virtual bool SerializeSyncVars(NetworkWriter writer, bool initialState)
		{
			return false;
		}

		protected virtual void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}

		internal ulong DirtyObjectBits()
		{
			return 0uL;
		}

		public bool SerializeObjectsAll(NetworkWriter writer)
		{
			return false;
		}

		public bool SerializeObjectsDelta(NetworkWriter writer)
		{
			return false;
		}

		internal void DeSerializeObjectsAll(NetworkReader reader)
		{
		}

		internal void DeSerializeObjectsDelta(NetworkReader reader)
		{
		}

		internal void ResetSyncObjects()
		{
		}

		public virtual void OnStartServer()
		{
		}

		public virtual void OnStopServer()
		{
		}

		public virtual void OnStartClient()
		{
		}

		public virtual void OnStopClient()
		{
		}

		public virtual void OnStartLocalPlayer()
		{
		}

		public virtual void OnStartAuthority()
		{
		}

		public virtual void OnStopAuthority()
		{
		}
	}
}
