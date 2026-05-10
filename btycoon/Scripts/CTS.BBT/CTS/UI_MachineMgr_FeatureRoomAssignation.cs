using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class UI_MachineMgr_FeatureRoomAssignation : UI_MachineMgr_MachinePanelFeature<IRoomAssignable>
	{
		[SerializeField]
		private TMP_Text _countText;

		[SerializeField]
		private CTSToggle _addToggle;

		[SerializeField]
		private CTSToggle _removeToggle;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private RoomAssignationsTool _assignationsTool;

		private static HashSet<UI_MachineMgr_FeatureRoomAssignation> _openedList = new HashSet<UI_MachineMgr_FeatureRoomAssignation>();

		public static bool IsOpen => _openedList.Count > 0;

		public static event Action<bool> PanelOpened;

		protected override void OnAwake()
		{
			base.OnAwake();
			_addToggle.onValueChanged.AddListener(OnAddToggleChanged);
			_removeToggle.onValueChanged.AddListener(OnRemoveToggleChanged);
			_assignationsTool.CurrentModeChanged += OnModeChanged;
		}

		private void OnDestroy()
		{
			_addToggle.onValueChanged.RemoveListener(OnAddToggleChanged);
			_removeToggle.onValueChanged.RemoveListener(OnRemoveToggleChanged);
			_assignationsTool.CurrentModeChanged -= OnModeChanged;
		}

		protected override void OnRepaint()
		{
			if (base._currentFurniture.RoomAssignations.AssignedRooms.Count <= 0)
			{
				_countText.text = "∞";
			}
			else
			{
				_countText.text = base._currentFurniture.RoomAssignations.AssignedRooms.Count.ToString();
			}
		}

		protected override bool CanBeDisplayedForFurniture(IRoomAssignable furniture)
		{
			return true;
		}

		protected override void OnFurnitureSet(IRoomAssignable furniture)
		{
			RoomAssignations.AssignedRoomsChanged += OnRoomAssignationChanged;
			_openedList.Add(this);
			UI_MachineMgr_FeatureRoomAssignation.PanelOpened?.Invoke(obj: true);
		}

		protected override void OnFurnitureUnset(IRoomAssignable furniture)
		{
			RoomAssignations.AssignedRoomsChanged -= OnRoomAssignationChanged;
			_addToggle.isOn = false;
			_removeToggle.isOn = false;
			_openedList.Remove(this);
			UI_MachineMgr_FeatureRoomAssignation.PanelOpened?.Invoke(obj: false);
		}

		private void OnRoomAssignationChanged(RoomAssignations assignations, RoomBuilding room)
		{
			OnRepaint();
		}

		private void OnAddToggleChanged(bool isOn)
		{
			if (isOn)
			{
				_assignationsTool.SetCurrentMode(RoomAssignationsTool.EMode.Add);
			}
			else if (_assignationsTool.CurrentMode == RoomAssignationsTool.EMode.Add)
			{
				_assignationsTool.SetCurrentMode(RoomAssignationsTool.EMode.None);
			}
		}

		private void OnRemoveToggleChanged(bool isOn)
		{
			if (isOn)
			{
				_assignationsTool.SetCurrentMode(RoomAssignationsTool.EMode.Remove);
			}
			else if (_assignationsTool.CurrentMode == RoomAssignationsTool.EMode.Remove)
			{
				_assignationsTool.SetCurrentMode(RoomAssignationsTool.EMode.None);
			}
		}

		private void OnModeChanged(EventChange<RoomAssignationsTool.EMode> change)
		{
			_addToggle.isOn = change.Current == RoomAssignationsTool.EMode.Add;
			_removeToggle.isOn = change.Current == RoomAssignationsTool.EMode.Remove;
		}
	}
}
