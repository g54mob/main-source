using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class FloorSelection : SelectableObject
	{
		[Inject(false)]
		private BuildingFloor _floor;

		[Inject(false)]
		private Renderer _renderer;

		private RoomSelection _currentRoom;

		private LockToggle _selectionLock;

		protected override void OnAwake()
		{
			base.OnAwake();
			_selectionLock = new LockToggle(this);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_floor.LinkedRoomChanged += OnLinkedRoomChanged;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_floor.LinkedRoomChanged -= OnLinkedRoomChanged;
			OnLinkedRoomChanged(_floor.LinkedRoom, null);
		}

		protected override void OnEnterHover(SelectionMode selectionMode)
		{
			base.OnEnterHover(selectionMode);
			if ((bool)_currentRoom)
			{
				_currentRoom.SetHoverActive(value: true);
			}
		}

		protected override void OnExitHover(SelectionMode selectionMode)
		{
			base.OnExitHover(selectionMode);
			if ((bool)_currentRoom)
			{
				_currentRoom.SetHoverActive(value: false);
			}
		}

		protected override void OnSelected(SelectionMode selectionMode)
		{
			base.OnSelected(selectionMode);
			if ((bool)_currentRoom)
			{
				_currentRoom.AddSelectedObject(this);
			}
		}

		protected override void OnDeselected(SelectionMode selectionMode)
		{
			base.OnDeselected(selectionMode);
			if ((bool)_currentRoom)
			{
				_currentRoom.RemoveSelectedObject(this);
			}
		}

		private void OnLinkedRoomChanged(RoomBuilding prevRoom, RoomBuilding newRoom)
		{
			if (prevRoom == newRoom)
			{
				return;
			}
			bool flag = WorldSelector.IsObjectSelected(this);
			if ((bool)_currentRoom)
			{
				if (prevRoom.RoomIndex == 0)
				{
					_selectionLock.Unlock();
				}
				_currentRoom.RemoveSelectedObject(this);
				_currentRoom.RemoveRenderer(_renderer);
			}
			_currentRoom = null;
			if ((bool)newRoom)
			{
				if (newRoom.RoomIndex == 0)
				{
					_selectionLock.Lock();
				}
				_currentRoom = newRoom.GetComponent<RoomSelection>();
				_currentRoom.AddRenderer(_renderer);
				if (flag)
				{
					_currentRoom.AddSelectedObject(this);
				}
			}
			SetSelectionTarget(newRoom);
		}
	}
}
