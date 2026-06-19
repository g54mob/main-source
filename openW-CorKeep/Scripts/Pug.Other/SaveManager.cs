#define PUG_ACHIEVEMENTS
using System;
using System.Collections.Generic;
using System.Text;
using Pug.Platform;
using Pug.Properties;
using Pug.UnityExtensions;
using PugMod;
using PugWorldGen;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Profiling;
using UnityEngine;

public class SaveManager : ManagerBase
{
	public const int numberCharacters = 30;

	public const int numberWorlds = 30;

	public const int numberCreativeCharacters = 30;

	public const int creativeCharacterStartIndex = 30;

	public const int debugCharacterIndex = 60;

	public const int debugWorldIndex = 30;

	public const int totalNumberCharacters = 61;

	public const int totalNumberWorlds = 31;

	public DataBlockRef<PlayerCustomizationTableDataBlock> playerCustomizationTable;

	private int _characterId = -1;

	private bool _characterDead;

	private int _worldId = -1;

	private int _serverId = -1;

	private CharacterData[] characterData = new CharacterData[61];

	private FilesystemManager.File[] characterFiles = new FilesystemManager.File[61];

	private WorldInfo[] worldInfo = new WorldInfo[31];

	private FilesystemManager.File[] worldInfoFiles = new FilesystemManager.File[31];

	private FilesystemManager.File[] worldDataFiles = new FilesystemManager.File[31];

	private CoreKeeperWorldParameters[] worldGenerationParameters = new CoreKeeperWorldParameters[31];

	private FilesystemManager.File[] worldGenerationParametersFiles = new FilesystemManager.File[31];

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("SaveManager.Init");

	private int characterId => GetCharacterId();

	private int serverId => GetServerId();

	private static byte[] EncodeJson<T>(T characterData) where T : class
	{
		string text = "";
		text = JsonUtility.ToJson(characterData);
		if (text == "")
		{
			throw new Exception("Empty JSON");
		}
		return Encoding.UTF8.GetBytes(text);
	}

	private static bool DecodeJson<T>(byte[] data, T characterData) where T : class
	{
		try
		{
			JsonUtility.FromJsonOverwrite(Encoding.UTF8.GetString(data), characterData);
		}
		catch (Exception ex)
		{
			Debug.LogWarning("Save file parse error: " + ex.Message);
			return false;
		}
		return true;
	}

	public byte[] GetStrippedAndSerializedCharacterData()
	{
		return EncodeJson(characterData[characterId]);
	}

	public static CharacterData GetCharacterDataFromSerialized(byte[] data)
	{
		CharacterData result = new CharacterData();
		if (!DecodeJson(data, result))
		{
			return null;
		}
		return result;
	}

	public void SetCharacterId(int id)
	{
		if (!IsCompatibleWithCurrentGameVersion(id))
		{
			Debug.LogWarning("Activating a character that is not compatible with the current game version.");
		}
		_characterDead = false;
		_characterId = id;
	}

	public int GetCharacterId()
	{
		return _characterId;
	}

	public void UseCustomCharacterDataProvider(Func<byte[]> provider)
	{
		Manager.filesystemManager.RegisterFileDataProvider(characterFiles[_characterId], provider);
		DecodeJson(Manager.filesystemManager.Read(characterFiles[_characterId]), characterData[_characterId]);
	}

	public void SetWorldId(int id)
	{
		_worldId = id;
	}

	public int GetWorldId()
	{
		return _worldId;
	}

	public void UseCustomWorldDataProvider(Func<byte[]> worldProvider, Func<byte[]> worldInfoProvider)
	{
		Manager.filesystemManager.RegisterFileDataProvider(worldDataFiles[_worldId], worldProvider);
		Manager.filesystemManager.RegisterFileDataProvider(worldInfoFiles[_worldId], worldInfoProvider);
		DecodeJson(Manager.filesystemManager.Read(worldInfoFiles[_worldId]), worldInfo[_worldId]);
	}

	public int GetServerId()
	{
		if (string.IsNullOrEmpty(Manager.networking.serverGuid))
		{
			Debug.LogError("No server guid");
			return -1;
		}
		_serverId = FindOrCreateServer(Manager.networking.serverGuid);
		return _serverId;
	}

