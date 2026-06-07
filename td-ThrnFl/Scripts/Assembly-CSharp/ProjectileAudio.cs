using UnityEngine;

public class ProjectileAudio : MonoBehaviour
{
	public enum ProjectileType
	{
		Catapult = 0
	}

	public AimbotProjectile target;

	public AudioSource aSource;

	public ProjectileType projectile;

	public float pitchrange = 0.2f;

	private void Start()
	{
		if (target != null)
		{
			target.onHit.AddListener(PlayImpact);
		}
		if (projectile == ProjectileType.Catapult)
		{
			aSource.clip = ThronefallAudioManager.Instance.audioContent.CatapultImpact.GetRandomClip();
		}
		aSource.pitch = Random.Range(1f - pitchrange, 1f + pitchrange);
	}

	private void PlayImpact()
	{
		aSource.Play();
		aSource.transform.parent = null;
		Object.Destroy(aSource.gameObject, aSource.clip.length);
	}
}
