using UnityEngine;

public class Hole : MonoBehaviour
{
	public InventoryItem dirtClump;

	public InventoryItem snowball;

	public InventoryItem capsule;

	public InventoryItem gift;

	public InventoryItem fishPellet;

	public InventoryItem insulationTuft;

	public GameObject holeInvisible;

	public GameObject holeEmpty;

	public GameObject holeFilled;

	public GameObject objectDugUpParticles;

	public GameObject objectDugUpParticlesSnow;

	public GameObject seedGUIPrefab;

	public MeshRenderer holeBaseOpenRenderer;

	public MeshRenderer holeBaseClosedRenderer;

	public MeshRenderer holeOpenRenderer;

	public MeshRenderer holeClosedRenderer;

	public Material baseMat;

	public Material snowBaseMat;

	public Material openMat;

	public Material snowOpenMat;

	public Material closedMat;

	public Material snowClosedMat;

	public GameObject actionParticles;

	private string objectDestroySound = "object_destroy";

	private bool inSnow;

	private int clumpMin = 1;

	private int clumpMax = 5;

	private float dirtScaleMultRangeLow = -0.3f;

	private float dirtScaleMultRangeHigh = 0.25f;

	private SaveableTaggedObjectNoDepth containedObject;

	private float objectSpawnChance = 0.6f;

	private float researchChance = 0.35f;

	private float seedChance = 0.7f;

	private float denUpgradeChance = 0.2f;

	private float giftChance = 0.85f;

	private float themedFoodChance = 0.85f;

	private float clumpForce = 50f;

	private string dirtCreateSound = "dirt_spawn";

	private string buryObjectSound = "create_hole";

	private string digUpObjectSound = "create_hole";

	private bool isShuttingDown;

	private bool markedForDestroyFromTravel;

	private HoleStage currentStage;

	private float currentTimer;

	private float autoCleanupTimer = 10f;

	private float autoCleanupJiggle = 5f;

	private void Awake()
	{
		ClearStages();
		SetStage(currentStage);
		currentTimer = Random.Range(0f - autoCleanupJiggle, 0f);
	}

	private void Update()
	{
		if (GameSettings.IsPassiveModeEnabled() && GameSettings.PassiveModeAutoClearHole())
		{
			currentTimer += Time.deltaTime;
			if (currentTimer >= autoCleanupTimer)
			{
				Vector3 objCenter = ObjectUtil.GetObjCenter(base.gameObject);
				Object.Instantiate(actionParticles, objCenter, Quaternion.identity);
				AudioController.Play(objectDestroySound, objCenter);
				FillIn();
			}
		}
	}

	public void Save(SaveablePlacedObject saveableObject)
	{
		saveableObject.boolList.Add(inSnow);
		saveableObject.intList.Add((int)currentStage);
		saveableObject.taggedObjectA = containedObject;
	}

	public void Load(SaveablePlacedObject saveableObject)
	{
		ClearStages();
		SetStage((HoleStage)saveableObject.intList[0]);
		containedObject = saveableObject.taggedObjectA;
		if (saveableObject.boolList != null && saveableObject.boolList.Count > 0)
		{
			inSnow = saveableObject.boolList[0];
			RefreshMaterials(inSnow);
		}
	}

	public void MarkForTravel()
	{
		markedForDestroyFromTravel = true;
	}

	private void OnApplicationQuit()
	{
		isShuttingDown = true;
	}

	private void OnDestroy()
	{
		if (!isShuttingDown && !markedForDestroyFromTravel)
		{
			RemoveContainedObject();
		}
	}

	public void OnRoomDestroyed()
	{
		RemoveContainedObject(destroyAfterRemoval: true);
	}

	public bool IsInSnow()
	{
		return inSnow;
	}

	public void RefreshMaterials(bool? inSnowCategoryToForce = null, bool? inAquariumCategoryToForce = null, bool? inBasementCategoryToForce = null)
	{
		if (!inSnowCategoryToForce.HasValue)
		{
			bool flag = GetFloorCategory() == ItemSet.WINTER;
			if (inSnow == flag)
			{
				return;
			}
			inSnow = flag;
		}
		else
		{
			inSnow = inSnowCategoryToForce.Value;
		}
		if (inSnow)
		{
			holeOpenRenderer.material = snowOpenMat;
			holeClosedRenderer.material = snowClosedMat;
			holeBaseOpenRenderer.material = snowBaseMat;
			holeBaseClosedRenderer.material = snowBaseMat;
		}
		else
		{
			holeOpenRenderer.material = openMat;
			holeClosedRenderer.material = closedMat;
			holeBaseOpenRenderer.material = baseMat;
			holeBaseClosedRenderer.material = baseMat;
		}
	}

