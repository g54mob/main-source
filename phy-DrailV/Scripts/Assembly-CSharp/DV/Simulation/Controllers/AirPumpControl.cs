using DV.HUD;

namespace DV.Simulation.Controllers
{
	public class AirPumpControl : OverridableBaseControl
	{
		public override InteriorControlsManager.ControlType ControlType => InteriorControlsManager.ControlType.AirPump;
	}
}
