using System.Collections;
using System.Collections.Generic;
using System.IO;
using MLAPI.Serialization.Pooled;

namespace MLAPI.NetworkedVar.Collections
{
	public class NetworkedList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, INetworkedVar
	{
		public delegate void OnListChangedDelegate(NetworkedListEvent<T> changeEvent);

		private readonly IList<T> list = new List<T>();

		private readonly List<NetworkedListEvent<T>> dirtyEvents = new List<NetworkedListEvent<T>>();

		private NetworkedBehaviour networkedBehaviour;

		public readonly NetworkedVarSettings Settings = new NetworkedVarSettings();

		public float LastSyncedTime { get; internal set; }

		public int Count => list.Count;

		public bool IsReadOnly => list.IsReadOnly;

		public T this[int index]
		{
			get
			{
				return list[index];
			}
			set
			{
				if (NetworkingManager.Singleton.IsServer)
				{
					list[index] = value;
				}
				NetworkedListEvent<T> networkedListEvent = new NetworkedListEvent<T>
				{
					eventType = NetworkedListEvent<T>.EventType.Value,
					index = index,
					value = value
				};
				dirtyEvents.Add(networkedListEvent);
				if (NetworkingManager.Singleton.IsServer && this.OnListChanged != null)
				{
					this.OnListChanged(networkedListEvent);
				}
			}
		}

		public event OnListChangedDelegate OnListChanged;

		public NetworkedList()
		{
		}

		public NetworkedList(NetworkedVarSettings settings)
		{
			Settings = settings;
		}

		public NetworkedList(NetworkedVarSettings settings, IList<T> value)
		{
			Settings = settings;
			list = value;
		}

		public NetworkedList(IList<T> value)
		{
			list = value;
		}

		public void ResetDirty()
		{
			dirtyEvents.Clear();
			LastSyncedTime = NetworkingManager.Singleton.NetworkTime;
		}

		public bool IsDirty()
		{
			if (dirtyEvents.Count == 0)
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

		public string GetChannel()
		{
			return Settings.SendChannel;
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
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(stream);
			pooledBitWriter.WriteUInt16Packed((ushort)dirtyEvents.Count);
			for (int i = 0; i < dirtyEvents.Count; i++)
			{
				pooledBitWriter.WriteBits((byte)dirtyEvents[i].eventType, 3);
				switch (dirtyEvents[i].eventType)
				{
				case NetworkedListEvent<T>.EventType.Add:
					pooledBitWriter.WriteObjectPacked(dirtyEvents[i].value);
					break;
				case NetworkedListEvent<T>.EventType.Insert:
					pooledBitWriter.WriteInt32Packed(dirtyEvents[i].index);
					pooledBitWriter.WriteObjectPacked(dirtyEvents[i].value);
					break;
				case NetworkedListEvent<T>.EventType.Remove:
					pooledBitWriter.WriteObjectPacked(dirtyEvents[i].value);
					break;
				case NetworkedListEvent<T>.EventType.RemoveAt:
					pooledBitWriter.WriteInt32Packed(dirtyEvents[i].index);
					break;
				case NetworkedListEvent<T>.EventType.Value:
					pooledBitWriter.WriteInt32Packed(dirtyEvents[i].index);
					pooledBitWriter.WriteObjectPacked(dirtyEvents[i].value);
					break;
				}
			}
		}

		public void WriteField(Stream stream)
		{
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(stream);
			pooledBitWriter.WriteUInt16Packed((ushort)list.Count);
			for (int i = 0; i < list.Count; i++)
			{
				pooledBitWriter.WriteObjectPacked(list[i]);
			}
		}

		public void ReadField(Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			list.Clear();
			ushort num = pooledBitReader.ReadUInt16Packed();
			for (int i = 0; i < num; i++)
			{
				list.Add((T)pooledBitReader.ReadObjectPacked(typeof(T)));
			}
		}

		public void ReadDelta(Stream stream, bool keepDirtyDelta)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			ushort num = pooledBitReader.ReadUInt16Packed();
			for (int i = 0; i < num; i++)
			{
				NetworkedListEvent<T>.EventType eventType = (NetworkedListEvent<T>.EventType)pooledBitReader.ReadBits(3);
				switch (eventType)
				{
				case NetworkedListEvent<T>.EventType.Add:
					list.Add((T)pooledBitReader.ReadObjectPacked(typeof(T)));
					if (this.OnListChanged != null)
					{
						this.OnListChanged(new NetworkedListEvent<T>
						{
							eventType = eventType,
							index = list.Count - 1,
							value = list[list.Count - 1]
						});
					}
					if (keepDirtyDelta)
					{
						dirtyEvents.Add(new NetworkedListEvent<T>
						{
							eventType = eventType,
							index = list.Count - 1,
							value = list[list.Count - 1]
						});
					}
					break;
				case NetworkedListEvent<T>.EventType.Insert:
				{
					int index2 = pooledBitReader.ReadInt32Packed();
					list.Insert(index2, (T)pooledBitReader.ReadObjectPacked(typeof(T)));
					if (this.OnListChanged != null)
					{
						this.OnListChanged(new NetworkedListEvent<T>
						{
							eventType = eventType,
							index = index2,
							value = list[index2]
						});
					}
					if (keepDirtyDelta)
					{
						dirtyEvents.Add(new NetworkedListEvent<T>
						{
							eventType = eventType,
							index = index2,
							value = list[index2]
						});
					}
					break;
				}
				case NetworkedListEvent<T>.EventType.Remove:
				{
					T val = (T)pooledBitReader.ReadObjectPacked(typeof(T));
					int index = list.IndexOf(val);
					list.RemoveAt(index);
					if (this.OnListChanged != null)
					{
						this.OnListChanged(new NetworkedListEvent<T>
						{
							eventType = eventType,
							index = index,
							value = val
						});
					}
					if (keepDirtyDelta)
					{
						dirtyEvents.Add(new NetworkedListEvent<T>
						{
							eventType = eventType,
							index = index,
							value = val
						});
					}
					break;
				}
				case NetworkedListEvent<T>.EventType.RemoveAt:
				{
					int index3 = pooledBitReader.ReadInt32Packed();
					T value2 = list[index3];
					list.RemoveAt(index3);
					if (this.OnListChanged != null)
					{
						this.OnListChanged(new NetworkedListEvent<T>
						{
							eventType = eventType,
							index = index3,
							value = value2
						});
					}
					if (keepDirtyDelta)
					{
						dirtyEvents.Add(new NetworkedListEvent<T>
						{
							eventType = eventType,
							index = index3,
							value = value2
						});
					}
					break;
				}
				case NetworkedListEvent<T>.EventType.Value:
				{
					int num2 = pooledBitReader.ReadInt32Packed();
					T value = (T)pooledBitReader.ReadObjectPacked(typeof(T));
					if (num2 < list.Count)
					{
						list[num2] = value;
					}
					if (this.OnListChanged != null)
					{
						this.OnListChanged(new NetworkedListEvent<T>
						{
							eventType = eventType,
							index = num2,
							value = value
						});
					}
					if (keepDirtyDelta)
					{
						dirtyEvents.Add(new NetworkedListEvent<T>
						{
							eventType = eventType,
							index = num2,
							value = value
						});
					}
					break;
				}
				case NetworkedListEvent<T>.EventType.Clear:
					list.Clear();
					if (this.OnListChanged != null)
					{
						this.OnListChanged(new NetworkedListEvent<T>
						{
							eventType = eventType
						});
					}
					if (keepDirtyDelta)
					{
						dirtyEvents.Add(new NetworkedListEvent<T>
						{
							eventType = eventType
						});
					}
					break;
				}
			}
		}

