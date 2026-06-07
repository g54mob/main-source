using DV.HUD;

namespace DV.Simulation.Controllers
{
	public class ThrottleControl : OverridableBaseControl
	{
		public override InteriorControlsManager.ControlType ControlType => InteriorControlsManager.ControlType.Throttle;
	}
}
