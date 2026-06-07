using UnityEngine;

[RequireComponent(typeof(TNTCrate))]
public class TNTCrateAudioEffect : RigidbodyAudioEffect
{
	[SerializeField]
	private AudioClip explosionClip;

	private AudioEffectData audioData;

	protected override void Initialize()
	{
		base.Initialize();
		GetComponent<TNTCrate>().OnExplosionEvent += OnExplosionHandler;
		audioData = new AudioEffectData
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
		explosionClip = gameStylesData.rigidbodyStylesData.tntCrateExplosionClip;
		if (audioData != null)
		{
			audioData.AudioClip = explosionClip;
		}
		if ((bool)gameStylesData.volumeStylesData && audioData != null)
		{
			audioData.Volume = gameStylesData.volumeStylesData.tntCrateExplosion;
		}
	}

	private void OnExplosionHandler()
	{
		if (!(explosionClip == null))
		{
			PlayOnceEffect(audioData, base.transform.position);
		}
	}
}
