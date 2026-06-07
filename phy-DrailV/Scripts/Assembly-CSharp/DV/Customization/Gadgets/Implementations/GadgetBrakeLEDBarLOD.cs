using DV.Simulation.Brake;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetBrakeLEDBarLOD : CustomizerLODObject<GadgetBase>
	{
		public LedBarDriverBase brakeBar;

		public LampControl brakeLamp;

		private BrakeWarningChecker checker;

		private void Awake()
		{
			checker = new BrakeWarningChecker();
		}

		private void OnEnable()
		{
			if (base.IsOnTrainCar)
			{
				checker.SetTrainCar(base.Base.TrainCar);
				checker.BrakeWarningChanged += BrakeWarningChanged;
			}
			UpdateLamp();
		}

		private void OnDisable()
		{
			checker.BrakeWarningChanged -= BrakeWarningChanged;
			checker.SetTrainCar(null);
		}

		private void Update()
		{
			brakeBar.UpdateValue((base.Base.PowerState && base.IsOnTrainCar) ? base.Base.TrainCar.brakeSystem.BrakeCylinderPressureNormalized : 0f);
		}

		private void UpdateLamp()
		{
			if (!base.Base.PowerState || checker == null)
			{
				brakeLamp.SetLampState(LampControl.LampState.Off);
				return;
			}
			bool brakeWarningState = checker.BrakeWarningState;
			brakeLamp.SetLampState(brakeWarningState ? LampControl.LampState.Blinking : LampControl.LampState.Off, brakeWarningState);
		}

		private void BrakeWarningChanged(bool _)
		{
			UpdateLamp();
		}

		protected internal override void OnPowerStateChanged(bool _)
		{
			UpdateLamp();
		}
	}
}
