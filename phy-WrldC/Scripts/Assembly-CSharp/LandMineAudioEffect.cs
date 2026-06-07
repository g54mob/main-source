using UnityEngine;

[RequireComponent(typeof(LandMine))]
public class LandMineAudioEffect : RigidbodyAudioEffect
{
	[SerializeField]
	private AudioClip beepClip;

	[SerializeField]
	private AudioClip explosionClip;

	private LandMine landMine;

	private AudioEffectData beepAudioData;

	private AudioEffectData explosionAudioData;

	protected override void Initialize()
	{
		base.Initialize();
		landMine = GetComponent<LandMine>();
		landMine.OnBeepEvent += OnBeepHandler;
		landMine.OnExplosionEvent += OnExplosionHandler;
		beepAudioData = new AudioEffectData
		{
			AudioClip = beepClip,
			LoudnessIntensity = AudioEffectData.Loudness.Medium,
			Volume = 1f,
			Priority = 128
		};
		explosionAudioData = new AudioEffectData
		{
			AudioClip = explosionClip,
			LoudnessIntensity = AudioEffectData.Loudness.VeryHigh,
			Volume = 1f,
			Priority = 64
		};
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		beepClip = gameStylesData.rigidbodyStylesData.landMineBeepClip;
		explosionClip = gameStylesData.rigidbodyStylesData.landMineExplosionClip;
		if (beepAudioData != null)
		{
			beepAudioData.AudioClip = beepClip;
		}
		if (explosionAudioData != null)
		{
			explosionAudioData.AudioClip = explosionClip;
		}
		if (gameStylesData.volumeStylesData != null)
		{
			if (beepAudioData != null)
			{
				beepAudioData.Volume = gameStylesData.volumeStylesData.landMineBeep;
			}
			if (explosionAudioData != null)
			{
				explosionAudioData.Volume = gameStylesData.volumeStylesData.landMineExplosion;
			}
		}
	}

	private void OnBeepHandler()
	{
		if (!(beepClip == null))
		{
			PlayOnceEffect(beepAudioData, base.transform.position);
		}
	}

	private void OnExplosionHandler()
	{
		if (!(explosionClip == null))
		{
			PlayOnceEffect(explosionAudioData, base.transform.position);
		}
	}
}
