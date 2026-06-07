using DV.CabControls.Spec;
using LocoSim.Implementations;

namespace DV.Simulation.Controllers
{
	public abstract class HeadlightsControlBase : OverridableBaseControl
	{
		public const float NEUTRAL_VALUE = 0.4f;

		public override void Init(TrainCar car, SimulationFlow simFlow, ControlSpec spec)
		{
			base.Init(car, simFlow, spec);
			defaultValue = 0.4f;
		}
	}
}
