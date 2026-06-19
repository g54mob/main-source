using UnityEngine;

public class FireworkExplosion : PoolableSimple
{
	[SerializeField]
	private ParticleSystem m_color1;

	[SerializeField]
	private ParticleSystem m_color2;

	[SerializeField]
	private ParticleSystem m_popParticles;

	[SerializeField]
	private ParticleSystem m_fizzleParticles;

	[SerializeField]
	private ParticleSystem m_lingerParticles;

	[SerializeField]
	private Light m_light;

	[SerializeField]
	private AnimationCurve m_lightAnimation;

	private float m_lightIntensity;

	private float m_lightRange;

	private float m_particle2Ratio;

	private Vector3 m_localScale;

	private float m_animationTime;

	private float[] m_startSizeMultipliers = new float[5];

	private void Awake()
	{
		m_lightIntensity = m_light.intensity;
		m_lightRange = m_light.range;
		m_localScale = base.transform.localScale;
		ParticleSystem.MainModule main = m_color1.main;
		ParticleSystem.MainModule main2 = m_color2.main;
		ParticleSystem.MainModule main3 = m_popParticles.main;
		ParticleSystem.MainModule main4 = m_fizzleParticles.main;
		ParticleSystem.MainModule main5 = m_lingerParticles.main;
		m_particle2Ratio = (float)main2.maxParticles / (float)main.maxParticles;
		m_startSizeMultipliers[0] = main.startSizeMultiplier;
		m_startSizeMultipliers[1] = main2.startSizeMultiplier;
		m_startSizeMultipliers[2] = main3.startSizeMultiplier;
		m_startSizeMultipliers[3] = main4.startSizeMultiplier;
		m_startSizeMultipliers[4] = main5.startSizeMultiplier;
	}

	public void Play(Color color1, Color color2, Color sparkleColor, Color lingerColor, float trailLength = 0f, float scale = 1f, int particleCount = 100)
	{
		Color color3 = new Color(1f, 0.75f, 0.5f);
		ParticleSystem.MainModule main = m_color1.main;
		ParticleSystem.MainModule main2 = m_color2.main;
		ParticleSystem.MainModule main3 = m_popParticles.main;
		ParticleSystem.MainModule main4 = m_fizzleParticles.main;
		ParticleSystem.MainModule main5 = m_lingerParticles.main;
		ParticleSystem.TrailModule trails = m_color1.trails;
		ParticleSystem.TrailModule trails2 = m_color2.trails;
		m_fizzleParticles.gameObject.SetActive(sparkleColor.a > Mathf.Epsilon);
		m_lingerParticles.gameObject.SetActive(lingerColor.a > Mathf.Epsilon);
		main.maxParticles = particleCount;
		main2.maxParticles = Mathf.CeilToInt((float)particleCount * m_particle2Ratio);
		main.startColor = color3;
		main2.startColor = color3;
		main4.startColor = sparkleColor;
		main5.startColor = lingerColor;
		trails.enabled = trailLength > Mathf.Epsilon;
		trails2.enabled = trailLength > Mathf.Epsilon;
		trails.colorOverTrail = color1;
		trails2.colorOverTrail = color2;
		trails.lifetime = trailLength;
		trails2.lifetime = trailLength;
		trails.inheritParticleColor = false;
		trails2.inheritParticleColor = false;
		base.transform.localScale = m_localScale * scale;
		main.startSizeMultiplier = m_startSizeMultipliers[0] / scale;
		main2.startSizeMultiplier = m_startSizeMultipliers[1] / scale;
		main3.startSizeMultiplier = m_startSizeMultipliers[2] / scale;
		main4.startSizeMultiplier = m_startSizeMultipliers[3] / scale;
		main5.startSizeMultiplier = m_startSizeMultipliers[4] / scale;
		m_color1.Play();
		m_animationTime = 0f;
		m_light.color = color1 + color2 * 0.25f;
		m_light.intensity = 0f;
		m_light.range = m_lightRange * scale;
	}

	private void Update()
	{
		m_animationTime += Time.deltaTime;
		m_light.intensity = m_lightAnimation.Evaluate(m_animationTime) * m_lightIntensity;
	}

	public void OnParticleSystemStopped()
	{
		Free();
	}
}
