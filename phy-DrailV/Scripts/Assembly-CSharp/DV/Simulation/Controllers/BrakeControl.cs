using DV.CabControls.Spec;
using DV.HUD;
using LocoSim.Implementations;

namespace DV.Simulation.Controllers
{
	public class BrakeControl : OverridableBaseControl
	{
		public override InteriorControlsManager.ControlType ControlType => InteriorControlsManager.ControlType.TrainBrake;

		public override void Init(TrainCar car, SimulationFlow simFlow, ControlSpec spec)
		{
			base.Init(car, simFlow, spec);
			car.brakeSystem.trainBrakePosition = base.Value;
		}

		protected override void OnControlUpdated(float value)
		{
			car.brakeSystem.trainBrakePosition = value;
			base.OnControlUpdated(value);
		}
	}
}
