using DV.CabControls;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetAmpLimiterLOD : CustomizerLODObject<GadgetAmpLimiter>
	{
		public LampControl limitingIndicator;

		public GameObject limitKnob;

		private ControlImplBase limitKnobControl;

		private void Start()
		{
			base.Base.OnStateUpdated += OnStateUpdated;
			limitKnobControl = limitKnob.GetComponent<ControlImplBase>();
			SyncControls();
			limitKnobControl.ValueChanged += OnLimitKnob;
			OnStateUpdated();
		}

		public void SyncControls()
		{
			limitKnobControl.SetValue((float)base.Base.ModeIndex / (float)(base.Base.ModeCount - 1));
		}

		private void OnLimitKnob(ValueChangedEventArgs e)
		{
			base.Base.ModeIndex = Mathf.RoundToInt(Mathf.Clamp01(e.newValue) * (float)(base.Base.ModeCount - 1));
		}

		private void OnStateUpdated()
		{
			LampControl.LampState state = LampControl.LampState.Off;
			if (base.Base.IsEnabled)
			{
				state = ((!base.Base.IsLimiting) ? LampControl.LampState.On : LampControl.LampState.Blinking);
			}
			limitingIndicator.SetLampState(state, playWarningAudio: true);
		}
	}
}