	private bool HasServer(string serverGuid)
	{
		List<ServerData> servers = characterData[characterId].servers;
		for (int i = 0; i < servers.Count; i++)
		{
			if (servers[i].serverGuid.Equals(serverGuid))
			{
				return true;
			}
		}
		return false;
	}

	private int FindOrCreateServer(string serverGuid)
	{
		List<ServerData> servers = characterData[characterId].servers;
		int i;
		for (i = 0; i < servers.Count; i++)
		{
			if (servers[i].serverGuid.Equals(serverGuid))
			{
				return i;
			}
		}
		ServerData serverData = new ServerData();
		serverData.serverGuid = serverGuid;
		servers.Add(serverData);
		FilesystemManager.File file = new FilesystemManager.File(FilesystemManager.FileID.MapParts, characterId, i);
		if (file.Exists())
		{
			Debug.LogError($"remove old map file {file.ToString()} when creating server id {i} guid {serverGuid}");
			file.Delete();
		}
		return servers.Count - 1;
	}

	public bool IsFirstTimePlayingOnAnyServer()
	{
		return characterData[characterId].serverConnectCount == 0;
	}

	public UnityEngine.Hash128 GetCharacterGuid()
	{
		return UnityEngine.Hash128.Parse(characterData[characterId].characterGuid);
	}

	public PlayerCustomization GetCharacterCustomization()
	{
		return GetCharacterCustomization(characterId);
	}

	public PlayerCustomization GetCharacterCustomization(int saveId)
	{
		return characterData[saveId].CharacterCustomization;
	}

	public void SetCharacterCustomization(PlayerCustomization customization)
	{
		SetCharacterCustomization(characterId, customization);
	}

	public void SetCharacterCustomization(int saveId, PlayerCustomization customization)
	{
		characterData[saveId].CharacterCustomization = customization;
	}

	public bool IsCompatibleWithCurrentGameVersion()
	{
		return IsCompatibleWithCurrentGameVersion(characterId);
	}

	public bool IsCompatibleWithCurrentGameVersion(int saveId)
	{
		return characterData[saveId].version == 15;
	}

	public CharacterType GetCharacterType()
	{
		return GetCharacterType(characterId);
	}

	public CharacterType GetCharacterType(int saveId)
	{
		return characterData[saveId].characterType;
	}

	public void SetCharacterType(CharacterType characterType)
	{
		SetCharacterType(characterId, characterType);
	}

	public void SetCharacterType(int saveId, CharacterType characterType)
	{
		characterData[saveId].characterType = characterType;
	}

	public bool SetObjectAsDiscovered(ObjectDataCD objectData)
	{
		HashSet<DiscoveredObjectData> discoveredObjects = characterData[characterId].nonSerialized.discoveredObjects;
		if (PugDatabase.HasComponent<PetCD>(objectData) || objectData.objectID == ObjectID.Bucket)
		{
			objectData.variation = 0;
		}
		if (discoveredObjects.Contains(objectData))
		{
			return false;
		}
		if (PugDatabase.HasComponent<CookedFoodCD>(objectData))
		{
			GetDiscoveredCookedFoods().Add(objectData);
		}
		discoveredObjects.Add(objectData);
		Manager.achievements.TriggerAnyAchievementForObtainingAnItem(objectData.objectID);
		return true;
	}

	public List<DiscoveredObjectData> GetDiscoveredCookedFoods()
	{
		if (characterData[characterId].nonSerialized.cookedFoods == null)
		{
			characterData[characterId].nonSerialized.cookedFoods = new List<DiscoveredObjectData>();
			foreach (DiscoveredObjectData discoveredObject in characterData[characterId].nonSerialized.discoveredObjects)
			{
				if (PugDatabase.HasComponent<CookedFoodCD>(discoveredObject))
				{
					characterData[characterId].nonSerialized.cookedFoods.Add(discoveredObject);
				}
			}
		}
		return characterData[characterId].nonSerialized.cookedFoods;
	}

	public bool HasDiscoveredObject(ObjectID objectID, int variation = 0)
	{
		return characterData[characterId].nonSerialized.discoveredObjects.Contains(new DiscoveredObjectData
		{
			objectID = objectID,
			variation = variation
		});
	}

