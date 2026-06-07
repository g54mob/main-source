using UnityEngine;

[RequireComponent(typeof(SolidRocket))]
public class SolidRocketAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip thrustClip;

	[SerializeField]
	private AudioClip startClip;

	private SolidRocket solidRocket;

	private float maxVolume;

	private float maxPitch;

	private AudioEffectData startAudioData;

	protected override void Initialize()
	{
		solidRocket = GetComponent<SolidRocket>();
		maxVolume = 0.3f;
		maxPitch = 1f;
		startAudioData = new AudioEffectData
		{
			AudioClip = startClip,
			LoudnessIntensity = AudioEffectData.Loudness.High,
			Volume = 0.1f,
			Priority = 128
		};
		solidRocket.OnStartEvent += delegate
		{
			PlayOnceEffect(startAudioData, base.transform.position);
		};
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		thrustClip = gameStylesData.componentStylesData.srbThrustClip;
		if (startAudioData != null)
		{
			startAudioData.AudioClip = gameStylesData.componentStylesData.srbStartClip;
		}
	}

	protected override void Update()
	{
		base.Update();
		if (base.AudioSource == null || base.AudioEffectsManager.IsAudioSourcesInPause)
		{
			return;
		}
		base.AudioSource.transform.position = base.transform.position;
		if (solidRocket.CurrentThrust > 0f)
		{
			if (!base.AudioSource.isPlaying)
			{
				base.AudioSource.clip = thrustClip;
				base.AudioSource.priority = 128;
				base.AudioSource.loop = true;
				base.AudioSource.Play();
			}
			float num = solidRocket.CurrentThrust / solidRocket.MaxThrust;
			base.AudioSource.volume = maxVolume * num;
			base.AudioSource.pitch = maxPitch * num;
		}
		else if (base.AudioSource.isPlaying)
		{
			base.AudioSource.Stop();
		}
	}
}
