using System;
using System.Collections.Generic;
using System.IO;
using MLAPI.Serialization.Pooled;
using UnityEngine;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVar<T> : INetworkedVar
	{
		public delegate void OnValueChangedDelegate(T previousValue, T newValue);

		public readonly NetworkedVarSettings Settings = new NetworkedVarSettings();

		public OnValueChangedDelegate OnValueChanged;

		private NetworkedBehaviour networkedBehaviour;

		[SerializeField]
		private T InternalValue;

		public bool isDirty { get; set; }

		public float LastSyncedTime { get; internal set; }

		public T Value
		{
			get
			{
				return InternalValue;
			}
			set
			{
				if (!EqualityComparer<T>.Default.Equals(InternalValue, value))
				{
					isDirty = true;
					T internalValue = InternalValue;
					InternalValue = value;
					if (OnValueChanged != null)
					{
						OnValueChanged(internalValue, InternalValue);
					}
				}
			}
		}

		public NetworkedVar()
		{
		}

		public NetworkedVar(NetworkedVarSettings settings)
		{
			Settings = settings;
		}

		public NetworkedVar(NetworkedVarSettings settings, T value)
		{
			Settings = settings;
			InternalValue = value;
		}

		public NetworkedVar(T value)
		{
			InternalValue = value;
		}

		public void ResetDirty()
		{
			isDirty = false;
			LastSyncedTime = NetworkingManager.Singleton.NetworkTime;
		}

		public bool IsDirty()
		{
			if (!isDirty)
			{
				return false;
			}
			if (Settings.SendTickrate == 0f)
			{
				return true;
			}
			if (Settings.SendTickrate < 0f)
			{
				return false;
			}
			if (NetworkingManager.Singleton.NetworkTime - LastSyncedTime >= 1f / Settings.SendTickrate)
			{
				return true;
			}
			return false;
		}

		public bool CanClientRead(ulong clientId)
		{
			switch (Settings.ReadPermission)
			{
			case NetworkedVarPermission.Everyone:
				return true;
			case NetworkedVarPermission.ServerOnly:
				return false;
			case NetworkedVarPermission.OwnerOnly:
				return networkedBehaviour.OwnerClientId == clientId;
			case NetworkedVarPermission.Custom:
				if (Settings.ReadPermissionCallback == null)
				{
					return false;
				}
				return Settings.ReadPermissionCallback(clientId);
			default:
				return true;
			}
		}

		public void WriteDelta(Stream stream)
		{
			WriteField(stream);
		}

		public bool CanClientWrite(ulong clientId)
		{
			switch (Settings.WritePermission)
			{
			case NetworkedVarPermission.Everyone:
				return true;
			case NetworkedVarPermission.ServerOnly:
				return false;
			case NetworkedVarPermission.OwnerOnly:
				return networkedBehaviour.OwnerClientId == clientId;
			case NetworkedVarPermission.Custom:
				if (Settings.WritePermissionCallback == null)
				{
					return false;
				}
				return Settings.WritePermissionCallback(clientId);
			default:
				return true;
			}
		}

		public void ReadDelta(Stream stream, bool keepDirtyDelta)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			T internalValue = InternalValue;
			InternalValue = (T)pooledBitReader.ReadObjectPacked(typeof(T));
			if (keepDirtyDelta)
			{
				isDirty = true;
			}
			if (OnValueChanged != null)
			{
				OnValueChanged(internalValue, InternalValue);
			}
		}

		public void SetNetworkedBehaviour(NetworkedBehaviour behaviour)
		{
			networkedBehaviour = behaviour;
		}

		public void ReadField(Stream stream)
		{
			ReadDelta(stream, keepDirtyDelta: false);
		}

		public void WriteField(Stream stream)
		{
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(stream);
			pooledBitWriter.WriteObjectPacked(InternalValue);
		}

		public string GetChannel()
		{
			return Settings.SendChannel;
		}
	}
}
