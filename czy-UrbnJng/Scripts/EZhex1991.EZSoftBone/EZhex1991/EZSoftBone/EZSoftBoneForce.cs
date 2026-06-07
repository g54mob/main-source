using UnityEngine;

namespace EZhex1991.EZSoftBone
{
	[CreateAssetMenu(fileName = "SBForce", menuName = "EZSoftBone/SBForce")]
	public class EZSoftBoneForce : ScriptableObject
	{
		public enum TurbulenceMode
		{
			Curve = 0,
			Perlin = 1
		}

		[SerializeField]
		private float m_Force = 1f;

		[SerializeField]
		private Vector3 m_Turbulence = new Vector3(1f, 0.5f, 2f);

		[SerializeField]
		private TurbulenceMode m_TurbulenceMode = TurbulenceMode.Perlin;

		[SerializeField]
		private Vector3 m_Frequency = new Vector3(1f, 1f, 1.5f);

		[SerializeField]
		private float m_TimeCycle = 2f;

		[SerializeField]
		[EZCurveRect(0f, -1f, 1f, 2f)]
		private AnimationCurve m_CurveX = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		[EZCurveRect(0f, -1f, 1f, 2f)]
		private AnimationCurve m_CurveY = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		[SerializeField]
		[EZCurveRect(0f, -1f, 1f, 2f)]
		private AnimationCurve m_CurveZ = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);

		public float force
		{
			get
			{
				return m_Force;
			}
			set
			{
				m_Force = value;
			}
		}

		public Vector3 turbulence
		{
			get
			{
				return m_Turbulence;
			}
			set
			{
				m_Turbulence = value;
			}
		}

		public TurbulenceMode turbulenceMode
		{
			get
			{
				return m_TurbulenceMode;
			}
			set
			{
				m_TurbulenceMode = value;
			}
		}

		public Vector3 frequency
		{
			get
			{
				return m_Frequency;
			}
			set
			{
				m_Frequency = value;
			}
		}

		public float timeCycle
		{
			get
			{
				return m_TimeCycle;
			}
			set
			{
				m_TimeCycle = Mathf.Max(0f, value);
			}
		}

		public Vector3 GetForce(float time)
		{
			Vector3 vector = turbulence;
			switch (turbulenceMode)
			{
			case TurbulenceMode.Curve:
				time = Mathf.Repeat(time, m_TimeCycle) / m_TimeCycle;
				vector.x *= Curve(m_CurveX, time);
				vector.y *= Curve(m_CurveY, time);
				vector.z *= Curve(m_CurveZ, time);
				break;
			case TurbulenceMode.Perlin:
				vector.x *= Perlin(time * frequency.x, 0f);
				vector.y *= Perlin(time * frequency.y, 0.5f);
				vector.z *= Perlin(time * frequency.z, 1f);
				break;
			}
			return new Vector3(0f, 0f, force) + vector;
		}

		private float Perlin(float x, float y)
		{
			return Mathf.PerlinNoise(x, y) * 2f - 1f;
		}

		private float Curve(AnimationCurve curve, float time)
		{
			return curve.Evaluate(time);
		}
	}
}
