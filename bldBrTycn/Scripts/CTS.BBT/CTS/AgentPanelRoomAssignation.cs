using System;
using CTS.BBT.AI;
using CTS.UI;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class AgentPanelRoomAssignation : AbsAgentPanel, IRepaint
	{
		[SerializeField]
		private TMP_Text _countTextContainer;

		[SerializeField]
		private CTSToggle[] _toggles;

		[SerializeField]
		private CTSToggle _needToggle;

		[SerializeField]
		private CTSToggle _powerToggle;

		private CanvasGroupController _canvasGroupController;

		public bool IsOpen
		{
			get
			{
				if (base.isActiveAndEnabled)
				{
					CanvasGroupController.CanvasGroupState state = GetCanvasController().State;
					return state == CanvasGroupController.CanvasGroupState.Showing || state == CanvasGroupController.CanvasGroupState.Shown;
				}
				return false;
			}
		}

		public static event Action<bool> PanelOpened;

		private CanvasGroupController GetCanvasController()
		{
			if (!_canvasGroupController)
			{
				_canvasGroupController = GetComponentInParent<CanvasGroupController>(includeInactive: true);
			}
			return _canvasGroupController;
		}

		protected override void Awake()
		{
			base.Awake();
			_needToggle.onValueChanged.AddListener(OnNeedToggleValueChanged);
			_powerToggle.onValueChanged.AddListener(OnPowerToggleValueChanged);
		}

		private void OnEnable()
		{
			RoomAssignations.AssignedRoomsChanged += OnRoomAssignationChanged;
		}

		private void OnPowerToggleValueChanged(bool isOn)
		{
			if (base._agent is Worker worker)
			{
				worker.AssignationBypassPowers = isOn;
			}
		}

		private void OnNeedToggleValueChanged(bool isOn)
		{
			if (base._agent is Worker worker)
			{
				worker.AssignationBypassNeeds = isOn;
			}
		}

		private void OnDisable()
		{
			RoomAssignations.AssignedRoomsChanged -= OnRoomAssignationChanged;
		}

		private void OnRoomAssignationChanged(RoomAssignations assignations, RoomBuilding room)
		{
			Repaint();
		}

		public override void SetAgentInfo()
		{
			Repaint();
			AgentPanelRoomAssignation.PanelOpened?.Invoke(obj: true);
		}

		public override void ClearAgentInfo()
		{
			AgentPanelRoomAssignation.PanelOpened?.Invoke(obj: false);
			CTSToggle[] toggles = _toggles;
			for (int i = 0; i < toggles.Length; i++)
			{
				toggles[i].isOn = false;
			}
		}

		public void ResetWorkerAssignations()
		{
			if (base._agent is Worker worker)
			{
				worker.RoomAssignations.UnassignAll();
			}
		}

		public void Repaint()
		{
			if (base._agent is Worker worker)
			{
				if (worker.RoomAssignations.AssignedRooms.Count <= 0)
				{
					_countTextContainer.text = "∞";
				}
				else
				{
					_countTextContainer.text = worker.RoomAssignations.AssignedRooms.Count.ToString();
				}
				_needToggle.isOn = worker.AssignationBypassNeeds;
				_powerToggle.isOn = worker.AssignationBypassPowers;
			}
		}
	}
}
