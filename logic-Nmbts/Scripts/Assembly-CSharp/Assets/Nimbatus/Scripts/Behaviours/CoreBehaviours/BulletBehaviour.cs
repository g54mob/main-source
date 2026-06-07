using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Behaviours.Radar;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public class BulletBehaviour : CoreBehaviour
	{
		public float ForwardForce = 5f;

		public EnemyRadar Radar;

		public bool DestroyOnRadarFind = true;

		protected override void OnInit()
		{
		}

		protected override void OnRelease()
		{
		}

		protected override void OnFixedUpdate()
		{
			OwnWorldObject.Rigidbody.AddForce(OwnWorldObject.transform.right * ForwardForce, ForceMode.VelocityChange);
			if (Radar.NearestTarget != null && DestroyOnRadarFind)
			{
				OwnWorldObject.HealthPool.TakeDamageSimple(OwnWorldObject.HealthPool.ActiveMaxHealth, EDamageReason.Death);
			}
		}
	}
}
