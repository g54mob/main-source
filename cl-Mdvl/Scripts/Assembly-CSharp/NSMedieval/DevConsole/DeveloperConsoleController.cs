using System;
using System.Collections.Generic;
using System.Reflection;
using NSEipix.Base;
using NSMedieval.UI;
using NSMedieval.UI.Utils;

namespace NSMedieval.DevConsole
{
	public class DeveloperConsoleController : MonoController<DeveloperConsoleController>
	{
		public bool MouseInputBlocked { get; set; }

		public Dictionary<string, ConsoleCommand> Commands { get; } = new Dictionary<string, ConsoleCommand>();

		public event Action<bool> InfoCursorDevToggleEvent;

		public event UIController.UpdateInfoCursorHandle UpdateInfoCursorContentDevEvent;

		private void Start()
		{
			AddAllCommands();
		}

		public ConsoleCommand GetCommand(string key)
		{
			Commands.TryGetValue(key, out var value);
			return value;
		}

		public void ToggleInfoCursor(bool active)
		{
			this.InfoCursorDevToggleEvent?.Invoke(active);
		}

		public void UpdateInfoCursorContent(List<string> textLines, bool background = true, float fontSizeScaler = 1f)
		{
			this.UpdateInfoCursorContentDevEvent?.Invoke(textLines, "devConsole", 0, background, fontSizeScaler);
		}

		public void UpdateInfoCursorContent(string iconID, bool background, float fontSizeScaler = 1f)
		{
			this.UpdateInfoCursorContentDevEvent?.Invoke(new List<string> { AssetUtils.GetSpriteAsset(iconID) }, "devConsole", 0, background, fontSizeScaler);
		}

		public void AddCommand(string name, ConsoleCommand command)
		{
			if (!Commands.ContainsKey(name))
			{
				Commands.Add(name, command);
			}
		}

		public void ParseCommand(string commandName)
		{
			ParseCommand(commandName, new string[0]);
		}

		public void ParseCommand(string commandName, float value)
		{
			ParseCommand(commandName, new string[1] { value.ToString() });
		}

		public void ParseCommand(string commandName, string[] arguments)
		{
			if (!Commands.ContainsKey(commandName))
			{
				string text = commandName + string.Join(" ", arguments);
				ReturnCommandResult("Command not recognized: " + text, ConsoleMessageType.Error);
				return;
			}
			MethodInfo methodInfo = null;
			MethodInfo[] commandMethod = Commands[commandName].GetCommandMethod();
			foreach (MethodInfo methodInfo2 in commandMethod)
			{
				if (methodInfo2.GetParameters().Length == arguments.Length)
				{
					methodInfo = methodInfo2;
					break;
				}
			}
			ParameterInfo[] array = methodInfo?.GetParameters();
			if (array == null || arguments.Length != array.Length)
			{
				ReturnCommandResult(ArgumentCountError(commandName), ConsoleMessageType.Error);
				return;
			}
			object[] array2 = new object[arguments.Length];
			for (int j = 0; j < arguments.Length; j++)
			{
				try
				{
					array2[j] = Convert.ChangeType(arguments[j], array[j].ParameterType);
				}
				catch (Exception)
				{
					ReturnCommandResult(WrongArgumentType(j + 1, commandName), ConsoleMessageType.Error);
					return;
				}
			}
			methodInfo.Invoke(Commands[commandName], array2);
		}

		public void ReturnCommandResult(string result, ConsoleMessageType messageType = ConsoleMessageType.Standard)
		{
			NotifyOne("AddMessageToConsole", result, messageType);
		}

		public void ClearConsole()
		{
			NotifyOne("ClearConsoleMessagesText");
		}

		private string WrongArgumentType(int paramIndex, string command)
		{
			return $"Wrong argument type:({paramIndex}). Use command <color=lime><i>help {command}</i></color> for full description.";
		}

		private string ArgumentCountError(string command)
		{
			return $"Wrong number of arguments. Use command <color=green><i>help {command}</i></color> for full description.";
		}

