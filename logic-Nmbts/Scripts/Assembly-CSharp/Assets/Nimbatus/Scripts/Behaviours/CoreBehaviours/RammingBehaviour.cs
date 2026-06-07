using System.Collections;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Animations;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Behaviours.Radar;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public class RammingBehaviour : CoreBehaviour
	{
		private float _currentTime;

		public float ChargeUpTime;

		public float CooldownTime;

		public float RammingImpulse;

		public float RotationSpeed;

		public bool UpIsForward;

		public bool HasAttackSound;

		[ShowIf("HasAttackSound", true)]
		public float AttackSoundPrewarm;

		[ShowIf("HasAttackSound", true)]
		public string AttackSound;

		public bool HasChargeUpGlow;

		[ShowIf("HasChargeUpGlow", true)]
		public List<SpriteSinusColorFader> ChargeUpGlowSprites;

		private float _frequencyInit;

		public EnemyRadar Radar;

		private bool _stopCoroutine;

		protected override void OnInit()
		{
			OwnWorldObject.StartCoroutine(ChargeCoroutine());
			if (HasChargeUpGlow)
			{
				_frequencyInit = ChargeUpGlowSprites[0].frequency;
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

		public void ResetCharge()
		{
			_currentTime = 0f;
		}

		private IEnumerator ChargeCoroutine()
		{
			_stopCoroutine = false;
			while (!_stopCoroutine)
			{
				if (OwnWorldObject.HealthPool.CurrentState == EChemicalState.Frozen)
				{
					OwnWorldObject.DeactivateGravity = false;
					yield return true;
					continue;
				}
				OwnWorldObject.DeactivateGravity = true;
				bool soundPlayed = false;
				while (_currentTime < ChargeUpTime)
				{
					yield return new WaitForFixedUpdate();
					if (OwnWorldObject.HealthPool.CurrentState == EChemicalState.Frozen)
					{
						OwnWorldObject.DeactivateGravity = false;
						break;
					}
					foreach (SpriteSinusColorFader chargeUpGlowSprite in ChargeUpGlowSprites)
					{
						chargeUpGlowSprite.SetTime(_currentTime / ChargeUpTime);
						chargeUpGlowSprite.frequency = 1f / ChargeUpTime;
					}
					_currentTime += Time.fixedDeltaTime;
					Quaternion rotationToTarget = GetRotationToTarget();
					OwnWorldObject.Rigidbody.MoveRotation(Quaternion.Lerp(OwnWorldObject.Rigidbody.rotation, rotationToTarget, Time.fixedDeltaTime * RotationSpeed));
					if (!soundPlayed && _currentTime > ChargeUpTime - AttackSoundPrewarm)
					{
						if (HasAttackSound)
						{
							OwnWorldObject.PlaySound(AttackSound);
						}
						soundPlayed = true;
					}
				}
				if (OwnWorldObject.HealthPool.CurrentState == EChemicalState.Frozen)
				{
					continue;
				}
				Vector3 vector = (UpIsForward ? OwnWorldObject.transform.up : OwnWorldObject.transform.right);
				OwnWorldObject.Rigidbody.AddForce(vector * RammingImpulse, ForceMode.Impulse);
				foreach (SpriteSinusColorFader chargeUpGlowSprite2 in ChargeUpGlowSprites)
				{
					chargeUpGlowSprite2.SetTime(1f);
					chargeUpGlowSprite2.frequency = _frequencyInit;
				}
				_currentTime = 0f;
				yield return new WaitForSeconds(CooldownTime);
			}
		}

		protected override void OnRelease()
		{
			_stopCoroutine = true;
			OwnWorldObject.HealthPool.DamageTaken -= HealthPool_OnDamageTaken;
		}

		private Quaternion GetRotationToTarget()
		{
			int num = (UpIsForward ? (-90) : 0);
			Vector3 vector;
			if (Radar.NearestTarget != null)
			{
				vector = Radar.NearestTarget.position - OwnWorldObject.transform.position;
				return Quaternion.AngleAxis(Mathf.Atan2(vector.y, vector.x) * 57.29578f + (float)num, Vector3.forward);
			}
			vector = OwnWorldObject.transform.up;
			return Quaternion.AngleAxis(Mathf.Atan2(vector.y, vector.x) * 57.29578f + (float)num, Vector3.forward);
		}
	}
}
