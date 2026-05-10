using System;
using CTS.Core;
using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class RoomAssingationMenu : MonoSingleton<RoomAssingationMenu>
	{
		[SerializeField]
		private GameObject _assingationPanel;

		[SerializeField]
		private ToggleGroup _toggleGroup;

		[SerializeField]
		private AssingationToggle[] _toggles;

		private NavigationArea _currentArea;

		private static readonly StringKey _cursorKey = "AssignationCursor";

		public static event Action<RoomBuilding> OnRoomAssignationChanged;

		protected override void SingletonAwake()
		{
			_currentArea = _toggles[0].area;
			AssingationToggle[] toggles = _toggles;
			for (int i = 0; i < toggles.Length; i++)
			{
				AssingationToggle assingationToggle = toggles[i];
				assingationToggle.toggle.group = _toggleGroup;
				assingationToggle.toggle.onValueChanged.AddListener(OnToggleChanged);
			}
			_assingationPanel.SetActive(value: true);
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void OnToggleChanged(bool active)
		{
			if (!active)
			{
				return;
			}
			AssingationToggle[] toggles = _toggles;
			for (int i = 0; i < toggles.Length; i++)
			{
				AssingationToggle assingationToggle = toggles[i];
				if (assingationToggle.toggle.isOn)
				{
					_currentArea = assingationToggle.area;
					break;
				}
			}
		}

		private void OnEnable()
		{
			RoomSelection.RoomSelected += OnRoomSelected;
			RoomSelection.RoomHovered += OnRoomHovered;
		}

		private void OnRoomHovered(RoomBuilding room, bool isHovered)
		{
			if (!MonoSingleton<CursorManager>.InstanceExists())
			{
				return;
			}
			if (!isHovered)
			{
				MonoSingleton<CursorManager>.Instance.RemoveCursorVisual(_cursorKey);
				return;
			}
			AssingationToggle[] toggles = _toggles;
			for (int i = 0; i < toggles.Length; i++)
			{
				AssingationToggle assingationToggle = toggles[i];
				if (!(assingationToggle.hoverCursor == null) && assingationToggle.area.Equals(room.NavArea))
				{
					MonoSingleton<CursorManager>.Instance.AddCursorVisual(_cursorKey, assingationToggle.hoverCursor);
					break;
				}
			}
		}

		private void OnDisable()
		{
			RoomSelection.RoomSelected -= OnRoomSelected;
			RoomSelection.RoomHovered -= OnRoomHovered;
			if (MonoSingleton<CursorManager>.InstanceExists())
			{
				MonoSingleton<CursorManager>.Instance.RemoveCursorVisual(_cursorKey);
			}
		}

		private void OnRoomSelected(RoomBuilding room, bool selected)
		{
			if (selected)
			{
				WorldSelector.Deselect(WorldSelector.GetLastSelected());
				if (!(room.NavArea == _currentArea))
				{
					room.NavArea = _currentArea;
					OnRoomHovered(room, isHovered: true);
					RoomAssingationMenu.OnRoomAssignationChanged?.Invoke(room);
				}
			}
		}
	}
}
