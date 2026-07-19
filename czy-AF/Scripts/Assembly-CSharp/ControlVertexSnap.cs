using UnityEngine;
using UnityEngine.EventSystems;

public class ControlVertexSnap : MonoBehaviour
{
	private int step;

	private bool snapping;

	private Vector3 initialSelectionPosition;

	private Vector3 vertexFrom;

	private Vector3 vertexTo;

	private Vector3 vertexOffset;

	private LayerMask mask;

	private LayerMask maskSelected;

	public Transform vertexDisplay;

	public static ControlVertexSnap instance { get; private set; }

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		mask = LayerMask.GetMask("Default");
		maskSelected = LayerMask.GetMask("Selected");
	}

	public void Enable()
	{
		Gizmo.instance.Disable();
		Selection.Disable();
	}

	public void Disable()
	{
		step = 0;
		snapping = false;
		vertexDisplay.gameObject.SetActive(value: false);
		if (Gizmo.instance != null)
		{
			Gizmo.instance.Enable();
			Selection.Update();
			Selection.Enable();
		}
	}

	public void Snap()
	{
		if (Hotkey.GetKeyDown("Edit/Vertex Snap") && !Hotkey.GetKey("Modifier/Control") && !Hotkey.GetKey("Modifier/Shift"))
		{
			snapping = !snapping;
			if (Selection.list.Count == 0)
			{
				snapping = false;
			}
			if (snapping)
			{
				Enable();
			}
			if (!snapping)
			{
				Disable();
			}
		}
		if (!snapping)
		{
			return;
		}
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		switch (step)
		{
		case 0:
			if (Physics.SphereCast(ray, 0.05f, out hitInfo, float.PositiveInfinity, maskSelected))
			{
				vertexDisplay.gameObject.SetActive(value: true);
				vertexDisplay.position = GetClosestVertex(hitInfo);
				if (Input.GetMouseButtonDown(0))
				{
					vertexFrom = GetClosestVertex(hitInfo);
					initialSelectionPosition = Global.elements["selection"].position;
					vertexOffset = initialSelectionPosition - vertexFrom;
					step = 1;
				}
			}
			else
			{
				vertexDisplay.gameObject.SetActive(value: false);
			}
			break;
		case 1:
			if (Physics.SphereCast(ray, 0.05f, out hitInfo, float.PositiveInfinity, mask) && (bool)hitInfo.transform.GetComponent<BlockComponent>())
			{
				vertexDisplay.gameObject.SetActive(value: true);
				vertexDisplay.position = GetClosestVertex(hitInfo);
				vertexTo = GetClosestVertex(hitInfo);
				Global.elements["selection"].position = vertexTo + vertexOffset;
			}
			else
			{
				Global.elements["selection"].position = initialSelectionPosition;
				vertexDisplay.gameObject.SetActive(value: false);
			}
			if (Input.GetMouseButtonDown(0))
			{
				Undo.AddState();
				Disable();
			}
			break;
		}
		if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject())
		{
			Disable();
		}
	}

	public static Vector3 GetClosestVertex(RaycastHit _hit)
	{
		Mesh mesh = _hit.transform.GetComponent<MeshFilter>().mesh;
		Vector3 vector = _hit.transform.InverseTransformPoint(_hit.point);
		float num = float.PositiveInfinity;
		Vector3 position = Vector3.zero;
		Vector3[] vertices = mesh.vertices;
		foreach (Vector3 vector2 in vertices)
		{
			float sqrMagnitude = (vector - vector2).sqrMagnitude;
			if (sqrMagnitude < num)
			{
				num = sqrMagnitude;
				position = vector2;
			}
		}
		return _hit.transform.TransformPoint(position);
	}
}
