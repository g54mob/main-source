#define PUG_ACHIEVEMENTS
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Entities;
using Unity.Profiling;
using UnityEngine;

public class AchievementsManager : ManagerBase
{
	public class PreviousEquipmentTracker
	{
		public ObjectID previousEquipment;

		public InventoryHandler handler;

		public PreviousEquipmentTracker(ObjectID _previousEquipment, InventoryHandler _handler)
		{
			previousEquipment = _previousEquipment;
			handler = _handler;
		}
	}

	public class ItemAchievement
	{
		public ObjectID objectId;

		public AchievementID achievementId;

		public ItemAchievement(ObjectID _objectId, AchievementID _achievementId)
		{
			objectId = _objectId;
			achievementId = _achievementId;
		}
	}

	private readonly List<ItemAchievement> itemAchievements = new List<ItemAchievement>
	{
		new ItemAchievement(ObjectID.OracleDeck, AchievementID.ObtainTheOracleDeck),
		new ItemAchievement(ObjectID.LegendarySword, AchievementID.ObtainRuneSong),
		new ItemAchievement(ObjectID.LegendaryBow, AchievementID.ObtainPhantomSpark),
		new ItemAchievement(ObjectID.LegendaryMiningPick, AchievementID.ObtainSoulSeeker),
		new ItemAchievement(ObjectID.LightningGun, AchievementID.ObtainStormbringer),
		new ItemAchievement(ObjectID.LegendaryStaff, AchievementID.ObtainTitanBreath),
		new ItemAchievement(ObjectID.LegendaryMortar, AchievementID.ObtainCredenceOfRuin)
	};

	private string[] achievementNames;

	private bool hasSatOnToiletWithCrown;

	private bool hasAchieved200MovementSpeed;

	private HashSet<AchievementID> triggeredAchievementIDsSet = new HashSet<AchievementID>();

	private AchievementsMapper achievementsMapper;

	private List<PreviousEquipmentTracker> previousEquipments;

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("AchievementsManager.Init");

	public AchievementsMapper AchievementsMapper
	{
		get
		{
			if (!(achievementsMapper != null))
			{
				return LoadAchievementMapper();
			}
			return achievementsMapper;
		}
	}

