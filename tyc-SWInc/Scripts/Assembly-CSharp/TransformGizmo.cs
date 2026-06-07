using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TransformGizmo : MonoBehaviour
{
	public enum Action
	{
		Move = 0,
		Rotate = 1,
		Scale = 2
	}

	public enum Axis
	{
		XAxis = 0,
		YAxis = 1,
		ZAxis = 2,
		None = 3
	}

	public Mesh Circle;

	public Mesh Arrow;

	public Mesh ScaleArrow;

	public Material Mat;

	public Camera Cam;

	public Action CurrentAction;

	public float Scale = 1f;

	[NonSerialized]
	private Material _red;

	[NonSerialized]
	private Material _green;

	[NonSerialized]
	private Material _blue;

	[NonSerialized]
	private Material _yellow;

	[NonSerialized]
	private Ray _initialDrag;

	private Vector3 _initalDragPos;

	private Vector3 _initalPos;

	private Vector3 _initialScale;

	private Vector3 _initalDragRef;

	private float _initialScreenAngle;

	private Quaternion _initalRot;

	private bool _isDragging;

	private Axis _activeAxis = Axis.None;

	[NonSerialized]
	public System.Action OnFinishChange;

	public bool Global;

	public bool Pivot = true;

	private Vector3 _centerOffset;

	public bool IsDragging
	{
		get
		{
			return _isDragging;
		}
	}

	public void InitOffsets()
	{
		_centerOffset = Vector3.zero;
		MeshFilter component = GetComponent<MeshFilter>();
		if (component != null && component.sharedMesh != null)
		{
			_centerOffset = component.sharedMesh.bounds.center;
			return;
		}
		SkinnedMeshRenderer component2 = GetComponent<SkinnedMeshRenderer>();
		if (component2 != null)
		{
			_centerOffset = component2.sharedMesh.bounds.center;
		}
	}

	private void Start()
	{
		_red = new Material(Mat);
		_red.color = Color.red;
		_green = new Material(Mat);
		_green.color = Color.green;
		_blue = new Material(Mat);
		_blue.color = Color.blue;
		_yellow = new Material(Mat);
		_yellow.color = Color.yellow;
		if (Cam == null)
		{
			Cam = Camera.main;
		}
		InitOffsets();
	}

	public Vector3 GetPosition()
	{
		if (!Pivot)
		{
			return base.transform.position + base.transform.localRotation * Vector3.Scale(_centerOffset, base.transform.localScale);
		}
		return base.transform.position;
	}

	private Axis GetActiveAxis(bool forceLocal = false)
	{
		Ray ray = new Ray(GetPosition(), (Global && !forceLocal) ? Vector3.forward : base.transform.forward);
		Ray ray2 = new Ray(GetPosition(), (Global && !forceLocal) ? Vector3.right : base.transform.right);
		Ray ray3 = new Ray(GetPosition(), (Global && !forceLocal) ? Vector3.up : base.transform.up);
		Ray mouse = Cam.ScreenPointToRay(Input.mousePosition);
		float num = float.MaxValue;
		Axis result = Axis.None;
		Vector3 p;
		Vector3 pr;
		if (GetClosestPoint(ray, ray3, ray2, mouse, out p, out pr) && (p - pr).magnitude < 0.1f * Scale && (GetPosition() - pr).magnitude < Scale && ray.direction == (pr - ray.origin).normalized)
		{
			num = (pr - Cam.transform.position).sqrMagnitude;
			result = Axis.ZAxis;
		}
		if (GetClosestPoint(ray2, ray, ray3, mouse, out p, out pr) && (p - pr).magnitude < 0.1f * Scale && (GetPosition() - pr).magnitude < Scale && ray2.direction == (pr - ray2.origin).normalized)
		{
			float sqrMagnitude = (pr - Cam.transform.position).sqrMagnitude;
			if (sqrMagnitude < num)
			{
				num = sqrMagnitude;
				result = Axis.XAxis;
			}
		}
		if (GetClosestPoint(ray3, ray2, ray, mouse, out p, out pr) && (p - pr).magnitude < 0.1f * Scale && (GetPosition() - pr).magnitude < Scale && ray3.direction == (pr - ray3.origin).normalized)
		{
			float sqrMagnitude2 = (pr - Cam.transform.position).sqrMagnitude;
			if (sqrMagnitude2 < num)
			{
				num = sqrMagnitude2;
				result = Axis.YAxis;
			}
		}
		return result;
	}

	private Axis GetActiveRotAxis()
	{
		Ray mouse = Cam.ScreenPointToRay(Input.mousePosition);
		float num = float.MaxValue;
		Axis result = Axis.None;
		Vector3 pr;
		if (CheckRotAxis(Global ? Vector3.forward : base.transform.forward, mouse, out pr))
		{
			num = (pr - Cam.transform.position).sqrMagnitude;
			result = Axis.ZAxis;
		}
		if (CheckRotAxis(Global ? Vector3.right : base.transform.right, mouse, out pr))
		{
			float sqrMagnitude = (pr - Cam.transform.position).sqrMagnitude;
			if (sqrMagnitude < num)
			{
				num = sqrMagnitude;
				result = Axis.XAxis;
			}
		}
		if (CheckRotAxis(Global ? Vector3.up : base.transform.up, mouse, out pr))
		{
			float sqrMagnitude2 = (pr - Cam.transform.position).sqrMagnitude;
			if (sqrMagnitude2 < num)
			{
				num = sqrMagnitude2;
				result = Axis.YAxis;
			}
		}
		return result;
	}

	private bool CheckRotAxis(Vector3 dir, Ray mouse, out Vector3 pr)
	{
		Plane plane = new Plane(dir, GetPosition());
		pr = Vector3.zero;
		float enter;
		if (plane.Raycast(mouse, out enter))
		{
			pr = mouse.GetPoint(enter);
			float magnitude = (pr - GetPosition()).magnitude;
			if (magnitude > Scale * 0.9f && magnitude < Scale * 1.1f)
			{
				return true;
			}
		}
		return false;
	}

	public bool GetClosestPoint(Ray dir, Ray plane, Ray plane2, Ray mouse, out Vector3 p, out Vector3 pr)
	{
		if (GetClosestPoint(dir, plane, mouse, out p, out pr))
		{
			Vector3 p2;
			Vector3 pr2;
			if (GetClosestPoint(dir, plane2, mouse, out p2, out pr2) && (p2 - pr2).sqrMagnitude < (p - pr).sqrMagnitude)
			{
				p = p2;
				pr = pr2;
			}
			return true;
		}
		return GetClosestPoint(dir, plane2, mouse, out p, out pr);
	}

	public bool GetClosestPoint(Ray dir, Ray plane, Ray mouse, out Vector3 p, out Vector3 pr)
	{
		float enter;
		if (!new Plane(plane.direction, plane.origin).Raycast(mouse, out enter))
		{
			p = Vector3.zero;
			pr = Vector3.zero;
			return false;
		}
		p = mouse.GetPoint(enter);
		pr = Vector3.Project(p - dir.origin, dir.direction) + dir.origin;
		return true;
	}

	private Vector3 GetActiveDir(Axis a, bool forceGlobal = false)
	{
		switch (a)
		{
		case Axis.XAxis:
			if (!(Global || forceGlobal))
			{
				return base.transform.right;
			}
			return Vector3.right;
		case Axis.YAxis:
			if (!(Global || forceGlobal))
			{
				return base.transform.up;
			}
			return Vector3.up;
		case Axis.ZAxis:
			if (!(Global || forceGlobal))
			{
				return base.transform.forward;
			}
			return Vector3.forward;
		default:
			return Vector3.up;
		}
	}

	private Ray GetActiveRay(Axis a)
	{
		return new Ray(GetPosition(), GetActiveDir(a));
	}

	private Vector3? GetDragPos(Axis a, Vector3 origin, Quaternion r)
	{
		Ray dir = new Ray(Vector3.zero, Vector3.up);
		Ray plane = new Ray(Vector3.zero, Vector3.forward);
		Ray plane2 = new Ray(Vector3.zero, Vector3.forward);
		Ray mouse = Cam.ScreenPointToRay(Input.mousePosition);
		switch (a)
		{
		case Axis.XAxis:
			dir = new Ray(origin, r * Vector3.right);
			plane = new Ray(origin, r * Vector3.forward);
			plane2 = new Ray(origin, r * Vector3.up);
			break;
		case Axis.YAxis:
			dir = new Ray(origin, r * Vector3.up);
			plane = new Ray(origin, r * Vector3.right);
			plane2 = new Ray(origin, r * Vector3.forward);
			break;
		case Axis.ZAxis:
			dir = new Ray(origin, r * Vector3.forward);
			plane = new Ray(origin, r * Vector3.up);
			plane2 = new Ray(origin, r * Vector3.right);
			break;
		}
		Vector3 p;
		Vector3 pr;
		if (GetClosestPoint(dir, plane, mouse, out p, out pr))
		{
			return pr;
		}
		if (GetClosestPoint(dir, plane2, mouse, out p, out pr))
		{
			return pr;
		}
		return null;
	}

	private bool OverGUI()
	{
		return EventSystem.current.IsPointerOverGameObject();
	}

	private float GetScreenAngle()
	{
		Vector3 vector = Cam.WorldToScreenPoint(GetPosition());
		Vector3 mousePosition = Input.mousePosition;
		return Mathf.Atan2(vector.y - mousePosition.y, vector.x - mousePosition.x) * 57.29578f;
	}

	private void Update()
	{
		switch (CurrentAction)
		{
		case Action.Move:
		{
			Axis axis2 = (_isDragging ? _activeAxis : GetActiveAxis());
			Vector3 forward2 = (Global ? Vector3.forward : base.transform.forward);
			Vector3 forward3 = (Global ? Vector3.right : base.transform.right);
			Vector3 forward4 = (Global ? Vector3.up : base.transform.up);
			Graphics.DrawMesh(Arrow, Matrix4x4.TRS(GetPosition(), Quaternion.LookRotation(forward2), Vector3.one * Scale), (axis2 == Axis.ZAxis) ? _yellow : _blue, 0, Cam, 0, null, false, false);
			Graphics.DrawMesh(Arrow, Matrix4x4.TRS(GetPosition(), Quaternion.LookRotation(forward3), Vector3.one * Scale), (axis2 == Axis.XAxis) ? _yellow : _green, 0, Cam, 0, null, false, false);
			Graphics.DrawMesh(Arrow, Matrix4x4.TRS(GetPosition(), Quaternion.LookRotation(forward4), Vector3.one * Scale), (axis2 == Axis.YAxis) ? _yellow : _red, 0, Cam, 0, null, false, false);
			if (_isDragging)
			{
				if (Input.GetMouseButtonUp(0))
				{
					_isDragging = false;
					System.Action onFinishChange2 = OnFinishChange;
					if (onFinishChange2 != null)
					{
						onFinishChange2();
					}
				}
				else
				{
					Vector3? dragPos3 = GetDragPos(_activeAxis, _initalDragRef, _initalRot);
					if (dragPos3.HasValue)
					{
						base.transform.position = _initalPos + (dragPos3.Value - _initalDragPos);
					}
				}
			}
			else if (Input.GetMouseButtonDown(0) && axis2 != Axis.None && !OverGUI())
			{
				Vector3? dragPos4 = GetDragPos(axis2, GetPosition(), Global ? Quaternion.identity : base.transform.rotation);
				if (dragPos4.HasValue)
				{
					_isDragging = true;
					_activeAxis = axis2;
					_initalDragPos = dragPos4.Value;
					_initalPos = base.transform.position;
					_initalDragRef = GetPosition();
					_initalRot = (Global ? Quaternion.identity : base.transform.rotation);
				}
			}
			break;
		}
		case Action.Rotate:
		{
			Axis axis3 = (_isDragging ? _activeAxis : GetActiveRotAxis());
			Vector3 forward5 = (Global ? Vector3.forward : base.transform.forward);
			Vector3 forward6 = (Global ? Vector3.right : base.transform.right);
			Vector3 forward7 = (Global ? Vector3.up : base.transform.up);
			Graphics.DrawMesh(Circle, Matrix4x4.TRS(GetPosition(), Quaternion.LookRotation(forward5), Vector3.one * Scale), (axis3 == Axis.ZAxis) ? _yellow : _blue, 0, Cam, 0, null, false, false);
			Graphics.DrawMesh(Circle, Matrix4x4.TRS(GetPosition(), Quaternion.LookRotation(forward6), Vector3.one * Scale), (axis3 == Axis.XAxis) ? _yellow : _green, 0, Cam, 0, null, false, false);
			Graphics.DrawMesh(Circle, Matrix4x4.TRS(GetPosition(), Quaternion.LookRotation(forward7), Vector3.one * Scale), (axis3 == Axis.YAxis) ? _yellow : _red, 0, Cam, 0, null, false, false);
			if (_isDragging)
			{
				if (Input.GetMouseButtonUp(0))
				{
					_isDragging = false;
					System.Action onFinishChange3 = OnFinishChange;
					if (onFinishChange3 != null)
					{
						onFinishChange3();
					}
					break;
				}
				float num = _initialScreenAngle - GetScreenAngle();
				if (Pivot)
				{
					if (Global)
					{
						switch (_activeAxis)
						{
						case Axis.XAxis:
							base.transform.rotation = Quaternion.Euler(num, 0f, 0f) * _initalRot;
							break;
						case Axis.YAxis:
							base.transform.rotation = Quaternion.Euler(0f, num, 0f) * _initalRot;
							break;
						case Axis.ZAxis:
							base.transform.rotation = Quaternion.Euler(0f, 0f, num) * _initalRot;
							break;
						}
					}
					else
					{
						switch (_activeAxis)
						{
						case Axis.XAxis:
							base.transform.rotation = _initalRot * Quaternion.Euler(num, 0f, 0f);
							break;
						case Axis.YAxis:
							base.transform.rotation = _initalRot * Quaternion.Euler(0f, num, 0f);
							break;
						case Axis.ZAxis:
							base.transform.rotation = _initalRot * Quaternion.Euler(0f, 0f, num);
							break;
						}
					}
				}
				else
				{
					Matrix4x4 matrix4x = ((_activeAxis == Axis.XAxis) ? Matrix4x4.Rotate(Quaternion.Euler(num, 0f, 0f)) : ((_activeAxis != Axis.YAxis) ? Matrix4x4.Rotate(Quaternion.Euler(0f, 0f, num)) : Matrix4x4.Rotate(Quaternion.Euler(0f, num, 0f))));
					Vector3 vector2 = Vector3.Scale(_centerOffset, base.transform.localScale);
					Matrix4x4 matrix4x2;
					if (Global)
					{
						matrix4x2 = Matrix4x4.TRS(_initalPos, Quaternion.identity, Vector3.one);
						Matrix4x4 matrix4x3 = Matrix4x4.TRS(Vector3.zero, _initalRot, Vector3.one);
						vector2 = _initalRot * vector2;
						matrix4x2 = matrix4x2 * Matrix4x4.Translate(vector2) * matrix4x * Matrix4x4.Translate(-vector2) * matrix4x3;
					}
					else
					{
						matrix4x2 = Matrix4x4.TRS(_initalPos, _initalRot, Vector3.one);
						matrix4x2 = matrix4x2 * Matrix4x4.Translate(vector2) * matrix4x * Matrix4x4.Translate(-vector2);
					}
					Vector3 position;
					Quaternion rotation;
					Vector3 scale;
					matrix4x2.ExtractTRS(out position, out rotation, out scale);
					base.transform.position = position;
					base.transform.rotation = rotation;
				}
			}
			else if (Input.GetMouseButtonDown(0) && axis3 != Axis.None && !OverGUI())
			{
				Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
				float enter;
				if (new Plane(GetActiveDir(axis3), GetPosition()).Raycast(ray, out enter))
				{
					_isDragging = true;
					_activeAxis = axis3;
					_initalDragPos = ray.GetPoint(enter);
					_initalPos = base.transform.position;
					_initalDragRef = GetPosition();
					_initalRot = base.transform.rotation;
					_initialScreenAngle = GetScreenAngle();
				}
			}
			break;
		}
		case Action.Scale:
		{
			Axis axis = (_isDragging ? _activeAxis : GetActiveAxis(true));
			Vector3 forward = base.transform.forward;
			Vector3 right = base.transform.right;
			Vector3 up = base.transform.up;
			Graphics.DrawMesh(ScaleArrow, Matrix4x4.TRS(GetPosition(), Quaternion.LookRotation(forward), Vector3.one * Scale), (axis == Axis.ZAxis) ? _yellow : _blue, 0, Cam, 0, null, false, false);
			Graphics.DrawMesh(ScaleArrow, Matrix4x4.TRS(GetPosition(), Quaternion.LookRotation(right), Vector3.one * Scale), (axis == Axis.XAxis) ? _yellow : _green, 0, Cam, 0, null, false, false);
			Graphics.DrawMesh(ScaleArrow, Matrix4x4.TRS(GetPosition(), Quaternion.LookRotation(up), Vector3.one * Scale), (axis == Axis.YAxis) ? _yellow : _red, 0, Cam, 0, null, false, false);
			if (_isDragging)
			{
				if (Input.GetMouseButtonUp(0))
				{
					_isDragging = false;
					System.Action onFinishChange = OnFinishChange;
					if (onFinishChange != null)
					{
						onFinishChange();
					}
					break;
				}
				Vector3? dragPos = GetDragPos(_activeAxis, _initalDragRef, _initalRot);
				if (dragPos.HasValue)
				{
					Vector3 activeDir = GetActiveDir(_activeAxis, true);
					Vector3 vector = ((dragPos.Value - _initalDragRef).magnitude - (_initalDragRef - _initalDragPos).magnitude) * activeDir;
					base.transform.localScale = (_initialScale + vector).Abs();
					if (!Pivot)
					{
						base.transform.position = _initalPos - _initalRot * Vector3.Scale(_centerOffset, vector);
					}
				}
			}
			else if (Input.GetMouseButtonDown(0) && axis != Axis.None && !OverGUI())
			{
				Vector3? dragPos2 = GetDragPos(axis, GetPosition(), base.transform.rotation);
				if (dragPos2.HasValue)
				{
					_isDragging = true;
					_activeAxis = axis;
					_initalDragPos = dragPos2.Value;
					_initalPos = base.transform.position;
					_initialScale = base.transform.localScale;
					_initalDragRef = GetPosition();
					_initalRot = base.transform.rotation;
				}
			}
			break;
		}
		}
	}

	private void OnDrawGizmos()
	{
		if (_isDragging)
		{
			Gizmos.color = Color.magenta;
			Gizmos.DrawSphere(_initalDragPos, 0.1f);
			Gizmos.color = Color.white;
		}
	}
}
