using UnityEngine;

public class Explosion : MonoBehaviour
{
	public bool playExplosionOnAwake;

	public float explosionRadius;

	public float enemyCloseDamage = 500f;

	public float enemyFarDamage = 100f;

	public float playerCloseDamage = 100f;

	public float playerFarDamage = 45f;

	public float camShakeIntensity = 0.6f;

	private void Start()
	{
		if (playExplosionOnAwake)
		{
			PlayExplosion();
		}
	}

	public void PlayExplosion()
	{
		ClientPlayer.Instance.playerMan.camShake.intensity = camShakeIntensity;
		Hittable[] array = Object.FindObjectsOfType<Hittable>();
		foreach (Hittable hittable in array)
		{
			if (Vector3.Distance(hittable.transform.position, base.transform.position) < explosionRadius - explosionRadius / 2f)
			{
				hittable.Hit(enemyCloseDamage, base.transform.position, alwaysTriggerDamageReaction: true);
			}
			else if (Vector3.Distance(hittable.transform.position, base.transform.position) < explosionRadius)
			{
				hittable.Hit(enemyFarDamage, base.transform.position, alwaysTriggerDamageReaction: true);
			}
		}
		if (Vector3.Distance(ClientPlayer.Instance.transform.position, base.transform.position) < explosionRadius - explosionRadius / 2f)
		{
			ClientPlayer.Instance.playerMan.TakeDamage(playerCloseDamage, significantAnim: true);
		}
		else if (Vector3.Distance(ClientPlayer.Instance.transform.position, base.transform.position) < explosionRadius)
		{
			ClientPlayer.Instance.playerMan.TakeDamage(playerFarDamage, significantAnim: true);
		}
	}
}
