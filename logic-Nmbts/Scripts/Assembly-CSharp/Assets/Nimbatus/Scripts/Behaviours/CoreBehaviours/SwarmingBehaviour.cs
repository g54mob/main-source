using System.Collections;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Behaviours.Radar;
using Assets.Nimbatus.Scripts.Behaviours.Weapons;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public class SwarmingBehaviour : CoreBehaviour
	{
		public float MinDistanceToTarget;

		public float ApproachSpeed;

		public float RetreatSpeed;

		public float RotationSpeed;

		public bool UpIsForward;

		public bool RetreatForward;

		[ShowIf("RetreatForward", true)]
		public float RetreatRotationSpeed;

		public EnemyRadar Radar;

		public bool Attack;

		[ShowIf("Attack", true)]
		public List<WeaponSlot> WeaponSlots = new List<WeaponSlot>();

		[ShowIf("Attack", true)]
		public float AttackRange;

		[ShowIf("Attack", true)]
		public float MinAttackAngle;

		private bool _deactivateGravity;

		private Vector2 _initialPosition;

		private bool _stopCoroutine;

		private Vector2 _randomPosition;

		protected override void OnInit()
		{
			_stopCoroutine = false;
			OwnWorldObject.StartCoroutine(UpdatePosition());
			_deactivateGravity = OwnWorldObject.DeactivateGravity;
			if (Attack && WeaponSlots != null)
			{
				int seed = Random.Range(int.MinValue, int.MaxValue);
				foreach (WeaponSlot weaponSlot in WeaponSlots)
				{
					weaponSlot.Init(OwnWorldObject, seed, ShootingCheck);
				}
			}
			_initialPosition = OwnWorldObject.transform.position;
			Radar.AddFriendlyUnit(OwnWorldObject.Rigidbody);
			OwnWorldObject.HealthPool.DamageTaken += HealthPool_OnDamageTaken;
		}

		private void HealthPool_OnDamageTaken(HealthPool healthPool, DamageInformation damage)
		{
			if (damage.DamageSourceObject != null && damage.Reason == EDamageReason.Player)
			{
				Radar.SetFocusTarget(damage.DamageSourceObject.transform);
			}
		}

		private bool ShootingCheck(EnemyWeapon weapon)
		{
			if (Radar.NearestTarget != null && OwnWorldObject.HealthPool.CurrentState != EChemicalState.Frozen)
			{
				Vector3 vector = (UpIsForward ? OwnWorldObject.transform.up : OwnWorldObject.transform.right);
				bool num = (Radar.NearestTarget.position - OwnWorldObject.transform.position).magnitude < AttackRange;
				Vector3 to = Radar.NearestTarget.position - OwnWorldObject.transform.position;
				if (num && Vector3.Angle(vector, to) < MinAttackAngle)
				{
					return true;
				}
			}
			return false;
		}

		private Quaternion GetRotation()
		{
			int num = (UpIsForward ? (-90) : 0);
			Vector3 vector;
			if (Radar.NearestTarget != null)
			{
				vector = Radar.NearestTarget.position - OwnWorldObject.transform.position;
				return Quaternion.AngleAxis(Mathf.Atan2(vector.y, vector.x) * 57.29578f + (float)num, Vector3.forward);
			}
			vector = OwnWorldObject.Rigidbody.velocity;
			return Quaternion.AngleAxis(Mathf.Atan2(vector.y, vector.x) * 57.29578f + (float)num, Vector3.forward);
		}

		private IEnumerator UpdatePosition()
		{
			while (!_stopCoroutine)
			{
				_randomPosition = Random.insideUnitCircle.normalized * 5f;
				yield return new WaitForSeconds(1f);
			}
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
			Vector2 vector3 = _initialPosition - (Vector2)OwnWorldObject.Rigidbody.transform.position;
			if (Radar.NearestTarget != null)
			{
				vector3 = Radar.NearestTarget.position - OwnWorldObject.Rigidbody.transform.position;
			}
			else if (OwnWorldObject.Spawner != null)
			{
				vector3 = OwnWorldObject.Spawner.GetTargetPosition() - OwnWorldObject.Rigidbody.transform.position;
			}
			float num = 0f;
			if (Radar.NearestTarget != null)
			{
				num = MinDistanceToTarget;
			}
			float num2 = ApproachSpeed;
			float num3 = vector3.magnitude - num;
			float num4 = Mathf.Min(1f, num3 * 0.05f);
			if (num3 < 0f)
			{
				vector3 = -vector3;
				num2 = RetreatSpeed;
				num4 = 1f;
			}
			return (vector + vector2 + vector3 * 3f).normalized * num2 * 100f * num4;
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
			Quaternion quaternion = GetRotation();
			Vector2 vector = GetVelocity() * Time.fixedDeltaTime;
			if (!RetreatForward)
			{
				if (!float.IsNaN(vector.x) && !float.IsNaN(vector.y))
				{
					OwnWorldObject.Rigidbody.AddForce(vector.x, vector.y, 0f, ForceMode.Force);
				}
			}
			else
			{
				quaternion = Quaternion.Inverse(quaternion);
				a = Time.fixedDeltaTime * RetreatRotationSpeed;
				OwnWorldObject.Rigidbody.AddForce(OwnWorldObject.transform.up * vector.magnitude, ForceMode.Force);
			}
			OwnWorldObject.Rigidbody.MoveRotation(Quaternion.Lerp(OwnWorldObject.Rigidbody.rotation, quaternion, a));
		}

		protected override void OnRelease()
		{
			if (WeaponSlots != null)
			{
				foreach (WeaponSlot weaponSlot in WeaponSlots)
				{
					weaponSlot.Release();
				}
			}
			OwnWorldObject.DeactivateGravity = _deactivateGravity;
			OwnWorldObject.HealthPool.DamageTaken -= HealthPool_OnDamageTaken;
			_stopCoroutine = true;
			Radar.Clear();
		}

		public void SetRotationSpeed(float speed)
		{
			RotationSpeed = speed;
		}
	}
}
