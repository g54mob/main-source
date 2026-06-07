using UnityEngine;

public class PopGunDart : MonoBehaviour
{
	[SerializeField]
	private Rigidbody rb;

	private bool _firstImpact = true;

	private void OnCollisionEnter(Collision _other)
	{
		if (_firstImpact)
		{
			rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
			AudioManager.Singleton.PlaySFX_PopGun_DartImpact(base.transform.position);
			_firstImpact = false;
		}
	}
}