	public int GetSkillValue(SkillID skillId)
	{
		for (int i = 0; i < characterData[characterId].skills.Count; i++)
		{
			if (characterData[characterId].skills[i].skillID == skillId)
			{
				return characterData[characterId].skills[i].value;
			}
		}
		return 0;
	}

	public Skills GetSkills()
	{
		Skills result = default(Skills);
		for (int i = 0; i < characterData[characterId].skills.Count; i++)
		{
			SkillData skillData = characterData[characterId].skills[i];
			switch (skillData.skillID)
			{
			case SkillID.Mining:
				result.mining = skillData.value;
				break;
			case SkillID.Running:
				result.running = skillData.value;
				break;
			case SkillID.Vitality:
				result.vitality = skillData.value;
				break;
			case SkillID.Melee:
				result.melee = skillData.value;
				break;
			case SkillID.Crafting:
				result.crafting = skillData.value;
				break;
			case SkillID.Range:
				result.range = skillData.value;
				break;
			case SkillID.Gardening:
				result.gardening = skillData.value;
				break;
			case SkillID.Fishing:
				result.fishing = skillData.value;
				break;
			}
		}
		return result;
	}

	public void AddSkillValue(SkillID skillId, int amount)
	{
		for (int i = 0; i < characterData[characterId].skills.Count; i++)
		{
			if (characterData[characterId].skills[i].skillID == skillId)
			{
				SkillData value = characterData[characterId].skills[i];
				value.value = math.max(0, characterData[characterId].skills[i].value + amount);
				characterData[characterId].skills[i] = value;
				Manager.achievements.CheckAndTriggerSkillAchievement(skillId, value.value);
				return;
			}
		}
		if (amount > 0)
		{
			characterData[characterId].skills.Add(new SkillData(skillId, amount));
		}
		Manager.achievements.CheckAndTriggerSkillAchievement(skillId, amount);
	}

	public void SetSkillValue(SkillID skillId, int value)
	{
		for (int i = 0; i < characterData[characterId].skills.Count; i++)
		{
			if (characterData[characterId].skills[i].skillID == skillId)
			{
				SkillData value2 = characterData[characterId].skills[i];
				value2.value = math.max(0, value);
				characterData[characterId].skills[i] = value2;
				Manager.achievements.CheckAndTriggerSkillAchievement(skillId, value2.value);
				return;
			}
		}
		if (value > 0)
		{
			characterData[characterId].skills.Add(new SkillData(skillId, value));
		}
		Manager.achievements.CheckAndTriggerSkillAchievement(skillId, value);
	}

	public List<int> GetSkillTalentTreesPoints(SkillID skillTreeID)
	{
		for (int i = 0; i < characterData[characterId].skillTalentTreeDatas.Count; i++)
		{
			if (characterData[characterId].skillTalentTreeDatas[i].skillTreeID == skillTreeID)
			{
				return characterData[characterId].skillTalentTreeDatas[i].points;
			}
		}
		return null;
	}

	public void SetSkillTalentPoint(SkillID skillTreeID, int talentIndex, int points)
	{
		int num = -1;
		for (int i = 0; i < characterData[characterId].skillTalentTreeDatas.Count; i++)
		{
			SkillTalentTreeData skillTalentTreeData = characterData[characterId].skillTalentTreeDatas[i];
			if (skillTalentTreeData.skillTreeID == skillTreeID)
			{
				num = i;
				if (skillTalentTreeData.points.Count > talentIndex)
				{
					characterData[characterId].skillTalentTreeDatas[i].points[talentIndex] = points;
					return;
				}
			}
		}
		if (num == -1)
		{
			characterData[characterId].skillTalentTreeDatas.Add(new SkillTalentTreeData
			{
				skillTreeID = skillTreeID,
				points = new List<int>()
			});
			num = characterData[characterId].skillTalentTreeDatas.Count - 1;
		}
		for (int j = characterData[characterId].skillTalentTreeDatas[num].points.Count; j <= talentIndex; j++)
		{
			characterData[characterId].skillTalentTreeDatas[num].points.Add(0);
		}
		characterData[characterId].skillTalentTreeDatas[num].points[talentIndex] = points;
	}

