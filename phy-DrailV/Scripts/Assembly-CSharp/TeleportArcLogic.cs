using System.Collections;
using DV;
using DV.Utils;
using UnityEngine;
using VRTK;

public class TeleportArcLogic : MonoBehaviour
{
	public const float POINTING_UP_THRESHOLD = 0.8f;

	private const float ELONGATE_LERP = 0.2f;

	private static WaitForSeconds WAIT_FOR_ELONGATE_IN_CAB = WaitFor.Seconds(0f);

	private static WaitForSeconds WAIT_FOR_ELONGATE_OUTSIDE = WaitFor.Seconds(3f);

	private static ArcParams POINTING_UP = new ArcParams
	{
		duration = 0.1f,
		speed = 0.06f,
		length = 8f,
		segmentCount = 4
	};

	private static ArcParams IN_CAB_SHORT = new ArcParams
	{
		duration = 4f,
		speed = 0.3f,
		length = 16f,
		segmentCount = 120
	};

	private static ArcParams IN_CAB_LONG = new ArcParams
	{
		duration = 4f,
		speed = 0.3f,
		length = 24f,
		segmentCount = 120
	};

	private static ArcParams OUTSIDE_SHORT = new ArcParams
	{
		duration = 4f,
		speed = 0.3f,
		length = 16f,
		segmentCount = 120
	};

	private static ArcParams OUTSIDE_LONG = new ArcParams
	{
		duration = 6f,
		speed = 0.3f,
		length = 32f,
		segmentCount = 200
	};

	private VRTK_Pointer pointer;

	private VRTK_CustomRaycast raycasts;

	private int originalRaycastMask;

	private VRTK_ValveArcPointerRenderer valveArc;

	private bool inCab;

	private Coroutine elongateCoro;

	private Coroutine visibilityCoro;

	private ArcParams currentValues;

	private ArcParams targetValues;

	private TeleportForbiddenOverlapSafety noTeleport;

	private void Awake()
	{
		pointer = GetComponent<VRTK_Pointer>();
		raycasts = GetComponent<VRTK_CustomRaycast>();
		valveArc = GetComponent<VRTK_ValveArcPointerRenderer>();
		originalRaycastMask = raycasts.layersToIgnore;
		if (!pointer)
		{
			Debug.LogError("TeleportArcLogic couldn't find VRTK_Pointer", this);
		}
		if (!raycasts)
		{
			Debug.LogError("TeleportArcLogic couldn't find VRTK_CustomRaycast", this);
		}
		if (!valveArc)
		{
			Debug.LogError("TeleportArcLogic couldn't find VRTK_ValveArcPointerRenderer", this);
		}
	}

	private void Start()
	{
		GameObject gameObject = base.gameObject.GetComponentInParent<ToggleInteractionStyle>().gameObject;
		noTeleport = gameObject.AddComponent<TeleportForbiddenOverlapSafety>();
		SetupListeners(on: true);
		base.enabled = false;
	}

	private void OnDestroy()
	{
		SetupListeners(on: false);
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			pointer.ActivationButtonPressed += OnTeleportStarted;
			pointer.ActivationButtonReleased += OnTeleportEndedOrAborted;
		}
		else
		{
			pointer.ActivationButtonPressed -= OnTeleportStarted;
			pointer.ActivationButtonReleased -= OnTeleportEndedOrAborted;
		}
	}

	private void OnTeleportStarted(object _, ControllerInteractionEventArgs __)
	{
		raycasts.layersToIgnore = -1;
		inCab = TrainCar.Resolve(base.gameObject) != null;
		valveArc.justTurnedOn = true;
		currentValues = (inCab ? IN_CAB_SHORT : OUTSIDE_SHORT);
		targetValues = currentValues;
		ArcParams values = (inCab ? IN_CAB_LONG : OUTSIDE_LONG);
		base.enabled = true;
		if (elongateCoro != null)
		{
			StopCoroutine(elongateCoro);
		}
		elongateCoro = StartCoroutine(ElongateArc(values, inCab ? WAIT_FOR_ELONGATE_IN_CAB : WAIT_FOR_ELONGATE_OUTSIDE));
		if (visibilityCoro != null)
		{
			StopCoroutine(visibilityCoro);
		}
		visibilityCoro = StartCoroutine(TurnOnCursorVisiblity());
	}

	private IEnumerator TurnOnCursorVisiblity()
	{
		yield return null;
		VRTK_ValveArcPointerRenderer vRTK_ValveArcPointerRenderer = valveArc;
		VRTK_ValveArcPointerRenderer vRTK_ValveArcPointerRenderer2 = valveArc;
		VRTK_BasePointerRenderer.VisibilityStates cursorVisibility = VRTK_BasePointerRenderer.VisibilityStates.OnWhenActive;
		vRTK_ValveArcPointerRenderer2.tracerVisibility = VRTK_BasePointerRenderer.VisibilityStates.OnWhenActive;
		vRTK_ValveArcPointerRenderer.cursorVisibility = cursorVisibility;
	}

	private IEnumerator ElongateArc(ArcParams values, WaitForSeconds wait)
	{
		yield return wait;
		targetValues = values;
		elongateCoro = null;
	}

	private void OnTeleportEndedOrAborted()
	{
		if (visibilityCoro != null)
		{
			StopCoroutine(visibilityCoro);
			visibilityCoro = null;
		}
		valveArc.TryAbortTracerActivation();
		valveArc.cursorVisibility = (valveArc.tracerVisibility = VRTK_BasePointerRenderer.VisibilityStates.AlwaysOff);
		raycasts.layersToIgnore = originalRaycastMask;
		base.enabled = false;
	}

	private void OnTeleportEndedOrAborted(object _, ControllerInteractionEventArgs __)
	{
		OnTeleportEndedOrAborted();
	}

	private void Update()
	{
		if (SingletonBehaviour<AppUtil>.Instance.IsPauseMenuOpen)
		{
			OnTeleportEndedOrAborted();
			raycasts.layersToIgnore = -1;
		}
		else if (Vector3.Dot(base.transform.forward, Vector3.up) > 0.8f || noTeleport.isInsideForbiddenCollider)
		{
			raycasts.layersToIgnore = -1;
			POINTING_UP.Apply(valveArc);
		}
		else
		{
			raycasts.layersToIgnore = originalRaycastMask;
			currentValues.Lerp(targetValues, 0.2f);
			currentValues.Apply(valveArc);
		}
	}
}
