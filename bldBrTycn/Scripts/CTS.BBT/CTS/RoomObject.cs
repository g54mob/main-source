using System;
using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Pooling;
using UnityEngine;

namespace CTS
{
	public class RoomObject : MonoBehaviour, IPoolCallbackReceiver, IReceive<RoomObject>
	{
		[SerializeField]
		[ReadOnly]
		private RoomBuilding _currentRoom;

		private RoomObject _parent;

		private readonly List<RoomObject> _children = new List<RoomObject>();

		public bool IsVisible
		{
			get
			{
				if ((bool)CurrentRoom)
				{
					return CurrentRoom.IsVisible;
				}
				return false;
			}
		}

		public RoomBuilding CurrentRoom
		{
			get
			{
				return _currentRoom;
			}
			set
			{
				if (_currentRoom == value)
				{
					this.CurrentRoomUpdated?.Invoke();
					return;
				}
				BuildingRoomContainer currentFloor = CurrentFloor;
				if ((bool)_currentRoom)
				{
					_currentRoom.Updated -= OnCurrentRoomUpdated;
					_currentRoom.Destroyed -= OnCurrentRoomUpdated;
					_currentRoom.ChangingVisibility -= OnCurrentRoomChangingVisibility;
				}
				_currentRoom = value;
				foreach (RoomObject child in _children)
				{
					child.CurrentRoom = _currentRoom;
				}
				if (!_currentRoom)
				{
					this.RoomLost?.Invoke();
					if (currentFloor != CurrentFloor)
					{
						this.CurrentFloorChanged?.Invoke();
					}
					return;
				}
				OnCurrentRoomChangingVisibility(_currentRoom.IsVisible);
				_currentRoom.Updated += OnCurrentRoomUpdated;
				_currentRoom.Destroyed += OnCurrentRoomUpdated;
				_currentRoom.ChangingVisibility += OnCurrentRoomChangingVisibility;
				this.CurrentRoomChanged?.Invoke();
				if (currentFloor != CurrentFloor)
				{
					this.CurrentFloorChanged?.Invoke();
				}
			}
		}

		public BuildingRoomContainer CurrentFloor
		{
			get
			{
				if (!CurrentRoom)
				{
					return null;
				}
				return CurrentRoom.Container;
			}
		}

		public event Action CurrentRoomUpdated;

		public event Action CurrentRoomChanged;

		public event Action RoomLost;

		public event Action<bool> CurrentRoomChangingVisibility;

		public event Action CurrentFloorChanged;

		public bool TryFindCurrentRoom()
		{
			if ((bool)_parent)
			{
				return _parent.TryFindCurrentRoom();
			}
			this.CurrentRoomUpdated?.Invoke();
			RoomBuilding room;
			bool result = RoomBuilding.TryGetRoomAt(base.transform.position, out room);
			if (CurrentRoom == room)
			{
				return CurrentRoom;
			}
			CurrentRoom = room;
			return result;
		}

		private void Start()
		{
			TryFindCurrentRoom();
		}

		private void OnEnable()
		{
			if (!TryFindCurrentRoom())
			{
				StartCoroutine(TryFindRoomLater());
			}
		}

		private IEnumerator TryFindRoomLater()
		{
			yield return Coroutines.WaitForSeconds(1f);
			if (!TryFindCurrentRoom())
			{
				StartCoroutine(TryFindRoomLater());
			}
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
			if ((bool)_currentRoom)
			{
				_currentRoom.Updated -= OnCurrentRoomUpdated;
				_currentRoom.Destroyed -= OnCurrentRoomUpdated;
				_currentRoom.ChangingVisibility -= OnCurrentRoomChangingVisibility;
			}
			if (base.gameObject.scene.isLoaded)
			{
				SetParent(null);
			}
		}

		private void OnRoomContainerCreatedBaseRoom(RoomBuilding room)
		{
			if (TryFindCurrentRoom())
			{
				RoomBuilding.OnRoomCreated -= OnRoomContainerCreatedBaseRoom;
			}
		}

		private void OnCurrentRoomUpdated()
		{
			try
			{
				TryFindCurrentRoom();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		public void SetParent(RoomObject parent)
		{
			if (_parent == parent)
			{
				return;
			}
			if ((bool)parent)
			{
				if ((bool)_parent)
				{
					SetParent(null);
				}
				_parent = parent;
				_parent._children.Add(this);
				CurrentRoom = _parent.CurrentRoom;
			}
			else
			{
				if ((bool)_parent)
				{
					_parent._children.Remove(this);
				}
				_parent = null;
			}
		}

		private void OnCurrentRoomChangingVisibility(bool visible)
		{
			this.CurrentRoomChangingVisibility?.Invoke(visible);
		}

		void IPoolCallbackReceiver.OnPulled()
		{
		}

		void IPoolCallbackReceiver.OnPushed()
		{
			SetParent(null);
		}

		void IReceive<RoomObject>.OnReceive(RoomObject obj)
		{
			SetParent(obj);
		}
	}
}
