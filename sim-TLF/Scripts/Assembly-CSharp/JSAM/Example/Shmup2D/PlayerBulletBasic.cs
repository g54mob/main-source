using UnityEngine;

namespace JSAM.Example.Shmup2D
{
	public class PlayerBulletBasic : BaseBullet
	{
		protected override void TriggerEnter(Collider2D other)
		{
			if ((bool)other.attachedRigidbody)
			{
				other.attachedRigidbody.TryGetComponent<BaseBullet>(out var _);
			}
		}
	}
}
