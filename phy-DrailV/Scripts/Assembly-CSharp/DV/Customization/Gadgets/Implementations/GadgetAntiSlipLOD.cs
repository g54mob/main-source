namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetAntiSlipLOD : CustomizerLODObject<GadgetAntiSlip>
	{
		public LampControl powerLED;

		public LampControl activeLED;

		private void Start()
		{
			UpdateLamps();
			base.Base.IsActivatedChanged += UpdateLamps;
		}

		protected internal override void OnPowerStateChanged(bool _ = false)
		{
			UpdateLamps();
		}

		private void UpdateLamps()
		{
			powerLED.SetLampState(base.Base.PowerState ? LampControl.LampState.On : LampControl.LampState.Off, base.Base.PowerState);
			activeLED.SetLampState(base.Base.IsActivated ? LampControl.LampState.On : LampControl.LampState.Off);
		}
	}
}
