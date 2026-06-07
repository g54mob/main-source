using Assets.Nimbatus.Scripts.Behaviours.Health;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public class FlyTowardsFlocktransform : CoreBehaviour
	{
		public float MoveSpeed;

		public float RandomTargetRadius;

		public bool UpIsForward;

		private Vector3 _randomPosition;

		private bool _deactivateGravity;

		protected override void OnInit()
		{
			_deactivateGravity = OwnWorldObject.DeactivateGravity;
			_randomPosition = Random.insideUnitCircle * RandomTargetRadius;
		}

		protected override void OnFixedUpdate()
		{
			if (OwnWorldObject.Rigidbody.isKinematic)
			{
				return;
			}
			if (OwnWorldObject.HealthPool.CurrentState == EChemicalState.Frozen)
			{
				OwnWorldObject.Rigidbody.drag = 0.1f;
				OwnWorldObject.Rigidbody.angularDrag = 0.1f;
				OwnWorldObject.DeactivateGravity = false;
				return;
			}
			OwnWorldObject.DeactivateGravity = _deactivateGravity;
			int num = (UpIsForward ? (-90) : 0);
			Vector3 vector = _randomPosition;
			if (OwnWorldObject.Spawner != null)
			{
				vector = OwnWorldObject.Spawner.FlockingTarget.position + _randomPosition - OwnWorldObject.transform.position;
			}
			if (OwnWorldObject.Rigidbody.velocity.magnitude < MoveSpeed / 2f)
			{
				OwnWorldObject.Rigidbody.AddForce(vector.normalized * MoveSpeed * 100f * Time.fixedDeltaTime, ForceMode.Force);
			}
			OwnWorldObject.Rigidbody.MoveRotation(Quaternion.Euler(0f, 0f, Mathf.Atan2(OwnWorldObject.Rigidbody.velocity.y, OwnWorldObject.Rigidbody.velocity.x) * 57.29578f + (float)num));
			if (vector.magnitude <= 5f)
			{
				_randomPosition = Random.insideUnitCircle * RandomTargetRadius;
			}
		}

		protected override void OnRelease()
		{
			OwnWorldObject.DeactivateGravity = _deactivateGravity;
		}
	}
}
