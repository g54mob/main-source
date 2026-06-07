using UnityEngine;

[RequireComponent(typeof(LaserButton))]
public class LaserButtonAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip turnOnClip;

	[SerializeField]
	private AudioClip turnOffClip;

	private LaserButton laserButton;

	private AudioEffectData turnOnAudioData;

	private AudioEffectData turnOffAudioData;

	protected override void Initialize()
	{
		laserButton = GetComponent<LaserButton>();
		laserButton.OnChangedState += ButtonChangedStateHandler;
		turnOnAudioData = new AudioEffectData
		{
			AudioClip = turnOnClip,
			LoudnessIntensity = AudioEffectData.Loudness.Medium,
			Volume = 0.25f,
			Priority = 128
		};
		turnOffAudioData = new AudioEffectData
		{
			AudioClip = turnOffClip,
			LoudnessIntensity = AudioEffectData.Loudness.Medium,
			Volume = 0.25f,
			Priority = 128
		};
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		if (turnOnAudioData != null)
		{
			turnOnAudioData.AudioClip = gameStylesData.rigidbodyStylesData.laserButtonOnClip;
		}
		if (turnOffAudioData != null)
		{
			turnOffAudioData.AudioClip = gameStylesData.rigidbodyStylesData.laserButtonOffClip;
		}
		if ((bool)gameStylesData.volumeStylesData)
		{
			if (turnOnAudioData != null)
			{
				turnOnAudioData.Volume = gameStylesData.volumeStylesData.laserButtonTurnOn;
			}
			if (turnOffAudioData != null)
			{
				turnOffAudioData.Volume = gameStylesData.volumeStylesData.laserButtonTurnOff;
			}
		}
	}

	private void ButtonChangedStateHandler(bool isOn)
	{
		if (isOn && turnOnClip != null)
		{
			PlayOnceEffect(turnOnAudioData, base.transform.position);
		}
		else if (turnOffClip != null)
		{
			PlayOnceEffect(turnOffAudioData, base.transform.position);
		}
	}
}
