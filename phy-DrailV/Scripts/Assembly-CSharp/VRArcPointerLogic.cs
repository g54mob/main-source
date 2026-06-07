using DV;
using UnityEngine;
using VRTK;

public class VRArcPointerLogic : APointerLogic
{
	public struct ArcParams
	{
		public float duration;

		public float speed;

		public float length;

		public int segmentCount;

		public void Lerp(ArcParams target, float ratio)
		{
			duration = Mathf.Lerp(duration, target.duration, ratio);
			speed = Mathf.Lerp(speed, target.speed, ratio);
			length = Mathf.Lerp(length, target.length, ratio);
			segmentCount = (int)Mathf.Lerp(segmentCount, target.segmentCount, ratio);
		}
	}

	private enum TeleportRequestState
	{
		Idle = 0,
		Targeting = 1,
		TeleportRequested = 2
	}

	private static readonly ArcParams ARC_PARAMS_LONG = new ArcParams
	{
		duration = 6f,
		speed = 0.3f,
		length = 32f,
		segmentCount = 200
	};

	private static readonly ArcParams ARC_PARAMS_SHORT = new ArcParams
	{
		duration = 3f,
		speed = 0.3f,
		length = 3.5f,
		segmentCount = 200
	};

	private static readonly ArcParams POINTING_UP = new ArcParams
	{
		duration = 0.1f,
		speed = 0.06f,
		length = 8f,
		segmentCount = 4
	};

	public VRTK_ControllerEvents.ButtonAlias activationButton;

	public ValveTeleportArc arc;

	public float pointingUpThreshold = 0.8f;

	private TeleportForbiddenOverlapSafety noTeleport;

	private TeleportInputVR teleportInputVR;

	private GameParams gameParams;

	private TeleportRequestState state;

	private void Awake()
	{
		SetupDeviceSpecificControls.DeviceSpecificControlsSet.Register(OnControlsSet);
		gameParams = Globals.G.GameParams;
	}

	private void OnEnable()
	{
		state = TeleportRequestState.Idle;
	}

	private void OnDestroy()
	{
		SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
		if (!UnloadWatcher.isUnloading)
		{
			SetupListeners(on: false);
		}
	}

	private void OnControlsSet(SDK_BaseController.ControllerHand givenHand)
	{
		GameObject gameObject = GetComponentInParent<ToggleInteractionStyle>()?.gameObject;
		if (VRTK_DeviceFinder.GetControllerHand(gameObject) == givenHand)
		{
			arc.queryTriggerInteraction = QueryTriggerInteraction.Collide;
			Transform transform = PipaUtils.PipaTransform(gameObject);
			if ((bool)transform)
			{
				noTeleport = transform.gameObject.AddComponent<TeleportForbiddenOverlapSafety>();
			}
			else
			{
				Debug.LogWarning("VRArcPointerLogic couldn't add TeleportForbiddenOverlapSafety component", this);
			}
			teleportInputVR = base.gameObject.AddComponent<TeleportInputVR>();
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
			SetupListeners(on: true);
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			teleportInputVR.TeleportButtonPressed += OnTeleportButtonPressed;
			teleportInputVR.TeleportButtonReleased += OnTeleportButtonReleased;
			teleportInputVR.TeleportAbortRequested += OnTeleportAbortRequested;
		}
		else
		{
			teleportInputVR.TeleportButtonPressed -= OnTeleportButtonPressed;
			teleportInputVR.TeleportButtonReleased -= OnTeleportButtonReleased;
			teleportInputVR.TeleportAbortRequested -= OnTeleportAbortRequested;
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
		}
	}

	private void OnTeleportButtonPressed()
	{
		state = TeleportRequestState.Targeting;
	}

	private void OnTeleportButtonReleased()
	{
		state = TeleportRequestState.TeleportRequested;
	}

	private void OnTeleportAbortRequested()
	{
		state = TeleportRequestState.Idle;
	}

	private void Update()
	{
		if (state == TeleportRequestState.TeleportRequested)
		{
			state = TeleportRequestState.Idle;
		}
	}

	public override bool IsActivationButtonBeingHeld()
	{
		return state == TeleportRequestState.Targeting;
	}

	public override bool IsActivationButtonJustReleased()
	{
		return state == TeleportRequestState.TeleportRequested;
	}

	public override bool ScanForCab(int layerMask, out RaycastHit hit)
	{
		if (IsActivationButtonBeingHeld() || IsActivationButtonJustReleased())
		{
			return ScanForTeleportDestination(layerMask, out hit);
		}
		hit = default(RaycastHit);
		return false;
	}

	public override bool ScanForTeleportDestination(int layerMask, out RaycastHit hit)
	{
		bool flag = Vector3.Dot(base.transform.forward, Vector3.up) > pointingUpThreshold;
		ArcParams arcParams;
		if (flag || ((bool)noTeleport && noTeleport.isInsideForbiddenCollider))
		{
			layerMask = 0;
			arcParams = POINTING_UP;
			SetColor(colorInvalid);
		}
		else
		{
			arcParams = (gameParams.LongDashAllowed ? ARC_PARAMS_LONG : ARC_PARAMS_SHORT);
		}
		arc.arcDuration = arcParams.duration;
		arc.arcSpeed = arcParams.speed;
		arc.segmentCount = arcParams.segmentCount;
		arc.traceLayerMask = layerMask;
		arc.UpdateRenderer();
		arc.SetArcData(base.transform.position, base.transform.forward * arcParams.length, gravity: true, flag);
		return arc.DrawArc(out hit);
	}

	public override void Enable()
	{
		arc.enabled = true;
	}

	public override void Disable()
	{
		arc.enabled = false;
	}

	public override void SetColor(Color color)
	{
		arc.SetColor(color);
	}
}
