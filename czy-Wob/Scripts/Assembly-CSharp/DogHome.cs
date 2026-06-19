using System.Collections.Generic;
using UnityEngine;

public class DogHome : MonoBehaviour
{
	public GameObject penBuildingBlock;

	public GameObject pipeCreator;

	public GameObject incubationPenExtras;

	public GameObject breedingExtras;

	public Material standardPenFloorMaterial;

	public Material standardPenWallMaterial;

	public Material standardPenWallTextureMat;

	public Material ghostedPenMaterial;

	public Material invalidPenMaterial;

	public Material selectedPenMaterial;

	public Material standardIncubationPenFloorMaterial;

	public Material standardIncubationPenWallMaterial;

	public Material ghostedIncubationPenMaterial;

	public Material invalidIncubationPenMaterial;

	public Material selectedIncubationPenMaterial;

	public List<Material> standardPipeMaterials;

	public Material pipeConnectorMaterial;

	public Material ghostedPipeMaterial;

	public Material invalidPipeMaterial;

	public Material selectedPipeMaterial;

	public Material transparentPipeMaterial;

	private PlayToolMode currentPlayMode;

	private bool inBuildMode;

	private bool initialized;

	private int allowedPens = 1;

	private PenFocus focusRef;

	private ObjectGrabber grabberRef;

	private DogRegistration registration;

	private GUIManagerPens guiManagerRef;

	private ConstructionManager constructionRef;

	private void Awake()
	{
		Initialize();
	}

	private void Update()
	{
		HandleInput();
	}

