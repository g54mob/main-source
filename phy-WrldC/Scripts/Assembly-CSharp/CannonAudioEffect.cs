using UnityEngine;

[RequireComponent(typeof(Cannon))]
public class CannonAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip fireClip;

	[SerializeField]
	private AudioClip emptyClip;

	private AudioEffectData fireAudioData;

	private AudioEffectData emptyAudioData;

	protected override void Initialize()
	{
		Cannon component = GetComponent<Cannon>();
		component.OnFireEvent += OnFireHandler;
		component.OnEmptyEvent += OnEmptyHandler;
		fireAudioData = new AudioEffectData
		{
			AudioClip = fireClip,
			LoudnessIntensity = AudioEffectData.Loudness.High,
			Volume = 1f,
			Priority = 64
		};
		emptyAudioData = new AudioEffectData
		{
			AudioClip = emptyClip,
			LoudnessIntensity = AudioEffectData.Loudness.Medium,
			Volume = 0.7f,
			Priority = 128
		};
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		fireClip = gameStylesData.componentStylesData.cannonFireClip;
		emptyClip = gameStylesData.componentStylesData.cannonEmptyClip;
		if (fireAudioData != null)
		{
			fireAudioData.AudioClip = fireClip;
		}
		if (emptyAudioData != null)
		{
			emptyAudioData.AudioClip = emptyClip;
		}
		if (gameStylesData.volumeStylesData != null)
		{
			fireAudioData.Volume = gameStylesData.volumeStylesData.cannonFire;
			emptyAudioData.Volume = gameStylesData.volumeStylesData.cannonEmpty;
		}
	}

	private void OnFireHandler(Vector3 firePosition, Vector3 fireDirection)
	{
		PlayOnceEffect(fireAudioData, base.transform.position);
	}

	private void OnEmptyHandler()
	{
		PlayOnceEffect(emptyAudioData, base.transform.position);
	}
}
