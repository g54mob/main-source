using UnityEngine;

public class CoalAudio : DebouncedSound
{
	public AudioClip detach;

	private void OnJointBreak(float breakForce)
	{
		if (detach != null)
		{
			PlayDebounced(detach, base.transform.position, 1f);
		}
	}
}