	public int GetAvailableTalentPoints(SkillID skillTreeID)
	{
		int skillValue = Manager.saves.GetSkillValue(skillTreeID);
		int num = (int)math.floor((float)SkillExtensions.GetLevelFromSkill(skillTreeID, skillValue) / 5f);
		if (num >= 20)
		{
			num += 5;
		}
		int num2 = 0;
		List<int> skillTalentTreesPoints = Manager.saves.GetSkillTalentTreesPoints(skillTreeID);
		if (skillTalentTreesPoints != null)
		{
			for (int i = 0; i < skillTalentTreesPoints.Count; i++)
			{
				num2 += skillTalentTreesPoints[i];
			}
		}
		return num - num2;
	}

	public void ResetTalentTree(SkillID skillTreeID)
	{
		for (int i = 0; i < characterData[characterId].skillTalentTreeDatas.Count; i++)
		{
			if (characterData[characterId].skillTalentTreeDatas[i].skillTreeID == skillTreeID)
			{
				characterData[characterId].skillTalentTreeDatas[i].points.Clear();
			}
		}
	}

	public void SetMaxHealth(int maxHealth)
	{
		characterData[characterId].maxHealth = maxHealth;
	}

	public int GetCurrentMaxHealth(int characterId)
	{
		return characterData[characterId].maxHealth;
	}

	public int GetConditionValue(int characterId, ConditionID condition)
	{
		for (int i = 0; i < characterData[characterId].conditionsList.Count; i++)
		{
			if (characterData[characterId].conditionsList[i].Id == (int)condition)
			{
				return characterData[characterId].conditionsList[i].Value;
			}
		}
		return 0;
	}

	public void SetConditions(DynamicBuffer<ConditionsBuffer> conditions, NetworkTick currentTick, uint tickRate)
	{
		characterData[characterId].conditionsList.Clear();
		for (int i = 0; i < conditions.Length; i++)
		{
			characterData[characterId].conditionsList.Add(conditions[i].condition.ToConditionSerialized(currentTick, tickRate));
		}
	}

	public void SetInventory(List<ContainedObjectsBuffer> inventory, InventoryAuxDataSystemDataCD auxDataSystemData, World world)
	{
		int property = Property.StringToHash("name");
		characterData[characterId].inventory.Clear();
		characterData[characterId].inventoryObjectNames.Clear();
		characterData[characterId].inventoryAuxData.Clear();
		for (int i = 0; i < inventory.Count; i++)
		{
			characterData[characterId].inventory.Add(inventory[i].objectData);
			string value = null;
			API.Authoring.ObjectProperties.TryGetPropertyString(inventory[i].objectData.objectID, property, out value);
			characterData[characterId].inventoryObjectNames.Add(value);
			if (inventory[i].auxDataIndex != 0)
			{
				string dataAsJson = auxDataSystemData.GetDataAsJson(world.EntityManager, inventory[i].auxDataIndex);
				if (string.IsNullOrEmpty(dataAsJson))
				{
					Debug.LogWarning($"got no data, but auxDataIndex is set: {inventory[i].auxDataIndex}");
				}
				characterData[characterId].inventoryAuxData.Add(new CharacterInventoryAuxData
				{
					index = inventory[i].auxDataIndex,
					data = dataAsJson
				});
			}
			else
			{
				characterData[characterId].inventoryAuxData.Add(default(CharacterInventoryAuxData));
			}
		}
	}

	public void SetLockedObjects(DynamicBuffer<LockedObjectsBuffer> lockedObjects)
	{
		characterData[characterId].lockedObjects.Clear();
		for (int i = 0; i < lockedObjects.Length; i++)
		{
			if (characterData[characterId].lockedObjects.Count <= i)
			{
				characterData[characterId].lockedObjects.Add(lockedObjects[i].Value);
			}
			else
			{
				characterData[characterId].lockedObjects[i] = lockedObjects[i].Value;
			}
		}
	}

	public void SetCrystalActivated(ObjectID crystalId)
	{
		if (!worldInfo[_worldId].activatedCrystals.Contains(crystalId))
		{
			worldInfo[_worldId].activatedCrystals.Add(crystalId);
		}
	}

	public bool HasActivatedCrystal(ObjectID objectID, int saveFileId)
	{
		return worldInfo[saveFileId].activatedCrystals.Contains(objectID);
	}

