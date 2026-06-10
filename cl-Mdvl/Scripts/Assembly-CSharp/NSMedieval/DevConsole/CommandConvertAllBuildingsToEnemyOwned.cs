using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Crops;
using NSMedieval.Stockpiles;
using NSMedieval.Village;
using NSMedieval.Village.Map;

namespace NSMedieval.DevConsole
{
	public class CommandConvertAllBuildingsToEnemyOwned : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandConvertAllBuildingsToEnemyOwned()
		{
			Command = "convertAllBuildingsToEnemyOwned";
			Description = "All player buildings are converted to enemy buildings.";
			Help = "Use this command/click the button in debug menu to convert all player buildings to enemy buildings.";
		}

		private void CommandMethod()
		{
			ConvertAll();
		}

		private void ConvertAll()
		{
			VillageMap map = VillageManager.ActiveVillage.Map;
			BaseBuildingInstance[] array = map.BuildingsManagerMain.UniqueIdBuildingDictionary.Values.ToArray();
			foreach (BaseBuildingInstance baseBuildingInstance in array)
			{
				if (baseBuildingInstance.OwnedByPlayer())
				{
					baseBuildingInstance.SetFaction(FactionOwnership.Enemy);
					map.EnemyBuildingsManager.CacheEnemyBuilding(baseBuildingInstance);
				}
			}
			foreach (StockpileInstance stockpile in MonoSingleton<StockpileManager>.Instance.Stockpiles)
			{
				if (stockpile.OwnedByPlayer())
				{
					stockpile.SetFaction(FactionOwnership.Enemy);
				}
			}
			foreach (CropfieldInstance cropfield in MonoSingleton<CropsManager>.Instance.Cropfields)
			{
				if (cropfield.OwnedByPlayer())
				{
					cropfield.SetFaction(FactionOwnership.Enemy);
				}
			}
		}
	}
}
