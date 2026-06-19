using UnityEngine;

public class FlamethrowerFX : ElectricBeamFX
{
	public float flameLength = 1f;

	public float lifetimeRandomMin = 0.2f;

	public float lifetimeRandomMax = 0.7f;

	protected override void Awake()
	{
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

	protected override void LateUpdate()
	{
		if (isOn)
		{
			if (updatePosition)
			{
				UpdatePosition();
			}
			EmitFlameParticles(originParticleSystem, ref m_originEmission, ref m_originEmitTimer);
			EmitFlameParticles(endParticleSystem, ref m_endEmission, ref m_endEmitTimer, useConnected: true);
		}
	}

	private void EmitFlameParticles(ParticleSystem particleSystem, ref ParticleSystem.EmissionModule emission, ref float counter, bool useConnected = false)
	{
		if (particleSystem == null)
		{
			return;
		}
		if (isOn && (!useConnected || isConnected))
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

	public override void UpdatePosition()
	{
		Vector3 vector = EntityMonoBehaviour.ToRenderFromWorld(originPointWorld);
		Vector3 vector2 = EntityMonoBehaviour.ToRenderFromWorld(endPointWorld);
		base.transform.position = vector;
		base.transform.rotation = Quaternion.LookRotation((vector2 - vector).normalized, Vector3.up);
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(vector2, vector));
		float num = Vector3.Distance(vector2, vector);
		ParticleSystem.MainModule main = originParticleSystem.main;
		float num2 = num * flameLength;
		main.startLifetime = new ParticleSystem.MinMaxCurve(lifetimeRandomMin * num2, lifetimeRandomMax * num2);
	}
}
