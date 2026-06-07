using System;
using System.Collections;
using DV.CabControls;
using DV.Interaction;
using DV.Utils;
using UnityEngine;
using VRTK;

public class PluggableObject : MonoBehaviour
{
	public enum PluggableState
	{
		Free = 0,
		Snapping = 1,
		PluggedIn = 2
	}

	[Header("General")]
	public string connectionTag;

	public bool reparentToSocket;

	public bool allowHandsFreePlugging;

	public bool allowUseToPlug = true;

	public bool yankOutOfHand = true;

	[Header("Startup")]
	public PlugSocket startAttachedTo;

	[Header("Alignment")]
	public Transform connectionPoint;

	[Header("Instant snap threshold")]
	public float instantSnapDistance = 0.1f;

	public float instantSnapAngle = 5f;

	private Collider[] allColliders;

	private Rigidbody[] allRigidBodies;

	private Transform virtualParent;

	private ControlImplBase controlBase;

	private Grabber nonVrGrabber;

	private GrabberInteractionHandlerDV interactionHandler;

	private Telegrabbable telegrabbable;

	private Vector3 positionOffset = Vector3.zero;

	private Quaternion rotationOffset = Quaternion.identity;

	private RaycastHit[] raycastCache = new RaycastHit[16];

	private PlugSocket targetedSocket;

	private int notHeldFrames;

	private int socketLayerMask;

	private bool controlGrabbed;

	private LayerMask grabbedLayerMask;

	private LayerMask ungrabbedLayerMask;

	private bool initialized;

	public PlugSocket Socket { get; private set; }

	public PluggableState State { get; private set; }

	public virtual bool IsLocked
	{
		get
		{
			if (!yankOutOfHand && !(telegrabbable == null))
			{
				return !telegrabbable.IsBeingTelegrabbed;
			}
			return false;
		}
	}

	public bool IsHeldInHand => controlGrabbed;

	public event Action<PluggableObject, PlugSocket> PluggingStart;

	public event Action<PluggableObject, PlugSocket> PluggingAbort;

	public event Action<PluggableObject, PlugSocket> PluggedIn;

	public event Action<PluggableObject, PlugSocket> Unplugged;

	private void Awake()
	{
		CheckInitialization();
		if (startAttachedTo != null)
		{
			InstantSnapTo(startAttachedTo);
		}
	}

	private void CheckInitialization()
	{
		if (!initialized)
		{
			socketLayerMask = LayerMask.GetMask("World_Item");
			grabbedLayerMask = LayerMask.NameToLayer("Grabbed_Item");
			ungrabbedLayerMask = LayerMask.NameToLayer("World_Item");
			if (VRManager.IsVREnabled())
			{
				base.gameObject.AddComponent<PluggableObjectKinematicVRFix>();
			}
			initialized = true;
		}
	}

	private void Start()
	{
		allColliders = GetComponentsInChildren<Collider>();
		allRigidBodies = GetComponentsInChildren<Rigidbody>();
		if (State == PluggableState.PluggedIn)
		{
			DisableStandaloneComponents();
		}
		controlBase = GetComponent<ControlImplBase>();
		if (controlBase != null)
		{
			controlBase.Used += OnUsePlugIn;
			controlBase.Grabbed += OnControlGrabbed;
			controlBase.Ungrabbed += OnControlUngrabbed;
		}
		if (!VRManager.IsVREnabled())
		{
			if (PlayerManager.PlayerTransform != null)
			{
				nonVrGrabber = PlayerManager.PlayerTransform.GetComponentInChildren<Grabber>();
				interactionHandler = nonVrGrabber.GetComponent<GrabberInteractionHandlerDV>();
			}
			if (nonVrGrabber == null)
			{
				StartCoroutine(DelayedComponentAcquisition());
			}
		}
	}

	private void OnControlGrabbed(ControlImplBase item)
	{
		controlGrabbed = true;
		if (State == PluggableState.PluggedIn)
		{
			Unplug();
			if (!VRManager.IsVREnabled() && controlBase is ItemBase)
			{
				base.transform.localPosition = Vector3.zero;
				base.transform.localRotation = Quaternion.identity;
			}
		}
		else if (State == PluggableState.Snapping)
		{
			StopAllCoroutines();
		}
		SetColliderLayers(isGrabbed: true);
	}

	private void SetColliderLayers(bool isGrabbed)
	{
		if (allColliders == null)
		{
			return;
		}
		LayerMask layerMask = (isGrabbed ? grabbedLayerMask : ungrabbedLayerMask);
		Collider[] array = allColliders;
		foreach (Collider collider in array)
		{
			if (!(collider == null))
			{
				collider.gameObject.layer = layerMask;
			}
		}
	}

