using UnityEngine;

[RequireComponent(typeof(DynamicSpring))]
public class DynamicSpringAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip releasedClip;

	private AudioEffectData audioData;

	protected override void Initialize()
	{
		GetComponent<DynamicSpring>().OnReleasedEvent += OnReleasedHandler;
		audioData = new AudioEffectData
		{
			AudioClip = releasedClip,
			LoudnessIntensity = AudioEffectData.Loudness.Medium,
			Volume = 0.5f,
			Priority = 128
		};
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		releasedClip = gameStylesData.componentStylesData.decouplerActivatedClip;
		if (audioData != null)
		{
			audioData.AudioClip = releasedClip;
		}
		if (gameStylesData.volumeStylesData != null)
		{
			audioData.Volume = gameStylesData.volumeStylesData.decoupleActived;
		}
	}

	private void OnReleasedHandler()
	{
		PlayOnceEffect(audioData, base.transform.position);
	}
}
