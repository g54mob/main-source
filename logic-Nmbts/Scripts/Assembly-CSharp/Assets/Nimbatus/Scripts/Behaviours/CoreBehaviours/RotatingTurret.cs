using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Behaviours.Radar;
using Assets.Nimbatus.Scripts.Behaviours.Weapons;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public class RotatingTurret : CoreBehaviour
	{
		public List<WeaponSlot> WeaponSlots = new List<WeaponSlot>();

		public EnemyRadar Radar;

		public Transform RotationTransform;

		public bool StartsDeactivated;

		public int AngleLimit;

		public float RotationSpeed;

		public float RepositionSpeed;

		public float DetectShootDelay;

		private Quaternion _originalRotation;

		private bool _targetInSight;

		private float _detectTimer;

		private bool _isShooting;

		public void ActivateTurret(bool start)
		{
			_isShooting = start;
		}

		private bool ShootingCheck(EnemyWeapon weapon)
		{
			if (Radar.NearestTarget != null && _targetInSight && _detectTimer >= DetectShootDelay)
			{
				return _isShooting;
			}
			return false;
		}

		private bool PlayerIsTargetable()
		{
			Vector3 to = Radar.NearestTarget.position - OwnWorldObject.transform.position;
			if (Vector3.Angle(OwnWorldObject.transform.up, to) > (float)AngleLimit / 2f)
			{
				return false;
			}
			return true;
		}

		private void TurnToTarget()
		{
			Vector3 position = Radar.NearestTarget.position;
			position -= RotationTransform.transform.position;
			Quaternion quaternion = Quaternion.AngleAxis(Mathf.Atan2(position.y, position.x) * 57.29578f, Vector3.forward);
			Quaternion rotation = RotationTransform.rotation;
			RotationTransform.rotation = quaternion;
			bool num = PlayerIsTargetable();
			RotationTransform.rotation = rotation;
			if (!num)
			{
				TurnBack();
				return;
			}
			_detectTimer += Time.fixedDeltaTime;
			_targetInSight = true;
			RotationTransform.rotation = Quaternion.Lerp(rotation, quaternion, RotationSpeed * Time.deltaTime);
		}

		private void TurnBack()
		{
			_detectTimer = 0f;
			_targetInSight = false;
			RotationTransform.rotation = Quaternion.Lerp(RotationTransform.rotation, _originalRotation, RepositionSpeed * Time.deltaTime);
		}

		protected override void OnUpdate()
		{
			if (OwnWorldObject.HealthPool.CurrentState != EChemicalState.Frozen)
			{
				if (Radar.NearestTarget != null)
				{
					TurnToTarget();
				}
				else
				{
					TurnBack();
				}
			}
		}

		protected override void OnInit()
		{
			_originalRotation = RotationTransform.rotation;
			_isShooting = !StartsDeactivated;
			int seed = Random.Range(int.MinValue, int.MaxValue);
			foreach (WeaponSlot weaponSlot in WeaponSlots)
			{
				weaponSlot.Init(OwnWorldObject, seed, ShootingCheck);
			}
			OwnWorldObject.HealthPool.DamageTaken += HealthPool_OnDamageTaken;
		}

		private void HealthPool_OnDamageTaken(HealthPool healthPool, DamageInformation damage)
		{
			if (damage.DamageSourceObject != null && damage.Reason == EDamageReason.Player)
			{
				Radar.SetFocusTarget(damage.DamageSourceObject.transform);
			}
		}

		protected override void OnRelease()
		{
			OwnWorldObject.HealthPool.DamageTaken -= HealthPool_OnDamageTaken;
		}
	}
}
