using UnityEngine;

public class BossProjectileTargetMarker : MonoBehaviour
{
	public AimbotProjectile projectile;

	public Transform targetMarker;

	private void Update()
	{
		targetMarker.position = projectile.rememberTarget;
		targetMarker.rotation = Quaternion.Euler(-90f, 0f, 0f);
	}
}
