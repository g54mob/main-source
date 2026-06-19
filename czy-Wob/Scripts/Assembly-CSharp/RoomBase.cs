using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

public class RoomBase : MonoBehaviour
{
	public RoomCustomizationObject defaultCarpet;

	public RoomCustomizationObject defaultWallpaper;

	public GameObject objectDestructionParticles;

	private string objectDestructionSFX = "object_destroy";

	public Material ceilingMaterial;

	public Transform focusTransform;

	public BuildableObject associatedBuildableObject;

	public List<WallBase> allWalls = new List<WallBase>();

	public Renderer frameFrontTop;

	public Renderer frameFrontLeft;

	public Renderer frameFrontRight;

	public Renderer frameLeftTop;

	public Renderer frameRightTop;

	public Renderer frameBackTop;

	public Renderer frameBackLeft;

	public Renderer frameBackRight;

	public Renderer frameConnectorFrontLeft;

	public Renderer frameConnectorFrontRight;

	public Renderer frameConnectorBackLeft;

	public Renderer frameConnectorBackRight;

	public float behaviorScoreMultiplier = 1f;

	private ConstructionManager.ConfirmRoomDestructionDelegate roomDestructionConfirmationCallback;

	private RoomCustomizationObject currentCarpet;

	private RoomCustomizationObject currentWallpaper;

	private float objectSpookiness;

	private float carpetWallSpookiness;

	private float maxObjectSpookiness = 0.5f;

	private float spookinessFromObject = 0.05f;

	private float spookinessFromWallCarpet = 0.25f;

	private int numberOfDensToBuild = 1;

	private int maxDensPerRoom = 4;

	private Coroutine currentMassCleanRoutine;

	private float isolationScore;

	private bool isolationScoreInitialized;

	private float dogPositionDecayRate = 0.1f;

	private float lastDogTrafficScore;

	private int lastDogTrafficScoreUpdateFrame = -1;

	private List<Vector2Int> reservedTiles = new List<Vector2Int>();

	private List<Vector2Int> reservedTilesForPlacement = new List<Vector2Int>();

	private Dictionary<Vector2Int, ulong> reservedTileForPlacementToOwningDogUID = new Dictionary<Vector2Int, ulong>();

	private List<List<ulong?>> plantGrid = new List<List<ulong?>>();

	private List<List<ulong?>> puddleGrid = new List<List<ulong?>>();

	private List<List<int>> groundPlacementGrid = new List<List<int>>();

	private List<List<float>> dogPositionGrid = new List<List<float>>();

	private List<List<float>> groundIsolationGrid = new List<List<float>>();

	private List<PlacedObjectInfo> placedPlants = new List<PlacedObjectInfo>();

	private List<PlacedObjectInfo> placedPuddles = new List<PlacedObjectInfo>();

	private List<PlacedObjectInfo> placedObjects = new List<PlacedObjectInfo>();

	private List<GameObject> currentExpansionNodes = new List<GameObject>();

	private int numberOfPlacedObjectsAffectingGravity;

	private List<ulong> placedObjectsAffectingGravity = new List<ulong>();

	private Dictionary<ulong, float> placedObjectUIDToGravModDict = new Dictionary<ulong, float>();

	private int numberOfPlacedObjectsPlayingMusic;

	private BoundingBoxComponent bbc;

	private ObjectRegistration regRef;

	private DogRegistration dogRegRef;

	private SceneManagerBase sceneRef;

	private InventoryManager inventoryRef;

	private void Awake()
	{
		sceneRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
		for (int i = 0; i < allWalls.Count; i++)
		{
			allWalls[i].attachedRoom = this;
		}
		regRef = ObjectRegistration.GetRegistrationScript();
		dogRegRef = regRef.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		inventoryRef = regRef.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		ApplyCarpet(defaultCarpet, fromLoad: true);
		ApplyWallpaper(defaultWallpaper, fromLoad: true);
	}

	private void Update()
	{
		DecayDogPositions();
	}

	public void EnableFrame()
	{
		frameFrontTop.enabled = true;
		frameFrontLeft.enabled = true;
		frameFrontRight.enabled = true;
		frameLeftTop.enabled = true;
		frameRightTop.enabled = true;
		frameBackTop.enabled = true;
		frameBackLeft.enabled = true;
		frameBackRight.enabled = true;
		frameConnectorFrontLeft.enabled = true;
		frameConnectorFrontRight.enabled = true;
		frameConnectorBackLeft.enabled = true;
		frameConnectorBackRight.enabled = true;
	}

	public int GetNumberOfDensToBuild()
	{
		return numberOfDensToBuild;
	}

	public void UpdateNumberOfDensToBuild(int newValue)
	{
		numberOfDensToBuild = Mathf.Clamp(newValue, 0, maxDensPerRoom);
	}

	public void MovePosition(Vector3 newPos, bool newRoom = false)
	{
		if (newRoom)
		{
			base.transform.position = newPos;
			return;
		}
		Vector3 position = base.transform.position;
		Vector3 vector = newPos - position;
		for (int i = 0; i < placedObjects.Count; i++)
		{
			placedObjects[i].objectRef.SetActive(value: false);
			StartCoroutine(RefreshRoutine(placedObjects[i].objectRef, placedObjects[i].objectRef.transform.position + vector));
		}
		for (int j = 0; j < placedPlants.Count; j++)
		{
			placedPlants[j].objectRef.SetActive(value: false);
			StartCoroutine(RefreshRoutine(placedPlants[j].objectRef, placedPlants[j].objectRef.transform.position + vector));
		}
		for (int k = 0; k < placedPuddles.Count; k++)
		{
			placedPuddles[k].objectRef.SetActive(value: false);
			StartCoroutine(RefreshRoutine(placedPuddles[k].objectRef, placedPuddles[k].objectRef.transform.position + vector));
		}
		BoundingBoxComponent bBC = GetBBC();
		List<GameObject> allObjectsForTag = regRef.GetAllObjectsForTag(TagsEnum.ALL);
		for (int l = 0; l < allObjectsForTag.Count; l++)
		{
			BoundingBoxComponent component = allObjectsForTag[l].GetComponent<BoundingBoxComponent>();
			if (!bBC.CheckBoxIntersect(component))
			{
				continue;
			}
			if (allObjectsForTag[l].CompareTag(Tags.COCOON))
			{
				Cocoon component2 = allObjectsForTag[l].GetComponent<Cocoon>();
				ConfigurableJoint attachmentJoint = component2.GetAttachmentJoint();
				if (attachmentJoint != null && attachmentJoint.connectedBody == null)
				{
					attachmentJoint.connectedAnchor += vector;
				}
				component2.rigidbodyRef.WakeUp();
			}
			allObjectsForTag[l].transform.position += vector;
		}
		base.transform.position = newPos;
	}

	public List<GameObject> GetAllFreeObjects()
	{
		BoundingBoxComponent bBC = GetBBC();
		List<GameObject> allObjectsForTag = regRef.GetAllObjectsForTag(TagsEnum.ALL);
		for (int num = allObjectsForTag.Count - 1; num >= 0; num--)
		{
			BoundingBoxComponent component = allObjectsForTag[num].GetComponent<BoundingBoxComponent>();
			if (!bBC.CheckBoxIntersect(component))
			{
				allObjectsForTag.RemoveAt(num);
			}
			else if (allObjectsForTag[num].CompareTag(Tags.COCOON))
			{
				allObjectsForTag.RemoveAt(num);
			}
		}
		return allObjectsForTag;
	}

