using UnityEngine;

[RequireComponent(typeof(LaserRayBase))]
public class LaserEmitterAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip workingClip;

	protected override void Initialize()
	{
		if (base.AudioSource != null)
		{
			base.AudioSource.clip = workingClip;
			base.AudioSource.volume = 0.7f;
			base.AudioSource.priority = 128;
			base.AudioSource.loop = true;
			base.AudioSource.Play();
		}
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		workingClip = gameStylesData.rigidbodyStylesData.laserEmitterWorkingClip;
		if (base.AudioSource != null)
		{
			base.AudioSource.clip = workingClip;
			if (gameStylesData.volumeStylesData != null)
			{
				base.AudioSource.volume = gameStylesData.volumeStylesData.laserEmitterWorking;
			}
		}
	}

	protected override void Update()
	{
		base.Update();
		if (base.AudioSource != null)
		{
			base.AudioSource.transform.position = base.transform.position;
		}
	}
}