	private void OnControlUngrabbed(ControlImplBase item)
	{
		controlGrabbed = false;
		SetColliderLayers(isGrabbed: false);
	}

	private IEnumerator DelayedComponentAcquisition()
	{
		while (PlayerManager.PlayerTransform == null)
		{
			yield return null;
		}
		for (int i = 0; i < 10; i++)
		{
			yield return null;
		}
		nonVrGrabber = PlayerManager.PlayerTransform.GetComponentInChildren<Grabber>();
		telegrabbable = GetComponent<Telegrabbable>();
	}

	private void OnDestroy()
	{
		if (controlBase != null)
		{
			controlBase.Used -= OnUsePlugIn;
			controlBase.Grabbed -= OnControlGrabbed;
			controlBase.Ungrabbed -= OnControlUngrabbed;
		}
	}

	private void OnDisable()
	{
		if (Socket != null)
		{
			Socket.NotifyUnplugged(this, playSound: false);
		}
	}

	public bool InstantSnapTo(PlugSocket socket)
	{
		CheckInitialization();
		if (State != PluggableState.Free || !CanPlugInto(socket) || !socket.CanAccept(this))
		{
			return false;
		}
		StartCoroutine(ConnectingRoutine(socket, 0f, playSound: false));
		return true;
	}

	public bool StartSnappingTo(PlugSocket socket, bool itemUseInitiated = false)
	{
		if (controlGrabbed && !yankOutOfHand && !itemUseInitiated)
		{
			return false;
		}
		if (State != PluggableState.Free)
		{
			return false;
		}
		if (!CanPlugInto(socket))
		{
			return false;
		}
		if (!socket.CanAccept(this))
		{
			return false;
		}
		float num = Vector3.Distance((connectionPoint != null) ? connectionPoint.transform.position : base.transform.position, GetSnappedWorldPositionFor(socket));
		float num2 = Quaternion.Angle((connectionPoint != null) ? connectionPoint.transform.rotation : base.transform.rotation, GetSnappedWorldRotationFor(socket));
		float duration = ((num < instantSnapDistance && num2 < instantSnapAngle) ? 0f : socket.snapInDuration);
		StartCoroutine(ConnectingRoutine(socket, duration, playSound: true));
		return true;
	}

	public bool YankOutOfHand()
	{
		if (controlGrabbed)
		{
			controlBase.ForceEndInteraction();
			return true;
		}
		return false;
	}

	private IEnumerator ConnectingRoutine(PlugSocket socket, float duration, bool playSound)
	{
		if (YankOutOfHand())
		{
			yield return null;
		}
		DisableStandaloneComponents();
		DisableColliders();
		Socket = socket;
		State = PluggableState.Snapping;
		virtualParent = ((socket.plugMarker != null) ? socket.plugMarker.transform : socket.transform);
		if (reparentToSocket)
		{
			base.transform.SetParent(virtualParent, worldPositionStays: true);
		}
		this.PluggingStart?.Invoke(this, socket);
		Vector3 startingPosition = (reparentToSocket ? base.transform.localPosition : base.transform.position);
		Quaternion startingRotation = (reparentToSocket ? base.transform.localRotation : base.transform.rotation);
		positionOffset = ((connectionPoint != null) ? (-connectionPoint.localPosition) : Vector3.zero);
		rotationOffset = ((connectionPoint != null) ? Quaternion.Inverse(connectionPoint.localRotation) : Quaternion.identity);
		if (duration <= Time.deltaTime)
		{
			if (reparentToSocket)
			{
				base.transform.localPosition = positionOffset;
				base.transform.localRotation = rotationOffset;
			}
			else
			{
				base.transform.position = GetSnappedWorldPositionFor(socket);
				base.transform.rotation = GetSnappedWorldRotationFor(socket);
			}
		}
		else
		{
			for (float phase = 0f; phase < 1f; phase += Time.deltaTime * (1f / duration))
			{
				if (!reparentToSocket && socket == null)
				{
					State = PluggableState.Free;
					EnableStandaloneComponents();
					EnableColliders();
					this.PluggingAbort?.Invoke(this, socket);
					yield break;
				}
				Vector3 b = (reparentToSocket ? positionOffset : GetSnappedWorldPositionFor(socket));
				Quaternion b2 = (reparentToSocket ? rotationOffset : GetSnappedWorldRotationFor(socket));
				float t = Mathf.SmoothStep(0f, 1f, Mathf.Clamp01(phase));
				if (reparentToSocket)
				{
					base.transform.localPosition = Vector3.Lerp(startingPosition, b, t);
					base.transform.localRotation = Quaternion.Lerp(startingRotation, b2, t);
				}
				else
				{
					base.transform.position = Vector3.Lerp(startingPosition, b, t);
					base.transform.rotation = Quaternion.Lerp(startingRotation, b2, t);
				}
				yield return null;
			}
		}
		State = PluggableState.PluggedIn;
		socket.NotifyPlugged(this, playSound);
		EnableColliders();
		HandleConnect(socket);
		this.PluggedIn?.Invoke(this, socket);
	}

