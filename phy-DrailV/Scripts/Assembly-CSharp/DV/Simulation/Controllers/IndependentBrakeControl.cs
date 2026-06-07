using DV.CabControls.Spec;
using DV.HUD;
using LocoSim.Implementations;

namespace DV.Simulation.Controllers
{
	public class IndependentBrakeControl : OverridableBaseControl
	{
		public override InteriorControlsManager.ControlType ControlType => InteriorControlsManager.ControlType.IndBrake;

		public override void Init(TrainCar car, SimulationFlow simFlow, ControlSpec spec)
		{
			base.Init(car, simFlow, spec);
			car.brakeSystem.independentBrakePosition = base.Value;
		}

		protected override void OnControlUpdated(float value)
		{
			car.brakeSystem.independentBrakePosition = value;
			base.OnControlUpdated(value);
		}
	}
}
