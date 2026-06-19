using System;
using Unity.Mathematics;
using UnityEngine;

public class HydraBossHeadController : MonoBehaviour
{
	[Serializable]
	public class RecordableTransform
	{
		[HideInInspector]
		public string name;

		public Transform transform;

		public Quaternion openRotation;

		public Quaternion closedRotation;

		public bool recordOpen;

		public bool recordClosed;

		public bool setOpen;

		public bool setClosed;

		public void Validate()
		{
			name = (transform ? transform.name : null);
			if (recordOpen)
			{
				if (!Application.isPlaying)
				{
					openRotation = transform.localRotation;
				}
				recordOpen = false;
			}
			if (recordClosed)
			{
				if (!Application.isPlaying)
				{
					closedRotation = transform.localRotation;
				}
				recordClosed = false;
			}
			if (setOpen)
			{
				if (!Application.isPlaying)
				{
					transform.localRotation = openRotation;
				}
				setOpen = false;
			}
			if (setClosed)
			{
				if (!Application.isPlaying)
				{
					transform.localRotation = closedRotation;
				}
				setClosed = false;
			}
		}

		public void SetClosed(float closedAmount)
		{
			transform.localRotation = Quaternion.LerpUnclamped(openRotation, closedRotation, closedAmount);
		}

		public void SetOpen(float openAmount)
		{
			transform.localRotation = Quaternion.LerpUnclamped(closedRotation, openRotation, openAmount);
		}
	}

	public RecordableTransform[] eyeLids;

	public RecordableTransform jaw;

	public HydraTongueController tongue;

	public MeshRenderer biteRenderer;

	public GameObject normalEyes;

	public GameObject ghostEyes;

	[Range(0f, 1f)]
	public float eyesClosed;

	[Range(0f, 4f)]
	public float mouthOpen;

	[Min(0f)]
	public float blinkDuration = 0.1f;

	public float blinkCooldownMin = 1f;

	public float blinkCooldownMax = 2f;

	public bool forceEyesClosed;

	public ParticleSystem biteParticles;

	public ParticleSystem vulnerableParticles;

	public ParticleSystem anticipationParticles;

	public Transform screamEffectReferencePoint;

	public Transform conditionEffectReferencePoint;

	private Material m_biteMaterial;

	private float m_blinkTime;

	private float m_nextBlinkTime;

	private static int _AnimationStartTime = Shader.PropertyToID("_AnimationStartTime");

	private Vector3 m_jawPosition;

	private void Awake()
	{
		m_biteMaterial = UnityEngine.Object.Instantiate(biteRenderer.material);
		biteRenderer.material = m_biteMaterial;
		m_biteMaterial.SetFloat(_AnimationStartTime, -1f);
		m_jawPosition = jaw.transform.localPosition;
	}

	private void OnValidate()
	{
		for (int i = 0; i < eyeLids.Length; i++)
		{
			eyeLids[i].Validate();
		}
		jaw.Validate();
	}

	private void Update()
	{
		if (Time.time > m_nextBlinkTime)
		{
			Blink();
		}
		float x = Time.time - m_blinkTime;
		eyesClosed = (forceEyesClosed ? 1f : (smoothstep(0f, blinkDuration * 0.5f, x) * smoothstep(blinkDuration, blinkDuration * 0.5f, x)));
		for (int i = 0; i < eyeLids.Length; i++)
		{
			eyeLids[i].SetClosed(eyesClosed);
		}
		jaw.SetOpen(mouthOpen);
		float x2 = Time.time * 20f;
		float num = Mathf.Max(0f, mouthOpen - 1f) * 0.15f;
		jaw.transform.localPosition = m_jawPosition + new Vector3(Mathf.PerlinNoise(x2, 0f), Mathf.PerlinNoise(x2, 1f), 0f) * num;
		if (tongue != null)
		{
			tongue.extended = math.smoothstep(1f, 0.5f, mouthOpen) * math.smoothstep(0.75f, 0.9f, math.sin(Time.time * MathF.PI * 0.5f)) * (float)((!forceEyesClosed) ? 1 : 0);
		}
	}

	public void Blink()
	{
		m_blinkTime = Time.time;
		m_nextBlinkTime = Time.time + UnityEngine.Random.Range(blinkCooldownMin, blinkCooldownMax);
	}

	public void PlayBiteEffect()
	{
		m_biteMaterial.SetFloat(_AnimationStartTime, Time.time);
		biteParticles.Play();
	}

	public void PlayVulnerableEffect()
	{
		vulnerableParticles.Play();
		Manager.camera.ShakeCameraNow(0.3f, 0.3f, 1.3f);
	}

	public void PlayAnticipationEffect()
	{
		if (anticipationParticles != null)
		{
			anticipationParticles.Play();
		}
	}

	private float smoothstep(float edge0, float edge1, float x)
	{
		x = Mathf.Clamp01((x - edge0) / (edge1 - edge0));
		return x * x * (3f - 2f * x);
	}
}