	public void AddMusicPlayer()
	{
		numberOfPlacedObjectsPlayingMusic++;
	}

	public void RemoveMusicPlayer()
	{
		numberOfPlacedObjectsPlayingMusic--;
	}

	public int GetNumberOfActiveMusicPlayers()
	{
		return numberOfPlacedObjectsPlayingMusic;
	}

	public void AddGravMod(ulong placedObjectUID, float mod)
	{
		if (!placedObjectsAffectingGravity.Contains(placedObjectUID))
		{
			placedObjectsAffectingGravity.Add(placedObjectUID);
		}
		placedObjectUIDToGravModDict[placedObjectUID] = mod;
		numberOfPlacedObjectsAffectingGravity = placedObjectsAffectingGravity.Count;
	}

	public void RemoveGravMod(ulong placedObjectUID)
	{
		if (!placedObjectsAffectingGravity.Contains(placedObjectUID))
		{
			Debug.LogError("Attempting to remove a gravity mod that hasn't been added.");
			return;
		}
		placedObjectUIDToGravModDict.Remove(placedObjectUID);
		placedObjectsAffectingGravity.Remove(placedObjectUID);
		numberOfPlacedObjectsAffectingGravity = placedObjectsAffectingGravity.Count;
	}

	public float GetGravMod()
	{
		if (numberOfPlacedObjectsAffectingGravity == 0)
		{
			return 1f;
		}
		float num = 0f;
		for (int i = 0; i < placedObjectsAffectingGravity.Count; i++)
		{
			num += placedObjectUIDToGravModDict[placedObjectsAffectingGravity[i]];
		}
		return num / (float)placedObjectsAffectingGravity.Count;
	}

	public bool IsGravModActive()
	{
		return GetGravMod() != 1f;
	}

	public float GetSpookiness()
	{
		return carpetWallSpookiness + Mathf.Min(objectSpookiness, maxObjectSpookiness);
	}

	public bool ShowPreDestructionWarningIfNeeded(ConstructionManager.ConfirmRoomDestructionDelegate destructionCallback, GUIManagerPens penGUIRef)
	{
		for (int i = 0; i < placedObjects.Count; i++)
		{
			if (placedObjects[i] == null || !(placedObjects[i].objectRef != null))
			{
				continue;
			}
			if (placedObjects[i].objectRef.CompareTag(Tags.DOG_DEN))
			{
				DogDen component = placedObjects[i].objectRef.GetComponent<DogDen>();
				if (!(component == null))
				{
					string message = ScriptLocalization.GUI.GUI_BUILD_DIRTPATCHWARNING_BODY;
					if (component.IsCompleted())
					{
						message = ScriptLocalization.GUI.GUI_BUILD_DENWARNING_BODY;
					}
					if (roomDestructionConfirmationCallback != null)
					{
						Debug.LogError("Attempting to double set roomDestructionConfirmationCallback");
					}
					roomDestructionConfirmationCallback = destructionCallback;
					penGUIRef.RequestGenericPopup(ScriptLocalization.GUI.GUI_PLCMNT_DENWARNING_HEADER, message, ConfirmDestruction, CancelDestruction);
					return true;
				}
			}
			else
			{
				if (!placedObjects[i].objectRef.CompareTag(Tags.STORAGE_CHEST))
				{
					continue;
				}
				StorageChest component2 = placedObjects[i].objectRef.GetComponent<StorageChest>();
				if (!(component2 == null) && !component2.IsEmpty())
				{
					string gUI_BUILD_CHESTWARNING_BODY = ScriptLocalization.GUI.GUI_BUILD_CHESTWARNING_BODY;
					if (roomDestructionConfirmationCallback != null)
					{
						Debug.LogError("Attempting to double set roomDestructionConfirmationCallback");
					}
					roomDestructionConfirmationCallback = destructionCallback;
					penGUIRef.RequestGenericPopup(ScriptLocalization.GUI.GUI_PLCMNT_DENWARNING_HEADER, gUI_BUILD_CHESTWARNING_BODY, ConfirmDestruction, CancelDestruction);
					return true;
				}
			}
		}
		return false;
	}

	private void ConfirmDestruction()
	{
		roomDestructionConfirmationCallback(base.gameObject);
	}

	private void CancelDestruction()
	{
		roomDestructionConfirmationCallback = null;
	}

	private IEnumerator RefreshRoutine(GameObject obj, Vector3 newPos)
	{
		yield return new WaitForEndOfFrame();
		obj.transform.position = newPos;
		obj.SetActive(value: true);
	}

	public void PrepareForTravel()
	{
		StopMassCleanRoutine();
	}

	private void StopMassCleanRoutine()
	{
		if (currentMassCleanRoutine != null)
		{
			StopCoroutine(currentMassCleanRoutine);
			currentMassCleanRoutine = null;
		}
	}

	public void DestroyInternal()
	{
		StopMassCleanRoutine();
		List<PlacedObjectInfo> list = new List<PlacedObjectInfo>();
		list.AddRange(placedObjects);
		for (int num = list.Count - 1; num >= 0; num--)
		{
			OnObjectRemoved(list[num], fromDestroy: true, fromRoomDestruction: true);
			Object.Destroy(list[num].objectRef);
		}
		if ((float)placedObjects.Count > 0f)
		{
			placedObjects.Clear();
			Debug.LogError("Not all objects removed!");
		}
		list.Clear();
		list.AddRange(placedPlants);
		for (int num2 = list.Count - 1; num2 >= 0; num2--)
		{
			OnObjectRemoved(list[num2], fromDestroy: true, fromRoomDestruction: true, forPlants: true);
			Object.Destroy(list[num2].objectRef);
		}
		if ((float)placedObjects.Count > 0f)
		{
			placedObjects.Clear();
			Debug.LogError("Not all plants removed!");
		}
		list.Clear();
		list.AddRange(placedPuddles);
		for (int num3 = list.Count - 1; num3 >= 0; num3--)
		{
			OnObjectRemoved(list[num3], fromDestroy: true, fromRoomDestruction: true, forPlants: false, forPuddles: true);
			Object.Destroy(list[num3].objectRef);
		}
		if ((float)placedObjects.Count > 0f)
		{
			placedObjects.Clear();
			Debug.LogError("Not all puddles removed!");
		}
		BoundingBoxComponent component = GetComponent<BoundingBoxComponent>();
		List<GameObject> allObjectsForTag = regRef.GetAllObjectsForTag(TagsEnum.ALL);
		for (int num4 = allObjectsForTag.Count - 1; num4 >= 0; num4--)
		{
			BoundingBoxComponent component2 = allObjectsForTag[num4].GetComponent<BoundingBoxComponent>();
			if (component.CheckBoxIntersect(component2))
			{
				Object.Destroy(allObjectsForTag[num4]);
			}
		}
	}

