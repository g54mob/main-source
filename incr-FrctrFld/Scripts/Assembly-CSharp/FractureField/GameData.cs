using FractureField.Achievements;
using FractureField.Bombs;
using FractureField.Drones;
using FractureField.GameManagers;
using FractureField.PlayerStats;
using FractureField.Prestige.RealityShatter;
using FractureField.Prestige.WorldFracture;
using FractureField.QuarryForeman;
using FractureField.Rocks;
using FractureField.Stats;
using FractureField.Tools;

namespace FractureField
{
	public class GameData
	{
		public RandomManagers RandomManagers { get; set; }

		public MiscManagerSaveData MiscManager { get; set; }

		public CurrencyManagerSaveData CurrencyManager { get; set; }

		public PlayerStatsManagerSaveData PlayerStatsManager { get; set; }

		public RockManagerSaveData RockManager { get; set; }

		public ToolManagerSaveData ToolManager { get; set; }

		public StatsManagerSaveData StatsManager { get; set; }

		public DroneManagerSaveData DroneManager { get; set; }

		public BombManagerSaveData BombManager { get; set; }

		public WorldFractureManagerSaveData WorldFractureManager { get; set; }

		public RealityShatterManagerSaveData RealityShatterManager { get; set; }

		public QuarryForemanManagerSaveData QuarryForemanManager { get; set; }

		public AchievementManagerSaveData AchievementManager { get; set; }

		public static GameData Save()
		{
			return null;
		}
	}
}
