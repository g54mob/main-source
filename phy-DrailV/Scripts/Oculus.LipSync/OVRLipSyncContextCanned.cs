using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OVRLipSyncContextCanned : OVRLipSyncContextBase
{
	[Tooltip("Pre-computed viseme sequence asset. Compute from audio in Unity with Tools -> Oculus -> Generate Lip Sync Assets.")]
	public OVRLipSyncSequence currentSequence;

	private void Update()
	{
		if (audioSource.isPlaying && currentSequence != null)
		{
			OVRLipSync.Frame frameAtTime = currentSequence.GetFrameAtTime(audioSource.time);
			base.Frame.CopyInput(frameAtTime);
		}
	}
}
