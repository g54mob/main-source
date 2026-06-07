using System;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_Bullet : FimpossibleComponent
	{
		public struct HitInfo
		{
			public RaycastHit rHit;

			public Demo_Ragd_Bullet bullet;

			public Vector3 flightDirection;

			public float Damage;
		}

		[Tooltip("Speed of the bullet")]
		public float FlySpeed = 100f;

		[Tooltip("How far bullet can fly then beeing destroyed")]
		public float DistanceLimit = 400f;

		private Vector3 initPosition;

		public LayerMask ProjectiletHitMask = 1;

		public float BulletDamage = 1f;

		public GameObject CreateOnHit;

		public bool SetAsChild;

		public Action<HitInfo> OnBulletHit;

		protected RaycastHit bulletHit;

		protected virtual void Start()
		{
			base.transform.position += StepForward(0.1f);
			initPosition = base.transform.position;
		}

		protected virtual void Update()
		{
			Vector3 vector = base.transform.position + StepForward();
			bool num = DoRaycast(vector);
			base.transform.position = vector;
			if (num)
			{
				HitTarget();
			}
			if (Vector3.Distance(initPosition, base.transform.position) >= DistanceLimit)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		protected virtual bool DoRaycast(Vector3 newPosition)
		{
			return Physics.Linecast(base.transform.position, newPosition, out bulletHit, ProjectiletHitMask, QueryTriggerInteraction.Ignore);
		}

		protected virtual void HitTarget()
		{
			if ((bool)bulletHit.collider && (bool)CreateOnHit)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(CreateOnHit, bulletHit.point, Quaternion.LookRotation(bulletHit.normal));
				if (SetAsChild)
				{
					gameObject.transform.SetParent(bulletHit.collider.transform, worldPositionStays: true);
				}
			}
			if (OnBulletHit != null)
			{
				OnBulletHit(new HitInfo
				{
					bullet = this,
					rHit = bulletHit,
					flightDirection = base.transform.forward,
					Damage = BulletDamage
				});
			}
			OnHitEnd();
		}

		protected virtual void OnHitEnd()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		internal Vector3 StepForward(float multiply = 1f)
		{
			return base.transform.forward * FlySpeed * multiply * Time.deltaTime;
		}
	}
}
