using UnityEngine;

public class GravityMachineAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip workingClip;

	protected override void Initialize()
	{
		if (base.AudioSource != null)
		{
			base.AudioSource.clip = workingClip;
			base.AudioSource.volume = 0.25f;
			base.AudioSource.priority = 128;
			base.AudioSource.loop = true;
			base.AudioSource.Play();
		}
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
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
