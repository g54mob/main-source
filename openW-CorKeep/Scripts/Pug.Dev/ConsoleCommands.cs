#define PUG_ACHIEVEMENTS
using System;
using System.Collections.Generic;
using System.Text;
using PlayerCommand;
using PlayerState;
using Pug.RP;
using Pug.UnityExtensions;
using PugMod;
using PugTilemap;
using QFSW.QC;
using QFSW.QC.Suggestors;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Scripting;

public class ConsoleCommands : MonoBehaviour
{
	[CommandPrefix("camera.")]
	private static class Camera
	{
		[Preserve]
		[CommandWithModSupport("toggleManualCamera", "Enable/disable manual camera control", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void ToggleManualCamera()
		{
			if (CanUseConsoleCommands())
			{
				bool flag = Manager.camera.currentCameraStyle != CameraManager.CameraControlStyle.ManualControl;
				Manager.main.player.ToggleManualCamera();
				if (flag)
				{
					Manager.camera.manualControlTargetPosition = Manager.main.player?.WorldPosition ?? Manager.camera.manualControlTargetPosition;
					Manager.menu.quantumConsole.LogToConsole("Manual camera control enabled. Use WASD to move the camera, hold Shift to move faster.");
				}
				else
				{
					Manager.menu.quantumConsole.LogToConsole("Manual camera control disabled.");
				}
				Manager.camera.currentCameraStyle = (flag ? CameraManager.CameraControlStyle.ManualControl : CameraManager.CameraControlStyle.FollowPlayer);
			}
		}

		[Preserve]
		[CommandWithModSupport("SetManualCameraPosition", "", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void SetManualCameraPosition(Vector2 position)
		{
			if (CanUseConsoleCommands())
			{
				if (Manager.camera.currentCameraStyle != CameraManager.CameraControlStyle.ManualControl)
				{
					ToggleManualCamera();
				}
				Manager.camera.manualControlTargetPosition = position.X0Y();
			}
		}

		[Preserve]
		[CommandWithModSupport("toggleCameraSmoothing", "", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void ToggleCameraSmoothing()
		{
			switch (Manager.camera.cameraMovementStyle)
			{
			case CameraManager.CameraMovementStyle.Instant:
				Manager.camera.cameraMovementStyle = CameraManager.CameraMovementStyle.Smooth;
				break;
			case CameraManager.CameraMovementStyle.Smooth:
				Manager.camera.cameraMovementStyle = CameraManager.CameraMovementStyle.Instant;
				break;
			}
		}

		[Preserve]
		[CommandWithModSupport("cameraSmoothingSpeed", "", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static float CameraSmoothingSpeed(float speed)
		{
			return Manager.camera.smoothedCameraLerpSpeed = speed;
		}

		[Preserve]
		[CommandWithModSupport("cameraSmoothingSpeed", "", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static float CameraSmoothingSpeed()
		{
			return Manager.camera.smoothedCameraLerpSpeed;
		}

		[Preserve]
		[CommandWithModSupport("cameraSmoothingMinPixelSnap", "", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static float CameraSmoothingMinPixelSnap(float minPixelSnap)
		{
			return Manager.camera.smoothedCameraMinPixelSnap = minPixelSnap;
		}

		[Preserve]
		[CommandWithModSupport("cameraSmoothingMinPixelSnap", "", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static float CameraSmoothingMinPixelSnap()
		{
			return Manager.camera.smoothedCameraMinPixelSnap;
		}

		[Preserve]
		[CommandWithModSupport("cameraSmoothingTeleportThreshold", "", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static float CameraSmoothingTeleportThreshold(float teleportThreshold)
		{
			return Manager.camera.smoothedCameraTeleportThreshold = teleportThreshold;
		}

		[Preserve]
		[CommandWithModSupport("cameraSmoothingTeleportThreshold", "", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static float CameraSmoothingTeleportThreshold()
		{
			return Manager.camera.smoothedCameraTeleportThreshold;
		}
	}

	[CommandPrefix("player.")]
	private static class Player
	{
		[Preserve]
		[CommandWithModSupport("setSkill", "", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		public static void SetSkill(SkillID id, int level)
		{
			if (CanUseConsoleCommands())
			{
				PlayerController player = Manager.main.player;
				player.playerCommandSystem.DebugSetSkillValue(player.entity, id, level);
				Manager.menu.quantumConsole.LogToConsole($"Set {id} to level {level.ToString()}.");
			}
		}

		[Preserve]
		[CommandWithModSupport("position", "Get or set player position", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static Vector2 Position()
		{
			if (!CanUseConsoleCommands())
			{
				return Vector2.zero;
			}
			return Manager.main.player.WorldPosition.XZ();
		}

		[Preserve]
		[CommandWithModSupport("position", "", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static Vector2 Position(Vector2 position)
		{
			if (!CanUseConsoleCommands())
			{
				return Manager.main.player.WorldPosition.XZ();
			}
			Manager.main.player.DebugSetPlayerPosition(position.X0Y());
			Manager.menu.quantumConsole.LogToConsole("Moved " + Manager.main.player.playerName + " to " + position.ToString() + ".");
			return Manager.main.player.WorldPosition.XZ();
		}

		[Preserve]
		[CommandWithModSupport("setMovementSpeedMultiplier", "Set player movement speed multiplier", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void DebugSetPlayerMovementSpeedMultiplier(float multiplier)
		{
			if (CanUseConsoleCommands())
			{
				Manager.main.player.playerCommandSystem.DebugSetMovementSpeed(Manager.main.player.entity, multiplier * Manager.main.player.movementSpeed);
			}
		}

		[Preserve]
		[CommandWithModSupport("superman", "Gain super powers (multiplied with strengthMultiplier) for a limited time", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void EnableSuperMan(int strengthMultiplier = 10)
		{
			if (CanUseConsoleCommands())
			{
				Manager.main.player.playerCommandSystem.DebugEnableSuperMan(Manager.main.player.entity, strengthMultiplier);
				Manager.menu.quantumConsole.LogToConsole("Super powers enabled (x" + strengthMultiplier + ").");
			}
		}

		[Preserve]
		[CommandWithModSupport("disableSuperman", "Lose super powers", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void DisableSuperMan()
		{
			if (CanUseConsoleCommands())
			{
				Manager.main.player.playerCommandSystem.DebugDisableSuperMan(Manager.main.player.entity);
				Manager.menu.quantumConsole.LogToConsole("Super powers disabled.");
			}
		}

		[Preserve]
		[CommandWithModSupport("invincible", "Turns player invincibility on/off.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void SetInvincible(bool trueOrFalse)
		{
			if (CanUseConsoleCommands())
			{
				Manager.prefs.playerInvincible = trueOrFalse;
				Manager.main.player.playerCommandSystem.DebugSetPlayerImmuneToDamage(Manager.main.player.entity, trueOrFalse);
				string playerName = Manager.main.player.playerName;
				Manager.menu.quantumConsole.LogToConsole(trueOrFalse ? (playerName + " is now invincible.") : (playerName + " is no longer invincible."));
			}
		}

		[Preserve]
		[CommandWithModSupport("noclip", "Turns player noclip on/off.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void SetNoclip(bool trueOrFalse)
		{
			if (CanUseConsoleCommands())
			{
				Manager.main.player.playerCommandSystem.DebugSetPlayerState(Manager.main.player.entity, trueOrFalse ? PlayerStateEnum.NoClip : PlayerStateEnum.Walk);
			}
		}

		[Preserve]
		[Command("setAllSkillsToMax", "Sets all skills at max level", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void MaxOutAllSkills()
		{
			Manager.main.player.MaxOutAllSkills();
		}

		[Preserve]
		[CommandWithModSupport("setAllSkillsLevel", "Sets all skills to the given level", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void SetAllSkills(int level)
		{
			if (CanUseConsoleCommands())
			{
				PlayerController player = Manager.main.player;
				for (SkillID skillID = SkillID.Mining; skillID < SkillID.NUM_SKILLS; skillID++)
				{
					int skillFromLevel = SkillExtensions.GetSkillFromLevel(skillID, level);
					player.playerCommandSystem.DebugSetSkillValue(player.entity, skillID, skillFromLevel);
					Manager.menu.quantumConsole.LogToConsole($"Set {skillID} to level {level.ToString()}.");
				}
			}
		}

		[Preserve]
		[Command("resetAllSkills", "Resets all skills", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void ResetAllSkills()
		{
			Manager.main.player.ResetAllSkills();
		}

		[Preserve]
		[Command("randomizeTalents", "Randomizes all talents", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void RandomizeTalents()
		{
			List<List<int>> list = new List<List<int>>();
			list.Add(new List<int> { 1, 2 });
			list.Add(new List<int> { 3, 4 });
			list.Add(new List<int> { 4, 5 });
			list.Add(new List<int> { 6 });
			list.Add(new List<int> { 6, 7 });
			list.Add(new List<int> { 7 });
			list.Add(new List<int>());
			list.Add(new List<int>());
			PlayerController player = Manager.main.player;
			SkillTalentsTable skillTalentsTable = Manager.mod.SkillTalentsTable;
			for (SkillID skillID = SkillID.Mining; skillID < SkillID.NUM_SKILLS; skillID++)
			{
				SkillTalentsTable.SkillTalentTree skillTalentTree = skillTalentsTable.GetSkillTalentTree(skillID);
				Manager.saves.ResetTalentTree(skillID);
				int num = Manager.saves.GetAvailableTalentPoints(skillID);
				Manager.menu.quantumConsole.LogToConsole($"Assign {num} talent points for {skillID}");
				List<int> list2 = new List<int>();
				HashSet<int> hashSet = new HashSet<int>();
				list2.Add(0);
				while (num > 0 && list2.Count > 0)
				{
					int num2 = list2[UnityEngine.Random.Range(0, list2.Count)];
					int num3 = math.min(num, 5);
					ConditionData conditionDataForSkillTalent = skillTalentsTable.GetConditionDataForSkillTalent(skillID, num2, num3);
					string name = skillTalentTree.skillTalents[num2].name;
					player.playerCommandSystem.SetSkillTalentCondition(player.entity, conditionDataForSkillTalent);
					Manager.saves.SetSkillTalentPoint(skillID, num2, num3);
					Manager.menu.quantumConsole.LogToConsole($"Assign {num3} points to {name}");
					num -= num3;
					list2.Remove(num2);
					foreach (int item in list[num2])
					{
						if (!hashSet.Contains(item))
						{
							hashSet.Add(item);
							list2.Add(item);
						}
					}
				}
			}
		}

		[Preserve]
		[CommandWithModSupport("setHunger", "Sets hunger value", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void SetHunger(int amount)
		{
			if (CanUseConsoleCommands())
			{
				Manager.main.player.playerCommandSystem.DebugSetHunger(Manager.main.player.entity, math.clamp(amount, 0, 100));
				Manager.menu.quantumConsole.LogToConsole("Set hunger to " + math.clamp(amount, 0, 100) + ".");
			}
		}

		[Preserve]
		[CommandWithModSupport("setHealth", "Sets health value", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void SetHealth(int amount)
		{
			if (CanUseConsoleCommands())
			{
				PlayerController player = Manager.main.player;
				player.playerCommandSystem.DebugSetHealth(player.entity, math.clamp(amount, 0, player.GetMaxHealth()), player.IsHardcore);
				Manager.menu.quantumConsole.LogToConsole("Set health to " + math.clamp(amount, 0, player.GetMaxHealth()) + ".");
			}
		}

		[Preserve]
		[CommandWithModSupport("setBaseMaxHealth", "Sets base max health value", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void SetBaseMaxHealth(int amount)
		{
			if (CanUseConsoleCommands())
			{
				PlayerController player = Manager.main.player;
				player.playerCommandSystem.DebugSetBaseMaxHealth(player.entity, amount);
				Manager.menu.quantumConsole.LogToConsole("Base max health set to " + amount + ".");
			}
		}

		[Preserve]
		[CommandWithModSupport("resetBaseMaxHealth", "Resets base max health value", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void ResetBaseMaxHealth()
		{
			if (CanUseConsoleCommands())
			{
				PlayerController player = Manager.main.player;
				player.playerCommandSystem.DebugSetBaseMaxHealth(player.entity, 100);
				Manager.menu.quantumConsole.LogToConsole("Max base health has been reset.");
			}
		}

		[Preserve]
		[CommandWithModSupport("setMana", "Sets mana value", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void SetMana(int amount)
		{
			if (CanUseConsoleCommands())
			{
				PlayerController player = Manager.main.player;
				player.playerCommandSystem.DebugSetMana(player.entity, math.clamp(amount, 0, player.GetMaxMana()));
				Manager.menu.quantumConsole.LogToConsole("Set mana to " + math.clamp(amount, 0, player.GetMaxMana()) + ".");
			}
		}

		[Preserve]
		[CommandWithModSupport("setManaUnlimited", "Sets mana value to infinite", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void SetManaUnlimited(bool trueOrFalse)
		{
			if (CanUseConsoleCommands())
			{
				PlayerController player = Manager.main.player;
				player.playerCommandSystem.DebugSetUnlimitedMana(player.entity, trueOrFalse);
				Manager.menu.quantumConsole.LogToConsole(trueOrFalse ? (player.playerName + " now has unlimited mana.") : (player.playerName + " no longer has unlimited mana."));
			}
		}

		[Preserve]
		[CommandWithModSupport("setAllItemsInInventoryToLevel", "Sets all upgradeable items in a players' inventory to chosen level", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		public static void SetAllItemsInInventoryToLevel(int level)
		{
			if (CanUseConsoleCommands())
			{
				PlayerController player = Manager.main.player;
				player.playerCommandSystem.DebugSetAllItemsInInventoryToLevel(player, level);
				Manager.menu.quantumConsole.LogToConsole("All inventory items set to level " + level + ".");
			}
		}

		[Preserve]
		[CommandWithModSupport("clearInventory", "Clears player's inventory (true: preserve top row", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void ClearInventory(bool preserveTopRow = true)
		{
			if (!CanUseConsoleCommands())
			{
				return;
			}
			PlayerController player = Manager.main.player;
			int num = (preserveTopRow ? 10 : 0);
			int num2 = 0;
			for (int i = num; i < player.playerInventoryHandler.size; i++)
			{
				if (player.playerInventoryHandler.GetObjectData(i).objectID != ObjectID.None)
				{
					num2++;
				}
			}
			player.playerInventoryHandler.DestroyObjects(player, num, player.playerInventoryHandler.size - 1);
			Manager.menu.quantumConsole.LogToConsole("Cleared " + num2 + " items from inventory.");
		}

		[Preserve]
		[CommandWithModSupport("RepairAll", "", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		public static void RepairAll(bool reinforce = false)
		{
			if (CanUseConsoleCommands())
			{
				PlayerController player = Manager.main.player;
				player.playerCommandSystem.DebugRepairAll(player, reinforce);
				Manager.menu.quantumConsole.LogToConsole(reinforce ? "Reinforced all items." : "Repaired all items.");
			}
		}

		[Preserve]
		[CommandWithModSupport("showMeleeHitBox", "Displays player's melee weapon hit- & shader-area", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void ShowHitArea(bool showHitArea)
		{
			Manager.main.player.showHitArea = showHitArea;
			Manager.menu.quantumConsole.LogToConsole(showHitArea ? "A hit box will now be displayed when you use a melee weapon." : "Disabled melee hit box display.");
		}

		[Preserve]
		[CommandWithModSupport("killAllNearbyEnemies", "Kill all of creature type on screen", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void KillEnemies()
		{
			if (!CanUseConsoleCommands())
			{
				return;
			}
			foreach (EntityMonoBehaviour value in Manager.memory.entityMonoLookUp.Values)
			{
				if (value == null || !value.entityExist || value.objectInfo == null || value.objectInfo.objectType != ObjectType.Creature || Manager.ecs.ClientWorld.EntityManager.HasComponent<BossCD>(value.entity))
				{
					continue;
				}
				if (Manager.ecs.ClientWorld.EntityManager.HasComponent<ObjectCategoryTagsCD>(value.entity))
				{
					ObjectCategoryTagsCD componentData = Manager.ecs.ClientWorld.EntityManager.GetComponentData<ObjectCategoryTagsCD>(value.entity);
					if (!ObjectCategoryTagsCD.HasTag(componentData.tagsBitMask, ObjectCategoryTag.HostileCreature) || ObjectCategoryTagsCD.HasTag(componentData.tagsBitMask, ObjectCategoryTag.Cattle) || ObjectCategoryTagsCD.HasTag(componentData.tagsBitMask, ObjectCategoryTag.NonHostileCreature))
					{
						continue;
					}
				}
				Manager.main.player.playerCommandSystem.DebugDestroyEntity(value.entity, Manager.main.player.entity, dontDrop: true);
			}
			Manager.menu.quantumConsole.LogToConsole("Killed all nearby enemies.");
		}

		[Preserve]
		[Command("unlockAllSouls", "Unlocks all souls", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void UnlockAllSouls()
		{
			PlayerController player = Manager.main.player;
			ClientSystem playerCommandSystem = player.playerCommandSystem;
			player.CollectSoul(SoulID.SoulOfAzeos);
			playerCommandSystem.MarkEnemyAsKilled(ObjectID.BirdBoss);
			player.CollectSoul(SoulID.SoulOfOmoroth);
			playerCommandSystem.MarkEnemyAsKilled(ObjectID.OctopusBoss);
			player.CollectSoul(SoulID.SoulOfScarab);
			playerCommandSystem.MarkEnemyAsKilled(ObjectID.ScarabBoss);
			player.CollectSoul(SoulID.SoulOfNatureHydra);
			playerCommandSystem.MarkEnemyAsKilled(ObjectID.HydraBossNature);
			player.CollectSoul(SoulID.SoulOfSeaHydra);
			playerCommandSystem.MarkEnemyAsKilled(ObjectID.HydraBossSea);
			player.CollectSoul(SoulID.SoulOfDesertHydra);
			playerCommandSystem.MarkEnemyAsKilled(ObjectID.HydraBossDesert);
			player.UnlockSouls();
		}

		[Preserve]
		[CommandWithModSupport("setAllPlayersPosition", "", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		public static void SetAllPlayerPosition(Vector2 position)
		{
			if (!CanUseConsoleCommands())
			{
				return;
			}
			List<PlayerController> allPlayers = Manager.main.allPlayers;
			float3 position2 = ((float2)position).ToFloat3();
			foreach (PlayerController item in allPlayers)
			{
				item.DebugSetPlayerPosition(position2);
				Manager.menu.quantumConsole.LogToConsole("Moved " + item.playerName + " to " + position.ToString() + ".");
			}
		}

		[Preserve]
		[CommandWithModSupport("setAllPlayersInvincible", "", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		public static void SetAllPlayersInvincible(bool value)
		{
			if (!CanUseConsoleCommands())
			{
				return;
			}
			PlayerController player = Manager.main.player;
			foreach (PlayerController allPlayer in Manager.main.allPlayers)
			{
				player.playerCommandSystem.DebugSetPlayerImmuneToDamage(allPlayer.entity, value);
				Manager.menu.quantumConsole.LogToConsole(value ? (allPlayer.playerName + " is now invincible.") : (allPlayer.playerName + " is no longer invincible."));
			}
		}
	}

	[CommandPrefix("crafting.")]
	private static class Crafting
	{
		[Preserve]
		[Command("toggleCraftingMaterialsRequired", "Enables/disables the requirement of materials when crafting.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		private static void ToggleCraftingMaterialsRequired()
		{
			Manager.ui.craftingMaterialsAreNotRequired = !Manager.ui.craftingMaterialsAreNotRequired;
			if (Manager.ui.craftingMaterialsAreNotRequired)
			{
				Manager.menu.quantumConsole.LogToConsole("Crafting no longer requires materials.");
			}
			else
			{
				Manager.menu.quantumConsole.LogToConsole("Crafting now requires materials.");
			}
		}
	}

	[CommandPrefix("ui.")]
	private static class UI
	{
		[Preserve]
		[Command("toggleEnabled", "Enable/disable UI.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		public static void ToggleEnabled()
		{
			Manager.prefs.hideInGameUI = !Manager.prefs.hideInGameUI;
		}
	}

	public QuantumConsole quantumConsole;

	private string introText => "Welcome to the Pugstorm Developer Console!\n\nThis console is for testing and debugging purposes. Use it to spawn items, modify player stats, and more. Write \"help\" for more information.";

	private void OnEnable()
	{
		ObjectNameSuggestor.GetLocalizedObjectID();
		quantumConsole.OnClear += QuantumConsoleStartup;
	}

	private void Start()
	{
		QuantumConsoleStartup();
	}

	public void QuantumConsoleStartup()
	{
		GlobalCommandSuggestor.InvalidateSuggestionCache();
		quantumConsole.LogToConsole(introText);
	}

	private void OnDestroy()
	{
		quantumConsole.OnClear -= QuantumConsoleStartup;
	}

	private void RefreshConsoleSuggestions(string newLanguage)
	{
		GlobalCommandSuggestor.InvalidateSuggestionCache();
		QuantumConsoleProcessor.GenerateCommandTable(deployThread: false, forceReload: true);
	}

	public static bool CanUseConsoleCommands()
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			Manager.menu.quantumConsole.LogToConsole("You must be in a game to use this command.");
			return false;
		}
		WorldInfoSystem existingSystemManaged = Manager.ecs.ClientWorld.GetExistingSystemManaged<WorldInfoSystem>();
		if (!existingSystemManaged.WorldInfo.hostConsoleEnabled || player.adminPrivileges <= 0)
		{
			Manager.menu.quantumConsole.LogToConsole("You must have admin privileges and the host must have console commands enabled.");
			return false;
		}
		if (!existingSystemManaged.WorldInfo.consoleCommandUsedThisSession)
		{
			player.playerCommandSystem.DebugMarkConsoleCommandUsed();
		}
		return true;
	}

	[Preserve]
	[CommandWithModSupport("spawn", "Spawns any object by Object ID", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 1u)]
	public static void Spawn(ObjectID objectID, int amount = 1, int variation = 0)
	{
		PlayerController player = Manager.main.player;
		if (!CanUseConsoleCommands())
		{
			return;
		}
		if (amount <= 0)
		{
			Manager.menu.quantumConsole.LogToConsole("Amount must be greater than 0.");
			return;
		}
		ObjectInfo objectInfo = PugDatabase.GetObjectInfo(objectID, variation);
		if (ObjectIsCookedFood(objectInfo))
		{
			Manager.menu.quantumConsole.LogToConsole(PugText.ProcessText("ConsoleCommands/CannotSpawnCookedFood", new string[1] { "Items/" + objectID }, shouldLocalize: true, shouldLocalizeFormatFields: true));
			return;
		}
		if (!ObjectIsValidToSpawn(objectInfo))
		{
			Manager.menu.quantumConsole.LogToConsole($"Cannot spawn {objectID}: objects of this type cannot be spawned.");
			return;
		}
		if (!objectInfo.variationIsDynamic && objectInfo.variation != variation)
		{
			Manager.menu.quantumConsole.LogToConsole($"{objectID} has no variation {variation.ToString()}. Using default variation 0 instead.");
			variation = 0;
		}
		if (objectInfo.objectType == ObjectType.Creature)
		{
			float num = 2f;
			for (int i = 0; i < amount; i++)
			{
				Vector3 vector = new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), 0f, UnityEngine.Random.Range(-0.5f, 0.5f));
				player.playerCommandSystem.DebugCreateEntity(objectID, player.WorldPosition + player.facingDirection.vec3 * num + vector, variation);
			}
		}
		else if (objectInfo.objectType == ObjectType.NonObtainable)
		{
			float3 float5 = math.round(player.WorldPosition + player.facingDirection.vec3);
			if (PugDatabase.HasComponent<TileCD>(objectID, variation) && !PugDatabase.HasComponent<PseudoTileCD>(objectID, variation))
			{
				TileCD component = PugDatabase.GetComponent<TileCD>(objectID, variation);
				int2 bottomLeft = float5.RoundToInt2();
				if (component.tileType == TileType.water)
				{
					player.playerCommandSystem.DebugClearTile(bottomLeft, 1);
				}
				player.playerCommandSystem.DebugFillTile(component.tileType, component.tileset, bottomLeft, 1);
			}
			else
			{
				player.playerCommandSystem.DebugCreateEntity(objectID, float5, variation);
			}
		}
		else
		{
			Vector3 vector2 = new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), 0f, UnityEngine.Random.Range(-0.5f, 0.5f));
			player.playerCommandSystem.DebugCreateAndDropEntity(objectID, player.WorldPosition + vector2, amount, player.entity, variation);
		}
		Manager.menu.quantumConsole.LogToConsole($"Spawned {objectID} x{amount.ToString()}.");
	}

	[Preserve]
	[CommandWithModSupport("spawnByName", "Spawns any object by name (supports localized names, enum names, or Mod IDs)", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 1u)]
	public static void SpawnByName([ObjectName] string objectName, int amount = 1)
	{
		if (!ObjectNameSuggestor._itemTranslationToObjectID.TryGetValue(objectName, out var value) && API.Authoring != null)
		{
			try
			{
				value = API.Authoring.GetObjectID(objectName);
			}
			catch
			{
				Debug.LogError("failed to get modded object ID: " + objectName);
			}
		}
		if (value == ObjectID.None)
		{
			Manager.menu.quantumConsole.LogToConsole("Cannot spawn " + objectName + ": no object with this name exists.");
		}
		else
		{
			Spawn(value, amount);
		}
	}

	private static bool ObjectIsValidToSpawn(ObjectInfo objectInfo)
	{
		if (!ObjectIsCookedFood(objectInfo))
		{
			ObjectType objectType = objectInfo.objectType;
			return objectType == ObjectType.NonUsable || objectType == ObjectType.Eatable || objectType == ObjectType.MeleeWeapon || objectType == ObjectType.MiningPick || objectType == ObjectType.Sledge || objectType == ObjectType.DrillTool || objectType == ObjectType.BeamWeapon || objectType == ObjectType.PlaceablePrefab || objectType == ObjectType.Critter || objectType == ObjectType.Pet || objectType == ObjectType.Shovel || objectType == ObjectType.Hoe || objectType == ObjectType.WaterCan || objectType == ObjectType.Bucket || objectType == ObjectType.PaintTool || objectType == ObjectType.FishingRod || objectType == ObjectType.BugNet || objectType == ObjectType.Creature || objectType == ObjectType.Helm || objectType == ObjectType.BreastArmor || objectType == ObjectType.PantsArmor || objectType == ObjectType.Necklace || objectType == ObjectType.RangeWeapon || objectType == ObjectType.ThrowingWeapon || objectType == ObjectType.SummoningWeapon || objectType == ObjectType.Ring || objectType == ObjectType.Offhand || objectType == ObjectType.Bag || objectType == ObjectType.Pouch || objectType == ObjectType.Lantern || objectType == ObjectType.CastingItem || objectType == ObjectType.NonObtainable || objectType == ObjectType.Valuable || objectType == ObjectType.UniqueCraftingComponent || objectType == ObjectType.KeyItem || objectType == ObjectType.Instrument || objectType == ObjectType.Seeder || objectType == ObjectType.RoofingTool;
		}
		return false;
	}

	[Preserve]
	[CommandWithModSupport("spawnTile", "Fills an area in front of the player with tiles.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void SpawnTile(TileType tileType, int radius = 1, bool clearExisting = false, Tileset tileset = Tileset.Dirt)
	{
		if (!CanUseConsoleCommands())
		{
			return;
		}
		PlayerController player = Manager.main.player;
		if (!(player == null))
		{
			int2 size = radius * 2 + 1;
			int2 bottomLeft = math.round(player.WorldPosition + player.facingDirection.vec3 * (radius + 1)).RoundToInt2() - radius;
			if (clearExisting)
			{
				player.playerCommandSystem.DebugClearTile(bottomLeft, size);
			}
			player.playerCommandSystem.DebugFillTile(tileType, (int)tileset, bottomLeft, size);
			Manager.menu.quantumConsole.LogToConsole("Spawned " + tileType.ToString() + ", " + size.x * size.y);
		}
	}

	[Preserve]
	[CommandWithModSupport("spawnInGrid", "Spawns items in a grid pattern in front of the player.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void SpawnInGrid(ObjectID objectID, int rows, int columns, int spacing = 1, int variation = 0)
	{
		if (!CanUseConsoleCommands())
		{
			return;
		}
		PlayerController player = Manager.main.player;
		ObjectInfo objectInfo = PugDatabase.GetObjectInfo(objectID, variation);
		if (ObjectIsCookedFood(objectInfo))
		{
			Manager.menu.quantumConsole.LogToConsole($"Cannot spawn {objectID}: cooked food must be created through the cooking pot.");
			return;
		}
		if (!ObjectIsValidToSpawn(objectInfo))
		{
			Manager.menu.quantumConsole.LogToConsole($"Cannot spawn {objectID}: objects of this type cannot be spawned.");
			return;
		}
		Vector3 vec = player.facingDirection.vec3;
		Vector3 normalized = Vector3.Cross(Vector3.up, vec).normalized;
		Vector2Int vector2Int = objectInfo.prefabTileSize + Vector2Int.one * spacing;
		Vector3 vector = player.WorldPosition + vec * ((float)vector2Int.y / 2f) - normalized * ((float)((columns - 1) * vector2Int.x) / 2f);
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < columns; j++)
			{
				Vector3 vector2 = vector + vec * (i * vector2Int.y) + normalized * (j * vector2Int.x);
				player.playerCommandSystem.DebugCreateEntity(objectID, vector2, variation);
			}
		}
		Manager.menu.quantumConsole.LogToConsole($"Spawned {objectID}, {(rows * columns).ToString()}.");
	}

	private static bool ObjectIsCookedFood(ObjectInfo objectInfo)
	{
		if (objectInfo.objectID >= ObjectID.CookedSoup)
		{
			return objectInfo.objectID < ObjectID.CavelingBread;
		}
		return false;
	}

	[Preserve]
	[CommandWithModSupport("setLighting", "Toggle lighting on/off for the game camera", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	private void Unlit()
	{
		PugCamera pugCamera = Manager.camera.gameCamera.GetPugCamera();
		if ((bool)pugCamera)
		{
			pugCamera.unlitDeferredPass = !pugCamera.unlitDeferredPass;
		}
	}

	[Preserve]
	[CommandWithModSupport("triggerEnvironmentEvent", "Attempts to start an event given its id.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void TriggerEnvironmentEvent(EnvironmentEventType eventType, bool bypassRequirements)
	{
		if (CanUseConsoleCommands())
		{
			Manager.main.player.playerCommandSystem.TriggerEnvironmentEvent(eventType, bypassRequirements);
		}
	}

	[Preserve]
	[CommandWithModSupport("listAllEnvironmentEvents", "Lists all available environment events that can be triggered.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void ListAllEnvironmentEvents()
	{
		string text = "";
		EnvironmentEventType[] array = (EnvironmentEventType[])Enum.GetValues(typeof(EnvironmentEventType));
		for (int i = 1; i < array.Length; i++)
		{
			text = text + i + ": " + array[i].ToString() + "\n";
		}
		Manager.menu.quantumConsole.LogToConsole(text);
	}

	[Preserve]
	[Command("SetTimeScale", "Set time scale. Will not work correctly in multiplayer sessions.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public void SetTimeScale(float timeScale)
	{
		Time.timeScale = timeScale;
	}

	[Preserve]
	[Command("ToggleMeshJob", "Toggles should the mesh creation use jobs or not. Mainly to test PS job issues.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public void ToggleMeshJob()
	{
		PugMapLayer2.UseJobs = !PugMapLayer2.UseJobs;
		Debug.Log("Mesh Jobs: " + (PugMapLayer2.UseJobs ? "on" : "off"));
	}

	[Preserve]
	[Command("markEnemyAsKilled", "Marks enemy as killed", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	private void MarkEnemyAsKilled(ObjectID objectID)
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			quantumConsole.LogToConsole("No player");
		}
		else
		{
			player.playerCommandSystem.MarkEnemyAsKilled(objectID);
		}
	}

	[Preserve]
	[Command("toggleEnemyBehaviour", "Enable/disable enemy AI", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	private void ToggleEnemyBehaviour()
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			quantumConsole.LogToConsole("No player");
			return;
		}
		Manager.prefs.enemiesDisabled = !Manager.prefs.enemiesDisabled;
		player.playerCommandSystem.DebugToggleEnemyBehaviour();
	}

	[Preserve]
	[Command("toggleForceLightFallbacks", "Force usage of fallback light renderers", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	private void ToggleForceLightFallbacks()
	{
		ManagedLight.forceFallbacks = !ManagedLight.forceFallbacks;
	}

	[Preserve]
	[Command("killAllCritters", "Kill all of crit type around player", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	private void KillCritters()
	{
		if (Manager.main.player == null)
		{
			quantumConsole.LogToConsole("No player");
			return;
		}
		foreach (EntityMonoBehaviour value in Manager.memory.entityMonoLookUp.Values)
		{
			if (!(value == null) && value.entityExist && value.objectInfo != null && value.objectInfo.objectType == ObjectType.Critter)
			{
				Manager.main.player.playerCommandSystem.DebugDestroyEntity(value.entity, Manager.main.player.entity, dontDrop: true);
			}
		}
	}

	[Preserve]
	[Command("saveEnabled", "Enable/disable saving", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	private void SaveEnabled(bool trueOrFalse)
	{
		Manager.prefs.saveEnabled = trueOrFalse;
	}

	[Preserve]
	[Command("dumpMapLightData", "", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	private static void DumpMapLightData()
	{
		MapUpdateSystem.shouldDumpMapLightData = true;
	}

	[Preserve]
	[Command("showMapLightData", "", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	private static void ShowMapLightData()
	{
		MapUpdateSystem.showMapLightDebugTexture = !MapUpdateSystem.showMapLightDebugTexture;
		_ = MapUpdateSystem.showMapLightDebugTexture;
	}

	[Preserve]
	[Command("select", "", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	private static void Select(string name)
	{
	}

	[Preserve]
	[Command("achievement.list", "List all achievements.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	private string ListAchievements()
	{
		string[] names = Enum.GetNames(typeof(AchievementID));
		StringBuilder stringBuilder = new StringBuilder();
		string[] array = names;
		foreach (string value in array)
		{
			stringBuilder.Append(value);
			stringBuilder.Append('\n');
		}
		return stringBuilder.ToString();
	}

	[Preserve]
	[Command("achievement.trigger", "Triggers an achievement.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	private void TriggerAchievemnt(AchievementID achievement)
	{
		Manager.achievements.TriggerAchievement(achievement);
	}

	[Preserve]
	[Command("achievement.clearAll", "Clears all achievements so they can be triggered again.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	private void ClearAllAchievements()
	{
		Manager.achievements.ClearTriggeredAchievements();
		Manager.platform.ClearAllAchievements();
	}

	[Preserve]
	[Command("map.clear", "Clear the player's discovered map", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	private void ClearMap()
	{
		Manager.ui.mapUI.Clear(clearSavedData: true);
	}

	[Preserve]
	[Command("map.clearCartography", "Clear the shared cartography map (can only be called by host).", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	private void ClearCartographyMap()
	{
		if (Manager.ecs.ServerWorld == null)
		{
			quantumConsole.LogToConsole("Can only clear cartography data on host");
		}
		else
		{
			Manager.ecs.ServerWorld.GetExistingSystemManaged<ShareMapServerSystem>().Clear();
		}
	}

	[Preserve]
	[Command("LoadBenchmarkScene", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	private void LoadBenchmarkScene()
	{
		Manager.load.LoadBenchmarkScene();
	}

	[Preserve]
	[Command("resetPrefs", "Resets user preferences to defaults.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	private void ResetUserPrefs()
	{
		if (!(Manager.prefs == null))
		{
			Manager.prefs.ResetToDefaults();
		}
	}

	[Preserve]
	[Command("network.setRates", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	private void SetNetworkTickRatesCheat(int simulationRate, int networkSendRate)
	{
		if (Manager.ecs.ServerWorld != null)
		{
			Manager.networking.SetNetworkTickRates(Manager.ecs.ServerWorld, simulationRate, networkSendRate);
		}
		if (Manager.ecs.ClientWorld != null)
		{
			Manager.networking.SetNetworkTickRates(Manager.ecs.ClientWorld, simulationRate, networkSendRate);
		}
	}
}
