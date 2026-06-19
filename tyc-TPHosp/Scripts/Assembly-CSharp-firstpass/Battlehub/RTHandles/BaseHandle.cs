using UnityEngine;

namespace Battlehub.RTHandles
{
	public abstract class BaseHandle : MonoBehaviour, IGL
	{
		public KeyCode SnapToGridKey = KeyCode.LeftControl;

		public Camera Camera;

		public float SelectionMargin = 10f;

		public Transform[] Targets;

		private static BaseHandle m_draggingTool;

		private RuntimeHandleAxis m_selectedAxis;

		private bool m_isDragging;

		private Plane m_dragPlane;

		protected float EffectiveGridSize { get; private set; }

		public Transform Target => Targets[0];

		public bool IsDragging => m_isDragging;

		protected abstract RuntimeTool Tool { get; }

		protected Quaternion Rotation
		{
			get
			{
				if (Targets == null || Targets.Length == 0 || Target == null)
				{
					return Quaternion.identity;
				}
				if (RuntimeTools.PivotRotation != RuntimePivotRotation.Local)
				{
					return Quaternion.identity;
				}
				return Target.rotation;
			}
		}

		protected RuntimeHandleAxis SelectedAxis
		{
			get
			{
				return m_selectedAxis;
			}
			set
			{
				m_selectedAxis = value;
			}
		}

		protected Plane DragPlane
		{
			get
			{
				return m_dragPlane;
			}
			set
			{
				m_dragPlane = value;
			}
		}

		protected abstract float CurrentGridSize { get; }

		private void Start()
		{
			if (Camera == null)
			{
				Camera = Camera.main;
			}
			if (GLRenderer.Instance == null)
			{
				GameObject obj = new GameObject();
				obj.name = "GLRenderer";
				obj.AddComponent<GLRenderer>();
			}
			if (Camera != null && !Camera.GetComponent<GLCamera>())
			{
				Camera.gameObject.AddComponent<GLCamera>();
			}
			if (Targets == null || Targets.Length == 0)
			{
				Targets = new Transform[1] { base.transform };
			}
			if (GLRenderer.Instance != null)
			{
				GLRenderer.Instance.Add(this);
			}
			if (Targets[0].position != base.transform.position)
			{
				base.transform.position = Targets[0].position;
			}
			StartOverride();
		}

		protected virtual void StartOverride()
		{
		}

		private void OnEnable()
		{
			if (GLRenderer.Instance != null)
			{
				GLRenderer.Instance.Add(this);
			}
			OnEnableOverride();
		}

		protected virtual void OnEnableOverride()
		{
		}

		private void OnDisable()
		{
			if (GLRenderer.Instance != null)
			{
				GLRenderer.Instance.Remove(this);
			}
			OnDisableOverride();
		}

		protected virtual void OnDisableOverride()
		{
		}

		private void OnDestroy()
		{
			if (GLRenderer.Instance != null)
			{
				GLRenderer.Instance.Remove(this);
			}
			OnDestroyOverride();
		}

		protected virtual void OnDestroyOverride()
		{
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				if ((RuntimeTools.Current != Tool && RuntimeTools.Current != RuntimeTool.None) || RuntimeTools.IsLocked)
				{
					return;
				}
				if (Camera == null)
				{
					Debug.LogError("Camera is null");
					return;
				}
				if (m_draggingTool != null)
				{
					return;
				}
				m_isDragging = OnBeginDrag();
				if (m_isDragging)
				{
					m_draggingTool = this;
				}
			}
			else if (Input.GetMouseButtonUp(0))
			{
				OnDrop();
				m_isDragging = false;
				m_draggingTool = null;
			}
			else if (m_isDragging)
			{
				if (Input.GetKey(SnapToGridKey))
				{
					EffectiveGridSize = CurrentGridSize;
				}
				else
				{
					EffectiveGridSize = 0f;
				}
				OnDrag();
			}
			UpdateOverride();
		}

