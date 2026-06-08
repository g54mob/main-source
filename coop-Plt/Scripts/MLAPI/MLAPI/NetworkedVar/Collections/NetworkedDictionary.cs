using System.Collections;
using System.Collections.Generic;
using System.IO;
using MLAPI.Serialization.Pooled;

namespace MLAPI.NetworkedVar.Collections
{
	public class NetworkedDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, INetworkedVar
	{
		public delegate void OnDictionaryChangedDelegate(NetworkedDictionaryEvent<TKey, TValue> changeEvent);

		public readonly NetworkedVarSettings Settings = new NetworkedVarSettings();

		private readonly IDictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

		private NetworkedBehaviour networkedBehaviour;

		private readonly List<NetworkedDictionaryEvent<TKey, TValue>> dirtyEvents = new List<NetworkedDictionaryEvent<TKey, TValue>>();

		public float LastSyncedTime { get; internal set; }

		public TValue this[TKey key]
		{
			get
			{
				return dictionary[key];
			}
			set
			{
				if (NetworkingManager.Singleton.IsServer)
				{
					dictionary[key] = value;
				}
				NetworkedDictionaryEvent<TKey, TValue> networkedDictionaryEvent = new NetworkedDictionaryEvent<TKey, TValue>
				{
					eventType = NetworkedDictionaryEvent<TKey, TValue>.NetworkedListEventType.Value,
					key = key,
					value = value
				};
				dirtyEvents.Add(networkedDictionaryEvent);
				if (NetworkingManager.Singleton.IsServer && this.OnDictionaryChanged != null)
				{
					this.OnDictionaryChanged(networkedDictionaryEvent);
				}
			}
		}

		public ICollection<TKey> Keys => dictionary.Keys;

		public ICollection<TValue> Values => dictionary.Values;

		public int Count => dictionary.Count;

		public bool IsReadOnly => dictionary.IsReadOnly;

		public event OnDictionaryChangedDelegate OnDictionaryChanged;

		public NetworkedDictionary()
		{
		}

		public NetworkedDictionary(NetworkedVarSettings settings)
		{
			Settings = settings;
		}

		public NetworkedDictionary(NetworkedVarSettings settings, IDictionary<TKey, TValue> value)
		{
			Settings = settings;
			dictionary = value;
		}

		public NetworkedDictionary(IDictionary<TKey, TValue> value)
		{
			dictionary = value;
		}

		public void ResetDirty()
		{
			dirtyEvents.Clear();
			LastSyncedTime = NetworkingManager.Singleton.NetworkTime;
		}

		public string GetChannel()
		{
			return Settings.SendChannel;
		}

