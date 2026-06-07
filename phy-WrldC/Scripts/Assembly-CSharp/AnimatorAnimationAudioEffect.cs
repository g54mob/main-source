using DG.Tweening;
using UnityEngine;

public class AnimatorAnimationAudioEffect : AudioEffectBase
{
	public enum SoundType
	{
		Motor = 0,
		Air = 1
	}

	[SerializeField]
	private SoundType soundType;

	[SerializeField]
	private AudioClip animationClip;

	[SerializeField]
	private bool shouldPlayClip;

	[SerializeField]
	[Range(0f, 1f)]
	private float volume = 0.4f;

	private Tween tween;

	protected override void Initialize()
	{
	}

	protected override void Update()
	{
		base.Update();
		if (base.AudioSource == null || base.AudioEffectsManager.IsAudioSourcesInPause)
		{
			return;
		}
		if (shouldPlayClip)
		{
			base.AudioSource.transform.position = base.transform.position;
			if (!base.AudioSource.isPlaying)
			{
				base.AudioSource.Play();
				base.AudioSource.DOFade(volume, 1f);
			}
		}
		else if (base.AudioSource.isPlaying && tween == null)
		{
			tween = base.AudioSource.DOFade(0f, 0.5f);
			tween.OnComplete(delegate
			{
				base.AudioSource.Stop();
				tween = null;
			});
		}
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		switch (soundType)
		{
		case SoundType.Motor:
			animationClip = gameStylesData.rigidbodyStylesData.motorClip;
			break;
		case SoundType.Air:
			animationClip = gameStylesData.rigidbodyStylesData.airClip;
			break;
		default:
			animationClip = gameStylesData.rigidbodyStylesData.motorClip;
			break;
		}
		if (gameStylesData.volumeStylesData != null)
		{
			volume = gameStylesData.volumeStylesData.animatorAnimation;
		}
		if (base.AudioSource != null)
		{
			base.AudioSource.clip = animationClip;
			base.AudioSource.volume = 0f;
			base.AudioSource.priority = 128;
			base.AudioSource.loop = true;
		}
	}
}
