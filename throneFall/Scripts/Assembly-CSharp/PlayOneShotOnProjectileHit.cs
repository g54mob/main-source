using UnityEngine;

public class PlayOneShotOnProjectileHit : MonoBehaviour
{
	public AimbotProjectile target;

	public ThronefallAudioManager.AudioOneShot oneshot;

	private void Start()
	{
		target.onHit.AddListener(Play);
	}

	private void Play()
	{
		ThronefallAudioManager.WorldSpaceOneShot(oneshot, base.transform.position);
	}
}
