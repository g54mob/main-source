using UnityEngine;
using UnityEngine.Serialization;

public class ParticleRandomizer : MonoBehaviour
{
	[SerializeField]
	private Gradient m_Color;

	[FormerlySerializedAs("m_ScaleDeviation")]
	[SerializeField]
	private float m_SizeDeviation;

	[SerializeField]
	private float m_LifetimeDeviation;

	[SerializeField]
	private float m_SpeedDeviation;

	[SerializeField]
	private float m_SpeedOffset;

	private ParticleSystem.MinMaxCurve m_BaseSize;

	private ParticleSystem.MinMaxCurve m_BaseLifetime;

	private ParticleSystem.MinMaxCurve m_BaseSpeed;

	private ParticleSystem m_Particle;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void Randomize()
	{
	}

	private ParticleSystem.MinMaxCurve ApplyOffset(ParticleSystem.MinMaxCurve to, float offset)
	{
		return default(ParticleSystem.MinMaxCurve);
	}

	private ParticleSystem.MinMaxCurve ApplyDeviation(ParticleSystem.MinMaxCurve to, float deviation)
	{
		return default(ParticleSystem.MinMaxCurve);
	}
}
