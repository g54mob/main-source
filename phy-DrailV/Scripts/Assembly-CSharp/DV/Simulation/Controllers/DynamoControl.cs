using DV.HUD;

namespace DV.Simulation.Controllers
{
	public class DynamoControl : OverridableBaseControl
	{
		public override InteriorControlsManager.ControlType ControlType => InteriorControlsManager.ControlType.Dynamo;
	}
}
