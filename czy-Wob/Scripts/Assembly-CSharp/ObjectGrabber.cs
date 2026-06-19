using System.Collections;
using System.Collections.Generic;
using DevConsole;
using HighlightingSystem;
using InControl;
using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
	public delegate void PlaceObjectCallback(Vector3 spawnPos, Quaternion spawnRot, GameObject objecetToIgnore);

	public delegate void PlacementEndCallback();

	public delegate void DogSelectionCallback(RaycastHit hitInfo);

	public GameObject locationPrefab;

	public GameObject locationCirclePrefab;

	public GameObject objectIndicatorPrefab;

	private ObjectIndicatorPens indicatorRef;

	private bool stageIndicatorActive;

	public bool infoModeEnabled = true;

	private PlaceObjectCallback PlacementCallback;

	private PlacementEndCallback PlacementOverCallback;

	private DogSelectionCallback CurrentDogSelectionCallback;

	private List<LockReason> dragLocks = new List<LockReason>();

	private Vector3 initialGrabOffset = Vector3.zero;

	private bool needsRenderEnable;

	private string grabObjectSound = "player_object_grab";

	private string dropObjectSound = "player_object_drop";

	private string throwObjectSound = "player_object_throw";

	private string objectDestroySound = "object_destroy";

	private string doubleClickSound = "contextMenu_click_default";

	private float dogTossForce = 1000f;

	private float objectTossForce = 100f;

	private bool needsMouseUp;

	private Vector3 dragBoxSize;

	private Vector3 dragBoxCenterOffset;

	private Dictionary<Rigidbody, float> dragDict = new Dictionary<Rigidbody, float>();

	private float maxYSpeed = 75f;

	private float maxSpeed = 150f;

	private float scrollSpeed = 100f;

	private float moveMultiplier = 100f;

	private float holdTimeStart;

	private bool hasPushedGrabReactions;

	private float minHoldTimeForGrab = 0.4f;

	private float minHoldTimeForGrabAdjustedMax = 0.6f;

	private float usableHoldTimeForGrab = 0.4f;

	private float minFramerate = 15f;

	private float maxFramerate = 45f;

	private float maxMouseDistForClick = 6f;

	private bool hasCreatedLocationVis;

	private Vector3 clickStartPos = Vector3.zero;

	private int frameCounter;

	private float timeCounter;

	private float lastFramerate = 60f;

	private float refreshTime = 0.5f;

	private int granularity = 5;

	private int fCounter;

	private List<float> pastRates = new List<float>();

	private float tunedFramerate = 60f;

	private float averageFramerate = 60f;

	public GameObject doubleClickParticles;

	private float lastClickTime = -100f;

	private float doubleClickWindow = 0.3f;

	private ulong? lastClickedDogID;

	private float grabbedAngularDrag = 10f;

	private float raycastDist = 100f;

	private RaycastHit[] results = new RaycastHit[100];

	private GameObject objectCarrier;

	private Rigidbody objectCarrierRB;

	private float dogSpring = 25000f;

	private float dogDamper = 1000f;

	private static string tailTag = "tail";

	private float tailWeightOriginal;

	private float tailWeightDriveOriginal;

	private float tailWeightGrab = 75f;

	private static string legsLayerName = "Legs";

	private static float legWeightGrabMultiplier = 50f;

	private static string faceLayerName = "Head";

	private static string wingTag = "Wing";

	private bool carryingDog;

	private DogAI carriedAIRef;

	private DogDenController carriedDenRef;

	private bool carryingObject;

	private bool carryingInventoryObject;

	private int dogSelectionEnterFrame;

	private bool inDogSelectionMode;

	public Color highlightColor;

	private GameObject currentHighlightedObject;

	public Color secondaryHighlightColor;

	private GameObject currentSecondaryHighlightedObject;

	public Color locationHighlightColor;

	private GameObject currentLocationHighlightedObject;

	public Color breedingSelectionColorA;

	private GameObject currentlySelectedBreedingObjecetA;

	public Color breedingSelectionColorB;

	private GameObject currentlySelectedBreedingObjecetB;

	public Color breedingSelectionColorFinal;

	private GameObject currentlySelectedBreedingObjecetFinal;

	public Color activeDogColor;

	private GameObject currentlyActiveDog;

	public Color levitationColor;

	private List<GameObject> currentlyLevitatedObjects = new List<GameObject>();

	private List<int> currentlyLevitatedObjectRequests = new List<int>();

	private bool isHighlightingCollectable;

	private GameObject locationObj;

	private GameObject locationCircle;

	private Material locationObjFadMat;

	private Coroutine currentCircleEaseRoutine;

	private Coroutine timeDelayedLocationRoutine;

	private RaycastHit lastRaycastHit;

	private GameObject lastSelectedObject;

	private float lastSelectedObjectTime = -1f;

	private float objectSelectionBuffer = 0.25f;

	private float distractionTimerMin = 1f;

	private float currentDistractionTimer;

	private List<GameObject> dogList = new List<GameObject>();

	private float lastDeltaTime;

	private int inputSamplesMax = 10;

	private List<Vector3> inputBuffer = new List<Vector3>();

	private int frameWait;

	private static List<string> grabAndClickTags = new List<string>
	{
		Tags.POOP,
		Tags.EGG,
		Tags.TOY,
		Tags.FOOD,
		Tags.DOG,
		Tags.DIRT_CLUMP,
		Tags.CAPSULE,
		Tags.DOG_CORE,
		Tags.SEED_PACKET,
		Tags.DEN_UPGRADE,
		Tags.VACUUM,
		Tags.SNOWBALL,
		Tags.GIFT
	};

	private List<string> clickableTags = new List<string>
	{
		Tags.DOG,
		Tags.FOOD,
		Tags.DRAGGABLE,
		Tags.EGG,
		Tags.CAPSULE,
		Tags.TOY,
		Tags.COCOON,
		Tags.CLICKABLE_OBJECT,
		Tags.PUDDLE,
		Tags.POOP,
		Tags.DIRT_CLUMP,
		Tags.DOG_DEN,
		Tags.DOG_CORE,
		Tags.HOLE,
		Tags.SEED_PACKET,
		Tags.TV,
		Tags.FAN,
		Tags.DOG_STACK,
		Tags.DOG_MEMORIAL,
		Tags.BOPPER,
		Tags.DEN_UPGRADE,
		Tags.MUSIC_PLAYER,
		Tags.VACUUM,
		Tags.SNOWBALL,
		Tags.GIFT,
		Tags.SNOWGLOBE,
		Tags.SAMPLESTABLE,
		Tags.PRICKLYPEAR
	};

	private Camera mainCam;

	private DogHome homeRef;

	private PenFocus penFocusRef;

	private DogRegistration dogRegRef;

	private CursorController cursorRef;

	private SceneManagerBase sceneManagerRef;

	private ConstructionManager constructionRef;

	private ObjectIndicatorManager indicatorManagerRef;

	private void Awake()
	{
		objectCarrier = new GameObject("ObjectGrabbingSpring");
		objectCarrierRB = objectCarrier.AddComponent<Rigidbody>();
		objectCarrierRB.isKinematic = true;
		mainCam = Camera.main;
		SpringJoint springJoint = objectCarrier.AddComponent<SpringJoint>();
		springJoint.spring = dogSpring;
		springJoint.damper = dogDamper;
		springJoint.enablePreprocessing = false;
		locationObj = Object.Instantiate(locationPrefab);
		locationCircle = Object.Instantiate(locationCirclePrefab);
		locationObjFadMat = locationObj.GetComponent<Renderer>().material;
		DisableLocationVis();
		penFocusRef = Camera.main.GetComponent<PenFocus>();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		cursorRef = registrationScript.GetGlobalComponent<CursorController>(GlobalObject.CURSOR, nullAllowed: true);
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION, nullAllowed: true);
	}

	private void Start()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		homeRef = registrationScript.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME, nullAllowed: true);
		constructionRef = registrationScript.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER, nullAllowed: true);
		indicatorManagerRef = registrationScript.GetGlobalComponent<ObjectIndicatorManager>(GlobalObject.OBJECT_INDICATOR_MANAGER, nullAllowed: true);
		indicatorRef = Object.Instantiate(objectIndicatorPrefab).GetComponent<ObjectIndicatorPens>();
		indicatorRef.HideEverything();
		stageIndicatorActive = false;
		indicatorRef.AddIndicatorAction(IndicatorAction.DOG_WALK_HERE);
		indicatorRef.AddIndicatorAction(IndicatorAction.DOG_DIG_HERE);
		indicatorRef.AddIndicatorAction(IndicatorAction.DOG_SLEEP_HERE);
		sceneManagerRef = registrationScript.GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
	}

	public static bool IsTagDraggable(string tag)
	{
		return grabAndClickTags.Contains(tag);
	}

	private bool DragEnabled()
	{
		return dragLocks.Count == 0;
	}

	private void Update()
	{
		if (PauseController.IsPaused())
		{
			return;
		}
		UpdateFramerateCounter();
		lastDeltaTime = Time.deltaTime;
		if (!DragEnabled())
		{
			return;
		}
		if (carryingInventoryObject)
		{
			cursorRef.SetCursor(CursorController.CursorType.GRABBING);
			return;
		}
		if (!carryingObject)
		{
			CheckForNewObject();
		}
		else
		{
			CheckTossObject();
			cursorRef.SetCursor(CursorController.CursorType.GRABBING);
		}
		DistractNearbyDogs();
	}

	private void UpdateFramerateCounter()
	{
		if (fCounter >= granularity)
		{
			fCounter = 0;
			float num = 0f;
			for (int i = 0; i < pastRates.Count; i++)
			{
				num += pastRates[i];
			}
			float num2 = num / (float)pastRates.Count;
			pastRates.Clear();
			averageFramerate = 1f / num2;
		}
		else
		{
			fCounter++;
			pastRates.Add(Time.unscaledDeltaTime);
		}
		if (timeCounter < refreshTime)
		{
			timeCounter += Time.deltaTime;
			frameCounter++;
			return;
		}
		lastFramerate = Mathf.Min((float)frameCounter / timeCounter, 60f);
		float percentage = 1f - Mathf.Min(MathUtil.GetPercentageOfRange(Mathf.Max(lastFramerate, minFramerate), minFramerate, maxFramerate), 1f);
		usableHoldTimeForGrab = MathUtil.GetValueOfRangePercentage(percentage, minHoldTimeForGrab, minHoldTimeForGrabAdjustedMax);
		frameCounter = 0;
		timeCounter = 0f;
	}

	private void ClearInputBuffer()
	{
		inputBuffer.Clear();
	}

	private void UpdateInputBuffer()
	{
		if (cursorRef.IsSystemMouseActive())
		{
			inputBuffer.Add(new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f));
		}
		else
		{
			inputBuffer.Add(new Vector3(InputManager.MouseProvider.GetDeltaX(), InputManager.MouseProvider.GetDeltaY(), 0f) / 2f);
		}
		if (inputBuffer.Count > inputSamplesMax)
		{
			inputBuffer.RemoveAt(0);
		}
	}

	private Vector3 GetSmoothedInput()
	{
		if (inputBuffer.Count == 0)
		{
			return Vector3.zero;
		}
		Vector3 zero = Vector3.zero;
		for (int i = 0; i < inputBuffer.Count; i++)
		{
			zero += inputBuffer[i];
		}
		zero /= (float)inputBuffer.Count;
		float num = averageFramerate / tunedFramerate;
		if (!cursorRef.IsSystemMouseActive())
		{
			num = 1f;
		}
		return zero * num;
	}

	private void FixedUpdate()
	{
		if (DragEnabled())
		{
			UpdateInputBuffer();
			if ((carryingInventoryObject || carryingObject) && GetConnectedBody() == null)
			{
				DropObject();
			}
			else if (carryingInventoryObject)
			{
				DragInventoryObject();
				DragObject();
				UpdateLocationVis();
			}
			else if (inDogSelectionMode)
			{
				CheckDogSelect();
			}
			else
			{
				ProcessMouseInput();
			}
		}
	}

	private void LateUpdate()
	{
		if (DragEnabled())
		{
			if (carryingInventoryObject)
			{
				CheckInventoryPlacement();
			}
			else
			{
				CheckDropObject();
			}
		}
	}

	public void RequestFrameWait()
	{
		frameWait++;
	}

	public void EnableGrabber(LockReason lockReason)
	{
		if (dragLocks.Contains(lockReason))
		{
			dragLocks.Remove(lockReason);
		}
	}

	public void DisableGrabber(LockReason lockReason)
	{
		if (dragLocks.Contains(lockReason))
		{
			Debug.LogError(string.Concat("Attempting to add lock reason: ", lockReason, " but it already exists."));
			return;
		}
		dragLocks.Add(lockReason);
		if (carryingObject)
		{
			DropObject();
		}
		RemoveHighlight();
		RemoveHighlight(secondaryHighlight: true);
		DeactivateIndicator();
		cursorRef.SetCursor(CursorController.CursorType.DEFAULT);
	}

	public bool DoesGrabbedObjectIntersectWithStage()
	{
		BoundingBoxComponent grabbedBoundingBox = GetGrabbedBoundingBox();
		if (grabbedBoundingBox == null)
		{
			return false;
		}
		return grabbedBoundingBox.CheckStageIntersect(forceCheck: true);
	}

	public float GetMaxBoundOfGrabbedObject()
	{
		BoundingBoxComponent grabbedBoundingBox = GetGrabbedBoundingBox();
		if (grabbedBoundingBox == null)
		{
			return 1f;
		}
		return grabbedBoundingBox.GetMaxBound();
	}

	public BoundingBoxComponent GetGrabbedBoundingBox()
	{
		GameObject grabbedObject = GetGrabbedObject();
		if (grabbedObject == null)
		{
			return null;
		}
		BoundingBoxComponent boundingBoxComponent = grabbedObject.GetComponent<BoundingBoxComponent>();
		if (boundingBoxComponent == null)
		{
			boundingBoxComponent = grabbedObject.AddComponent<BoundingBoxComponent>();
		}
		return boundingBoxComponent;
	}

	public bool IsCarryingInventoryObject()
	{
		return carryingInventoryObject;
	}

	public bool IsHoldingObject()
	{
		return GetGrabbedObject() != null;
	}

	public bool IsHoldingDog()
	{
		return carryingDog;
	}

	public bool IsHoldingOrHighlightingObject()
	{
		if (isHighlightingCollectable)
		{
			return true;
		}
		if (currentHighlightedObject != null)
		{
			return true;
		}
		if (GetGrabbedObject() != null)
		{
			return true;
		}
		return false;
	}

	public GameObject GetGrabbedObject()
	{
		if (!carryingDog && !carryingObject && !carryingInventoryObject)
		{
			return null;
		}
		Rigidbody connectedBody = GetConnectedBody();
		if (connectedBody == null)
		{
			return null;
		}
		return connectedBody.transform.root.gameObject;
	}

	private void ProcessMouseInput()
	{
		if (carryingObject)
		{
			CheckDragObject();
			UpdateLocationVis();
		}
	}

	private void CheckTossObject()
	{
		if (GameControls.actions.TossHeldObject.WasPressed)
		{
			TossObject();
		}
		else
		{
			if (!GameControls.actions.DestroyHeldObject.WasPressed || sceneManagerRef.GetGameMode() == GameMode.BREEDING)
			{
				return;
			}
			bool flag = carryingDog;
			GameObject grabbedObject = GetGrabbedObject();
			if (!(grabbedObject.GetComponent<PlaceableObject>() != null))
			{
				DropObject();
				if (flag)
				{
					dogRegRef.SaveDog(grabbedObject, inWorld: false);
				}
				if (grabbedObject.CompareTag(Tags.POOP))
				{
					GoalsController.ReportGoalEvent(GoalCondition.CLEAN_POOP);
				}
				OnObjectRemovedByPlayer(grabbedObject);
				Object.Destroy(grabbedObject);
			}
		}
	}

	private void TossObject()
	{
		Rigidbody connectedBody;
		Vector3 force;
		if (carryingDog)
		{
			connectedBody = objectCarrier.GetComponent<SpringJoint>().connectedBody;
			force = mainCam.transform.forward * dogTossForce;
		}
		else
		{
			connectedBody = objectCarrier.GetComponent<SpringJoint>().connectedBody;
			if (connectedBody.GetComponent<Rigidbody>() == null)
			{
				connectedBody.GetComponentInChildren<Rigidbody>();
			}
			force = mainCam.transform.forward * objectTossForce * connectedBody.GetComponent<Rigidbody>().mass;
		}
		AudioController.Play(throwObjectSound, objectCarrier.transform.position);
		DropObject();
		penFocusRef.EnableRotationIconBuffer();
		connectedBody.transform.root.GetComponent<InteractableBase>().OnObjectThrownByPlayer();
		connectedBody.GetComponentInChildren<Rigidbody>().AddForce(force, ForceMode.Impulse);
	}

	private void CheckForNewObject()
	{
		if (frameWait > 0)
		{
			frameWait--;
			return;
		}
		InteractableBase interactableBase = null;
		RaycastHit hitInfo = default(RaycastHit);
		GameObject gameObject = GetHitTarget(ref hitInfo);
		bool flag = true;
		if (cursorRef != null)
		{
			if (!cursorRef.IsPassiveModeCursorEnabled())
			{
				gameObject = null;
			}
			if (gameObject != null)
			{
				interactableBase = gameObject.transform.root.gameObject.GetComponent<InteractableBase>();
				if (grabAndClickTags.Contains(gameObject.transform.root.tag))
				{
					cursorRef.SetCursor(CursorController.CursorType.CLICKABLE);
				}
				else if (gameObject.transform.CompareTag(Tags.CLICKABLE_OBJECT))
				{
					ClickableObject component = gameObject.transform.parent.GetComponent<ClickableObject>();
					if (component != null && component.CanHighlight())
					{
						cursorRef.SetCursor(CursorController.CursorType.CLICKABLE);
					}
					else
					{
						flag = false;
						cursorRef.SetCursor(CursorController.CursorType.LOCKED_CLICKABLE);
					}
				}
				else if (gameObject.transform.root.CompareTag(Tags.CLICKABLE_OBJECT))
				{
					if (gameObject.transform.root.GetComponent<ClickableObject>().CanHighlight())
					{
						cursorRef.SetCursor(CursorController.CursorType.CLICKABLE);
					}
					else
					{
						flag = false;
						cursorRef.SetCursor(CursorController.CursorType.LOCKED_CLICKABLE);
					}
				}
				else if (gameObject.transform.root.CompareTag(Tags.DOG_DEN) || gameObject.transform.root.CompareTag(Tags.HOLE) || gameObject.transform.root.CompareTag(Tags.TV) || gameObject.transform.root.CompareTag(Tags.FAN) || gameObject.transform.root.CompareTag(Tags.DOG_STACK) || gameObject.transform.root.CompareTag(Tags.DOG_MEMORIAL) || gameObject.transform.root.CompareTag(Tags.BOPPER) || gameObject.transform.root.CompareTag(Tags.MUSIC_PLAYER) || gameObject.transform.root.CompareTag(Tags.SNOWGLOBE) || gameObject.transform.root.CompareTag(Tags.SAMPLESTABLE) || gameObject.transform.root.CompareTag(Tags.PRICKLYPEAR))
				{
					cursorRef.SetCursor(CursorController.CursorType.CLICKABLE);
				}
				else if (gameObject.transform.root.CompareTag(Tags.PUDDLE))
				{
					cursorRef.SetCursor(CursorController.CursorType.BLOWDRY);
				}
				else if (gameObject.transform.root.GetComponent<RoomBase>() != null)
				{
					if (penFocusRef.GetFocusedRoom() != gameObject.transform.root.gameObject && penFocusRef.GetRoomForFocusedObject() != gameObject.transform.root.gameObject)
					{
						gameObject = null;
					}
					else if (GameControls.actions.Interact.WasPressed && flag)
					{
						ReportClick(gameObject.transform.root.gameObject, hitInfo.point);
						return;
					}
				}
				else
				{
					cursorRef.SetCursor(CursorController.CursorType.GRABBABLE);
				}
			}
		}
		if ((GameControls.actions.CameraRotateMode.WasPressed || GameControls.actions.CameraPanMode.WasPressed || GameControls.actions.Cancel.WasPressed) && flag)
		{
			ReportClick(null, null, leftClick: false);
		}
		if (GameControls.actions.Interact.WasPressed && flag)
		{
			if (gameObject == null)
			{
				ReportClick(null);
				RemoveHighlight();
			}
			else if (CheckDoubleClick(gameObject))
			{
				DeactivateIndicator();
			}
			else if (Input.GetKey(KeyCode.LeftControl) && gameObject.transform.root.CompareTag(Tags.DOG))
			{
				SaveableDog saveableDogFromDog = dogRegRef.GetSaveableDogFromDog(gameObject.transform.root.gameObject);
				if (saveableDogFromDog != null)
				{
					Console.LogInfo("Dog ID: " + saveableDogFromDog.dogName + " " + saveableDogFromDog.dogID);
				}
				else
				{
					Console.LogError("Not a valid dog.");
				}
			}
			else if (gameObject.transform.root.CompareTag(Tags.DOG_DEN) || gameObject.transform.root.CompareTag(Tags.HOLE) || gameObject.transform.root.CompareTag(Tags.TV) || gameObject.transform.root.CompareTag(Tags.FAN) || gameObject.transform.root.CompareTag(Tags.DOG_STACK) || gameObject.transform.root.CompareTag(Tags.DOG_MEMORIAL) || gameObject.transform.root.CompareTag(Tags.BOPPER) || gameObject.transform.root.CompareTag(Tags.MUSIC_PLAYER) || gameObject.transform.root.CompareTag(Tags.SNOWGLOBE) || gameObject.transform.root.CompareTag(Tags.SAMPLESTABLE) || gameObject.transform.root.CompareTag(Tags.PRICKLYPEAR))
			{
				ReportClick(gameObject.transform.root.gameObject);
			}
			else if (gameObject.transform.root.CompareTag(Tags.CLICKABLE_OBJECT))
			{
				gameObject.transform.root.GetComponent<ClickableObject>().OnClick();
			}
			else if (gameObject.CompareTag(Tags.CLICKABLE_OBJECT))
			{
				ClickableObject component2 = gameObject.transform.parent.GetComponent<ClickableObject>();
				if (component2 != null)
				{
					component2.OnClick();
				}
			}
			else
			{
				PickupObject(gameObject, hitInfo.point, gameObject.transform.root.gameObject.CompareTag(Tags.DOG));
			}
		}
		else if (GameControls.actions.Interact.IsPressed)
		{
			if (!(gameObject == null) && gameObject.transform.root.CompareTag(Tags.PUDDLE))
			{
				gameObject.transform.root.GetComponent<LiquidPuddle>().OnCleanup();
			}
		}
		else if (gameObject != null && flag)
		{
			if (gameObject.CompareTag(Tags.CLICKABLE_OBJECT) || gameObject.CompareTag(Tags.DOG_DEN))
			{
				HighlightObject(gameObject.transform.parent.gameObject);
			}
			else if (gameObject.transform.root.GetComponent<RoomBase>() == null)
			{
				HighlightObject(gameObject.transform.root.gameObject);
			}
			else
			{
				RemoveHighlight();
			}
		}
		else if (interactableBase == null)
		{
			RemoveHighlight();
		}
	}

	private bool CheckDoubleClick(GameObject hitTarget)
	{
		if (sceneManagerRef.GetGameMode() == GameMode.BREEDING)
		{
			return false;
		}
		bool result = false;
		ulong? num = null;
		if (hitTarget.transform.root.CompareTag(Tags.DOG))
		{
			num = dogRegRef.GetSaveableDogFromDog(hitTarget.transform.root.gameObject).dogID;
		}
		else if (hitTarget.transform.root.CompareTag(Tags.COCOON))
		{
			num = hitTarget.transform.root.GetComponent<Cocoon>().GetAssociatedDogID();
		}
		if (num.HasValue)
		{
			if (num == lastClickedDogID)
			{
				float time = Time.time;
				if (time - lastClickTime <= doubleClickWindow)
				{
					lastClickTime = -100f;
					lastClickedDogID = null;
					result = true;
					dogRegRef.SelectDog(num, fromDoubleClick: true);
					AudioController.Play(doubleClickSound);
					Object.Instantiate(doubleClickParticles, hitTarget.transform.root.GetComponent<BoundingBoxComponent>().GetBoxCenter(), Quaternion.identity);
				}
				lastClickedDogID = num;
				lastClickTime = time;
			}
			else
			{
				lastClickedDogID = num;
				lastClickTime = Time.time;
			}
		}
		else
		{
			lastClickTime = -100f;
			lastClickedDogID = null;
		}
		return result;
	}

	private void CheckDogSelect()
	{
		if (needsMouseUp && GameControls.actions.Interact.WasReleased)
		{
			needsMouseUp = false;
		}
		if (Time.frameCount <= dogSelectionEnterFrame + 1)
		{
			return;
		}
		RaycastHit hitInfo = default(RaycastHit);
		GameObject hitTarget = GetHitTarget(ref hitInfo);
		if (hitTarget == null || !hitTarget.transform.root.CompareTag(Tags.DOG))
		{
			if (currentHighlightedObject != null)
			{
				RemoveHighlight(currentHighlightedObject);
			}
			return;
		}
		GameObject gameObject = hitTarget.transform.root.gameObject;
		if (gameObject == currentlySelectedBreedingObjecetA || gameObject == currentlySelectedBreedingObjecetB || gameObject == currentlySelectedBreedingObjecetFinal || gameObject == currentlyActiveDog)
		{
			return;
		}
		for (int i = 0; i < currentlyLevitatedObjects.Count; i++)
		{
			if (gameObject == currentlyLevitatedObjects[i])
			{
				return;
			}
		}
		HighlightObject(gameObject);
		if (!needsMouseUp && GameControls.actions.Interact.WasReleased)
		{
			CurrentDogSelectionCallback(hitInfo);
			ExitDogSelectionMode();
		}
	}

	public void HighlightObjectForLevitation(GameObject obj)
	{
		CleanUpLevitationData();
		if (!currentlyLevitatedObjects.Contains(obj))
		{
			currentlyLevitatedObjects.Add(obj);
			currentlyLevitatedObjectRequests.Add(1);
			HighlightObjectInternal(obj, levitationColor);
		}
		else
		{
			int index = currentlyLevitatedObjects.IndexOf(obj);
			currentlyLevitatedObjectRequests[index]++;
		}
	}

	public void ClearLevitationObject(GameObject obj)
	{
		if (!currentlyLevitatedObjects.Contains(obj))
		{
			RemoveHighlightInternal(obj);
			return;
		}
		CleanUpLevitationData();
		int index = currentlyLevitatedObjects.IndexOf(obj);
		currentlyLevitatedObjectRequests[index]--;
		if (currentlyLevitatedObjectRequests[index] <= 0)
		{
			currentlyLevitatedObjects.RemoveAt(index);
			currentlyLevitatedObjectRequests.RemoveAt(index);
			RemoveHighlightInternal(obj);
		}
	}

	private void CleanUpLevitationData()
	{
		for (int num = currentlyLevitatedObjects.Count - 1; num >= 0; num--)
		{
			if (currentlyLevitatedObjects[num] == null)
			{
				currentlyLevitatedObjects.RemoveAt(num);
			}
		}
	}

	public void SelectBreedingDogA(GameObject newDog)
	{
		currentlySelectedBreedingObjecetA = newDog;
		HighlightObjectInternal(newDog, breedingSelectionColorA);
	}

	public void SelectBreedingDogB(GameObject newDog)
	{
		currentlySelectedBreedingObjecetB = newDog;
		HighlightObjectInternal(newDog, breedingSelectionColorB);
	}

	public void SelectBreedingDogFinal(GameObject newDog)
	{
		currentlySelectedBreedingObjecetFinal = newDog;
		HighlightObjectInternal(newDog, breedingSelectionColorFinal);
	}

	public void HighlightActiveDog(GameObject dog)
	{
		currentlyActiveDog = dog;
		HighlightObjectInternal(dog, activeDogColor);
	}

	public void ClearBreedingDogA()
	{
		RemoveHighlightInternal(currentlySelectedBreedingObjecetA);
		currentlySelectedBreedingObjecetA = null;
	}

	public void ClearBreedingDogB()
	{
		RemoveHighlightInternal(currentlySelectedBreedingObjecetB);
		currentlySelectedBreedingObjecetB = null;
	}

	public void ClearBreedingDogFinal()
	{
		RemoveHighlightInternal(currentlySelectedBreedingObjecetFinal);
		currentlySelectedBreedingObjecetFinal = null;
	}

	public void ClearActiveDog(GameObject indicatedObject)
	{
		if (!(indicatedObject != currentlyActiveDog))
		{
			RemoveHighlightInternal(currentlyActiveDog);
			currentlyActiveDog = null;
		}
	}

	private GameObject GetHitTarget(ref RaycastHit hitInfo)
	{
		bool flag = Time.realtimeSinceStartup - lastSelectedObjectTime <= objectSelectionBuffer;
		if (cursorRef.IsSystemMouseActive())
		{
			flag = false;
		}
		if (!flag)
		{
			lastSelectedObject = null;
		}
		if (cursorRef.HasOverrideUIElement())
		{
			return null;
		}
		hitInfo = default(RaycastHit);
		Ray ray = mainCam.ScreenPointToRay(InputManager.MouseProvider.GetPosition());
		int num = RaycastUtil.DogGrabberCastAllNonAlloc(ray.origin, ray.direction, results, raycastDist);
		if (num == 0)
		{
			if (flag && lastSelectedObject != null)
			{
				hitInfo = lastRaycastHit;
				return lastSelectedObject;
			}
			return null;
		}
		RaycastHit raycastHit = hitInfo;
		GameObject result = null;
		float num2 = float.PositiveInfinity;
		for (int i = 0; i < num; i++)
		{
			GameObject gameObject = results[i].transform.gameObject;
			BuildObjectInfo component = results[i].transform.root.gameObject.GetComponent<BuildObjectInfo>();
			if (component != null && !component.CanHighlight())
			{
				continue;
			}
			if (gameObject.layer == RaycastUtil.stageLayer)
			{
				Renderer component2 = gameObject.GetComponent<Renderer>();
				if (component2 != null && !component2.enabled)
				{
					continue;
				}
			}
			float num3 = Vector3.Distance(results[i].point, ray.origin);
			if (num3 < num2)
			{
				num2 = num3;
				raycastHit = results[i];
				result = gameObject;
			}
		}
		if (raycastHit.transform != null)
		{
			GameObject gameObject2 = raycastHit.transform.root.gameObject;
			if (clickableTags.Contains(gameObject2.tag))
			{
				hitInfo = raycastHit;
				lastRaycastHit = hitInfo;
				lastSelectedObject = result;
				lastSelectedObjectTime = Time.realtimeSinceStartup;
				return result;
			}
			if (raycastHit.transform.CompareTag(Tags.CLICKABLE_OBJECT))
			{
				hitInfo = raycastHit;
				return result;
			}
			RoomBase component3 = gameObject2.GetComponent<RoomBase>();
			if (component3 != null && component3.GetWallForDirection(WallDirection.DOWN).gameObject == raycastHit.transform.parent.gameObject)
			{
				if (flag && lastSelectedObject != null)
				{
					hitInfo = lastRaycastHit;
					return lastSelectedObject;
				}
				hitInfo = raycastHit;
				return result;
			}
		}
		hitInfo = default(RaycastHit);
		return null;
	}

	private void CheckDragObject()
	{
		if (GameControls.actions.Interact.IsPressed)
		{
			DragObject();
		}
	}

	private void EnableLocationVis(GameObject obj)
	{
		hasCreatedLocationVis = true;
		locationObj.SetActive(value: true);
		locationCircle.SetActive(value: true);
		RequestCircleSizeChange(GetCircleSizeForObject(obj));
		UpdateLocationVis();
	}

	private float GetCircleSizeForObject(GameObject obj)
	{
		BoundingBoxComponent boundingBoxComponent = obj.GetComponent<BoundingBoxComponent>();
		if (boundingBoxComponent == null)
		{
			boundingBoxComponent = obj.AddComponent<BoundingBoxComponent>();
		}
		return Mathf.Max(boundingBoxComponent.GetBoxSize().x, boundingBoxComponent.GetBoxSize().z);
	}

	private void DisableLocationVis()
	{
		locationObj.SetActive(value: false);
		if (timeDelayedLocationRoutine != null)
		{
			StopCoroutine(timeDelayedLocationRoutine);
			timeDelayedLocationRoutine = null;
		}
		if (currentCircleEaseRoutine != null)
		{
			StopCoroutine(currentCircleEaseRoutine);
			currentCircleEaseRoutine = null;
		}
		RequestCircleSizeChange(0f);
		RemoveLocationHighlight();
	}

	private void RequestCircleSizeChange(float newSize)
	{
		if (currentCircleEaseRoutine != null)
		{
			StopCoroutine(currentCircleEaseRoutine);
			currentCircleEaseRoutine = null;
		}
		if (newSize == 0f)
		{
			currentCircleEaseRoutine = StartCoroutine(CircleEaseOutRoutine());
		}
		else
		{
			currentCircleEaseRoutine = StartCoroutine(CircleEaseInRoutine(newSize));
		}
	}

	private void AddLocationHighlight(GameObject obj)
	{
		if (currentLocationHighlightedObject == obj || obj == currentlySelectedBreedingObjecetA || obj == currentlySelectedBreedingObjecetB || obj == currentlySelectedBreedingObjecetFinal || obj == currentlyActiveDog)
		{
			return;
		}
		for (int i = 0; i < currentlyLevitatedObjects.Count; i++)
		{
			if (obj == currentlyLevitatedObjects[i])
			{
				return;
			}
		}
		if (currentLocationHighlightedObject != null)
		{
			RemoveLocationHighlight();
		}
		HighlightObjectInternal(obj, locationHighlightColor);
		currentLocationHighlightedObject = obj;
	}

	private void RemoveLocationHighlight()
	{
		if (currentLocationHighlightedObject == null || currentLocationHighlightedObject == currentlySelectedBreedingObjecetA || currentLocationHighlightedObject == currentlySelectedBreedingObjecetB || currentLocationHighlightedObject == currentlySelectedBreedingObjecetFinal || currentLocationHighlightedObject == currentlyActiveDog)
		{
			return;
		}
		for (int i = 0; i < currentlyLevitatedObjects.Count; i++)
		{
			if (currentLocationHighlightedObject == currentlyLevitatedObjects[i])
			{
				return;
			}
		}
		if (currentHighlightedObject == currentLocationHighlightedObject)
		{
			RemoveHighlight(currentLocationHighlightedObject);
			HighlightObject(currentLocationHighlightedObject);
		}
		else if (currentSecondaryHighlightedObject == currentLocationHighlightedObject)
		{
			RemoveHighlight(currentLocationHighlightedObject);
			HighlightObject(currentLocationHighlightedObject, secondaryHighlight: true);
		}
		else
		{
			RemoveHighlightInternal(currentLocationHighlightedObject);
		}
		currentLocationHighlightedObject = null;
	}

	private void UpdateLocationVis()
	{
		locationObj.transform.position = objectCarrier.transform.position;
		Vector3 vector = locationObj.transform.position + Vector3.down * raycastDist;
		RaycastHit closestHitIgnoringObject = RaycastUtil.GetClosestHitIgnoringObject(RaycastUtil.GoodRaycastAllNonAlloc(locationObj.transform.position, Vector3.down, raycastDist, results), locationObj.transform.position, results, GetGrabbedObject());
		if (closestHitIgnoringObject.transform != null)
		{
			vector = closestHitIgnoringObject.point;
		}
		RaycastUtil.StageRaycast(locationObj.transform.position, Vector3.down, out var hitInfo, raycastDist);
		if (closestHitIgnoringObject.transform != null && closestHitIgnoringObject.transform.gameObject.layer != RaycastUtil.stageLayer && closestHitIgnoringObject.transform.root.GetComponent<RoomBase>() == null)
		{
			AddLocationHighlight(closestHitIgnoringObject.transform.root.gameObject);
		}
		else
		{
			RemoveLocationHighlight();
		}
		locationCircle.transform.position = hitInfo.point + new Vector3(0f, 0.01f, 0f);
		locationObj.transform.localScale = new Vector3(locationObj.transform.localScale.x, locationObj.transform.localScale.y, (locationObj.transform.position.y - vector.y) / 2f);
		locationObjFadMat.SetFloat("_Top", locationObj.transform.position.y);
		locationObjFadMat.SetFloat("_Bottom", hitInfo.point.y);
	}

	private IEnumerator CircleEaseInRoutine(float targetSize)
	{
		float offChange = 0.25f;
		float timer = 0f;
		float easeInTime1 = 0.1f;
		float startSize = locationCircle.transform.localScale.x;
		while (timer <= easeInTime1)
		{
			float quadraticOutValue = Inchworm.GetQuadraticOutValue(timer, startSize, startSize - targetSize - offChange, easeInTime1);
			locationCircle.transform.localScale = new Vector3(quadraticOutValue, quadraticOutValue, quadraticOutValue);
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		timer = 0f;
		float easeOutTime = 0.1f;
		startSize = locationCircle.transform.localScale.x;
		while (timer <= easeOutTime)
		{
			float quadraticOutValue2 = Inchworm.GetQuadraticOutValue(timer, startSize, offChange, easeOutTime);
			locationCircle.transform.localScale = new Vector3(quadraticOutValue2, quadraticOutValue2, quadraticOutValue2);
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		currentCircleEaseRoutine = null;
	}

	private IEnumerator CircleEaseOutRoutine()
	{
		float offChange = 0.25f;
		float timer = 0f;
		float easeInTime1 = 0.1f;
		float startSize = locationCircle.transform.localScale.x;
		while (timer <= easeInTime1)
		{
			float quadraticInValue = Inchworm.GetQuadraticInValue(timer, startSize, 0f - offChange, easeInTime1);
			locationCircle.transform.localScale = new Vector3(quadraticInValue, quadraticInValue, quadraticInValue);
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		timer = 0f;
		float easeOutTime = 0.1f;
		startSize = locationCircle.transform.localScale.x;
		while (timer <= easeOutTime)
		{
			float quadraticInValue2 = Inchworm.GetQuadraticInValue(timer, startSize, startSize, easeOutTime);
			locationCircle.transform.localScale = new Vector3(quadraticInValue2, quadraticInValue2, quadraticInValue2);
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		locationCircle.SetActive(value: false);
		currentCircleEaseRoutine = null;
	}

	private void CheckDropObject()
	{
		bool flag = Time.unscaledTime - holdTimeStart >= usableHoldTimeForGrab;
		if (!flag && Vector3.Distance(clickStartPos, InputManager.MouseProvider.GetPosition()) > maxMouseDistForClick)
		{
			flag = true;
		}
		if (!GameControls.actions.Interact.IsPressed)
		{
			DropObject();
		}
		else
		{
			if (!(GetConnectedBody() != null))
			{
				return;
			}
			if (flag && !hasPushedGrabReactions)
			{
				hasPushedGrabReactions = true;
				InteractableBase component = GetGrabbedObject().transform.root.GetComponent<InteractableBase>();
				component.OnObjectGrabbedByPlayer();
				if (!IsHoldingDog())
				{
					return;
				}
				SitBehavior component2 = component.GetComponent<SitBehavior>();
				LegController component3 = component.GetComponent<LegController>();
				if (carriedAIRef != null)
				{
					carriedAIRef.OnGrabbedByPlayer();
					if ((carriedDenRef != null && carriedDenRef.IsDigging()) || component2.IsSitting())
					{
						carriedAIRef.ForceInterruptBehavior();
					}
				}
				component3.LoosenAbs(LooseAbsLock.GRABBED);
			}
			else if (flag && hasPushedGrabReactions && carriedAIRef != null && carriedDenRef != null && carriedDenRef.IsDigging())
			{
				carriedAIRef.ForceInterruptBehavior();
			}
		}
	}

	private void ReportMouseOver(GameObject obj)
	{
		indicatorManagerRef.ReportMouseOver(obj);
		if (obj.CompareTag(Tags.DOG))
		{
			obj.GetComponent<DogIndicatorController>().ReportMouseOver();
		}
	}

	private void ReportMouseOff(GameObject obj)
	{
		indicatorManagerRef.ReportMouseOff(obj);
		if (obj.CompareTag(Tags.DOG))
		{
			obj.GetComponent<DogIndicatorController>().ReportMouseOff();
		}
	}

	public void DeactivateIndicator()
	{
		stageIndicatorActive = false;
		indicatorRef.CloseContextMenu(fromDeactivation: true);
		indicatorRef.gameObject.SetActive(value: false);
	}

	public void ReportIndicatorActive()
	{
		stageIndicatorActive = true;
	}

	private void ReportClick(GameObject obj, Vector3? clickPos = null, bool leftClick = true)
	{
		if (indicatorManagerRef == null)
		{
			return;
		}
		RoomBase roomBase = null;
		if (obj != null)
		{
			roomBase = obj.GetComponent<RoomBase>();
		}
		if (roomBase != null && indicatorManagerRef.IsObjectIndicatorActive())
		{
			obj = null;
			roomBase = null;
		}
		if (stageIndicatorActive)
		{
			if (indicatorManagerRef.IsMouseOverContextButton() && leftClick)
			{
				return;
			}
			DeactivateIndicator();
			if (roomBase != null)
			{
				return;
			}
		}
		if (roomBase != null)
		{
			if (!clickPos.HasValue)
			{
				Debug.LogError("No click pos specified for room action.");
				clickPos = obj.transform.position;
			}
			SaveableDog selectedDog = dogRegRef.GetSelectedDog();
			if (selectedDog != null && !selectedDog.inCocoon)
			{
				stageIndicatorActive = true;
				indicatorRef.SetFollowPosition(clickPos.Value);
				indicatorRef.gameObject.SetActive(value: true);
				indicatorRef.UpdateBillboard();
				indicatorRef.ShowChoiceMenu();
				indicatorManagerRef.ReportClick(null, leftClick);
				indicatorRef.ShowContextMenuLocationCircle(clickPos.Value);
			}
		}
		else
		{
			indicatorManagerRef.ReportClick(obj, leftClick);
		}
	}

	private void HighlightObject(GameObject obj, bool secondaryHighlight = false)
	{
		if (obj == currentlySelectedBreedingObjecetA || obj == currentlySelectedBreedingObjecetB || obj == currentlySelectedBreedingObjecetFinal || obj == currentlyActiveDog)
		{
			return;
		}
		for (int i = 0; i < currentlyLevitatedObjects.Count; i++)
		{
			if (obj == currentlyLevitatedObjects[i])
			{
				return;
			}
		}
		if (secondaryHighlight || !(obj == currentSecondaryHighlightedObject))
		{
			if (secondaryHighlight && obj == currentHighlightedObject)
			{
				RemoveHighlight();
			}
			GameObject gameObject = (secondaryHighlight ? currentSecondaryHighlightedObject : currentHighlightedObject);
			if (gameObject != obj)
			{
				RemoveHighlight(secondaryHighlight);
			}
			else if (gameObject != null)
			{
				return;
			}
			HighlightObjectInternal(obj, secondaryHighlight ? secondaryHighlightColor : highlightColor);
			if (secondaryHighlight)
			{
				currentSecondaryHighlightedObject = obj;
			}
			else
			{
				currentHighlightedObject = obj;
			}
			if (!secondaryHighlight)
			{
				ReportMouseOver(obj);
			}
		}
	}

	private void HighlightObjectInternal(GameObject obj, Color c)
	{
		if (!(obj == null))
		{
			Highlighter[] array = obj.GetComponentsInChildren<Highlighter>();
			if (array.Length == 0)
			{
				array = new Highlighter[1] { obj.AddComponent<Highlighter>() };
				array[0].overlay = true;
			}
			for (int i = 0; i < array.Length; i++)
			{
				array[i].ConstantOnImmediate(c);
			}
		}
	}

	private void RemoveHighlight(bool secondaryHighlight = false)
	{
		isHighlightingCollectable = false;
		GameObject gameObject = (secondaryHighlight ? currentSecondaryHighlightedObject : currentHighlightedObject);
		if (gameObject == null || gameObject == currentlySelectedBreedingObjecetA || gameObject == currentlySelectedBreedingObjecetB || gameObject == currentlySelectedBreedingObjecetFinal || gameObject == currentlyActiveDog)
		{
			return;
		}
		for (int i = 0; i < currentlyLevitatedObjects.Count; i++)
		{
			if (gameObject == currentlyLevitatedObjects[i])
			{
				return;
			}
		}
		RemoveHighlightInternal(gameObject);
		ReportMouseOff(gameObject);
		if (secondaryHighlight)
		{
			currentSecondaryHighlightedObject = null;
		}
		else
		{
			currentHighlightedObject = null;
		}
	}

	private void RemoveHighlightInternal(GameObject obj)
	{
		if (!(obj == null))
		{
			Highlighter[] componentsInChildren = obj.GetComponentsInChildren<Highlighter>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].ConstantOffImmediate();
			}
		}
	}

	public void EnterDogSelectionMode(DogSelectionCallback callback)
	{
		if (inDogSelectionMode)
		{
			Debug.LogError("Attempting to double enter dog selection mode.");
			return;
		}
		inDogSelectionMode = true;
		if (CurrentDogSelectionCallback != null)
		{
			Debug.LogError("CurrentDogSelectionCallback being double set");
		}
		CurrentDogSelectionCallback = callback;
		dogSelectionEnterFrame = Time.frameCount;
	}

	public void HoldObjectForPlacement(InventoryItem itemType, PlaceObjectCallback callback, PlacementEndCallback earlyEndCallback)
	{
		if (carryingInventoryObject)
		{
			return;
		}
		if (PlacementCallback != null)
		{
			Debug.LogError("PlacementCallback being double set");
		}
		PlacementCallback = callback;
		PlacementOverCallback = earlyEndCallback;
		carryingInventoryObject = true;
		GameObject focusedRoom = penFocusRef.GetFocusedRoom();
		if (focusedRoom != null)
		{
			ulong? expectedRoom = focusedRoom.GetComponent<BuildObjectInfo>().GetUID();
			GameObject gameObject = homeRef.TrySpawnItem(itemType, Vector3.zero, expectedRoom, moveToGoodLocation: false);
			ObjectRegistration.AddRegisteredComponents(gameObject);
			gameObject.GetComponent<RegisterTaggedObject>().SetSafeDestroy();
			OOBDestroy component = gameObject.GetComponent<OOBDestroy>();
			if (component != null)
			{
				Object.Destroy(component);
			}
			needsRenderEnable = true;
			penFocusRef.DisableModularZoom();
			ReadyObject(gameObject, constructionRef.GetObjectForUID(expectedRoom.Value));
		}
		else
		{
			Debug.LogError("Not currently focusing on a room! Cannot place an object.");
		}
	}

	private void ReadyObject(GameObject objectToPlace, GameObject room)
	{
		Vector3 roomCenter = DogHome.GetRoomCenter(room);
		roomCenter.x = mainCam.ScreenToWorldPoint(InputManager.MouseProvider.GetPosition()).x;
		objectToPlace.transform.position = roomCenter;
		Rigidbody rigidbody = objectToPlace.GetComponent<Rigidbody>();
		if (rigidbody == null)
		{
			rigidbody = objectToPlace.GetComponentInChildren<Rigidbody>();
		}
		BoundingBoxComponent boundingBoxComponent = objectToPlace.GetComponent<BoundingBoxComponent>();
		if (boundingBoxComponent == null)
		{
			boundingBoxComponent = objectToPlace.AddComponent<BoundingBoxComponent>();
		}
		Vector3 boxSize = boundingBoxComponent.GetBoxSize();
		PickupObject(rigidbody.gameObject, boundingBoxComponent.GetBoxCenter() + new Vector3(boxSize.x, boxSize.y, 0f), isDog: false);
		if (GameControls.actions.Interact.IsPressed)
		{
			needsMouseUp = true;
		}
		else
		{
			needsMouseUp = false;
		}
	}

	public void StopHoldingObjectForPlacement()
	{
		needsMouseUp = false;
		PlacementCallback = null;
		PlacementOverCallback = null;
		if (carryingInventoryObject)
		{
			if (constructionRef != null)
			{
				constructionRef.EnableModularZoom();
			}
			carryingInventoryObject = false;
			Rigidbody connectedBody = GetConnectedBody();
			if (connectedBody != null)
			{
				Object.Destroy(connectedBody.transform.root.gameObject);
			}
			DisableLocationVis();
		}
	}

	public void ExitDogSelectionMode()
	{
		needsMouseUp = false;
		CurrentDogSelectionCallback = null;
		if (inDogSelectionMode)
		{
			inDogSelectionMode = false;
			Rigidbody connectedBody = objectCarrier.GetComponent<SpringJoint>().connectedBody;
			if (connectedBody != null)
			{
				connectedBody.useGravity = false;
			}
			objectCarrier.GetComponent<SpringJoint>().connectedBody = null;
			DisableLocationVis();
		}
	}

	private void CheckInventoryPlacement()
	{
		if (needsMouseUp && GameControls.actions.Interact.WasReleased)
		{
			needsMouseUp = false;
		}
		if (!needsMouseUp && GameControls.actions.Interact.WasPressed)
		{
			Rigidbody connectedBody = GetConnectedBody();
			PlacementCallback(connectedBody.transform.position, connectedBody.transform.rotation, GetGrabbedObject());
		}
		else if (GameControls.actions.Cancel.WasPressed || GameControls.actions.CloseMenu.WasPressed)
		{
			PlacementOverCallback();
		}
	}

	private void TurnOffColliders(GameObject obj)
	{
		SetColliders(obj, val: false);
	}

	private void TurnOnColliders(GameObject obj)
	{
		SetColliders(obj, val: true);
	}

	private void SetColliders(GameObject obj, bool val)
	{
		Collider[] components = obj.GetComponents<Collider>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].enabled = val;
		}
		components = obj.GetComponentsInChildren<Collider>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].enabled = val;
		}
		Rigidbody[] components2 = obj.GetComponents<Rigidbody>();
		for (int i = 0; i < components2.Length; i++)
		{
			components2[i].useGravity = !val;
		}
		components2 = obj.GetComponentsInChildren<Rigidbody>();
		for (int i = 0; i < components2.Length; i++)
		{
			components2[i].useGravity = !val;
		}
	}

	private void PickupObject(GameObject clickedBody, Vector3 hitPos, bool isDog)
	{
		if (clickedBody.GetComponent<Rigidbody>() == null)
		{
			return;
		}
		carryingDog = isDog;
		carryingObject = true;
		GameObject gameObject = clickedBody.transform.root.gameObject;
		InteractableBase component = clickedBody.transform.root.GetComponent<InteractableBase>();
		if (isDog)
		{
			carriedAIRef = gameObject.GetComponent<DogAI>();
			carriedDenRef = gameObject.GetComponent<DogDenController>();
		}
		if (clickedBody.layer == LayerMask.NameToLayer(faceLayerName) || clickedBody.CompareTag(tailTag) || clickedBody.CompareTag(wingTag))
		{
			clickedBody = gameObject.GetComponent<LegController>().bodyFront;
		}
		dragDict.Clear();
		Rigidbody[] componentsInChildren = gameObject.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigidbody in componentsInChildren)
		{
			dragDict[rigidbody] = rigidbody.angularDrag;
			rigidbody.angularDrag = grabbedAngularDrag;
		}
		objectCarrier.transform.position = hitPos;
		Rigidbody grabbedBody = component.GetGrabbedBody(clickedBody);
		if (isDog)
		{
			objectCarrier.GetComponent<SpringJoint>().connectedBody = grabbedBody;
			if (clickedBody.CompareTag(tailTag))
			{
				SetTailGrabWeights();
			}
			if (clickedBody.layer == LayerMask.NameToLayer(legsLayerName))
			{
				SetLegGrabWeights();
			}
			TurnInPlace component2 = gameObject.GetComponent<TurnInPlace>();
			if (component2.IsDoingPlantedTurn())
			{
				component2.RequestStop(forceDone: true);
			}
		}
		else
		{
			objectCarrier.GetComponent<SpringJoint>().connectedBody = grabbedBody;
		}
		BoundingBoxComponent grabbedBoundingBox = GetGrabbedBoundingBox();
		dragBoxCenterOffset = objectCarrierRB.transform.position - grabbedBoundingBox.GetBoxCenter();
		dragBoxSize = Vector3.one * 0.25f;
		Vector3 boxSize = grabbedBoundingBox.GetBoxSize();
		if (dragBoxSize.x > boxSize.x)
		{
			dragBoxSize.x = boxSize.x;
		}
		if (dragBoxSize.y > boxSize.y)
		{
			dragBoxSize.y = boxSize.y;
		}
		if (dragBoxSize.z > boxSize.z)
		{
			dragBoxSize.z = boxSize.z;
		}
		initialGrabOffset = Vector3.zero;
		initialGrabOffset = objectCarrier.transform.position - DragXZ();
		ClearInputBuffer();
		penFocusRef.DisableModularZoom();
		hasCreatedLocationVis = false;
		if (grabAndClickTags.Contains(gameObject.tag))
		{
			hasPushedGrabReactions = false;
			holdTimeStart = Time.unscaledTime;
			clickStartPos = InputManager.MouseProvider.GetPosition();
		}
		else
		{
			EnableLocationVis(gameObject);
		}
		ReportClick(null);
		AudioController.Play(grabObjectSound, objectCarrier.transform.position);
	}

	private void SetTailGrabWeights()
	{
		tailWeightOriginal = objectCarrier.GetComponent<SpringJoint>().connectedBody.mass;
		tailWeightDriveOriginal = objectCarrier.GetComponent<SpringJoint>().connectedBody.GetComponentInParent<TailController>().tailDrive.GetComponent<Rigidbody>().mass;
		SetTailWeights(tailWeightGrab, tailWeightGrab);
	}

	private void ClearTailGrabWeights()
	{
		SetTailWeights(tailWeightOriginal, tailWeightDriveOriginal);
	}

	private void SetTailWeights(float newWeightSegments, float newWeightDrive)
	{
		GameObject gameObject = objectCarrier.GetComponent<SpringJoint>().connectedBody.gameObject;
		gameObject = gameObject.GetComponentInParent<TailController>().gameObject;
		Rigidbody[] componentsInChildren = gameObject.GetComponentsInChildren<Rigidbody>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].mass = newWeightSegments;
		}
		gameObject.GetComponentInParent<TailController>().tailDrive.GetComponent<Rigidbody>().mass = newWeightDrive;
	}

	private void SetLegGrabWeights()
	{
		SetLegWeights(legWeightGrabMultiplier);
	}

	private void RemoveLegGrabWeights()
	{
		SetLegWeights(1f / legWeightGrabMultiplier);
	}

	private void SetLegWeights(float multiplier)
	{
		GameObject gameObject = objectCarrier.GetComponent<SpringJoint>().connectedBody.gameObject;
		while (gameObject.layer == LayerMask.NameToLayer(legsLayerName))
		{
			gameObject = gameObject.transform.parent.gameObject;
		}
		int childCount = gameObject.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			gameObject.transform.GetChild(i).GetComponent<Rigidbody>().mass = gameObject.transform.GetChild(i).GetComponent<Rigidbody>().mass * multiplier;
		}
	}

	private IEnumerator TimeDelayedLocationVisEnable(GameObject obj)
	{
		yield return new WaitForEndOfFrame();
		yield return new WaitForEndOfFrame();
		BoundingBoxComponent grabbedBoundingBox = GetGrabbedBoundingBox();
		if (grabbedBoundingBox != null)
		{
			grabbedBoundingBox.ForceUpdateBoundingBox();
		}
		EnableLocationVis(obj);
		timeDelayedLocationRoutine = null;
	}

	private void DragInventoryObject()
	{
		if (needsRenderEnable)
		{
			GameObject grabbedObject = GetGrabbedObject();
			timeDelayedLocationRoutine = StartCoroutine(TimeDelayedLocationVisEnable(grabbedObject));
			needsRenderEnable = false;
		}
	}

	private void DragObject()
	{
		if (!hasCreatedLocationVis && !IsValidClick())
		{
			EnableLocationVis(GetGrabbedObject());
		}
		DragObjectSmart();
	}

	private Vector3 DragXZ()
	{
		Vector3 position = objectCarrier.transform.position;
		if (!RaycastUtil.StageRaycast(position, Vector3.down, out var hitInfo, 100f))
		{
			return position;
		}
		Vector3 a = Camera.main.ScreenToWorldPoint(InputManager.MouseProvider.GetPosition());
		Ray ray = Camera.main.ScreenPointToRay(InputManager.MouseProvider.GetPosition());
		if (!hitInfo.collider.Raycast(ray, out hitInfo, Vector3.Distance(a, hitInfo.point) + 100f))
		{
			return position;
		}
		Vector3 point = hitInfo.point;
		point.y = position.y;
		return point + initialGrabOffset;
	}

	private Vector3 DragXY()
	{
		return objectCarrier.transform.position;
	}

	private void DragObjectSmart()
	{
		float num = 0.01f;
		Vector3 smoothedInput = GetSmoothedInput();
		float num2 = smoothedInput.x * moveMultiplier * num;
		float num3 = smoothedInput.y * moveMultiplier * num;
		float num4 = 0f;
		bool flag = false;
		if (GameControls.actions.DragModeVertical.IsPressed)
		{
			flag = true;
		}
		else
		{
			num4 = num3;
			num3 = 0f;
		}
		Vector3 vector = mainCam.transform.right * num2;
		Vector3 vector2 = Vector3.up * num3;
		Vector3 vector3 = mainCam.transform.forward * num4;
		vector.y = 0f;
		vector3.y = 0f;
		float num5 = 0f;
		GameControls.CheckScrollValuesIfNeeded();
		if (GameControls.actions.DragUp.IsPressed)
		{
			num5 = ((!GameControls.isDragUpScrollWheel || !(Input.mouseScrollDelta != Vector2.zero)) ? 0.25f : (1f * GameControls.currentScrollMultiplier));
		}
		else if (GameControls.actions.DragDown.IsPressed)
		{
			num5 = ((!GameControls.isDragDownScrollWheel || !(Input.mouseScrollDelta != Vector2.zero)) ? (-0.25f) : (-1f * GameControls.currentScrollMultiplier));
		}
		vector2 += Vector3.up * (num5 * scrollSpeed * Time.fixedDeltaTime);
		if (flag)
		{
			vector = Vector3.zero;
			vector3 = Vector3.zero;
		}
		else if (num5 == 0f)
		{
			vector2 = Vector3.zero;
		}
		Vector3 vector4 = vector + vector2 + vector3 + objectCarrierRB.transform.position;
		num2 = vector4.x;
		num3 = vector4.y;
		num4 = vector4.z;
		Vector3 vector5 = dragBoxSize * 2f;
		float num6 = Mathf.Min(maxSpeed * num, vector5.x);
		float num7 = maxYSpeed * num;
		float num8 = Mathf.Min(maxYSpeed * num, vector5.z);
		if (num2 - objectCarrierRB.transform.position.x > num6)
		{
			num2 = num6 + objectCarrierRB.transform.position.x;
		}
		else if (num2 - objectCarrierRB.transform.position.x < 0f - num6)
		{
			num2 = 0f - num6 + objectCarrierRB.transform.position.x;
		}
		if (num3 - objectCarrierRB.transform.position.y > num7)
		{
			num3 = num7 + objectCarrierRB.transform.position.y;
		}
		else if (num3 - objectCarrierRB.transform.position.y < 0f - num7)
		{
			num3 = 0f - num7 + objectCarrierRB.transform.position.y;
		}
		if (num4 - objectCarrierRB.transform.position.z > num8)
		{
			num4 = num8 + objectCarrierRB.transform.position.z;
		}
		else if (num4 - objectCarrierRB.transform.position.z < 0f - num8)
		{
			num4 = 0f - num8 + objectCarrierRB.transform.position.z;
		}
		Vector3 vector6 = new Vector3(num2, num3, num4);
		Vector3 vector7 = vector6;
		if (objectCarrierRB.transform.position == vector6)
		{
			return;
		}
		float num9 = 5f;
		float num10 = 0.1f;
		Vector3 vector8 = Vector3.up * num10;
		Vector3 vector9 = Vector3.left * num10;
		Vector3 vector10 = Vector3.forward * num10;
		Vector3 position = objectCarrierRB.transform.position;
		bool flag2 = !RaycastUtil.ObjectDraggingCheckBox(position - dragBoxCenterOffset, dragBoxSize, Quaternion.identity);
		if (RaycastUtil.ObjectDraggingCheckBox(vector7 - dragBoxCenterOffset, dragBoxSize, Quaternion.identity))
		{
			if (!RaycastUtil.ObjectDraggingCheckBox(vector7 - dragBoxCenterOffset + vector8, dragBoxSize, Quaternion.identity))
			{
				vector6 += vector8;
				vector7 = vector6;
				position += vector8;
			}
			else if (!RaycastUtil.ObjectDraggingCheckBox(vector7 - dragBoxCenterOffset - vector8, dragBoxSize, Quaternion.identity))
			{
				vector6 -= vector8;
				vector7 = vector6;
				position -= vector8;
			}
			else if (!RaycastUtil.ObjectDraggingCheckBox(vector7 - dragBoxCenterOffset + vector9, dragBoxSize, Quaternion.identity))
			{
				vector6 += vector9;
				vector7 = vector6;
				position += vector9;
			}
			else if (!RaycastUtil.ObjectDraggingCheckBox(vector7 - dragBoxCenterOffset - vector9, dragBoxSize, Quaternion.identity))
			{
				vector6 -= vector9;
				vector7 = vector6;
				position -= vector9;
			}
			else if (!RaycastUtil.ObjectDraggingCheckBox(vector7 - dragBoxCenterOffset + vector10, dragBoxSize, Quaternion.identity))
			{
				vector6 += vector10;
				vector7 = vector6;
				position += vector10;
			}
			else if (!RaycastUtil.ObjectDraggingCheckBox(vector7 - dragBoxCenterOffset - vector10, dragBoxSize, Quaternion.identity))
			{
				vector6 -= vector10;
				vector7 = vector6;
				position -= vector10;
			}
			else if (!flag2)
			{
				MoveGrabbedObject(vector7);
			}
			for (int i = 1; (float)i <= num9; i++)
			{
				vector7 = MathUtil.GetPointAlongLine(position, vector6, (float)i / num9);
				if (!RaycastUtil.ObjectDraggingCheckBox(vector7 - dragBoxCenterOffset, dragBoxSize, Quaternion.identity))
				{
					MoveGrabbedObject(vector7);
					return;
				}
			}
			if (position.z != vector6.z)
			{
				Vector3 vector11 = new Vector3(vector6.x, vector6.y, position.z);
				vector7 = vector11;
				for (int num11 = (int)num9; num11 > 0; num11--)
				{
					vector7 = MathUtil.GetPointAlongLine(position, vector11, (float)num11 / num9);
					if (!RaycastUtil.ObjectDraggingCheckBox(vector7 - dragBoxCenterOffset, dragBoxSize, Quaternion.identity))
					{
						MoveGrabbedObject(vector7);
						return;
					}
				}
			}
			if (position.x != vector6.x)
			{
				Vector3 vector12 = new Vector3(position.x, vector6.y, vector6.z);
				vector7 = vector12;
				for (int num12 = (int)num9; num12 > 0; num12--)
				{
					vector7 = MathUtil.GetPointAlongLine(position, vector12, (float)num12 / num9);
					if (!RaycastUtil.ObjectDraggingCheckBox(vector7 - dragBoxCenterOffset, dragBoxSize, Quaternion.identity))
					{
						MoveGrabbedObject(vector7);
						return;
					}
				}
			}
			if (position.y == vector6.y)
			{
				return;
			}
			Vector3 vector13 = new Vector3(vector6.x, position.y, vector6.z);
			vector7 = vector13;
			for (int num13 = (int)num9; num13 > 0; num13--)
			{
				vector7 = MathUtil.GetPointAlongLine(position, vector13, (float)num13 / num9);
				if (!RaycastUtil.ObjectDraggingCheckBox(vector7 - dragBoxCenterOffset, dragBoxSize, Quaternion.identity))
				{
					MoveGrabbedObject(vector7);
					break;
				}
			}
		}
		else
		{
			MoveGrabbedObject(vector7);
		}
	}

	private void MoveGrabbedObject(Vector3 newPos)
	{
		objectCarrierRB.MovePosition(newPos);
	}

	private void DropDog()
	{
		if (objectCarrier.GetComponent<SpringJoint>().connectedBody.gameObject.CompareTag(tailTag))
		{
			ClearTailGrabWeights();
		}
		if (objectCarrier.GetComponent<SpringJoint>().connectedBody.gameObject.layer == LayerMask.NameToLayer(legsLayerName))
		{
			RemoveLegGrabWeights();
		}
		GetConnectedBody().transform.root.GetComponent<LegController>().TightenAbs(LooseAbsLock.GRABBED);
	}

	private Rigidbody GetConnectedBody()
	{
		return objectCarrier.GetComponent<SpringJoint>().connectedBody;
	}

	public void DropObject()
	{
		if (!carryingObject)
		{
			dragDict.Clear();
			return;
		}
		bool flag = carryingDog;
		carryingDog = false;
		carryingObject = false;
		carriedAIRef = null;
		carriedDenRef = null;
		DisableLocationVis();
		constructionRef.EnableModularZoom();
		Rigidbody connectedBody = GetConnectedBody();
		if (connectedBody == null)
		{
			dragDict.Clear();
			return;
		}
		Rigidbody[] componentsInChildren = connectedBody.transform.root.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigidbody in componentsInChildren)
		{
			rigidbody.angularDrag = dragDict[rigidbody];
		}
		dragDict.Clear();
		connectedBody.transform.root.GetComponent<InteractableBase>().OnObjectDroppedByPlayer();
		if (flag)
		{
			DropDog();
			objectCarrier.GetComponent<SpringJoint>().connectedBody.AddForce(0f, 0f, 0.1f);
		}
		else
		{
			objectCarrier.GetComponent<SpringJoint>().connectedBody.AddForce(0f, 0f, 0.1f);
		}
		objectCarrier.GetComponent<SpringJoint>().connectedBody = null;
		Vector3 cursorPos = mainCam.WorldToScreenPoint(objectCarrier.transform.position);
		cursorRef.TeleportVirtualCursor(cursorPos);
		if (IsValidClick())
		{
			Transform root = connectedBody.transform.root;
			if (grabAndClickTags.Contains(root.tag))
			{
				indicatorManagerRef.ReportClick(root.gameObject);
			}
		}
		else
		{
			AudioController.Play(dropObjectSound, objectCarrier.transform.position);
		}
	}

	public void OnObjectRemovedByPlayer(GameObject obj)
	{
		AudioController.Play(objectDestroySound, objectCarrier.transform.position);
		InteractableBase component = obj.GetComponent<InteractableBase>();
		if (component == null)
		{
			return;
		}
		List<ulong> useList = component.GetUseList();
		for (int i = 0; i < useList.Count; i++)
		{
			GameObject dogFromID = dogRegRef.GetDogFromID(useList[i]);
			if (dogFromID.GetComponent<FaceController>().CanSeeFocusObject())
			{
				dogFromID.GetComponent<DogParticleController>().RequestSurpriseParticlesStart();
			}
		}
		useList.Clear();
		useList = component.GetFocusList();
		for (int j = 0; j < useList.Count; j++)
		{
			GameObject dogFromID2 = dogRegRef.GetDogFromID(useList[j]);
			if (dogFromID2.GetComponent<FaceController>().CanSeeFocusObject())
			{
				dogFromID2.GetComponent<DogParticleController>().RequestSurpriseParticlesStart();
			}
		}
	}

	private bool IsValidClick()
	{
		if (Time.unscaledTime - holdTimeStart < usableHoldTimeForGrab && Vector3.Distance(clickStartPos, InputManager.MouseProvider.GetPosition()) <= maxMouseDistForClick)
		{
			return true;
		}
		return false;
	}

	private void DistractNearbyDogs()
	{
		if (GetGrabbedObject() == null)
		{
			currentDistractionTimer = distractionTimerMin;
			return;
		}
		currentDistractionTimer -= Time.deltaTime;
		if (currentDistractionTimer > 0f)
		{
			return;
		}
		currentDistractionTimer = distractionTimerMin;
		dogRegRef.GetNearbyDogList(GetGrabbedObject(), ref dogList);
		for (int i = 0; i < dogList.Count; i++)
		{
			if (!(dogList[i].GetComponent<DogAI>().GetTargetObject() == GetGrabbedObject()))
			{
				DistractionObject newDistraction = new DistractionObject(dogList[i].GetComponent<DogAI>(), 0.35f, GetGrabbedObject());
				dogList[i].GetComponent<DogAI>().TryAddNewDistraction(newDistraction);
			}
		}
	}
}