		public void ReadDelta(Stream stream, bool keepDirtyDelta)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			ushort num = pooledBitReader.ReadUInt16Packed();
			for (int i = 0; i < num; i++)
			{
				NetworkedDictionaryEvent<TKey, TValue>.NetworkedListEventType networkedListEventType = (NetworkedDictionaryEvent<TKey, TValue>.NetworkedListEventType)pooledBitReader.ReadBits(3);
				switch (networkedListEventType)
				{
				case NetworkedDictionaryEvent<TKey, TValue>.NetworkedListEventType.Add:
				{
					TKey key4 = (TKey)pooledBitReader.ReadObjectPacked(typeof(TKey));
					TValue value4 = (TValue)pooledBitReader.ReadObjectPacked(typeof(TValue));
					dictionary.Add(key4, value4);
					if (this.OnDictionaryChanged != null)
					{
						this.OnDictionaryChanged(new NetworkedDictionaryEvent<TKey, TValue>
						{
							eventType = networkedListEventType,
							key = key4,
							value = value4
						});
					}
					if (keepDirtyDelta)
					{
						dirtyEvents.Add(new NetworkedDictionaryEvent<TKey, TValue>
						{
							eventType = networkedListEventType,
							key = key4,
							value = value4
						});
					}
					break;
				}
				case NetworkedDictionaryEvent<TKey, TValue>.NetworkedListEventType.Remove:
				{
					TKey key3 = (TKey)pooledBitReader.ReadObjectPacked(typeof(TKey));
					dictionary.TryGetValue(key3, out var value3);
					dictionary.Remove(key3);
					if (this.OnDictionaryChanged != null)
					{
						this.OnDictionaryChanged(new NetworkedDictionaryEvent<TKey, TValue>
						{
							eventType = networkedListEventType,
							key = key3,
							value = value3
						});
					}
					if (keepDirtyDelta)
					{
						dirtyEvents.Add(new NetworkedDictionaryEvent<TKey, TValue>
						{
							eventType = networkedListEventType,
							key = key3,
							value = value3
						});
					}
					break;
				}
				case NetworkedDictionaryEvent<TKey, TValue>.NetworkedListEventType.RemovePair:
				{
					TKey key2 = (TKey)pooledBitReader.ReadObjectPacked(typeof(TKey));
					TValue value2 = (TValue)pooledBitReader.ReadObjectPacked(typeof(TValue));
					dictionary.Remove(new KeyValuePair<TKey, TValue>(key2, value2));
					if (this.OnDictionaryChanged != null)
					{
						this.OnDictionaryChanged(new NetworkedDictionaryEvent<TKey, TValue>
						{
							eventType = networkedListEventType,
							key = key2,
							value = value2
						});
					}
					if (keepDirtyDelta)
					{
						dirtyEvents.Add(new NetworkedDictionaryEvent<TKey, TValue>
						{
							eventType = networkedListEventType,
							key = key2,
							value = value2
						});
					}
					break;
				}
				case NetworkedDictionaryEvent<TKey, TValue>.NetworkedListEventType.Clear:
					dictionary.Clear();
					if (this.OnDictionaryChanged != null)
					{
						this.OnDictionaryChanged(new NetworkedDictionaryEvent<TKey, TValue>
						{
							eventType = networkedListEventType
						});
					}
					if (keepDirtyDelta)
					{
						dirtyEvents.Add(new NetworkedDictionaryEvent<TKey, TValue>
						{
							eventType = networkedListEventType
						});
					}
					break;
				case NetworkedDictionaryEvent<TKey, TValue>.NetworkedListEventType.Value:
				{
					TKey key = (TKey)pooledBitReader.ReadObjectPacked(typeof(TKey));
					TValue value = (TValue)pooledBitReader.ReadObjectPacked(typeof(TValue));
					dictionary[key] = value;
					if (this.OnDictionaryChanged != null)
					{
						this.OnDictionaryChanged(new NetworkedDictionaryEvent<TKey, TValue>
						{
							eventType = networkedListEventType,
							key = key,
							value = value
						});
					}
					if (keepDirtyDelta)
					{
						dirtyEvents.Add(new NetworkedDictionaryEvent<TKey, TValue>
						{
							eventType = networkedListEventType,
							key = key,
							value = value
						});
					}
					break;
				}
				}
			}
		}

		public void ReadField(Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			dictionary.Clear();
			ushort num = pooledBitReader.ReadUInt16Packed();
			for (int i = 0; i < num; i++)
			{
				TKey key = (TKey)pooledBitReader.ReadObjectPacked(typeof(TKey));
				TValue value = (TValue)pooledBitReader.ReadObjectPacked(typeof(TValue));
				dictionary.Add(key, value);
			}
		}

