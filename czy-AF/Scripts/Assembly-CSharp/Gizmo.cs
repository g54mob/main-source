using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Gizmo : MonoBehaviour
{
	public bool local = true;

	public Plane plane;

	public Transform handleHover;

	public Transform handleDrag;

	private Bounds selectionBounds;

	private Vector3 initialPosition;

	private Vector3 initialScale;

	private Vector3 initialScaleParent;

	private Vector3 handleDirection;

	private Vector3 handleDirectionAbsolute;

	private Vector3 handleDirectionStatic;

	private Vector3 positionOrigin;

	private Vector3 mousePositionOrigin;

	private Vector3 screenSpaceOrigin;

	private Vector3 planeOrigin;

	private Vector3 targetPosition;

	private List<Vector3> initialScales = new List<Vector3>();

	private Quaternion initialRotation;

	private string handleType;

	[Header("Groups")]
	public GameObject groupPosition;

	public GameObject groupRotation;

	[Header("Components")]
	public Transform gizmoArrow;

	public Transform gizmoOrigin;

	public Transform gizmoRingX;

	public Transform gizmoRingY;

	public Transform gizmoRingZ;

	public static GameObject gizmoParent;

	public static Transform layers;

	public static Transform selection;

	public static Gizmo instance { get; private set; }

	private void Start()
	{
		if (instance == null)
		{
			instance = this;
		}
		plane = new Plane(Vector3.forward, base.transform.position);
		selection = Global.elements["selection"];
		GizmoToggle(showRotation: false);
		gizmoParent = new GameObject("gizmoTarget");
	}

	private void Update()
	{
		if (Selection.list.Count > 0)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			int mask = LayerMask.GetMask("Gizmo");
			if (Physics.Raycast(ray, out var hitInfo, 1000f, mask))
			{
				if (!Input.GetMouseButton(0))
				{
					SetColor(handleHover);
					handleHover = hitInfo.transform;
					SetColor(handleHover, selected: true);
				}
				if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
				{
					handleDrag = hitInfo.transform;
					handleDirection = Vector3.zero;
					handleDirectionStatic = Vector3.zero;
					if (hitInfo.transform.name.Contains("x"))
					{
						handleDirection = base.transform.right;
						plane.SetNormalAndPosition(base.transform.forward, base.transform.position);
					}
					if (hitInfo.transform.name.Contains("y"))
					{
						handleDirection = base.transform.up;
						plane.SetNormalAndPosition(base.transform.right, base.transform.position);
					}
					if (hitInfo.transform.name.Contains("z"))
					{
						handleDirection = base.transform.forward;
						plane.SetNormalAndPosition(base.transform.up, base.transform.position);
					}
					if (hitInfo.transform.name.Contains("x"))
					{
						handleDirectionStatic = Vector3.right;
					}
					if (hitInfo.transform.name.Contains("y"))
					{
						handleDirectionStatic = Vector3.up;
					}
					if (hitInfo.transform.name.Contains("z"))
					{
						handleDirectionStatic = Vector3.forward;
					}
					if (hitInfo.transform.name.Contains("-"))
					{
						handleDirection = -handleDirection;
						handleDirectionStatic = -handleDirectionStatic;
					}
					handleDirectionAbsolute = new Vector3(Mathf.Abs(handleDirection.x), Mathf.Abs(handleDirection.y), Mathf.Abs(handleDirection.z));
					planeOrigin = PlaneRaycast();
					initialPosition = selection.position;
					initialRotation = selection.localRotation;
					initialScale = selection.localScale;
					selectionBounds = Global.GetBounds(selection.gameObject);
					initialScales.Clear();
					foreach (Transform item in Selection.list)
					{
						initialScales.Add(item.localScale);
					}
					if (hitInfo.transform.name.Contains("move"))
					{
						handleType = "move";
					}
					if (hitInfo.transform.name.Contains("plane"))
					{
						handleType = "plane";
					}
					if (hitInfo.transform.name.Contains("scale"))
					{
						handleType = "scale";
					}
					if (hitInfo.transform.name.Contains("rotate"))
					{
						handleType = "rotate";
					}
					if (hitInfo.transform.name.Contains("rotate"))
					{
						gizmoOrigin.LookAt(planeOrigin, base.transform.up);
						gizmoOrigin.gameObject.SetActive(value: true);
						gizmoArrow.gameObject.SetActive(value: true);
					}
					layers = selection.parent;
					targetPosition = selectionBounds.center + Vector3.Scale(selectionBounds.extents, handleDirection);
					if (handleDirectionAbsolute == base.transform.up)
					{
						targetPosition = selectionBounds.center - Vector3.Scale(selectionBounds.extents, handleDirection);
					}
					gizmoParent.transform.position = targetPosition;
					initialScaleParent = gizmoParent.transform.localScale;
					selection.parent = gizmoParent.transform;
				}
			}
			else if (!Input.GetMouseButton(0))
			{
				SetColor(handleHover);
				handleHover = null;
			}
			if (!Input.GetMouseButton(0) && handleDrag != null)
			{
				handleDrag = null;
				gizmoOrigin.gameObject.SetActive(value: false);
				gizmoArrow.gameObject.SetActive(value: false);
				selection.parent = layers;
				gizmoParent.transform.localScale = Vector3.one;
				Undo.AddState();
				Selection.Update();
			}
			if (handleDrag != null)
			{
				Vector3 vector = PlaneRaycast();
				Vector3 vector2 = vector - planeOrigin;
				Vector3 vector3 = Global.RoundVector(vector2, Control.GetGrid());
				float num = Vector3.Dot(vector2, handleDirection);
				float amount = Control.GetGrid() * Mathf.Round(num / Control.GetGrid());
				switch (handleType)
				{
				case "move":
					PositionSelection(initialPosition, handleDirection, amount);
					WidgetText(amount.ToString("F2"));
					break;
				case "plane":
					WidgetText(vector3);
					if (Hotkey.GetKey("Modifier/Shift"))
					{
						Vector3 vector4 = new Vector3(Mathf.Abs(vector2.x), Mathf.Abs(vector2.y), Mathf.Abs(vector2.z));
						if (vector4.x > vector4.y && vector4.x > vector4.z)
						{
							vector2.y = 0f;
							vector2.z = 0f;
							WidgetText(vector3.x.ToString("F1"));
						}
						if (vector4.y > vector4.x && vector4.y > vector4.z)
						{
							vector2.x = 0f;
							vector2.z = 0f;
							WidgetText(vector3.y.ToString("F1"));
						}
						if (vector4.z > vector4.x && vector4.z > vector4.y)
						{
							vector2.x = 0f;
							vector2.y = 0f;
							WidgetText(vector3.z.ToString("F1"));
						}
					}
					PositionSelection(initialPosition, vector2, plane.normal);
					break;
				case "rotate":
				{
					float num3 = Vector3.SignedAngle(planeOrigin - base.transform.position, vector - base.transform.position, plane.normal);
					num3 = Mathf.Round(num3 / Control.gridRotate) * Control.gridRotate;
					gizmoArrow.LookAt(planeOrigin, base.transform.up);
					gizmoArrow.Rotate(plane.normal, num3, Space.World);
					RotateSelection(initialRotation, plane.normal, num3);
					WidgetText(num3.ToString("F0") + "°");
					break;
				}
				case "scale":
				{
					float num2 = 0f - Vector3.Dot(handleDirection, vector3);
					if (handleDirectionAbsolute == base.transform.up)
					{
						num2 = 0f - num2;
					}
					if (!Hotkey.GetKey("Modifier/Shift"))
					{
						if (Hotkey.GetKey("Modifier/Control"))
						{
							ScaleSelectionParent(initialScaleParent, Vector3.zero, 0f);
							ScaleSelectionUniform(initialScale, new Vector3(num2, num2, num2));
						}
						else
						{
							ScaleSelectionParent(initialScaleParent, handleDirectionAbsolute, num2);
							ScaleSelection(initialScale, Vector3.zero, 0f);
						}
					}
					else
					{
						ScaleSelectionParent(initialScaleParent, Vector3.zero, 0f);
						ScaleSelection(initialScale, handleDirectionAbsolute, num2);
					}
					WidgetText(num2.ToString("F1"));
					Control.UpdateScale();
					break;
				}
				}
				GizmoScaling();
			}
			Vector3 rhs = Camera.main.transform.position - base.transform.position;
			Vector3 normalized = Vector3.Cross(base.transform.forward, rhs).normalized;
			gizmoRingX.rotation = Quaternion.LookRotation(normalized, base.transform.forward);
			Vector3 normalized2 = Vector3.Cross(base.transform.right, rhs).normalized;
			gizmoRingY.rotation = Quaternion.LookRotation(normalized2, base.transform.right);
			Vector3 normalized3 = Vector3.Cross(base.transform.up, rhs).normalized;
			gizmoRingZ.rotation = Quaternion.LookRotation(normalized3, base.transform.up);
		}
		if (handleDrag == null)
		{
			Global.elements["widget"].gameObject.SetActive(value: false);
		}
		else
		{
			Global.elements["widget"].gameObject.SetActive(value: true);
			Global.elements["widget"].position = Global.RoundVector(Camera.main.WorldToScreenPoint(handleDrag.position), 1f);
		}
		GizmoToggle(Hotkey.GetKey("Gizmo/Rotate"));
	}

	public void Enable()
	{
		Global.SetLayerRecursively(base.transform, 9);
	}

	public void Disable()
	{
		Global.SetLayerRecursively(base.transform, 10);
	}

	public void GizmoToggle(bool showRotation)
	{
		groupPosition.SetActive(!showRotation);
		groupRotation.SetActive(showRotation);
	}

	public void GizmoScaling()
	{
		Vector2 vector = new Vector2(Screen.width, Screen.height);
		float num = Mathf.Min(vector.x / 1280f, vector.y / 720f) / Preferences.data.visualsScale;
		float num2 = Vector3.Distance(base.transform.position, Camera.main.transform.position);
		if (Camera.main.orthographic)
		{
			num2 = Camera.main.orthographicSize * 2.25f;
		}
		float num3 = num2 / (8f / Preferences.data.gizmoScale);
		base.transform.localScale = new Vector3(num3 / num, num3 / num, num3 / num);
	}

	public void SetGizmoPosition()
	{
		base.transform.position = Global.GetBounds(Selection.list).center;
	}

	public void SetColor(Transform g, bool selected = false)
	{
		if (g == null)
		{
			return;
		}
		Material[] materials = g.GetComponent<Renderer>().materials;
		foreach (Material material in materials)
		{
			if (!material.name.Contains("transparent"))
			{
				Color color = default(Color);
				if (material.name.Contains("x"))
				{
					color = color.Hex("#EC3B5A");
				}
				if (material.name.Contains("y"))
				{
					color = color.Hex("#F39C12");
				}
				if (material.name.Contains("z"))
				{
					color = color.Hex("#7F67EE");
				}
				if (selected)
				{
					color = color.Hex("#FFFFFF");
				}
				material.SetColor("_Color", color);
			}
		}
	}

	public void WidgetText(string s)
	{
		Global.elements["widget"].GetChild(0).GetChild(0).GetComponent<Text>()
			.text = s;
	}

	public void WidgetText(Vector3 s)
	{
		WidgetText(string.Format("{0} × {1} × {2}", s.x.ToString("F1"), s.y.ToString("F1"), s.z.ToString("F1")));
	}

	public static Vector3 PositionSelection(Vector3 initialPosition, Vector3 direction, float amount)
	{
		selection.position = initialPosition + direction * amount;
		instance.SetGizmoPosition();
		return selection.position;
	}

	public static Vector3 PositionSelection(Vector3 initialPosition, Vector3 vector, Vector3 axis)
	{
		vector = Global.RoundVector(vector, Control.GetGrid());
		vector = Vector3.ProjectOnPlane(vector, -axis);
		selection.position = initialPosition + vector;
		instance.SetGizmoPosition();
		return selection.position;
	}

	public static Vector3 ScaleSelection(Vector3 initialScale, Vector3 direction, float amount)
	{
		selection.localScale = initialScale + direction * amount;
		return selection.localScale;
	}

	public static Vector3 ScaleSelection(Vector3 _pivot, List<Vector3> _initialScales, Vector3 direction, float amount)
	{
		for (int i = 0; i < Selection.list.Count; i++)
		{
			Quaternion rotation = Selection.list[i].rotation;
			Selection.list[i].rotation = Quaternion.identity;
			SetScaleFrom(Selection.list[i], _pivot, _initialScales[i] + direction * amount);
			Selection.list[i].rotation = rotation;
		}
		return selection.localScale;
	}

	public static Vector3 ScaleSelectionUniform(Vector3 initialScale, Vector3 setScale)
	{
		selection.localScale = initialScale + setScale;
		if (selection.localScale == Vector3.zero)
		{
			selection.localScale = new Vector3(0.01f, 0.01f, 0.01f);
		}
		return selection.localScale;
	}

	public static Vector3 ScaleSelectionParent(Vector3 initialScale, Vector3 direction, float amount)
	{
		gizmoParent.transform.localScale = initialScale + direction * amount;
		return gizmoParent.transform.localScale;
	}

	public static Vector3 RotateSelection(Quaternion initialRotation, Vector3 direction, float amount)
	{
		selection.rotation = initialRotation;
		selection.Rotate(direction, amount, Space.World);
		return selection.eulerAngles;
	}

	public Vector3 PlaneRaycast()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector3 result = Vector3.zero;
		float enter = 0f;
		if (plane.Raycast(ray, out enter))
		{
			result = ray.GetPoint(enter);
		}
		return result;
	}

	public static void ScaleAround(GameObject target, Vector3 pivot, Vector3 newScale)
	{
		Vector3 vector = target.transform.position - pivot;
		Vector3 scale = new Vector3(newScale.x / target.transform.localScale.x, newScale.y / target.transform.localScale.y, newScale.z / target.transform.localScale.z);
		vector.Scale(scale);
		target.transform.position = pivot + vector;
		target.transform.localScale = newScale;
	}

	public static void SetScaleFrom(Transform _target, Vector3 worldPivot, Vector3 newScale)
	{
		Vector3 vector = _target.InverseTransformPoint(worldPivot);
		Vector3 localScale = _target.localScale;
		Vector3 b = new Vector3(ExtMathf.SafeDivide(newScale.x, localScale.x), ExtMathf.SafeDivide(newScale.y, localScale.y), ExtMathf.SafeDivide(newScale.z, localScale.z));
		Vector3 vector2 = Vector3.Scale(vector, b);
		Vector3 position = _target.TransformPoint(vector - vector2);
		_target.localScale = newScale;
		_target.position = position;
	}
}
