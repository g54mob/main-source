using DV.CabControls.Spec;
using DV.HUD;
using LocoSim.Implementations;

namespace DV.Simulation.Controllers
{
	public class HornControl : OverridableBaseControl
	{
		public bool neutralAt0;

		public override InteriorControlsManager.ControlType ControlType => InteriorControlsManager.ControlType.Horn;

		public override void Init(TrainCar car, SimulationFlow simFlow, ControlSpec spec)
		{
			base.Init(car, simFlow, spec);
			if (!neutralAt0)
			{
				defaultValue = 0.5f;
			}
		}

		public override void Set(float value)
		{
			if (!neutralAt0)
			{
				value = (value + 1f) / 2f;
			}
			base.Set(value);
		}
	}
}