	public void SetWorldCreationDate(DateTime dateTime)
	{
		SetWorldCreationDate(dateTime, _worldId);
	}

	public void SetWorldCreationDate(DateTime dateTime, int saveFileID)
	{
		worldInfo[saveFileID].creationDate = new CreationDate(dateTime);
	}

	public CreationDate GetWorldCreationDate(int saveFileId)
	{
		return worldInfo[saveFileId].creationDate;
	}

	public void SetWorldSeedString(string seedString)
	{
		worldInfo[_worldId].seedString = seedString;
	}

	public void SetWorldGenerationSettings(CoreKeeperWorldGenerationSettings worldGenerationSettings)
	{
		worldInfo[_worldId].worldGenerationSettings = worldGenerationSettings.levelSettings;
	}

	public void SetWorldIconIndex(int index)
	{
		worldInfo[_worldId].iconIndex = index;
	}

	public int GetWorldIconIndex(int saveFileId)
	{
		return worldInfo[saveFileId].iconIndex;
	}

	public void UnlockSouls()
	{
		characterData[characterId].hasUnlockedSouls = true;
	}

	public bool HasUnlockedSouls()
	{
		return characterData[characterId].hasUnlockedSouls;
	}

	public void CollectSoul(SoulID soulID)
	{
		if (!characterData[characterId].collectedSouls.Contains(soulID))
		{
			characterData[characterId].collectedSouls.Add(soulID);
		}
	}

	public bool HasCollectedSoul(SoulID soulID)
	{
		return characterData[characterId].collectedSouls.Contains(soulID);
	}

	public bool HasCollectedSoul(SoulID soulID, int saveFileId)
	{
		return characterData[saveFileId].collectedSouls.Contains(soulID);
	}

	public bool HasCollectedAllSouls()
	{
		return characterData[characterId].collectedSouls.Count >= Enum.GetValues(typeof(SoulID)).Length - 2;
	}

	public bool SoulPowerIsEnabled(SoulID soulID)
	{
		return !characterData[characterId].disabledSoulPowers.Contains(soulID);
	}

	public void DisableSoulPower(SoulID soulID)
	{
		if (!characterData[characterId].disabledSoulPowers.Contains(soulID))
		{
			characterData[characterId].disabledSoulPowers.Add(soulID);
		}
	}

	public byte GetCollectedAndActiveSoulsMask()
	{
		byte b = 0;
		for (int i = 0; i < 7; i++)
		{
			if (characterData[characterId].collectedSouls.Contains((SoulID)i) && !characterData[characterId].disabledSoulPowers.Contains((SoulID)i))
			{
				b |= (byte)(1 << i);
			}
		}
		return b;
	}

	public void EnableSoulPower(SoulID soulID)
	{
		if (characterData[characterId].disabledSoulPowers.Contains(soulID))
		{
			characterData[characterId].disabledSoulPowers.Remove(soulID);
		}
	}

	public void PlayedOutro()
	{
		characterData[characterId].hasPlayedOutro = true;
	}

	public bool HasPlayedOutro()
	{
		return characterData[characterId].hasPlayedOutro;
	}

	public bool HasCompletedTutorial(TutorialID tutorialID)
	{
		return characterData[characterId].completedTutorials.Contains(tutorialID);
	}

	public void CompleteTutorial(TutorialID tutorialID)
	{
		if (!characterData[characterId].completedTutorials.Contains(tutorialID))
		{
			characterData[characterId].completedTutorials.Add(tutorialID);
		}
	}

	public void DiscoverBiome(Biome biome)
	{
		if (!characterData[characterId].discoveredBiomes.Contains(biome))
		{
			characterData[characterId].discoveredBiomes.Add(biome);
		}
	}

	public bool HasDiscoveredBiome(Biome biome)
	{
		return characterData[characterId].discoveredBiomes.Contains(biome);
	}

	public void SetCoinAmount(int coinAmount)
	{
		characterData[characterId].coinAmount = coinAmount;
	}

	public int GetCoinAmount()
	{
		return characterData[characterId].coinAmount;
	}

	public string GetServerGuid()
	{
		return characterData[characterId].servers[serverId].serverGuid;
	}

