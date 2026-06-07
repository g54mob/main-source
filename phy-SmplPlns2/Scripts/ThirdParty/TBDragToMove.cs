using UnityEngine;

[AddComponentMenu("FingerGestures/Toolbox/Drag To Move")]
public class TBDragToMove : MonoBehaviour
{
	public enum DragPlaneType
	{
		Camera = 0,
		UseCollider = 1
	}

	public Collider DragPlaneCollider;

	public float DragPlaneOffset;

	public Camera RaycastCamera;

	public bool DragFromObjectCenter;

	private bool dragging;

	private FingerGestures.Finger draggingFinger;

	private GestureRecognizer gestureRecognizer;

	private bool oldUseGravity;

	private bool oldIsKinematic;

	private Vector3 physxDragMove = Vector3.zero;

	public bool Dragging
	{
		get
		{
			return dragging;
		}
		private set
		{
			if (dragging == value)
			{
				return;
			}
			dragging = value;
			if ((bool)GetComponent<Rigidbody>())
			{
				if (dragging)
				{
					oldUseGravity = GetComponent<Rigidbody>().useGravity;
					oldIsKinematic = GetComponent<Rigidbody>().isKinematic;
					GetComponent<Rigidbody>().useGravity = false;
					GetComponent<Rigidbody>().isKinematic = true;
				}
				else
				{
					GetComponent<Rigidbody>().isKinematic = oldIsKinematic;
					GetComponent<Rigidbody>().useGravity = oldUseGravity;
					GetComponent<Rigidbody>().velocity = Vector3.zero;
				}
			}
		}
	}

	private void Start()
	{
		if (!RaycastCamera)
		{
			RaycastCamera = Camera.main;
		}
	}

	public bool ProjectScreenPointOnDragPlane(Vector3 refPos, Vector2 screenPos, out Vector3 worldPos)
	{
		worldPos = refPos;
		if ((bool)DragPlaneCollider)
		{
			Ray ray = RaycastCamera.ScreenPointToRay(screenPos);
			if (!DragPlaneCollider.Raycast(ray, out var hitInfo, float.MaxValue))
			{
				return false;
			}
			worldPos = hitInfo.point + DragPlaneOffset * hitInfo.normal;
		}
		else
		{
			Transform transform = RaycastCamera.transform;
			Plane plane = new Plane(-transform.forward, refPos);
			Ray ray2 = RaycastCamera.ScreenPointToRay(screenPos);
			float enter = 0f;
			if (!plane.Raycast(ray2, out enter))
			{
				return false;
			}
			worldPos = ray2.GetPoint(enter);
		}
		return true;
	}

	private void HandleDrag(DragGesture gesture)
	{
		if (!base.enabled)
		{
			return;
		}
		if (gesture.Phase == ContinuousGesturePhase.Started)
		{
			Dragging = true;
			draggingFinger = gesture.Fingers[0];
		}
		else
		{
			if (!Dragging || gesture.Fingers[0] != draggingFinger)
			{
				return;
			}
			if (gesture.Phase == ContinuousGesturePhase.Updated)
			{
				Transform transform = base.transform;
				Vector3 vector = Vector3.zero;
				Vector3 worldPos2;
				Vector3 worldPos3;
				if (DragFromObjectCenter)
				{
					if (ProjectScreenPointOnDragPlane(transform.position, draggingFinger.Position, out var worldPos))
					{
						vector = worldPos - transform.position;
					}
				}
				else if (ProjectScreenPointOnDragPlane(transform.position, draggingFinger.PreviousPosition, out worldPos2) && ProjectScreenPointOnDragPlane(transform.position, draggingFinger.Position, out worldPos3))
				{
					vector = worldPos3 - worldPos2;
				}
				if ((bool)GetComponent<Rigidbody>())
				{
					physxDragMove += vector;
				}
				else
				{
					transform.position += vector;
				}
			}
			else
			{
				Dragging = false;
			}
		}
	}

	private void FixedUpdate()
	{
		if (Dragging && (bool)GetComponent<Rigidbody>())
		{
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + physxDragMove);
			physxDragMove = Vector3.zero;
		}
	}

	private void OnDrag(DragGesture gesture)
	{
		HandleDrag(gesture);
	}

	private void OnDisable()
	{
		if (Dragging)
		{
			Dragging = false;
		}
	}
}