	private void Update()
	{
		if (controlGrabbed)
		{
			notHeldFrames = 0;
		}
		else
		{
			notHeldFrames++;
		}
		if (allowUseToPlug && interactionHandler != null && !interactionHandler.IsHoldingLocked && controlGrabbed && ScanForHit() && (bool)targetedSocket && targetedSocket.CanAccept(this) && CanPlugInto(targetedSocket))
		{
			SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(InteractionInfoType.PlugIn);
		}
	}

	private bool ScanForHit()
	{
		int num = Physics.RaycastNonAlloc(nonVrGrabber.Cursor.GetRay(), raycastCache, 2f, socketLayerMask, QueryTriggerInteraction.Collide);
		RaycastUtils.ExtendOnCacheFull(ref raycastCache, num);
		targetedSocket = null;
		for (int i = 0; i < num; i++)
		{
			if (raycastCache[i].collider.CompareTag("PlugSocket"))
			{
				PlugSocket component = raycastCache[i].collider.GetComponent<PlugSocket>();
				if ((bool)component && component.CanAccept(this))
				{
					targetedSocket = component;
					return true;
				}
			}
		}
		return false;
	}

	private void OnUsePlugIn()
	{
		if (allowUseToPlug && State == PluggableState.Free && controlBase != null && targetedSocket != null)
		{
			StartSnappingTo(targetedSocket, itemUseInitiated: true);
		}
	}

	public void Unplug()
	{
		if (!(Socket == null) && State != PluggableState.Free)
		{
			VRTK_InteractableObject component = GetComponent<VRTK_InteractableObject>();
			if ((bool)component)
			{
				component.GetPreviousState(out var previousParent, out var _, out var previousGrabbable);
				component.OverridePreviousState(previousParent, previousKinematic: false, previousGrabbable);
			}
			PlugSocket socket = Socket;
			State = PluggableState.Free;
			StopAllCoroutines();
			if (Socket != null)
			{
				Socket.NotifyUnplugged(this);
				Socket = null;
			}
			EnableColliders();
			EnableStandaloneComponents();
			HandleDisconnect(socket);
			this.Unplugged?.Invoke(this, socket);
		}
	}

	private void LateUpdate()
	{
		if (State == PluggableState.PluggedIn && Socket != null && !reparentToSocket)
		{
			base.transform.position = virtualParent.TransformPoint(positionOffset);
			base.transform.rotation = virtualParent.rotation * rotationOffset;
		}
	}

	protected virtual void DisableColliders()
	{
		if (allColliders != null)
		{
			for (int i = 0; i < allColliders.Length; i++)
			{
				allColliders[i].enabled = false;
			}
		}
	}

	protected virtual void EnableColliders()
	{
		if (allColliders != null)
		{
			for (int i = 0; i < allColliders.Length; i++)
			{
				allColliders[i].enabled = true;
			}
		}
	}

	protected virtual void DisableStandaloneComponents()
	{
		if (allRigidBodies != null)
		{
			for (int i = 0; i < allRigidBodies.Length; i++)
			{
				allRigidBodies[i].isKinematic = true;
			}
		}
	}

	protected virtual void EnableStandaloneComponents()
	{
		if (allRigidBodies != null && !controlGrabbed)
		{
			for (int i = 0; i < allRigidBodies.Length; i++)
			{
				allRigidBodies[i].isKinematic = false;
			}
		}
	}

	protected virtual bool CanPlugInto(PlugSocket socket)
	{
		if ((controlBase == null || allowHandsFreePlugging || notHeldFrames <= 1) && State == PluggableState.Free && socket != null)
		{
			return socket.connectionTag == connectionTag;
		}
		return false;
	}

	public Vector3 GetSnappedWorldPositionFor(PlugSocket socket)
	{
		Transform obj = ((socket.plugMarker != null) ? socket.plugMarker.transform : socket.transform);
		Vector3 position = ((connectionPoint != null) ? (-connectionPoint.localPosition) : Vector3.zero);
		return obj.TransformPoint(position);
	}

	public Quaternion GetSnappedWorldRotationFor(PlugSocket socket)
	{
		Transform obj = ((socket.plugMarker != null) ? socket.plugMarker.transform : socket.transform);
		Quaternion quaternion = ((connectionPoint != null) ? Quaternion.Inverse(connectionPoint.localRotation) : Quaternion.identity);
		return obj.rotation * quaternion;
	}

	protected virtual void HandleConnect(PlugSocket socket)
	{
	}

	protected virtual void HandleDisconnect(PlugSocket socket)
	{
	}
}
