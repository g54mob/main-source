using System;
using CTS.BBT;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class UIWallMenu : MonoSingleton<UIWallMenu>
	{
		private RoomAssingationMenu _roomMenu;

		[SerializeField]
		private GameObject _roomAssignationPanel;

		[SerializeField]
		private OrderedSelectionMode _selectionMode;

		private LockToggle _timeLocker = new LockToggle();

		public bool IsOpen => _timeLocker.Locked;

		public static event Action<bool> OnMenuOpen;

		protected override void SingletonAwake()
		{
			_roomMenu = GetComponent<RoomAssingationMenu>();
			_roomMenu.enabled = false;
			_timeLocker.Add(MonoSingleton<TimeController>.Instance);
			UI_ConstructionSystem.OnAssignationActived += UI_ConstructionSystem_OnAssignationActived;
		}

		protected override void OnSingletonDestroy()
		{
			UI_ConstructionSystem.OnAssignationActived -= UI_ConstructionSystem_OnAssignationActived;
		}

		private void Start()
		{
			_roomAssignationPanel.SetActive(value: false);
		}

		private void OnEnable()
		{
			WorldSelector.SelectionModeChanged += OnSelectionModeChanged;
		}

		private void OnDisable()
		{
			WorldSelector.SelectionModeChanged -= OnSelectionModeChanged;
		}

		private void UI_ConstructionSystem_OnAssignationActived(bool value)
		{
			if (value)
			{
				WorldSelector.DeselectAll();
				SetOpen(CTSSingleton<WorldSelector>.Instance.CurrentSelectionMode != _selectionMode);
			}
			else
			{
				SetOpen(value: false);
			}
		}

		public void SetOpen(bool value)
		{
			if (_timeLocker.Locked != value)
			{
				_roomMenu.enabled = value;
				if (value)
				{
					CTSSingleton<SelectionModeList>.Instance.AddMode(_selectionMode);
					_roomAssignationPanel.SetActive(value: true);
					_timeLocker.Lock();
					UIWallMenu.OnMenuOpen?.Invoke(obj: true);
				}
				else
				{
					CTSSingleton<SelectionModeList>.Instance.RemoveMode(_selectionMode);
					_roomAssignationPanel.SetActive(value: false);
					_timeLocker.Unlock();
					UIWallMenu.OnMenuOpen?.Invoke(obj: false);
				}
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public void OnWallMenuButton()
		{
			if (FurnitureShop.IsOpen)
			{
				MonoSingleton<FurnitureShop>.Instance.SetFurnitureShopOpen(p_value: false);
			}
			WorldSelector.DeselectAll();
			SetOpen(CTSSingleton<WorldSelector>.Instance.CurrentSelectionMode != _selectionMode);
		}

		private void OnCanvasGroupShown(bool value)
		{
			if (!value)
			{
				SetOpen(value: false);
			}
		}

		private void OnSelectionModeChanged(SelectionMode mode)
		{
			if (mode != _selectionMode)
			{
				SetOpen(value: false);
			}
		}
	}
}
