using Assets.Scripts.Flight.Discoverables;
using Assets.Scripts.Flight.WorldObjects.Combat;
using Assets.Scripts.Levels;

namespace Assets.Scripts.Flight.WorldObjects.Unique.Snowstone
{
	public class SnowstoneMountainBaseScript : MissileDefenseBaseScript
	{
		protected override bool InitiallyHostile()
		{
			LevelInfo currentLevel = Game.Instance.CurrentLevel;
			if (currentLevel.Id == "RaceTundra")
			{
				return true;
			}
			if (!currentLevel.IsSandbox && string.IsNullOrEmpty(currentLevel.ModName))
			{
				return false;
			}
			return !GetComponentsInChildren<DiscoverableLocationScript>(includeInactive: true)[0].IsPlayerInBounds(FlightSceneScript.Instance.LocalPlayer);
		}
	}
}
