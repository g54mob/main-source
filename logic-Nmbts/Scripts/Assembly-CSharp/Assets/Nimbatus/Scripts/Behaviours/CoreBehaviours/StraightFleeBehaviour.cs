using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Behaviours.Radar;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public class StraightFleeBehaviour : CoreBehaviour
	{
		public float RetreatSpeed;

		public float RotationSpeed;

		public bool UpIsForward;

		public EnemyRadar Radar;

		private bool _deactivateGravity;

		private Vector3 _oldTargetVector;

		protected override void OnInit()
		{
			_deactivateGravity = OwnWorldObject.DeactivateGravity;
			Radar.AddFriendlyUnit(OwnWorldObject.Rigidbody);
			OwnWorldObject.HealthPool.DamageTaken += HealthPool_OnDamageTaken;
			_oldTargetVector = OwnWorldObject.transform.rotation * Vector3.forward;
		}

		private void HealthPool_OnDamageTaken(HealthPool healthPool, DamageInformation damage)
		{
			if (damage.DamageSourceObject != null && damage.Reason == EDamageReason.Player)
			{
				Radar.SetFocusTarget(damage.DamageSourceObject.transform);
			}
		}

		protected override void OnFixedUpdate()
		{
			if (!OwnWorldObject.Rigidbody.isKinematic)
			{
				if (OwnWorldObject.HealthPool.CurrentState == EChemicalState.Frozen)
				{
					OwnWorldObject.Rigidbody.drag = 0.1f;
					OwnWorldObject.Rigidbody.angularDrag = 0.1f;
					OwnWorldObject.DeactivateGravity = false;
					return;
				}
				OwnWorldObject.Rigidbody.drag = OwnWorldObject.StartDrag;
				OwnWorldObject.Rigidbody.angularDrag = OwnWorldObject.StartAngularDrag;
				OwnWorldObject.DeactivateGravity = _deactivateGravity;
				Vector3 vector = ((!(Radar.NearestTarget != null)) ? _oldTargetVector : (_oldTargetVector = Radar.NearestTarget.position - OwnWorldObject.transform.position));
				float num = Mathf.Atan2(vector.y, vector.x) * 57.29578f;
				int num2 = (UpIsForward ? (-90) : 0);
				Quaternion b = Quaternion.AngleAxis(num + (float)num2 + 180f, Vector3.forward);
				float t = RotationSpeed * Time.fixedDeltaTime;
				OwnWorldObject.Rigidbody.MoveRotation(Quaternion.Lerp(OwnWorldObject.Rigidbody.rotation, b, t));
				OwnWorldObject.Rigidbody.AddForce(vector.normalized * 100f * (0f - RetreatSpeed) * Time.fixedDeltaTime, ForceMode.Force);
			}
		}

		protected override void OnRelease()
		{
			OwnWorldObject.DeactivateGravity = _deactivateGravity;
			OwnWorldObject.HealthPool.DamageTaken -= HealthPool_OnDamageTaken;
			Radar.Clear();
		}

		public void SetRotationSpeed(float speed)
		{
			RotationSpeed = speed;
		}
	}
}
