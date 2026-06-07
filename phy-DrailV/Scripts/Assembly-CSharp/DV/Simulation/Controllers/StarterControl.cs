using DV.HUD;

namespace DV.Simulation.Controllers
{
	public class StarterControl : OverridableBaseControl
	{
		public override InteriorControlsManager.ControlType ControlType => InteriorControlsManager.ControlType.StarterControl;
	}
}
