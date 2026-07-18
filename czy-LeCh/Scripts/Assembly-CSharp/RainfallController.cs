using UnityEngine;

public class RainfallController : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem ps;

	[SerializeField]
	private SoundManager soundManager;

	[SerializeField]
	private AudioClip rainSfx;

	public void StartRain()
	{
		ps.Play();
		soundManager.PlaySound(rainSfx, randomPitch: false);
	}
}