	public void Initialize()
	{
		if (!initialized)
		{
			initialized = true;
			currentPlayMode = PlayToolMode.STANDARD;
			ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
			focusRef = Camera.main.GetComponent<PenFocus>();
			grabberRef = registrationScript.GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER);
			registration = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		}
	}

	private void Start()
	{
		constructionRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
	}

	public SaveableDogHome GetSavedDogHome()
	{
		SaveableDogHome saveableDogHome = new SaveableDogHome();
		saveableDogHome.freshHome = false;
		saveableDogHome.IDCounter = constructionRef.GetIDCounter();
		constructionRef.SaveBuildObjects(saveableDogHome);
		constructionRef.SaveCameraFocus(saveableDogHome);
		saveableDogHome.allowedPens = allowedPens;
		return saveableDogHome;
	}

	public void LoadDogHome(SaveableDogHome savedHome)
	{
		if (savedHome != null)
		{
			constructionRef.SetIDCounter(savedHome.IDCounter);
			ObjectPlacementManager.SetPlantIDCounter(savedHome.placedPlantsIDCounter);
			ObjectPlacementManager.SetPuddleIDCounter(savedHome.placedPuddlesIDCounter);
			ObjectPlacementManager.SetPlaceableIDCounter(savedHome.placedObjectsIDCounter);
		}
		constructionRef.LoadBuildObjects(savedHome);
		if (savedHome != null)
		{
			allowedPens = savedHome.allowedPens;
			constructionRef.LoadCameraFocus(savedHome.lastFocusedRoomUID);
		}
		else
		{
			allowedPens = 1;
			constructionRef.LoadCameraFocus(0uL);
		}
	}

	public PlayToolMode GetCurrentMode()
	{
		return currentPlayMode;
	}

	public void AssignGuiManagerRef()
	{
		guiManagerRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
	}

	public void SetMode(PlayToolMode newMode)
	{
		if (currentPlayMode != newMode)
		{
			currentPlayMode = newMode;
			PlayToolMode playToolMode = currentPlayMode;
			if (playToolMode == PlayToolMode.PLACE_DOG)
			{
				TrySpawnDog();
				SetMode(PlayToolMode.STANDARD);
			}
		}
	}

	public int GetRemainingAllowedDogs()
	{
		return Mathf.Max(registration.GetMaxDogs() - registration.GetDogCount(), 0);
	}

	public BoundingBoxComponent GetBBCForRoomUID(ulong roomUID)
	{
		return constructionRef.GetObjectForUID(roomUID).GetComponent<BoundingBoxComponent>();
	}

	public RoomBase GetRoomForUID(ulong UID)
	{
		return constructionRef.GetObjectForUID(UID).GetComponent<RoomBase>();
	}

	public float GetGravModForRoomUID(ulong? UID)
	{
		if (!UID.HasValue)
		{
			return 1f;
		}
		return GetRoomForUID(UID.Value).GetGravMod();
	}

	public bool AnyGravModsActive()
	{
		return constructionRef.AnyGravModsActive();
	}

	public ulong? GetRoomUIDForBoundingBox(BoundingBoxComponent bbc, bool requireInRoom = false, bool requireIntersectInstead = false)
	{
		ulong? result = null;
		float num = float.PositiveInfinity;
		Vector3 a = Vector3.zero;
		if (!requireInRoom)
		{
			a = bbc.GetBoxCenter();
		}
		int numberOfCreatedRooms = constructionRef.GetNumberOfCreatedRooms();
		for (int i = 0; i < numberOfCreatedRooms; i++)
		{
			ulong roomUIDForIndex = constructionRef.GetRoomUIDForIndex(i);
			BoundingBoxComponent objectBBCForUID = constructionRef.GetObjectBBCForUID(roomUIDForIndex);
			if (objectBBCForUID == null)
			{
				continue;
			}
			if (requireIntersectInstead)
			{
				if (bbc.CheckBoxIntersect(objectBBCForUID))
				{
					return roomUIDForIndex;
				}
				continue;
			}
			if (bbc.CheckBoxContained(objectBBCForUID))
			{
				return roomUIDForIndex;
			}
			if (!requireInRoom)
			{
				float num2 = Vector3.Distance(a, objectBBCForUID.GetBoxCenter());
				if (num2 < num)
				{
					result = roomUIDForIndex;
					num = num2;
				}
			}
		}
		return result;
	}

	public ulong? GetRoomUIDForDog(GameObject dog)
	{
		DogDenController component = dog.GetComponent<DogDenController>();
		if (component != null && component.IsInDen())
		{
			GameObject currentlyOccupiedDenObject = component.GetCurrentlyOccupiedDenObject();
			if (currentlyOccupiedDenObject != null)
			{
				BoundingBoxComponent component2 = currentlyOccupiedDenObject.GetComponent<BoundingBoxComponent>();
				if (component2 != null)
				{
					return component2.GetRoomUID();
				}
			}
		}
		BoundingBoxComponent component3 = dog.GetComponent<BoundingBoxComponent>();
		return GetRoomUIDForBoundingBox(component3);
	}

	public Vector3 GetPosForRoom(ulong? roomUID, GameObject room = null)
	{
		GameObject gameObject = room;
		if (gameObject == null)
		{
			if (!roomUID.HasValue)
			{
				roomUID = 0uL;
			}
			gameObject = constructionRef.GetObjectForUID(roomUID.Value);
			if (gameObject == null)
			{
				return Vector3.zero;
			}
		}
		return GetRoomCenter(gameObject);
	}

	public void TrySpawnDog()
	{
		GameObject targetRoom = GetTargetRoom();
		if (!(targetRoom == null))
		{
			Vector3 posForRoom = GetPosForRoom(0uL, targetRoom);
			bool useBaseGeneWithoutMutation = true;
			if (CheatEngine.cheatRef.randomDogGenes || CheatEngine.cheatRef.manualDogGenetics)
			{
				useBaseGeneWithoutMutation = false;
			}
			registration.RequestNewDog(posForRoom, targetRoom.transform.rotation, null, null, manualDog: false, null, playerOwned: true, useBaseGeneWithoutMutation);
		}
	}

	public GameObject TrySpawnItem(InventoryItem item, Vector3 placementPos, ulong? expectedRoom = null, bool moveToGoodLocation = true, Vector3? customScale = null, Quaternion? customRotation = null, List<GameObject> toIgnoreDuringPlacement = null)
	{
		Quaternion rotation = ((!customRotation.HasValue) ? Quaternion.identity : customRotation.Value);
		GameObject gameObject = Object.Instantiate(item.itemPrefab, placementPos, rotation);
		if (customScale.HasValue)
		{
			gameObject.transform.localScale = customScale.Value;
			gameObject.transform.root.gameObject.SetActive(value: false);
			gameObject.transform.root.gameObject.SetActive(value: true);
		}
		BoundingBoxComponent boundingBoxComponent = gameObject.GetComponent<BoundingBoxComponent>();
		if (boundingBoxComponent == null)
		{
			boundingBoxComponent = gameObject.AddComponent<BoundingBoxComponent>();
		}
		if (moveToGoodLocation && !boundingBoxComponent.MoveToGoodLocation(expectedRoom, toIgnoreDuringPlacement))
		{
			Debug.LogError("No valid placement position for spawned object: " + item.itemName);
		}
		gameObject.name = item.itemName;
		ObjectRegistration.GetRegistrationScript().AssignID(gameObject, item);
		return gameObject;
	}

	public static Vector3 GetRoomCenter(GameObject room)
	{
		return room.transform.position;
	}

	public GameObject GetTargetRoom()
	{
		GameObject gameObject = constructionRef.GetLastFocusedRoom();
		if (gameObject == null)
		{
			List<GameObject> allRooms = constructionRef.GetAllRooms();
			if (allRooms.Count > 0)
			{
				gameObject = allRooms[0];
			}
		}
		return gameObject;
	}

	private void HandleInput()
	{
		if (GameControls.actions.BuildModeToggle.WasPressed)
		{
			if (guiManagerRef == null)
			{
				AssignGuiManagerRef();
			}
			if (!(guiManagerRef == null) && guiManagerRef.ModeButtonsUsable())
			{
				RequestModeToggle();
			}
		}
	}

	public bool IsInBuildMode()
	{
		return inBuildMode;
	}

	public void RequestModeToggle()
	{
		if (guiManagerRef == null)
		{
			AssignGuiManagerRef();
		}
		if ((!(guiManagerRef != null) || guiManagerRef.GetGUIInteractiveStatus()) && (!(guiManagerRef != null) || guiManagerRef.CanEnterBuildMode()))
		{
			if (inBuildMode)
			{
				RequestExitBuildMode();
			}
			else
			{
				RequestEnterBuildMode();
			}
		}
	}

	public void RequestEnterBuildMode(bool playSounds = true)
	{
		if (guiManagerRef == null)
		{
			AssignGuiManagerRef();
		}
		bool playExitSound;
		if (inBuildMode)
		{
			ConstructionManager constructionManager = constructionRef;
			playExitSound = playSounds;
			constructionManager.SetConstructionMode(ConstructionManager.CurrentMode.CONSTRUCTION, null, playSounds, playExitSound);
			SetMode(PlayToolMode.STANDARD);
			return;
		}
		inBuildMode = true;
		focusRef.ClearFollowCam(fromRoomFocus: false, playSounds: false, playPenFocusSound: false);
		ConstructionManager constructionManager2 = constructionRef;
		playExitSound = playSounds;
		constructionManager2.SetConstructionMode(ConstructionManager.CurrentMode.CONSTRUCTION, null, playSounds, playExitSound);
		SetMode(PlayToolMode.STANDARD);
		guiManagerRef.ExitPhotoMode();
		guiManagerRef.CloseInventoryPanel();
		grabberRef.DisableGrabber(LockReason.DOG_HOME);
	}

	public void RequestExitBuildMode()
	{
		if (!inBuildMode)
		{
			Debug.LogError("Attempting to exit build mdoe but we're not in build mode.");
			return;
		}
		inBuildMode = false;
		constructionRef.SetConstructionMode(ConstructionManager.CurrentMode.STANDARD);
		SetMode(PlayToolMode.STANDARD);
		grabberRef.EnableGrabber(LockReason.DOG_HOME);
	}

	public int GetNumberOfAllowedPens()
	{
		return allowedPens;
	}

	public void UnlockAdditionalPens(int count = 1)
	{
		allowedPens += count;
	}
}
