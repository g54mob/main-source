using DV.CabControls.Spec;
using DV.HUD;
using LocoSim.Implementations;

namespace DV.Simulation.Controllers
{
	public class BrakeCutoutControl : OverridableBaseControl
	{
		public override InteriorControlsManager.ControlType ControlType => InteriorControlsManager.ControlType.TrainBrakeCutout;

		public override void Init(TrainCar car, SimulationFlow simFlow, ControlSpec spec)
		{
			base.Init(car, simFlow, spec);
			car.brakeSystem.trainBrakeCutout = base.Value > 0.5f;
		}

		protected override void OnControlUpdated(float value)
		{
			car.brakeSystem.trainBrakeCutout = value > 0.5f;
			base.OnControlUpdated(value);
		}
	}
}
