using UnityEngine;

[RequireComponent(typeof(Piston))]
public class PistonAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip positionChangedClip;

	private AudioEffectData audioData;

	protected override void Initialize()
	{
		GetComponent<Piston>().OnPositionChangedEvent += OnPositionChangedHandler;
		audioData = new AudioEffectData
		{
			AudioClip = positionChangedClip,
			LoudnessIntensity = AudioEffectData.Loudness.Medium,
			Volume = 0.5f,
			Priority = 128
		};
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		positionChangedClip = gameStylesData.componentStylesData.pistonPositionChangedClip;
		if (audioData != null)
		{
			audioData.AudioClip = positionChangedClip;
		}
		if (gameStylesData.volumeStylesData != null)
		{
			audioData.Volume = gameStylesData.volumeStylesData.pistonMoving;
		}
	}

	private void OnPositionChangedHandler()
	{
		PlayOnceEffect(audioData, base.transform.position);
	}
}
