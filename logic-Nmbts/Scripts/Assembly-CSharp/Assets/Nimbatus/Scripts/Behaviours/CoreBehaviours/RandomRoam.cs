using System.Collections;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Behaviours.Radar;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public class RandomRoam : CoreBehaviour
	{
		public EnemyRadar Radar;

		public float MoveSpeed;

		public float RotationSpeed;

		public float MoveRadius;

		public bool UpIsForward;

		public float RandomPositionTimer = 3f;

		private bool _stopCoroutine;

		private Vector2 _randomPosition;

		private bool _deactivateGravity;

		private Vector2 _targetPosition;

		protected override void OnInit()
		{
			_stopCoroutine = false;
			Radar.AddFriendlyUnit(OwnWorldObject.Rigidbody);
			_deactivateGravity = OwnWorldObject.DeactivateGravity;
			OwnWorldObject.HealthPool.DamageTaken += HealthPool_OnDamageTaken;
			OwnWorldObject.StartCoroutine(UpdatePosition());
		}

		private void HealthPool_OnDamageTaken(HealthPool healthPool, DamageInformation damage)
		{
			if (damage.DamageSourceObject != null && damage.Reason == EDamageReason.Player)
			{
				EnemyRadar radar = Radar;
				if ((object)radar != null)
				{
					radar.SetFocusTarget(damage.DamageSourceObject.transform);
				}
			}
		}

		private IEnumerator UpdatePosition()
		{
			while (!_stopCoroutine)
			{
				_randomPosition = Random.insideUnitCircle.normalized * MoveRadius;
				yield return new WaitForSeconds(RandomPositionTimer);
			}
		}

		private Quaternion GetRotation()
		{
			int num = (UpIsForward ? (-90) : 0);
			Vector3 velocity = OwnWorldObject.Rigidbody.velocity;
			return Quaternion.AngleAxis(Mathf.Atan2(velocity.y, velocity.x) * 57.29578f + (float)num, Vector3.forward);
		}

		private Vector2 GetVelocity()
		{
			Vector2 vector = Vector2.zero;
			Vector2 vector2 = Vector2.zero;
			if (Radar.HasFriendlyUnits)
			{
				vector = Radar.FriendlyFlockCenter - OwnWorldObject.transform.position;
				vector2 = Radar.FriendlyFlockVelocity - OwnWorldObject.Rigidbody.velocity;
			}
			Vector2 vector3 = _targetPosition + _randomPosition - (Vector2)OwnWorldObject.transform.position;
			float magnitude = vector3.magnitude;
			float num = Mathf.Min(1f, magnitude * 0.1f);
			return (vector + vector2 + vector3 * 3f).normalized * MoveSpeed * 100f * num;
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
			OwnWorldObject.Rigidbody.drag = OwnWorldObject.StartDrag;
			OwnWorldObject.Rigidbody.angularDrag = OwnWorldObject.StartAngularDrag;
			OwnWorldObject.DeactivateGravity = _deactivateGravity;
			float a = Time.fixedDeltaTime * RotationSpeed;
			a = Mathf.Min(a, OwnWorldObject.Rigidbody.velocity.magnitude * 0.1f);
			if (OwnWorldObject.Spawner != null)
			{
				_targetPosition = OwnWorldObject.Spawner.GetTargetPosition();
			}
			else
			{
				_targetPosition = OwnWorldObject.gameObject.transform.position;
			}
			Quaternion rotation = GetRotation();
			Vector2 vector = GetVelocity() * Time.fixedDeltaTime;
			if (!float.IsNaN(vector.x) && !float.IsNaN(vector.y))
			{
				OwnWorldObject.Rigidbody.AddForce(vector.x, vector.y, 0f, ForceMode.Force);
			}
			OwnWorldObject.Rigidbody.MoveRotation(Quaternion.Lerp(OwnWorldObject.Rigidbody.rotation, rotation, a));
		}

		protected override void OnRelease()
		{
			OwnWorldObject.DeactivateGravity = _deactivateGravity;
			OwnWorldObject.HealthPool.DamageTaken -= HealthPool_OnDamageTaken;
			_stopCoroutine = true;
			Radar.Clear();
		}
	}
}
