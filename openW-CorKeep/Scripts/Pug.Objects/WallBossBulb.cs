using System;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class WallBossBulb : EntityMonoBehaviour
{
	[SerializeField]
	private GameObject m_bulbObject;

	[SerializeField]
	private MeshRenderer m_bulbRenderer;

	[SerializeField]
	private ParticleSystem m_burstParticles;

	[SerializeField]
	private ParticleSystem m_renewParticles;

	[SerializeField]
	public Transform ParticlePosition;

	[Header("Pulse Animation")]
	[Min(0f)]
	public float pulseSpeed = 1f;

	[Min(1f)]
	public float pulseLinger = 10f;

	[Range(0f, 1f)]
	public float pulseAmplitude = 1f;

	[Header("Shake (hit) Animation")]
	public float shakeFreq = 4f;

	public float shakeAmp = 1f;

	private Material m_bulbMaterial;

	private bool m_wasDisabled;

	private float m_damageTime;

	private float m_disableTime;

	private float m_timeOffset;

	private static int _ShadingExponent = Shader.PropertyToID("_ShadingExponent");

	protected override void Awake()
	{
		base.Awake();
		m_bulbMaterial = m_bulbRenderer.material;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		m_disableTime = -1f;
		m_timeOffset = UnityEngine.Random.value * MathF.PI * 2f;
	}

	public override void ManagedLateUpdate()
	{
		bool flag = false;
		if (EntityUtility.HasComponentData<DisablePhysicsCD>(base.entity, base.world))
		{
			flag = EntityUtility.IsComponentEnabled<DisablePhysicsCD>(base.entity, base.world);
		}
		Vector3 normalized = EntityMonoBehaviour.ToWorldFromRender(base.transform.position).normalized;
		base.transform.rotation = Quaternion.LookRotation(Vector3.Cross(Vector3.up, normalized), Vector3.up);
		m_bulbObject.SetActive(!flag);
		if (flag)
		{
			_ = m_wasDisabled;
		}
		if (flag)
		{
			m_disableTime = Time.time;
		}
		m_wasDisabled = flag;
		float num = Time.time * shakeFreq * 2f * MathF.PI + m_timeOffset;
		float num2 = shakeAmp * Mathf.Exp((0f - (Time.time - m_damageTime)) * 4f);
		if (num2 > Mathf.Epsilon)
		{
			Vector3 v = new Vector3(Mathf.Cos(num), Mathf.Cos(num + 1.8849558f), Mathf.Cos(num + 3.7699115f)) * num2;
			m_bulbObject.transform.localPosition = v.RoundToMultiple(0.0625f);
		}
		else
		{
			m_bulbObject.transform.localPosition = Vector3.zero;
		}
		MathUtilities.SteepSine(Time.time * pulseSpeed, pulseLinger);
		_ = pulseAmplitude;
		m_bulbObject.transform.localScale = Vector3.one * ((m_disableTime > 0f) ? (1f - Mathf.Exp((0f - (Time.time - m_disableTime)) * 5f)) : 1f);
		optionalHealthBar.gameObject.SetActive(!flag);
		if (!flag)
		{
			optionalHealthBar.transform.rotation = quaternion.identity;
		}
		m_bulbMaterial.SetFloat(_ShadingExponent, 3.5f + Mathf.Cos(Time.time * MathF.PI) * 1.5f);
	}

	protected override void OnTakeDamage()
	{
		base.OnTakeDamage();
		if (hasFlashable)
		{
			flashable.FlashLinearNoCurve(Color.red, 0.5f);
		}
		if (Manager.prefs.particleQuality != 0)
		{
			Manager.effects.PlayPuff(PuffID.WallBossHit, ParticlePosition.position, 8);
		}
		m_damageTime = Time.time;
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		switch (animID)
		{
		case 2053665356:
			m_burstParticles.Play();
			AudioManager.Sfx(SfxTableID.wallBossBulbSplatter, base.transform.position);
			break;
		case -350899940:
			m_renewParticles.Play();
			break;
		}
	}
}
