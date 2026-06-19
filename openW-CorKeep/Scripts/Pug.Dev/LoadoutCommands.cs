using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using Pug.UnityExtensions;
using QFSW.QC;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Scripting;

public class LoadoutCommands : MonoBehaviour
{
	[Serializable]
	public class Loadout
	{
		[Serializable]
		public struct LoadoutItem
		{
			public ObjectID id;

			public int amount;
		}

		public string name;

		[ArrayElementTitle("id, amount")]
		public List<LoadoutItem> items = new List<LoadoutItem>();

		public List<SoulID> souls = new List<SoulID>();

		public int skillsLevel;

		public List<ObjectID> permanentHealthItems = new List<ObjectID>();

		public List<CharacterRole> foodForRole;
	}

	private struct SpawnIntoSlot
	{
		public ObjectID Id;

		public int Amount;

		public int Slot;
	}

	[Serializable]
	public class RoleFood
	{
		[Serializable]
		public struct FoodIngredients
		{
			public ObjectID ingridientOne;

			public ObjectID ingridientTwo;
		}

		public CharacterRole role;

		public List<FoodIngredients> foodByIngredients;
	}

	public QuantumConsole quantumConsole;

	public ConditionsTable conditionsTable;

	[ArrayElementTitle("name")]
	public List<Loadout> loadouts = new List<Loadout>();

	public List<RoleFood> roleFoods = new List<RoleFood>();

	[Preserve]
	[Command("equipLoadout", "Spawns and equips a predefined loadout", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public void LoadoutCommand([LoadoutName] string loadoutName, int gearLevel = 0)
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			quantumConsole.LogToConsole("Loadout setup failed: not in game");
			return;
		}
		Loadout loadout = loadouts.Find((Loadout l) => l.name.Equals(loadoutName, StringComparison.OrdinalIgnoreCase));
		if (loadout == null)
		{
			quantumConsole.LogToConsole("Loadout '" + loadoutName + "' not found");
		}
		else
		{
			StartCoroutine(SetupLoadout(player, loadout, gearLevel));
		}
	}

