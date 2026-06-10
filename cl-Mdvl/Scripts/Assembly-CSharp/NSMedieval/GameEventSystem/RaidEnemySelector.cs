using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using Raid.Config;
using UnityEngine;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	public class RaidEnemySelector : MonoSingleton<RaidEnemySelector>
	{
		public LastRaidInfo.RaidVariation OverrideRaidVariation { get; set; }

		public bool PurchaseBodyGuards(in int pointsToSpend, out List<IEnemyPurchaseUnit> enemiesToSpawn, in string enemyCategory = null)
		{
			List<IEnemyPurchaseUnit> unitsByPriceDesc = GetUnitsByPriceDesc(addEnemies: true, addSiegeWeapons: false, addAnimals: false, enemyCategory, NPCType.Basic);
			List<IEnemyPurchaseUnit> unitsByPriceDesc2 = GetUnitsByPriceDesc(addEnemies: true, addSiegeWeapons: false, addAnimals: false, enemyCategory, NPCType.Archer);
			int points = Mathf.CeilToInt((float)pointsToSpend * 0.8f);
			int num = Mathf.CeilToInt((float)pointsToSpend * 0.2f);
			enemiesToSpawn = DoBuyEnemies(unitsByPriceDesc, points, out var remainingPoints);
			enemiesToSpawn.AddRange(DoBuyEnemies(unitsByPriceDesc2, num + remainingPoints, out remainingPoints));
			return enemiesToSpawn.Count > 0;
		}

		public bool PurchaseEnemies(int wealthPoints, out List<IEnemyPurchaseUnit> enemiesToSpawn, out List<SiegeWeaponComponentBlueprint> siegeWeaponsInventory, string enemyCategory = null, bool forceSiegeWeaponRaid = false)
		{
			if (!string.IsNullOrEmpty(enemyCategory) && !Repository<NPCRepository, NPC>.Instance.GetAllItems().Any((NPC enemy) => enemy.Category.Equals(enemyCategory)))
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(53, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\RaidEnemySelector.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Enemy category '");
					messageBuilder.AppendFormatted(enemyCategory);
					messageBuilder.AppendLiteral("' not found. Setting it to 'general'.");
				}
				Log.Info(messageBuilder);
				enemyCategory = "general";
			}
			List<IEnemyPurchaseUnit> unitsByPriceDesc = GetUnitsByPriceDesc(addEnemies: true, addSiegeWeapons: false, addAnimals: false, enemyCategory, NPCType.Basic);
			List<IEnemyPurchaseUnit> unitsByPriceDesc2 = GetUnitsByPriceDesc(addEnemies: true, addSiegeWeapons: false, addAnimals: false, enemyCategory, NPCType.Archer);
			List<IEnemyPurchaseUnit> unitsByPriceDesc3 = GetUnitsByPriceDesc(addEnemies: true, addSiegeWeapons: false, addAnimals: false, enemyCategory, NPCType.Heavy);
			List<IEnemyPurchaseUnit> unitsByPriceDesc4 = GetUnitsByPriceDesc(addEnemies: false, addSiegeWeapons: true, addAnimals: false, null);
			int remainingPoints;
			float num = ((DoBuyEnemies(unitsByPriceDesc, wealthPoints, out remainingPoints).Count > 10) ? 0.1f : 0f);
			float num2 = (1f - num) * 0.8f;
			float num3 = 1f - num2 - num;
			int points = Mathf.CeilToInt((float)wealthPoints * num2);
			int num4 = Mathf.CeilToInt((float)wealthPoints * num3);
			int num5 = Mathf.CeilToInt((float)wealthPoints * num);
			List<IEnemyPurchaseUnit> list = DoBuyEnemies(unitsByPriceDesc, points, out remainingPoints);
			List<IEnemyPurchaseUnit> collection = DoBuyEnemies(unitsByPriceDesc2, num4 + remainingPoints, out remainingPoints);
			List<IEnemyPurchaseUnit> collection2 = DoBuyEnemies(unitsByPriceDesc3, num5 + remainingPoints, out remainingPoints);
			list.AddRange(collection);
			list.AddRange(collection2);
			LastRaidInfo lastRaidInfo = GlobalSaveController.CurrentVillageData.LastRaidInfo;
			lastRaidInfo.Variation = LastRaidInfo.RaidVariation.Basic;
			if ((float)wealthPoints < SingletonModel<RaidSpawnSettings, RaidSpawnSettingsData>.I.SiegeMinPointsForSiegeWeapons)
			{
				forceSiegeWeaponRaid = false;
			}
			bool flag = (int)GlobalSaveController.CurrentVillageData.GameParametersCurrent.GetById("enemiesHaveTrebuchet") == 1;
			if (flag && OverrideRaidVariation.Equals(LastRaidInfo.RaidVariation.Siege))
			{
				lastRaidInfo.Variation = LastRaidInfo.RaidVariation.Siege;
				int points2 = wealthPoints / 2;
				List<IEnemyPurchaseUnit> collection3 = DoBuyEnemies(unitsByPriceDesc4, points2, out remainingPoints, -1, minimumOne: true);
				list.AddRange(collection3);
			}
			else if (OverrideRaidVariation.Equals(LastRaidInfo.RaidVariation.SiegeWeaponRaid) || !lastRaidInfo.FirstRaid || forceSiegeWeaponRaid)
			{
				if (flag && (forceSiegeWeaponRaid || (lastRaidInfo.HasHeavyUnit && lastRaidInfo.HasDoor && lastRaidInfo.IsDoorDamageTaken && !lastRaidInfo.IsDoorDestroyed)))
				{
					lastRaidInfo.Variation = LastRaidInfo.RaidVariation.SiegeWeaponRaid;
					int points3 = wealthPoints / 2;
					List<IEnemyPurchaseUnit> collection4 = DoBuyEnemies(unitsByPriceDesc4, points3, out remainingPoints, 5, minimumOne: true);
					list.AddRange(collection4);
				}
				else if (OverrideRaidVariation.Equals(LastRaidInfo.RaidVariation.HeavyUnits))
				{
					lastRaidInfo.Variation = LastRaidInfo.RaidVariation.HeavyUnits;
					int maxToBuy = (int)Mathf.Max((float)list.Count * 0.1f, 1f);
					collection2 = DoBuyEnemies(unitsByPriceDesc3, wealthPoints, out remainingPoints, maxToBuy);
					int points4 = (int)((float)remainingPoints * 0.5f);
					int num6 = (int)((float)remainingPoints * 0.5f);
					int remainingPoints2;
					List<IEnemyPurchaseUnit> collection5 = DoBuyEnemies(unitsByPriceDesc2, points4, out remainingPoints2);
					List<IEnemyPurchaseUnit> collection6 = DoBuyEnemies(unitsByPriceDesc, remainingPoints2 + num6, out remainingPoints2);
					list.Clear();
					list.AddRange(collection2);
					list.AddRange(collection5);
					list.AddRange(collection6);
				}
				else if (OverrideRaidVariation.Equals(LastRaidInfo.RaidVariation.Archers))
				{
					lastRaidInfo.Variation = LastRaidInfo.RaidVariation.Archers;
					int maxToBuy2 = (int)Mathf.Max((float)list.Count * 0.5f, 1f);
					List<IEnemyPurchaseUnit> unitsByPriceDesc5 = GetUnitsByPriceDesc(addEnemies: true, addSiegeWeapons: false, addAnimals: false, enemyCategory, NPCType.Archer);
					List<IEnemyPurchaseUnit> collection7 = DoBuyEnemies(unitsByPriceDesc5, wealthPoints, out remainingPoints, maxToBuy2);
					int remainingPoints3;
					List<IEnemyPurchaseUnit> collection8 = DoBuyEnemies(unitsByPriceDesc, remainingPoints, out remainingPoints3);
					list.Clear();
					list.AddRange(collection7);
					list.AddRange(collection8);
				}
			}
			enemiesToSpawn = list.Where((IEnemyPurchaseUnit enemy) => !(enemy is SiegeWeaponComponentBlueprint)).ToList();
			siegeWeaponsInventory = list.Where((IEnemyPurchaseUnit enemy) => enemy is SiegeWeaponComponentBlueprint).Cast<SiegeWeaponComponentBlueprint>().ToList();
			return enemiesToSpawn.Count > 0;
		}

		public bool PurchaseEnemiesForAnimalRaid(out List<IEnemyPurchaseUnit> enemiesToSpawn, GameEvent animalRaid)
		{
			int points = (int)MonoSingleton<BaseWealth>.Instance.GetRaidPoints();
			List<IEnemyPurchaseUnit> unitsByPriceDesc = GetUnitsByPriceDesc(addEnemies: false, addSiegeWeapons: false, addAnimals: true, animalRaid.Category);
			if (animalRaid.UseRaidPoints || animalRaid.Count == null)
			{
				enemiesToSpawn = DoBuyEnemies(unitsByPriceDesc, points, out var _);
				return enemiesToSpawn.Count > 0;
			}
			enemiesToSpawn = new List<IEnemyPurchaseUnit>();
			int num = animalRaid.Count.RandomMaxInclusive();
			for (int i = 0; i < num; i++)
			{
				enemiesToSpawn.Add(unitsByPriceDesc.PickRandom());
			}
			return enemiesToSpawn.Count > 0;
		}

		public bool TryPurchaseEnemies(string factionId, WorldMapPlace battleMapPlace, out List<IEnemyPurchaseUnit> enemiesToSpawn)
		{
			if (factionId == null)
			{
				throw new Exception("Faction ID cannot be null");
			}
			string enemyCategory = factionId;
			int num = battleMapPlace.SecondMapType switch
			{
				SecondMapType.Attack => battleMapPlace.CachedMapInfo.RaidPoints, 
				SecondMapType.Settlement => battleMapPlace.CachedMapInfo.RaidPoints, 
				SecondMapType.Ambush => MonoSingleton<BaseWealth>.Instance.GetRaidPointsForAmbush(), 
				_ => 0, 
			};
			if (num == 0)
			{
				enemiesToSpawn = null;
				return false;
			}
			if (!string.IsNullOrEmpty(enemyCategory) && !Repository<NPCRepository, NPC>.Instance.GetAllItems().Any((NPC enemy) => enemy.Category.Equals(enemyCategory)))
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(53, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\RaidEnemySelector.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Enemy category '");
					messageBuilder.AppendFormatted(enemyCategory);
					messageBuilder.AppendLiteral("' not found. Setting it to 'general'.");
				}
				Log.Info(messageBuilder);
				enemyCategory = "general";
			}
			List<IEnemyPurchaseUnit> unitsByPriceDesc = GetUnitsByPriceDesc(addEnemies: true, addSiegeWeapons: false, addAnimals: false, enemyCategory, NPCType.Basic);
			List<IEnemyPurchaseUnit> unitsByPriceDesc2 = GetUnitsByPriceDesc(addEnemies: true, addSiegeWeapons: false, addAnimals: false, enemyCategory, NPCType.Archer);
			float num2 = 0.6f;
			float num3 = 1f - num2;
			int num4 = Mathf.CeilToInt((float)num * num3);
			int points = Mathf.CeilToInt((float)num * num2);
			int remainingPoints;
			List<IEnemyPurchaseUnit> collection = DoBuyEnemies(unitsByPriceDesc2, points, out remainingPoints, -1, minimumOne: false, 0.3f);
			List<IEnemyPurchaseUnit> list = DoBuyEnemies(unitsByPriceDesc, num4 + remainingPoints, out remainingPoints);
			list.AddRange(collection);
			enemiesToSpawn = list.Where((IEnemyPurchaseUnit enemy) => !(enemy is SiegeWeaponComponentBlueprint)).ToList();
			return enemiesToSpawn.Count > 0;
		}

		private List<IEnemyPurchaseUnit> GetEnemyUnits(bool addEnemies, bool addSiegeWeapons, bool addAnimals, string enemyCategory = null, NPCType? enemyType = null)
		{
			List<IEnemyPurchaseUnit> list = new List<IEnemyPurchaseUnit>();
			if (addEnemies)
			{
				List<IEnemyPurchaseUnit> list2 = new List<IEnemyPurchaseUnit>(Repository<NPCRepository, NPC>.Instance.GetAllItems());
				if (!string.IsNullOrEmpty(enemyCategory))
				{
					list2 = list2.FindAll((IEnemyPurchaseUnit e) => ((NPC)e).Category.Equals(enemyCategory));
				}
				if (enemyType.HasValue)
				{
					list2 = list2.FindAll((IEnemyPurchaseUnit e) => ((NPC)e).Type == enemyType);
				}
				list.AddRange(list2);
			}
			if (addSiegeWeapons)
			{
				list.AddRange(Repository<SiegeWeaponComponentRepository, SiegeWeaponComponentBlueprint>.Instance.GetAllItems());
			}
			if (addAnimals)
			{
				IEnumerable<Animal> allItems = Repository<AnimalBaseRepository, Animal>.Instance.GetAllItems();
				if (!string.IsNullOrEmpty(enemyCategory))
				{
					list.AddRange(allItems.Where((Animal animal) => animal.Category != null && animal.Category.Equals(enemyCategory)));
				}
				else
				{
					list.AddRange(allItems);
				}
			}
			return list;
		}

		private List<IEnemyPurchaseUnit> GetUnitsByPriceDesc(bool addEnemies, bool addSiegeWeapons, bool addAnimals, string enemyCategory, NPCType? enemyType = null)
		{
			List<IEnemyPurchaseUnit> enemyUnits = GetEnemyUnits(addEnemies, addSiegeWeapons, addAnimals, enemyCategory, enemyType);
			enemyUnits.Sort(delegate(IEnemyPurchaseUnit a, IEnemyPurchaseUnit b)
			{
				int num = a.GetPrice() * 100;
				int num2 = b.GetPrice() * 100;
				if (num == num2)
				{
					num += UnityEngine.Random.Range(0, 99);
					num2 += UnityEngine.Random.Range(0, 99);
				}
				return num2.CompareTo(num);
			});
			return enemyUnits;
		}

		private List<IEnemyPurchaseUnit> DoBuyEnemies(List<IEnemyPurchaseUnit> possibleEnemies, int points, out int remainingPoints, int maxToBuy = -1, bool minimumOne = false, float thresholdMultiplier = 1f)
		{
			remainingPoints = 0;
			List<IEnemyPurchaseUnit> list = new List<IEnemyPurchaseUnit>();
			int num = 0;
			IEnemyPurchaseUnit enemyPurchaseUnit;
			do
			{
				enemyPurchaseUnit = null;
				foreach (IEnemyPurchaseUnit possibleEnemy in possibleEnemies)
				{
					int num2 = TryPurchaseEnemy(possibleEnemy, points, thresholdMultiplier);
					if (num2 != -1)
					{
						points = num2;
						enemyPurchaseUnit = possibleEnemy;
						break;
					}
				}
				if (minimumOne && enemyPurchaseUnit == null)
				{
					IEnemyPurchaseUnit enemyPurchaseUnit2 = null;
					foreach (IEnemyPurchaseUnit possibleEnemy2 in possibleEnemies)
					{
						enemyPurchaseUnit2 = ((enemyPurchaseUnit2 == null || enemyPurchaseUnit2.GetPrice() > possibleEnemy2.GetPrice()) ? possibleEnemy2 : enemyPurchaseUnit2);
					}
					if (enemyPurchaseUnit2 != null)
					{
						list.Add(enemyPurchaseUnit2);
						points = 0;
						break;
					}
				}
				if (enemyPurchaseUnit != null)
				{
					list.Add(enemyPurchaseUnit);
					num++;
					if (maxToBuy != -1 && num >= maxToBuy)
					{
						break;
					}
				}
			}
			while (enemyPurchaseUnit != null);
			remainingPoints = points;
			return list;
		}

		private int TryPurchaseEnemy(IEnemyPurchaseUnit enemy, int availablePoints, float thresholdMultiplier)
		{
			if (enemy == null)
			{
				return -1;
			}
			if (availablePoints < enemy.GetPrice())
			{
				return -1;
			}
			if ((float)availablePoints * (enemy.GetPriceThreshold() * thresholdMultiplier) < (float)enemy.GetPrice())
			{
				return -1;
			}
			return availablePoints - enemy.GetPrice();
		}
	}
}
