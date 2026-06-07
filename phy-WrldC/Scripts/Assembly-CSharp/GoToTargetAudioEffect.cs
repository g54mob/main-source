using UnityEngine;

[RequireComponent(typeof(GoToTarget))]
public class GoToTargetAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip movingClip;

	private float volume;

	protected override void Initialize()
	{
		GetComponent<GoToTarget>().OnMovingToTargetEvent += OnMovingToTargetHandler;
		if (base.AudioSource != null)
		{
			base.AudioSource.volume = volume;
			base.AudioSource.priority = 128;
			base.AudioSource.loop = true;
		}
	}

	protected override void Update()
	{
		base.Update();
		if (!(base.AudioSource == null) && !base.AudioEffectsManager.IsAudioSourcesInPause && base.AudioSource.isPlaying)
		{
			base.AudioSource.transform.position = base.transform.position;
		}
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		movingClip = gameStylesData.rigidbodyStylesData.motorClip;
		if (gameStylesData.volumeStylesData != null)
		{
			volume = gameStylesData.volumeStylesData.animatorByButton;
		}
	}

	private void OnMovingToTargetHandler(bool isMoving, float currentSpeed, float maxSpeed)
	{
		if (base.AudioSource == null || base.AudioEffectsManager.IsAudioSourcesInPause)
		{
			return;
		}
		if (isMoving && movingClip != null)
		{
			base.AudioSource.clip = movingClip;
			base.AudioSource.volume = volume * (currentSpeed / maxSpeed);
			if (!base.AudioSource.isPlaying)
			{
				base.AudioSource.Play();
			}
		}
		else if (base.AudioSource.isPlaying)
		{
			base.AudioSource.Stop();
		}
	}
}
