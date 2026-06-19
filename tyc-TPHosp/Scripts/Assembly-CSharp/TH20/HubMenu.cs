using UnityEngine;

namespace TH20
{
	public class HubMenu : MenuBase
	{
		[SerializeField]
		private HubMenuButtons _hubMenuButtons;

		[SerializeField]
		private DataViewButtons _dataViewButtons;

		private Level _level;

		public HubMenuButtons HubMenuButtons => _hubMenuButtons;

		public void Setup(Level level)
		{
			_level = level;
			_hubMenuButtons.Setup(_level);
			_dataViewButtons.Setup(_level.DataViewManager);
		}

		protected void OnDestry()
		{
			Object.Destroy(_hubMenuButtons);
		}

		public void PressStaffButton()
		{
			_hubMenuButtons.PressStaffButton();
		}

		public void PressPatientButton()
		{
			_hubMenuButtons.PressPatientButton();
		}

		public void PressIllnessButton()
		{
			_hubMenuButtons.PressIllnessButton();
		}

		public void PressOverviewButton()
		{
			_hubMenuButtons.PressOverviewButton();
		}
	}
}
