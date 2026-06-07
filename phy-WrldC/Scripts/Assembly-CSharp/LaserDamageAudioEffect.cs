using UnityEngine;

[RequireComponent(typeof(LaserDamage))]
public class LaserDamageAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip damagingClip;

	protected override void Initialize()
	{
		if (base.AudioSource != null)
		{
			base.AudioSource.clip = damagingClip;
			base.AudioSource.volume = 0.01f;
			base.AudioSource.priority = 128;
			base.AudioSource.loop = true;
		}
		GetComponent<LaserDamage>().OnLaserHitOrNotHitEvent += LaserHitOrNotHitHandler;
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		damagingClip = gameStylesData.rigidbodyStylesData.laserDamagingClip;
		if (base.AudioSource != null)
		{
			base.AudioSource.clip = damagingClip;
			if (gameStylesData.volumeStylesData != null)
			{
				base.AudioSource.volume = gameStylesData.volumeStylesData.laserEmitterDamaging;
			}
		}
	}

	private void LaserHitOrNotHitHandler(bool isObjectHit, Vector3 hitPoint)
	{
		if (!(base.AudioSource == null) && !base.AudioEffectsManager.IsAudioSourcesInPause)
		{
			base.AudioSource.transform.position = hitPoint;
			if (isObjectHit && !base.AudioSource.isPlaying)
			{
				base.AudioSource.Play();
			}
			else if (!isObjectHit && base.AudioSource.isPlaying)
			{
				base.AudioSource.Stop();
			}
		}
	}
}
