using DV.CabControls.Spec;
using DV.HUD;
using LocoSim.Implementations;

namespace DV.Simulation.Controllers
{
	public class ReverserControl : OverridableBaseControl
	{
		public const float NEUTRAL_VALUE = 0.5f;

		public override InteriorControlsManager.ControlType ControlType => InteriorControlsManager.ControlType.Reverser;

		public override void Init(TrainCar car, SimulationFlow simFlow, ControlSpec spec)
		{
			base.Init(car, simFlow, spec);
			defaultValue = 0.5f;
		}
	}
}
