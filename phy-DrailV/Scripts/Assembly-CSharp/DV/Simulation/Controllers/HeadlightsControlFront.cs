using DV.HUD;

namespace DV.Simulation.Controllers
{
	public class HeadlightsControlFront : HeadlightsControlBase
	{
		public override InteriorControlsManager.ControlType ControlType => InteriorControlsManager.ControlType.HeadlightsFront;
	}
}