	public void SetLastActiveSession(Unity.Entities.Hash128 sessionId)
	{
		characterData[characterId].lastActiveSession = sessionId;
	}

	public void ClearLastActiveSession()
	{
		characterData[characterId].lastActiveSession = default(Unity.Entities.Hash128);
	}

	public int GetServerConnectCount()
	{
		return characterData[characterId].serverConnectCount;
	}

	public void AddServerConnectCount()
	{
		characterData[characterId].serverConnectCount++;
	}

	public bool IsCreativeModeCharacter()
	{
		return IsCreativeModeCharacter(_characterId);
	}

	public bool IsCreativeModeCharacter(int characterId)
	{
		if (characterId >= 30)
		{
			return characterId < 60;
		}
		return false;
	}

	public bool CharacterExists()
	{
		return CharacterExists(characterId);
	}

	public bool CharacterExists(int characterId)
	{
		return Manager.filesystemManager.FileExists(new FilesystemManager.File(FilesystemManager.FileID.Save, characterId));
	}

	public void WriteCompressedWorldData(byte[] data, int size)
	{
		worldDataFiles[_worldId].Write(data, size, addToPool: true, force: false, raw: true);
	}

	public bool WorldExists(int id)
	{
		return worldDataFiles[id].Exists();
	}

	public WorldInfo GetWorldInfo()
	{
		return GetWorldInfo(_worldId);
	}

	public WorldInfo GetWorldInfo(int id)
	{
		if (id <= -1 || id >= worldInfo.Length)
		{
			return null;
		}
		return worldInfo[id];
	}

	public bool IsWorldModeEnabled(WorldMode mode)
	{
		return IsWorldModeEnabled(_worldId, mode);
	}

	public bool IsWorldModeEnabled(int id, WorldMode mode)
	{
		return ((GetWorldInfo(id)?.mode ?? WorldMode.Normal) & mode) != 0;
	}

	public WorldMode GetWorldMode()
	{
		return GetWorldMode(_worldId);
	}

	public WorldMode GetWorldMode(int id)
	{
		return GetWorldInfo(id)?.mode ?? WorldMode.Normal;
	}

	public void SetWorldMode(WorldMode worldMode)
	{
		worldInfo[_worldId].mode = worldMode;
	}

	public bool IsCreativeModeWorld()
	{
		if (Manager.networking.isConnected)
		{
			return (Manager.networking.serverWorldMode & WorldMode.Creative) != 0;
		}
		return (GetWorldMode() & WorldMode.Creative) != 0;
	}

	public string GetWorldName()
	{
		return GetWorldName(_worldId);
	}

	public string GetWorldName(int worldID)
	{
		return GetWorldInfo(worldID)?.name ?? "";
	}

	public void SetWorldName(string worldName)
	{
		if (string.Equals(worldName, "PugServer"))
		{
			worldInfo[_worldId].name = "Legacy World";
		}
		else
		{
			worldInfo[_worldId].name = worldName;
		}
	}

	public WorldGenerationType GetWorldGenerationType()
	{
		return worldInfo[_worldId].worldGenerationType;
	}

	public void SetWorldGenerationType(WorldGenerationType worldGenerationType)
	{
		worldInfo[_worldId].worldGenerationType = worldGenerationType;
	}

	public CoreKeeperWorldParameters GetWorldGenerationParametersReference()
	{
		return worldGenerationParameters[_worldId];
	}

	public void UpdateWorldInfo(ServerGuidCD guid, ServerSeedCD seed, WorldInfoCD worldInfoComponent, WorldGenerationTypeCD worldGenerationType, DynamicBuffer<ActivatedContentBundlesBuffer> activatedContentBundles)
	{
		worldInfo[_worldId].guid = guid.Value.ToString();
		worldInfo[_worldId].seed = seed.Value;
		worldInfo[_worldId].bossesKilled = worldInfoComponent.bossesKilled;
		worldInfo[_worldId].worldGenerationType = worldGenerationType.Value;
		List<DataBlockAddress> activatedContentBundles2 = worldInfo[_worldId].ActivatedContentBundles;
		activatedContentBundles2.Clear();
		foreach (ActivatedContentBundlesBuffer item in activatedContentBundles)
		{
			activatedContentBundles2.Add(item.ContentBundle);
		}
	}

