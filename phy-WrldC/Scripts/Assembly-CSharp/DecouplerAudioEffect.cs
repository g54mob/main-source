using UnityEngine;

[RequireComponent(typeof(Decoupler))]
public class DecouplerAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip activatedClip;

	private AudioEffectData audioData;

	protected override void Initialize()
	{
		GetComponent<Decoupler>().OnActivatedEvent += OnActivatedHandler;
		audioData = new AudioEffectData
		{
			AudioClip = activatedClip,
			LoudnessIntensity = AudioEffectData.Loudness.Medium,
			Volume = 0.5f,
			Priority = 128
		};
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		activatedClip = gameStylesData.componentStylesData.decouplerActivatedClip;
		if (audioData != null)
		{
			audioData.AudioClip = activatedClip;
		}
		if (gameStylesData.volumeStylesData != null)
		{
			audioData.Volume = gameStylesData.volumeStylesData.decoupleActived;
		}
	}

	private void OnActivatedHandler()
	{
		PlayOnceEffect(audioData, base.transform.position);
	}
}