		public void SetNetworkedBehaviour(NetworkedBehaviour behaviour)
		{
			networkedBehaviour = behaviour;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)list).GetEnumerator();
		}

		public void Add(T item)
		{
			if (NetworkingManager.Singleton.IsServer)
			{
				list.Add(item);
			}
			NetworkedListEvent<T> networkedListEvent = new NetworkedListEvent<T>
			{
				eventType = NetworkedListEvent<T>.EventType.Add,
				value = item,
				index = list.Count - 1
			};
			dirtyEvents.Add(networkedListEvent);
			if (NetworkingManager.Singleton.IsServer && this.OnListChanged != null)
			{
				this.OnListChanged(networkedListEvent);
			}
		}

		public void Clear()
		{
			if (NetworkingManager.Singleton.IsServer)
			{
				list.Clear();
			}
			NetworkedListEvent<T> networkedListEvent = new NetworkedListEvent<T>
			{
				eventType = NetworkedListEvent<T>.EventType.Clear
			};
			dirtyEvents.Add(networkedListEvent);
			if (NetworkingManager.Singleton.IsServer && this.OnListChanged != null)
			{
				this.OnListChanged(networkedListEvent);
			}
		}

		public bool Contains(T item)
		{
			return list.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(T item)
		{
			if (NetworkingManager.Singleton.IsServer)
			{
				list.Remove(item);
			}
			NetworkedListEvent<T> networkedListEvent = new NetworkedListEvent<T>
			{
				eventType = NetworkedListEvent<T>.EventType.Remove,
				value = item
			};
			dirtyEvents.Add(networkedListEvent);
			if (NetworkingManager.Singleton.IsServer && this.OnListChanged != null)
			{
				this.OnListChanged(networkedListEvent);
			}
			return true;
		}

		public int IndexOf(T item)
		{
			return list.IndexOf(item);
		}

		public void Insert(int index, T item)
		{
			if (NetworkingManager.Singleton.IsServer)
			{
				list.Insert(index, item);
			}
			NetworkedListEvent<T> networkedListEvent = new NetworkedListEvent<T>
			{
				eventType = NetworkedListEvent<T>.EventType.Insert,
				index = index,
				value = item
			};
			dirtyEvents.Add(networkedListEvent);
			if (NetworkingManager.Singleton.IsServer && this.OnListChanged != null)
			{
				this.OnListChanged(networkedListEvent);
			}
		}

		public void RemoveAt(int index)
		{
			if (NetworkingManager.Singleton.IsServer)
			{
				list.RemoveAt(index);
			}
			NetworkedListEvent<T> networkedListEvent = new NetworkedListEvent<T>
			{
				eventType = NetworkedListEvent<T>.EventType.RemoveAt,
				index = index
			};
			dirtyEvents.Add(networkedListEvent);
			if (NetworkingManager.Singleton.IsServer && this.OnListChanged != null)
			{
				this.OnListChanged(networkedListEvent);
			}
		}
	}
}