	public string[] AchievementNames => achievementNames;

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			achievementNames = Enum.GetNames(typeof(AchievementID));
			return true;
		}
	}

	public bool HasTriggeredAchievement(AchievementID achievementID)
	{
		return triggeredAchievementIDsSet.Contains(achievementID);
	}

	public void ClearTriggeredAchievements()
	{
		triggeredAchievementIDsSet.Clear();
	}

	private AchievementsMapper LoadAchievementMapper()
	{
		achievementsMapper = Resources.Load<AchievementsMapper>("AchievementsMapper");
		return achievementsMapper;
	}

	[Conditional("PUG_ACHIEVEMENTS")]
	public void TriggerAchievement(AchievementID id)
	{
		TriggerAchievement(id, Entity.Null);
	}

	[Conditional("PUG_ACHIEVEMENTS")]
	public void TriggerAchievement(AchievementID id, Entity playerEntity)
	{
		if (Manager.saves.IsCreativeModeCharacter())
		{
			return;
		}
		if (Manager.ecs.ClientWorld != null)
		{
			WorldInfoSystem existingSystemManaged = Manager.ecs.ClientWorld.GetExistingSystemManaged<WorldInfoSystem>();
			if (existingSystemManaged != null && existingSystemManaged.WorldInfo.consoleCommandUsedThisSession)
			{
				return;
			}
		}
		if (!achievementsMapper)
		{
			LoadAchievementMapper();
		}
		if (id == AchievementID.None)
		{
			UnityEngine.Debug.LogError("Tried to trigger \"None\" achievement");
		}
		else if (achievementNames == null)
		{
			UnityEngine.Debug.LogError("achivementNames not initialized");
		}
		else if (!(playerEntity != Entity.Null) || !(Manager.main.player != null) || !(Manager.main.player.entity != playerEntity))
		{
			triggeredAchievementIDsSet.Add(id);
			AchievementData achievementData = achievementsMapper.GetAchievementData(id);
			Manager.platform.TriggerAchievement(achievementData);
		}
	}

	[Conditional("PUG_ACHIEVEMENTS")]
	public void CheckAndTriggerAchievementsOnInit(PlayerController player)
	{
		hasAchieved200MovementSpeed = false;
		hasSatOnToiletWithCrown = false;
		CheckAndTriggerAllSkillAchievements();
		CheckAndTriggerAnyObtainedItemAchievements();
		InitialCheckAndTriggerAnyEquipmentAchievement(player);
	}

	[Conditional("PUG_ACHIEVEMENTS")]
	public void CheckAndTriggerAchievements(PlayerController player)
	{
		CheckAndTriggerAnyEquipmentAchievement(player);
		CheckAndTriggerAllConditionsAchievements(player);
		CheckAndTriggerAllContextualAchievements(player);
	}

	private void CheckAndTriggerAllContextualAchievements(PlayerController player)
	{
		if (!hasSatOnToiletWithCrown && EntityUtility.TryGetComponentData<ControllingOtherEntityCD>(player.entity, player.world, out var value) && EntityUtility.TryGetComponentData<ObjectDataCD>(value.controlledEntity, player.world, out var value2) && value2.objectID == ObjectID.CavelingToilet && player.equipmentHandler.helmInventoryHandler.GetObjectData(0).objectID == ObjectID.KingSlimeCrown)
		{
			Manager.achievements.TriggerAchievement(AchievementID.SitOnCavelingToiletWithACrown);
			hasSatOnToiletWithCrown = true;
		}
	}

	private void CheckAndTriggerAllConditionsAchievements(PlayerController player)
	{
		if (!hasAchieved200MovementSpeed && EntityUtility.GetConditionEffectValue(ConditionEffect.MovementSpeed, player.entity, player.world) > 1000)
		{
			Manager.achievements.TriggerAchievement(AchievementID.GainOver200MovementSpeed);
			hasAchieved200MovementSpeed = true;
		}
	}

	private void CheckAndTriggerAllSkillAchievements()
	{
		for (int i = 0; i < 12; i++)
		{
			SkillID skillID = (SkillID)i;
			int skillValue = Manager.saves.GetSkillValue(skillID);
			CheckAndTriggerSkillAchievement(skillID, skillValue);
		}
	}

	[Conditional("PUG_ACHIEVEMENTS")]
	public void CheckAndTriggerSkillAchievement(SkillID skillID, int skillValue)
	{
		if (SkillExtensions.GetLevelFromSkill(skillID, skillValue) >= 100)
		{
			switch (skillID)
			{
			case SkillID.Mining:
				Manager.achievements.TriggerAchievement(AchievementID.MaxedOutMining);
				break;
			case SkillID.Running:
				Manager.achievements.TriggerAchievement(AchievementID.MaxedOutRunning);
				break;
			case SkillID.Melee:
				Manager.achievements.TriggerAchievement(AchievementID.MaxedOutMelee);
				break;
			case SkillID.Vitality:
				Manager.achievements.TriggerAchievement(AchievementID.MaxedOutVitality);
				break;
			case SkillID.Crafting:
				Manager.achievements.TriggerAchievement(AchievementID.MaxedOutCrafting);
				break;
			case SkillID.Range:
				Manager.achievements.TriggerAchievement(AchievementID.MaxedOutRange);
				break;
			case SkillID.Gardening:
				Manager.achievements.TriggerAchievement(AchievementID.MaxedOutGardening);
				break;
			case SkillID.Fishing:
				Manager.achievements.TriggerAchievement(AchievementID.MaxedOutFishing);
				break;
			case SkillID.Cooking:
				Manager.achievements.TriggerAchievement(AchievementID.MaxedOutCooking);
				break;
			case SkillID.Magic:
				Manager.achievements.TriggerAchievement(AchievementID.MaxedOutMagic);
				break;
			case SkillID.Summoning:
				Manager.achievements.TriggerAchievement(AchievementID.MaxedOutSummoning);
				break;
			case SkillID.Explosives:
				Manager.achievements.TriggerAchievement(AchievementID.MaxedOutExplosives);
				break;
			}
		}
	}

	private void CheckAndTriggerAnyObtainedItemAchievements()
	{
		foreach (ItemAchievement itemAchievement in itemAchievements)
		{
			if (Manager.saves.HasDiscoveredObject(itemAchievement.objectId))
			{
				Manager.achievements.TriggerAchievement(itemAchievement.achievementId);
			}
		}
	}

	[Conditional("PUG_ACHIEVEMENTS")]
	public void TriggerAnyAchievementForObtainingAnItem(ObjectID objectId)
	{
		foreach (ItemAchievement itemAchievement in itemAchievements)
		{
			if (objectId == itemAchievement.objectId)
			{
				Manager.achievements.TriggerAchievement(itemAchievement.achievementId);
			}
		}
	}

	[Conditional("PUG_ACHIEVEMENTS")]
	public void InitialCheckAndTriggerAnyEquipmentAchievement(PlayerController player)
	{
		previousEquipments = new List<PreviousEquipmentTracker>();
		previousEquipments.Add(new PreviousEquipmentTracker(ObjectID.None, player.equipmentHandler.helmInventoryHandler));
		previousEquipments.Add(new PreviousEquipmentTracker(ObjectID.None, player.equipmentHandler.breastInventoryHandler));
		previousEquipments.Add(new PreviousEquipmentTracker(ObjectID.None, player.equipmentHandler.pantsInventoryHandler));
		previousEquipments.Add(new PreviousEquipmentTracker(ObjectID.None, player.equipmentHandler.necklaceInventoryHandler));
		previousEquipments.Add(new PreviousEquipmentTracker(ObjectID.None, player.equipmentHandler.ring1InventoryHandler));
		previousEquipments.Add(new PreviousEquipmentTracker(ObjectID.None, player.equipmentHandler.ring2InventoryHandler));
		previousEquipments.Add(new PreviousEquipmentTracker(ObjectID.None, player.equipmentHandler.offHandInventoryHandler));
		previousEquipments.Add(new PreviousEquipmentTracker(ObjectID.None, player.equipmentHandler.bagInventoryHandler));
		previousEquipments.Add(new PreviousEquipmentTracker(ObjectID.None, player.equipmentHandler.petInventoryHandler));
		previousEquipments.Add(new PreviousEquipmentTracker(ObjectID.None, player.equipmentHandler.lanternInventoryHandler));
		for (int i = 0; i < 4; i++)
		{
			previousEquipments.Add(new PreviousEquipmentTracker(ObjectID.None, player.equipmentHandler.pouchInventoryHandlers[i]));
		}
		CheckAndTriggerAnyEquipmentAchievement(player);
	}

	[Conditional("PUG_ACHIEVEMENTS")]
	public void CheckAndTriggerAnyEquipmentAchievement(PlayerController player)
	{
		if (!player.isLocal)
		{
			return;
		}
		bool flag = false;
		foreach (PreviousEquipmentTracker previousEquipment in previousEquipments)
		{
			ObjectID objectID = previousEquipment.handler.GetObjectData(0).objectID;
			if (previousEquipment.previousEquipment != objectID)
			{
				previousEquipment.previousEquipment = objectID;
				flag = true;
			}
		}
		if (flag)
		{
			CheckAndTriggerRingOfRockAndStoneAchievement(player);
		}
	}

	private void CheckAndTriggerRingOfRockAndStoneAchievement(PlayerController player)
	{
		ObjectID objectID = player.equipmentHandler.ring1InventoryHandler.GetObjectData(0).objectID;
		ObjectID objectID2 = player.equipmentHandler.ring2InventoryHandler.GetObjectData(0).objectID;
		if ((objectID == ObjectID.RingOfRock && objectID2 == ObjectID.RingOfStone) || (objectID == ObjectID.RingOfStone && objectID2 == ObjectID.RingOfRock))
		{
			Manager.achievements.TriggerAchievement(AchievementID.EquipRingOfRockAndStone);
		}
	}

	public void InitializeAchievements()
	{
		Manager.platform.platformImpl.InitializeAchievements();
	}
}