		protected virtual bool OnBeginDrag()
		{
			return false;
		}

		protected virtual void OnDrag()
		{
		}

		protected virtual void OnDrop()
		{
		}

		protected virtual void UpdateOverride()
		{
			if (Targets == null || Targets.Length == 0 || !(Targets[0] != null) || !(Targets[0].position != base.transform.position))
			{
				return;
			}
			if (IsDragging)
			{
				Vector3 vector = base.transform.position - Targets[0].position;
				Targets[0].position = base.transform.position;
				for (int i = 1; i < Targets.Length; i++)
				{
					Targets[i].position += vector;
				}
			}
			else
			{
				base.transform.position = Targets[0].position;
				base.transform.rotation = Targets[0].rotation;
			}
		}

		protected bool HitCenter()
		{
			Vector2 vector = Camera.WorldToScreenPoint(base.transform.position);
			return ((Vector2)Input.mousePosition - vector).magnitude <= SelectionMargin;
		}

		protected bool HitAxis(Vector3 axis, Matrix4x4 matrix, out float distanceToAxis)
		{
			axis = matrix.MultiplyVector(axis);
			Vector2 vector = Camera.WorldToScreenPoint(base.transform.position);
			Vector3 vector2 = (Vector2)Camera.WorldToScreenPoint(axis + base.transform.position) - vector;
			float magnitude = vector2.magnitude;
			vector2.Normalize();
			if (vector2 != Vector3.zero)
			{
				Vector2 normalized = PerpendicularClockwise(vector2).normalized;
				Vector2 vector3 = (Vector2)Input.mousePosition - vector;
				distanceToAxis = Mathf.Abs(Vector2.Dot(normalized, vector3));
				Vector2 rhs = vector3 - normalized * distanceToAxis;
				float num = Vector2.Dot(vector2, rhs);
				int num2;
				if (num <= magnitude + SelectionMargin && num >= 0f - SelectionMargin)
				{
					num2 = ((distanceToAxis <= SelectionMargin) ? 1 : 0);
					if (num2 != 0)
					{
						if (magnitude < SelectionMargin)
						{
							distanceToAxis = 0f;
						}
						return (byte)num2 != 0;
					}
				}
				else
				{
					num2 = 0;
				}
				distanceToAxis = float.PositiveInfinity;
				return (byte)num2 != 0;
			}
			Vector2 vector4 = Input.mousePosition;
			distanceToAxis = (vector - vector4).magnitude;
			bool num3 = distanceToAxis <= SelectionMargin;
			if (!num3)
			{
				distanceToAxis = float.PositiveInfinity;
				return num3;
			}
			distanceToAxis = 0f;
			return num3;
		}

		protected Plane GetDragPlane(Matrix4x4 matrix, Vector3 axis)
		{
			return new Plane(matrix.MultiplyVector(axis).normalized, matrix.MultiplyPoint(Vector3.zero));
		}

		protected Plane GetDragPlane()
		{
			return new Plane(Camera.cameraToWorldMatrix.MultiplyVector(Vector3.forward).normalized, base.transform.position);
		}

		protected bool GetPointOnDragPlane(Vector3 screenPos, out Vector3 point)
		{
			return GetPointOnDragPlane(m_dragPlane, screenPos, out point);
		}

		protected bool GetPointOnDragPlane(Plane dragPlane, Vector3 screenPos, out Vector3 point)
		{
			Ray ray = Camera.ScreenPointToRay(screenPos);
			if (dragPlane.Raycast(ray, out var enter))
			{
				point = ray.GetPoint(enter);
				return true;
			}
			point = Vector3.zero;
			return false;
		}

		private static Vector2 PerpendicularClockwise(Vector2 vector2)
		{
			return new Vector2(0f - vector2.y, vector2.x);
		}

		void IGL.Draw()
		{
			DrawOverride();
		}

		protected virtual void DrawOverride()
		{
		}
	}
}
