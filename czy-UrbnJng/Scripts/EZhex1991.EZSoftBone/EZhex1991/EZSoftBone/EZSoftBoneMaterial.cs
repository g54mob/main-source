using UnityEngine;

namespace EZhex1991.EZSoftBone
{
	[CreateAssetMenu(fileName = "SBMat", menuName = "EZSoftBone/SBMaterial")]
	public class EZSoftBoneMaterial : ScriptableObject
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float m_Damping = 0.2f;

		[SerializeField]
		[EZCurveRect(0f, 0f, 1f, 1f)]
		private AnimationCurve m_DampingCurve = AnimationCurve.EaseInOut(0f, 0.5f, 1f, 1f);

		[SerializeField]
		[Range(0f, 1f)]
		private float m_Stiffness = 0.1f;

		[SerializeField]
		[EZCurveRect(0f, 0f, 1f, 1f)]
		private AnimationCurve m_StiffnessCurve = AnimationCurve.Linear(0f, 1f, 1f, 1f);

		[SerializeField]
		[Range(0f, 1f)]
		private float m_Resistance = 0.9f;

		[SerializeField]
		[EZCurveRect(0f, 0f, 1f, 1f)]
		private AnimationCurve m_ResistanceCurve = AnimationCurve.Linear(0f, 1f, 1f, 0f);

		[SerializeField]
		[Range(0f, 1f)]
		private float m_Slackness = 0.1f;

		[SerializeField]
		[EZCurveRect(0f, 0f, 1f, 1f)]
		private AnimationCurve m_SlacknessCurve = AnimationCurve.Linear(0f, 1f, 1f, 0.8f);

		private static EZSoftBoneMaterial m_DefaultMaterial;

		public float damping
		{
			get
			{
				return m_Damping;
			}
			set
			{
				m_Damping = Mathf.Clamp01(value);
			}
		}

		public AnimationCurve dampingCurve => m_DampingCurve;

		public float stiffness
		{
			get
			{
				return m_Stiffness;
			}
			set
			{
				m_Stiffness = Mathf.Clamp01(value);
			}
		}

		public AnimationCurve stiffnessCurve => m_StiffnessCurve;

		public float resistance
		{
			get
			{
				return m_Resistance;
			}
			set
			{
				m_Resistance = Mathf.Clamp01(value);
			}
		}

		public AnimationCurve resistanceCurve => m_ResistanceCurve;

		public float slackness
		{
			get
			{
				return m_Slackness;
			}
			set
			{
				m_Slackness = Mathf.Clamp01(value);
			}
		}

		public AnimationCurve slacknessCurve => m_SlacknessCurve;

		public static EZSoftBoneMaterial defaultMaterial
		{
			get
			{
				if (m_DefaultMaterial == null)
				{
					m_DefaultMaterial = ScriptableObject.CreateInstance<EZSoftBoneMaterial>();
				}
				m_DefaultMaterial.name = "SBMat_Default";
				return m_DefaultMaterial;
			}
		}

		public float GetDamping(float t)
		{
			return damping * dampingCurve.Evaluate(t);
		}

		public float GetStiffness(float t)
		{
			return stiffness * stiffnessCurve.Evaluate(t);
		}

		public float GetResistance(float t)
		{
			return resistance * resistanceCurve.Evaluate(t);
		}

		public float GetSlackness(float t)
		{
			return slackness * slacknessCurve.Evaluate(t);
		}
	}
}
