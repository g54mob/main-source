using UnityEngine;

public class MultipleUnitHoseAudio : HoseAudioBase
{
	[Header("Hose sounds")]
	public AudioClip connectSound;

	public AudioClip disconnectSound;

	public override void PlayConnectSound()
	{
		connectSound.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
	}

	public override void PlayDisconnectSound()
	{
		disconnectSound.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
	}
}
