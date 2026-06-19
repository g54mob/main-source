using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using InControl;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityStandardAssets.ImageEffects;

public class PenFocus : MonoBehaviour
{
	public Camera dogGUICameraRef;

	public PostProcessProfile profileRef;

	public Color constructionBGColor = Color.cyan;

	public CinemachineFreeLook cinemachineDogFocusRefA;

	public CinemachineFreeLook cinemachineDogFocusRefB;

	public CinemachineFreeLook cinemachinePenFocusRefA;

	public CinemachineFreeLook cinemachinePenFocusRefB;

	public CinemachineVirtualCamera cinemachineTutorialCam1;

	public CinemachineVirtualCamera cinemachineConstructionCamA;

	private List<CinemachineFreeLook> allPenCams = new List<CinemachineFreeLook>();

	private bool exteriorCamMode = true;

	private Vector3 interiorCamCenterPos;

	private float interiorCameraFarClipPos = 125f;

	private float exteriorCameraFarClipPos = 500f;

	private int penFocusLowPriority = 8;

	private int penFocusHighPriority = 9;

	private int dogFocusLowPriority = 10;

	private int dogFocusHighPriority = 11;

	private int constructionCamLowPriority;

	private int constructionCamHighPriority = 25;

	private string penFocusSound = "pen_focus";

	private string dogFocusExitSound = "dogFocusExit";

	private string dogFocusEnterSound = "dogFocusEnter";

	private string camFocusDenExitSound = "denFocusExit";

	private string camFocusDenEnterSound = "denFocusEnter";

	private string constructionModeZoomInSound = "constructionModeZoomIn";

	private string constructionModeZoomOutSound = "constructionModeZoomOut";

	private List<LockReason> inputLocks = new List<LockReason>();

	private CinemachineFreeLook currentDogFocusCam;

	private CinemachineFreeLook currentPenFocusCam;

	private UnityStandardAssets.ImageEffects.DepthOfField DOFRef;

	private UnityStandardAssets.ImageEffects.DepthOfField UIDOFRef;

	private float defaultFOV = 60f;

	private Vector3 defaultPos = new Vector3(0f, 0f, -75f);

	private Quaternion defaultRot = Quaternion.identity;

	private Vector3 targetPos;

	private Quaternion targetRot;

	private float camSensitivity = 1f;

	private float camSensitivityLow = 0.25f;

	private float camSensitivityHigh = 2f;

	private bool atTarget = true;

	private float targetTime = 0.5f;

	private float currentMoveTime;

	private bool slerp;

	private bool inputAllowed = true;

	private bool modularZoomAllowed = true;

	private float modularZoomDepth = 10f;

	private float focusedZoomDepth = 5f;

	private float minZoomDepth = -500f;

	private float focusZoomDepth = 43f;

	private float maxZoomDepth = 10f;

	private Vector3 lastMousePosSinceMiddleDown;

	private float middleSpeedX = -1f;

	private float middleSpeedY = -1f;

	private float keySpeedXZ = 30f;

	private float keySpeedXZConstruction = 100f;

	private float movementKeyDownTimer;

	private float movementKeyCurveTimer = 0.1f;

	private Vector3 camBounds = new Vector3(150f, 150f, 150f);

	private Vector3 camBoundsInterior = new Vector3(10f, 10f, 10f);

	private Vector3 camBoundsConstruction = new Vector3(100f, 100f, 100f);

	private bool updateBlur = true;

	private List<MotionBlurLockReason> blurLocks = new List<MotionBlurLockReason>();

	private bool scrollingLocked;

	private GameObject lastFocusedRoom;

	private Transform currentFocusTransform;

	private float currentRotationIconBuffer;

	private float rotationIconBufferTimer = 0.25f;

	private bool followCam;

	private float maxXOrbitalSpeed = 250f;

	private float maxYOrbitalSpeed = 4f;

	private float minFollowCamOrbitalRadius = 3f;

	private float maxFollowCamOrbitalRadius = 30f;

	private Transform currentFollowTarget;

	private float scrollDeltaFollowCamSpeed = -25f;

	private float defaultFollowCamOrbitalRadius = 8f;

	private float currentFollowCamOrbitalRadius = 8f;

	private float currentFollowCamOrbitalRadiusTarget = 8f;

	private float followCamOrbitalRadiusSmoothingSpeed = 35f;

	private bool penFocusCam = true;

	private float defaultXAxisValue;

	private float defaultYAxisValue = 0.5f;

	private float minPenFocusOrbitalRadius = 3f;

	private float maxPenFocusOrbitalRadius = 150f;

	private float maxPenInteriorFocusOrbitalRadius = 75f;

	private float defaultPenFocusOrbitalRadiusTop = 20f;

	private float defaultPenFocusOrbitalRadiusMiddle = 20f;

	private float defaultPenFocusOrbitalRadiusBottom = 20f;

	private float defaultPenFocusOrbitalHeightTop = 20f;

	private float defaultPenFocusOrbitalHeightMiddle = 20f;

	private float defaultPenFocusOrbitalHeightBottom = 20f;

	private float currentPenFocusOrbitalRadius = 20f;

	private float currentPenFocusOrbitalRadiusTarget = 20f;

	private float binaryScrollDeltaPenFocusSpeed = -100f;

	private float penFocusOrbitalRadiusSmoothingSpeed = 250f;

	private bool xAxisInverted = true;

	private bool yAxisInverted = true;

	private bool constructionMode;

	private float minConstructionZoom = 20f;

	private float maxConstructionZoom = 150f;

	private float constructionDragSpeed = -5f;

	private float scrollDeltaConstructionZoomSpeed = -150f;

	private Vector3 startingConstructionPos = new Vector3(0f, 0f, -60f);

	private bool autoSpin;

	private float camSwitchRetryMin = 1f;

	private float camSwitchRetryMax = 3f;

	private float camSwitchMin = 10f;

	private float camSwitchMax = 30f;

	private string originalInputAxisName = "Mouse X";

	private float autoXAxisSpinVal = 1f;

	private float currentCamSwitchTimer = 30f;

	private float minAttractModePenFocusOrbitalRadius = 20f;

	private float maxAttractModePenFocusOrbitalRadius = 40f;

	private float minAttractModeFollowCamOrbitalRadius = 8f;

	private float maxAttractModeFollowCamOrbitalRadius = 15f;

	private bool needFocus;

	private Vector3 neededPos;

	private Quaternion neededRot;

	private bool neededSlerp;

	private List<GameObject> allRooms = new List<GameObject>();

	private List<Renderer> disabledRenderers = new List<Renderer>();

	private List<Renderer> oldDisabledRenderers = new List<Renderer>();

	private CinemachineBlendDefinition cutBlend;

	private CinemachineBlendDefinition defaultBlend;

	private UnityEngine.Rendering.PostProcessing.MotionBlur blurRef;

	private bool hasAddedPostFX;

	private CinemachineBrain cinemachineBrainRef;

	private Camera cameraRef;

	private DogFocus dogFocusRef;

	private DogHome dogHomeRef;

	private GameObject uiCameraRef;

	private ObjectGrabber grabberRef;

	private GUIManagerPens penGUIRef;

	private DogRegistration dogRegRef;

	private SceneManagerBase sceneRef;

	private CursorController cursorRef;

	private ConstructionManager constructionRef;

