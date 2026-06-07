using UnityEngine;

[RequireComponent(typeof(LevelButtonBase))]
public class LevelButtonAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip buttonOnClip;

	[SerializeField]
	private AudioClip buttonOffClip;

	private AudioEffectData audioData;

	protected override void Initialize()
	{
		GetComponent<LevelButtonBase>().OnChangedState += OnChangedStateHandler;
		audioData = new AudioEffectData
		{
			LoudnessIntensity = AudioEffectData.Loudness.Medium,
			Volume = 1f,
			Priority = 128
		};
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		buttonOnClip = gameStylesData.rigidbodyStylesData.levelButtonOnClip;
		buttonOffClip = gameStylesData.rigidbodyStylesData.levelButtonOffClip;
		if (gameStylesData.volumeStylesData != null && audioData != null)
		{
			audioData.Volume = gameStylesData.volumeStylesData.levelButtonTurnOnOff;
		}
	}

	private void OnChangedStateHandler(bool isOn)
	{
		if (!(buttonOnClip == null) && !(buttonOffClip == null))
		{
			audioData.AudioClip = (isOn ? buttonOnClip : buttonOffClip);
			PlayOnceEffect(audioData, base.transform.position);
		}
	}
}
