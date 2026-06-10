using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.BuildingComponents;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;

namespace NSMedieval.CommanderAI
{
	[FVSerializableKey("CommanderAIGroup", "")]
	public class CommanderAIGroup : IFVSerializable
	{
		private readonly Dictionary<HumanoidInstance, CommanderAIUnit> humanoidToUnit = new Dictionary<HumanoidInstance, CommanderAIUnit>();

		private readonly List<BaseBuildingInstance> deployedSiegeWeapons = new List<BaseBuildingInstance>();

		private readonly Dictionary<string, int> siegeWeaponInventory = new Dictionary<string, int>();

		public ICollection<CommanderAIUnit> Units => humanoidToUnit.Values;

		public List<BaseBuildingInstance> DeployedSiegeWeapons => deployedSiegeWeapons;

		public Dictionary<string, int> SiegeWeaponInventory => siegeWeaponInventory;

		public CommanderAIGroup()
		{
		}

		public void InitAfterLoad()
		{
			using PooledList<CommanderAIUnit> pooledList = ListPool<CommanderAIUnit>.GetJanitor();
			foreach (CommanderAIUnit unit in Units)
			{
				if (!GlobalSaveController.CurrentVillageData.NPCs.Contains(unit.Humanoid))
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(74, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\CommanderAIGroup.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Humanoid is in units list, but is not in save data NPCs list, removing: '");
						messageBuilder.AppendFormatted(unit.Humanoid);
						messageBuilder.AppendLiteral("'");
					}
					Log.Error(messageBuilder);
					pooledList.Add(unit);
				}
				else
				{
					if (!GlobalSaveController.CurrentVillageData.IsSecondMap)
					{
						unit.CurrentOrder = MoveOrder.Stop(unit);
					}
					unit.Humanoid.OnDisposedEvent += OnUnitDisposed;
				}
			}
			foreach (CommanderAIUnit item in pooledList)
			{
				humanoidToUnit.Remove(item.Humanoid);
			}
			foreach (BaseBuildingInstance deployedSiegeWeapon in deployedSiegeWeapons)
			{
				deployedSiegeWeapon.OnDisposedEvent += OnBuildingDisposed;
			}
		}

		public void AddUnit(EnemyBehaviour enemyUnit)
		{
			if (humanoidToUnit.ContainsKey(enemyUnit.Humanoid))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(61, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\CommanderAIGroup.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Tried to add enemy '");
					messageBuilder.AppendFormatted(enemyUnit.Humanoid.GetFullName());
					messageBuilder.AppendLiteral("' to group, but they are already in there");
				}
				Log.Error(messageBuilder);
			}
			else
			{
				CommanderAIUnit commanderAIUnit = new CommanderAIUnit(enemyUnit.Humanoid);
				if (!GlobalSaveController.CurrentVillageData.IsSecondMap)
				{
					commanderAIUnit.CurrentOrder = MoveOrder.Stop(commanderAIUnit);
				}
				commanderAIUnit.Humanoid.OnDisposedEvent += OnUnitDisposed;
				humanoidToUnit[enemyUnit.Humanoid] = commanderAIUnit;
			}
		}

		public int GetSiegeWeaponInventoryCount(string blueprintId)
		{
			return siegeWeaponInventory.GetValueOrDefault(blueprintId, 0);
		}

		public void AddSiegeWeapon(BaseBuildingInstance building)
		{
			if (deployedSiegeWeapons.Contains(building))
			{
				return;
			}
			deployedSiegeWeapons.Add(building);
			building.OnDisposedEvent += OnBuildingDisposed;
			string blueprintId = building.BlueprintId;
			if (siegeWeaponInventory.ContainsKey(blueprintId))
			{
				siegeWeaponInventory[blueprintId]--;
				if (siegeWeaponInventory[blueprintId] <= 0)
				{
					siegeWeaponInventory.Remove(blueprintId);
				}
				return;
			}
			bool isEnabled;
			FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(54, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\CommanderAIGroup.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Added siege weapon '");
				messageBuilder.AppendFormatted(blueprintId);
				messageBuilder.AppendLiteral("', but it was not in the inventory");
			}
			Log.Error(messageBuilder);
		}

		private void OnUnitDisposed(IGameDisposable unitAsDisposable)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(35, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\CommanderAIGroup.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Removing unit from commander group ");
				messageBuilder.AppendFormatted(unitAsDisposable);
			}
			Log.Info(messageBuilder);
			unitAsDisposable.OnDisposedEvent -= OnUnitDisposed;
			if (!(unitAsDisposable is HumanoidInstance key))
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(51, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\CommanderAIGroup.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("OnUnitDisposed invoked with non-humanoid object: '");
					messageBuilder2.AppendFormatted(unitAsDisposable);
					messageBuilder2.AppendLiteral("'");
				}
				Log.Error(messageBuilder2);
			}
			else
			{
				humanoidToUnit.Remove(key);
			}
		}

		private void OnBuildingDisposed(IGameDisposable obj)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(39, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\CommanderAIGroup.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Removing building from commander group ");
				messageBuilder.AppendFormatted(obj);
			}
			Log.Info(messageBuilder);
			obj.OnDisposedEvent -= OnBuildingDisposed;
			if (!(obj is BaseBuildingInstance item))
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(55, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\CommanderAIGroup.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("OnBuildingDisposed invoked with non-building object: '");
					messageBuilder2.AppendFormatted(obj);
					messageBuilder2.AppendLiteral("'");
				}
				Log.Error(messageBuilder2);
			}
			else
			{
				deployedSiegeWeapons.Remove(item);
			}
		}

		public CommanderAIUnit GetUnit(HumanoidInstance humanoid)
		{
			humanoidToUnit.TryGetValue(humanoid, out var value);
			return value;
		}

		public bool HasUnit(EnemyBehaviour enemy)
		{
			return HasUnit(enemy.Humanoid);
		}

		public bool HasUnit(HumanoidInstance humanoid)
		{
			return humanoidToUnit.ContainsKey(humanoid);
		}

		public void Serialize(FVSerializer serializer)
		{
			HumanoidInstance[] value = Units.Select((CommanderAIUnit unit) => unit.Humanoid).ToArray();
			serializer.Write("units", value);
			serializer.Write("siegeWeaponsInventory", siegeWeaponInventory);
			serializer.Write("deployedSiegeWeapons", deployedSiegeWeapons);
		}

		public CommanderAIGroup(FVDeserializer deserializer)
		{
			HumanoidInstance[] array = deserializer.ReadObjectArray<HumanoidInstance>("units");
			foreach (HumanoidInstance humanoidInstance in array)
			{
				humanoidToUnit[humanoidInstance] = new CommanderAIUnit(humanoidInstance);
			}
			deployedSiegeWeapons = deserializer.ReadObjectList<BaseBuildingInstance>("deployedSiegeWeapons") ?? new List<BaseBuildingInstance>();
			siegeWeaponInventory = deserializer.ReadStringIntDict("siegeWeaponsInventory") ?? new Dictionary<string, int>();
		}
	}
}
