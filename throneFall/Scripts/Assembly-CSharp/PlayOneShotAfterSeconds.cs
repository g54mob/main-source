using UnityEngine;

public class PlayOneShotAfterSeconds : MonoBehaviour
{
	public float initialDelay = 1f;

	public ThronefallAudioManager.AudioOneShot type;

	private float timer;

	private void Update()
	{
		if (timer <= initialDelay)
		{
			timer += Time.deltaTime;
			if (timer > initialDelay)
			{
				ThronefallAudioManager.WorldSpaceOneShot(type, base.transform.position);
			}
		}
	}
}
