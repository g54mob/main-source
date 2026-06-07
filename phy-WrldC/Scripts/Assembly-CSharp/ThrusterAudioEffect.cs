using UnityEngine;

[RequireComponent(typeof(Thruster))]
public class ThrusterAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip thrusterClip;

	private Thruster thruster;

	private float maxVolume;

	private float maxPitch;

	protected override void Initialize()
	{
		thruster = GetComponent<Thruster>();
		maxVolume = 0.5f;
		maxPitch = 1.5f;
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		thrusterClip = gameStylesData.componentStylesData.thrusterClip;
	}

	protected override void Update()
	{
		base.Update();
		if (base.AudioSource == null || base.AudioEffectsManager.IsAudioSourcesInPause)
		{
			return;
		}
		base.AudioSource.transform.position = base.transform.position;
		if (thruster.CurrentThrust > 0f)
		{
			if (!base.AudioSource.isPlaying)
			{
				base.AudioSource.clip = thrusterClip;
				base.AudioSource.priority = 128;
				base.AudioSource.loop = true;
				base.AudioSource.Play();
			}
			float num = thruster.CurrentThrust / thruster.MaxThrust;
			base.AudioSource.volume = maxVolume * num;
			base.AudioSource.pitch = maxPitch * num;
		}
		else if (base.AudioSource.isPlaying)
		{
			base.AudioSource.Stop();
		}
	}
}
