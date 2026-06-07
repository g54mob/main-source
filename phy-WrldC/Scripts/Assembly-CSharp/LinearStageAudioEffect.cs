using UnityEngine;

[RequireComponent(typeof(LinearStage))]
public class LinearStageAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip positionChangingClip;

	private float positionChangingVolume;

	protected override void Initialize()
	{
		LinearStage component = GetComponent<LinearStage>();
		component.OnPositionChangingEvent += OnPositionChangingHandler;
		component.OnNotPositionChangingEvent += OnNotPositionChangingHandler;
		positionChangingVolume = 0.5f;
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		positionChangingClip = gameStylesData.componentStylesData.linearPositionChangingClip;
		if (gameStylesData.volumeStylesData != null)
		{
			positionChangingVolume = gameStylesData.volumeStylesData.linearStageMoving;
		}
	}

	private void OnPositionChangingHandler()
	{
		if (base.AudioSource != null && !base.AudioSource.isPlaying)
		{
			base.AudioSource.clip = positionChangingClip;
			base.AudioSource.volume = positionChangingVolume;
			base.AudioSource.priority = 128;
			base.AudioSource.loop = true;
			base.AudioSource.Play();
		}
		if (base.AudioSource != null)
		{
			base.AudioSource.transform.position = base.transform.position;
		}
	}

	private void OnNotPositionChangingHandler()
	{
		RecycleAudioSource();
	}

	private void OnBlockDestroyedHandler()
	{
		RecycleAudioSource();
	}
}
