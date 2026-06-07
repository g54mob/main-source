using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_BaloonBullet : Demo_Ragd_Bullet
	{
		public GameObject BaloonPrefab;

		protected override void OnHitEnd()
		{
			if (!(bulletHit.transform == null))
			{
				RagdollAnimator2BoneIndicator component = bulletHit.collider.GetComponent<RagdollAnimator2BoneIndicator>();
				if (component != null)
				{
					GameObject gameObject = Object.Instantiate(BaloonPrefab);
					gameObject.transform.position = bulletHit.point;
					gameObject.GetComponent<Rigidbody>().position = gameObject.transform.position;
					gameObject.GetComponent<Demo_Ragd_BaloonForce>().AttachTo(component.DummyBoneRigidbody, bulletHit.point);
				}
				Object.Destroy(base.gameObject);
			}
		}
	}
}
