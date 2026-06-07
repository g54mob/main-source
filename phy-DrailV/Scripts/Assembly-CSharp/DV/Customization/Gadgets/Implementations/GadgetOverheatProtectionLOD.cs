using DV.CabControls;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetOverheatProtectionLOD : CustomizerLODObject<GadgetOverheatProtection>
	{
		public LampControl active;

		public GameObject switchLimit;

		public GameObject switchMethod;

		private ControlImplBase switchLimitControl;

		private ControlImplBase switchMethodControl;

		private void Start()
		{
			switchLimitControl = switchLimit.GetComponent<ControlImplBase>();
			switchMethodControl = switchMethod.GetComponent<ControlImplBase>();
			SyncControls();
			switchLimitControl.ValueChanged += OnSomethingChanged;
			switchMethodControl.ValueChanged += OnSomethingChanged;
			base.Base.HasReachedLimitChanged += UpdateLamp;
			OnPowerStateChanged(base.Base.PowerState);
		}

		protected internal override void OnPowerStateChanged(bool _)
		{
			UpdateLamp();
		}

		private void UpdateLamp()
		{
			LampControl.LampState lampState = LampControl.LampState.Off;
			if (base.Base.PowerState && base.Base.ArePlacementRequirementsMet)
			{
				lampState = ((!base.Base.HasReachedLimit) ? LampControl.LampState.On : LampControl.LampState.Blinking);
			}
			active.SetLampState(lampState, lampState == LampControl.LampState.Blinking);
		}

		private void OnSomethingChanged(object _)
		{
			base.Base.ModeIndex = Mathf.RoundToInt(switchLimitControl.Value * (float)(base.Base.ModeCount - 1));
			base.Base.cutEngine = switchMethodControl.Value > 0.5f;
		}

		public void SyncControls()
		{
			switchLimitControl.SetValue((float)base.Base.ModeIndex / ((float)base.Base.ModeCount - 1f));
			switchMethodControl.SetValue(base.Base.cutEngine ? 1 : 0);
		}
	}
}