	private IEnumerator SetupLoadout(PlayerController player, Loadout loadout, int gearLevel)
	{
		List<SpawnIntoSlot> spawnIntoSlot = new List<SpawnIntoSlot>();
		EquipmentCD componentData = EntityUtility.GetComponentData<EquipmentCD>(player.entity, Manager.ecs.ClientWorld);
		int num = 0;
		int num2 = 0;
		HashSet<int> hashSet = new HashSet<int>();
		foreach (Loadout.LoadoutItem item in loadout.items)
		{
			if (item.amount <= 0)
			{
				Debug.LogWarning($"Skip spawn of {item.id} with amount {item.amount}");
				continue;
			}
			ObjectInfo objectInfo = PugDatabase.GetObjectInfo(item.id);
			int num3 = objectInfo.objectType switch
			{
				ObjectType.Helm => componentData.helmSlotIndex, 
				ObjectType.BreastArmor => componentData.breastSlotIndex, 
				ObjectType.PantsArmor => componentData.pantsSlotIndex, 
				ObjectType.Necklace => componentData.necklaceSlotIndex, 
				ObjectType.Lantern => componentData.lanternIndex, 
				ObjectType.Pet => EntityUtility.GetComponentData<PetOwnerCD>(player.entity, Manager.ecs.ClientWorld).SlotIndex, 
				ObjectType.Bag => componentData.bagIndex, 
				ObjectType.Offhand => componentData.offHandIndex, 
				ObjectType.Ring => (num++ == 0) ? componentData.ring1SlotIndex : componentData.ring2SlotIndex, 
				ObjectType.MeleeWeapon => 0, 
				ObjectType.RangeWeapon => 1, 
				ObjectType.Eatable => 2 + num2++, 
				_ => -1, 
			};
			if (hashSet.Contains(num3))
			{
				num3 = -1;
			}
			int num4 = 0;
			if (num3 >= 0)
			{
				hashSet.Add(num3);
				num4 = ((!objectInfo.isStackable) ? 1 : item.amount);
				spawnIntoSlot.Add(new SpawnIntoSlot
				{
					Id = item.id,
					Amount = num4,
					Slot = num3
				});
			}
			if (item.amount > num4)
			{
				spawnIntoSlot.Add(new SpawnIntoSlot
				{
					Id = item.id,
					Amount = item.amount - num4,
					Slot = -1
				});
			}
		}
		foreach (SpawnIntoSlot item2 in spawnIntoSlot)
		{
			if (item2.Slot >= 0)
			{
				ObjectID objectID = player.playerInventoryHandler.GetObjectData(item2.Slot).objectID;
				if (objectID != ObjectID.None)
				{
					quantumConsole.LogToConsole($"Destroy {objectID} in slot {item2.Slot}");
					player.playerInventoryHandler.DestroyObject(player, item2.Slot, objectID);
					yield return new WaitForSeconds(0.1f);
				}
			}
		}
		yield return new WaitForSeconds(0.2f);
		PugDatabase.DatabaseBankCD singleton = Manager.main.player.querySystem.GetSingleton<PugDatabase.DatabaseBankCD>();
		BufferLookup<LevelEntitiesBuffer> bufferLookup = Manager.main.player.querySystem.GetBufferLookup<LevelEntitiesBuffer>(isReadOnly: true);
		ComponentLookup<ObjectCategoryTagsCD> componentLookup = Manager.main.player.querySystem.GetComponentLookup<ObjectCategoryTagsCD>(isReadOnly: true);
		foreach (SpawnIntoSlot item3 in spawnIntoSlot)
		{
			int variation = 0;
			if (gearLevel > 0)
			{
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(item3.Id, singleton.databaseBankBlob);
				if (InventoryUtility.CanBeUpgraded(bufferLookup, componentLookup, primaryPrefabEntity))
				{
					int maxLevel = LevelScaling.GetMaxLevel();
					variation = math.clamp(gearLevel, 0, maxLevel);
				}
			}
			if (item3.Slot >= 0)
			{
				player.playerCommandSystem.CreateItem(player.entity, item3.Slot, item3.Id, item3.Amount, player.WorldPosition, variation);
				quantumConsole.LogToConsole($"Equip {item3.Id} in slot {item3.Slot}");
			}
			else
			{
				player.playerCommandSystem.CreateAndDropEntity(item3.Id, player.WorldPosition, item3.Amount, player.entity, variation);
				quantumConsole.LogToConsole($"Drop {item3.Id} x{item3.Amount}");
			}
		}
		player.UnlockSouls();
		foreach (SoulID soul in loadout.souls)
		{
			player.CollectSoul(soul);
			quantumConsole.LogToConsole($"Collect soul {soul}");
		}
		player.SetAllSkills(loadout.skillsLevel);
		quantumConsole.LogToConsole($"Set all skills to {loadout.skillsLevel}");
		foreach (ObjectID permanentHealthItem in loadout.permanentHealthItems)
		{
			if (!TryGetMaxHealthCondition(permanentHealthItem, out var healthIncreasingCondition))
			{
				Debug.LogWarning($"{permanentHealthItem} does not give max health, drop as item instead");
				player.playerCommandSystem.CreateAndDropEntity(permanentHealthItem, player.WorldPosition, 1, player.entity);
				quantumConsole.LogToConsole($"Drop {permanentHealthItem} x1");
			}
			else
			{
				quantumConsole.LogToConsole($"Consume permahealth item {permanentHealthItem} (+{healthIncreasingCondition.value} max health)");
				player.playerCommandSystem.AddOrRefreshCondition(player.entity, healthIncreasingCondition.conditionID, healthIncreasingCondition.value, 0f);
			}
		}
		ComponentLookup<CookingIngredientCD> componentLookup2 = Manager.main.player.querySystem.GetComponentLookup<CookingIngredientCD>();
		foreach (CharacterRole item4 in loadout.foodForRole)
		{
			foreach (RoleFood roleFood in roleFoods)
			{
				if (item4 != roleFood.role)
				{
					continue;
				}
				foreach (RoleFood.FoodIngredients foodByIngredient in roleFood.foodByIngredients)
				{
					ObjectID ingridientOne = foodByIngredient.ingridientOne;
					ObjectID ingridientTwo = foodByIngredient.ingridientTwo;
					Entity primaryPrefabEntity2 = PugDatabase.GetPrimaryPrefabEntity(CookedFoodCD.GetPrimaryIngredient(ingridientOne, ingridientTwo), singleton.databaseBankBlob);
					int foodVariation = CookedFoodCD.GetFoodVariation(ingridientOne, ingridientTwo);
					ObjectID turnsIntoFood = componentLookup2[primaryPrefabEntity2].turnsIntoFood;
					int num5 = 999;
					player.playerCommandSystem.CreateAndDropEntity(turnsIntoFood, player.WorldPosition, num5, player.entity, foodVariation);
					quantumConsole.LogToConsole($"Drop {turnsIntoFood} x{num5}");
				}
			}
		}
	}

	private bool TryGetMaxHealthCondition(ObjectID healthItem, out ConditionData healthIncreasingCondition)
	{
		healthIncreasingCondition = default(ConditionData);
		DynamicBuffer<GivesConditionsWhenConsumedBuffer> buffer = PugDatabase.GetBuffer<GivesConditionsWhenConsumedBuffer>(healthItem);
		if (!buffer.IsCreated)
		{
			Debug.LogWarning($"{healthItem} does not have conditions buffer");
			return false;
		}
		foreach (GivesConditionsWhenConsumedBuffer item in buffer)
		{
			if (TryGetMaxHealthContribution(item.conditionDataContainer.conditionData, out var healthIncrease))
			{
				healthIncreasingCondition = item.conditionDataContainer.conditionData;
				return true;
			}
			if (TryGetMaxHealthContribution(item.conditionDataContainer.conditionDataWhenCooked, out healthIncrease))
			{
				healthIncreasingCondition = item.conditionDataContainer.conditionDataWhenCooked;
				return true;
			}
		}
		Debug.LogWarning($"{healthItem} does not give max health");
		return false;
	}

	private bool TryGetMaxHealthContribution(ConditionData condition, out int healthIncrease)
	{
		healthIncrease = ((conditionsTable.GetConditionInfo(condition.conditionID).effect == ConditionEffect.MaxHealthPermanent) ? condition.value : 0);
		return healthIncrease > 0;
	}
}
