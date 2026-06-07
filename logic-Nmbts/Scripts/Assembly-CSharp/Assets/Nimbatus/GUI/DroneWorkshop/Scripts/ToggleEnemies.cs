using Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ToggleEnemies : ToggleButton
	{
		protected override void Toggle(bool toggle)
		{
			Spawner.ShouldSpawn = toggle;
		}

		protected override bool IsToggled()
		{
			return Spawner.ShouldSpawn;
		}
	}
}
