using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	public class RoomAssignationsTool : CTSSingleton<RoomAssignationsTool>
	{
		public enum EMode
		{
			None = 0,
			Add = 1,
			Remove = 2
		}

		[SerializeField]
		private InputActionReference _assignInput;

		[SerializeField]
		private OrderedSelectionMode _selectionMode;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private SelectionModeList _selectionModeList;

		[SerializeField]
		[Inject(false)]
		private WorldSelector _worldSelector;

		private readonly LockToggle _selectionToggle = new LockToggle();

		private bool _selectionActive;

		public EMode CurrentMode { get; private set; }

		public event Action<EventChange<EMode>> CurrentModeChanged;

		protected override void SingletonAwake()
		{
			_selectionToggle.Add(InputManager.game.select);
			_selectionToggle.Add(InputManager.game.unselect);
		}

		protected override void OnSingletonDestroy()
		{
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			RoomSelection.RoomHovered += OnRoomHovered;
			_assignInput.action.performed += OnInputPerformed;
			SetSelectionModeActive(value: true);
			_selectionToggle.Lock();
			RoomSelection hovered = WorldSelector.GetHovered<RoomSelection>();
			if ((object)hovered != null)
			{
				OnRoomHovered(hovered.Room, isHovered: true);
			}
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			RoomSelection.RoomHovered -= OnRoomHovered;
			_assignInput.action.performed -= OnInputPerformed;
			SetSelectionModeActive(value: false);
			_selectionToggle.Unlock();
			SetCurrentMode(EMode.None);
		}

		private void OnInputPerformed(InputAction.CallbackContext obj)
		{
			RoomSelection hovered = WorldSelector.GetHovered<RoomSelection>();
			if ((object)hovered != null)
			{
				OnRoomHovered(hovered.Room, isHovered: true);
			}
		}

		public void SetCurrentMode(EMode mode)
		{
			if (mode != CurrentMode)
			{
				EMode currentMode = CurrentMode;
				CurrentMode = mode;
				base.enabled = CurrentMode != EMode.None;
				this.CurrentModeChanged?.Invoke(new EventChange<EMode>(currentMode, CurrentMode));
			}
		}

		private void SetSelectionModeActive(bool value)
		{
			if (value != _selectionActive)
			{
				_selectionActive = value;
				if (_selectionActive)
				{
					_selectionModeList.AddMode(_selectionMode);
				}
				else
				{
					_selectionModeList.RemoveMode(_selectionMode);
				}
			}
		}

		private void OnRoomHovered(RoomBuilding room, bool isHovered)
		{
			if (CurrentMode == EMode.None || !_assignInput.action.IsPressed())
			{
				return;
			}
			IRoomAssignable component = null;
			for (int num = _worldSelector.CurrentSelectedList.Count - 1; num >= 0; num--)
			{
				SelectableObject selectableObject = _worldSelector.CurrentSelectedList[num];
				if ((object)selectableObject != null)
				{
					if (selectableObject.TryGetComponent<IRoomAssignable>(out component))
					{
						break;
					}
					if ((object)selectableObject.SelectionTarget != null)
					{
						if (selectableObject.SelectionTarget is IRoomAssignable roomAssignable)
						{
							component = roomAssignable;
							break;
						}
						if (selectableObject.SelectionTarget.TryGetComponent<IRoomAssignable>(out component))
						{
							break;
						}
					}
				}
			}
			if (component != null)
			{
				if (CurrentMode == EMode.Add)
				{
					component.RoomAssignations.AssignRoom(room);
				}
				else
				{
					component.RoomAssignations.UnassignRoom(room);
				}
			}
		}
	}
}
