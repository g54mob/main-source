using UnityEngine;

namespace Battlehub.RTHandles
{
	public class RotationHandle : BaseHandle
	{
		public float GridSize = 15f;

		public float XSpeed = 10f;

		public float YSpeed = 10f;

		private Matrix4x4 m_targetInverse;

		private Matrix4x4 m_matrix;

		private Matrix4x4 m_inverse;

		private const float innerRadius = 1f;

		private const float outerRadius = 1.2f;

		private const float hitDot = 0.2f;

		private float m_deltaX;

		private float m_deltaY;

		public static RotationHandle Current { get; private set; }

		protected override RuntimeTool Tool => RuntimeTool.Rotate;

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

		protected override void OnEnableOverride()
		{
			base.OnEnableOverride();
		}

		private bool Intersect(Ray r, Vector3 sphereCenter, float sphereRadius, out float hit1Distance, out float hit2Distance)
		{
			hit1Distance = 0f;
			hit2Distance = 0f;
			Vector3 vector = sphereCenter - r.origin;
			float num = Vector3.Dot(vector, r.direction);
			if ((double)num < 0.0)
			{
				return false;
			}
			float num2 = Vector3.Dot(vector, vector) - num * num;
			float num3 = sphereRadius * sphereRadius;
			if (num2 > num3)
			{
				return false;
			}
			float num4 = Mathf.Sqrt(num3 - num2);
			hit1Distance = num - num4;
			hit2Distance = num + num4;
			return true;
		}

		private RuntimeHandleAxis Hit()
		{
			Ray r = Camera.ScreenPointToRay(Input.mousePosition);
			float screenScale = RuntimeHandles.GetScreenScale(base.Target.position, Camera);
			if (Intersect(r, base.Target.position, 1.2f * screenScale, out var hit1Distance, out var hit2Distance))
			{
				GetPointOnDragPlane(GetDragPlane(), Input.mousePosition, out var point);
				if ((point - base.Target.position).magnitude <= 1f * screenScale)
				{
					Intersect(r, base.Target.position, 1f * screenScale, out hit1Distance, out hit2Distance);
					Vector3 normalized = m_targetInverse.MultiplyPoint(r.GetPoint(hit1Distance)).normalized;
					float num = Mathf.Abs(Vector3.Dot(normalized, Vector3.right));
					float num2 = Mathf.Abs(Vector3.Dot(normalized, Vector3.up));
					float num3 = Mathf.Abs(Vector3.Dot(normalized, Vector3.forward));
					if (num < 0.2f)
					{
						return RuntimeHandleAxis.X;
					}
					if (num2 < 0.2f)
					{
						return RuntimeHandleAxis.Y;
					}
					if (num3 < 0.2f)
					{
						return RuntimeHandleAxis.Z;
					}
					return RuntimeHandleAxis.Free;
				}
				return RuntimeHandleAxis.Screen;
			}
			return RuntimeHandleAxis.None;
		}

		protected override bool OnBeginDrag()
		{
			m_targetInverse = Matrix4x4.TRS(base.Target.position, base.Target.rotation, Vector3.one).inverse;
			base.SelectedAxis = Hit();
			m_deltaX = 0f;
			m_deltaY = 0f;
			if (base.SelectedAxis == RuntimeHandleAxis.Screen)
			{
				Vector2 vector = Camera.WorldToScreenPoint(base.Target.position);
				Vector2 vector2 = Input.mousePosition;
				float num = Mathf.Atan2(vector2.y - vector.y, vector2.x - vector.x);
				m_matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(57.29578f * num, Vector3.forward), Vector3.one);
			}
			else
			{
				m_matrix = Matrix4x4.TRS(Vector3.zero, base.Target.rotation, Vector3.one);
			}
			m_inverse = m_matrix.inverse;
			return base.SelectedAxis != RuntimeHandleAxis.None;
		}

		protected override void OnDrag()
		{
			float axis = Input.GetAxis("Mouse X");
			float axis2 = Input.GetAxis("Mouse Y");
			axis *= XSpeed;
			axis2 *= YSpeed;
			m_deltaX += axis;
			m_deltaY += axis2;
			Vector3 vector = m_inverse.MultiplyVector(Camera.cameraToWorldMatrix.MultiplyVector(new Vector3(m_deltaY, 0f - m_deltaX, 0f)));
			Quaternion quaternion;
			if (base.SelectedAxis == RuntimeHandleAxis.X)
			{
				if (base.EffectiveGridSize != 0f)
				{
					if (Mathf.Abs(vector.x) >= base.EffectiveGridSize)
					{
						vector.x = Mathf.Sign(vector.x) * base.EffectiveGridSize;
						m_deltaX = 0f;
						m_deltaY = 0f;
					}
					else
					{
						vector.x = 0f;
					}
				}
				quaternion = Quaternion.Euler(vector.x, 0f, 0f);
			}
			else if (base.SelectedAxis == RuntimeHandleAxis.Y)
			{
				if (base.EffectiveGridSize != 0f)
				{
					if (Mathf.Abs(vector.y) >= base.EffectiveGridSize)
					{
						vector.y = Mathf.Sign(vector.y) * base.EffectiveGridSize;
						m_deltaX = 0f;
						m_deltaY = 0f;
					}
					else
					{
						vector.y = 0f;
					}
				}
				quaternion = Quaternion.Euler(0f, vector.y, 0f);
			}
			else if (base.SelectedAxis == RuntimeHandleAxis.Z)
			{
				if (base.EffectiveGridSize != 0f)
				{
					if (Mathf.Abs(vector.z) >= base.EffectiveGridSize)
					{
						vector.z = Mathf.Sign(vector.z) * base.EffectiveGridSize;
						m_deltaX = 0f;
						m_deltaY = 0f;
					}
					else
					{
						vector.z = 0f;
					}
				}
				quaternion = Quaternion.Euler(0f, 0f, vector.z);
			}
			else if (base.SelectedAxis == RuntimeHandleAxis.Free)
			{
				quaternion = Quaternion.Euler(vector.x, vector.y, vector.z);
				m_deltaX = 0f;
				m_deltaY = 0f;
			}
			else
			{
				vector = m_inverse.MultiplyVector(new Vector3(m_deltaY, 0f - m_deltaX, 0f));
				if (base.EffectiveGridSize != 0f)
				{
					if (Mathf.Abs(vector.x) >= base.EffectiveGridSize)
					{
						vector.x = Mathf.Sign(vector.x) * base.EffectiveGridSize;
						m_deltaX = 0f;
						m_deltaY = 0f;
					}
					else
					{
						vector.x = 0f;
					}
				}
				Vector3 axis3 = m_targetInverse.MultiplyVector(Camera.cameraToWorldMatrix.MultiplyVector(-Vector3.forward));
				quaternion = Quaternion.AngleAxis(vector.x, axis3);
			}
			if (base.EffectiveGridSize == 0f)
			{
				m_deltaX = 0f;
				m_deltaY = 0f;
			}
			for (int i = 0; i < Targets.Length; i++)
			{
				Targets[i].rotation *= quaternion;
			}
		}

		protected override void DrawOverride()
		{
			RuntimeHandles.DoRotationHandle(base.Target.rotation, base.Target.position, base.SelectedAxis);
		}
	}
}
