using UnityEngine;

public class ProjectileSpawnAudio : MonoBehaviour
{
	public ThronefallAudioManager.AudioOneShot oneShotType;

	private void Start()
	{
		ThronefallAudioManager.WorldSpaceOneShot(oneShotType, base.transform.position);
	}
}
