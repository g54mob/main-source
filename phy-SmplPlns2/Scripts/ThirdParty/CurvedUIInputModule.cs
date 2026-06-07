using System;
using CurvedUI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CurvedUIInputModule : MonoBehaviour
{
	public enum CUIControlMethod
	{
		MOUSE = 0,
		GAZE = 1,
		WORLD_MOUSE = 2,
		CUSTOM_RAY = 3,
		STEAMVR_LEGACY = 4,
		OCULUSVR = 5,
		GOOGLEVR = 7,
		STEAMVR_2 = 8,
		UNITY_XR = 9
	}

	public enum Hand
	{
		Both = 0,
		Right = 1,
		Left = 2
	}

	[SerializeField]
	private CUIControlMethod controlMethod;

	[SerializeField]
	private string submitButtonName = "Fire1";

	[SerializeField]
	private Camera mainEventCamera;

	[SerializeField]
	private LayerMask raycastLayerMask = 32;

	[SerializeField]
	private bool gazeUseTimedClick;

	[SerializeField]
	private float gazeClickTimer = 2f;

	[SerializeField]
	private float gazeClickTimerDelay = 1f;

	[SerializeField]
	private Image gazeTimedClickProgressImage;

	[SerializeField]
	private float worldSpaceMouseSensitivity = 1f;

	[SerializeField]
	private Hand usedHand = Hand.Right;

	[FormerlySerializedAs("controllerTransformOverride")]
	[SerializeField]
	private Transform pointerTransformOverride;

	private static bool disableOtherInputModulesOnStart = true;

	private static CurvedUIInputModule instance;

	private GameObject currentDragging;

	private GameObject currentPointedAt;

	private GameObject m_rightController;

	private GameObject m_leftController;

	private float gazeTimerProgress;

	private Ray customControllerRay;

	private float dragThreshold = 10f;

	private bool pressedDown;

	private bool pressedLastFrame;

	private Vector3 lastMouseOnScreenPos = Vector2.zero;

	private Vector2 worldSpaceMouseInCanvasSpace = Vector2.zero;

	private Vector2 lastWorldSpaceMouseOnCanvas = Vector2.zero;

	private Vector2 worldSpaceMouseOnCanvasDelta = Vector2.zero;

	public static CurvedUIInputModule Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameObject("CurvedUI").AddComponent<CurvedUIInputModule>();
			}
			return instance;
		}
		private set
		{
			instance = value;
		}
	}

	public static CUIControlMethod ControlMethod
	{
		get
		{
			return Instance.controlMethod;
		}
		set
		{
			if (Instance.controlMethod != value)
			{
				Instance.controlMethod = value;
			}
		}
	}

	public LayerMask RaycastLayerMask
	{
		get
		{
			return raycastLayerMask;
		}
		set
		{
			raycastLayerMask = value;
		}
	}

	public Hand UsedHand
	{
		get
		{
			return usedHand;
		}
		set
		{
			usedHand = value;
		}
	}

	public Transform ControllerTransform
	{
		get
		{
			if (PointerTransformOverride != null)
			{
				return PointerTransformOverride;
			}
			Debug.LogWarning("CURVEDUI: CurvedUIInputModule.ActiveController will only return proper gameobject in  STEAMVR, STEAMVR_LEGACY, OCULUSVR, UNITY_XR or GOOGLEVR control methods.");
			return null;
		}
	}

	public Vector3 ControllerPointingDirection
	{
		get
		{
			Debug.LogWarning("CURVEDUI: CurvedUIInputModule.PointingDirection will only return proper direction in  STEAMVR, STEAMVR_LEGACY, OCULUSVR, UNITY_XR or GOOGLEVR control methods.");
			return Vector3.forward;
		}
	}

	public Vector3 ControllerPointingOrigin
	{
		get
		{
			Debug.LogWarning("CURVEDUI: CurvedUIInputModule.PointingOrigin will only return proper position in  STEAMVR, STEAMVR_LEGACY, OCULUSVR, UNITY_XR or GOOGLEVR control methods.");
			return Vector3.zero;
		}
	}

	public Transform PointerTransformOverride
	{
		get
		{
			return instance.pointerTransformOverride;
		}
		set
		{
			instance.pointerTransformOverride = value;
		}
	}

	public GameObject CurrentPointedAt => currentPointedAt;

	public Camera EventCamera
	{
		get
		{
			return mainEventCamera;
		}
		set
		{
			mainEventCamera = value;
			if (mainEventCamera != null)
			{
				mainEventCamera.AddComponentIfMissing<CurvedUIPhysicsRaycaster>();
			}
		}
	}

	public static Ray CustomControllerRay
	{
		get
		{
			return Instance.customControllerRay;
		}
		set
		{
			Instance.customControllerRay = value;
		}
	}

	public static bool CustomControllerButtonState
	{
		get
		{
			return Instance.pressedDown;
		}
		set
		{
			Instance.pressedDown = value;
		}
	}

	[Obsolete("Use CustomControllerButtonState instead.")]
	public static bool CustomControllerButtonDown
	{
		get
		{
			return Instance.pressedDown;
		}
		set
		{
			Instance.pressedDown = value;
		}
	}

	public Vector2 WorldSpaceMouseInCanvasSpace
	{
		get
		{
			return worldSpaceMouseInCanvasSpace;
		}
		set
		{
			worldSpaceMouseInCanvasSpace = value;
			lastWorldSpaceMouseOnCanvas = value;
		}
	}

	public Vector2 WorldSpaceMouseInCanvasSpaceDelta => worldSpaceMouseInCanvasSpace - lastWorldSpaceMouseOnCanvas;

	public float WorldSpaceMouseSensitivity
	{
		get
		{
			return worldSpaceMouseSensitivity;
		}
		set
		{
			worldSpaceMouseSensitivity = value;
		}
	}

	public bool GazeUseTimedClick
	{
		get
		{
			return gazeUseTimedClick;
		}
		set
		{
			gazeUseTimedClick = value;
		}
	}

	public float GazeClickTimer
	{
		get
		{
			return gazeClickTimer;
		}
		set
		{
			gazeClickTimer = Mathf.Max(value, 0f);
		}
	}

	public float GazeClickTimerDelay
	{
		get
		{
			return gazeClickTimerDelay;
		}
		set
		{
			gazeClickTimerDelay = Mathf.Max(value, 0f);
		}
	}

	public float GazeTimerProgress => gazeTimerProgress;

	public Image GazeTimedClickProgressImage
	{
		get
		{
			return gazeTimedClickProgressImage;
		}
		set
		{
			gazeTimedClickProgressImage = value;
		}
	}

	private PointerEventData.FramePressState CustomRayFramePressedState()
	{
		if (pressedDown && !pressedLastFrame)
		{
			return PointerEventData.FramePressState.Pressed;
		}
		if (!pressedDown && pressedLastFrame)
		{
			return PointerEventData.FramePressState.Released;
		}
		return PointerEventData.FramePressState.NotChanged;
	}

	protected virtual void ProcessViveControllers()
	{
	}

	protected virtual void ProcessOculusVRController()
	{
	}

	private void ProcessSteamVR2Controllers()
	{
	}

	protected virtual void ProcessUnityXRController()
	{
	}

	private static T EnableInputModule<T>() where T : BaseInputModule
	{
		bool flag = true;
		EventSystem eventSystem = UnityEngine.Object.FindFirstObjectByType<EventSystem>();
		if (eventSystem == null)
		{
			Debug.LogError("CurvedUI: Your EventSystem component is missing from the scene! Unity Canvas will not track interactions without it.");
			return null;
		}
		BaseInputModule[] components = eventSystem.GetComponents<BaseInputModule>();
		foreach (BaseInputModule baseInputModule in components)
		{
			if (baseInputModule is T)
			{
				flag = false;
				baseInputModule.enabled = true;
			}
			else if (disableOtherInputModulesOnStart)
			{
				baseInputModule.enabled = false;
			}
		}
		if (flag)
		{
			eventSystem.gameObject.AddComponent<T>();
		}
		return eventSystem.GetComponent<T>();
	}

	public Ray GetEventRay(Camera eventCam = null)
	{
		if (eventCam == null)
		{
			eventCam = mainEventCamera;
		}
		switch (ControlMethod)
		{
		case CUIControlMethod.MOUSE:
			return eventCam.ScreenPointToRay(Input.mousePosition);
		case CUIControlMethod.GAZE:
			return new Ray(eventCam.transform.position, eventCam.transform.forward);
		case CUIControlMethod.STEAMVR_LEGACY:
		case CUIControlMethod.GOOGLEVR:
			if ((bool)pointerTransformOverride)
			{
				return new Ray(pointerTransformOverride.position, pointerTransformOverride.forward);
			}
			return new Ray(ControllerPointingOrigin, ControllerPointingDirection);
		default:
			if ((bool)pointerTransformOverride)
			{
				return new Ray(pointerTransformOverride.position, pointerTransformOverride.forward);
			}
			return CustomControllerRay;
		}
	}
}
