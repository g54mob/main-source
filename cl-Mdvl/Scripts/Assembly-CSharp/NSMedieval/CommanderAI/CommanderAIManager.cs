using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using Raid.Config;
using UnityEngine;

namespace NSMedieval.CommanderAI
{
	public class CommanderAIManager : IDisposable
	{
		public readonly VillageMap Map;

		private readonly Dictionary<uint, CommanderAgentBase> idToCommander;

		public IEnumerable<CommanderAgentBase> Commanders => idToCommander.Values;

		public CommanderAIManager(VillageMap map)
		{
			idToCommander = new Dictionary<uint, CommanderAgentBase>();
			Map = map;
		}

		public void InitAfterLoad(List<CommanderAgentBase> commanders)
		{
			using PooledHashSet<int> pooledHashSet = HashSetPool<int>.GetJanitor();
			foreach (CommanderAgentBase commander in commanders)
			{
				idToCommander[commander.Id] = commander;
				commander.InitAfterLoad();
				foreach (CommanderAIUnit unit in commander.Units)
				{
					if (!pooledHashSet.Add(unit.Humanoid.UniqueId))
					{
						bool isEnabled;
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(113, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\CommanderAIManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Save corrupted: unit ");
							messageBuilder.AppendFormatted(unit.Humanoid.GetFullName());
							messageBuilder.AppendLiteral(" is assigned to more than one commander, for now we should only allow one commander per unit");
						}
						Log.Error(messageBuilder);
					}
				}
			}
			if (commanders.Count > 1)
			{
				Log.Error("There are multiple active commanders, this is probably not what you want", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\CommanderAIManager.cs");
			}
		}

		public uint CreateCommander(IList<HumanoidInstance> units = null, SiegeWeaponComponentBlueprint[] siegeWeapons = null, SiegePathfinderPenaltyModifiers siegePathfinderModifiers = null)
		{
			if (siegePathfinderModifiers == null)
			{
				siegePathfinderModifiers = SingletonModel<RaidSpawnSettings, RaidSpawnSettingsData>.I.StandardSiegePathfinderSettings;
			}
			uint num = GenerateUniqueCommanderId();
			BehaviourTreeCommanderAgent newCommander = new BehaviourTreeCommanderAgent(num, Map, siegePathfinderModifiers);
			idToCommander[num] = newCommander;
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\CommanderAIManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Created new enemy commander '");
				messageBuilder.AppendFormatted(newCommander.GetType().Name);
				messageBuilder.AppendLiteral("'");
			}
			Log.Info(messageBuilder);
			if (units != null)
			{
				foreach (HumanoidInstance humanoidUnit in units)
				{
					EnemyBehaviour enemyBehaviour = humanoidUnit.EnemyBehaviour;
					if (enemyBehaviour == null)
					{
						FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(92, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\CommanderAIManager.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("Tried to assign humanoid to commander, but it doesn't have an enemy behaviour (humanoid: '");
							messageBuilder2.AppendFormatted(humanoidUnit);
							messageBuilder2.AppendLiteral("')");
						}
						Log.Error(messageBuilder2);
					}
					else if (idToCommander.Values.Any((CommanderAgentBase commander) => commander != newCommander && commander.UnitGroup.HasUnit(humanoidUnit)))
					{
						FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(128, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\CommanderAIManager.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("Tried to assign humanoid ");
							messageBuilder2.AppendFormatted(humanoidUnit.GetFullName());
							messageBuilder2.AppendLiteral(" to new commander, but this unit is already assigned to another commander. This is not allowed for now.");
						}
						Log.Error(messageBuilder2);
					}
					else
					{
						newCommander.UnitGroup.AddUnit(enemyBehaviour);
					}
				}
			}
			if (siegeWeapons != null)
			{
				for (int num2 = 0; num2 < siegeWeapons.Length; num2++)
				{
					string iD = siegeWeapons[num2].GetID();
					newCommander.SiegeWeaponInventory.TryAdd(iD, 0);
					newCommander.SiegeWeaponInventory[iD]++;
				}
			}
			if (idToCommander.Count > 1)
			{
				Log.Error("There are multiple active commanders, this is probably not what you want", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\CommanderAIManager.cs");
			}
			return num;
		}

		public CommanderAgentBase GetCommander(uint id)
		{
			idToCommander.TryGetValue(id, out var value);
			return value;
		}

		public bool AssignUnitToCommander(EnemyBehaviour enemy, uint groupId)
		{
			if (!idToCommander.TryGetValue(groupId, out var existingCommander))
			{
				return false;
			}
			if (idToCommander.Values.Any((CommanderAgentBase commander) => commander != existingCommander && commander.UnitGroup.HasUnit(enemy)))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(92, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\CommanderAIManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Failed to assign enemy ");
					messageBuilder.AppendFormatted(enemy.Humanoid.GetFullName());
					messageBuilder.AppendLiteral(" to commander id ");
					messageBuilder.AppendFormatted(groupId);
					messageBuilder.AppendLiteral(" because it is already assigned to another commander");
				}
				Log.Error(messageBuilder);
				return false;
			}
			existingCommander.UnitGroup.AddUnit(enemy);
			return true;
		}

		public void ReplaceCommanderAgent(uint commanderId, CommanderAgentBase newCommander)
		{
			if (idToCommander.TryGetValue(commanderId, out var value))
			{
				value.TransferTo(newCommander);
				idToCommander[newCommander.Id] = newCommander;
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(39, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\CommanderAIManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Replaced enemy commander agent '");
					messageBuilder.AppendFormatted(value.GetType().Name);
					messageBuilder.AppendLiteral("' -> '");
					messageBuilder.AppendFormatted(newCommander.GetType().Name);
					messageBuilder.AppendLiteral("'");
				}
				Log.Info(messageBuilder);
				value.Dispose();
			}
		}

		public void DestroyCommander(uint commanderId)
		{
			if (idToCommander.TryGetValue(commanderId, out var value))
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(35, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\CommanderAIManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Destroying commander agent '");
					messageBuilder.AppendFormatted(value.GetType().Name);
					messageBuilder.AppendLiteral("' (id ");
					messageBuilder.AppendFormatted(value.Id);
					messageBuilder.AppendLiteral(")");
				}
				Log.Info(messageBuilder);
				value.Dispose();
				idToCommander.Remove(commanderId);
			}
		}

		public void LinkWithRaid(uint commanderAgentId, ActiveRaidInfo activeRaidInfo)
		{
			if (idToCommander.TryGetValue(commanderAgentId, out var value))
			{
				value.LinkWithRaid(activeRaidInfo);
			}
		}

		public bool HasDeployedSiegeWeapons()
		{
			foreach (CommanderAgentBase commander in Commanders)
			{
				if (commander.DeployedSiegeWeapons != null && commander.DeployedSiegeWeapons.Count > 0)
				{
					return true;
				}
			}
			return false;
		}

		public void Dispose()
		{
			foreach (CommanderAgentBase value in idToCommander.Values)
			{
				value.Dispose();
			}
			idToCommander.Clear();
		}

		private uint GenerateUniqueCommanderId()
		{
			uint num;
			for (num = (uint)Time.unscaledTime; idToCommander.ContainsKey(num); num++)
			{
			}
			return num;
		}
	}
}
