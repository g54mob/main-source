using System;
using System.Collections.Generic;
using Assets.Scripts.Flight;
using Assets.Scripts.Multiplayer.FlightObjects.Spawners;
using Assets.Scripts.Multiplayer.FlightObjects.Spawners.Events;
using FishNet.Serializing;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects
{
	public class NetworkedAreaScript : MonoBehaviour, INetworkedArea
	{
		private class ItemWrapper
		{
			public float Delta { get; set; }

			public INetworkedAreaItem Item { get; set; }

			public ItemWrapper()
			{
			}

			public ItemWrapper(INetworkedAreaItem item)
			{
				Item = item;
			}
		}

		private class NetworkedItemPlaceholder : INetworkedAreaItem
		{
			public bool IsActive { get; set; }

			public byte ItemID { get; }

			public float TimeSinceLastWrite => 0f;

			public NetworkedItemPlaceholder(byte itemID)
			{
				ItemID = itemID;
			}

			public float CalculateDelta()
			{
				return 0f;
			}

			public void InitializeArea(INetworkedArea area, byte itemID)
			{
			}

			public void ReadState(PooledReader reader, float timeDelta)
			{
			}

			public void UpdateLastWriteTime()
			{
			}

			public void WriteState(PooledWriter writer)
			{
			}
		}

		private NetworkedAreaComponent _areaComponent;

		[SerializeField]
		private int _debugDisplayNumObjectsSerialized;

		private FlightSceneNetworkScript _fsn;

		private bool _initialized;

		private bool _isOwner;

		private List<ItemWrapper> _items = new List<ItemWrapper>();

		private float _lastReadPhysicsTime;

		[SerializeField]
		private int _maxItemStatesPerMessage = 5;

		[SerializeField]
		private float _minimumDeltaThreshold = 1f;

		private SimpleSpawnerClientScript _spawner;

		public bool Initialized => _initialized;

		public bool IsFlightObjectLoaded { get; private set; }

		public bool IsOwner
		{
			get
			{
				return _isOwner;
			}
			private set
			{
				if (_isOwner != value)
				{
					_isOwner = value;
					this.OwnershipChanged?.Invoke(_isOwner);
				}
			}
		}

		public NetworkFlightObject NetworkFlightObject => _areaComponent?.NetworkFlightObject;

		public event Action<NetworkFlightObject> FlightObjectLoaded;

		public event Action<NetworkFlightObject> FlightObjectUnloaded;

		public event Action<bool> OwnershipChanged;

		public byte AsyncRegistrationBegin()
		{
			byte b = (byte)_items.Count;
			_items.Add(new ItemWrapper(new NetworkedItemPlaceholder(b)));
			return b;
		}

		public void AsyncRegistrationComplete(INetworkedAreaItem item, byte itemId)
		{
			if (_items.Count <= itemId)
			{
				Debug.LogError("Attempted to complete the async registration of a networked area item with " + $"id '{itemId}' for networked area '{base.name}', but only {_items.Count} items are registered.");
				return;
			}
			if (!(_items[itemId].Item is NetworkedItemPlaceholder))
			{
				Debug.LogError("Attempted to complete the async registration of a networked area item with " + $"id '{itemId}' for networked area '{base.name}', but an item with that id already exists.");
				return;
			}
			_items[itemId].Item = item;
			item.InitializeArea(this, itemId);
		}

		public void OnOwnershipChanged(bool isOwner)
		{
			IsOwner = isOwner;
		}

		public void ReadState(PooledReader reader)
		{
			float num = reader.ReadSingle();
			float timeDelta = _fsn.PhysicsTime - num;
			if (!(_lastReadPhysicsTime <= num))
			{
				return;
			}
			_lastReadPhysicsTime = num;
			byte b = reader.ReadUInt8Unpacked();
			for (int i = 0; i < b; i++)
			{
				byte b2 = reader.ReadUInt8Unpacked();
				bool flag = reader.ReadBoolean();
				int num2 = (flag ? reader.ReadUInt16Unpacked() : 0);
				int position = reader.Position;
				INetworkedAreaItem networkedAreaItem = ((b2 < _items.Count) ? _items[b2].Item : null);
				if (networkedAreaItem is NetworkedItemPlaceholder)
				{
					reader.Position += num2;
					continue;
				}
				try
				{
					if (networkedAreaItem.IsActive != flag)
					{
						networkedAreaItem.IsActive = flag;
					}
					if (flag)
					{
						networkedAreaItem.ReadState(reader, timeDelta);
					}
				}
				catch (Exception exception)
				{
					Debug.LogError($"Failed to read state with item ID {b2}. " + $"Expected bytes read: {num2}. " + $"Actual bytes read: {reader.Position - position}. " + $"Length of array is {_items.Count}. Frame {Time.frameCount}");
					Debug.LogException(exception);
					int num3 = position + num2;
					if (i == b - 1 || num3 >= reader.Length)
					{
						break;
					}
					reader.Position = num3;
				}
				int num4 = reader.Position - position;
				if (num4 < num2)
				{
					reader.Position = position + num2;
				}
				else if (num4 > num2)
				{
					Debug.LogError($"An item in a networked area tried to read more state data bytes than were available to be read ({num4} read, {num2} expected).{System.Environment.NewLine}" + "Flight Object: " + base.name + " (" + GetType().FullName + ")" + System.Environment.NewLine + "Item: " + ((networkedAreaItem as MonoBehaviour)?.name ?? "unknown") + " (" + (networkedAreaItem?.GetType().FullName ?? "null") + ")");
				}
			}
		}

		public void WriteState(PooledWriter writer)
		{
			writer.WriteSingle(_fsn.PhysicsTime);
			List<ItemWrapper> value;
			using (CollectionPool<List<ItemWrapper>, ItemWrapper>.Get(out value))
			{
				(ItemWrapper, float) tuple = (null, float.MinValue);
				foreach (ItemWrapper item in _items)
				{
					item.Delta = item.Item.CalculateDelta();
					if (item.Delta > _minimumDeltaThreshold)
					{
						value.Add(item);
					}
					if (item.Item.TimeSinceLastWrite > tuple.Item2)
					{
						tuple = (item, item.Item.TimeSinceLastWrite);
					}
				}
				value.Sort((ItemWrapper a, ItemWrapper b) => b.Delta.CompareTo(a.Delta));
				if (value.Count > _maxItemStatesPerMessage)
				{
					value.RemoveRange(_maxItemStatesPerMessage, value.Count - _maxItemStatesPerMessage);
				}
				else if (tuple.Item1 != null && !value.Contains(tuple.Item1) && !(tuple.Item1.Item is NetworkedItemPlaceholder))
				{
					value.Add(tuple.Item1);
				}
				_debugDisplayNumObjectsSerialized = value.Count;
				writer.WriteUInt8Unpacked((byte)value.Count);
				foreach (ItemWrapper item2 in value)
				{
					item2.Item.UpdateLastWriteTime();
					writer.WriteUInt8Unpacked(item2.Item.ItemID);
					writer.WriteBoolean(item2.Item.IsActive);
					if (item2.Item.IsActive)
					{
						int position = writer.Position;
						writer.WriteUInt16Unpacked(0);
						item2.Item.WriteState(writer);
						int position2 = writer.Position;
						int num = position2 - (position + 2);
						if (num > 65535)
						{
							Debug.LogError($"An item in a networked area tried to write more state data than its limit of {ushort.MaxValue} bytes.{System.Environment.NewLine}" + "Flight Object: " + base.name + " (" + GetType().FullName + ")" + System.Environment.NewLine + "Item: " + ((item2.Item as MonoBehaviour)?.name ?? "unknown") + " (" + (item2.Item?.GetType().FullName ?? "null") + ")");
						}
						writer.Position = position;
						writer.WriteUInt16Unpacked((ushort)num);
						writer.Position = position2;
					}
				}
			}
		}

		protected virtual void OnDestroy()
		{
			UnloadAreaSynchronization();
			if (_spawner != null)
			{
				_spawner.ObjectLoaded -= OnFlightObjectLoaded;
				_spawner.ObjectUnloaded -= OnFlightObjectUnloaded;
			}
		}

		protected virtual void Start()
		{
			int count = _items.Count;
			List<NetworkedAreaItemScript> componentsInChildrenOrdered = Utilities.GetComponentsInChildrenOrdered<NetworkedAreaItemScript>(base.gameObject);
			if (componentsInChildrenOrdered.Count + count >= 256)
			{
				Debug.LogError("Networked areas cannot have more than 256 objects");
				return;
			}
			for (int i = 0; i < componentsInChildrenOrdered.Count; i++)
			{
				byte itemID = (byte)(i + count);
				NetworkedAreaItemScript networkedAreaItemScript = componentsInChildrenOrdered[i];
				_items.Add(new ItemWrapper
				{
					Item = networkedAreaItemScript
				});
				networkedAreaItemScript.InitializeArea(this, itemID);
			}
			_fsn = FlightSceneScript.Instance.FlightSceneNetwork;
			NetworkFlightObject component;
			if (TryGetComponent<SimpleSpawnerClientScript>(out _spawner))
			{
				_spawner.ObjectLoaded += OnFlightObjectLoaded;
				_spawner.ObjectUnloaded += OnFlightObjectUnloaded;
			}
			else if (TryGetComponent<NetworkFlightObject>(out component))
			{
				SetNetworkFlightObject(component);
			}
			else
			{
				Debug.LogError("NetworkedAreaScript must have either a SimpleSpawnerClientScript or a NetworkedAreaComponent script attached. Check comments for the purpose of each.", base.gameObject);
			}
			_initialized = true;
		}

		private void OnFlightObjectLoaded(object sender, NetworkFlightObjectSpawnEventArgs e)
		{
			SetNetworkFlightObject(e.Object);
		}

		private void OnFlightObjectUnloaded(object sender, NetworkFlightObjectSpawnEventArgs e)
		{
			IsFlightObjectLoaded = false;
			this.FlightObjectUnloaded?.Invoke(e.Object);
			UnloadAreaSynchronization();
		}

		private void SetNetworkFlightObject(NetworkFlightObject nfo)
		{
			_areaComponent = nfo.GetNetworkFlightObjectComponent<NetworkedAreaComponent>();
			_areaComponent.OnAreaLoaded(this, Utilities.GetFullObjectHierarchy(base.transform));
			IsOwner = _areaComponent.NetworkFlightObject.IsOwner;
			IsFlightObjectLoaded = true;
			this.FlightObjectLoaded?.Invoke(nfo);
		}

		private void UnloadAreaSynchronization()
		{
			if (_areaComponent != null)
			{
				_areaComponent.OnAreaUnloaded(this);
				_areaComponent = null;
				IsOwner = false;
			}
		}
	}
}