	public void OpenSeedGUI()
	{
		Object.Instantiate(seedGUIPrefab).GetComponent<SeedPlantingGUIController>().SetHoleRef(this);
	}

	public void PlantSeed(InventoryItem seedRef)
	{
		ulong? roomUID = GetComponent<BoundingBoxComponent>().GetRoomUID();
		if (!roomUID.HasValue)
		{
			Debug.LogError("Something went wrong! This hole somehow isn't inside of a room.");
			return;
		}
		RoomBase roomForUID = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME).GetRoomForUID(roomUID.Value);
		ObjectPlacementManager.RemoveObjectManually(roomForUID.GetPlacedObjectInfoForObject(base.gameObject), roomForUID);
		Vector2Int gridSquareForPositionAndRoom = ObjectPlacementManager.GetGridSquareForPositionAndRoom(GetComponent<BoundingBoxComponent>().GetBoxCenter(), roomForUID, !seedRef.placeableObjectOverride);
		if (seedRef.placeableObjectOverride)
		{
			ObjectPlacementManager.PlaceObjectManually(roomForUID, seedRef.itemPrefab.GetComponent<SeedPacket>().containedPlant, gridSquareForPositionAndRoom);
		}
		else
		{
			ObjectPlacementManager.PlacePlant(roomForUID, seedRef.itemPrefab.GetComponent<SeedPacket>().containedPlant, gridSquareForPositionAndRoom);
		}
		GoalsController.ReportGoalEvent(GoalCondition.PLANT_SEED);
	}

	public void FillIn()
	{
		DogHome globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		ulong? roomUID = GetComponent<BoundingBoxComponent>().GetRoomUID();
		if (!roomUID.HasValue)
		{
			Debug.LogError("No room found for hole.");
			return;
		}
		RoomBase roomForUID = globalComponent.GetRoomForUID(roomUID.Value);
		ObjectPlacementManager.RemoveObjectManually(roomForUID.GetPlacedObjectInfoForObject(base.gameObject), roomForUID);
	}

	public void BuryObject(GameObject obj)
	{
		if (currentStage == HoleStage.FILLED)
		{
			return;
		}
		if (containedObject != null)
		{
			Debug.LogError("Attempting to bury an object in a hole that already has a contained object.");
			return;
		}
		GameObject original = (inSnow ? objectDugUpParticlesSnow : objectDugUpParticles);
		GoalsController.ReportGoalEvent(GoalCondition.BURY_OBJECT);
		AudioController.Play(buryObjectSound, base.transform.position);
		if (obj.CompareTag(Tags.SEED_PACKET))
		{
			obj.GetComponent<RegisterTaggedObject>().SetSafeDestroy();
			PlantSeed(obj.GetComponent<ObjectID>().item);
			Object.Instantiate(original, GetComponent<BoundingBoxComponent>().GetBoxCenter(), Quaternion.identity);
			Object.Destroy(obj);
			return;
		}
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		InventoryManager globalComponent = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		containedObject = registrationScript.GetSaveableTaggedObjectForObject(globalComponent, obj, saveGameObjectInfo: false);
		RegisterTaggedObject component = obj.GetComponent<RegisterTaggedObject>();
		if (component != null)
		{
			component.SetSafeDestroy();
		}
		Object.Instantiate(original, GetComponent<BoundingBoxComponent>().GetBoxCenter(), Quaternion.identity);
		Object.Destroy(obj);
		SetStage(HoleStage.FILLED);
	}

	public void DigUp()
	{
		if (currentStage != HoleStage.EMPTY)
		{
			AudioController.Play(digUpObjectSound, base.transform.position);
			SetStage(HoleStage.EMPTY);
			RemoveContainedObject();
		}
	}

	private void RemoveContainedObject(bool destroyAfterRemoval = false)
	{
		if (containedObject == null)
		{
			return;
		}
		GameObject gameObject = null;
		try
		{
			ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
			InventoryManager globalComponent = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
			gameObject = registrationScript.LoadTaggedObject(globalComponent, containedObject.GetCopy(), loadComponents: true, tryLoadFullObject: false);
		}
		finally
		{
			containedObject = null;
		}
		if (gameObject == null)
		{
			return;
		}
		if (destroyAfterRemoval)
		{
			Object.Destroy(gameObject);
			return;
		}
		gameObject.transform.position = base.transform.position;
		BoundingBoxComponent boundingBoxComponent = gameObject.GetComponent<BoundingBoxComponent>();
		if (boundingBoxComponent == null)
		{
			boundingBoxComponent = gameObject.AddComponent<BoundingBoxComponent>();
		}
		boundingBoxComponent.MoveToGoodLocation();
		Object.Instantiate(inSnow ? objectDugUpParticlesSnow : objectDugUpParticles, GetComponent<BoundingBoxComponent>().GetBoxCenter(), Quaternion.identity);
	}

	private ItemSet GetFloorCategory()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		ItemSet result = ItemSet.NONE;
		ulong? roomUID = GetComponent<BoundingBoxComponent>().GetRoomUID();
		if (!roomUID.HasValue)
		{
			Debug.LogError("Invalid room UID for hole.");
		}
		else
		{
			result = registrationScript.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER).GetObjectForUID(roomUID.Value).GetComponent<RoomBase>()
				.GetCurrentCarpet()
				.associatedItemSet;
		}
		return result;
	}

	public void CreateClumps()
	{
		RefreshMaterials();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		ResearchManager globalComponent = registrationScript.GetGlobalComponent<ResearchManager>(GlobalObject.RESEARCH_MANAGER);
		InventoryManager globalComponent2 = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		DogHome globalComponent3 = registrationScript.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		Vector3 position = base.transform.position;
		bool flag = Random.value <= objectSpawnChance;
		bool flag2 = false;
		InventoryItem item = dirtClump;
		ItemSet floorCategory = GetFloorCategory();
		if (IsInSnow())
		{
			item = snowball;
		}
		int num = Random.Range(clumpMin, clumpMax);
		while (num > 0)
		{
			num--;
			GameObject gameObject;
			if (!flag || flag2)
			{
				gameObject = globalComponent3.TrySpawnItem(item, position);
				gameObject.transform.localScale += gameObject.transform.localScale * Random.Range(dirtScaleMultRangeLow, dirtScaleMultRangeHigh);
			}
			else
			{
				flag2 = true;
				if (IsInSnow() && Random.value < giftChance)
				{
					gameObject = globalComponent3.TrySpawnItem(gift, position);
				}
				else if (CheatEngine.fishPackEnabled && floorCategory == ItemSet.FISH && Random.value < themedFoodChance)
				{
					gameObject = globalComponent3.TrySpawnItem(fishPellet, position);
				}
				else if (CheatEngine.basementPackEnabled && floorCategory == ItemSet.BASEMENT && Random.value < themedFoodChance)
				{
					gameObject = globalComponent3.TrySpawnItem(insulationTuft, position);
				}
				else if (!globalComponent.DoesUnlockedResearchExist() || Random.value > researchChance)
				{
					ItemType typeToSpawn = ItemType.TOY;
					if (Random.value <= seedChance)
					{
						typeToSpawn = ((!(Random.value < denUpgradeChance)) ? ItemType.SEED_PACKET : ItemType.DEN_UPGRADE);
					}
					InventoryItem randomItemOfType = globalComponent2.GetRandomItemOfType(typeToSpawn, floorCategory);
					if (randomItemOfType == null)
					{
						gameObject = globalComponent3.TrySpawnItem(item, position);
						gameObject.transform.localScale += gameObject.transform.localScale * Random.Range(dirtScaleMultRangeLow, dirtScaleMultRangeHigh);
					}
					else
					{
						gameObject = globalComponent3.TrySpawnItem(randomItemOfType, position);
					}
				}
				else
				{
					gameObject = globalComponent3.TrySpawnItem(capsule, position);
				}
			}
			AddForceToSpawnedObject(gameObject);
		}
	}

	public void AddForceToSpawnedObject(GameObject obj)
	{
		Rigidbody componentInChildren = obj.GetComponentInChildren<Rigidbody>();
		componentInChildren.AddRelativeForce(Vector3.up * clumpForce);
		componentInChildren.AddRelativeTorque(Random.rotation.eulerAngles * clumpForce);
		AudioController.Play(dirtCreateSound, componentInChildren.transform.position);
	}

	public HoleStage GetCurrentHoleStage()
	{
		return currentStage;
	}

	public void SetStage(HoleStage newStage)
	{
		GetObjectForStage(currentStage).SetActive(value: false);
		currentStage = newStage;
		GetObjectForStage(currentStage).SetActive(value: true);
		GetComponent<BoundingBoxComponent>().ForceUpdateBoundingBox();
	}

	public GameObject GetObjectForStage(HoleStage stage)
	{
		switch (stage)
		{
		case HoleStage.INVISIBLE:
			return holeInvisible;
		case HoleStage.EMPTY:
			return holeEmpty;
		case HoleStage.FILLED:
			return holeFilled;
		default:
			Debug.LogError("No object listed for den stage: " + stage);
			return null;
		}
	}

	private void ClearStages()
	{
		foreach (HoleStage value in EnumUtils.GetValues<HoleStage>())
		{
			GetObjectForStage(value).SetActive(value: false);
		}
	}
}