		public void SetNetworkedBehaviour(NetworkedBehaviour behaviour)
		{
			networkedBehaviour = behaviour;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return dictionary.TryGetValue(key, out value);
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
				case NetworkedDictionaryEvent<TKey, TValue>.NetworkedListEventType.Add:
					pooledBitWriter.WriteObjectPacked(dirtyEvents[i].key);
					pooledBitWriter.WriteObjectPacked(dirtyEvents[i].value);
					break;
				case NetworkedDictionaryEvent<TKey, TValue>.NetworkedListEventType.Remove:
					pooledBitWriter.WriteObjectPacked(dirtyEvents[i].key);
					break;
				case NetworkedDictionaryEvent<TKey, TValue>.NetworkedListEventType.RemovePair:
					pooledBitWriter.WriteObjectPacked(dirtyEvents[i].key);
					pooledBitWriter.WriteObjectPacked(dirtyEvents[i].value);
					break;
				case NetworkedDictionaryEvent<TKey, TValue>.NetworkedListEventType.Value:
					pooledBitWriter.WriteObjectPacked(dirtyEvents[i].key);
					pooledBitWriter.WriteObjectPacked(dirtyEvents[i].value);
					break;
				}
			}
		}

		public void WriteField(Stream stream)
		{
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(stream);
			pooledBitWriter.WriteUInt16Packed((ushort)dictionary.Count);
			foreach (KeyValuePair<TKey, TValue> item in dictionary)
			{
				pooledBitWriter.WriteObjectPacked(item.Key);
				pooledBitWriter.WriteObjectPacked(item.Value);
			}
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

		public void Add(TKey key, TValue value)
		{
			if (NetworkingManager.Singleton.IsServer)
			{
				dictionary.Add(key, value);
			}
			NetworkedDictionaryEvent<TKey, TValue> networkedDictionaryEvent = new NetworkedDictionaryEvent<TKey, TValue>
			{
				eventType = NetworkedDictionaryEvent<TKey, TValue>.NetworkedListEventType.Add,
				key = key,
				value = value
			};
			dirtyEvents.Add(networkedDictionaryEvent);
			if (NetworkingManager.Singleton.IsServer && this.OnDictionaryChanged != null)
			{
				this.OnDictionaryChanged(networkedDictionaryEvent);
			}
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			if (NetworkingManager.Singleton.IsServer)
			{
				dictionary.Add(item);
			}
			NetworkedDictionaryEvent<TKey, TValue> networkedDictionaryEvent = new NetworkedDictionaryEvent<TKey, TValue>
			{
				eventType = NetworkedDictionaryEvent<TKey, TValue>.NetworkedListEventType.Add,
				key = item.Key,
				value = item.Value
			};
			dirtyEvents.Add(networkedDictionaryEvent);
			if (NetworkingManager.Singleton.IsServer && this.OnDictionaryChanged != null)
			{
				this.OnDictionaryChanged(networkedDictionaryEvent);
			}
		}

		public void Clear()
		{
			if (NetworkingManager.Singleton.IsServer)
			{
				dictionary.Clear();
			}
			NetworkedDictionaryEvent<TKey, TValue> networkedDictionaryEvent = new NetworkedDictionaryEvent<TKey, TValue>
			{
				eventType = NetworkedDictionaryEvent<TKey, TValue>.NetworkedListEventType.Clear
			};
			dirtyEvents.Add(networkedDictionaryEvent);
			if (NetworkingManager.Singleton.IsServer && this.OnDictionaryChanged != null)
			{
				this.OnDictionaryChanged(networkedDictionaryEvent);
			}
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return dictionary.Contains(item);
		}

		public bool ContainsKey(TKey key)
		{
			return dictionary.ContainsKey(key);
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			dictionary.CopyTo(array, arrayIndex);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return dictionary.GetEnumerator();
		}

		public bool Remove(TKey key)
		{
			if (NetworkingManager.Singleton.IsServer)
			{
				dictionary.Remove(key);
			}
			dictionary.TryGetValue(key, out var value);
			NetworkedDictionaryEvent<TKey, TValue> networkedDictionaryEvent = new NetworkedDictionaryEvent<TKey, TValue>
			{
				eventType = NetworkedDictionaryEvent<TKey, TValue>.NetworkedListEventType.Remove,
				key = key,
				value = value
			};
			dirtyEvents.Add(networkedDictionaryEvent);
			if (NetworkingManager.Singleton.IsServer && this.OnDictionaryChanged != null)
			{
				this.OnDictionaryChanged(networkedDictionaryEvent);
			}
			return true;
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			if (NetworkingManager.Singleton.IsServer)
			{
				dictionary.Remove(item);
			}
			NetworkedDictionaryEvent<TKey, TValue> networkedDictionaryEvent = new NetworkedDictionaryEvent<TKey, TValue>
			{
				eventType = NetworkedDictionaryEvent<TKey, TValue>.NetworkedListEventType.RemovePair,
				key = item.Key,
				value = item.Value
			};
			dirtyEvents.Add(networkedDictionaryEvent);
			if (NetworkingManager.Singleton.IsServer && this.OnDictionaryChanged != null)
			{
				this.OnDictionaryChanged(networkedDictionaryEvent);
			}
			return true;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return dictionary.GetEnumerator();
		}
	}
}