	public PlacedObjectInfo GetPlacedObjectInfoForObject(GameObject obj, bool forPlants = false)
	{
		PlacedObjectID component = obj.GetComponent<PlacedObjectID>();
		if (component == null)
		{
			return null;
		}
		bool flag = obj.CompareTag(Tags.PHYSICS_PLANT);
		if (forPlants != flag)
		{
			return null;
		}
		if (forPlants)
		{
			for (int i = 0; i < placedPlants.Count; i++)
			{
				if (placedPlants[i].objectID == component.GetUID())
				{
					return placedPlants[i];
				}
			}
			return null;
		}
		for (int j = 0; j < placedObjects.Count; j++)
		{
			if (placedObjects[j].objectID == component.GetUID())
			{
				return placedObjects[j];
			}
		}
		return null;
	}

	public void OnObjectPlaced(PlacedObjectInfo placementInfo, List<Vector2Int> placementTiles, SaveablePlacedObject existingObject = null, bool ignoreDogs = false, bool plant = false, bool puddle = false, bool forceClearExistingPlants = false)
	{
		bool flag = false;
		PlacedObjectID placedObjectID = placementInfo.objectRef.GetComponent<PlacedObjectID>();
		if (existingObject == null)
		{
			if (placedObjectID == null)
			{
				placedObjectID = placementInfo.objectRef.AddComponent<PlacedObjectID>();
				placedObjectID.SetUID(ObjectPlacementManager.GetNewPlaceableID(plant, puddle));
				placedObjectID.SetResourceString(inventoryRef.GetPathForCustomizationObject(placementInfo.customizationRef));
			}
		}
		else if (placedObjectID == null)
		{
			placedObjectID = placementInfo.objectRef.AddComponent<PlacedObjectID>();
			placedObjectID.SetUID(existingObject.UID);
			placedObjectID.SetResourceString(existingObject.resourceString);
			flag = true;
		}
		if (!plant && !puddle && placementInfo != null && placementInfo.customizationRef != null && placementInfo.customizationRef.associatedItemSet == ItemSet.SPOOKY)
		{
			objectSpookiness += spookinessFromObject;
		}
		placementInfo.objectID = placedObjectID.GetUID();
		if (plant)
		{
			placedPlants.Add(placementInfo);
		}
		else if (puddle)
		{
			placedPuddles.Add(placementInfo);
		}
		else
		{
			placedObjects.Add(placementInfo);
		}
		RegisterTaggedObject component = placementInfo.objectRef.GetComponent<RegisterTaggedObject>();
		if (component != null)
		{
			component.ManualRegister();
		}
		if (flag)
		{
			LoadSavedPlaceableComponents(placementInfo, existingObject);
		}
		if (!forceClearExistingPlants && (plant || puddle))
		{
			return;
		}
		GameObject placementGrid = ObjectPlacementManager.GetPlacementGrid();
		List<GameObject> toIgnore = null;
		if (placementGrid != null)
		{
			toIgnore = new List<GameObject> { placementGrid };
		}
		if (!plant && !puddle)
		{
			ClearSpaceForObject(placementInfo.objectRef, ignoreDogs, toIgnore);
			List<ulong> list = new List<ulong>();
			for (int i = 0; i < placementTiles.Count; i++)
			{
				if (IsTileReservedForPlacement(placementTiles[i].x, placementTiles[i].y))
				{
					Vector2Int key = new Vector2Int(placementTiles[i].x, placementTiles[i].y);
					if (!list.Contains(reservedTileForPlacementToOwningDogUID[key]))
					{
						list.Add(reservedTileForPlacementToOwningDogUID[key]);
					}
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				dogRegRef.GetDogFromID(list[j]).GetComponent<DogAI>().ForceInterruptBehavior(placementInfo.objectRef);
			}
			if (TutorialController.IsTutorialActive())
			{
				TutorialController.OnObjectPlaced(placementInfo);
			}
		}
		if (plantGrid.Count != 0)
		{
			List<ulong> list2 = new List<ulong>();
			List<Vector2Int> list3 = new List<Vector2Int>();
			if (!plant)
			{
				list3.AddRange(ObjectPlacementManager.GetPlantGridSquaresForPlacementGridSquares(placementTiles));
			}
			else
			{
				list3.AddRange(placementTiles);
			}
			for (int k = 0; k < list3.Count; k++)
			{
				if (list3[k].x < plantGrid.Count && list3[k].y < plantGrid[list3[k].x].Count)
				{
					ulong? num = plantGrid[list3[k].x][list3[k].y];
					if (num.HasValue && !list2.Contains(num.Value))
					{
						list2.Add(num.Value);
					}
				}
			}
			for (int l = 0; l < list2.Count; l++)
			{
				ObjectPlacementManager.RemovePlantManually(GetPlantInfoForUID(list2[l]), this);
			}
		}
		if (puddleGrid.Count == 0 || plant || puddle)
		{
			return;
		}
		List<ulong> list4 = new List<ulong>();
		List<Vector2Int> puddleGridSquaresForPlacementGridSquares = ObjectPlacementManager.GetPuddleGridSquaresForPlacementGridSquares(placementTiles);
		for (int m = 0; m < puddleGridSquaresForPlacementGridSquares.Count; m++)
		{
			if (puddleGridSquaresForPlacementGridSquares[m].x < puddleGrid.Count && puddleGridSquaresForPlacementGridSquares[m].y < puddleGrid[puddleGridSquaresForPlacementGridSquares[m].x].Count)
			{
				ulong? num2 = puddleGrid[puddleGridSquaresForPlacementGridSquares[m].x][puddleGridSquaresForPlacementGridSquares[m].y];
				if (num2.HasValue && !list4.Contains(num2.Value))
				{
					list4.Add(num2.Value);
				}
			}
		}
		for (int n = 0; n < list4.Count; n++)
		{
			ObjectPlacementManager.RemovePuddleManually(GetPuddleInfoForUID(list4[n]), this);
		}
	}

	public void ClearSpaceForObject(GameObject obj, bool ignoreDogs = false, List<GameObject> toIgnore = null)
	{
		ulong uID = GetComponent<BuildObjectInfo>().GetUID();
		BoundingBoxComponent component = obj.GetComponent<BoundingBoxComponent>();
		List<GameObject> allObjectsForTag = regRef.GetAllObjectsForTag(TagsEnum.ALL);
		for (int i = 0; i < allObjectsForTag.Count; i++)
		{
			if (!(allObjectsForTag[i] == obj) && (!ignoreDogs || !allObjectsForTag[i].transform.root.CompareTag(Tags.DOG)) && !(allObjectsForTag[i].GetComponent<PlaceableObject>() != null))
			{
				BoundingBoxComponent component2 = allObjectsForTag[i].GetComponent<BoundingBoxComponent>();
				if (component.CheckBoxIntersect(component2) && !component2.MoveToGoodLocation(uID, toIgnore))
				{
					Object.Destroy(allObjectsForTag[i]);
				}
			}
		}
	}

	public void OnObjectRemoved(PlacedObjectInfo placementInfo, bool fromDestroy, bool fromRoomDestruction = false, bool forPlants = false, bool forPuddles = false)
	{
		if (fromDestroy)
		{
			DogDen component = placementInfo.objectRef.GetComponent<DogDen>();
			if (component != null)
			{
				component.PreDestroy();
			}
			DogMemorial component2 = placementInfo.objectRef.GetComponent<DogMemorial>();
			if (component2 != null)
			{
				component2.OnRemovedFromRoom();
			}
			if (fromRoomDestruction)
			{
				Hole component3 = placementInfo.objectRef.GetComponent<Hole>();
				if (component3 != null)
				{
					component3.OnRoomDestroyed();
				}
			}
		}
		if (!forPlants && !forPuddles && placementInfo != null && placementInfo.customizationRef != null && placementInfo.customizationRef.associatedItemSet == ItemSet.SPOOKY)
		{
			objectSpookiness -= spookinessFromObject;
		}
		RegisterTaggedObject component4 = placementInfo.objectRef.GetComponent<RegisterTaggedObject>();
		if (component4 != null)
		{
			component4.ManualUnregister();
		}
		if (forPlants)
		{
			for (int i = 0; i < placedPlants.Count; i++)
			{
				if (placedPlants[i].objectID == placementInfo.objectID)
				{
					placedPlants.RemoveAt(i);
					break;
				}
			}
			return;
		}
		if (forPuddles)
		{
			for (int j = 0; j < placedPuddles.Count; j++)
			{
				if (placedPuddles[j].objectID == placementInfo.objectID)
				{
					placedPuddles.RemoveAt(j);
					break;
				}
			}
			return;
		}
		for (int k = 0; k < placedObjects.Count; k++)
		{
			if (placedObjects[k].objectID == placementInfo.objectID)
			{
				placedObjects.RemoveAt(k);
				break;
			}
		}
		if (fromDestroy && TutorialController.IsTutorialActive())
		{
			TutorialController.OnObjectRemoved(placementInfo);
		}
	}

	public void MassClean()
	{
		if (currentMassCleanRoutine == null)
		{
			currentMassCleanRoutine = StartCoroutine(MassCleanRoutine());
		}
	}

	private IEnumerator MassCleanRoutine()
	{
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		BoundingBoxComponent bbc = GetBBC();
		List<GameObject> allObjects = regRef.GetAllObjectsForTag(TagsEnum.ALL);
		for (int i = allObjects.Count - 1; i >= 0; i--)
		{
			if (!(allObjects[i] == null))
			{
				BoundingBoxComponent component = allObjects[i].GetComponent<BoundingBoxComponent>();
				if (bbc.CheckBoxIntersect(component))
				{
					bool flag = allObjects[i].CompareTag(Tags.EGG);
					if (flag || allObjects[i].CompareTag(Tags.CAPSULE) || allObjects[i].CompareTag(Tags.DIRT_CLUMP) || allObjects[i].CompareTag(Tags.DOG_CORE) || allObjects[i].CompareTag(Tags.DRAGGABLE) || allObjects[i].CompareTag(Tags.TOY) || allObjects[i].CompareTag(Tags.FOOD) || allObjects[i].CompareTag(Tags.POOP) || allObjects[i].CompareTag(Tags.SEED_PACKET) || allObjects[i].CompareTag(Tags.DEN_UPGRADE) || allObjects[i].CompareTag(Tags.VACUUM) || allObjects[i].CompareTag(Tags.SNOWBALL) || allObjects[i].CompareTag(Tags.GIFT))
					{
						if (flag)
						{
							allObjects[i].GetComponent<DogEgg>().CollectEgg();
						}
						else
						{
							Vector3 objCenter = ObjectUtil.GetObjCenter(allObjects[i]);
							AudioController.Play(objectDestructionSFX, objCenter);
							Object.Instantiate(objectDestructionParticles, objCenter, Quaternion.identity);
							Object.Destroy(allObjects[i]);
						}
					}
					yield return frameWait;
				}
			}
		}
		for (int num = placedPuddles.Count - 1; num >= 0; num--)
		{
			Vector3 objCenter2 = ObjectUtil.GetObjCenter(placedPuddles[num].objectRef);
			AudioController.Play(objectDestructionSFX, objCenter2);
			Object.Instantiate(objectDestructionParticles, objCenter2, Quaternion.identity);
			placedPuddles[num].objectRef.GetComponent<LiquidPuddle>().RemovePuddle(fromMassClean: true);
		}
		currentMassCleanRoutine = null;
	}

	public void ApplyCarpet(RoomCustomizationObject newCarpet, bool fromLoad = false)
	{
		if (!(newCarpet == null))
		{
			currentCarpet = newCarpet;
			WallBase wallForDirection = GetWallForDirection(WallDirection.DOWN);
			WallBase wallForDirection2 = GetWallForDirection(WallDirection.UP);
			wallForDirection.ApplyCarpet(newCarpet.associatedMaterial, newCarpet.tiling, newCarpet.collisionType, newCarpet.shadowsEnabled, newCarpet.customPhysicsMaterial);
			if (newCarpet.associatedSecondaryMaterial != null && newCarpet.useSecondaryMatForCeiling)
			{
				wallForDirection2.ApplyCarpet(newCarpet.associatedSecondaryMaterial, newCarpet.tiling, newCarpet.collisionType, newCarpet.shadowsEnabled);
			}
			else
			{
				ApplyCurrentWallpaperToCeiling();
			}
			if (newCarpet.useTrimMatForPenFrame && newCarpet.associatedTrimMaterial != null && sceneRef.GetGameMode() == GameMode.BREEDING)
			{
				ApplyMatToPenFrame(newCarpet.associatedTrimMaterial);
			}
			OnCarpetOrWallpaperApplied();
		}
	}

	public void ApplyWallpaper(RoomCustomizationObject newWallpaper, bool fromLoad = false)
	{
		if (!(newWallpaper == null))
		{
			Material associatedMaterial = newWallpaper.associatedMaterial;
			Material mainMat = newWallpaper.associatedMaterial;
			if (newWallpaper.associatedSecondaryMaterial != null)
			{
				mainMat = newWallpaper.associatedSecondaryMaterial;
			}
			currentWallpaper = newWallpaper;
			ApplyWallpaperToWall(GetWallForDirection(WallDirection.BACK), associatedMaterial, newWallpaper.associatedTrimMaterial, newWallpaper.tiling, newWallpaper.shadowsEnabled);
			ApplyWallpaperToWall(GetWallForDirection(WallDirection.LEFT), mainMat, newWallpaper.associatedTrimMaterial, newWallpaper.tiling, newWallpaper.shadowsEnabled);
			ApplyWallpaperToWall(GetWallForDirection(WallDirection.RIGHT), mainMat, newWallpaper.associatedTrimMaterial, newWallpaper.tiling, newWallpaper.shadowsEnabled);
			ApplyWallpaperToWall(GetWallForDirection(WallDirection.FRONT), associatedMaterial, newWallpaper.associatedTrimMaterial, newWallpaper.tiling, newWallpaper.shadowsEnabled);
			ApplyCurrentWallpaperToCeiling();
			OnCarpetOrWallpaperApplied();
		}
	}

	private void OnCarpetOrWallpaperApplied()
	{
		if (currentCarpet != null && currentCarpet.associatedItemSet == ItemSet.SPACE_LAB && currentWallpaper != null && currentWallpaper.associatedItemSet == ItemSet.SPACE_LAB)
		{
			GoalsController.ReportGoalEvent(GoalCondition.SPACE_ROOM);
		}
		carpetWallSpookiness = 0f;
		if (currentCarpet != null && currentCarpet.associatedItemSet == ItemSet.SPOOKY)
		{
			carpetWallSpookiness += spookinessFromWallCarpet;
		}
		if (currentWallpaper != null && currentWallpaper.associatedItemSet == ItemSet.SPOOKY)
		{
			carpetWallSpookiness += spookinessFromWallCarpet;
		}
	}

	private void ApplyCurrentWallpaperToCeiling()
	{
		if ((!(currentCarpet.associatedSecondaryMaterial != null) || !currentCarpet.useSecondaryMatForCeiling) && !(currentWallpaper == null))
		{
			if (currentWallpaper.useMatForCeiling)
			{
				ApplyWallpaperToWall(GetWallForDirection(WallDirection.UP), currentWallpaper.associatedMaterial, currentWallpaper.associatedTrimMaterial, currentWallpaper.tiling, currentWallpaper.shadowsEnabled);
			}
			else if (currentWallpaper.useColorForCeiling)
			{
				Material material = new Material(ceilingMaterial);
				material.color = currentWallpaper.associatedColor;
				ApplyWallpaperToWall(GetWallForDirection(WallDirection.UP), material, currentWallpaper.associatedTrimMaterial, tiling: false, currentWallpaper.shadowsEnabled);
			}
		}
	}

	private void ApplyMatToPenFrame(Material mat)
	{
		if (ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER).GetGameMode() != GameMode.HOME)
		{
			Renderer[] componentsInChildren = frameBackLeft.transform.parent.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].material = mat;
			}
		}
	}

	private void ApplyWallpaperToWall(WallBase wallParent, Material mainMat, Material trimMat, bool tiling, bool shadowsEnabled)
	{
		wallParent.ApplyWallpaper(mainMat, trimMat, tiling, shadowsEnabled);
	}

	public float GetDistanceFromExistingDen(Vector2Int gridPos)
	{
		Vector3 worldPositionForGridSquare = GetWorldPositionForGridSquare(gridPos);
		float num = float.PositiveInfinity;
		for (int i = 0; i < placedObjects.Count; i++)
		{
			if (placedObjects[i].objectRef.CompareTag(Tags.DOG_DEN))
			{
				float num2 = Mathf.Abs(Vector3.Distance(worldPositionForGridSquare, placedObjects[i].objectRef.transform.position));
				if (num2 < num)
				{
					num = num2;
				}
			}
		}
		return num;
	}

	public int GetNumberOfDens(bool requireComplete = false)
	{
		int num = 0;
		for (int i = 0; i < placedObjects.Count; i++)
		{
			if (placedObjects[i].objectRef.CompareTag(Tags.DOG_DEN) && (!requireComplete || placedObjects[i].objectRef.GetComponent<DogDen>().IsCompleted()))
			{
				num++;
			}
		}
		return num;
	}

	public List<PlacedObjectInfo> GetAllPlacedObjects()
	{
		return placedObjects;
	}

	public GameObject GetObjectForUID(ulong UID)
	{
		for (int i = 0; i < placedObjects.Count; i++)
		{
			if (placedObjects[i].objectID == UID)
			{
				return placedObjects[i].objectRef;
			}
		}
		return null;
	}

	public PlacedObjectInfo GetPlantInfoForUID(ulong UID)
	{
		for (int i = 0; i < placedPlants.Count; i++)
		{
			if (placedPlants[i].objectID == UID)
			{
				return placedPlants[i];
			}
		}
		return null;
	}

	public bool DoPuddlesExist()
	{
		return placedPuddles.Count > 0;
	}

	public List<PlacedObjectInfo> GetPlacedPuddles()
	{
		return placedPuddles;
	}

	public PlacedObjectInfo GetPuddleInfoForUID(ulong UID)
	{
		for (int i = 0; i < placedPuddles.Count; i++)
		{
			if (placedPuddles[i].objectID == UID)
			{
				return placedPuddles[i];
			}
		}
		return null;
	}

	public List<List<ulong?>> GetPlantGrid()
	{
		return plantGrid;
	}

	public List<List<ulong?>> GetPuddleGrid()
	{
		return puddleGrid;
	}

	public bool IsPlantCellFree(Vector2Int cell)
	{
		if (cell.x >= plantGrid.Count || cell.y >= plantGrid[cell.x].Count)
		{
			return false;
		}
		return !plantGrid[cell.x][cell.y].HasValue;
	}

	public bool IsPuddleCellFree(Vector2Int cell)
	{
		if (cell.x >= puddleGrid.Count || cell.y >= puddleGrid[cell.x].Count)
		{
			return false;
		}
		return !puddleGrid[cell.x][cell.y].HasValue;
	}

	public List<List<int>> GetGroundPlacementGrid()
	{
		return groundPlacementGrid;
	}

	public void UpdateGroundPlacementGrid(List<List<int>> grid)
	{
		groundPlacementGrid = grid;
	}

	public bool IsGroundPlacementCellFree(Vector2Int cell)
	{
		if (cell.x >= groundPlacementGrid.Count || cell.y >= groundPlacementGrid[cell.x].Count)
		{
			return false;
		}
		return groundPlacementGrid[cell.x][cell.y] == 0;
	}

	public Vector3 GetWorldPositionForGridSquare(Vector2Int gridPos)
	{
		return ObjectPlacementManager.GetCenterPositionForGridCellAndRoom(gridPos, this);
	}

	public void InitializeDogPositionalGrid()
	{
		if (dogPositionGrid.Count != 0)
		{
			return;
		}
		for (int i = 0; i < groundPlacementGrid.Count; i++)
		{
			dogPositionGrid.Add(new List<float>());
			for (int j = 0; j < groundPlacementGrid[i].Count; j++)
			{
				dogPositionGrid[i].Add(0f);
			}
		}
	}

	public void ReserveTileForPlacement(Vector2Int tile, ulong dogUID)
	{
		if (reservedTilesForPlacement.Contains(tile))
		{
			Debug.LogError("Attempting to reserve a tile for placement, but it's already been reserved.");
			return;
		}
		reservedTilesForPlacement.Add(tile);
		reservedTileForPlacementToOwningDogUID[tile] = dogUID;
	}

	public bool CanReserveTileForPlacement(Vector2Int tile)
	{
		if (reservedTilesForPlacement.Contains(tile))
		{
			return false;
		}
		return true;
	}

	public void ReleaseTileForPlacement(Vector2Int tile)
	{
		if (!reservedTilesForPlacement.Contains(tile))
		{
			Debug.LogError("Attempting to release a reserved tile for placement, but it doesn't seem to have been reserved to begin with.");
			return;
		}
		reservedTilesForPlacement.Remove(tile);
		reservedTileForPlacementToOwningDogUID.Remove(tile);
	}

	public bool IsTileReservedForPlacement(int x, int y)
	{
		Vector2Int item = new Vector2Int(x, y);
		return reservedTilesForPlacement.Contains(item);
	}

	public void ReleaseAllTilesDogHasReservedForPlacement(ulong dogUID)
	{
		for (int num = reservedTilesForPlacement.Count - 1; num >= 0; num--)
		{
			if (reservedTileForPlacementToOwningDogUID[reservedTilesForPlacement[num]] == dogUID)
			{
				ReleaseTileForPlacement(reservedTilesForPlacement[num]);
			}
		}
	}

	public void ReserveTile(Vector2Int tile)
	{
		if (!reservedTiles.Contains(tile))
		{
			reservedTiles.Add(tile);
		}
	}

	public void ReleaseTile(Vector2Int tile)
	{
		if (reservedTiles.Contains(tile))
		{
			reservedTiles.Remove(tile);
		}
	}

	public bool IsTileReserved(int x, int y)
	{
		Vector2Int item = new Vector2Int(x, y);
		return reservedTiles.Contains(item);
	}

	public float GetDogScoreForGridSquare(int x, int y)
	{
		if (x < 0 || y < 0 || x >= dogPositionGrid.Count || y >= dogPositionGrid[x].Count)
		{
			return 0f;
		}
		if (IsTileReserved(x, y))
		{
			return 1f;
		}
		return dogPositionGrid[x][y];
	}

	private void DecayDogPositions()
	{
		float num = Time.deltaTime * dogPositionDecayRate;
		for (int i = 0; i < dogPositionGrid.Count; i++)
		{
			for (int j = 0; j < dogPositionGrid[i].Count; j++)
			{
				if (!(dogPositionGrid[i][j] <= 0f))
				{
					dogPositionGrid[i][j] -= num;
					if (dogPositionGrid[i][j] < 0f)
					{
						dogPositionGrid[i][j] = 0f;
					}
				}
			}
		}
	}

	public int GetNumberOfDogsInRoom()
	{
		List<GameObject> allDogs = dogRegRef.GetAllDogs();
		int num = 0;
		for (int i = 0; i < allDogs.Count; i++)
		{
			if (bbc.CheckBoxIntersect(allDogs[i].GetComponent<BoundingBoxComponent>()))
			{
				num++;
			}
		}
		return num;
	}

	public void ReportDogPositions(BoundingBoxComponent bbc)
	{
		if (dogPositionGrid.Count == 0)
		{
			ObjectPlacementManager.InitializeDogGridForRoom(this);
		}
		Vector3 boxSize = bbc.GetBoxSize();
		Vector3 boxCenter = bbc.GetBoxCenter();
		Vector2Int gridSquareForPositionAndRoom = ObjectPlacementManager.GetGridSquareForPositionAndRoom(boxCenter - boxSize * 2f, this);
		Vector2Int gridSquareForPositionAndRoom2 = ObjectPlacementManager.GetGridSquareForPositionAndRoom(boxCenter + boxSize * 2f, this);
		if (gridSquareForPositionAndRoom == gridSquareForPositionAndRoom2)
		{
			return;
		}
		float num = 1f;
		float num2 = Mathf.FloorToInt((float)(gridSquareForPositionAndRoom2.x - gridSquareForPositionAndRoom.x) / 2f);
		float num3 = Mathf.FloorToInt((float)(gridSquareForPositionAndRoom2.y - gridSquareForPositionAndRoom.y) / 2f);
		float num4 = (float)gridSquareForPositionAndRoom.x + num2;
		float num5 = (float)gridSquareForPositionAndRoom.y + num3;
		for (int i = gridSquareForPositionAndRoom.x; i <= gridSquareForPositionAndRoom2.x; i++)
		{
			for (int j = gridSquareForPositionAndRoom.y; j <= gridSquareForPositionAndRoom2.y; j++)
			{
				float num6 = Mathf.Min(Mathf.Abs((float)i - num4), num2);
				float num7 = Mathf.Min(Mathf.Abs((float)j - num5), num3);
				float num8 = (num2 - num6) / num2;
				float num9 = (num3 - num7) / num3;
				num = (num8 + num9) / 2f;
				num *= dogPositionDecayRate * Time.deltaTime * 4f;
				dogPositionGrid[i][j] = Mathf.Min(dogPositionGrid[i][j] + num, 1f);
			}
		}
	}

	public List<List<float>> GetGroundIsolationGrid()
	{
		return groundIsolationGrid;
	}

	public List<Vector3> GetGroundIsolationPositions(List<float> weights)
	{
		weights.Clear();
		List<Vector3> list = new List<Vector3>();
		for (int i = 0; i < groundIsolationGrid.Count; i++)
		{
			for (int j = 0; j < groundIsolationGrid[i].Count; j++)
			{
				if (!(GetDogScoreForGridSquare(i, j) > 0f) && !(GetDogScoreForGridSquare(i + 1, j) > 0f) && !(GetDogScoreForGridSquare(i - 1, j) > 0f) && !(GetDogScoreForGridSquare(i, j - 1) > 0f) && !(GetDogScoreForGridSquare(i, j + 1) > 0f) && (i - 1 < 0 || groundPlacementGrid[i - 1][j] != 0 || !(groundIsolationGrid[i - 1][j] <= 0f)) && (i + 1 >= groundPlacementGrid.Count || groundPlacementGrid[i + 1][j] != 0 || !(groundIsolationGrid[i + 1][j] <= 0f)) && (j - 1 < 0 || groundPlacementGrid[i][j - 1] != 0 || !(groundIsolationGrid[i][j - 1] <= 0f)) && (j + 1 >= groundPlacementGrid[i].Count || groundPlacementGrid[i][j + 1] != 0 || !(groundIsolationGrid[i][j + 1] <= 0f)) && groundIsolationGrid[i][j] > 0f)
				{
					weights.Add(groundIsolationGrid[i][j]);
					list.Add(ObjectPlacementManager.GetCenterPositionForGridCellAndRoom(new Vector2Int(i, j), this));
				}
			}
		}
		return list;
	}

	public List<Vector3> GetGroundNoTrafficPoints()
	{
		List<Vector3> list = new List<Vector3>();
		for (int i = 0; i < dogPositionGrid.Count; i++)
		{
			for (int j = 0; j < dogPositionGrid[i].Count; j++)
			{
				if (dogPositionGrid[i][j] == 0f)
				{
					list.Add(ObjectPlacementManager.GetCenterPositionForGridCellAndRoom(new Vector2Int(i, j), this));
				}
			}
		}
		return list;
	}

	public List<Vector3> GetGroundHighTrafficPoints(List<float> weights)
	{
		weights.Clear();
		List<Vector3> list = new List<Vector3>();
		for (int i = 0; i < dogPositionGrid.Count; i++)
		{
			for (int j = 0; j < dogPositionGrid[i].Count; j++)
			{
				if (dogPositionGrid[i][j] > 0f)
				{
					weights.Add(dogPositionGrid[i][j]);
					list.Add(ObjectPlacementManager.GetCenterPositionForGridCellAndRoom(new Vector2Int(i, j), this));
				}
			}
		}
		return list;
	}

	public float GetIsolationScore()
	{
		if (!isolationScoreInitialized)
		{
			InitializeIsolationGrid();
		}
		return isolationScore;
	}

	private void InitializeIsolationGrid()
	{
		List<List<float>> list = new List<List<float>>();
		for (int i = 0; i < groundPlacementGrid.Count; i++)
		{
			list.Add(new List<float>());
			for (int j = 0; j < groundPlacementGrid[i].Count; j++)
			{
				list[i].Add(ObjectPlacementManager.GetIsolationScoreForGridCell(i, j, groundPlacementGrid));
			}
		}
		UpdateGroundIsolationGrid(list);
	}

	public void UpdateGroundIsolationGrid(List<List<float>> grid)
	{
		isolationScore = 0f;
		groundIsolationGrid = grid;
		int num = 0;
		for (int i = 0; i < grid.Count; i++)
		{
			for (int j = 0; j < grid[i].Count; j++)
			{
				num++;
				isolationScore += grid[i][j];
				if (grid[i][j] > 1f)
				{
					Debug.LogWarning("NO");
				}
			}
		}
		isolationScore /= num;
		isolationScoreInitialized = true;
	}

	public float GetDogTrafficScore()
	{
		if (lastDogTrafficScoreUpdateFrame == Time.frameCount)
		{
			return lastDogTrafficScore;
		}
		lastDogTrafficScoreUpdateFrame = Time.frameCount;
		if (dogPositionGrid.Count == 0)
		{
			lastDogTrafficScore = 0f;
			return 0f;
		}
		float num = 0f;
		int num2 = 0;
		for (int i = 0; i < dogPositionGrid.Count; i++)
		{
			for (int j = 0; j < dogPositionGrid[i].Count; j++)
			{
				num2++;
				num += dogPositionGrid[i][j];
				num += dogPositionGrid[i][j];
			}
		}
		return lastDogTrafficScore = num / (float)num2;
	}

	public RoomCustomizationObject GetCurrentCarpet()
	{
		return currentCarpet;
	}

	public RoomCustomizationObject GetCurrentWallpaper()
	{
		return currentWallpaper;
	}

	public List<SaveablePlacedObject> GetSaveablePlacedObjects()
	{
		List<SaveablePlacedObject> list = new List<SaveablePlacedObject>();
		for (int i = 0; i < placedObjects.Count; i++)
		{
			if (CanSavePlacedObject(placedObjects[i].objectRef))
			{
				SaveablePlacedObject saveablePlacedObject = new SaveablePlacedObject();
				saveablePlacedObject.UID = placedObjects[i].objectID.Value;
				saveablePlacedObject.resourceString = placedObjects[i].objectRef.GetComponent<PlacedObjectID>().GetResourceString();
				saveablePlacedObject.scaleValue = placedObjects[i].scale;
				saveablePlacedObject.rotationValue = placedObjects[i].rotationValue;
				saveablePlacedObject.gridPos = new SerializableVector2Int(placedObjects[i].gridPos);
				SavePlaceableComponents(saveablePlacedObject, placedObjects[i].objectRef);
				list.Add(saveablePlacedObject);
			}
		}
		return list;
	}

	public List<SaveablePlacedObject> GetSaveablePlacedPlants()
	{
		List<SaveablePlacedObject> list = new List<SaveablePlacedObject>();
		for (int i = 0; i < placedPlants.Count; i++)
		{
			SaveablePlacedObject saveablePlacedObject = new SaveablePlacedObject();
			saveablePlacedObject.UID = placedPlants[i].objectID.Value;
			saveablePlacedObject.resourceString = placedPlants[i].objectRef.GetComponent<PlacedObjectID>().GetResourceString();
			saveablePlacedObject.scaleValue = placedPlants[i].scale;
			saveablePlacedObject.rotationValue = placedPlants[i].rotationValue;
			saveablePlacedObject.gridPos = new SerializableVector2Int(placedPlants[i].gridPos);
			SavePlaceableComponents(saveablePlacedObject, placedPlants[i].objectRef);
			list.Add(saveablePlacedObject);
		}
		return list;
	}

	public List<SaveablePlacedObject> GetSaveablePlacedPuddles()
	{
		List<SaveablePlacedObject> list = new List<SaveablePlacedObject>();
		for (int i = 0; i < placedPuddles.Count; i++)
		{
			SaveablePlacedObject saveablePlacedObject = new SaveablePlacedObject();
			saveablePlacedObject.UID = placedPuddles[i].objectID.Value;
			saveablePlacedObject.resourceString = placedPuddles[i].objectRef.GetComponent<PlacedObjectID>().GetResourceString();
			saveablePlacedObject.scaleValue = placedPuddles[i].scale;
			saveablePlacedObject.rotationValue = placedPuddles[i].rotationValue;
			saveablePlacedObject.gridPos = new SerializableVector2Int(placedPuddles[i].gridPos);
			SavePlaceableComponents(saveablePlacedObject, placedPuddles[i].objectRef);
			list.Add(saveablePlacedObject);
		}
		return list;
	}

	private bool CanSavePlacedObject(GameObject obj)
	{
		if (obj == null)
		{
			return false;
		}
		DogDen component = obj.GetComponent<DogDen>();
		if (component != null)
		{
			if (component.GetCurrentDenStage() == DenStage.EMPTY)
			{
				return false;
			}
			return true;
		}
		Hole component2 = obj.GetComponent<Hole>();
		if (component2 != null)
		{
			if (component2.GetCurrentHoleStage() == HoleStage.INVISIBLE)
			{
				return false;
			}
			return true;
		}
		return true;
	}

	private void SavePlaceableComponents(SaveablePlacedObject saveableObject, GameObject objectRef)
	{
		int num = 0;
		if (objectRef.GetComponent<InteractibleFoodDispensor>() != null)
		{
			num++;
			objectRef.GetComponentInChildren<FoodDispensor>().SaveObject(saveableObject);
		}
		Incubator component = objectRef.GetComponent<Incubator>();
		if (component != null)
		{
			num++;
			component.SaveObject(saveableObject);
		}
		Growable component2 = objectRef.GetComponent<Growable>();
		if (component2 != null)
		{
			num++;
			component2.Save(saveableObject);
		}
		LiquidPuddle component3 = objectRef.GetComponent<LiquidPuddle>();
		if (component3 != null)
		{
			num++;
			component3.Save(saveableObject);
		}
		DogDen component4 = objectRef.GetComponent<DogDen>();
		if (component4 != null)
		{
			num++;
			component4.Save(saveableObject);
		}
		Hole component5 = objectRef.GetComponent<Hole>();
		if (component5 != null)
		{
			num++;
			component5.Save(saveableObject);
		}
		DogMemorial component6 = objectRef.GetComponent<DogMemorial>();
		if (component6 != null)
		{
			num++;
			component6.Save(saveableObject);
		}
		DynamicTree component7 = objectRef.GetComponent<DynamicTree>();
		if (component7 != null)
		{
			num++;
			saveableObject.treeRef = new SaveableTree(component7);
		}
		InteractableTV component8 = objectRef.GetComponent<InteractableTV>();
		if (component8 != null)
		{
			num++;
			component8.Save(saveableObject);
		}
		InteractableMusicPlayer component9 = objectRef.GetComponent<InteractableMusicPlayer>();
		if (component9 != null)
		{
			num++;
			component9.Save(saveableObject);
		}
		IndustrialFan component10 = objectRef.GetComponent<IndustrialFan>();
		if (component10 != null)
		{
			num++;
			component10.Save(saveableObject);
		}
		GravityMachine component11 = objectRef.GetComponent<GravityMachine>();
		if (component11 != null)
		{
			num++;
			component11.SaveObject(saveableObject);
		}
		StorageChest component12 = objectRef.GetComponent<StorageChest>();
		if (component12 != null)
		{
			num++;
			component12.SaveObject(saveableObject);
		}
		if (num > 1)
		{
			Debug.LogError(string.Concat("Attempting to save multiple components on the same object: ", objectRef, " This will most likely result in a saved data clash!"));
		}
	}

	private void LoadSavedPlaceableComponents(PlacedObjectInfo placementInfo, SaveablePlacedObject existingObject)
	{
		if (placementInfo.objectRef.GetComponent<InteractibleFoodDispensor>() != null)
		{
			placementInfo.objectRef.GetComponentInChildren<FoodDispensor>().LoadObject(existingObject);
		}
		Incubator component = placementInfo.objectRef.GetComponent<Incubator>();
		if (component != null)
		{
			component.LoadObject(existingObject);
		}
		Growable component2 = placementInfo.objectRef.GetComponent<Growable>();
		if (component2 != null)
		{
			component2.Load(existingObject);
		}
		LiquidPuddle component3 = placementInfo.objectRef.GetComponent<LiquidPuddle>();
		if (component3 != null)
		{
			component3.Load(existingObject);
		}
		DogDen component4 = placementInfo.objectRef.GetComponent<DogDen>();
		if (component4 != null)
		{
			component4.Load(existingObject);
		}
		Hole component5 = placementInfo.objectRef.GetComponent<Hole>();
		if (component5 != null)
		{
			component5.Load(existingObject);
		}
		DogMemorial component6 = placementInfo.objectRef.GetComponent<DogMemorial>();
		if (component6 != null)
		{
			component6.Load(existingObject);
		}
		DynamicTree component7 = placementInfo.objectRef.GetComponent<DynamicTree>();
		if (component7 != null && existingObject.treeRef != null)
		{
			component7.LoadTree(existingObject.treeRef);
		}
		InteractableTV component8 = placementInfo.objectRef.GetComponent<InteractableTV>();
		if (component8 != null)
		{
			component8.Load(existingObject);
		}
		InteractableMusicPlayer component9 = placementInfo.objectRef.GetComponent<InteractableMusicPlayer>();
		if (component9 != null)
		{
			component9.Load(existingObject);
		}
		IndustrialFan component10 = placementInfo.objectRef.GetComponent<IndustrialFan>();
		if (component10 != null)
		{
			component10.Load(existingObject);
		}
		GravityMachine component11 = placementInfo.objectRef.GetComponent<GravityMachine>();
		if (component11 != null)
		{
			component11.LoadObject(existingObject);
		}
		StorageChest component12 = placementInfo.objectRef.GetComponent<StorageChest>();
		if (component12 != null)
		{
			component12.LoadObject(existingObject);
		}
	}

	public void LoadSavedPlacedObjects(List<SaveablePlacedObject> objects)
	{
		if (objects == null)
		{
			return;
		}
		for (int i = 0; i < objects.Count; i++)
		{
			if (objects[i] == null)
			{
				Debug.LogError("Save file had a null object associated with it. Ignoring.");
				continue;
			}
			RoomCustomizationObject customizationObjectForPath = inventoryRef.GetCustomizationObjectForPath(objects[i].resourceString);
			ObjectPlacementManager.LoadSavedObject(this, objects[i], customizationObjectForPath);
		}
	}

	public void LoadSavedPlacedPlants(List<SaveablePlacedObject> plants)
	{
		if (plants != null)
		{
			for (int i = 0; i < plants.Count; i++)
			{
				RoomCustomizationObject customizationObjectForPath = inventoryRef.GetCustomizationObjectForPath(plants[i].resourceString);
				ObjectPlacementManager.LoadSavedPlant(this, plants[i], customizationObjectForPath);
			}
		}
	}

	public void LoadSavedPlacedPuddles(List<SaveablePlacedObject> puddles)
	{
		if (puddles != null)
		{
			for (int i = 0; i < puddles.Count; i++)
			{
				RoomCustomizationObject customizationObjectForPath = inventoryRef.GetCustomizationObjectForPath(puddles[i].resourceString);
				ObjectPlacementManager.LoadSavedPuddle(this, puddles[i], customizationObjectForPath);
			}
		}
	}

	public Transform GetCenterFocusTransform()
	{
		return focusTransform;
	}

	public Vector3 GetRoomCenter()
	{
		return GetBBC().GetBoxCenter();
	}

	public BoundingBoxComponent GetBBC()
	{
		if (bbc != null)
		{
			return bbc;
		}
		bbc = GetComponent<BoundingBoxComponent>();
		if (bbc == null)
		{
			bbc = base.gameObject.AddComponent<BoundingBoxComponent>();
		}
		return bbc;
	}

	public void CenterFocusTransform()
	{
		Vector3 boxSize = GetBBC().GetBoxSize();
		focusTransform.position = base.transform.position;
		focusTransform.position += new Vector3(0f, 0f - boxSize.y + 5f, 0f);
	}

	public bool DoesWallHaveExpansionPotential(WallDirection dir)
	{
		return GetWallForDirection(dir).canBecomeDoor;
	}

	public bool CanWallActuallyExpand(WallDirection dir, ConnectorLabel label)
	{
		return GetWallForDirection(dir).CanExpand(label);
	}

	public bool CanAnyWallExpand()
	{
		for (int i = 0; i < allWalls.Count; i++)
		{
			if (allWalls[i].CanAnyLabelExpand())
			{
				return true;
			}
		}
		return false;
	}

	public GameObject GetNodeForWallDirection(WallDirection dir, ConnectorLabel label)
	{
		for (int i = 0; i < currentExpansionNodes.Count; i++)
		{
			PipeExpansionNode component = currentExpansionNodes[i].GetComponent<PipeExpansionNode>();
			if (component.attachedWall.wallDirection == dir && component.label == label)
			{
				return currentExpansionNodes[i];
			}
		}
		return null;
	}

	public float GetBehaviorScoreMultiplier(DogBehaviorRoomEnum behaviorEnum)
	{
		return behaviorScoreMultiplier;
	}

	public void ShowPipeConnections(GameObject expansionPrefab)
	{
		HidePipeConnections();
		for (int i = 0; i < allWalls.Count; i++)
		{
			if (!allWalls[i].CanAnyLabelExpand())
			{
				continue;
			}
			for (int j = 0; j < allWalls[i].wallStateStructures.Count; j++)
			{
				if (allWalls[i].CanExpand(allWalls[i].wallStateStructures[j].label))
				{
					GameObject gameObject = Object.Instantiate(expansionPrefab);
					PipeExpansionNode component = gameObject.GetComponent<PipeExpansionNode>();
					component.attachedRoom = this;
					component.attachedWall = allWalls[i];
					component.direction = allWalls[i].wallDirection;
					component.label = allWalls[i].wallStateStructures[j].label;
					gameObject.transform.position = component.GetPositionForNode();
					currentExpansionNodes.Add(gameObject);
				}
			}
		}
	}

	public List<Vector3> GetPipeExpansionNodePositions()
	{
		List<Vector3> list = new List<Vector3>();
		for (int i = 0; i < currentExpansionNodes.Count; i++)
		{
			list.Add(currentExpansionNodes[i].transform.position);
		}
		return list;
	}

	public void HidePipeConnections()
	{
		for (int i = 0; i < currentExpansionNodes.Count; i++)
		{
			Object.Destroy(currentExpansionNodes[i]);
		}
		currentExpansionNodes.Clear();
	}

	public WallBase GetWallForDirection(WallDirection dir)
	{
		for (int i = 0; i < allWalls.Count; i++)
		{
			if (allWalls[i].wallDirection == dir)
			{
				return allWalls[i];
			}
		}
		return null;
	}

	public bool IsAnyWallVisible()
	{
		for (int i = 0; i < allWalls.Count; i++)
		{
			if (allWalls[i].IsVisible())
			{
				return true;
			}
		}
		return false;
	}
}
