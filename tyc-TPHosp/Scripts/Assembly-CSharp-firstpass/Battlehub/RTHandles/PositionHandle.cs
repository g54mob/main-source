using UnityEngine;

namespace Battlehub.RTHandles
{
	public class PositionHandle : BaseHandle
	{
		public float GridSize = 1f;

		private Vector3 m_cursorPosition;

		private Vector3 m_currentPosition;

		private Vector3 m_prevPoint;

		private Matrix4x4 m_matrix;

		private Matrix4x4 m_inverse;

		public static PositionHandle Current { get; private set; }

		protected override RuntimeTool Tool => RuntimeTool.Move;

		protected override float CurrentGridSize => GridSize;

		protected override void StartOverride()
		{
			Current = this;
		}

		protected override void OnDestroyOverride()
		{
			if (Current == this)
			{
				Current = null;
			}
		}

		private bool HitQuad(Vector3 axis, Matrix4x4 matrix, float size)
		{
			Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
			Plane plane = new Plane(matrix.MultiplyVector(axis).normalized, matrix.MultiplyPoint(Vector3.zero));
			if (!plane.Raycast(ray, out var enter))
			{
				return false;
			}
			Vector3 point = ray.GetPoint(enter);
			point = matrix.inverse.MultiplyPoint(point);
			Vector3 lhs = Camera.transform.position - base.transform.position;
			float num = Mathf.Sign(Vector3.Dot(lhs, Vector3.right));
			float num2 = Mathf.Sign(Vector3.Dot(lhs, Vector3.up));
			float num3 = Mathf.Sign(Vector3.Dot(lhs, Vector3.forward));
			point.x *= num;
			point.y *= num2;
			point.z *= num3;
			float num4 = -0.01f;
			int num5;
			if (point.x >= num4 && point.x <= size && point.y >= num4 && point.y <= size && point.z >= num4)
			{
				num5 = ((point.z <= size) ? 1 : 0);
				if (num5 != 0)
				{
					base.DragPlane = GetDragPlane(matrix, axis);
				}
			}
			else
			{
				num5 = 0;
			}
			return (byte)num5 != 0;
		}

		protected override bool OnBeginDrag()
		{
			m_cursorPosition = base.transform.position;
			m_currentPosition = m_cursorPosition;
			float screenScale = RuntimeHandles.GetScreenScale(base.transform.position, Camera);
			m_matrix = Matrix4x4.TRS(base.transform.position, base.Rotation, Vector3.one);
			m_inverse = m_matrix.inverse;
			Matrix4x4 matrix = Matrix4x4.TRS(base.transform.position, base.Rotation, new Vector3(screenScale, screenScale, screenScale));
			float size = 0.3f * screenScale;
			if (HitQuad(Vector3.up, m_matrix, size))
			{
				base.SelectedAxis = RuntimeHandleAxis.XZ;
				return GetPointOnDragPlane(Input.mousePosition, out m_prevPoint);
			}
			if (HitQuad(Vector3.right, m_matrix, size))
			{
				base.SelectedAxis = RuntimeHandleAxis.YZ;
				return GetPointOnDragPlane(Input.mousePosition, out m_prevPoint);
			}
			if (HitQuad(Vector3.forward, m_matrix, size))
			{
				base.SelectedAxis = RuntimeHandleAxis.XY;
				return GetPointOnDragPlane(Input.mousePosition, out m_prevPoint);
			}
			if (HitAxis(Vector3.up, matrix, out var distanceToAxis) | HitAxis(Vector3.forward, matrix, out var distanceToAxis2) | HitAxis(Vector3.right, matrix, out var distanceToAxis3))
			{
				if (distanceToAxis <= distanceToAxis2 && distanceToAxis <= distanceToAxis3)
				{
					base.SelectedAxis = RuntimeHandleAxis.Y;
				}
				else if (distanceToAxis3 <= distanceToAxis && distanceToAxis3 <= distanceToAxis2)
				{
					base.SelectedAxis = RuntimeHandleAxis.X;
				}
				else
				{
					base.SelectedAxis = RuntimeHandleAxis.Z;
				}
				base.DragPlane = GetDragPlane();
				return GetPointOnDragPlane(Input.mousePosition, out m_prevPoint);
			}
			base.SelectedAxis = RuntimeHandleAxis.None;
			return false;
		}

		protected override void OnDrag()
		{
			if (!GetPointOnDragPlane(Input.mousePosition, out var point))
			{
				return;
			}
			Vector3 vector = m_inverse.MultiplyVector(point - m_prevPoint);
			float magnitude = vector.magnitude;
			if (base.SelectedAxis == RuntimeHandleAxis.X)
			{
				vector.y = (vector.z = 0f);
			}
			else if (base.SelectedAxis == RuntimeHandleAxis.Y)
			{
				vector.x = (vector.z = 0f);
			}
			else if (base.SelectedAxis == RuntimeHandleAxis.Z)
			{
				vector.x = (vector.y = 0f);
			}
			if ((double)base.EffectiveGridSize == 0.0)
			{
				vector = m_matrix.MultiplyVector(vector).normalized * magnitude;
				base.transform.position += vector;
				m_prevPoint = point;
				return;
			}
			vector = m_matrix.MultiplyVector(vector).normalized * magnitude;
			m_cursorPosition += vector;
			Vector3 vector2 = m_cursorPosition - m_currentPosition;
			if (vector2.magnitude * 1.5f >= base.EffectiveGridSize)
			{
				m_currentPosition += vector2.normalized * base.EffectiveGridSize;
				base.transform.position = m_currentPosition;
			}
			m_prevPoint = point;
		}

		protected override void DrawOverride()
		{
			RuntimeHandles.DoPositionHandle(base.transform.position, base.Rotation, base.SelectedAxis);
		}
	}
}
