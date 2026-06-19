using System;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[Serializable]
public class CharacterData : ISerializationCallbackReceiver
{
	public struct NonSerialized
	{
		public HashSet<DiscoveredObjectData> discoveredObjects;

		public List<DiscoveredObjectData> cookedFoods;
	}

	public const int CURRENT_VERSION = 15;

	public int version;

	public string characterGuid;

	[SerializeField]
	private PlayerCustomizationOld characterCustomization;

	[SerializeField]
	private PlayerCustomization characterCustomizationNew;

	public List<int> discoveredObjects = new List<int>();

	public List<ServerData> servers = new List<ServerData>();

	public List<SkillData> skills = new List<SkillData>();

	public List<ObjectID> activatedCrystals = new List<ObjectID>();

	public List<ObjectDataCD> inventory = new List<ObjectDataCD>();

	public List<string> inventoryObjectNames = new List<string>();

	public List<CharacterInventoryAuxData> inventoryAuxData = new List<CharacterInventoryAuxData>();

	public List<bool> lockedObjects = new List<bool>();

	public List<ConditionSerialized> conditionsList = new List<ConditionSerialized>();

	public bool hasUnlockedSouls;

	public int coinAmount;

	public List<SoulID> collectedSouls = new List<SoulID>();

	public int maxHealth;

	public int serverConnectCount;

	public List<SkillTalentTreeData> skillTalentTreeDatas = new List<SkillTalentTreeData>();

	public CharacterType characterType;

	public List<Biome> discoveredBiomes = new List<Biome>();

	public List<DiscoveredObjectData> discoveredObjects2 = new List<DiscoveredObjectData>();

	public List<SoulID> disabledSoulPowers = new List<SoulID>();

	public bool hasPlayedOutro;

	public List<TutorialID> completedTutorials = new List<TutorialID>();

	public Unity.Entities.Hash128 lastActiveSession;

	[NonSerialized]
	public NonSerialized nonSerialized = new NonSerialized
	{
		discoveredObjects = new HashSet<DiscoveredObjectData>(),
		cookedFoods = new List<DiscoveredObjectData>()
	};

	public PlayerCustomization CharacterCustomization
	{
		get
		{
			return characterCustomizationNew;
		}
		set
		{
			characterCustomizationNew = value;
		}
	}

	public void OnBeforeSerialize()
	{
		discoveredObjects2.Clear();
		foreach (DiscoveredObjectData discoveredObject in nonSerialized.discoveredObjects)
		{
			discoveredObjects2.Add(discoveredObject);
		}
	}

	private static DiscoveredObjectData ConvertOldDiscoveredObjectData(int serializedValue)
	{
		int variation = serializedValue % 16384;
		ObjectID objectID = (ObjectID)(serializedValue / 16384);
		return new DiscoveredObjectData
		{
			objectID = objectID,
			variation = variation
		};
	}

	public void OnAfterDeserialize()
	{
		foreach (int discoveredObject in discoveredObjects)
		{
			discoveredObjects2.Add(ConvertOldDiscoveredObjectData(discoveredObject));
		}
		discoveredObjects.Clear();
		if (version < 7)
		{
			Debug.Log($"Upgrading character {characterGuid} from version {version} to 7");
			for (int i = 0; i < discoveredObjects2.Count; i++)
			{
				DiscoveredObjectData value = discoveredObjects2[i];
				if (value.objectID.IsCookedFood())
				{
					value.variation = CookedFoodCD.ConvertOldVariationEncoding(value.variation);
					discoveredObjects2[i] = value;
				}
			}
			version = 7;
		}
		if (version < 8)
		{
			Debug.Log($"Upgrading character {characterGuid} from version {version} to 8");
			for (int j = 0; j < inventory.Count; j++)
			{
				ObjectDataCD value2 = inventory[j];
				if (value2.objectID.IsCookedFood())
				{
					value2.variation = CookedFoodCD.ConvertOldVariationEncoding(value2.variation);
					inventory[j] = value2;
				}
			}
			version = 8;
		}
		if (version < 9)
		{
			Debug.Log($"Upgrading character {characterGuid} from version {version} to 9");
			version = 9;
		}
		if (version < 10)
		{
			Debug.Log($"Upgrading character {characterGuid} from version {version} to 10");
			version = 10;
		}
		if (version < 11)
		{
			for (int k = 0; k < inventory.Count; k++)
			{
				ObjectDataCD value3 = inventory[k];
				if (value3.objectID == ObjectID.AbyssTree)
				{
					value3.objectID = ObjectID.Stalagmite;
					value3.variation = 2;
					inventory[k] = value3;
					Debug.Log($"Replaced AbyssTree in inventory slot {k} with Stalagmite variation 2.");
				}
			}
			for (int num = discoveredObjects2.Count - 1; num >= 0; num--)
			{
				if (discoveredObjects2[num].objectID == ObjectID.AbyssTree)
				{
					discoveredObjects2.RemoveAt(num);
				}
			}
			version = 11;
		}
		if (version < 12)
		{
			Debug.Log($"Upgrading character {characterGuid} from version {version} to 12");
			version = 12;
		}
		if (version < 13)
		{
			Debug.Log($"Upgrading character {characterGuid} from version {version} to 13: fixing swapped pet talents");
			FixSwappedPetTalents();
			version = 13;
		}
		if (version < 14)
		{
			Debug.Log($"Upgrading character {characterGuid} from version {version} to 14: converting player customization to new format");
			characterCustomizationNew = ConvertOldPlayerCustomizationToNew(characterCustomization);
			version = 14;
		}
		if (version < 15)
		{
			Debug.Log($"Upgrading character {characterGuid} from version {version} to 15");
			version = 15;
		}
		if (version > 15)
		{
			Debug.LogWarning($"Character uses version {version}, but the current version is {15}");
		}
		nonSerialized.discoveredObjects.Clear();
		foreach (DiscoveredObjectData item in discoveredObjects2)
		{
			nonSerialized.discoveredObjects.Add(item);
		}
		nonSerialized.cookedFoods = null;
	}

