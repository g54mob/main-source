using System.Collections;
using DV.CabControls;
using UnityEngine;

[RequireComponent(typeof(CouplingHoseConnector))]
public class CouplingHoseConnectorDragAligner : MonoBehaviour
{
	private const float SEARCH_RADIUS = 1.2f;

	private const float MIN_DIST_FROM_CAMERA = 0.3f;

	private const float MAX_DIST_FROM_CAMERA = 1.7f;

	private static int _layerMask;

	private GizmoBase gizmo;

	private CouplingHoseConnector connector;

	private Vector3? targetPos;

	private Vector3 finalTargetPos;

	private Vector3 smoothDampRefVel;

	private static int layerMask
	{
		get
		{
			if (_layerMask == 0)
			{
				_layerMask = 1 << LayerMask.NameToLayer("Interactable");
			}
			return _layerMask;
		}
	}

	private void Awake()
	{
		if (VRManager.IsVREnabled())
		{
			Object.Destroy(this);
		}
	}

	private IEnumerator Start()
	{
		for (int safety = 0; safety < 10; safety++)
		{
			if (!gizmo)
			{
				gizmo = GetComponent<GizmoBase>();
			}
			if (!connector)
			{
				connector = GetComponent<CouplingHoseConnector>();
			}
			if ((bool)gizmo && (bool)connector)
			{
				break;
			}
			yield return null;
		}
		if (!gizmo || !connector)
		{
			Debug.LogError("CouplingHoseConnectorDragAligner couldn't find required components, destroying self", this);
			Object.Destroy(this);
		}
		else
		{
			gizmo.Grabbed += OnGrabbed;
			gizmo.Ungrabbed += OnUngrabbed;
			base.enabled = false;
		}
	}

	private void OnEnable()
	{
		StartCoroutine(Align());
	}

	private void OnDisable()
	{
		StopAllCoroutines();
		targetPos = null;
	}

	private void OnDestroy()
	{
		if ((bool)gizmo)
		{
			gizmo.Grabbed -= OnGrabbed;
			gizmo.Ungrabbed -= OnUngrabbed;
		}
	}

	private void OnGrabbed(ControlImplBase _)
	{
		base.enabled = true;
	}

	private void OnUngrabbed(ControlImplBase _)
	{
		base.enabled = false;
	}

	private IEnumerator Align()
	{
		WaitForSeconds wait = WaitFor.Seconds(0.1f);
		while (true)
		{
			yield return wait;
			targetPos = null;
			Camera playerCamera = PlayerManager.PlayerCamera;
			if (!gizmo || !gizmo.IsGrabbed() || !playerCamera)
			{
				break;
			}
			CouplingHoseConnector couplingHoseConnector = CouplingAttachPoint.FindClosest(gizmo.transform.position, layerMask, 1.2f, connector);
			if ((bool)couplingHoseConnector)
			{
				targetPos = playerCamera.transform.TransformPoint(Vector3.Project(playerCamera.transform.InverseTransformPoint(couplingHoseConnector.transform.position), Vector3.forward));
			}
			else
			{
				targetPos = null;
			}
		}
		base.enabled = false;
	}

	private void Update()
	{
		if (targetPos.HasValue)
		{
			Transform transform = PlayerManager.PlayerCamera.transform;
			Vector3 rhs = targetPos.Value - transform.position;
			float num = Vector3.Dot(transform.forward, rhs);
			if (num < 0.3f)
			{
				finalTargetPos = transform.position + transform.forward * 0.3f;
			}
			else if (num > 1.7f)
			{
				finalTargetPos = transform.position + transform.forward * 1.7f;
			}
			else
			{
				finalTargetPos = targetPos.Value;
			}
			base.transform.position = Vector3.SmoothDamp(base.transform.position, finalTargetPos, ref smoothDampRefVel, 0.3f);
		}
	}
}
