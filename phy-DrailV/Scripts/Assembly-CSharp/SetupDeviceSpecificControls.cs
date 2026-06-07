using System.Collections.Generic;
using DV.Util.EventWrapper;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class SetupDeviceSpecificControls : MonoBehaviour
{
	private struct InputBindObjects
	{
		public VRTK_InteractUse[] interactUses;

		public VRTK_InteractGrab[] interactGrabs;

		public ToggleInteractionStyle[] toggleInteractionStyle;

		public InputBindObjects(VRTK_InteractUse[] interactUses, VRTK_InteractGrab[] interactGrabs, ToggleInteractionStyle[] toggleInteractionStyle)
		{
			this.interactUses = interactUses;
			this.interactGrabs = interactGrabs;
			this.toggleInteractionStyle = toggleInteractionStyle;
		}
	}

	public static VRTK_ControllerEvents.ButtonAlias useOverrideButtonForButtonComponent = VRTK_ControllerEvents.ButtonAlias.Undefined;

	private ControllerType_DV controllerTypeLeft;

	private ControllerType_DV controllerTypeRight;

	public static event_<SDK_BaseController.ControllerHand> DeviceSpecificControlsSet;

	private readonly HashSet<ControllerType_DV> supportedControllers = new HashSet<ControllerType_DV>
	{
		ControllerType_DV.RiftTouch,
		ControllerType_DV.QuestTouch,
		ControllerType_DV.ValveIndex,
		ControllerType_DV.ViveWand,
		ControllerType_DV.WMR,
		ControllerType_DV.HPReverbG2,
		ControllerType_DV.Cosmos
	};

	public static readonly Dictionary<ControllerType_DV, VRTK_ControllerEvents.ButtonAlias> useButtonDictionary = new Dictionary<ControllerType_DV, VRTK_ControllerEvents.ButtonAlias>
	{
		{
			ControllerType_DV.Undefined,
			VRTK_ControllerEvents.ButtonAlias.TriggerClick
		},
		{
			ControllerType_DV.ViveWand,
			VRTK_ControllerEvents.ButtonAlias.TriggerClick
		},
		{
			ControllerType_DV.ValveIndex,
			VRTK_ControllerEvents.ButtonAlias.TriggerPress
		},
		{
			ControllerType_DV.QuestTouch,
			VRTK_ControllerEvents.ButtonAlias.TriggerPress
		},
		{
			ControllerType_DV.RiftTouch,
			VRTK_ControllerEvents.ButtonAlias.TriggerPress
		},
		{
			ControllerType_DV.WMR,
			VRTK_ControllerEvents.ButtonAlias.TriggerPress
		},
		{
			ControllerType_DV.HPReverbG2,
			VRTK_ControllerEvents.ButtonAlias.TriggerPress
		},
		{
			ControllerType_DV.Cosmos,
			VRTK_ControllerEvents.ButtonAlias.TriggerPress
		}
	};

	public static readonly Dictionary<ControllerType_DV, VRTK_ControllerEvents.ButtonAlias> grabButtonDictionary = new Dictionary<ControllerType_DV, VRTK_ControllerEvents.ButtonAlias>
	{
		{
			ControllerType_DV.Undefined,
			VRTK_ControllerEvents.ButtonAlias.TriggerPress
		},
		{
			ControllerType_DV.ViveWand,
			VRTK_ControllerEvents.ButtonAlias.TriggerPress
		},
		{
			ControllerType_DV.ValveIndex,
			VRTK_ControllerEvents.ButtonAlias.GripPress
		},
		{
			ControllerType_DV.QuestTouch,
			VRTK_ControllerEvents.ButtonAlias.GripPress
		},
		{
			ControllerType_DV.RiftTouch,
			VRTK_ControllerEvents.ButtonAlias.GripPress
		},
		{
			ControllerType_DV.WMR,
			VRTK_ControllerEvents.ButtonAlias.GripPress
		},
		{
			ControllerType_DV.HPReverbG2,
			VRTK_ControllerEvents.ButtonAlias.GripPress
		},
		{
			ControllerType_DV.Cosmos,
			VRTK_ControllerEvents.ButtonAlias.GripPress
		}
	};

	public static bool AreControlsSetLeft { get; private set; }

	public static bool AreControlsSetRight { get; private set; }

	private void Awake()
	{
		VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
	}

	private void OnDestroy()
	{
		AreControlsSetLeft = (AreControlsSetRight = false);
		DeviceSpecificControlsSet = default(event_<SDK_BaseController.ControllerHand>);
		if (!UnloadWatcher.isQuitting)
		{
			SetupListeners(on: false);
		}
	}

	private void Start()
	{
		SetupListeners(on: true);
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			TransmogrifyControllers.ControllerReady.Register(OnControllerReady);
		}
		else
		{
			TransmogrifyControllers.ControllerReady.Unregister(OnControllerReady);
		}
	}

	private void OnControllerReady(SDK_BaseController.ControllerHand hand)
	{
		if (hand == SDK_BaseController.ControllerHand.None)
		{
			Debug.LogError("Can't setup device specific controls for unidentified hand.", this);
			return;
		}
		if (hand == SDK_BaseController.ControllerHand.Right && !AreControlsSetRight)
		{
			InputBindObjects inputBindObjectsForControllerHand = GetInputBindObjectsForControllerHand(hand);
			controllerTypeRight = VRTK_DeviceFinder.GetControllerReferenceRightHand().GetControllerTypeDV();
			SetupForDevice(controllerTypeRight, inputBindObjectsForControllerHand);
			AreControlsSetRight = true;
			DeviceSpecificControlsSet.Invoke(hand);
		}
		else if (hand == SDK_BaseController.ControllerHand.Left && !AreControlsSetLeft)
		{
			InputBindObjects inputBindObjectsForControllerHand2 = GetInputBindObjectsForControllerHand(hand);
			controllerTypeLeft = VRTK_DeviceFinder.GetControllerReferenceLeftHand().GetControllerTypeDV();
			SetupForDevice(controllerTypeLeft, inputBindObjectsForControllerHand2);
			AreControlsSetLeft = true;
			DeviceSpecificControlsSet.Invoke(hand);
		}
		if (AreControlsSetRight && AreControlsSetLeft)
		{
			TransmogrifyControllers.ControllerReady.Unregister(OnControllerReady);
		}
	}

	private InputBindObjects GetInputBindObjectsForControllerHand(SDK_BaseController.ControllerHand hand)
	{
		GameObject gameObject = ((hand == SDK_BaseController.ControllerHand.Left) ? VRTK_DeviceFinder.GetControllerLeftHand(getActual: true) : VRTK_DeviceFinder.GetControllerRightHand(getActual: true));
		InputBindObjects result = new InputBindObjects(gameObject.GetComponentsInChildren<VRTK_InteractUse>(includeInactive: true), gameObject.GetComponentsInChildren<VRTK_InteractGrab>(includeInactive: true), gameObject.GetComponentsInChildren<ToggleInteractionStyle>(includeInactive: true));
		int num = 1;
		if (result.interactUses.Length != num)
		{
			Debug.LogError(string.Format("{0} is expecting {1} {2} instances for {3} controller, found {4}", "SetupDeviceSpecificControls", num, "VRTK_InteractUse", hand, result.interactUses.Length), base.gameObject);
		}
		num = 1;
		if (result.interactGrabs.Length != num)
		{
			Debug.LogError(string.Format("{0} is expecting {1} {2} instances for {3} controller, found {4}", "SetupDeviceSpecificControls", num, "VRTK_InteractGrab", hand, result.interactGrabs.Length), base.gameObject);
		}
		num = 1;
		if (result.toggleInteractionStyle.Length != num)
		{
			Debug.LogError(string.Format("{0} is expecting {1} {2} instances for {3} controller, found {4}", "SetupDeviceSpecificControls", num, "ToggleInteractionStyle", hand, result.interactGrabs.Length), base.gameObject);
		}
		return result;
	}

	private void SetupForDevice(ControllerType_DV controllerType, InputBindObjects inputBindObjects)
	{
		switch (controllerType)
		{
		case ControllerType_DV.ViveWand:
			SetupForViveWand(inputBindObjects);
			break;
		case ControllerType_DV.RiftTouch:
		case ControllerType_DV.QuestTouch:
			SetupForRift(inputBindObjects);
			break;
		case ControllerType_DV.ValveIndex:
			SetupForKnuckles(inputBindObjects);
			break;
		case ControllerType_DV.WMR:
			SetupForWMR(inputBindObjects);
			break;
		case ControllerType_DV.HPReverbG2:
			SetupForG2(inputBindObjects);
			break;
		case ControllerType_DV.Cosmos:
			SetupForCosmos(inputBindObjects);
			break;
		default:
			Debug.LogWarning($"Controller type '{controllerType}' is not supported. Initializing for Vive Wands.");
			SetupForViveWand(inputBindObjects);
			break;
		}
		ToggleInteractionStyle[] toggleInteractionStyle = inputBindObjects.toggleInteractionStyle;
		for (int i = 0; i < toggleInteractionStyle.Length; i++)
		{
			toggleInteractionStyle[i].Initialize();
		}
	}

	private void SetupForRift(InputBindObjects inputBindObjects)
	{
		if (VRManager.GetCurrentSDK() == VRManager.SDK.Oculus)
		{
			HapticUtils.SetHapticIntensities((HapticIntensityType.Normal, 1f), (HapticIntensityType.Strong, 1f), (HapticIntensityType.Weak, 1f));
		}
		else
		{
			HapticUtils.SetHapticIntensities((HapticIntensityType.Normal, 0.9f), (HapticIntensityType.Strong, 1f), (HapticIntensityType.Weak, 0.8f));
		}
		VRTK_InteractUse[] interactUses = inputBindObjects.interactUses;
		for (int i = 0; i < interactUses.Length; i++)
		{
			interactUses[i].useButton = useButtonDictionary[ControllerType_DV.RiftTouch];
		}
		VRTK_InteractGrab[] interactGrabs = inputBindObjects.interactGrabs;
		for (int i = 0; i < interactGrabs.Length; i++)
		{
			interactGrabs[i].grabButton = grabButtonDictionary[ControllerType_DV.RiftTouch];
		}
		useOverrideButtonForButtonComponent = VRTK_ControllerEvents.ButtonAlias.TriggerPress;
	}

	private void SetupForViveWand(InputBindObjects inputBindObjects)
	{
		HapticUtils.SetHapticIntensities((HapticIntensityType.Normal, 0.2f), (HapticIntensityType.Strong, 0.3f), (HapticIntensityType.Weak, 0.1f));
		VRTK_InteractUse[] interactUses = inputBindObjects.interactUses;
		for (int i = 0; i < interactUses.Length; i++)
		{
			interactUses[i].useButton = useButtonDictionary[ControllerType_DV.ViveWand];
		}
		VRTK_InteractGrab[] interactGrabs = inputBindObjects.interactGrabs;
		for (int i = 0; i < interactGrabs.Length; i++)
		{
			interactGrabs[i].grabButton = grabButtonDictionary[ControllerType_DV.ViveWand];
		}
		useOverrideButtonForButtonComponent = VRTK_ControllerEvents.ButtonAlias.TriggerPress;
	}

	private void SetupForKnuckles(InputBindObjects inputBindObjects)
	{
		HapticUtils.SetHapticIntensities((HapticIntensityType.Normal, 0.2f), (HapticIntensityType.Strong, 0.3f), (HapticIntensityType.Weak, 0.1f));
		VRTK_InteractUse[] interactUses = inputBindObjects.interactUses;
		for (int i = 0; i < interactUses.Length; i++)
		{
			interactUses[i].useButton = useButtonDictionary[ControllerType_DV.ValveIndex];
		}
		VRTK_InteractGrab[] interactGrabs = inputBindObjects.interactGrabs;
		for (int i = 0; i < interactGrabs.Length; i++)
		{
			interactGrabs[i].grabButton = grabButtonDictionary[ControllerType_DV.ValveIndex];
		}
		useOverrideButtonForButtonComponent = VRTK_ControllerEvents.ButtonAlias.TriggerPress;
	}

	private void SetupForWMR(InputBindObjects inputBindObjects)
	{
		HapticUtils.SetHapticIntensities((HapticIntensityType.Normal, 0.2f), (HapticIntensityType.Strong, 0.3f), (HapticIntensityType.Weak, 0.1f));
		VRTK_InteractUse[] interactUses = inputBindObjects.interactUses;
		for (int i = 0; i < interactUses.Length; i++)
		{
			interactUses[i].useButton = useButtonDictionary[ControllerType_DV.WMR];
		}
		VRTK_InteractGrab[] interactGrabs = inputBindObjects.interactGrabs;
		for (int i = 0; i < interactGrabs.Length; i++)
		{
			interactGrabs[i].grabButton = grabButtonDictionary[ControllerType_DV.WMR];
		}
		useOverrideButtonForButtonComponent = VRTK_ControllerEvents.ButtonAlias.TriggerPress;
	}

	private void SetupForG2(InputBindObjects inputBindObjects)
	{
		HapticUtils.SetHapticIntensities((HapticIntensityType.Normal, 0.2f), (HapticIntensityType.Strong, 0.3f), (HapticIntensityType.Weak, 0.1f));
		VRTK_InteractUse[] interactUses = inputBindObjects.interactUses;
		for (int i = 0; i < interactUses.Length; i++)
		{
			interactUses[i].useButton = useButtonDictionary[ControllerType_DV.HPReverbG2];
		}
		VRTK_InteractGrab[] interactGrabs = inputBindObjects.interactGrabs;
		for (int i = 0; i < interactGrabs.Length; i++)
		{
			interactGrabs[i].grabButton = grabButtonDictionary[ControllerType_DV.HPReverbG2];
		}
		useOverrideButtonForButtonComponent = VRTK_ControllerEvents.ButtonAlias.TriggerPress;
	}

	private void SetupForCosmos(InputBindObjects inputBindObjects)
	{
		HapticUtils.SetHapticIntensities((HapticIntensityType.Normal, 0.2f), (HapticIntensityType.Strong, 0.3f), (HapticIntensityType.Weak, 0.1f));
		VRTK_InteractUse[] interactUses = inputBindObjects.interactUses;
		for (int i = 0; i < interactUses.Length; i++)
		{
			interactUses[i].useButton = useButtonDictionary[ControllerType_DV.Cosmos];
		}
		VRTK_InteractGrab[] interactGrabs = inputBindObjects.interactGrabs;
		for (int i = 0; i < interactGrabs.Length; i++)
		{
			interactGrabs[i].grabButton = grabButtonDictionary[ControllerType_DV.Cosmos];
		}
		useOverrideButtonForButtonComponent = VRTK_ControllerEvents.ButtonAlias.TriggerPress;
	}

	public static bool ControllerSupportsMultiTouch(VRTK_ControllerReference ctrlRef)
	{
		return ctrlRef.IsWandOrUndefined();
	}
}
