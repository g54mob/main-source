using DV.HUD;

namespace DV.Simulation.Controllers
{
	public class CabLightControl : OverridableBaseControl
	{
		public override InteriorControlsManager.ControlType ControlType => InteriorControlsManager.ControlType.CabLight;
	}
}
