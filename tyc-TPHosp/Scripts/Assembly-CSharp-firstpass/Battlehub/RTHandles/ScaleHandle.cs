using UnityEngine;

namespace Battlehub.RTHandles
{
	public class ScaleHandle : BaseHandle
	{
		public float GridSize = 0.1f;

		private Vector3 m_prevPoint;

		private Matrix4x4 m_matrix;

		private Matrix4x4 m_inverse;

		private Vector3 m_roundedScale;

		private Vector3 m_scale;

		private Vector3[] m_refScales;

		private float m_screenScale;

		public static ScaleHandle Current { get; private set; }

		protected override RuntimeTool Tool => RuntimeTool.Scale;

		protected override float CurrentGridSize => GridSize;

		protected override void StartOverride()
		{
			Current = this;
			m_scale = Vector3.one;
			m_roundedScale = m_scale;
		}

		protected override void OnDestroyOverride()
		{
			if (Current == this)
			{
				Current = null;
			}
		}

		protected override bool OnBeginDrag()
		{
			m_screenScale = RuntimeHandles.GetScreenScale(base.transform.position, Camera);
			m_matrix = Matrix4x4.TRS(base.transform.position, base.Rotation, Vector3.one);
			m_inverse = m_matrix.inverse;
			Matrix4x4 matrix = Matrix4x4.TRS(base.transform.position, base.Rotation, new Vector3(m_screenScale, m_screenScale, m_screenScale));
			if (HitCenter())
			{
				base.SelectedAxis = RuntimeHandleAxis.Free;
				base.DragPlane = GetDragPlane();
			}
			else
			{
				if (!(HitAxis(Vector3.up, matrix, out var distanceToAxis) | HitAxis(Vector3.forward, matrix, out var distanceToAxis2) | HitAxis(Vector3.right, matrix, out var distanceToAxis3)))
				{
					base.SelectedAxis = RuntimeHandleAxis.None;
					return false;
				}
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
			}
			m_refScales = new Vector3[Targets.Length];
			for (int i = 0; i < m_refScales.Length; i++)
			{
				Quaternion quaternion = ((RuntimeTools.PivotRotation == RuntimePivotRotation.Global) ? Targets[i].rotation : Quaternion.identity);
				m_refScales[i] = quaternion * base.Target.localScale;
			}
			base.DragPlane = GetDragPlane();
			return GetPointOnDragPlane(Input.mousePosition, out m_prevPoint);
		}

		protected override void OnDrag()
		{
			if (GetPointOnDragPlane(Input.mousePosition, out var point))
			{
				Vector3 vector = m_inverse.MultiplyVector((point - m_prevPoint) / m_screenScale);
				float magnitude = vector.magnitude;
				if (base.SelectedAxis == RuntimeHandleAxis.X)
				{
					vector.y = (vector.z = 0f);
					m_scale.x += Mathf.Sign(vector.x) * magnitude;
				}
				else if (base.SelectedAxis == RuntimeHandleAxis.Y)
				{
					vector.x = (vector.z = 0f);
					m_scale.y += Mathf.Sign(vector.y) * magnitude;
				}
				else if (base.SelectedAxis == RuntimeHandleAxis.Z)
				{
					vector.x = (vector.y = 0f);
					m_scale.z += Mathf.Sign(vector.z) * magnitude;
				}
				if (base.SelectedAxis == RuntimeHandleAxis.Free)
				{
					float num = Mathf.Sign(vector.x + vector.y);
					m_scale.x += num * magnitude;
					m_scale.y += num * magnitude;
					m_scale.z += num * magnitude;
				}
				m_roundedScale = m_scale;
				if ((double)base.EffectiveGridSize > 0.01)
				{
					m_roundedScale.x = (float)Mathf.RoundToInt(m_roundedScale.x / base.EffectiveGridSize) * base.EffectiveGridSize;
					m_roundedScale.y = (float)Mathf.RoundToInt(m_roundedScale.y / base.EffectiveGridSize) * base.EffectiveGridSize;
					m_roundedScale.z = (float)Mathf.RoundToInt(m_roundedScale.z / base.EffectiveGridSize) * base.EffectiveGridSize;
				}
				for (int i = 0; i < m_refScales.Length; i++)
				{
					Quaternion rotation = ((RuntimeTools.PivotRotation == RuntimePivotRotation.Global) ? Targets[i].rotation : Quaternion.identity);
					Targets[i].localScale = Quaternion.Inverse(rotation) * Vector3.Scale(m_refScales[i], m_roundedScale);
				}
				m_prevPoint = point;
			}
		}

		protected override void OnDrop()
		{
			m_scale = Vector3.one;
			m_roundedScale = m_scale;
		}

		protected override void DrawOverride()
		{
			RuntimeHandles.DoScaleHandle(m_roundedScale, base.transform.position, base.Rotation, base.SelectedAxis);
		}
	}
}