	private void FixSwappedPetTalents()
	{
		if (inventory.Count != inventoryAuxData.Count)
		{
			Debug.LogError("Cannot fix swapped pet talents: size of inventory and aux data do not match!");
			return;
		}
		for (int i = 0; i < inventory.Count; i++)
		{
			ObjectDataCD objectDataCD = inventory[i];
			if (objectDataCD.objectID == ObjectID.PetElectric)
			{
				CharacterInventoryAuxData value = inventoryAuxData[i];
				value.data = InventoryAuxDataSystemExtensions.PatchIncorrectPetTalents(PetTalent.MinionAttackSpeed, PetTalent.ApplyRadiationDamage, value.data);
				inventoryAuxData[i] = value;
				Debug.Log($"Replaced talent {PetTalent.MinionAttackSpeed} with {PetTalent.ApplyRadiationDamage} for {objectDataCD.objectID} in inventory slot {i}.");
			}
			else if (objectDataCD.objectID == ObjectID.PetWarlock)
			{
				CharacterInventoryAuxData value2 = inventoryAuxData[i];
				value2.data = InventoryAuxDataSystemExtensions.PatchIncorrectPetTalents(PetTalent.ApplyRadiationDamage, PetTalent.MinionAttackSpeed, value2.data);
				inventoryAuxData[i] = value2;
				Debug.Log($"Replaced talent {PetTalent.ApplyRadiationDamage} with {PetTalent.MinionAttackSpeed} for {objectDataCD.objectID} in inventory slot {i}.");
			}
		}
	}

	private PlayerCustomization ConvertOldPlayerCustomizationToNew(PlayerCustomizationOld oldPlayerCustomizationData)
	{
		PlayerCustomization result = new PlayerCustomization
		{
			name = oldPlayerCustomizationData.name,
			role = oldPlayerCustomizationData.role
		};
		PlayerCustomizationIndexToDataBlockMapping playerCustomizationIndexToDataBlockMapping = Resources.Load<PlayerCustomizationIndexToDataBlockMapping>("PlayerCustomizationIndexToDataBlockMapping");
		if (playerCustomizationIndexToDataBlockMapping == null)
		{
			Debug.LogError("Failed to load PlayerCustomizationIndexToDataBlockMapping resource.");
			return result;
		}
		result.body = GetOrEmptyAddress(playerCustomizationIndexToDataBlockMapping.bodySkins, oldPlayerCustomizationData.gender);
		result.skinColor = GetOrEmptyAddress(playerCustomizationIndexToDataBlockMapping.skinColors, oldPlayerCustomizationData.skinColor);
		result.hair = GetOrEmptyAddress(playerCustomizationIndexToDataBlockMapping.hairs, oldPlayerCustomizationData.hair);
		result.hairColor = GetOrEmptyAddress(playerCustomizationIndexToDataBlockMapping.hairColors, oldPlayerCustomizationData.hairColor);
		result.hairShadeColor = GetOrEmptyAddress(playerCustomizationIndexToDataBlockMapping.hairShadeColors, oldPlayerCustomizationData.skinColor);
		result.eyes = GetOrEmptyAddress(playerCustomizationIndexToDataBlockMapping.eyes, oldPlayerCustomizationData.eyes);
		result.eyesColor = GetOrEmptyAddress(playerCustomizationIndexToDataBlockMapping.eyeColors, oldPlayerCustomizationData.eyesColor);
		result.shirtSkin = GetOrEmptyAddress(playerCustomizationIndexToDataBlockMapping.shirts, oldPlayerCustomizationData.shirtSkin);
		result.shirtColor = GetOrEmptyAddress(playerCustomizationIndexToDataBlockMapping.shirtColors, oldPlayerCustomizationData.shirtColor);
		result.pantsSkin = GetOrEmptyAddress(playerCustomizationIndexToDataBlockMapping.pants, oldPlayerCustomizationData.pantsSkin);
		result.pantsColor = GetOrEmptyAddress(playerCustomizationIndexToDataBlockMapping.pantsColors, oldPlayerCustomizationData.pantsColor);
		result.helm = GetOrEmptyAddress(playerCustomizationIndexToDataBlockMapping.helms, oldPlayerCustomizationData.helm);
		result.breastArmor = GetOrEmptyAddress(playerCustomizationIndexToDataBlockMapping.breastArmors, oldPlayerCustomizationData.breastArmor);
		result.pantsArmor = GetOrEmptyAddress(playerCustomizationIndexToDataBlockMapping.pantsArmors, oldPlayerCustomizationData.pantsArmor);
		return result;
	}

	private static DataBlockAddress GetOrEmptyAddress<T>(List<DataBlockRef<T>> list, int index) where T : ScriptableDataBlock
	{
		if (index >= 0 && index < list.Count)
		{
			return list[index];
		}
		Debug.LogWarning($"{index} is out of range for PlayerCustomizationIndexToDataBlockMapping of type {typeof(T).Name}");
		return DataBlockAddress.Empty;
	}
}
