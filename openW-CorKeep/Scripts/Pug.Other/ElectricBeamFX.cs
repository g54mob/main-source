using UnityEngine;

public class ElectricBeamFX : WeaponFX
{
	public MeshRenderer renderer;

	public ParticleSystem originParticleSystem;

	public ParticleSystem endParticleSystem;

	[Space(10f)]
	[ColorUsage(false, true)]
	public Color color = new Color(1f, 0.4f, 0f);

	[ColorUsage(false, true)]
	public Color dimColor = new Color(1f, 0.1f, 0f);

	[Space(10f)]
	public bool updatePosition = true;

	[Range(0f, 1f)]
	public float flailing = 1f;

	public bool ignoreDim;

	private static int _Color = Shader.PropertyToID("_Color");

	private static int _DimColor = Shader.PropertyToID("_DimColor");

	private static int _Dim = Shader.PropertyToID("_Dim");

	private static int _DimFlailing = Shader.PropertyToID("_DimFlailing");

	private static int _TimeOffset = Shader.PropertyToID("_TimeOffset");

	protected ParticleSystem.EmissionModule m_originEmission;

	protected ParticleSystem.EmissionModule m_endEmission;

	protected float m_originEmitTimer;

	protected float m_endEmitTimer;

	private Material m_material;

	protected virtual void Awake()
	{
		m_material = Object.Instantiate(renderer.sharedMaterial);
		m_material.SetFloat(_TimeOffset, Random.value * 10f);
		renderer.sharedMaterial = m_material;
		if (originParticleSystem != null)
		{
			m_originEmission = originParticleSystem.emission;
			m_originEmission.enabled = false;
			m_originEmitTimer = 0f;
		}
		if (endParticleSystem != null)
		{
			m_endEmission = endParticleSystem.emission;
			m_endEmission.enabled = false;
			m_endEmitTimer = 0f;
		}
	}

	protected virtual void LateUpdate()
	{
		renderer.enabled = isOn;
		if (isOn)
		{
			if (updatePosition)
			{
				UpdatePosition();
			}
			m_material.SetColor(_Color, color);
			m_material.SetColor(_DimColor, dimColor);
			m_material.SetFloat(_Dim, (!isConnected || ignoreDim) ? 1 : 0);
			m_material.SetFloat(_DimFlailing, flailing);
			EmitParticles(originParticleSystem, ref m_originEmission, ref m_originEmitTimer);
			EmitParticles(endParticleSystem, ref m_endEmission, ref m_endEmitTimer);
		}
	}

	public override void UpdatePosition()
	{
		Vector3 vector = EntityMonoBehaviour.ToRenderFromWorld(originPointWorld);
		Vector3 vector2 = EntityMonoBehaviour.ToRenderFromWorld(endPointWorld);
		base.transform.position = vector;
		base.transform.rotation = Quaternion.LookRotation((vector2 - vector).normalized, Vector3.up);
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(vector2, vector));
	}

	protected void EmitParticles(ParticleSystem particleSystem, ref ParticleSystem.EmissionModule emission, ref float counter)
	{
		if (particleSystem == null)
		{
			return;
		}
		if (isOn && isConnected)
		{
			counter += emission.rateOverTime.constant * Time.deltaTime;
			int num = Mathf.FloorToInt(counter);
			counter -= num;
			if (num > 0)
			{
				particleSystem.Emit(num);
			}
		}
		else
		{
			counter = 0f;
		}
	}
}
