using DV.CabControls;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class AlternatingControllerLOD : CustomizerLODObject<AlternatingController>
	{
		public GameObject modeSwitch;

		public LampControl lampActive;

		private ControlImplBase modeSwitchController;

		private void Start()
		{
			modeSwitchController = modeSwitch.GetComponent<ControlImplBase>();
			SyncControls();
			modeSwitchController.ValueChanged += OnFlipSwitched;
			OnPowerStateChanged(base.Base.PowerState);
		}

		protected internal override void OnPowerStateChanged(bool newValue)
		{
			base.OnPowerStateChanged(newValue);
			UpdateLamp();
		}

		private void UpdateLamp()
		{
			if (lampActive != null)
			{
				lampActive.SetLampState((base.Base.DefaultOutputValue > 0f) ? LampControl.LampState.On : LampControl.LampState.Off);
			}
		}

		private void OnFlipSwitched(ValueChangedEventArgs e)
		{
			base.Base.SelectedInterval = Mathf.RoundToInt(e.newValue * (float)(base.Base.IntervalCount - 1));
			UpdateLamp();
		}

		public void SyncControls()
		{
			modeSwitchController.SetValue((float)base.Base.SelectedInterval / ((float)base.Base.IntervalCount - 1f));
		}
	}
}
