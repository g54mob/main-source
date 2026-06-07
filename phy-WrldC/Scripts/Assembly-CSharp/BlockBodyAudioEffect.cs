using UnityEngine;

public class BlockBodyAudioEffect : RigidbodyAudioEffect
{
	[SerializeField]
	private AudioClip blockDestroyedClip;

	private AudioEffectData audioData;

	protected override void Initialize()
	{
		base.Initialize();
		base.gameObject.GetBlockView().BlockDestroyedEvent += BlockDestroyedHandler;
		audioData = new AudioEffectData
		{
			AudioClip = blockDestroyedClip,
			LoudnessIntensity = AudioEffectData.Loudness.Medium,
			Volume = 1f,
			Priority = 128
		};
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		blockDestroyedClip = gameStylesData.rigidbodyStylesData.blockDestroyedClip;
		if (audioData != null)
		{
			audioData.AudioClip = blockDestroyedClip;
		}
	}

	private void BlockDestroyedHandler()
	{
		PlayOnceEffect(audioData, base.transform.position);
		Debug.Log("Block Destroyed");
	}
}
