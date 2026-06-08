using System;
using UnityEngine;

namespace LaundryBear.Math
{
	[Serializable]
	public struct VelocityContainer
	{
		[SerializeField]
		private Vector3 m_direction;

		[SerializeField]
		private float m_speed;

		public Vector3 Direction
		{
			get
			{
				return m_direction;
			}
			set
			{
				if (Mathf.Abs(value.sqrMagnitude - 1f) > 1E-05f)
				{
					throw new ArgumentException("The Direction member of a Velocity type must be normalized");
				}
				m_direction = value;
			}
		}

		public float Speed
		{
			get
			{
				return m_speed;
			}
			set
			{
				if (0f > value)
				{
					Debug.LogWarning("The Speed member of a Velocity type must be 0 or greater.  Clamping value to 0.");
				}
				m_speed = Mathf.Clamp(value, 0f, float.MaxValue);
			}
		}

		public Vector3 Velocity
		{
			get
			{
				return m_direction * m_speed;
			}
			set
			{
				Debug.LogWarning("Setting velocity vector directly. This is an expensive operation.");
				if (value.sqrMagnitude > 1E-05f)
				{
					Direction = value.normalized;
				}
				Speed = value.magnitude;
			}
		}

		public static implicit operator Vector3(VelocityContainer value)
		{
			return value.Velocity;
		}

		public static Vector3 operator +(VelocityContainer valueA, VelocityContainer valueB)
		{
			return valueA.Velocity + valueB.Velocity;
		}

		public static Vector3 operator -(VelocityContainer value)
		{
			return -value.Velocity;
		}

		public static VelocityContainer operator *(VelocityContainer value, float scalar)
		{
			value.Speed *= scalar;
			return value;
		}

		public static VelocityContainer operator *(float scalar, VelocityContainer value)
		{
			value.Speed *= scalar;
			return value;
		}
	}
}
