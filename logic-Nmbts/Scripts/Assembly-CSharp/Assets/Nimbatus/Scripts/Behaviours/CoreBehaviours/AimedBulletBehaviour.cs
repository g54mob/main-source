using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Behaviours.Radar;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public class AimedBulletBehaviour : CoreBehaviour
	{
		public float ForwardForce = 5f;

		public EnemyRadar Radar;

		public bool DestroyOnRadarFind = true;

		public float RotationSpeed;

		public bool UpIsForward;

		protected override void OnInit()
		{
		}

		protected override void OnRelease()
		{
		}

		protected override void OnFixedUpdate()
		{
			Quaternion rotation = GetRotation();
			float a = Time.fixedDeltaTime * RotationSpeed;
			a = Mathf.Min(a, OwnWorldObject.Rigidbody.velocity.magnitude * 0.1f);
			OwnWorldObject.Rigidbody.MoveRotation(Quaternion.Lerp(OwnWorldObject.Rigidbody.rotation, rotation, a));
			OwnWorldObject.Rigidbody.AddForce(OwnWorldObject.transform.right * ForwardForce, ForceMode.VelocityChange);
			if (Radar.NearestTarget != null && DestroyOnRadarFind)
			{
				OwnWorldObject.HealthPool.TakeDamageSimple(OwnWorldObject.HealthPool.ActiveMaxHealth, EDamageReason.Death);
			}
		}

		private Quaternion GetRotation()
		{
			int num = (UpIsForward ? (-90) : 0);
			Vector3 vector = OwnWorldObject.Rigidbody.velocity;
			if (Radar.NearestTarget != null)
			{
				vector = Radar.NearestTarget.position - OwnWorldObject.transform.position;
			}
			return Quaternion.AngleAxis(Mathf.Atan2(vector.y, vector.x) * 57.29578f + (float)num, Vector3.forward);
		}
	}
}