	private void Awake()
	{
		cinemachineBrainRef = GetComponent<CinemachineBrain>();
		cutBlend = new CinemachineBlendDefinition(CinemachineBlendDefinition.Style.Cut, 0f);
		defaultBlend = new CinemachineBlendDefinition(CinemachineBlendDefinition.Style.EaseIn, 0.25f);
		cinemachineBrainRef.m_DefaultBlend = defaultBlend;
		AddPostFX();
		DOFRef = GetComponent<UnityStandardAssets.ImageEffects.DepthOfField>();
		lastMousePosSinceMiddleDown = InputManager.MouseProvider.GetPosition();
		cameraRef = Camera.main;
		cameraRef.fieldOfView = defaultFOV;
		cameraRef.transform.position = defaultPos;
		cameraRef.transform.rotation = defaultRot;
		dogFocusRef = cameraRef.GetComponent<DogFocus>();
		defaultFollowCamOrbitalRadius = cinemachineDogFocusRefA.m_Orbits[0].m_Radius;
		currentFollowCamOrbitalRadius = defaultFollowCamOrbitalRadius;
		defaultPenFocusOrbitalRadiusTop = cinemachinePenFocusRefA.m_Orbits[0].m_Radius;
		defaultPenFocusOrbitalRadiusMiddle = cinemachinePenFocusRefA.m_Orbits[1].m_Radius;
		defaultPenFocusOrbitalRadiusBottom = cinemachinePenFocusRefA.m_Orbits[2].m_Radius;
		defaultPenFocusOrbitalHeightTop = cinemachinePenFocusRefA.m_Orbits[0].m_Height;
		defaultPenFocusOrbitalHeightMiddle = cinemachinePenFocusRefA.m_Orbits[1].m_Height;
		defaultPenFocusOrbitalHeightBottom = cinemachinePenFocusRefA.m_Orbits[2].m_Height;
		currentPenFocusOrbitalRadius = defaultPenFocusOrbitalRadiusMiddle;
		if (currentDogFocusCam == null)
		{
			currentDogFocusCam = cinemachineDogFocusRefA;
		}
		if (cinemachineConstructionCamA != null)
		{
			cinemachineConstructionCamA.enabled = true;
			cinemachineConstructionCamA.Priority = constructionCamLowPriority;
		}
		if (needFocus)
		{
			RequestMoveToTarget(neededPos, neededRot, neededSlerp);
		}
		allPenCams.Clear();
		allPenCams.Add(cinemachineDogFocusRefA);
		allPenCams.Add(cinemachineDogFocusRefB);
		allPenCams.Add(cinemachinePenFocusRefA);
		for (int i = 0; i < allPenCams.Count; i++)
		{
			allPenCams[i].m_Lens.FieldOfView = defaultFOV;
		}
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		cursorRef = registrationScript.GetGlobalComponent<CursorController>(GlobalObject.CURSOR);
		dogHomeRef = registrationScript.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME, nullAllowed: true);
		penGUIRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI, nullAllowed: true);
		sceneRef = registrationScript.GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER, nullAllowed: true);
		grabberRef = registrationScript.GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER, nullAllowed: true);
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION, nullAllowed: true);
		uiCameraRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Camera>(GlobalObject.UI_CAMERA).gameObject;
		constructionRef = registrationScript.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER, nullAllowed: true);
		UIDOFRef = uiCameraRef.GetComponent<UnityStandardAssets.ImageEffects.DepthOfField>();
		SetModeDenExterior();
	}

	private void Start()
	{
		StartCoroutine(RebuildPenCamB());
	}

	public UnityStandardAssets.ImageEffects.DepthOfField GetDOFRef()
	{
		return DOFRef;
	}

	private IEnumerator RebuildPenCamB()
	{
		Object.Destroy(cinemachinePenFocusRefB.gameObject);
		GameObject gameObject = Object.Instantiate(cinemachinePenFocusRefA.gameObject);
		gameObject.name = "Cloned Pen Cam";
		gameObject.transform.SetParent(cinemachinePenFocusRefA.transform.parent, worldPositionStays: true);
		cinemachinePenFocusRefB = gameObject.GetComponent<CinemachineFreeLook>();
		cinemachinePenFocusRefB.m_Lens.FieldOfView = defaultFOV;
		allPenCams.Add(cinemachinePenFocusRefB);
		yield return new WaitForSecondsRealtime(0.025f);
		SetRoomFocus(lastFocusedRoom, playSound: false);
	}

	public void SetFarClippingPlane(float value)
	{
		for (int i = 0; i < allPenCams.Count; i++)
		{
			allPenCams[i].m_Lens.FarClipPlane = value;
		}
	}

	public PostProcessProfile GetPostFXProfile()
	{
		return profileRef;
	}

	private void AddPostFX()
	{
		if (!hasAddedPostFX)
		{
			hasAddedPostFX = true;
			PostProcessVolume postProcessVolume = base.transform.GetChild(0).gameObject.AddComponent<PostProcessVolume>();
			postProcessVolume.isGlobal = true;
			postProcessVolume.profile = profileRef;
		}
	}

	public void SetBlurUpdate(bool newVal)
	{
		updateBlur = newVal;
	}

	public void EnableMotionBlur(MotionBlurLockReason reason)
	{
		if (blurLocks.Contains(reason))
		{
			blurLocks.Remove(reason);
		}
		if (blurRef == null)
		{
			profileRef.TryGetSettings<UnityEngine.Rendering.PostProcessing.MotionBlur>(out blurRef);
		}
		if (blurLocks.Count == 0 && !blurRef.active)
		{
			blurRef.active = true;
		}
	}

	public void DisableMotionBlur(MotionBlurLockReason reason)
	{
		if (!blurLocks.Contains(reason))
		{
			blurLocks.Add(reason);
		}
		if (blurRef == null)
		{
			profileRef.TryGetSettings<UnityEngine.Rendering.PostProcessing.MotionBlur>(out blurRef);
		}
		if (blurRef.active)
		{
			blurRef.active = false;
		}
	}

	public bool IsOptionsMenuLockingMotionBlur()
	{
		if (blurLocks.Contains(MotionBlurLockReason.OPTIONS_MENU))
		{
			return true;
		}
		return false;
	}

	public bool IsBlurActive()
	{
		return DOFRef.aperture == 1f;
	}

	public void BlurBG()
	{
		if (!(DOFRef == null))
		{
			DOFRef.aperture = 1f;
		}
	}

	public void UnblurBG()
	{
		if (!(DOFRef == null))
		{
			DOFRef.aperture = 0f;
		}
	}

	public void BlurUI()
	{
		if (!(UIDOFRef == null))
		{
			UIDOFRef.aperture = 1f;
		}
	}

	public void UnblurUI()
	{
		if (!(UIDOFRef == null))
		{
			UIDOFRef.aperture = 0f;
		}
	}

	public bool IsInPhotoMode()
	{
		return penGUIRef.IsInPhotoMode();
	}

	public void SetStartingAperture(float newValue)
	{
		penGUIRef.photoModeGUIRef.SetStartingAperture(newValue);
	}

	public bool IsXCamInverted()
	{
		return xAxisInverted;
	}

	public bool IsYCamInverted()
	{
		return yAxisInverted;
	}

	public void UpdateXCamInversion(bool val)
	{
		xAxisInverted = val;
		cinemachinePenFocusRefA.m_XAxis.m_InvertInput = xAxisInverted;
		cinemachinePenFocusRefB.m_XAxis.m_InvertInput = xAxisInverted;
		cinemachineDogFocusRefA.m_XAxis.m_InvertInput = xAxisInverted;
		cinemachineDogFocusRefB.m_XAxis.m_InvertInput = xAxisInverted;
	}

	public void UpdateYCamInversion(bool val)
	{
		yAxisInverted = val;
		cinemachinePenFocusRefA.m_YAxis.m_InvertInput = yAxisInverted;
		cinemachinePenFocusRefB.m_YAxis.m_InvertInput = yAxisInverted;
		cinemachineDogFocusRefA.m_YAxis.m_InvertInput = yAxisInverted;
		cinemachineDogFocusRefB.m_YAxis.m_InvertInput = yAxisInverted;
	}

	public void SetDefaultCamSensitivity()
	{
		camSensitivity = 1f;
	}

	public float GetCamSensitivity()
	{
		if (camSensitivity < 1f)
		{
			float num = 1f - camSensitivityLow;
			return MathUtil.GetValueOfRangePercentage((camSensitivity - camSensitivityLow) / num, 0f, 0.5f);
		}
		if (camSensitivity > 1f)
		{
			float num2 = camSensitivityHigh - 1f;
			return MathUtil.GetValueOfRangePercentage((camSensitivity - 1f) / num2, 0.5f, 1f);
		}
		return 0.5f;
	}

	public void SetCamSensitivity(float newVal)
	{
		newVal = Mathf.Clamp(newVal, 0f, 1f);
		if (newVal < 0.5f)
		{
			camSensitivity = MathUtil.GetValueOfRangePercentage(newVal / 0.5f, camSensitivityLow, 1f);
		}
		else if (newVal > 0.5f)
		{
			camSensitivity = MathUtil.GetValueOfRangePercentage((newVal - 0.5f) / 0.5f, 1f, camSensitivityHigh);
		}
		else
		{
			camSensitivity = 1f;
		}
	}

	private void OnPreRender()
	{
		CheckAllPenWallVisibility();
	}

	private void Update()
	{
		if (constructionMode)
		{
			HandleConstructionModeInput();
			return;
		}
		UpdateInputBuffers();
		bool flag = CheckMove();
		flag = ((!flag) ? CheckRotate() : flag);
		flag = ((!flag) ? CheckModularZoom() : flag);
		if (!atTarget)
		{
			flag = true;
			MoveTowardsTarget();
		}
		if (!followCam && updateBlur)
		{
			if (!flag)
			{
				EnableMotionBlur(MotionBlurLockReason.CAMERA_MOVEMENT);
			}
			else
			{
				DisableMotionBlur(MotionBlurLockReason.CAMERA_MOVEMENT);
			}
		}
		if (GameSettings.IsPassiveModeEnabled() && sceneRef.GetGameMode() == GameMode.HOME && IsInputAllowed())
		{
			TickAutoPlay();
		}
		if (followCam)
		{
			UpdateFollowCam();
		}
		else if (penFocusCam)
		{
			UpdateRoomFocusCam();
		}
	}

	public void SetLastFocusedRoom(ulong roomUID, bool refocusAllowed = true, bool playSound = true)
	{
		SetLastFocusedRoom(constructionRef.GetObjectForUID(roomUID), refocusAllowed, playSound);
	}

	public void SetLastFocusedRoom(GameObject room, bool refocusAllowed = true, bool playSound = true, Vector3? focusTransformOverridePos = null)
	{
		if (!(lastFocusedRoom == room) || refocusAllowed)
		{
			lastFocusedRoom = room;
			if (room == null)
			{
				ClearLastFocusedRoom();
			}
			else
			{
				SetRoomFocus(room, playSound, focusTransformOverridePos);
			}
		}
	}

	public void RefreshRoomFocus()
	{
		if (!(lastFocusedRoom == null))
		{
			SetRoomFocus(lastFocusedRoom, playSound: false);
		}
	}

	public void ClearLastFocusedRoom()
	{
		ClearPenFocus();
		lastFocusedRoom = null;
	}

	public void FocusOnDen(GameObject den, Vector3? focusTransformOverridePos = null)
	{
		SetLastFocusedRoom(den, refocusAllowed: true, playSound: true, focusTransformOverridePos);
	}

	public void ClearDenFocus()
	{
		if (FollowCamActive())
		{
			ClearFollowCam();
			ClearDenFocus();
			dogFocusRef.DisableDOFImmediate();
			return;
		}
		if (lastFocusedRoom == null)
		{
			ClearLastFocusedRoom();
			return;
		}
		if (lastFocusedRoom.GetComponent<RoomBase>() != null)
		{
			SetRoomFocus(lastFocusedRoom);
			return;
		}
		DogDen dogDen = lastFocusedRoom.GetComponent<DogDen>();
		if (dogDen == null)
		{
			DogDenInterior component = lastFocusedRoom.GetComponent<DogDenInterior>();
			if (component == null)
			{
				ClearLastFocusedRoom();
				return;
			}
			dogDen = component.associatedDenRef;
		}
		ulong? roomUID = dogDen.GetComponent<BoundingBoxComponent>().GetRoomUID();
		if (!roomUID.HasValue)
		{
			ClearLastFocusedRoom();
			return;
		}
		SetRoomFocus(constructionRef.GetObjectForUID(roomUID.Value));
		SetModeDenExterior();
	}

	public void OnEnterConstructionMode(bool playSounds = true)
	{
		if (!cameraRef.orthographic && playSounds)
		{
			AudioController.Play(constructionModeZoomInSound);
		}
		ClearFollowCam(fromRoomFocus: false, playSounds: false, playPenFocusSound: false);
		DisableMotionBlur(MotionBlurLockReason.CAMERA_MOVEMENT);
		constructionMode = true;
		cameraRef.orthographic = true;
		cameraRef.clearFlags = CameraClearFlags.Color;
		cameraRef.backgroundColor = constructionBGColor;
		cinemachineConstructionCamA.transform.position = startingConstructionPos;
		cinemachineConstructionCamA.Priority = constructionCamHighPriority;
	}

	public void OnExitConstructionMode(bool playSounds = true)
	{
		if (cameraRef.orthographic && playSounds)
		{
			AudioController.Play(constructionModeZoomOutSound);
		}
		constructionMode = false;
		cameraRef.orthographic = false;
		cameraRef.clearFlags = CameraClearFlags.Skybox;
		if (cinemachineConstructionCamA != null)
		{
			cinemachineConstructionCamA.Priority = constructionCamLowPriority;
		}
		if (lastFocusedRoom == null && allRooms.Count > 0)
		{
			SetRoomFocus(allRooms[0]);
		}
	}

	public float GetCurrentFOV()
	{
		if (penFocusCam)
		{
			return currentPenFocusCam.m_Lens.FieldOfView;
		}
		return currentDogFocusCam.m_Lens.FieldOfView;
	}

	public void SetFOV(float newValue)
	{
		for (int i = 0; i < allPenCams.Count; i++)
		{
			allPenCams[i].m_Lens.FieldOfView = newValue;
		}
	}

	public void ResetFOV()
	{
		SetFOV(defaultFOV);
	}

	public void SetDutch(float newValue)
	{
		for (int i = 0; i < allPenCams.Count; i++)
		{
			allPenCams[i].m_Lens.Dutch = newValue;
		}
	}

	public void ResetDutch()
	{
		SetDutch(0f);
	}

	private void SwitchPenFocusCams()
	{
		if (currentPenFocusCam == null)
		{
			currentPenFocusCam = cinemachinePenFocusRefA;
		}
		CinemachineFreeLook cinemachineFreeLook = currentPenFocusCam;
		if (cinemachineFreeLook == cinemachinePenFocusRefA)
		{
			currentPenFocusCam = cinemachinePenFocusRefB;
		}
		else
		{
			currentPenFocusCam = cinemachinePenFocusRefA;
		}
		cinemachineFreeLook.Priority = penFocusLowPriority;
		currentPenFocusCam.Priority = penFocusHighPriority;
		cinemachinePenFocusRefA.enabled = true;
		cinemachinePenFocusRefB.enabled = true;
		cinemachineFreeLook.Follow = null;
		cinemachineFreeLook.LookAt = null;
	}

	private void SwitchDogFocusCams()
	{
		if (!(cinemachineDogFocusRefA == null) && !(cinemachineDogFocusRefB == null))
		{
			if (currentDogFocusCam == null)
			{
				currentDogFocusCam = cinemachineDogFocusRefA;
			}
			CinemachineFreeLook cinemachineFreeLook = currentDogFocusCam;
			if (cinemachineFreeLook == cinemachineDogFocusRefA)
			{
				currentDogFocusCam = cinemachineDogFocusRefB;
			}
			else
			{
				currentDogFocusCam = cinemachineDogFocusRefA;
			}
			cinemachineFreeLook.Priority = dogFocusLowPriority;
			currentDogFocusCam.Priority = dogFocusHighPriority;
			cinemachineDogFocusRefA.enabled = true;
			cinemachineDogFocusRefB.enabled = true;
		}
	}

	private void SetRoomFocus(GameObject room, bool playSound = true, Vector3? focusTransformOverridePos = null)
	{
		if (room != null)
		{
			lastFocusedRoom = room;
		}
		if (currentFollowTarget != null)
		{
			ClearFollowCam(fromRoomFocus: true, playSounds: false, playPenFocusSound: false);
		}
		if (!exteriorCamMode)
		{
			SetModeDenExterior(null, focusTransformOverridePos);
			if (!focusTransformOverridePos.HasValue)
			{
				cinemachineBrainRef.m_DefaultBlend = cutBlend;
			}
			else
			{
				cinemachineBrainRef.m_DefaultBlend = defaultBlend;
			}
		}
		else
		{
			cinemachineBrainRef.m_DefaultBlend = defaultBlend;
		}
		penFocusCam = true;
		SetupRoomFocusCam(room, focusTransformOverridePos);
		if (playSound && !focusTransformOverridePos.HasValue)
		{
			AudioController.Play(penFocusSound);
		}
		for (int i = 0; i < 3; i++)
		{
			cinemachinePenFocusRefA.GetRig(i).GetCinemachineComponent<CinemachineOrbitalTransposer>().m_XDamping = 0f;
			cinemachinePenFocusRefB.GetRig(i).GetCinemachineComponent<CinemachineOrbitalTransposer>().m_XDamping = 0f;
		}
	}

	public Vector3 GetCorrectedCamPos()
	{
		if (currentFollowTarget != null)
		{
			return currentDogFocusCam.State.CorrectedPosition;
		}
		return currentPenFocusCam.State.CorrectedPosition;
	}

	private void SetupRoomFocusCam(GameObject room, Vector3? focusTransformOverridePos = null)
	{
		if (room == null)
		{
			return;
		}
		DogDen component = room.GetComponent<DogDen>();
		RoomBase component2 = room.GetComponent<RoomBase>();
		if (component2 == null && component == null)
		{
			return;
		}
		if (component2 != null)
		{
			component2.CenterFocusTransform();
		}
		Transform transform = null;
		if (component2 != null)
		{
			transform = component2.GetCenterFocusTransform();
		}
		else if (component != null)
		{
			DogDenInterior component3 = DenInteriorManager.GetInteriorForDen(room).GetComponent<DogDenInterior>();
			SetModeDenInterior(component3, null, focusTransformOverridePos);
			if (!focusTransformOverridePos.HasValue)
			{
				cinemachineBrainRef.m_DefaultBlend = cutBlend;
			}
			component3.CenterFocusTransform();
			transform = component3.focusTransform;
		}
		if (focusTransformOverridePos.HasValue)
		{
			transform.position = focusTransformOverridePos.Value;
		}
		currentFocusTransform = transform;
		SwitchPenFocusCams();
		currentPenFocusCam.Follow = transform;
		currentPenFocusCam.LookAt = transform;
		if (currentPenFocusCam.Follow == null || currentPenFocusCam.LookAt == null)
		{
			currentPenFocusCam.Follow = transform;
			currentPenFocusCam.LookAt = transform;
		}
		currentPenFocusCam.m_XAxis.Value = defaultXAxisValue;
		currentPenFocusCam.m_YAxis.Value = defaultYAxisValue;
		currentPenFocusCam.m_XAxis.m_InputAxisName = originalInputAxisName;
		if (!focusTransformOverridePos.HasValue)
		{
			currentPenFocusOrbitalRadiusTarget = defaultPenFocusOrbitalRadiusMiddle;
			currentPenFocusCam.m_Orbits[0].m_Radius = defaultPenFocusOrbitalRadiusTop;
			currentPenFocusCam.m_Orbits[1].m_Radius = defaultPenFocusOrbitalRadiusMiddle;
			currentPenFocusCam.m_Orbits[2].m_Radius = defaultPenFocusOrbitalRadiusBottom;
			currentPenFocusCam.m_Orbits[0].m_Height = defaultPenFocusOrbitalHeightTop;
			currentPenFocusCam.m_Orbits[1].m_Height = defaultPenFocusOrbitalHeightMiddle;
			currentPenFocusCam.m_Orbits[2].m_Height = defaultPenFocusOrbitalHeightBottom;
		}
		else if (currentDogFocusCam != null)
		{
			currentPenFocusOrbitalRadius = currentFollowCamOrbitalRadius;
			currentPenFocusOrbitalRadiusTarget = currentFollowCamOrbitalRadius;
			currentPenFocusCam.m_Orbits[0].m_Radius = currentDogFocusCam.m_Orbits[0].m_Radius;
			currentPenFocusCam.m_Orbits[1].m_Radius = currentDogFocusCam.m_Orbits[1].m_Radius;
			currentPenFocusCam.m_Orbits[2].m_Radius = currentDogFocusCam.m_Orbits[2].m_Radius;
			currentPenFocusCam.m_Orbits[0].m_Height = currentDogFocusCam.m_Orbits[0].m_Height;
			currentPenFocusCam.m_Orbits[1].m_Height = currentDogFocusCam.m_Orbits[1].m_Height;
			currentPenFocusCam.m_Orbits[2].m_Height = currentDogFocusCam.m_Orbits[2].m_Height;
			Vector3 to = currentDogFocusCam.State.CorrectedPosition - currentFocusTransform.position;
			to.y = 0f;
			float value = Vector3.SignedAngle(-currentFocusTransform.forward, to, Vector3.up);
			currentPenFocusCam.InternalUpdateCameraState(Vector3.up, -1f);
			currentPenFocusCam.m_XAxis.Value = value;
			currentPenFocusCam.m_YAxis.Value = currentDogFocusCam.m_YAxis.Value;
			currentPenFocusCam.PreviousStateIsValid = false;
		}
	}

	private void ClearPenFocus()
	{
		penFocusCam = false;
		currentFocusTransform = null;
		cinemachinePenFocusRefA.Follow = null;
		cinemachinePenFocusRefA.LookAt = null;
		cinemachinePenFocusRefB.Follow = null;
		cinemachinePenFocusRefB.LookAt = null;
		cinemachinePenFocusRefA.enabled = false;
		cinemachinePenFocusRefB.enabled = false;
	}

	public void EnableModularZoom()
	{
		EnableModularZoom(lastFocusedRoom);
	}

	public void EnableModularZoom(GameObject lastFocusedRoom)
	{
		this.lastFocusedRoom = lastFocusedRoom;
		modularZoomAllowed = true;
	}

	public void DisableModularZoom()
	{
		modularZoomAllowed = false;
	}

	public bool IsInputAllowed()
	{
		return inputAllowed;
	}

	public void SetInputAllowed(bool val, LockReason reason)
	{
		if (val)
		{
			if (inputLocks.Contains(reason))
			{
				inputLocks.Remove(reason);
			}
		}
		else
		{
			if (inputLocks.Contains(reason))
			{
				Debug.LogError("Attempting to double-add an input lock reason. This will result in issues when trying to remove the locks later on.");
				return;
			}
			inputLocks.Add(reason);
		}
		if (!val)
		{
			inputAllowed = val;
			cinemachineDogFocusRefA.m_XAxis.m_MaxSpeed = 0f;
			cinemachineDogFocusRefA.m_YAxis.m_MaxSpeed = 0f;
			cinemachineDogFocusRefB.m_XAxis.m_MaxSpeed = 0f;
			cinemachineDogFocusRefB.m_YAxis.m_MaxSpeed = 0f;
		}
		else if (inputLocks.Count == 0)
		{
			inputAllowed = val;
			cinemachineDogFocusRefA.m_XAxis.m_MaxSpeed = maxXOrbitalSpeed * camSensitivity;
			cinemachineDogFocusRefA.m_YAxis.m_MaxSpeed = maxYOrbitalSpeed * camSensitivity;
			cinemachineDogFocusRefB.m_XAxis.m_MaxSpeed = maxXOrbitalSpeed * camSensitivity;
			cinemachineDogFocusRefB.m_YAxis.m_MaxSpeed = maxYOrbitalSpeed * camSensitivity;
		}
	}

	public void RequestReturnToDefault()
	{
		RequestMoveToTarget(defaultPos, defaultRot);
	}

	public void EnableTutorialCam1()
	{
		cinemachineTutorialCam1.enabled = true;
	}

	public void DisableTutorialCams()
	{
		cinemachineTutorialCam1.enabled = false;
	}

	public GameObject GetFocusedRoom()
	{
		if (currentFocusTransform == null || currentFollowTarget != null || IsZoomedOut())
		{
			return null;
		}
		return currentFocusTransform.root.gameObject;
	}

	public GameObject GetLastFocusedRoom()
	{
		return lastFocusedRoom;
	}

	public GameObject GetRoomForFocusedObject()
	{
		if (currentFollowTarget == null)
		{
			return null;
		}
		ulong? roomUID = currentFollowTarget.transform.root.GetComponent<BoundingBoxComponent>().GetRoomUID();
		if (!roomUID.HasValue)
		{
			return null;
		}
		return constructionRef.GetObjectForUID(roomUID.Value);
	}

	public bool IsCameraFollowingObject(GameObject obj)
	{
		if (currentFollowTarget != null && obj != null && currentFollowTarget.root.gameObject == obj.transform.root.gameObject)
		{
			return true;
		}
		return false;
	}

	public bool FollowCamActive()
	{
		return currentFollowTarget != null;
	}

	public Transform GetFollowTarget()
	{
		return currentFollowTarget;
	}

	public void RequestCocoonHatchCam(GameObject cocoon)
	{
		dogRegRef.SelectDog(cocoon);
		RequestFollowCam(cocoon.GetComponent<Cocoon>().GetFocusTransform());
		ScaleOrbitalFocus(currentDogFocusCam, 10f);
	}

	public void RequestFollowCam(Transform transformRef, bool forceInDen = false)
	{
		if (IsCameraFollowingObject(transformRef.root.gameObject) || (transformRef.root.gameObject.CompareTag(Tags.DOG) && DogHider.IsDogHidden(transformRef.root.gameObject)))
		{
			return;
		}
		if (penGUIRef != null && penGUIRef.GetCurrentMode() != GUIMode.PLAY && dogHomeRef != null)
		{
			dogHomeRef.RequestExitBuildMode();
		}
		AudioController.Play(dogFocusEnterSound);
		followCam = true;
		DisableModularZoom();
		SwitchDogFocusCams();
		currentFollowTarget = transformRef;
		currentDogFocusCam.Follow = currentFollowTarget;
		currentDogFocusCam.LookAt = currentFollowTarget;
		CinemachineCollider component = currentDogFocusCam.GetComponent<CinemachineCollider>();
		component.m_ObjectsToIgnore.Clear();
		MouthController component2 = currentFollowTarget.transform.root.GetComponent<MouthController>();
		if (component2 != null)
		{
			GameObject carriedObject = component2.GetCarriedObject();
			if (carriedObject != null)
			{
				component.m_ObjectsToIgnore.Add(carriedObject.transform.root);
			}
		}
		cinemachineDogFocusRefA.m_XAxis.m_MaxSpeed = 0f;
		cinemachineDogFocusRefA.m_YAxis.m_MaxSpeed = 0f;
		cinemachineDogFocusRefB.m_XAxis.m_MaxSpeed = 0f;
		cinemachineDogFocusRefB.m_YAxis.m_MaxSpeed = 0f;
		currentFollowCamOrbitalRadiusTarget = defaultFollowCamOrbitalRadius;
		DogDenController component3 = transformRef.root.gameObject.GetComponent<DogDenController>();
		bool flag = false;
		if (forceInDen)
		{
			flag = forceInDen;
		}
		else if (component3 != null)
		{
			flag = component3.IsInDen();
		}
		if (exteriorCamMode && flag)
		{
			SetModeDenInterior();
			cinemachineBrainRef.m_DefaultBlend = cutBlend;
		}
		else if (!exteriorCamMode && !flag)
		{
			SetModeDenExterior();
			cinemachineBrainRef.m_DefaultBlend = cutBlend;
		}
		else
		{
			cinemachineBrainRef.m_DefaultBlend = defaultBlend;
		}
	}

	public void ClearFollowCam(bool fromRoomFocus = false, bool playSounds = true, bool playPenFocusSound = true, bool keepPosRot = false)
	{
		if (followCam && playSounds)
		{
			AudioController.Play(dogFocusExitSound);
		}
		Transform transform = currentFollowTarget;
		followCam = false;
		currentFollowTarget = null;
		cinemachineDogFocusRefA.Follow = null;
		cinemachineDogFocusRefA.LookAt = null;
		cinemachineDogFocusRefB.Follow = null;
		cinemachineDogFocusRefB.LookAt = null;
		cinemachineDogFocusRefA.enabled = false;
		cinemachineDogFocusRefB.enabled = false;
		bool flag = exteriorCamMode;
		if (!fromRoomFocus)
		{
			if (!exteriorCamMode)
			{
				if (transform != null)
				{
					DogDenController component = transform.root.GetComponent<DogDenController>();
					if (component != null && component.IsInDen())
					{
						Vector3? focusTransformOverridePos = null;
						if (keepPosRot)
						{
							focusTransformOverridePos = transform.transform.position;
						}
						FocusOnDen(component.GetCurrentlyOccupiedDenObject(), focusTransformOverridePos);
						return;
					}
					ClearDenFocus();
				}
				else
				{
					ClearDenFocus();
				}
			}
			else if (transform != null)
			{
				ulong? roomUID = transform.root.gameObject.GetComponent<BoundingBoxComponent>().GetRoomUID();
				Vector3? focusTransformOverridePos2 = null;
				if (keepPosRot)
				{
					focusTransformOverridePos2 = transform.transform.position;
				}
				SetRoomFocus(constructionRef.GetObjectForUID(roomUID.Value), playPenFocusSound, focusTransformOverridePos2);
			}
			else if (lastFocusedRoom == null)
			{
				SetRoomFocus(constructionRef.GetObjectForUID(0uL), playPenFocusSound);
			}
			else
			{
				SetRoomFocus(lastFocusedRoom, playPenFocusSound);
			}
		}
		if (flag == exteriorCamMode)
		{
			if (!exteriorCamMode)
			{
				SetModeDenExterior();
				cinemachineBrainRef.m_DefaultBlend = cutBlend;
			}
			else
			{
				cinemachineBrainRef.m_DefaultBlend = defaultBlend;
			}
		}
	}

	public void OnObjectGrabbed(GameObject dog, GameObject grabbedObject)
	{
		if (!(currentFollowTarget == null) && !(currentFollowTarget.transform.root != dog.transform.root))
		{
			CinemachineCollider component = currentDogFocusCam.GetComponent<CinemachineCollider>();
			component.m_ObjectsToIgnore.Clear();
			component.m_ObjectsToIgnore.Add(grabbedObject.transform.root);
		}
	}

	public void OnObjectDropped(GameObject dog)
	{
		if (!(currentFollowTarget == null) && !(currentFollowTarget.transform.root != dog.transform.root))
		{
			currentDogFocusCam.GetComponent<CinemachineCollider>().m_ObjectsToIgnore.Clear();
		}
	}

	public void OnDogEnterDen(GameObject dog, Vector3 positionDelta)
	{
		if (IsCameraFollowingObject(dog))
		{
			SetModeDenInterior(null, positionDelta);
		}
	}

	public void OnDogExitDen(GameObject dog, Vector3 positionDelta)
	{
		if (IsCameraFollowingObject(dog))
		{
			SetModeDenExterior(positionDelta);
		}
	}

	private void SetModeDenInterior(DogDenInterior interiorRef = null, Vector3? positionDelta = null, Vector3? overrideFocusPos = null)
	{
		exteriorCamMode = false;
		cameraRef.backgroundColor = Color.black;
		SetFarClippingPlane(interiorCameraFarClipPos);
		cameraRef.clearFlags = CameraClearFlags.Color;
		if (positionDelta.HasValue && !overrideFocusPos.HasValue)
		{
			SnapCamera(positionDelta.Value);
		}
		if (interiorRef != null)
		{
			interiorRef.CenterFocusTransform();
			if (overrideFocusPos.HasValue)
			{
				interiorCamCenterPos = overrideFocusPos.Value;
			}
			else
			{
				interiorCamCenterPos = interiorRef.focusTransform.position;
			}
		}
		if (penGUIRef != null)
		{
			penGUIRef.OnEnterDenInterior();
		}
		if (!overrideFocusPos.HasValue)
		{
			AudioController.Play(camFocusDenEnterSound);
		}
	}

	public bool IsCamModeExterior()
	{
		return exteriorCamMode;
	}

	private void SetModeDenExterior(Vector3? positionDelta = null, Vector3? focusTransformOverridePos = null)
	{
		if (!exteriorCamMode && !focusTransformOverridePos.HasValue)
		{
			AudioController.Play(camFocusDenExitSound);
		}
		exteriorCamMode = true;
		SetFarClippingPlane(exteriorCameraFarClipPos);
		cameraRef.clearFlags = CameraClearFlags.Skybox;
		if (positionDelta.HasValue && !focusTransformOverridePos.HasValue)
		{
			SnapCamera(positionDelta.Value);
		}
		if (penGUIRef != null)
		{
			penGUIRef.OnExitDenInterior();
		}
	}

	private void SnapCamera(Vector3 positionDelta)
	{
		if (!(currentDogFocusCam == null) && !(currentPenFocusCam == null))
		{
			if (FollowCamActive())
			{
				currentDogFocusCam.OnTargetObjectWarped(currentFollowTarget, positionDelta);
			}
			else
			{
				currentPenFocusCam.OnTargetObjectWarped(currentPenFocusCam.Follow, positionDelta);
			}
		}
	}

	private void TickAutoPlay()
	{
		currentCamSwitchTimer -= Time.deltaTime;
		if ((bool)InputManager.ActiveDevice.LeftStick || (bool)InputManager.ActiveDevice.RightStick || (bool)InputManager.ActiveDevice.AnyButton || Input.anyKey || InputManager.MouseProvider.GetDeltaScroll() != 0f || InputManager.MouseProvider.GetDeltaX() != 0f || InputManager.MouseProvider.GetDeltaY() != 0f)
		{
			ResetAutoCamSwitch();
		}
		if (currentCamSwitchTimer <= 0f)
		{
			bool oldAutoSpinValue = autoSpin;
			ResetAutoCamSwitch();
			RandomCamSwitch(oldAutoSpinValue);
		}
	}

	public void AutoFocusOnRoomObjectIsInIfNeeded(GameObject obj)
	{
		if (!cursorRef.IsPassiveModeCursorEnabled())
		{
			RoomBase currentRoom = obj.GetComponent<BoundingBoxComponent>().GetCurrentRoom();
			if (currentRoom != null && lastFocusedRoom != currentRoom)
			{
				ResetAutoCamSwitch();
				SetRoomFocus(currentRoom.gameObject);
			}
		}
	}

	public void AutoFocusOnCocoonIfNeeded(GameObject cocoon)
	{
		if (!cursorRef.IsPassiveModeCursorEnabled())
		{
			ResetAutoCamSwitch();
			RequestCocoonHatchCam(cocoon);
		}
	}

	public void AutoFocusOnDogIfNeeded(GameObject dog)
	{
		if (!cursorRef.IsPassiveModeCursorEnabled() && !IsCameraFollowingObject(dog))
		{
			ResetAutoCamSwitch();
			RequestFollowCam(dog.GetComponent<LegController>().bodyFront.transform);
			dogRegRef.SelectDog(dog);
		}
	}

	private void ResetAutoCamSwitch()
	{
		autoSpin = false;
		if (currentPenFocusCam != null)
		{
			currentPenFocusCam.m_XAxis.m_InputAxisName = originalInputAxisName;
		}
		currentCamSwitchTimer = Mathf.Max(Random.Range(camSwitchMin, camSwitchMax), currentCamSwitchTimer);
	}

	private void RandomCamSwitch(bool oldAutoSpinValue)
	{
		bool flag = false;
		if (GameSettings.PassiveModeRandomDogFocus() && GameSettings.PassiveModeRandomPenFocus())
		{
			flag = ((!(Random.value >= 0.75f)) ? RandomPenCam(oldAutoSpinValue) : RandomFollowCam());
		}
		else if (GameSettings.PassiveModeRandomDogFocus())
		{
			flag = RandomFollowCam();
		}
		else if (GameSettings.PassiveModeRandomPenFocus())
		{
			flag = RandomPenCam(oldAutoSpinValue);
		}
		if (!flag)
		{
			currentCamSwitchTimer = Random.Range(camSwitchRetryMin, camSwitchRetryMax);
		}
	}

	private bool RandomFollowCam()
	{
		GameObject gameObject = null;
		if (GetFollowTarget() != null)
		{
			gameObject = GetFollowTarget().transform.root.gameObject;
		}
		List<GameObject> allInWorldOwnedDogs = dogRegRef.GetAllInWorldOwnedDogs();
		if (currentFollowTarget != null)
		{
			allInWorldOwnedDogs.Remove(currentFollowTarget.root.gameObject);
		}
		GameObject randomElement = ListUtil.GetRandomElement(allInWorldOwnedDogs);
		if (randomElement == null)
		{
			return false;
		}
		if (randomElement.CompareTag(Tags.DOG))
		{
			RequestFollowCam(randomElement.GetComponent<LegController>().bodyFront.transform);
		}
		else if (randomElement.CompareTag(Tags.COCOON))
		{
			RequestFollowCam(randomElement.GetComponent<Cocoon>().GetFocusTransform());
		}
		dogRegRef.SelectDog(randomElement);
		ScaleOrbitalFocus(currentDogFocusCam, Random.Range(minAttractModeFollowCamOrbitalRadius, maxAttractModeFollowCamOrbitalRadius));
		return randomElement != gameObject;
	}

	private bool RandomPenCam(bool oldAutoSpinValue)
	{
		List<GameObject> allRoomsWithDogs = constructionRef.GetAllRoomsWithDogs();
		if (currentFocusTransform != null && currentFollowTarget == null && allRoomsWithDogs.Contains(currentFocusTransform.root.gameObject))
		{
			allRoomsWithDogs.Remove(currentFocusTransform.root.gameObject);
		}
		GameObject randomElement = ListUtil.GetRandomElement(allRoomsWithDogs);
		if (randomElement == null)
		{
			if (oldAutoSpinValue)
			{
				autoSpin = true;
				currentPenFocusCam.m_XAxis.m_InputAxisName = "";
			}
			return false;
		}
		autoSpin = Random.value >= 0.5f;
		if (!GameSettings.PassiveModeRandomPenFocusRotation())
		{
			autoSpin = false;
		}
		bool result = false;
		if (followCam)
		{
			result = true;
		}
		else if (randomElement != lastFocusedRoom)
		{
			result = true;
		}
		SetRoomFocus(randomElement);
		if (autoSpin)
		{
			currentPenFocusCam.m_XAxis.m_InputAxisName = "";
		}
		if (Random.value > 0.5f)
		{
			ScaleOrbitalFocus(currentPenFocusCam, Random.Range(minAttractModePenFocusOrbitalRadius, maxAttractModePenFocusOrbitalRadius));
		}
		else
		{
			ScaleOrbitalFocus(currentPenFocusCam, defaultPenFocusOrbitalRadiusMiddle);
		}
		return result;
	}

	private bool CameraStickActive()
	{
		if (GameControls.actions.GamepadCameraX.IsPressed || GameControls.actions.GamepadCameraY.IsPressed)
		{
			return true;
		}
		return false;
	}

	private void UpdateFollowCam()
	{
		if (!inputAllowed)
		{
			return;
		}
		if (currentFollowTarget == null)
		{
			ClearFollowCam();
			return;
		}
		if (GameControls.actions.CameraPanMode.IsPressed || GameControls.actions.PanLeft.IsPressed || GameControls.actions.PanRight.IsPressed || GameControls.actions.PanForward.IsPressed || GameControls.actions.PanBack.IsPressed || GameControls.actions.PanUp.IsPressed || GameControls.actions.PanDown.IsPressed)
		{
			ClearFollowCam(fromRoomFocus: false, playSounds: false, playPenFocusSound: false, keepPosRot: true);
			return;
		}
		DisableMotionBlur(MotionBlurLockReason.CAMERA_MOVEMENT);
		if (currentFollowCamOrbitalRadius != currentFollowCamOrbitalRadiusTarget)
		{
			float num = followCamOrbitalRadiusSmoothingSpeed * Time.unscaledDeltaTime;
			if (currentFollowCamOrbitalRadius < currentFollowCamOrbitalRadiusTarget)
			{
				currentFollowCamOrbitalRadius = Mathf.Clamp(currentFollowCamOrbitalRadius + num, currentFollowCamOrbitalRadius, currentFollowCamOrbitalRadiusTarget);
			}
			else
			{
				currentFollowCamOrbitalRadius = Mathf.Clamp(currentFollowCamOrbitalRadius - num, currentFollowCamOrbitalRadiusTarget, currentFollowCamOrbitalRadius);
			}
			ScaleOrbitalFocus(cinemachineDogFocusRefA, currentFollowCamOrbitalRadius);
			ScaleOrbitalFocus(cinemachineDogFocusRefB, currentFollowCamOrbitalRadius);
		}
		if ((GameControls.actions.CameraRotateMode.IsPressed || CameraStickActive()) && (!scrollingLocked || !CameraStickActive()))
		{
			cinemachineDogFocusRefA.m_XAxis.m_MaxSpeed = maxXOrbitalSpeed * camSensitivity;
			cinemachineDogFocusRefA.m_YAxis.m_MaxSpeed = maxYOrbitalSpeed * camSensitivity;
			cinemachineDogFocusRefB.m_XAxis.m_MaxSpeed = maxXOrbitalSpeed * camSensitivity;
			cinemachineDogFocusRefB.m_YAxis.m_MaxSpeed = maxYOrbitalSpeed * camSensitivity;
		}
		else
		{
			cinemachineDogFocusRefA.m_XAxis.m_MaxSpeed = 0f;
			cinemachineDogFocusRefA.m_YAxis.m_MaxSpeed = 0f;
			cinemachineDogFocusRefB.m_XAxis.m_MaxSpeed = 0f;
			cinemachineDogFocusRefB.m_YAxis.m_MaxSpeed = 0f;
		}
		float num2 = 0f;
		GameControls.CheckScrollValuesIfNeeded();
		if (GameControls.actions.ZoomIn.IsPressed)
		{
			num2 = scrollDeltaFollowCamSpeed * Time.unscaledDeltaTime;
			if (GameControls.isZoomInScrollWheel && Input.mouseScrollDelta != Vector2.zero)
			{
				num2 *= GameControls.scrollDeltaFollowCamMultiplier * GameControls.currentScrollMultiplier;
			}
		}
		else if (GameControls.actions.ZoomOut.IsPressed)
		{
			num2 = (0f - scrollDeltaFollowCamSpeed) * Time.unscaledDeltaTime;
			if (GameControls.isZoomOutScrollWheel && Input.mouseScrollDelta != Vector2.zero)
			{
				num2 *= GameControls.scrollDeltaFollowCamMultiplier * GameControls.currentScrollMultiplier;
			}
		}
		if (num2 != 0f && !scrollingLocked && !grabberRef.IsHoldingObject())
		{
			grabberRef.DeactivateIndicator();
			currentFollowCamOrbitalRadiusTarget = Mathf.Clamp(currentFollowCamOrbitalRadiusTarget + num2, minFollowCamOrbitalRadius, maxFollowCamOrbitalRadius);
		}
	}

	private void UpdateRoomFocusCam()
	{
		if (currentPenFocusCam == null)
		{
			return;
		}
		if (currentPenFocusCam.LookAt == null && lastFocusedRoom != null)
		{
			SetupRoomFocusCam(lastFocusedRoom);
		}
		if (inputAllowed && (!scrollingLocked || !CameraStickActive()) && (autoSpin || ((GameControls.actions.CameraRotateMode.IsPressed || CameraStickActive()) && !GameControls.actions.CameraPanMode.IsPressed)))
		{
			cinemachinePenFocusRefA.m_XAxis.m_MaxSpeed = maxXOrbitalSpeed * camSensitivity;
			cinemachinePenFocusRefA.m_YAxis.m_MaxSpeed = maxYOrbitalSpeed * camSensitivity;
			cinemachinePenFocusRefB.m_XAxis.m_MaxSpeed = maxXOrbitalSpeed * camSensitivity;
			cinemachinePenFocusRefB.m_YAxis.m_MaxSpeed = maxYOrbitalSpeed * camSensitivity;
		}
		else
		{
			cinemachinePenFocusRefA.m_XAxis.m_MaxSpeed = 0f;
			cinemachinePenFocusRefA.m_YAxis.m_MaxSpeed = 0f;
			cinemachinePenFocusRefB.m_XAxis.m_MaxSpeed = 0f;
			cinemachinePenFocusRefB.m_YAxis.m_MaxSpeed = 0f;
		}
		if (autoSpin)
		{
			cinemachinePenFocusRefA.m_XAxis.m_InputAxisValue = autoXAxisSpinVal * Time.unscaledDeltaTime;
			cinemachinePenFocusRefB.m_XAxis.m_InputAxisValue = autoXAxisSpinVal * Time.unscaledDeltaTime;
		}
		if (currentPenFocusOrbitalRadius != currentPenFocusOrbitalRadiusTarget)
		{
			float num = penFocusOrbitalRadiusSmoothingSpeed * Time.unscaledDeltaTime;
			if (currentPenFocusOrbitalRadius < currentPenFocusOrbitalRadiusTarget)
			{
				currentPenFocusOrbitalRadius = Mathf.Clamp(currentPenFocusOrbitalRadius + num, currentPenFocusOrbitalRadius, currentPenFocusOrbitalRadiusTarget);
			}
			else
			{
				currentPenFocusOrbitalRadius = Mathf.Clamp(currentPenFocusOrbitalRadius - num, currentPenFocusOrbitalRadiusTarget, currentPenFocusOrbitalRadius);
			}
			ScaleOrbitalFocus(cinemachinePenFocusRefA, currentPenFocusOrbitalRadius);
			ScaleOrbitalFocus(cinemachinePenFocusRefB, currentPenFocusOrbitalRadius);
		}
		float num2 = 0f;
		GameControls.CheckScrollValuesIfNeeded();
		if (GameControls.actions.ZoomIn.IsPressed && !ObjectPlacementManager.IsPlacingObject())
		{
			num2 = binaryScrollDeltaPenFocusSpeed * Time.unscaledDeltaTime * GameControls.currentScrollMultiplier;
		}
		else if (GameControls.actions.ZoomOut.IsPressed && !ObjectPlacementManager.IsPlacingObject())
		{
			num2 = (0f - binaryScrollDeltaPenFocusSpeed) * Time.unscaledDeltaTime * GameControls.currentScrollMultiplier;
		}
		if (inputAllowed && num2 != 0f && !scrollingLocked && !grabberRef.IsHoldingObject() && (penGUIRef.GetCurrentMode() != GUIMode.PLACEMENT || !RaycastUtil.GlobalGUICheck()))
		{
			float max = maxPenFocusOrbitalRadius;
			if (!exteriorCamMode)
			{
				max = maxPenInteriorFocusOrbitalRadius;
			}
			grabberRef.DeactivateIndicator();
			currentPenFocusOrbitalRadiusTarget = Mathf.Clamp(currentPenFocusOrbitalRadiusTarget + num2, minPenFocusOrbitalRadius, max);
		}
	}

	private void ScaleOrbitalFocus(CinemachineFreeLook cam, float newRadius)
	{
		float radius = cam.m_Orbits[1].m_Radius;
		float num = newRadius / radius;
		cam.m_Orbits[0].m_Radius *= num;
		cam.m_Orbits[1].m_Radius *= num;
		cam.m_Orbits[2].m_Radius *= num;
		cam.m_Orbits[0].m_Height *= num;
		cam.m_Orbits[1].m_Height *= num;
		cam.m_Orbits[2].m_Height *= num;
	}

	public void RequestMoveToTarget(Vector3 newPos, Quaternion newRot, bool slerpIt = true)
	{
		if (cameraRef == null)
		{
			neededPos = newPos;
			neededRot = newRot;
			neededSlerp = slerpIt;
			needFocus = true;
			return;
		}
		needFocus = false;
		if (!(cameraRef.transform.position == newPos) || !(cameraRef.transform.rotation == newRot))
		{
			slerp = slerpIt;
			atTarget = false;
			targetPos = newPos;
			targetRot = newRot;
			currentMoveTime = 0f;
		}
	}

	private Vector3 GetCurvedKeyboardMovementVectors()
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		if (GameControls.actions.PanForward.IsPressed)
		{
			num3 = 1f;
		}
		else if (GameControls.actions.PanBack.IsPressed)
		{
			num3 = -1f;
		}
		if (GameControls.actions.PanLeft.IsPressed)
		{
			num = -1f;
		}
		else if (GameControls.actions.PanRight.IsPressed)
		{
			num = 1f;
		}
		if (GameControls.actions.PanUp.IsPressed)
		{
			num2 = 1f;
		}
		else if (GameControls.actions.PanDown.IsPressed)
		{
			num2 = -1f;
		}
		if (num == 0f && num2 == 0f && num3 == 0f)
		{
			movementKeyDownTimer = 0f;
			return Vector2.zero;
		}
		new Vector3(base.transform.forward.x, 0f, base.transform.forward.z).Normalize();
		float num4 = Mathf.Min(movementKeyDownTimer, movementKeyCurveTimer) / movementKeyCurveTimer;
		movementKeyDownTimer += Time.unscaledDeltaTime;
		return new Vector3(num, num2, num3) * num4 * Time.unscaledDeltaTime;
	}

	private void ConstraintFocusPos(Vector3 usableBounds)
	{
		if (!(currentFocusTransform == null))
		{
			Vector3 zero = Vector3.zero;
			if (!exteriorCamMode)
			{
				zero = interiorCamCenterPos;
			}
			Vector3 vector = zero - currentFocusTransform.position;
			Vector3 vector2 = vector;
			if (vector.x > usableBounds.x)
			{
				vector2 = new Vector3(usableBounds.x, vector2.y, vector2.z);
			}
			else if (vector.x < 0f - usableBounds.x)
			{
				vector2 = new Vector3(0f - usableBounds.x, vector2.y, vector2.z);
			}
			if (vector.y > usableBounds.y)
			{
				vector2 = new Vector3(vector2.x, usableBounds.y, vector2.z);
			}
			else if (vector.y < 0f - usableBounds.y)
			{
				vector2 = new Vector3(vector2.x, 0f - usableBounds.y, vector2.z);
			}
			if (vector.z > usableBounds.z)
			{
				vector2 = new Vector3(vector2.x, vector2.y, usableBounds.z);
			}
			else if (vector.z < 0f - usableBounds.z)
			{
				vector2 = new Vector3(vector2.x, vector2.y, 0f - usableBounds.z);
			}
			currentFocusTransform.position = zero - vector2;
		}
	}

	private bool CheckMove()
	{
		Vector3 usableBounds = camBounds;
		if (!exteriorCamMode)
		{
			usableBounds = camBoundsInterior;
		}
		if (!inputAllowed)
		{
			movementKeyDownTimer = 0f;
			lastMousePosSinceMiddleDown = InputManager.MouseProvider.GetPosition();
			return false;
		}
		if (!FollowCamActive())
		{
			Vector3 curvedKeyboardMovementVectors = GetCurvedKeyboardMovementVectors();
			if (curvedKeyboardMovementVectors != Vector3.zero)
			{
				Vector3 vector = new Vector3(base.transform.forward.x, 0f, base.transform.forward.z);
				vector.Normalize();
				Vector3 vector2 = curvedKeyboardMovementVectors.x * keySpeedXZ * base.transform.right;
				Vector3 vector3 = curvedKeyboardMovementVectors.y * keySpeedXZ * Vector3.up;
				Vector3 vector4 = curvedKeyboardMovementVectors.z * keySpeedXZ * vector;
				if (currentFocusTransform != null)
				{
					currentFocusTransform.position += vector2 + vector3 + vector4;
					ConstraintFocusPos(usableBounds);
				}
				lastMousePosSinceMiddleDown = InputManager.MouseProvider.GetPosition();
				movementKeyDownTimer += Time.unscaledDeltaTime;
				return true;
			}
		}
		if (!GameControls.actions.CameraPanMode.IsPressed || GameControls.actions.CameraPanMode.WasPressed)
		{
			lastMousePosSinceMiddleDown = InputManager.MouseProvider.GetPosition();
			return false;
		}
		if (FollowCamActive())
		{
			cursorRef.SetCursor(CursorController.CursorType.CAMERA_DRAG_LOCKED);
		}
		else
		{
			cursorRef.SetCursor(CursorController.CursorType.CAMERA_DRAG);
		}
		float num = InputManager.MouseProvider.GetPosition().x - lastMousePosSinceMiddleDown.x;
		float num2 = InputManager.MouseProvider.GetPosition().y - lastMousePosSinceMiddleDown.y;
		Vector3 vector5 = num * middleSpeedX * Time.unscaledDeltaTime * base.transform.right;
		Vector3 vector6 = num2 * middleSpeedY * Time.unscaledDeltaTime * base.transform.up;
		if (currentFocusTransform != null)
		{
			currentFocusTransform.position += vector5 + vector6;
			ConstraintFocusPos(usableBounds);
		}
		lastMousePosSinceMiddleDown = InputManager.MouseProvider.GetPosition();
		return true;
	}

	private void HandleConstructionModeInput()
	{
		CheckConstructionModeMoveZ();
		CheckConstructionModeMoveXY();
	}

	private void CheckConstructionModeMoveZ()
	{
		float num = 0f;
		GameControls.CheckScrollValuesIfNeeded();
		if (GameControls.actions.ZoomIn.IsPressed)
		{
			num = ((!GameControls.isZoomInScrollWheel || !(Input.mouseScrollDelta != Vector2.zero)) ? 1f : (GameControls.scrollDeltaConstructionMultiplier * GameControls.currentScrollMultiplier));
		}
		else if (GameControls.actions.ZoomOut.IsPressed)
		{
			num = ((!GameControls.isZoomOutScrollWheel || !(Input.mouseScrollDelta != Vector2.zero)) ? (-1f) : (-1f * GameControls.scrollDeltaConstructionMultiplier * GameControls.currentScrollMultiplier));
		}
		if (num != 0f && !scrollingLocked)
		{
			float orthographicSize = Mathf.Clamp(num * scrollDeltaConstructionZoomSpeed * Time.unscaledDeltaTime + cinemachineConstructionCamA.m_Lens.OrthographicSize, minConstructionZoom, maxConstructionZoom);
			cinemachineConstructionCamA.m_Lens.OrthographicSize = orthographicSize;
		}
	}

	private void CheckConstructionModeMoveXY()
	{
		Vector3 curvedKeyboardMovementVectors = GetCurvedKeyboardMovementVectors();
		Vector3 position;
		if (curvedKeyboardMovementVectors != Vector3.zero)
		{
			Vector3 vector = curvedKeyboardMovementVectors.x * keySpeedXZConstruction * base.transform.right;
			Vector3 vector2 = curvedKeyboardMovementVectors.z * keySpeedXZConstruction * base.transform.up;
			cinemachineConstructionCamA.transform.position += vector + vector2;
			position = cinemachineConstructionCamA.transform.position;
			if (cinemachineConstructionCamA.transform.position.x > camBoundsConstruction.x)
			{
				position = new Vector3(camBoundsConstruction.x, position.y, position.z);
			}
			else if (cinemachineConstructionCamA.transform.position.x < 0f - camBoundsConstruction.x)
			{
				position = new Vector3(0f - camBoundsConstruction.x, position.y, position.z);
			}
			if (cinemachineConstructionCamA.transform.position.y > camBoundsConstruction.y)
			{
				position = new Vector3(position.x, camBoundsConstruction.y, position.z);
			}
			else if (cinemachineConstructionCamA.transform.position.y < 0f - camBoundsConstruction.y)
			{
				position = new Vector3(position.x, 0f - camBoundsConstruction.y, position.z);
			}
			cinemachineConstructionCamA.transform.position = position;
			lastMousePosSinceMiddleDown = InputManager.MouseProvider.GetPosition();
			movementKeyDownTimer += Time.unscaledDeltaTime;
			return;
		}
		if (!GameControls.actions.CameraPanMode.IsPressed)
		{
			lastMousePosSinceMiddleDown = InputManager.MouseProvider.GetPosition();
			return;
		}
		cursorRef.SetCursor(CursorController.CursorType.CAMERA_DRAG);
		float num = InputManager.MouseProvider.GetPosition().x - lastMousePosSinceMiddleDown.x;
		float num2 = InputManager.MouseProvider.GetPosition().y - lastMousePosSinceMiddleDown.y;
		Vector3 vector3 = num * constructionDragSpeed * Time.unscaledDeltaTime * base.transform.right;
		Vector3 vector4 = num2 * constructionDragSpeed * Time.unscaledDeltaTime * base.transform.up;
		cinemachineConstructionCamA.transform.position += vector3 + vector4;
		position = cinemachineConstructionCamA.transform.position;
		if (cinemachineConstructionCamA.transform.position.x > camBoundsConstruction.x)
		{
			position = new Vector3(camBoundsConstruction.x, position.y, position.z);
		}
		else if (cinemachineConstructionCamA.transform.position.x < 0f - camBoundsConstruction.x)
		{
			position = new Vector3(0f - camBoundsConstruction.x, position.y, position.z);
		}
		if (cinemachineConstructionCamA.transform.position.y > camBoundsConstruction.y)
		{
			position = new Vector3(position.x, camBoundsConstruction.y, position.z);
		}
		else if (cinemachineConstructionCamA.transform.position.y < 0f - camBoundsConstruction.y)
		{
			position = new Vector3(position.x, 0f - camBoundsConstruction.y, position.z);
		}
		cinemachineConstructionCamA.transform.position = position;
		lastMousePosSinceMiddleDown = InputManager.MouseProvider.GetPosition();
	}

	private void UpdateInputBuffers()
	{
		if (currentRotationIconBuffer > 0f)
		{
			currentRotationIconBuffer = Mathf.Max(currentRotationIconBuffer - Time.unscaledDeltaTime, 0f);
		}
	}

	public void EnableRotationIconBuffer()
	{
		currentRotationIconBuffer = rotationIconBufferTimer;
	}

	private bool CheckRotate()
	{
		if (!inputAllowed || lastFocusedRoom == null || (!GameControls.actions.CameraRotateMode.IsPressed && !CameraStickActive()))
		{
			return false;
		}
		if (scrollingLocked && CameraStickActive())
		{
			return false;
		}
		if (currentRotationIconBuffer <= 0f)
		{
			cursorRef.SetCursor(CursorController.CursorType.CAMERA_ROTATE);
		}
		return true;
	}

	private Vector3 GetFocusPos()
	{
		if (FollowCamActive())
		{
			if (currentFollowTarget != null)
			{
				return currentFollowTarget.position;
			}
		}
		else if (currentPenFocusCam != null && currentPenFocusCam.Follow != null)
		{
			return currentPenFocusCam.Follow.position;
		}
		return Vector3.zero;
	}

	public bool CheckAllPenWallVisibility()
	{
		if (constructionRef == null)
		{
			return false;
		}
		oldDisabledRenderers.Clear();
		oldDisabledRenderers.AddRange(disabledRenderers);
		RestoreRenderers();
		allRooms.Clear();
		allRooms = constructionRef.GetAllRooms();
		for (int i = 0; i < allRooms.Count; i++)
		{
			RefreshRoomWalls(allRooms[i]);
		}
		bool result = false;
		if (oldDisabledRenderers.Count != disabledRenderers.Count)
		{
			result = true;
		}
		else
		{
			for (int j = 0; j < disabledRenderers.Count; j++)
			{
				if (!oldDisabledRenderers.Contains(disabledRenderers[j]))
				{
					result = true;
					break;
				}
			}
		}
		oldDisabledRenderers.Clear();
		return result;
	}

	public void RestoreRenderers()
	{
		for (int i = 0; i < disabledRenderers.Count; i++)
		{
			if (!(disabledRenderers[i] == null))
			{
				disabledRenderers[i].enabled = true;
				constructionRef.OnWallUnfaded(disabledRenderers[i].transform.root.gameObject, disabledRenderers[i].transform.parent.parent.GetComponent<WallBase>());
			}
		}
		disabledRenderers.Clear();
	}

	private void RefreshRoomWalls(GameObject room)
	{
		if (constructionRef == null || room == null)
		{
			return;
		}
		_ = base.transform.forward;
		_ = base.transform.rotation.eulerAngles;
		Vector3 vector = base.transform.position - base.transform.forward * 1f;
		if (!followCam && !penFocusCam)
		{
			return;
		}
		Vector3 bSize = new Vector3(1.1f, 1.1f, 1.1f);
		BoundingBoxComponent component = room.GetComponent<BoundingBoxComponent>();
		Vector3 aSize = component.GetBoxSize() - Vector3.one;
		if (BoundingBoxComponent.DoesAContainB(component.GetBoxCenter(), aSize, vector, bSize))
		{
			return;
		}
		Vector3 boxCenter = component.GetBoxCenter();
		RoomBase component2 = room.GetComponent<RoomBase>();
		if (!component2.IsAnyWallVisible())
		{
			return;
		}
		float num = 85f;
		float num2 = 270f;
		float num3 = 180f;
		float num4 = 90f;
		float num5 = 0f;
		float num6 = 90f;
		float num7 = 0.2f;
		Vector3 vector2 = Vector3.Normalize(vector - boxCenter);
		float num8 = Mathf.Atan2(vector2.z, vector2.x) * 57.29578f;
		if (num8 < 0f)
		{
			num8 += 360f;
		}
		WallBase wallForDirection = component2.GetWallForDirection(WallDirection.BACK);
		WallBase wallForDirection2 = component2.GetWallForDirection(WallDirection.LEFT);
		WallBase wallForDirection3 = component2.GetWallForDirection(WallDirection.RIGHT);
		WallBase wallForDirection4 = component2.GetWallForDirection(WallDirection.FRONT);
		bool flag = true;
		bool flag2 = true;
		bool flag3 = true;
		bool flag4 = true;
		bool flag5 = true;
		if (vector.z - 1f <= wallForDirection4.centerPoint.position.z && num8 <= num2 + num && num8 >= num2 - num)
		{
			DisableWall(wallForDirection4);
			flag4 = false;
		}
		if (vector.z + 1f >= wallForDirection.centerPoint.position.z && num8 <= num4 + num && num8 >= num4 - num)
		{
			DisableWall(wallForDirection);
			flag3 = false;
		}
		if (vector.x - 1f <= wallForDirection2.centerPoint.position.x && num8 <= num3 + num && num8 >= num3 - num)
		{
			DisableWall(wallForDirection2);
			flag2 = false;
		}
		if (vector.x + 1f >= wallForDirection3.centerPoint.position.x && (num8 <= num5 + num || num8 >= num5 + 360f - num))
		{
			DisableWall(wallForDirection3);
			flag5 = false;
		}
		WallBase wallForDirection5 = component2.GetWallForDirection(WallDirection.UP);
		float num9 = Vector3.Dot(wallForDirection5.centerPoint.position - vector, base.transform.forward);
		float num10 = Vector3.Angle(Vector3.Normalize(wallForDirection5.centerPoint.position - vector), Vector3.up);
		if (num9 >= num7 && num10 >= num6)
		{
			flag = false;
			DisableWall(wallForDirection5);
		}
		component2.EnableFrame();
		if (!flag4 && !flag2)
		{
			if (!flag)
			{
				component2.frameLeftTop.enabled = false;
				component2.frameFrontTop.enabled = false;
				component2.frameConnectorFrontLeft.enabled = false;
			}
			component2.frameFrontLeft.enabled = false;
		}
		else if (!flag4 && !flag5)
		{
			if (!flag)
			{
				component2.frameRightTop.enabled = false;
				component2.frameFrontTop.enabled = false;
				component2.frameConnectorFrontRight.enabled = false;
			}
			component2.frameFrontRight.enabled = false;
		}
		else if (!flag3 && !flag2)
		{
			if (!flag)
			{
				component2.frameLeftTop.enabled = false;
				component2.frameBackTop.enabled = false;
				component2.frameConnectorBackLeft.enabled = false;
			}
			component2.frameBackLeft.enabled = false;
		}
		else if (!flag3 && !flag5)
		{
			if (!flag)
			{
				component2.frameBackTop.enabled = false;
				component2.frameRightTop.enabled = false;
				component2.frameConnectorBackRight.enabled = false;
			}
			component2.frameBackRight.enabled = false;
		}
		else if (!flag4 && !flag)
		{
			component2.frameFrontTop.enabled = false;
		}
		else if (!flag3 && !flag)
		{
			component2.frameBackTop.enabled = false;
		}
		else if (!flag2 && !flag)
		{
			component2.frameLeftTop.enabled = false;
		}
		else if (!flag5 && !flag)
		{
			component2.frameRightTop.enabled = false;
		}
	}

	private void DisableWall(WallBase wallRef)
	{
		constructionRef.OnWallFaded(wallRef.transform.root.gameObject, wallRef);
		Renderer[] componentsInChildren = wallRef.gameObject.GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in componentsInChildren)
		{
			if (!(renderer == null) && renderer.enabled)
			{
				disabledRenderers.Add(renderer);
				renderer.enabled = false;
			}
		}
	}

	private bool ShouldObjectFadeOut(GameObject obj)
	{
		return constructionRef.ShouldObjectFadeOut(obj);
	}

	public bool IsZoomedOut()
	{
		if (constructionRef != null && !FollowCamActive())
		{
			if (constructionRef.IsInConstructionMode())
			{
				return true;
			}
		}
		else if (currentFollowTarget == null)
		{
			return false;
		}
		if (Vector3.Distance(GetFocusPos(), base.transform.position) <= focusZoomDepth)
		{
			return false;
		}
		if (FollowCamActive())
		{
			return true;
		}
		float num = 1f;
		float num2 = 1f;
		float num3 = (num - num2) / 2f;
		Vector3 focusPos = GetFocusPos();
		Vector3 a = new Vector3(focusPos.x, base.transform.position.y, focusPos.z);
		if (Vector3.Distance(a, base.transform.position) <= focusZoomDepth + num3)
		{
			return false;
		}
		a += new Vector3(num, 0f, 0f);
		if (Vector3.Distance(a, base.transform.position) <= focusZoomDepth + num3)
		{
			return false;
		}
		return true;
	}

	public void LockScrolling()
	{
		scrollingLocked = true;
	}

	public void UnlockScrolling()
	{
		scrollingLocked = false;
	}

	private bool CheckModularZoom()
	{
		if (!inputAllowed || !modularZoomAllowed || (grabberRef != null && grabberRef.GetGrabbedObject() != null))
		{
			return false;
		}
		int num = 0;
		if (GameControls.actions.ZoomIn.IsPressed)
		{
			num = 1;
		}
		else if (GameControls.actions.ZoomOut.IsPressed)
		{
			num = -1;
		}
		if (num == 0 || scrollingLocked)
		{
			return false;
		}
		Vector3 vector = cameraRef.transform.position;
		if (!atTarget)
		{
			vector = targetPos;
		}
		Vector3 vector2 = modularZoomDepth * base.transform.forward;
		if (!IsZoomedOut())
		{
			vector2 = focusedZoomDepth * base.transform.forward;
		}
		Quaternion rotation = cameraRef.transform.rotation;
		Vector3 focusPos = GetFocusPos();
		switch (num)
		{
		case 1:
		{
			focusPos = new Vector3(focusPos.x, vector.y, focusPos.z);
			float num2 = Vector3.Distance(focusPos, vector);
			vector += vector2;
			if (num2 < maxZoomDepth || Vector3.Distance(focusPos, vector) > num2)
			{
				vector -= vector2;
			}
			break;
		}
		case -1:
			vector -= vector2;
			if (vector.z < minZoomDepth)
			{
				vector = new Vector3(vector.x, vector.y, minZoomDepth);
			}
			break;
		}
		grabberRef.DeactivateIndicator();
		RequestMoveToTarget(vector, rotation, slerpIt: false);
		return true;
	}

	private void MoveTowardsTarget()
	{
		currentMoveTime += Time.unscaledDeltaTime;
		float t = currentMoveTime / targetTime;
		if (slerp)
		{
			base.transform.position = Vector3.Slerp(base.transform.position, targetPos, t);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRot, t);
		}
		else
		{
			base.transform.position = Vector3.Lerp(base.transform.position, targetPos, t);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, targetRot, t);
		}
		if (currentMoveTime >= targetTime)
		{
			OnTargetReached();
		}
	}

	private void OnTargetReached()
	{
		atTarget = true;
		cameraRef.transform.position = targetPos;
		cameraRef.transform.rotation = targetRot;
	}
}
