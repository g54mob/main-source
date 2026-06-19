using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using HighlightingSystem;
using I2.Loc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogRegistration : MonoBehaviour
{
	public delegate void DogImportCompleteCallback();

	private DogImportCompleteCallback importCallback;

	public Sprite symbolNone;

	public Sprite symbolStar;

	public Sprite symbolCircle;

	public Sprite symbolSquare;

	public Sprite symbolSquishedOval;

	public Sprite symbolDiamond;

	public Sprite symbolTriangle;

	public GameObject genePillParticles;

	public GameObject ageUpDustParticles;

	public GameObject ageUpConfettiParticles;

	public GameObject globalDogprefab;

	public GameObject globalDogDummyPrefab;

	public GameObject globalDogManualPrefab;

	private Scene dogSpawningScene;

	private PhysicsScene dogSpawningPhysics;

	private float dogSpawningPhysicsTimer;

	private string dogSpawningSceneName = "DogSpawningScene";

	private List<DogRequest> dogRequests = new List<DogRequest>();

	private int requestIntentions;

	private int maxDogs = 10;

	private float nearbyDogDistance = 10f;

	private List<ulong> allDogIDs = new List<ulong>();

	private Dictionary<ulong, GameObject> dogIDDict = new Dictionary<ulong, GameObject>();

	private Dictionary<ulong, ThumbnailSet> dogThumbnailsByID = new Dictionary<ulong, ThumbnailSet>();

	private Dictionary<ulong, ThumbnailSet> highQualityDogThumbnailsByID = new Dictionary<ulong, ThumbnailSet>();

	private int reservedDogCount;

	private int dogsToLoad;

	private bool dogLoadInProgress;

	private string dogExportSeperator = "^";

	private bool renderStatus = true;

	private bool initialized;

	private bool anyDogHatching;

	private DogRequest currentDogRequestRef;

	private Coroutine currentDogRequest;

	private Coroutine currentDogCreationSubRequest;

	private ulong? currentlyLoadingDogUID;

	private bool isCurrentlyLoadingPlayerOwnedDog;

	private string lastLanguage;

	private List<string> allDogNames = new List<string>();

	private DogHome homeRef;

	private PenFocus penFocusRef;

	private SceneManagerBase sceneRef;

	private GhostManager ghostManagerRef;

	private PlayerInventory playerInventoryRef;

	private DogThumbnailController thumbnailRef;

	private void Start()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
		SceneManager.sceneUnloaded += OnSceneUnloaded;
		OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
	}

	private void Update()
	{
		ProcessDogRequests();
		UpdateDogSpawningPhysicsTimer();
	}

	private void OnDestroy()
	{
		CancelAllDogRequests();
	}

	public void UpdateDogMax(int newMax)
	{
		maxDogs = newMax;
	}

	public Sprite GetSpriteForLabel(DogLabelType label)
	{
		switch (label)
		{
		case DogLabelType.NONE:
			return symbolNone;
		case DogLabelType.STAR:
			return symbolStar;
		case DogLabelType.CIRCLE:
			return symbolCircle;
		case DogLabelType.SQUARE:
			return symbolSquare;
		case DogLabelType.SQUISHED_OVAL:
			return symbolSquishedOval;
		case DogLabelType.DIAMOND:
			return symbolDiamond;
		case DogLabelType.TRIANGLE:
			return symbolTriangle;
		default:
			Debug.LogError("No Sprite found for label: " + label);
			return symbolNone;
		}
	}

	public void StopAllDogBehaviors()
	{
		for (int i = 0; i < allDogIDs.Count; i++)
		{
			dogIDDict[allDogIDs[i]].GetComponent<DogAI>().ForceInterruptBehavior();
		}
	}

	public DogThumbnailController GetThumbnailRef()
	{
		return thumbnailRef;
	}

	public void SetThumbnailRef(DogThumbnailController newRef)
	{
		thumbnailRef = newRef;
	}

	public List<ulong> GetOrderedDogUIDs()
	{
		if (thumbnailRef == null)
		{
			return new List<ulong>();
		}
		return thumbnailRef.GetOrderedDogUIDs();
	}

	public void CacheThumbnails()
	{
		if (thumbnailRef == null)
		{
			return;
		}
		List<SaveableDog> ownedDogs = playerInventoryRef.GetOwnedDogs();
		for (int i = 0; i < ownedDogs.Count; i++)
		{
			if (!ownedDogs[i].inWorld || ownedDogs[i].inCocoon || sceneRef.GetGameMode() != GameMode.HOME)
			{
				thumbnailRef.CacheThumbnailForDogID(ownedDogs[i].dogID);
			}
		}
	}

	public bool AnyDogHatching()
	{
		return anyDogHatching;
	}

	public void SetIsHatching(bool val)
	{
		if (val && anyDogHatching)
		{
			Debug.LogError("Potential hatch clash.");
		}
		anyDogHatching = val;
	}

	public void SetCocoonableDog(GameObject dog)
	{
		thumbnailRef.SetCocoonableDog(GetIDFromDog(dog));
	}

	public void RefreshThumbnailForDog(GameObject dog)
	{
		RefreshThumbnailForDogID(GetIDFromDog(dog));
	}

	public void RefreshThumbnailForDogID(ulong dogID)
	{
		thumbnailRef.RefreshThumbnailForDogID(dogID);
	}

	public void RefreshNameForDogID(ulong dogID, bool forceOn = false)
	{
		SaveableDog saveableDogFromID = GetSaveableDogFromID(dogID);
		if (!saveableDogFromID.inWorld)
		{
			return;
		}
		if (saveableDogFromID.inCocoon)
		{
			GetCocoonFromID(dogID).GetComponent<Cocoon>().GetIndicator().GetComponent<CocoonIndicator>()
				.SetName(saveableDogFromID.dogName);
			return;
		}
		DogIndicatorController component = GetDogFromID(dogID).GetComponent<DogIndicatorController>();
		component.UpdateName(saveableDogFromID.dogName);
		if (forceOn)
		{
			component.EnableEntireIndicator();
		}
	}

	public bool TryImportDog(string dogCode, DogImportCompleteCallback newCallback)
	{
		GameObject targetRoom = homeRef.GetTargetRoom();
		if (targetRoom == null)
		{
			return false;
		}
		Vector3 posForRoom = homeRef.GetPosForRoom(0uL, targetRoom);
		float value = 0f;
		float value2 = 0f;
		GeneticVersion geneVersion = GeneticVersion.ZERO;
		SaveableDogPersonality saveableDogPersonality = new SaveableDogPersonality(new DogPersonality());
		string dogGene;
		string text3;
		DogAge dogAge;
		float num2;
		try
		{
			string text = MathUtil.Unscramble(dogCode);
			int num = text.IndexOf(dogExportSeperator);
			if (num < 0)
			{
				return false;
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			if (text[0].ToString() == dogExportSeperator)
			{
				flag = true;
				text = text.Substring(1);
				if (text[0].ToString() == dogExportSeperator)
				{
					flag2 = true;
					text = text.Substring(1);
					if (text[0].ToString() == dogExportSeperator)
					{
						flag3 = true;
						text = text.Substring(1);
					}
				}
				num = text.IndexOf(dogExportSeperator);
			}
			if (flag3)
			{
				geneVersion = (GeneticVersion)Enum.Parse(typeof(GeneticVersion), text.Substring(0, num));
				text = text.Substring(num + 1);
				num = text.IndexOf(dogExportSeperator);
			}
			dogGene = MathUtil.GeneticDecode(text.Substring(0, num));
			string text2 = text.Substring(num + 1);
			num = text2.IndexOf(dogExportSeperator);
			text3 = MathUtil.GeneticDecode(text2.Substring(0, num));
			text3 = text3.Replace('0', 'a');
			text3 = text3.Replace('1', 'A');
			text2 = text2.Substring(num + 1);
			num = text2.IndexOf(dogExportSeperator);
			dogAge = (DogAge)Enum.Parse(typeof(DogAge), text2.Substring(0, num));
			text2 = text2.Substring(num + 1);
			num = text2.IndexOf(dogExportSeperator);
			CultureInfo cultureInfo = new CultureInfo("en-US");
			num2 = (float)Convert.ToDouble(text2.Substring(0, num), cultureInfo.NumberFormat);
			text2 = text2.Substring(num + 1);
			num = text2.IndexOf(dogExportSeperator);
			if (flag2)
			{
				value2 = (float)Convert.ToDouble(text2.Substring(0, num), cultureInfo.NumberFormat);
				text2 = text2.Substring(num + 1);
				num = text2.IndexOf(dogExportSeperator);
				value = (float)Convert.ToDouble(text2.Substring(0, num), cultureInfo.NumberFormat);
				text2 = text2.Substring(num + 1);
				num = text2.IndexOf(dogExportSeperator);
			}
			if (flag)
			{
				saveableDogPersonality.socialPersonality = (SocialPersonalityType)Enum.Parse(typeof(SocialPersonalityType), text2.Substring(0, 1));
				saveableDogPersonality.energyPersonality = (EnergyPersonalityType)Enum.Parse(typeof(EnergyPersonalityType), text2.Substring(1, 1));
				saveableDogPersonality.foodPersonality = (FoodPersonalityType)Enum.Parse(typeof(FoodPersonalityType), text2.Substring(2, 1));
				saveableDogPersonality.mischiefPersonality = (MischiefPersonalityType)Enum.Parse(typeof(MischiefPersonalityType), text2.Substring(3, 1));
				saveableDogPersonality.nicenessPersonality = (NicenessPersonalityType)Enum.Parse(typeof(NicenessPersonalityType), text2.Substring(4, 1));
				saveableDogPersonality.pettablePersonality = (PettablePersonalityType)Enum.Parse(typeof(PettablePersonalityType), text2.Substring(5, 1));
				string text4 = text2.Substring(6, 1);
				if (text4 != dogExportSeperator)
				{
					saveableDogPersonality.loudnessPersonality = (LoudnessPersonalityType)Enum.Parse(typeof(LoudnessPersonalityType), text4);
				}
				text2 = text2.Substring(num + 1);
				num = text2.IndexOf(dogExportSeperator);
			}
		}
		catch (Exception message)
		{
			Debug.Log("Failed Dog Import Attempt: " + dogCode);
			Debug.Log(message);
			return false;
		}
		importCallback = newCallback;
		SaveableDogProfile saveableDogProfile = new SaveableDogProfile(ChooseRandomDogNameNonDestructive());
		SaveableDogGene saveableDogGene = new SaveableDogGene();
		saveableDogGene.dogGene = dogGene;
		saveableDogGene.domRecGene = text3;
		saveableDogGene.geneVersion = geneVersion;
		RequestNewDog(posForRoom, targetRoom.transform.rotation, saveableDogGene, null, manualDog: false, dogProfile: saveableDogProfile, customDogAge: dogAge, customDogAgeProgress: num2, customEndOfLifeModifier: value2, customLifeExtension: value, callback: DogImportCallback, playerOwned: true, useBaseGeneWithoutMutation: false, timeslice: true, forceCacheThumbnails: false, dummyDog: false, traitsAllowed: true, useTemporaryID: false, customDogPersonality: saveableDogPersonality, customFloraPool: null, respectMaxDogs: false);
		return true;
	}

	public SaveableDogGene GetSaveableDogGeneFromCode(string dogCode)
	{
		GeneticVersion geneVersion = GeneticVersion.ZERO;
		string dogGene;
		string text3;
		try
		{
			string text = MathUtil.Unscramble(dogCode);
			int num = text.IndexOf(dogExportSeperator);
			if (num < 0)
			{
				return null;
			}
			bool flag = false;
			if (text[0].ToString() == dogExportSeperator)
			{
				text = text.Substring(1);
				if (text[0].ToString() == dogExportSeperator)
				{
					text = text.Substring(1);
					if (text[0].ToString() == dogExportSeperator)
					{
						flag = true;
						text = text.Substring(1);
					}
				}
				num = text.IndexOf(dogExportSeperator);
			}
			if (flag)
			{
				geneVersion = (GeneticVersion)Enum.Parse(typeof(GeneticVersion), text.Substring(0, num));
				text = text.Substring(num + 1);
				num = text.IndexOf(dogExportSeperator);
			}
			dogGene = MathUtil.GeneticDecode(text.Substring(0, num));
			string text2 = text.Substring(num + 1);
			num = text2.IndexOf(dogExportSeperator);
			text3 = MathUtil.GeneticDecode(text2.Substring(0, num));
			text3 = text3.Replace('0', 'a');
			text3 = text3.Replace('1', 'A');
		}
		catch (Exception message)
		{
			Debug.Log("Failed Dog Import Attempt: " + dogCode);
			Debug.Log(message);
			return null;
		}
		return new SaveableDogGene
		{
			dogGene = dogGene,
			domRecGene = text3,
			geneVersion = geneVersion
		};
	}

	private void DogImportCallback(GameObject newDog)
	{
		UnityEngine.Object.Destroy(newDog);
		StartCoroutine(DogImportCompleteRoutine());
	}

	private IEnumerator DogImportCompleteRoutine()
	{
		yield return new WaitForEndOfFrame();
		yield return new WaitForEndOfFrame();
		importCallback?.Invoke();
		importCallback = null;
	}

	public string ExportDog(SaveableDog dogRef)
	{
		if (dogRef.dogGene.geneVersion != MasterDogGene.currentGeneticVersion)
		{
			Debug.LogError("Something went wrong! Attempting to export a dog with an out of date gene!");
			return null;
		}
		CultureInfo cultureInfo = new CultureInfo("en-US");
		string dogGene = dogRef.dogGene.dogGene;
		string input = dogRef.dogGene.domRecGene.Replace('a', '0').Replace('A', '1');
		string text = MathUtil.GeneticEncode(dogGene);
		string text2 = MathUtil.GeneticEncode(input);
		return MathUtil.Scramble(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(dogExportSeperator + dogExportSeperator + dogExportSeperator + (int)dogRef.dogGene.geneVersion, dogExportSeperator), text), dogExportSeperator), text2), dogExportSeperator), dogRef.brain.dogAge), dogExportSeperator), Convert.ToString(dogRef.brain.dogAgeProgress, cultureInfo.NumberFormat)), dogExportSeperator), Convert.ToString(dogRef.brain.endOfLifeModifier, cultureInfo.NumberFormat)), dogExportSeperator), Convert.ToString(dogRef.brain.lifeExtension, cultureInfo.NumberFormat)), dogExportSeperator), (int)dogRef.brain.personality.socialPersonality), (int)dogRef.brain.personality.energyPersonality), (int)dogRef.brain.personality.foodPersonality), (int)dogRef.brain.personality.mischiefPersonality), (int)dogRef.brain.personality.nicenessPersonality), (int)dogRef.brain.personality.pettablePersonality), (int)dogRef.brain.personality.loudnessPersonality), dogExportSeperator), dogRef.dogName));
	}

	public void SelectNextDog()
	{
		thumbnailRef.SelectNextDog();
	}

	public void SelectPreviousDog()
	{
		thumbnailRef.SelectPreviousDog();
	}

	public void SelectDog(GameObject dog)
	{
		thumbnailRef.OnDogSelected(GetIDFromDog(dog));
	}

	public void SelectDog(ulong? dogID, bool fromDoubleClick = false)
	{
		thumbnailRef.OnDogSelected(dogID, fromDoubleClick);
	}

	public void RefreshSelectedDog()
	{
		thumbnailRef.OnDogSelected(thumbnailRef.GetCurrentlySelectedDogID());
	}

	public SaveableDog GetSelectedDog()
	{
		ulong? currentlySelectedDogID = thumbnailRef.GetCurrentlySelectedDogID();
		if (!currentlySelectedDogID.HasValue)
		{
			return null;
		}
		return GetSaveableDogFromID(currentlySelectedDogID.Value);
	}

	public SaveableDogs GetSavedDogs()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		SaveableDogs saveableDogs = new SaveableDogs();
		List<SaveableDog> list = new List<SaveableDog>();
		List<SaveableDog> ownedDogs = playerInventoryRef.GetOwnedDogs();
		for (int i = 0; i < ownedDogs.Count; i++)
		{
			if (registrationScript.IsIDTemporary(ownedDogs[i].dogID))
			{
				Debug.LogError("Attempting to save a dog with a temporary ID. This should never happen.");
			}
			else if (ownedDogs[i].isGhost)
			{
				Debug.LogError("Attempting to save a ghost dog. This should never happen.");
			}
			else if (ownedDogs[i].inWorld && !ownedDogs[i].inCocoon)
			{
				SaveDog(GetDogFromID(ownedDogs[i].dogID), inWorld: true, ownedDogs[i].inCocoon);
				list.Add(GetSaveableDogFromID(ownedDogs[i].dogID).GetCopy());
			}
			else
			{
				list.Add(ownedDogs[i]);
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			list[j].dogGene.dogGeneEncoded = MathUtil.GeneticEncode(list[j].dogGene.dogGene);
			list[j].dogGene.dogGene = "";
			string domRecGene = list[j].dogGene.domRecGene;
			domRecGene = domRecGene.Replace('a', '0');
			domRecGene = domRecGene.Replace('A', '1');
			list[j].dogGene.domRecGeneEncoded = MathUtil.GeneticEncode(domRecGene);
			list[j].dogGene.domRecGene = "";
			saveableDogs.dogs.Add(list[j]);
		}
		return saveableDogs;
	}

	public void LoadSavedDogs(PlayerData playerData, bool spawnDogs = true)
	{
		dogLoadInProgress = true;
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		int num = 0;
		if (playerData != null && playerData.dogs != null)
		{
			SaveableDogs dogs = playerData.dogs;
			homeRef.Initialize();
			for (int i = 0; i < dogs.dogs.Count; i++)
			{
				SaveableDog copy = dogs.dogs[i].GetCopy();
				if (copy.dogGene.dogGeneEncoded != null && copy.dogGene.dogGeneEncoded.Length > 0)
				{
					copy.dogGene.dogGene = MathUtil.GeneticDecode(copy.dogGene.dogGeneEncoded);
					copy.dogGene.dogGeneEncoded = "";
				}
				if (copy.dogGene.domRecGeneEncoded != null && copy.dogGene.domRecGeneEncoded.Length > 0)
				{
					string text = MathUtil.GeneticDecode(copy.dogGene.domRecGeneEncoded);
					text = text.Replace('0', 'a');
					text = text.Replace('1', 'A');
					copy.dogGene.domRecGene = text;
					copy.dogGene.domRecGeneEncoded = "";
				}
				MasterDogGene.MigrateSaveableDogGene(copy.dogGene);
				if (registrationScript.IsIDTemporary(copy.dogID))
				{
					ulong dogID = copy.dogID;
					copy.dogID = registrationScript.GetNewIDForBrokenDog();
					if (copy.inCocoon && playerData.worldTaggedObjectsHome != null && playerData.worldTaggedObjectsHome.cocoons != null)
					{
						for (int j = 0; j < playerData.worldTaggedObjectsHome.cocoons.Count; j++)
						{
							if (playerData.worldTaggedObjectsHome.cocoons[j].cocoon != null && playerData.worldTaggedObjectsHome.cocoons[j].cocoon.associatedDogID == dogID)
							{
								playerData.worldTaggedObjectsHome.cocoons[j].cocoon.associatedDogID = copy.dogID;
								break;
							}
						}
					}
				}
				if (copy.thumbSet != null && copy.thumbSet.IsEmpty())
				{
					copy.thumbSet = null;
				}
				if (copy.thumbSet == null && copy.inCocoon && copy.inWorld)
				{
					copy.inCocoon = false;
				}
				playerInventoryRef.AddOwnedDog(copy);
				if (!(copy.inWorld && !copy.inCocoon && spawnDogs))
				{
					continue;
				}
				if (num < maxDogs)
				{
					num++;
					dogsToLoad++;
					Vector3 pos = homeRef.GetPosForRoom(copy.roomUID);
					if (copy.bodyFrontPosition != null)
					{
						pos = copy.bodyFrontPosition.Load();
					}
					RequestNewDog(pos, Quaternion.identity, null, copy, manualDog: false, OnDogLoaded);
				}
				else
				{
					copy.inWorld = false;
				}
			}
		}
		if (dogsToLoad == 0 && dogRequests.Count == 0)
		{
			OnAllDogsLoaded();
		}
	}

	private void OnDogLoaded(GameObject dog)
	{
		dogsToLoad--;
		if (dogsToLoad == 0 && dogRequests.Count == 0)
		{
			OnAllDogsLoaded();
		}
	}

	private void OnAllDogsLoaded()
	{
		dogLoadInProgress = false;
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		CacheThumbnails();
		registrationScript.saveLoadManager.LoadCocoons();
		registrationScript.GetGlobalComponent<SceneTransition>(GlobalObject.SCENE_TRANSITION).OnAllDogsLoaded();
	}

	public bool AreDogsBeingLoaded()
	{
		return dogLoadInProgress;
	}

	public int GetMaxDogs()
	{
		return maxDogs;
	}

	public List<GameObject> GetAllDogs()
	{
		List<GameObject> list = new List<GameObject>();
		for (int i = 0; i < allDogIDs.Count; i++)
		{
			list.Add(dogIDDict[allDogIDs[i]]);
		}
		return list;
	}

	public List<SaveableDog> GetAllOwnedDogs()
	{
		return playerInventoryRef.GetOwnedDogs();
	}

	public List<GameObject> GetAllInWorldOwnedDogs(bool includeGhosts = true)
	{
		return playerInventoryRef.GetAllInWorldOwnedDogs(includeGhosts);
	}

	public void GetNearbyDogList(GameObject obj, ref List<GameObject> nearbyDogList)
	{
		nearbyDogList.Clear();
		Vector3 vector;
		if (obj.CompareTag(Tags.DOG))
		{
			vector = obj.GetComponent<LegController>().internalFacingObj.transform.position;
		}
		else
		{
			Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
			if (rigidbody == null)
			{
				rigidbody = obj.GetComponentInChildren<Rigidbody>();
			}
			vector = ((!(rigidbody == null)) ? rigidbody.transform.position : obj.transform.position);
		}
		for (int i = 0; i < allDogIDs.Count; i++)
		{
			if (!(dogIDDict[allDogIDs[i]] == obj))
			{
				Vector3 position = dogIDDict[allDogIDs[i]].GetComponent<LegController>().internalFacingObj.transform.position;
				float num = Vector3.Distance(vector, position);
				if (!(num > nearbyDogDistance) && !RaycastUtil.StageRaycast(vector, position - vector, num))
				{
					nearbyDogList.Add(dogIDDict[allDogIDs[i]]);
				}
			}
		}
	}

	public bool HasOutstandingDogRequests()
	{
		if (dogRequests.Count <= 0)
		{
			return currentDogRequest != null;
		}
		return true;
	}

	public int GetDogCount()
	{
		return allDogIDs.Count + reservedDogCount;
	}

	public bool IsLoadingOwnedDogs()
	{
		if (isCurrentlyLoadingPlayerOwnedDog)
		{
			return true;
		}
		for (int i = 0; i < dogRequests.Count; i++)
		{
			if (dogRequests[i].IsPlayerOwned())
			{
				return true;
			}
		}
		return false;
	}

	public int GetNumberOfOwnedDogsBeingLoaded(bool includeGhosts = true)
	{
		int num = 0;
		for (int i = 0; i < dogRequests.Count; i++)
		{
			SaveableDog existingDog = dogRequests[i].GetExistingDog();
			if (existingDog != null)
			{
				if (includeGhosts || !existingDog.isGhost)
				{
					num++;
				}
			}
			else if (dogRequests[i].IsPlayerOwned())
			{
				num++;
			}
			else if (includeGhosts && dogRequests[i].GetIsGhost())
			{
				num++;
			}
		}
		if (currentDogRequestRef != null)
		{
			SaveableDog existingDog2 = currentDogRequestRef.GetExistingDog();
			if (existingDog2 != null)
			{
				if (includeGhosts || !existingDog2.isGhost)
				{
					num++;
				}
			}
			else if (currentDogRequestRef.IsPlayerOwned())
			{
				num++;
			}
			else if (includeGhosts && currentDogRequestRef.GetIsGhost())
			{
				num++;
			}
		}
		return num;
	}

	public List<ulong> GetListOfOwnedDogsBeingLoaded()
	{
		List<ulong> list = new List<ulong>();
		for (int i = 0; i < dogRequests.Count; i++)
		{
			SaveableDog existingDog = dogRequests[i].GetExistingDog();
			if (existingDog != null)
			{
				list.Add(existingDog.dogID);
			}
		}
		if (isCurrentlyLoadingPlayerOwnedDog && currentlyLoadingDogUID.HasValue)
		{
			list.Add(currentlyLoadingDogUID.Value);
		}
		return list;
	}

	public bool IsGivenDogBeingLoaded(ulong dogID)
	{
		if (currentlyLoadingDogUID == dogID)
		{
			return true;
		}
		for (int i = 0; i < dogRequests.Count; i++)
		{
			if (dogRequests[i].IsPlayerOwned())
			{
				SaveableDog existingDog = dogRequests[i].GetExistingDog();
				if (existingDog != null && existingDog.dogID == dogID)
				{
					return true;
				}
			}
		}
		return false;
	}

	public int GetInWorldOwnedDogsCount()
	{
		if (thumbnailRef == null)
		{
			return GetAllInWorldOwnedDogs().Count;
		}
		return thumbnailRef.GetDogCount();
	}

	public void AddRequestIntention()
	{
		requestIntentions++;
	}

	public void RemoveRequestIntention()
	{
		requestIntentions--;
	}

	public int GetNumberOfOwnedAndLoadingDogsIncludingGhosts()
	{
		return GetInWorldOwnedDogsCount() + GetNumberOfOwnedDogsBeingLoaded() + requestIntentions;
	}

	public int GetNumberOfOwnedAndLoadingDogsMinusGhosts()
	{
		return GetInWorldOwnedDogsCount() + GetNumberOfOwnedDogsBeingLoaded() - ghostManagerRef.GetGhostCount();
	}

	public Sprite GetDefaultThumbnailForDog(GameObject dog)
	{
		return GetDefaultThumbnailForDogID(GetIDFromDog(dog));
	}

	public Sprite GetDefaultThumbnailForDogID(ulong? dogID, bool useCocoonSprite = true, bool highQuality = false)
	{
		if (useCocoonSprite && GetSaveableDogFromID(dogID.Value).inCocoon)
		{
			if (highQuality)
			{
				return thumbnailRef.cocoonPortraitSprite;
			}
			return thumbnailRef.cocoonPortraitSpriteLowRes;
		}
		Sprite sprite = null;
		if (highQuality && highQualityDogThumbnailsByID.ContainsKey(dogID.Value))
		{
			return highQualityDogThumbnailsByID[dogID.Value].defaultThumb;
		}
		if (thumbnailRef != null)
		{
			sprite = thumbnailRef.GetDefaultThumbnailForDogID(dogID);
		}
		if (sprite != null)
		{
			return sprite;
		}
		if (dogThumbnailsByID.ContainsKey(dogID.Value))
		{
			return dogThumbnailsByID[dogID.Value].defaultThumb;
		}
		return null;
	}

	public GameObject GetCocoonFromID(ulong ID)
	{
		List<GameObject> allObjectsForTag = ObjectRegistration.GetRegistrationScript().GetAllObjectsForTag(TagsEnum.COCOON);
		for (int i = 0; i < allObjectsForTag.Count; i++)
		{
			if (allObjectsForTag[i].GetComponent<Cocoon>().GetAssociatedDogID() == ID)
			{
				return allObjectsForTag[i];
			}
		}
		return null;
	}

	public GameObject GetDogFromID(ulong ID)
	{
		if (!dogIDDict.ContainsKey(ID))
		{
			return null;
		}
		return dogIDDict[ID];
	}

	public SaveableDog GetSaveableDogFromDog(GameObject dog)
	{
		return GetSaveableDogFromID(GetIDFromDog(dog));
	}

	public SaveableDog GetSaveableDogFromID(ulong ID)
	{
		return playerInventoryRef.GetSaveableDogByID(ID);
	}

	public void UpdateSaveableDog(SaveableDog newSave)
	{
		playerInventoryRef.UpdateSaveableDog(newSave);
	}

	public void UpdateSavedLooks(GameObject dog)
	{
		ulong iDFromDog = GetIDFromDog(dog);
		SaveableDog saveableDogByID = playerInventoryRef.GetSaveableDogByID(iDFromDog);
		if (saveableDogByID == null)
		{
			Debug.LogError("No SaveableDog found for ID: " + iDFromDog + " or dog: " + dog);
			return;
		}
		DogLooks component = dog.GetComponent<DogLooks>();
		MasterDogGene component2 = dog.GetComponent<MasterDogGene>();
		saveableDogByID.dogGene = component2.GetSaveableDogGene(saveableDogByID.dogGene);
		saveableDogByID.bodyMainMat = component.GetBodyMainMaterial();
		saveableDogByID.bodyPatternTexture = component.GetBodyPatternTexture();
		saveableDogByID.bodyPatternAlpha = component.GetBodyPatternTextureAlpha();
		saveableDogByID.bodyPatternMetallic = component.GetBodyPatternTextureMetallic();
		saveableDogByID.bodyPatternSmoothness = component.GetBodyPatternTextureSmoothness();
		saveableDogByID.bodyPatternEmissionColor = new SerializableColor(component.GetBodyPatternEmissionColor());
		playerInventoryRef.UpdateSaveableDog(saveableDogByID);
	}

	public ulong GetIDFromDog(GameObject dog)
	{
		if (dog.CompareTag(Tags.COCOON))
		{
			return dog.GetComponent<Cocoon>().GetAssociatedDogID();
		}
		return dog.GetComponent<ObjectID>().GetUID();
	}

	public string ChooseRandomDogNameNonDestructive(string nameToIgnore = null)
	{
		if (LocalizationManager.CurrentLanguage != lastLanguage)
		{
			RefreshDogNameList();
		}
		string randomElement = ListUtil.GetRandomElement(allDogNames);
		for (int i = 0; i < 5; i++)
		{
			if (!(randomElement == nameToIgnore))
			{
				break;
			}
			randomElement = ListUtil.GetRandomElement(allDogNames);
		}
		return randomElement;
	}

	public void ReserveDogs(int numDogs)
	{
		reservedDogCount += numDogs;
	}

	private void UnpackSavedDog(GameObject dog, SaveableDog savedDog = null, DogAge customDogAge = DogAge.ADULT, float customDogAgeProgress = -1f, float? customEndOfLifeModifier = null, float? customLifeExtension = null)
	{
		if (savedDog == null)
		{
			if (customDogAgeProgress != -1f)
			{
				dog.GetComponent<DoggyBrain>().LoadDogAgeFromSavedDog(customDogAge, customDogAgeProgress, customEndOfLifeModifier, customLifeExtension);
			}
			return;
		}
		dog.name = "Dog: " + savedDog.dogName;
		dog.GetComponent<DogLooks>().UnpackSavedDogInfo(savedDog);
		savedDog.brain.LoadBrain(dog.GetComponent<DoggyBrain>());
		if (savedDog.poop != null)
		{
			savedDog.poop.Load(dog.GetComponent<DogPoopController>());
		}
		if (savedDog.gut != null)
		{
			savedDog.gut.LoadGut(dog.GetComponent<DogGutController>());
		}
		DogEggLayingController component = dog.GetComponent<DogEggLayingController>();
		component.SetCurrentEggTimer(savedDog.currentEggTimer);
		component.SetCanLayEggs(savedDog.canStillLayEggs);
		component.SetCurrentCapsuleTimer(savedDog.currentCapsuleTimer);
	}

	public void PreRegisterDog(GameObject dog, SaveableDog savedDog, bool playerOwned, SaveableDogProfile dogProfile = null, DogAge customDogAge = DogAge.NONE, float customDogAgeProgress = -1f, bool useTemporaryID = false, bool isGhost = false, float? customEndOfLifeModifier = null, float? customLifeExtension = null)
	{
		if (savedDog != null && playerOwned)
		{
			dog.AddComponent<ObjectID>().SetUID(savedDog.dogID);
		}
		else
		{
			ObjectRegistration.GetRegistrationScript().AssignID(dog, null, useTemporaryID);
		}
		UnpackSavedDog(dog, savedDog, customDogAge, customDogAgeProgress, customEndOfLifeModifier, customLifeExtension);
		if (playerOwned)
		{
			IndexDog(dog, savedDog, dogProfile, isGhost);
		}
	}

	public void OnDogDestroyed(ulong dogID)
	{
		DeIndexDog(dogID);
	}

	private void IndexDog(GameObject dog, SaveableDog savedDog = null, SaveableDogProfile dogProfile = null, bool isGhost = false)
	{
		if (dog == null)
		{
			Debug.LogError("Attempting to index a null dog.");
			return;
		}
		ulong uID = dog.GetComponent<ObjectID>().GetUID();
		if (!allDogIDs.Contains(uID))
		{
			if (savedDog != null && uID != savedDog.dogID)
			{
				Debug.LogError("Dog ID mis-match in IndexDog.");
			}
			allDogIDs.Add(uID);
			dogIDDict[uID] = dog;
			if (savedDog == null)
			{
				savedDog = GenerateSaveableDogFromDog(dog, dogProfile, isGhost);
			}
			playerInventoryRef.AddOwnedDog(savedDog);
			playerInventoryRef.UpdateSaveableDog(savedDog);
		}
	}

	private void DeIndexDog(ulong dogID)
	{
		if (dogIDDict.ContainsKey(dogID))
		{
			dogIDDict.Remove(dogID);
		}
		if (dogThumbnailsByID.ContainsKey(dogID))
		{
			dogThumbnailsByID.Remove(dogID);
		}
	}

	public void RegisterDog(GameObject dog, bool playerOwned = true)
	{
		if (playerOwned)
		{
			IndexDog(dog);
		}
		AddDogComponents(dog);
		if (playerOwned)
		{
			UpdateSavedLooks(dog);
		}
	}

	public IEnumerator CacheThumbnailForDog(GameObject dog, bool playerOwned = true)
	{
		if (playerOwned && !(thumbnailRef == null))
		{
			ulong iDFromDog = GetIDFromDog(dog);
			if (!DoThumbnailsExistForDogID(iDFromDog))
			{
				yield return StartCoroutine(GenerateDogThumbnailFromDog(dog, iDFromDog));
			}
			thumbnailRef.CacheThumbnailForDogID(GetIDFromDog(dog));
		}
	}

	public IEnumerator GenerateHighQualityThumbnailForDog(GameObject dog)
	{
		ulong iDFromDog = GetIDFromDog(dog);
		if (!DoThumbnailsExistForDogID(iDFromDog, highQuality: true))
		{
			yield return StartCoroutine(GenerateDogThumbnailFromDog(dog, iDFromDog, highQuality: true));
		}
	}

	public void CacheThumbnailForDogID(ulong dogID)
	{
		thumbnailRef.CacheThumbnailForDogID(dogID);
	}

	private void AddDogComponents(GameObject dog)
	{
		Highlighter[] componentsInChildren = dog.GetComponentsInChildren<Highlighter>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].occluder = true;
		}
	}

	public SaveableDog GenerateSaveableDogFromDog(GameObject dog, SaveableDogProfile dogProfile = null, bool isGhost = false)
	{
		SaveableDog saveableDog = new SaveableDog();
		saveableDog.dogID = GetIDFromDog(dog);
		MasterDogGene component = dog.GetComponent<MasterDogGene>();
		saveableDog.dogGene = component.GetSaveableDogGene(null);
		if (dogProfile != null)
		{
			saveableDog.dogProfile = dogProfile;
			saveableDog.dogName = dogProfile.defaultName;
		}
		else
		{
			saveableDog.dogName = ChooseRandomDogNameNonDestructive();
			saveableDog.dogProfile = new SaveableDogProfile(saveableDog.dogName);
		}
		saveableDog.isGhost = isGhost;
		return UpdateSaveableDogFromDog(saveableDog, dog, inWorld: true);
	}

	private SaveableDog UpdateSaveableDogFromDog(SaveableDog existingSave, GameObject dog, bool inWorld, bool inCocoon = false, bool saveGene = true)
	{
		dog.name = "Dog: " + existingSave.dogName;
		if (saveGene)
		{
			MasterDogGene component = dog.GetComponent<MasterDogGene>();
			existingSave.dogGene = component.GetSaveableDogGene(existingSave.dogGene);
		}
		DogLooks component2 = dog.GetComponent<DogLooks>();
		existingSave.bodyMainMat = component2.GetBodyMainMaterial();
		existingSave.bodyPatternTexture = component2.GetBodyPatternTexture();
		existingSave.bodyPatternAlpha = component2.GetBodyPatternTextureAlpha();
		existingSave.bodyPatternMetallic = component2.GetBodyPatternTextureMetallic();
		existingSave.bodyPatternSmoothness = component2.GetBodyPatternTextureSmoothness();
		existingSave.bodyPatternEmissionColor = new SerializableColor(component2.GetBodyPatternEmissionColor());
		existingSave.gut = new SaveableDogGut(dog.GetComponent<DogGutController>());
		existingSave.brain = new SaveableDoggyBrain(dog.GetComponent<DoggyBrain>());
		existingSave.poop = new SaveablePoopController(dog.GetComponent<DogPoopController>());
		DogEggLayingController component3 = dog.GetComponent<DogEggLayingController>();
		if (component3 == null)
		{
			existingSave.currentEggTimer = 10f;
			existingSave.canStillLayEggs = false;
			existingSave.currentCapsuleTimer = 10f;
		}
		else
		{
			existingSave.canStillLayEggs = component3.CanDogStillLayEggs();
			existingSave.currentEggTimer = component3.GetCurrentEggTimerValue();
			existingSave.currentCapsuleTimer = component3.GetCurrentCapsuleTimerValue();
		}
		if (thumbnailRef != null)
		{
			SaveableThumbSet saveableThumbsetForDogID = thumbnailRef.GetSaveableThumbsetForDogID(existingSave.dogID);
			if (saveableThumbsetForDogID != null)
			{
				existingSave.thumbSet = saveableThumbsetForDogID;
			}
		}
		existingSave.bodyFrontPosition = null;
		if (homeRef != null)
		{
			existingSave.roomUID = homeRef.GetRoomUIDForDog(dog);
			Vector3 position = dog.GetComponent<LegController>().bodyFront.transform.position;
			if (existingSave.roomUID.HasValue && homeRef.GetBBCForRoomUID(existingSave.roomUID.Value).IsPointInsideBox(position))
			{
				existingSave.bodyFrontPosition = new SerializableVector3(position);
			}
		}
		existingSave.inWorld = inWorld;
		existingSave.inCocoon = inCocoon;
		if (inCocoon)
		{
			existingSave.cocoonScale = dog.transform.root.localScale.x;
		}
		return existingSave;
	}

	public void SetDogLabel(ulong dogUID, DogLabelType newLabel)
	{
		SaveableDog saveableDogFromID = GetSaveableDogFromID(dogUID);
		saveableDogFromID.labelType = newLabel;
		saveableDogFromID.favorite = false;
		playerInventoryRef.UpdateSaveableDog(saveableDogFromID);
	}

	public static void SafeDestroy(GameObject obj, bool fromTravel = false)
	{
		obj.GetComponent<RegisterTaggedObject>().SetSafeDestroy(fromTravel);
		UnityEngine.Object.Destroy(obj);
	}

	public void SaveDog(GameObject dog, bool inWorld, bool inCocoon = false, bool saveGene = true)
	{
		if (dog == null)
		{
			Debug.LogError("Attempting to save a null dog.");
			return;
		}
		ulong iDFromDog = GetIDFromDog(dog);
		if (!ObjectRegistration.GetRegistrationScript().IsIDTemporary(iDFromDog) && playerInventoryRef.IsDogUIDOwned(iDFromDog))
		{
			SaveableDog saveableDogFromID = GetSaveableDogFromID(iDFromDog);
			saveableDogFromID = UpdateSaveableDogFromDog(saveableDogFromID, dog, inWorld, inCocoon, saveGene);
			playerInventoryRef.UpdateSaveableDog(saveableDogFromID);
		}
	}

	public bool DoThumbnailsExistForDogID(ulong dogID, bool highQuality = false)
	{
		if (highQuality)
		{
			return highQualityDogThumbnailsByID.ContainsKey(dogID);
		}
		return dogThumbnailsByID.ContainsKey(dogID);
	}

	public ThumbnailSet GrabExistingThumbnailSetForDogID(ulong dogID, DogThumbnailController controllerRef = null)
	{
		if (controllerRef != null && !DoThumbnailsExistForDogID(dogID))
		{
			return controllerRef.GetThumbnailSetForDogID(dogID);
		}
		return dogThumbnailsByID[dogID];
	}

	public void OnRenderFailure()
	{
		renderStatus = false;
	}

	public IEnumerator GenerateDogThumbnailFromDog(GameObject dog, ulong dogID, bool highQuality = false, SaveableDogCore.ThumbnailGenerationCallback callback = null)
	{
		if (callback == null)
		{
			SaveableDog saveableDogFromID = GetSaveableDogFromID(dogID);
			if (saveableDogFromID.thumbSet != null && !highQuality)
			{
				ThumbnailSet value = saveableDogFromID.thumbSet.Load();
				dogThumbnailsByID[dogID] = value;
				yield break;
			}
		}
		Camera renderCam = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Camera>(GlobalObject.RENDER_TEXTURE_CAM);
		renderCam.gameObject.SetActive(value: true);
		int width = 128;
		int height = 128;
		int depth = 32;
		if (highQuality)
		{
			width = 512;
			height = 512;
		}
		RenderTexture renderTex = new RenderTexture(width, height, depth, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
		float originalCamSize = renderCam.orthographicSize;
		Vector3 originalCamPos = renderCam.transform.position;
		Quaternion originalCamRot = renderCam.transform.rotation;
		Vector3 originalDogPos = dog.transform.position;
		Quaternion originalDogRot = dog.transform.rotation;
		renderCam.orthographicSize = 1.5f;
		renderCam.transform.rotation = Quaternion.identity;
		renderCam.transform.position = new Vector3(1000f, 1000f, 1000f);
		dog.transform.SetParent(renderCam.transform);
		dog.transform.localRotation = Quaternion.Euler(0f, -45f, -15f);
		float num = dog.GetComponent<BoundingBoxComponent>().GetBoxSize().x * 4f;
		dog.transform.localPosition = new Vector3(1.5f - num / 16f, -0.5f, num);
		float x = 1.5f - dog.GetComponent<LegController>().bodyFront.transform.lossyScale.x;
		dog.transform.localPosition -= new Vector3(x, 0f, 0f);
		DogIndicatorController indicatorRef = dog.GetComponent<DogIndicatorController>();
		indicatorRef.DisableEntireIndicator();
		dog.GetComponent<FaceController>().RequestFace(Face.DEFAULT);
		ThumbnailSet thumbnailSet = default(ThumbnailSet);
		renderStatus = true;
		Texture2D thumbTex = CreateThumbnailTexture(renderTex);
		yield return StartCoroutine(RenderCamSnapshot(renderCam, renderTex, thumbTex));
		if (!renderStatus)
		{
			thumbTex = null;
		}
		thumbnailSet.defaultThumb = GetSpriteFromRenderTex(renderTex, thumbTex);
		renderCam.orthographicSize = originalCamSize;
		renderCam.transform.rotation = originalCamRot;
		renderCam.transform.position = originalCamPos;
		dog.transform.SetParent(null);
		dog.transform.position = originalDogPos;
		dog.transform.rotation = originalDogRot;
		UnityEngine.Object.Destroy(renderTex);
		renderCam.targetTexture = null;
		RenderTexture.active = null;
		indicatorRef.EnableEntireIndicator();
		if (callback == null)
		{
			if (highQuality)
			{
				highQualityDogThumbnailsByID[dogID] = thumbnailSet;
				if (thumbnailRef.GetCurrentlySelectedDogID() == dogID)
				{
					thumbnailRef.RefreshThumbnailForDogID(dogID);
				}
			}
			else
			{
				dogThumbnailsByID[dogID] = thumbnailSet;
			}
		}
		renderCam.gameObject.SetActive(value: false);
		callback?.Invoke(thumbnailSet);
	}

	private IEnumerator RenderCamSnapshot(Camera renderCam, RenderTexture renderTex, Texture2D thumbnailTexture, FaceController faceRef = null, Face faceType = Face.DEFAULT)
	{
		renderCam.enabled = false;
		penFocusRef.DisableMotionBlur(MotionBlurLockReason.SNAPSHOT_RENDER);
		yield return new WaitForEndOfFrame();
		if (faceRef != null)
		{
			faceRef.RequestFace(faceType, -1f, suppressEmote: true);
		}
		renderCam.enabled = true;
		renderCam.targetTexture = renderTex;
		bool validPortrait = true;
		try
		{
			renderCam.Render();
		}
		catch (Exception message)
		{
			Debug.LogError(message);
			Debug.LogError("Unable to render dog icon snapshot.");
			validPortrait = false;
		}
		renderCam.enabled = false;
		yield return new WaitForEndOfFrame();
		penFocusRef.EnableMotionBlur(MotionBlurLockReason.SNAPSHOT_RENDER);
		RenderTexture.active = renderTex;
		try
		{
			if (validPortrait)
			{
				thumbnailTexture.ReadPixels(new Rect(0f, 0f, renderTex.width, renderTex.height), 0, 0);
				thumbnailTexture.Apply();
			}
		}
		catch (Exception message2)
		{
			Debug.LogError(message2);
			Debug.LogError("Unable to apply dog icon snapshot pixels to final texture.");
			validPortrait = false;
		}
		if (!validPortrait)
		{
			OnRenderFailure();
		}
		yield return new WaitForEndOfFrame();
	}

	private Texture2D CreateThumbnailTexture(RenderTexture renderTex)
	{
		TextureFormat textureFormat = TextureFormat.ARGB32;
		return new Texture2D(renderTex.width, renderTex.height, textureFormat, mipChain: false)
		{
			wrapMode = TextureWrapMode.Clamp
		};
	}

	private Sprite GetSpriteFromRenderTex(RenderTexture renderTex, Texture2D thumbnailTexture)
	{
		if (thumbnailTexture == null)
		{
			return null;
		}
		return Sprite.Create(thumbnailTexture, new Rect(0f, 0f, renderTex.width, renderTex.height), new Vector2(0.5f, 0.5f));
	}

	public void OnDogRemoved(GameObject dog, bool fromTravel = false)
	{
		if (dog == null)
		{
			Debug.LogError("Attempting to call OnDogRemoved() on a null dog.");
			return;
		}
		ulong uID = dog.GetComponent<ObjectID>().GetUID();
		if (dog.GetComponent<DoggyBrain>().IsGhost() && GetSaveableDogFromID(uID) != null)
		{
			ghostManagerRef.DeIndexGhostIfFound(dog);
		}
		RemoveDogInternal(uID, fromTravel);
	}

	public void RemoveDogInternal(ulong dogID, bool fromTravel = false)
	{
		if (allDogIDs.Contains(dogID))
		{
			allDogIDs.Remove(dogID);
		}
		if (dogIDDict.ContainsKey(dogID))
		{
			dogIDDict.Remove(dogID);
		}
		SaveableDog saveableDogFromID = GetSaveableDogFromID(dogID);
		if (thumbnailRef != null && saveableDogFromID != null && !saveableDogFromID.inCocoon)
		{
			thumbnailRef.RemoveDog(dogID);
		}
		if (saveableDogFromID != null && playerInventoryRef.IsDogUIDOwned(dogID))
		{
			if (!ObjectRegistration.GetRegistrationScript().IsIDTemporary(dogID))
			{
				playerInventoryRef.OnOwnedDogStored(saveableDogFromID);
			}
			else if (sceneRef.GetGameMode() == GameMode.BREEDING)
			{
				playerInventoryRef.RemoveOwnedDog(saveableDogFromID);
			}
			else if (sceneRef.GetGameMode() != GameMode.BREEDING)
			{
				if (saveableDogFromID.isGhost)
				{
					playerInventoryRef.RemoveOwnedDog(saveableDogFromID);
				}
				else if (!fromTravel)
				{
					Debug.LogError("Removing a dog that has a temporary ID but is marked as being owned by the player, but we are not in the breeding simulation.");
				}
			}
		}
		if (highQualityDogThumbnailsByID.ContainsKey(dogID))
		{
			highQualityDogThumbnailsByID.Remove(dogID);
		}
	}

	public void ReleaseAndRemoveDog(SaveableDog sd)
	{
		if (sd.inWorld)
		{
			GameObject gameObject = (sd.inCocoon ? GetCocoonFromID(sd.dogID) : GetDogFromID(sd.dogID));
			gameObject.GetComponent<RegisterTaggedObject>().ManualUnregister();
			UnityEngine.Object.Destroy(gameObject);
		}
		playerInventoryRef.RemoveOwnedDog(sd);
	}

	public void OnCocoonRemoved(GameObject cocoon, ulong cocoonID)
	{
		if (dogIDDict.ContainsKey(cocoonID))
		{
			dogIDDict.Remove(cocoonID);
		}
		if (thumbnailRef != null)
		{
			thumbnailRef.RemoveDog(cocoonID);
		}
		SaveableDog saveableDogFromID = GetSaveableDogFromID(cocoon.GetComponent<Cocoon>().GetAssociatedDogID());
		playerInventoryRef.OnOwnedDogStored(saveableDogFromID);
	}

	public void RemoveUnlinkedCocoon(ulong associatedDogID)
	{
		SaveableDog saveableDogFromID = GetSaveableDogFromID(associatedDogID);
		saveableDogFromID.inWorld = false;
		UpdateSaveableDog(saveableDogFromID);
		if (dogIDDict.ContainsKey(associatedDogID))
		{
			dogIDDict.Remove(associatedDogID);
		}
		if (thumbnailRef != null)
		{
			thumbnailRef.RemoveDog(associatedDogID);
		}
		playerInventoryRef.OnOwnedDogStored(saveableDogFromID);
		Debug.LogWarning("Removing an unlinked cocoon for dogID: " + associatedDogID);
	}

	public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		penFocusRef = Camera.main.GetComponent<PenFocus>();
		sceneRef = registrationScript.GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
		ghostManagerRef = registrationScript.GetGlobalComponent<GhostManager>(GlobalObject.GHOST_MANAGER);
		playerInventoryRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).playerInventory;
		if (!SceneManager.GetSceneByName(dogSpawningSceneName).IsValid())
		{
			CreateDogSpawningScene();
		}
		if (!initialized)
		{
			homeRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME, nullAllowed: true);
			RefreshDogNameList();
			initialized = true;
		}
	}

	private void CreateDogSpawningScene()
	{
		dogSpawningScene = SceneManager.CreateScene(parameters: new CreateSceneParameters(LocalPhysicsMode.Physics3D), sceneName: dogSpawningSceneName);
		dogSpawningPhysics = dogSpawningScene.GetPhysicsScene();
	}

	public PhysicsScene GetDogSpawningPhysics()
	{
		return dogSpawningPhysics;
	}

	public void RefreshDogNameList()
	{
		lastLanguage = LocalizationManager.CurrentLanguage;
		allDogNames.Clear();
		allDogNames = new List<string>
		{
			ScriptLocalization.DogNames.NAME_0010,
			ScriptLocalization.DogNames.NAME_0020,
			ScriptLocalization.DogNames.NAME_0030,
			ScriptLocalization.DogNames.NAME_0040,
			ScriptLocalization.DogNames.NAME_0050,
			ScriptLocalization.DogNames.NAME_0060,
			ScriptLocalization.DogNames.NAME_0070,
			ScriptLocalization.DogNames.NAME_0080,
			ScriptLocalization.DogNames.NAME_0090,
			ScriptLocalization.DogNames.NAME_0100,
			ScriptLocalization.DogNames.NAME_0120,
			ScriptLocalization.DogNames.NAME_0130,
			ScriptLocalization.DogNames.NAME_0140,
			ScriptLocalization.DogNames.NAME_0150,
			ScriptLocalization.DogNames.NAME_0160,
			ScriptLocalization.DogNames.NAME_0170,
			ScriptLocalization.DogNames.NAME_0180,
			ScriptLocalization.DogNames.NAME_0190,
			ScriptLocalization.DogNames.NAME_0200,
			ScriptLocalization.DogNames.NAME_0210,
			ScriptLocalization.DogNames.NAME_0220,
			ScriptLocalization.DogNames.NAME_0230,
			ScriptLocalization.DogNames.NAME_0240,
			ScriptLocalization.DogNames.NAME_0250,
			ScriptLocalization.DogNames.NAME_0260,
			ScriptLocalization.DogNames.NAME_0270,
			ScriptLocalization.DogNames.NAME_0280,
			ScriptLocalization.DogNames.NAME_0290,
			ScriptLocalization.DogNames.NAME_0300,
			ScriptLocalization.DogNames.NAME_0310,
			ScriptLocalization.DogNames.NAME_0320,
			ScriptLocalization.DogNames.NAME_0330,
			ScriptLocalization.DogNames.NAME_0340,
			ScriptLocalization.DogNames.NAME_0350,
			ScriptLocalization.DogNames.NAME_0360,
			ScriptLocalization.DogNames.NAME_0370,
			ScriptLocalization.DogNames.NAME_0380,
			ScriptLocalization.DogNames.NAME_0390,
			ScriptLocalization.DogNames.NAME_0400,
			ScriptLocalization.DogNames.NAME_0410,
			ScriptLocalization.DogNames.NAME_0420,
			ScriptLocalization.DogNames.NAME_0430,
			ScriptLocalization.DogNames.NAME_0440,
			ScriptLocalization.DogNames.NAME_0450,
			ScriptLocalization.DogNames.NAME_0460,
			ScriptLocalization.DogNames.NAME_0470,
			ScriptLocalization.DogNames.NAME_0480,
			ScriptLocalization.DogNames.NAME_0490,
			ScriptLocalization.DogNames.NAME_0500,
			ScriptLocalization.DogNames.NAME_0510,
			ScriptLocalization.DogNames.NAME_0520,
			ScriptLocalization.DogNames.NAME_0530,
			ScriptLocalization.DogNames.NAME_0540,
			ScriptLocalization.DogNames.NAME_0550,
			ScriptLocalization.DogNames.NAME_0560,
			ScriptLocalization.DogNames.NAME_0570,
			ScriptLocalization.DogNames.NAME_0580,
			ScriptLocalization.DogNames.NAME_0590,
			ScriptLocalization.DogNames.NAME_0600,
			ScriptLocalization.DogNames.NAME_0610,
			ScriptLocalization.DogNames.NAME_0620,
			ScriptLocalization.DogNames.NAME_0630,
			ScriptLocalization.DogNames.NAME_0640,
			ScriptLocalization.DogNames.NAME_0650,
			ScriptLocalization.DogNames.NAME_0660,
			ScriptLocalization.DogNames.NAME_0670,
			ScriptLocalization.DogNames.NAME_0680,
			ScriptLocalization.DogNames.NAME_0690,
			ScriptLocalization.DogNames.NAME_0700,
			ScriptLocalization.DogNames.NAME_0710,
			ScriptLocalization.DogNames.NAME_0720,
			ScriptLocalization.DogNames.NAME_0730,
			ScriptLocalization.DogNames.NAME_0740,
			ScriptLocalization.DogNames.NAME_0750,
			ScriptLocalization.DogNames.NAME_0760,
			ScriptLocalization.DogNames.NAME_0770,
			ScriptLocalization.DogNames.NAME_0780,
			ScriptLocalization.DogNames.NAME_0790
		};
	}

	public void OnSceneUnloaded(Scene scene)
	{
		if (initialized && !(scene.name == "Preview Scene"))
		{
			allDogIDs.Clear();
			dogIDDict.Clear();
			allDogNames.Clear();
			dogThumbnailsByID.Clear();
			highQualityDogThumbnailsByID.Clear();
			initialized = false;
		}
	}

	public void UpdateDogCollision(GameObject dog)
	{
		LegController component = dog.GetComponent<LegController>();
		for (int i = 0; i < allDogIDs.Count; i++)
		{
			if (!(dogIDDict[allDogIDs[i]] == dog))
			{
				LegController component2 = dogIDDict[allDogIDs[i]].GetComponent<LegController>();
				UpdateLegCollision(component, component2);
				UpdateLegCollision(component2, component);
				UpdateBodyCollision(component, component2);
				UpdateBodyCollision(component2, component);
			}
		}
	}

	public void RebuildDog(GameObject dog, bool saveGene = true)
	{
		SaveableDog saveableDogFromDog = GetSaveableDogFromDog(dog);
		Vector3 position = dog.GetComponent<LegController>().bodyFront.transform.position;
		ObjectSpawnParticles component = UnityEngine.Object.Instantiate(genePillParticles, position, Quaternion.identity).GetComponent<ObjectSpawnParticles>();
		component.RequireDogExists();
		component.SetExistingDog(dog);
		component.SetSaveGene(saveGene);
		component.SetContainedDog(saveableDogFromDog);
		component.dogRegRef = this;
		component.spawnPos = position;
		dog.GetComponent<DogAI>().AIEnabled = false;
	}

	public void ClearCachedThumbnailsForDog(GameObject dog)
	{
		ClearCachedThumbnailsForSaveableDog(GetSaveableDogFromDog(dog));
	}

	public void ClearCachedThumbnailsForSaveableDog(SaveableDog savedDog, bool fromHatch = false)
	{
		savedDog.thumbSet = null;
		UpdateSaveableDog(savedDog);
		dogThumbnailsByID.Remove(savedDog.dogID);
		playerInventoryRef.UpdateSaveableDog(savedDog);
		thumbnailRef.ClearAllThumbnailsForDog(savedDog.dogID, fromHatch);
	}

	public void DogAgeUpdate(GameObject dog)
	{
		SaveDog(dog, inWorld: true);
		SaveableDog saveableDogFromDog = GetSaveableDogFromDog(dog);
		Vector3 position = dog.GetComponent<LegController>().bodyFront.transform.position;
		UnityEngine.Object.Destroy(dog);
		UnityEngine.Object.Instantiate(ageUpConfettiParticles, position, Quaternion.identity);
		ObjectSpawnParticles component = UnityEngine.Object.Instantiate(ageUpDustParticles, position, Quaternion.identity).GetComponent<ObjectSpawnParticles>();
		component.SetContainedDog(saveableDogFromDog);
		component.dogRegRef = this;
		component.spawnPos = position;
		ClearCachedThumbnailsForSaveableDog(saveableDogFromDog);
	}

	public void PopulateLoopedGeneticsMap(SaveableDogGene gene)
	{
		MasterDogGene component = globalDogprefab.GetComponent<MasterDogGene>();
		DogLooks component2 = globalDogprefab.GetComponent<DogLooks>();
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		for (int i = 0; i < component.dogGenes.Count; i++)
		{
			if (component.dogGenes[i].geneType == GeneType.LOOPED && component.dogGenes[i].dynamicLoopCount)
			{
				dictionary[component.dogGenes[i].key] = component2.GetLoopCountForGene(component.dogGenes[i].key);
			}
		}
		gene.dynamicLoopPropertiesCounter = new SerializableDictionary<string, int>(dictionary);
	}

	public void RequestReservedDog(Vector3 pos, Quaternion rot, SaveableDogGene gene = null, SaveableDog existingDog = null, DogRequest.DogRequestCallback callback = null)
	{
		if (reservedDogCount > 0)
		{
			reservedDogCount--;
			RequestNewDog(pos, rot, gene, existingDog, manualDog: false, callback);
		}
	}

	public void CancelAllDogRequests()
	{
		dogRequests.Clear();
		if (currentDogCreationSubRequest != null)
		{
			StopCoroutine(currentDogCreationSubRequest);
			currentDogCreationSubRequest = null;
		}
		if (currentDogRequest != null)
		{
			StopCoroutine(currentDogRequest);
			currentDogRequest = null;
		}
		currentDogRequestRef = null;
	}

	public bool IsCurrentlySpawningDogs()
	{
		if (dogRequests.Count > 0 || currentDogRequest != null)
		{
			return true;
		}
		return false;
	}

	private void UpdateDogSpawningPhysicsTimer()
	{
		dogSpawningPhysicsTimer += Time.unscaledDeltaTime;
		_ = dogSpawningPhysics;
		if (dogSpawningPhysics.IsValid())
		{
			while (dogSpawningPhysicsTimer >= Time.fixedDeltaTime)
			{
				dogSpawningPhysicsTimer -= Time.fixedDeltaTime;
				dogSpawningPhysics.Simulate(Time.fixedDeltaTime);
			}
		}
	}

	public void MoveObjectToDogSpawningScene(GameObject obj)
	{
		SceneManager.MoveGameObjectToScene(obj, dogSpawningScene);
	}

	public void ProcessDogRequests()
	{
		if (dogRequests.Count != 0 && currentDogRequest == null && (dogRequests[0].GetSpawnDuringPause() || !PauseController.IsPaused()))
		{
			isCurrentlyLoadingPlayerOwnedDog = dogRequests[0].IsPlayerOwned();
			if (dogRequests[0].GetExistingDog() != null)
			{
				currentlyLoadingDogUID = dogRequests[0].GetExistingDog().dogID;
			}
			else
			{
				currentlyLoadingDogUID = null;
			}
			currentDogRequestRef = dogRequests[0];
			currentDogRequest = StartCoroutine(ProcessDogRequest(dogRequests[0]));
			dogRequests.RemoveAt(0);
		}
	}

	public void RequestNewDog(Vector3 pos, Quaternion rot, SaveableDogGene gene = null, SaveableDog existingDog = null, bool manualDog = false, DogRequest.DogRequestCallback callback = null, bool playerOwned = true, bool useBaseGeneWithoutMutation = false, bool timeslice = true, bool forceCacheThumbnails = false, bool dummyDog = false, SaveableDogProfile dogProfile = null, DogAge customDogAge = DogAge.NONE, float customDogAgeProgress = -1f, bool traitsAllowed = true, bool useTemporaryID = false, SaveableDogPersonality customDogPersonality = null, List<string> customFloraPool = null, bool respectMaxDogs = true, bool isGhost = false, float? customEndOfLifeModifier = null, float? customLifeExtension = null, bool spawnDuringPause = true, bool customEmptyGut = false)
	{
		int numberOfOwnedAndLoadingDogsIncludingGhosts = GetNumberOfOwnedAndLoadingDogsIncludingGhosts();
		if (playerOwned && numberOfOwnedAndLoadingDogsIncludingGhosts >= maxDogs && respectMaxDogs)
		{
			if ((isGhost && (existingDog == null || existingDog.isGhost)) || GetNumberOfOwnedAndLoadingDogsMinusGhosts() >= maxDogs)
			{
				callback?.Invoke(null);
				return;
			}
			ghostManagerRef.DespawnOldestGhost();
		}
		if (gene != null)
		{
			gene = gene.GetCopy();
			MasterDogGene.MigrateSaveableDogGene(gene);
		}
		DogRequest item = new DogRequest(pos, rot, gene, existingDog, manualDog, callback, playerOwned, useBaseGeneWithoutMutation, timeslice, forceCacheThumbnails, dummyDog, dogProfile, customDogAge, customDogAgeProgress, traitsAllowed, useTemporaryID, customDogPersonality, customFloraPool, isGhost, customEndOfLifeModifier, customLifeExtension, spawnDuringPause, customEmptyGut);
		dogRequests.Add(item);
	}

	private IEnumerator ProcessDogRequest(DogRequest request)
	{
		Transform transform = Camera.main.transform;
		Vector3 position = transform.position - transform.forward * 500f;
		GameObject newDog = (request.IsManual() ? UnityEngine.Object.Instantiate(globalDogManualPrefab, position, Quaternion.identity) : UnityEngine.Object.Instantiate(globalDogprefab, position, Quaternion.identity));
		SaveableDogGene gene = request.GetGene();
		if (gene != null)
		{
			MasterDogGene.MigrateSaveableDogGene(gene);
			newDog.GetComponent<DogLooks>().SetGenetics(gene);
		}
		if (request.GetUseBaseGeneWithoutMutation())
		{
			newDog.GetComponent<DogLooks>().UseUnmutatedBaseGenome();
		}
		if (sceneRef.HasSceneStarted() && !sceneRef.IsBreedingScene())
		{
			MoveObjectToDogSpawningScene(newDog);
		}
		currentDogCreationSubRequest = StartCoroutine(newDog.GetComponent<DogCreation>().Create(request.GetExistingDog(), playerOwned: request.IsPlayerOwned(), dummyDog: request.GetDummyDog(), timeslice: request.Timeslice(), forceCacheThumbnails: request.GetForceCacheThumbnails(), dogProfile: request.GetDogProfile(), customDogAge: request.GetCustomDogAge(), customDogAgeProgress: request.GetCustomDogAgeProgress(), traitsAllowed: request.GetTraitsAllowed(), useTemporaryID: request.GetUseTemporaryID(), customPersonality: request.GetDogPersonality(), customFloraPool: request.GetCustomFloraPool(), isGhost: request.GetIsGhost(), customEndOfLifeModifier: request.GetCustomEndOfLifeModifier(), customLifeExtension: request.GetCustomLifeExtension(), customEmptyGut: request.GetCustomEmptyGut()));
		yield return currentDogCreationSubRequest;
		currentDogCreationSubRequest = null;
		if (request.Timeslice())
		{
			yield return new WaitForEndOfFrame();
		}
		try
		{
			BoundingBoxComponent component = newDog.GetComponent<BoundingBoxComponent>();
			component.ForceUpdateBoundingBox();
			newDog.transform.position = request.GetPos();
			newDog.transform.rotation = request.GetRot();
			if (newDog.scene != dogSpawningScene && !component.MoveToGoodLocation())
			{
				Debug.LogError("No valid placement position for spawned dog: " + newDog.name);
			}
		}
		catch
		{
			throw;
		}
		finally
		{
			try
			{
				request?.GetCallback()?.Invoke(newDog);
			}
			catch
			{
				throw;
			}
			finally
			{
				currentDogRequest = null;
				currentDogRequestRef = null;
				currentlyLoadingDogUID = null;
				currentDogCreationSubRequest = null;
				isCurrentlyLoadingPlayerOwnedDog = false;
				if (!thumbnailRef.GetCurrentlySelectedDogID().HasValue)
				{
					thumbnailRef.SelectNextDog();
				}
				if (GetInWorldOwnedDogsCount() == GetMaxDogs())
				{
					GoalsController.SetGoalEvent(GoalCondition.MAX_DOGS_IN_PEN, 1);
				}
				if (dogLoadInProgress && dogRequests.Count == 0)
				{
					OnAllDogsLoaded();
				}
			}
		}
	}

	public void MakeDogSuitableForUIDisplay(GameObject dog)
	{
		dog.GetComponent<DogAI>().SetEnabled(enabledVal: false);
		dog.GetComponent<DoggyBrain>().SetIsDisplayDog();
		dog.GetComponent<DogNoises>().SetVocalizationAllowed(val: false);
		DogLooks component = dog.GetComponent<DogLooks>();
		if (component.leftWing != null)
		{
			List<WingController> list = new List<WingController>();
			list.AddRange(component.leftWing.GetComponentsInChildren<WingController>());
			for (int i = 0; i < list.Count; i++)
			{
				list[i].SetWingState(WingController.WingState.FLAP);
			}
		}
		if (component.rightWing != null)
		{
			List<WingController> list2 = new List<WingController>();
			list2.AddRange(component.rightWing.GetComponentsInChildren<WingController>());
			for (int j = 0; j < list2.Count; j++)
			{
				list2[j].SetWingState(WingController.WingState.FLAP);
			}
		}
		UnityEngine.Object.Destroy(dog.GetComponent<CocoonController>());
		UnityEngine.Object.Destroy(dog.GetComponent<DogIndicatorController>());
		UnityEngine.Object.Destroy(dog.GetComponent<DogEggLayingController>());
		LegController component2 = dog.GetComponent<LegController>();
		if (component2 != null)
		{
			Rigidbody component3 = component2.bodyBack.GetComponent<Rigidbody>();
			Rigidbody component4 = component2.bodyFront.GetComponent<Rigidbody>();
			component3.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
			component4.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
			component3.isKinematic = true;
			component4.isKinematic = true;
		}
		UnityEngine.Object.Destroy(dog.GetComponent<LegController>());
	}

	private void UpdateLegCollision(LegController refA, LegController refB)
	{
		if (refB.collisionHelperBack == null)
		{
			return;
		}
		List<GameObject> allLegs = refA.GetAllLegs();
		for (int i = 0; i < allLegs.Count; i++)
		{
			Transform parent = allLegs[i].transform.parent;
			for (int j = 0; j < parent.childCount; j++)
			{
				Transform child = parent.GetChild(j);
				Collider component = child.GetComponent<Collider>();
				if (component == null)
				{
					continue;
				}
				Physics.IgnoreCollision(refB.collisionHelperBack.GetComponent<Collider>(), component);
				Physics.IgnoreCollision(refB.collisionHelperFront.GetComponent<Collider>(), component);
				if (child.childCount <= 0)
				{
					continue;
				}
				for (int k = 0; k < child.childCount; k++)
				{
					Collider component2 = child.GetChild(k).GetComponent<Collider>();
					if (component2 != null)
					{
						Physics.IgnoreCollision(refB.collisionHelperBack.GetComponent<Collider>(), component2);
						Physics.IgnoreCollision(refB.collisionHelperFront.GetComponent<Collider>(), component2);
					}
				}
			}
		}
	}

	private void UpdateBodyCollision(LegController refA, LegController refB)
	{
		if (refB.collisionHelperBackBody == null)
		{
			return;
		}
		Collider[] componentsInChildren = refA.collisionHelperBackBody.GetComponentsInChildren<Collider>();
		foreach (Collider collider in componentsInChildren)
		{
			Physics.IgnoreCollision(collider, refB.bodyFront.GetComponent<Collider>());
			Physics.IgnoreCollision(collider, refB.bodyBack.GetComponent<Collider>());
			Collider[] componentsInChildren2 = refB.bodyFront.GetComponentsInChildren<Collider>();
			foreach (Collider collider2 in componentsInChildren2)
			{
				Physics.IgnoreCollision(collider, collider2);
			}
		}
		componentsInChildren = refA.collisionHelperFrontBody.GetComponentsInChildren<Collider>();
		foreach (Collider collider3 in componentsInChildren)
		{
			Physics.IgnoreCollision(collider3, refB.bodyFront.GetComponent<Collider>());
			Physics.IgnoreCollision(collider3, refB.bodyBack.GetComponent<Collider>());
			Collider[] componentsInChildren2 = refB.bodyFront.GetComponentsInChildren<Collider>();
			foreach (Collider collider4 in componentsInChildren2)
			{
				Physics.IgnoreCollision(collider3, collider4);
			}
		}
	}
}
