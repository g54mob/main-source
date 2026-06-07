using DV.HUD;

namespace DV.Simulation.Controllers
{
	public class DynamicBrakeControl : OverridableBaseControl
	{
		public override InteriorControlsManager.ControlType ControlType => InteriorControlsManager.ControlType.DynamicBrake;
	}
}
