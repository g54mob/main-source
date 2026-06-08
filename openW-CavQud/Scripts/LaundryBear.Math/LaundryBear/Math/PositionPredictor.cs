using UnityEngine;

namespace LaundryBear.Math
{
	public class PositionPredictor
	{
		private Vector3 m_position;

		private const float SMOOTHING_DEFAULT = 10f;

		private float m_smoothing = 10f;

		private GaussianWindow1D_Vector3 m_velocity = new GaussianWindow1D_Vector3(10f);

		private GaussianWindow1D_Vector3 m_accel = new GaussianWindow1D_Vector3(10f);

		public float Smoothing
		{
			get
			{
				return m_smoothing;
			}
			set
			{
				if (value != m_smoothing)
				{
					m_smoothing = value;
					int maxKernelRadius = Mathf.Max(10, Mathf.FloorToInt(value * 1.5f));
					m_velocity = new GaussianWindow1D_Vector3(m_smoothing, maxKernelRadius);
					m_accel = new GaussianWindow1D_Vector3(m_smoothing, maxKernelRadius);
				}
			}
		}

		public bool IgnoreY { get; set; }

		public bool IsEmpty => m_velocity.IsEmpty();

		public void ApplyTransformDelta(Vector3 positionDelta)
		{
			m_position += positionDelta;
		}

		public void Reset()
		{
			m_velocity.Reset();
			m_accel.Reset();
		}

		public void AddPosition(Vector3 pos)
		{
			if (IsEmpty)
			{
				m_velocity.AddValue(Vector3.zero);
			}
			else if (Time.deltaTime > 1E-05f)
			{
				Vector3 vector = m_velocity.Value();
				Vector3 vector2 = (pos - m_position) / Time.deltaTime;
				if (IgnoreY)
				{
					vector2.y = 0f;
				}
				m_velocity.AddValue(vector2);
				m_accel.AddValue(vector2 - vector);
			}
			m_position = pos;
		}

		public Vector3 PredictPosition(float lookaheadTime)
		{
			Vector3 position = m_position;
			if (Time.deltaTime > 1E-05f)
			{
				int num = Mathf.Min(Mathf.RoundToInt(lookaheadTime / Time.deltaTime), 6);
				float num2 = lookaheadTime / (float)num;
				Vector3 vector = (m_velocity.IsEmpty() ? Vector3.zero : m_velocity.Value());
				Vector3 vector2 = (m_accel.IsEmpty() ? Vector3.zero : m_accel.Value());
				for (int i = 0; i < num; i++)
				{
					position += vector * num2;
					Vector3 vector3 = vector + vector2 * num2;
					vector2 = Quaternion.FromToRotation(vector, vector3) * vector2;
					vector = vector3;
				}
			}
			return position;
		}

		public Vector3 SmoothedVelocity()
		{
			if (!m_velocity.IsEmpty())
			{
				return m_velocity.Value();
			}
			return Vector3.zero;
		}

		public Vector3 SmoothedAcceleration()
		{
			if (!m_accel.IsEmpty())
			{
				return m_accel.Value();
			}
			return Vector3.zero;
		}
	}
}
