using UnityEngine;

[RequireComponent(typeof(SteerableBlock))]
public class SteerableBlockAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip positionChangedClip;

	private AudioEffectData audioData;

	protected override void Initialize()
	{
		GetComponent<SteerableBlock>().OnPositionChangedEvent += OnPositionChangedHandler;
		audioData = new AudioEffectData
		{
			AudioClip = positionChangedClip,
			LoudnessIntensity = AudioEffectData.Loudness.Medium,
			Volume = 0.1f,
			Priority = 128
		};
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		positionChangedClip = gameStylesData.componentStylesData.steerablePositionChangedClip;
		if (audioData != null)
		{
			audioData.AudioClip = positionChangedClip;
		}
		if (gameStylesData.volumeStylesData != null)
		{
			audioData.Volume = gameStylesData.volumeStylesData.steerableBlockMoving;
		}
	}

	private void OnPositionChangedHandler()
	{
		PlayOnceEffect(audioData, base.transform.position);
	}
}
