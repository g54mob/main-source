using System.Collections;
using UnityEngine;

public class RestrictedZoneEffect : MonoBehaviour
{
	public MeshRenderer meshRenderer;

	[ColorUsage(true, true)]
	public Color redColor;

	[ColorUsage(true, true)]
	public Color greenColor;

	[Min(0f)]
	public float killWindupDuration = 0.7f;

	public ParticleSystem killParticles;

	private static readonly int _Color = Shader.PropertyToID("_Color");

	private static readonly int _KillTime = Shader.PropertyToID("_KillTime");

	private static readonly int _KillWindupDuration = Shader.PropertyToID("_KillWindupDuration");

	private static readonly int _ShowRing = Shader.PropertyToID("_ShowRing");

	private MaterialPropertyBlock m_properties;

	private bool m_isGreen;

	private void Awake()
	{
		m_properties = new MaterialPropertyBlock();
		meshRenderer.GetPropertyBlock(m_properties);
		Activate();
	}

	public void TurnRed()
	{
		m_isGreen = false;
	}

	public void TurnGreen()
	{
		m_isGreen = true;
	}

	public void Activate()
	{
		m_properties.SetFloat(_KillTime, -1f);
	}

	public void Kill(bool showRing)
	{
		m_properties.SetFloat(_KillTime, Time.time);
		m_properties.SetFloat(_KillWindupDuration, killWindupDuration);
		m_properties.SetFloat(_ShowRing, showRing ? 1 : 0);
		if (killParticles != null)
		{
			StartCoroutine(PlayKillParticles());
		}
	}

	private IEnumerator PlayKillParticles()
	{
		yield return new WaitForSeconds(killWindupDuration);
		ParticleSystem.MainModule main = killParticles.main;
		main.startColor = (m_isGreen ? greenColor : redColor);
		ParticleSystem.EmissionModule emission = killParticles.emission;
		ParticleSystem.Burst burst = emission.GetBurst(0);
		burst.count = Mathf.CeilToInt(base.transform.lossyScale.x * 10f);
		emission.SetBurst(0, burst);
		killParticles.Play();
	}

	private void Update()
	{
		m_properties.SetColor(_Color, m_isGreen ? greenColor : redColor);
		meshRenderer.SetPropertyBlock(m_properties);
	}
}
