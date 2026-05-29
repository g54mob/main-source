using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class AgentPanelRoomAssignationToggle : CTSBehaviour
	{
		[SerializeField]
		private RoomAssignationsTool.EMode _mode;

		[SerializeField]
		[Inject(false)]
		private CTSToggle _toggle;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private RoomAssignationsTool _assignationsTool;

		protected override void OnAwake()
		{
			base.OnAwake();
			_toggle.onValueChanged.AddListener(OnToggleChanged);
		}

		private void OnDestroy()
		{
			_toggle.onValueChanged.RemoveListener(OnToggleChanged);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_assignationsTool.CurrentModeChanged += OnModeChanged;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_assignationsTool.CurrentModeChanged -= OnModeChanged;
		}

		private void OnToggleChanged(bool isOn)
		{
			if (isOn)
			{
				_assignationsTool.SetCurrentMode(_mode);
			}
			else if (_assignationsTool.CurrentMode == _mode)
			{
				_assignationsTool.SetCurrentMode(RoomAssignationsTool.EMode.None);
			}
		}

		private void OnModeChanged(EventChange<RoomAssignationsTool.EMode> change)
		{
			if (change.Previous == RoomAssignationsTool.EMode.None || change.Previous == _mode)
			{
				_toggle.isOn = change.Current == _mode;
			}
		}
	}
}
