using UnityEngine;

[RequireComponent(typeof(Grabber))]
public class GrabberAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip turnOnClip;

	[SerializeField]
	private AudioClip turnOffClip;

	[SerializeField]
	private AudioClip grabbedClip;

	private AudioEffectData turnedOnOffAudioData;

	private AudioEffectData grabbedAudioData;

	protected override void Initialize()
	{
		Grabber component = GetComponent<Grabber>();
		component.OnTurnedOnOffEvent += OnTurnedOnOffHandler;
		component.OnGrabbedEvent += OnGrabbedHandler;
		turnedOnOffAudioData = new AudioEffectData
		{
			LoudnessIntensity = AudioEffectData.Loudness.Medium,
			Volume = 0.7f,
			Priority = 128
		};
		grabbedAudioData = new AudioEffectData
		{
			AudioClip = grabbedClip,
			LoudnessIntensity = AudioEffectData.Loudness.Medium,
			Volume = 0.7f,
			Priority = 128
		};
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		turnOnClip = gameStylesData.componentStylesData.grabberTurnOnClip;
		turnOffClip = gameStylesData.componentStylesData.grabberTurnOffClip;
		grabbedClip = gameStylesData.componentStylesData.grabberGrabbedClip;
		if (grabbedAudioData != null)
		{
			grabbedAudioData.AudioClip = grabbedClip;
		}
		if (gameStylesData.volumeStylesData != null)
		{
			turnedOnOffAudioData.Volume = gameStylesData.volumeStylesData.grabberTurnOnOff;
			grabbedAudioData.Volume = gameStylesData.volumeStylesData.grabberGrabbed;
		}
	}

	private void OnTurnedOnOffHandler(bool isOn)
	{
		if (isOn && turnOnClip != null)
		{
			turnedOnOffAudioData.AudioClip = turnOnClip;
		}
		else
		{
			if (isOn || !(turnOffClip != null))
			{
				return;
			}
			turnedOnOffAudioData.AudioClip = turnOffClip;
		}
		PlayOnceEffect(turnedOnOffAudioData, base.transform.position);
	}

	private void OnGrabbedHandler()
	{
		if (!(grabbedClip == null))
		{
			PlayOnceEffect(grabbedAudioData, base.transform.position);
		}
	}
}
