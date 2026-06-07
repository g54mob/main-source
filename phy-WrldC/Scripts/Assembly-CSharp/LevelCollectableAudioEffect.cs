using UnityEngine;

[RequireComponent(typeof(LevelCollectable))]
public class LevelCollectableAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip collectedClip;

	private LevelCollectable levelCollectable;

	private AudioEffectData collectedAudioData;

	protected override void Initialize()
	{
		levelCollectable = GetComponent<LevelCollectable>();
		levelCollectable.OnCollectedEvent += CollectedHandler;
		collectedAudioData = new AudioEffectData
		{
			AudioClip = collectedClip,
			LoudnessIntensity = AudioEffectData.Loudness.Medium,
			Volume = 1f,
			Priority = 128
		};
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		collectedClip = gameStylesData.rigidbodyStylesData.collectedClip;
		if (collectedAudioData != null)
		{
			collectedAudioData.AudioClip = collectedClip;
		}
	}

	private void CollectedHandler(LevelCollectable.CollectableType type)
	{
		if (collectedAudioData != null)
		{
			PlayOnceEffect(collectedAudioData, base.transform.position);
		}
	}
}
