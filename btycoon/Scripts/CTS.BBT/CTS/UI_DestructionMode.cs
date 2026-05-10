using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_DestructionMode : MonoSingleton<UI_DestructionMode>
	{
		[SerializeField]
		private Button _confirmButton;

		[SerializeField]
		private Toggle _standartModeToggle;

		[SerializeField]
		private Toggle _roomModeToggle;

		[SerializeField]
		private Toggle _wallModeToggle;

		[SerializeField]
		private ToggleGroup _toggleGroup;

		[SerializeField]
		private GameObject _container;

		[SerializeField]
		private OrderedSelectionMode _roomSelectionMode;

		[SerializeField]
		private Vector3 _confirmButtonOffset;

		private bool _changedMode;

		public RoomBuilding currentSelectedRoomForDestroy;

		public RoomBuilding _roomA;

		public RoomBuilding _roomB;

		public int CurrentRoomDestroyCellCount;

		public ESelectedDestructionMode CurrentMode { get; private set; }

		public static event Action OnDestructionModeChanged;

		protected override void SingletonAwake()
		{
			UI_ConstructionSystem.OnDestructionActived += UI_ConstructionSystem_OnDestructionActived;
			ConstructionSystem.OnSelectedRoomForRoomDestroyChanged += ConstructionSystem_OnSelectedRoomForRoomDestroyChanged;
			ConstructionSystem.OnSelectedWallForRoomDestroyChanged += OnSelectWallToDestroy;
			_standartModeToggle.group = _toggleGroup;
			_roomModeToggle.group = _toggleGroup;
			_wallModeToggle.group = _toggleGroup;
			_standartModeToggle.onValueChanged.AddListener(OnStandardDestructionToggled);
			_roomModeToggle.onValueChanged.AddListener(OnPerRoomDestructionToggled);
			_wallModeToggle.onValueChanged.AddListener(OnWallDestructionToggled);
			_confirmButton.onClick.AddListener(ConfirmationClicked);
		}

		private void UI_ConstructionSystem_OnOpenBuildMode()
		{
		}

		protected override void OnSingletonDestroy()
		{
			UI_ConstructionSystem.OnDestructionActived -= UI_ConstructionSystem_OnDestructionActived;
			ConstructionSystem.OnSelectedRoomForRoomDestroyChanged -= ConstructionSystem_OnSelectedRoomForRoomDestroyChanged;
			ConstructionSystem.OnSelectedWallForRoomDestroyChanged -= OnSelectWallToDestroy;
			_standartModeToggle.onValueChanged.RemoveListener(OnStandardDestructionToggled);
			_roomModeToggle.onValueChanged.RemoveListener(OnPerRoomDestructionToggled);
			_wallModeToggle.onValueChanged.RemoveListener(OnWallDestructionToggled);
			_confirmButton.onClick.RemoveListener(ConfirmationClicked);
		}

		private void OnSelectWallToDestroy(RoomBuilding roomA, RoomBuilding roomB)
		{
			_confirmButton.gameObject.SetActive(roomA != null && roomB != null);
			_roomA = roomA;
			_roomB = roomB;
			if (_confirmButton.gameObject.activeSelf)
			{
				_confirmButton.transform.position = Input.mousePosition + _confirmButtonOffset;
			}
		}

		private void ConstructionSystem_OnSelectedRoomForRoomDestroyChanged(bool arg1, RoomBuilding arg2)
		{
			if (!arg1)
			{
				currentSelectedRoomForDestroy = null;
			}
			else
			{
				currentSelectedRoomForDestroy = arg2;
			}
			CurrentRoomDestroyCellCount = 0;
			_confirmButton.gameObject.SetActive(currentSelectedRoomForDestroy != null);
			if (_confirmButton.gameObject.activeSelf)
			{
				_confirmButton.transform.position = Input.mousePosition + _confirmButtonOffset;
				CurrentRoomDestroyCellCount = currentSelectedRoomForDestroy.FloorTiles.Count;
			}
		}

		private void ConfirmationClicked()
		{
			if (CurrentMode == ESelectedDestructionMode.PerRoom)
			{
				if (currentSelectedRoomForDestroy == null)
				{
					return;
				}
				MonoSingleton<ConstructionSystem>.Instance.RemoveEntireRoom(currentSelectedRoomForDestroy.RoomIndex);
				currentSelectedRoomForDestroy = null;
				CurrentRoomDestroyCellCount = 0;
			}
			if (CurrentMode == ESelectedDestructionMode.Wall)
			{
				MonoSingleton<ConstructionSystem>.Instance.MergeRoom(_roomA, _roomB);
				_roomA = null;
				_roomB = null;
				CurrentRoomDestroyCellCount = 0;
			}
			_confirmButton.gameObject.SetActive(value: false);
		}

		private void Clear()
		{
			_roomA = null;
			_roomB = null;
			currentSelectedRoomForDestroy = null;
			CurrentRoomDestroyCellCount = 0;
		}

		private void OnStandardDestructionToggled(bool toggle)
		{
			if (toggle)
			{
				CurrentMode = ESelectedDestructionMode.Standard;
				UI_DestructionMode.OnDestructionModeChanged?.Invoke();
				ChangeSelectionMode(playMode: true);
				Clear();
			}
		}

		private void OnPerRoomDestructionToggled(bool toggle)
		{
			if (toggle)
			{
				CurrentMode = ESelectedDestructionMode.PerRoom;
				UI_DestructionMode.OnDestructionModeChanged?.Invoke();
				ChangeSelectionMode(playMode: false);
				Clear();
			}
		}

		private void OnWallDestructionToggled(bool toggle)
		{
			if (toggle)
			{
				CurrentMode = ESelectedDestructionMode.Wall;
				UI_DestructionMode.OnDestructionModeChanged?.Invoke();
				ChangeSelectionMode(playMode: true);
				Clear();
			}
		}

		private void ChangeSelectionMode(bool playMode)
		{
			if (playMode)
			{
				SetSelectionMode(isOn: false);
				currentSelectedRoomForDestroy = null;
			}
			else
			{
				SetSelectionMode(isOn: true);
			}
			_confirmButton.gameObject.SetActive(currentSelectedRoomForDestroy != null);
		}

		private void SetSelectionMode(bool isOn)
		{
			if (_changedMode != isOn)
			{
				_changedMode = isOn;
				if (_changedMode)
				{
					CTSSingleton<SelectionModeList>.Instance.AddMode(_roomSelectionMode);
				}
				else
				{
					CTSSingleton<SelectionModeList>.Instance.RemoveMode(_roomSelectionMode);
				}
			}
		}

		private void UI_ConstructionSystem_OnDestructionActived(bool obj)
		{
			_container.SetActive(obj);
			if (!obj)
			{
				ChangeSelectionMode(playMode: true);
				return;
			}
			ChangeSelectionMode(CurrentMode != ESelectedDestructionMode.PerRoom);
			_standartModeToggle.isOn = CurrentMode == ESelectedDestructionMode.Standard;
			_roomModeToggle.isOn = CurrentMode == ESelectedDestructionMode.PerRoom;
			_wallModeToggle.isOn = CurrentMode == ESelectedDestructionMode.Wall;
		}
	}
}