		private void AddAllCommands()
		{
			AddCommand(new CommandQuit());
			AddCommand(new CommandList());
			AddCommand(new CommandHelp());
			AddCommand(new CommandGarbageCollect());
			AddCommand(new CommandSpawnResourcePile());
			AddCommand(new CommandSpawnResourceCategory());
			AddCommand(new CommandSpawnRandomResourcePiles());
			AddCommand(new CommandSpawnAnimal());
			AddCommand(new CommandSpawnDomesticAnimals());
			AddCommand(new CommandSpawnPetAnimal());
			AddCommand(new CommandSpawnPlant());
			AddCommand(new CommandSpawnMaturePlant());
			AddCommand(new CommandSpawnFish());
			AddCommand(new CommandSpawnWorker());
			AddCommand(new CommandRemoveWorker());
			AddCommand(new CommandSetWorkerHunger());
			AddCommand(new CommandFainWorker());
			AddCommand(new CommandSetWorkerSleep());
			AddCommand(new CommandDrawEffectMap());
			AddCommand(new CommandDrawMapMask());
			AddCommand(new CommandDamageVoxels());
			AddCommand(new CommandDealDamage());
			AddCommand(new LadderFalldown());
			AddCommand(new CommandAutoconstruct());
			AddCommand(new CommandForcePlantCrops());
			AddCommand(new CommandSpawnMaterialsWithBuilding());
			AddCommand(new CommandUnlockAllVariants());
			AddCommand(new CommandConstructionSpeedMax());
			AddCommand(new CommandToggleTooltips());
			AddCommand(new CommandMarketingMode());
			AddCommand(new CommandConstructWithoutResources());
			AddCommand(new CommandForceCropHarvestPhase());
			AddCommand(new CommandActivateAllResearch());
			AddCommand(new CommandAutoProductionWithoutResource());
			AddCommand(new CommandAutoProductionWithoutWorker());
			AddCommand(new CommandSetProductionSpeed());
			AddCommand(new CommandKillPlants());
			AddCommand(new CommandInstantCut());
			AddCommand(new CommandCraftableBuildingsEnabled());
			AddCommand(new CommandPlantNextPhase());
			AddCommand(new CommandFillStorage());
			AddCommand(new CommandCropNextPhase());
			AddCommand(new CommandSetLowFuel());
			AddCommand(new CommandKillEnemies());
			AddCommand(new CommandRemoveResourcePile());
			AddCommand(new CommandSetDebugCombatTarget());
			AddCommand(new CommandChangeWorkerMood());
			AddCommand(new CommandToggleWeatherDebugView());
			AddCommand(new CommandInstantDig());
			AddCommand(new CommandSpawnEnemy());
			AddCommand(new CommandSpawnNPC());
			AddCommand(new CommandSetNpcBehaviour());
			AddCommand(new CommandMakeNPCLeave());
			AddCommand(new CommandSpawnParticleSystem());
			AddCommand(new CommandSpawnTrader());
			AddCommand(new CommandVoxelInfo());
			AddCommand(new CommandAddExperience());
			AddCommand(new CommandSetWorkerHealth());
			AddCommand(new CommandSetFreshness());
			AddCommand(new CommandUnlockAchievement());
			AddCommand(new CommandResetAchievement());
			AddCommand(new CommandAchievementSetStat());
			AddCommand(new CommandFireEffector());
			AddCommand(new CommandEndEffector());
			AddCommand(new CommandAnimateAllWorkers());
			AddCommand(new CommandSetAgentStat());
			AddCommand(new CommandThunder());
			AddCommand(new CommandToggleUI());
			AddCommand(new CommandCountResources());
			AddCommand(new CommandTrackWorkerAreas());
			AddCommand(new CommandMarkForRoping());
			AddCommand(new CommandSetPet());
			AddCommand(new CommandSetDomestic());
			AddCommand(new CommandSetWild());
			AddCommand(new CommandSetWildAggressive());
			AddCommand(new CommandSetPregnant());
			AddCommand(new CommandGiveBirth());
			AddCommand(new CommandFinishAnimalProduction());
			AddCommand(new CommandResetAnimalTamingAndTraining());
			AddCommand(new CommandTriggerTrap());
			AddCommand(new CommandResetTrap());
			AddCommand(new CommandForceGoal());
			AddCommand(new CommandSetHaulMode());
			AddCommand(new CommandSetSeason());
			AddCommand(new CommandSetTimeInDay());
			AddCommand(new CommandSetWeatherEvent());
			AddCommand(new CommandSetWorkerStat());
			AddCommand(new CommandDrawGrass());
			AddCommand(new CommandDrawSnow());
			AddCommand(new CommandDrawWetness());
			AddCommand(new CommandSetStunted());
			AddCommand(new CommandSetInteractionEventChance());
			AddCommand(new CommandP2PPathCheck());
			AddCommand(new CommandKillAllPiles());
			AddCommand(new CommandWoundWorker());
			AddCommand(new CommandSpawnBardVisitor());
			AddCommand(new CommandSpawnPriestVisitor());
			AddCommand(new CommandSpawnShamanVisitor());
			AddCommand(new CommandKillAllFish());
			AddCommand(new CommandDebugTryFishSpawning());
			AddCommand(new CommandToggleCreatureInvulnerability());
			AddCommand(new CommandSetNPCFaction());
			AddCommand(new CommandGenerateRaidSpawnPoints());
			AddCommand(new CommandCreateCommanderGroupFromSelection());
			AddCommand(new CommandCreateCommanderGroupFromAll());
			AddCommand(new CommandSetManualInputCommanderAgent());
			AddCommand(new CommandSetManualConstructCommanderAgent());
			AddCommand(new CommandSetManualDigCommanderAgent());
			AddCommand(new CommandFindCastleBreachingPoint());
			AddCommand(new CommandSetFactionOwnership());
			AddCommand(new CommandConvertAllBuildingsToEnemyOwned());
			AddCommand(new CommandAllowEdgePlacement());
			AddCommand(new CommandDisableSecondMapTimer());
			AddCommand(new CommandListGlobalStats());
			AddCommand(new CommandSetGlobalStat());
			AddCommand(new CommandUnlockRoomType());
			AddCommand(new CommandUnlockEvent());
			AddCommand(new CommandDeleteMapMarker());
			AddCommand(new CommandSetTradeDeal());
			AddCommand(new CommandSetWalkableModel());
		}

		private void AddCommand(ConsoleCommand command)
		{
			Commands.TryAdd(command.Command, command);
		}
	}
}
