using DV.CabControls;
using UnityEngine;
using VerletRope;

public class CouplingHoseConnector : MonoBehaviour
{
	private const float DROP_CONNECTOR_MAX_DISTANCE_SQ = 2.25f;

	public RopeBehaviour rope;

	public Transform visualConnector;

	private CouplingHoseRig rig;

	private Rigidbody rb;

	private GizmoBase gizmo;

	private TelegrabbableGizmo telegrabbable;

	private HoseAudioBase hoseAudio;

	private bool isGizmoBeingDragged;

	private void Start()
	{
		gizmo = GetComponent<GizmoBase>();
		telegrabbable = GetComponent<TelegrabbableGizmo>();
		rb = GetComponent<Rigidbody>();
		gizmo.Grabbed += OnGrabbed;
		gizmo.Ungrabbed += OnUngrabbed;
		telegrabbable.IsBeingTelegrabbedChanged.Register(OnTelegrabAttract);
	}

	private void OnDisable()
	{
		isGizmoBeingDragged = false;
	}

	public void OnTakenFromPool(CouplingHoseRig rig)
	{
		this.rig = rig;
		hoseAudio = rig.GetComponent<HoseAudioBase>();
		if (hoseAudio != null)
		{
			hoseAudio.connector = visualConnector;
		}
	}

	public void OnAboutToReturnToPool()
	{
		if (hoseAudio != null)
		{
			hoseAudio.connector = null;
		}
		hoseAudio = null;
	}

	private void OnTriggerEnter(Collider other)
	{
		CouplingHoseConnector component = other.GetComponent<CouplingHoseConnector>();
		if ((bool)component && !(rig.adapter.GetType() != component.rig.adapter.GetType()) && !(GetMaster(this, component) != this) && (bool)gizmo && (bool)component.gizmo && (gizmo.IsGrabbed() || component.gizmo.IsGrabbed()))
		{
			gizmo.ForceEndInteraction();
			component.gizmo.ForceEndInteraction();
			rig.RequestConnect(component.rig);
		}
	}

	private void OnGrabbed(ControlImplBase _ = null)
	{
		TogglePins(active: true);
		isGizmoBeingDragged = true;
	}

	private void OnUngrabbed(ControlImplBase _ = null)
	{
		TogglePins(active: false);
		isGizmoBeingDragged = false;
	}

	private void OnTelegrabAttract(bool isBeingTelegrabbed)
	{
		if (isBeingTelegrabbed)
		{
			OnGrabbed();
		}
	}

	private void TogglePins(bool active)
	{
		Pin value = rope.pins[2];
		value.active = active;
		rope.pins[2] = value;
	}

	public static CouplingHoseConnector GetMaster(CouplingHoseConnector a, CouplingHoseConnector b)
	{
		if (!(CouplingHoseConnectionManager.GetMaster(a.rig, b.rig) == a.rig))
		{
			return b;
		}
		return a;
	}

	public bool IsWithinGrabbableDistance(Vector3 position)
	{
		return (rig.ropeAnchor.position - position).sqrMagnitude < 2.25f;
	}

	private void Update()
	{
		if (isGizmoBeingDragged)
		{
			if (!IsWithinGrabbableDistance(base.transform.position))
			{
				gizmo.ForceEndInteraction();
			}
		}
		else
		{
			rb.isKinematic = true;
			base.transform.position = visualConnector.position;
		}
	}
}