	public void UpdateWorldGenerationParameters(WorldGenerationParametersSerializedCD blobValue)
	{
		if (!blobValue.PackedJsonData.IsCreated)
		{
			Debug.LogWarning("UpdateWorldGenerationParameters called with null blob value.");
		}
		else
		{
			JsonUtility.FromJsonOverwrite(BlobByteArray.DataToString(blobValue.PackedJsonData), worldGenerationParameters[_worldId]);
		}
	}

	public void RemoveCharacter(int saveId)
	{
		FilesystemManager.File file = new FilesystemManager.File(FilesystemManager.FileID.Save, saveId);
		if (Manager.filesystemManager.FileExists(file))
		{
			Manager.filesystemManager.Delete(file);
		}
		Manager.filesystemManager.DeleteAll(FilesystemManager.FileID.MapParts, saveId);
		_ClearCharacter(saveId);
	}

	public void PermaKillCharacter()
	{
		FilesystemManager.File file = new FilesystemManager.File(FilesystemManager.FileID.Save, _characterId);
		if (Manager.filesystemManager.FileExists(file))
		{
			Manager.filesystemManager.Delete(file);
		}
		Manager.filesystemManager.DeleteAll(FilesystemManager.FileID.MapParts, _characterId);
		Manager.ui.mapUI.Clear();
		_characterDead = true;
	}

	public void RemoveWorld(int id)
	{
		FilesystemManager.File file = new FilesystemManager.File(FilesystemManager.FileID.WorldSave, id);
		if (Manager.filesystemManager.FileExists(file))
		{
			Manager.filesystemManager.Delete(file);
		}
		FilesystemManager.File file2 = new FilesystemManager.File(FilesystemManager.FileID.WorldInfo, id);
		if (Manager.filesystemManager.FileExists(file2))
		{
			Manager.filesystemManager.Delete(file2);
		}
		_ClearWorldInfo(id);
		FilesystemManager.File file3 = new FilesystemManager.File(FilesystemManager.FileID.ServerMapParts, id);
		if (Manager.filesystemManager.FileExists(file3))
		{
			Manager.filesystemManager.Delete(file3);
		}
		FilesystemManager.File file4 = new FilesystemManager.File(FilesystemManager.FileID.WorldGenerationParameters, id);
		if (Manager.filesystemManager.FileExists(file4))
		{
			Manager.filesystemManager.Delete(file4);
		}
		_ClearWorldGenerationParameters(id);
	}

	private void _ClearCharacter(int i)
	{
		characterData[i].version = 15;
		characterData[i].characterGuid = PugRandom.GenerateGuid().ToString();
		characterData[i].CharacterCustomization = (playerCustomizationTable.TryGet(out var dataBlock) ? new PlayerCustomization(dataBlock) : default(PlayerCustomization));
		characterData[i].discoveredObjects.Clear();
		characterData[i].servers.Clear();
		characterData[i].skills.Clear();
		characterData[i].activatedCrystals.Clear();
		characterData[i].inventory.Clear();
		characterData[i].inventoryObjectNames.Clear();
		characterData[i].inventoryAuxData.Clear();
		characterData[i].lockedObjects.Clear();
		characterData[i].conditionsList.Clear();
		characterData[i].hasUnlockedSouls = false;
		characterData[i].coinAmount = 0;
		characterData[i].collectedSouls.Clear();
		characterData[i].maxHealth = 100;
		characterData[i].serverConnectCount = 0;
		characterData[i].skillTalentTreeDatas.Clear();
		characterData[i].discoveredBiomes.Clear();
		characterData[i].discoveredObjects2.Clear();
		characterData[i].disabledSoulPowers.Clear();
		characterData[i].hasPlayedOutro = false;
		characterData[i].completedTutorials.Clear();
		characterData[i].OnAfterDeserialize();
	}

	private void _ClearWorldInfo(int i)
	{
		worldInfo[i].version = 0;
		worldInfo[i].name = "Legacy World";
		worldInfo[i].guid = "";
		worldInfo[i].seedString = "";
		worldInfo[i].seed = 0u;
		worldInfo[i].mode = WorldMode.Normal;
		worldInfo[i].creationDate = null;
		worldInfo[i].activatedCrystals.Clear();
		worldInfo[i].iconIndex = 0;
		worldInfo[i].worldGenerationType = WorldGenerationType.Undefined;
		worldInfo[i].viewedContentBundles.Clear();
	}

