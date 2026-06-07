using System;
using System.Collections;
using UnityEngine;

public class AutoAttack_overTime_laser : AutoAttack_overTime
{
	[Serializable]
	private struct FVFXConfig
	{
		public ParticleSystem impactParticles;

		public float lineRendererWidthMultiplier;

		public AudioData sound;
	}

	[Header("VFX")]
	[SerializeField]
	private GameObject warmUpParticles;

	[SerializeField]
	private AudioData warmupSound;

	[SerializeField]
	private LineRenderer lineRenderer;

	[SerializeField]
	private float lineRendererTravelSpeed = 1f;

	[SerializeField]
	private FVFXConfig[] vfxConfig;

	private CapsuleCollider targetCapsuleCollider;

	private Coroutine updateLineRendererCoroutine;

	private GameObject currentWarmupParticles;

	private ParticleSystem currentImpactParticles;

	private Vector3 lineRendererTipPosition;

	private AudioSource currentAudioSource;

	protected override void Start()
	{
		base.Start();
		lineRenderer.gameObject.SetActive(value: false);
		base.ShootTransform = (abilityManager.CombatComponent as TowerCombatComponent).ShootTransform;
	}

	protected override void OnStartWarmup()
	{
		base.OnStartWarmup();
		currentWarmupParticles = UnityEngine.Object.Instantiate(warmUpParticles, base.ShootTransform.position, Quaternion.identity, abilityManager.gameObject.transform);
		if (warmupSound.AudioClips.Length != 0)
		{
			currentAudioSource = AudioSystem.Instance.PlaySound3D(warmupSound, base.ShootTransform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Custom, 1f, 50f);
		}
	}

	protected override void OnStartDamage()
	{
		base.OnStartDamage();
		if ((bool)base.Target)
		{
			targetCapsuleCollider = base.Target.GetComponent<CapsuleCollider>();
			lineRenderer.gameObject.SetActive(value: true);
			lineRenderer.transform.position = base.ShootTransform.position;
			lineRenderer.widthMultiplier = vfxConfig[0].lineRendererWidthMultiplier;
			this.StartCoroutineCheckingVar(UpdateLineRendererCoroutine(), ref updateLineRendererCoroutine);
		}
	}

	protected override void OnDamageIndexChanged(int newIndex)
	{
		if ((bool)base.Target)
		{
			if ((bool)currentImpactParticles)
			{
				currentImpactParticles.Stop(withChildren: true);
			}
			currentImpactParticles = UnityEngine.Object.Instantiate(vfxConfig[newIndex].impactParticles, base.Target.transform.position, Quaternion.identity);
			lineRenderer.widthMultiplier = vfxConfig[newIndex].lineRendererWidthMultiplier;
			if ((bool)currentAudioSource)
			{
				currentAudioSource.Stop();
			}
			if (vfxConfig[newIndex].sound.AudioClips.Length != 0)
			{
				currentAudioSource = AudioSystem.Instance.PlaySound3D(vfxConfig[newIndex].sound, base.ShootTransform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Custom, 1f, 50f, null, 0f, 0f, loop: true);
			}
		}
	}

	protected override void OnEndAbility(bool canceled)
	{
		base.OnEndAbility(canceled);
		lineRenderer.gameObject.SetActive(value: false);
		if ((bool)currentWarmupParticles)
		{
			UnityEngine.Object.Destroy(currentWarmupParticles.gameObject);
		}
		if ((bool)currentAudioSource)
		{
			currentAudioSource.Stop();
			currentAudioSource = null;
		}
		if ((bool)currentImpactParticles)
		{
			currentImpactParticles.Stop(withChildren: true);
		}
		this.StopCoroutineCheckingVar(ref updateLineRendererCoroutine);
	}

	private IEnumerator UpdateLineRendererCoroutine()
	{
		lineRenderer.SetPosition(0, base.ShootTransform.position);
		lineRendererTipPosition = base.ShootTransform.position;
		while (true)
		{
			Vector3 position = base.Target.TargetObject.transform.position;
			lineRendererTipPosition = Vector3.MoveTowards(lineRendererTipPosition, position, lineRendererTravelSpeed * Time.deltaTime);
			lineRenderer.SetPosition(1, lineRendererTipPosition);
			lineRenderer.gameObject.transform.rotation = Quaternion.LookRotation(position - lineRenderer.transform.position);
			currentImpactParticles.transform.position = position;
			yield return null;
		}
	}
}
