using System;
using UnityEngine;

public class PingMarker : MonoBehaviour
{
	[Header("Refs")]
	[SerializeField]
	private Transform visualRoot;

	[SerializeField]
	private SpriteRenderer icon;

	[Header("Scale / Pulse Curves")]
	[SerializeField]
	private AnimationCurve spawnScale;

	[SerializeField]
	private AnimationCurve idlePulse;

	[SerializeField]
	private float spawnDuration;

	[Header("FX")]
	[SerializeField]
	private AudioSource markAudioSource;

	[SerializeField]
	private float bobAmplitude;

	[SerializeField]
	private float bobSpeed;

	[SerializeField]
	[Range(0.01f, 1f)]
	private float fadeOutFrac;

	[Header("Toggles")]
	[SerializeField]
	[Tooltip("Doğuşta büyüme eğrisi")]
	private bool enableSpawnScale;

	[SerializeField]
	[Tooltip("Idle pulsation")]
	private bool enableIdlePulse;

	[SerializeField]
	[Tooltip("Yukarı-aşağı salınım")]
	private bool enableBobbing;

	[SerializeField]
	[Tooltip("LookTarget'a dön")]
	private bool enableLookAtTarget;

	[SerializeField]
	[Tooltip("Süre sonuna doğru şeffaflaşma")]
	private bool enableFadeOut;

	[SerializeField]
	[Tooltip("Ölçek çarpanını baseScale ile sınırla")]
	private bool clampScaleToBase;

	private float _ttl;

	private float _age;

	private float _baseScale;

	private Transform _lookTarget;

	public Action<PingMarker> onDespawn;

	private void Awake()
	{
	}

	public void SetOwnerColor(Color c)
	{
	}

	public void SetLookTarget(Transform t)
	{
	}

	public void Play(float ttl)
	{
	}

	private void Update()
	{
	}
}