	private void _ClearWorldGenerationParameters(int i)
	{
		DecodeJson(EncodeJson(Manager.worldGen.defaultWorldParameters), worldGenerationParameters[i]);
	}

	public void WriteCharacter()
	{
		WriteCharacter(characterId);
	}

	public void WriteCharacter(int saveId)
	{
		if (!IsCompatibleWithCurrentGameVersion(saveId))
		{
			Debug.LogError("Trying to save a character using the format from a newer game version.");
		}
		else if (saveId != _characterId || !_characterDead)
		{
			if (saveId == _characterId && Manager.main.player != null)
			{
				Manager.main.player.UpdateInventory();
			}
			characterFiles[saveId].Write(EncodeJson(characterData[saveId]));
		}
	}

	public void WriteWorldInfo()
	{
		WriteWorldInfo(_worldId);
	}

	public void WriteWorldInfo(int saveId)
	{
		worldInfoFiles[saveId].Write(EncodeJson(worldInfo[saveId]));
	}

	public void WriteWorldGenerationParameters()
	{
		WriteWorldGenerationParameters(_worldId);
	}

	public void WriteWorldGenerationParameters(int saveId)
	{
		worldGenerationParametersFiles[saveId].Write(EncodeJson(worldGenerationParameters[saveId]));
	}

	public void OnSceneUnload()
	{
		if (Manager.sceneHandler.isInGame)
		{
			if (_characterDead)
			{
				RemoveCharacter(_characterId);
			}
			else
			{
				WriteCharacter();
			}
			_characterDead = false;
			_characterId = -1;
			_serverId = -1;
			_worldId = -1;
		}
	}

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			for (int i = 0; i < 61; i++)
			{
				characterFiles[i] = Manager.filesystemManager.GetFile(FilesystemManager.FileID.Save, i);
				characterData[i] = new CharacterData();
				_ClearCharacter(i);
				if (Manager.filesystemManager.FileExists(characterFiles[i]))
				{
					int version = characterData[i].version;
					DecodeJson(Manager.filesystemManager.Read(characterFiles[i]), characterData[i]);
					characterData[i].serverConnectCount = Mathf.Max(characterData[i].serverConnectCount, characterData[i].servers.Count);
					if (characterData[i].version > version)
					{
						WriteCharacter(i);
					}
				}
			}
			for (int j = 0; j < 31; j++)
			{
				worldInfoFiles[j] = Manager.filesystemManager.GetFile(FilesystemManager.FileID.WorldInfo, j);
				worldInfo[j] = new WorldInfo();
				ReloadWorldInfo(j);
				worldDataFiles[j] = Manager.filesystemManager.GetFile(FilesystemManager.FileID.WorldSave, j);
			}
			for (int k = 0; k < 31; k++)
			{
				worldGenerationParametersFiles[k] = Manager.filesystemManager.GetFile(FilesystemManager.FileID.WorldGenerationParameters, k);
				worldGenerationParameters[k] = UnityEngine.Object.Instantiate(Manager.worldGen.defaultWorldParameters);
				if (Manager.filesystemManager.FileExists(worldGenerationParametersFiles[k]))
				{
					DecodeJson(Manager.filesystemManager.Read(worldGenerationParametersFiles[k]), worldGenerationParameters[k]);
				}
			}
			return true;
		}
	}

	public void ReloadWorldInfo(int worldId)
	{
		_ClearWorldInfo(worldId);
		if (Manager.filesystemManager.FileExists(worldInfoFiles[worldId]))
		{
			DecodeJson(Manager.filesystemManager.Read(worldInfoFiles[worldId]), worldInfo[worldId]);
		}
	}

	public static WorldInfo GetWorldInfoFromSerialized(byte[] data)
	{
		WorldInfo result = new WorldInfo();
		DecodeJson(data, result);
		return result;
	}

	public override void Deinit()
	{
		if (_characterId != -1 && Manager.sceneHandler != null && Manager.sceneHandler.isInGame)
		{
			WriteCharacter();
		}
		base.Deinit();
	}
}
