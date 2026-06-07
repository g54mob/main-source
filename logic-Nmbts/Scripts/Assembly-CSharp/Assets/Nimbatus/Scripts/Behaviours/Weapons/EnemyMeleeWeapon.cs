using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.WorldObjects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.Weapons
{
	public class EnemyMeleeWeapon : MonoBehaviour
	{
		public float Damage;

		public ParticleSystem HitParticleSystem;

		public SpriteRenderer ActiveSprite;

		public SpriteRenderer InactiveSprite;

		private InteractiveWorldObject _ownWorldObject;

		private bool _active;

		public void Init(bool active, InteractiveWorldObject ownWorldObject)
		{
			_active = active;
			_ownWorldObject = ownWorldObject;
			SpriteRenderer activeSprite = ActiveSprite;
			if ((object)activeSprite != null)
			{
				activeSprite.gameObject.SetActive(active);
			}
			SpriteRenderer inactiveSprite = InactiveSprite;
			if ((object)inactiveSprite != null)
			{
				inactiveSprite.gameObject.SetActive(!active);
			}
		}

		public void OnTriggerStay(Collider col)
		{
			if (!col.isTrigger)
			{
				if (DealDamage(col.gameObject, Damage * Time.deltaTime))
				{
					HitParticleSystem.Play(true);
				}
				else
				{
					HitParticleSystem.Stop(true);
				}
			}
			else
			{
				HitParticleSystem.Stop(true);
			}
		}

		public void OnTriggerExit(Collider col)
		{
			HitParticleSystem.Stop(true);
		}

		public virtual bool DealDamage(GameObject go, float damage)
		{
			if (!_active || go == null || _ownWorldObject == null)
			{
				return false;
			}
			if (go.layer == _ownWorldObject.gameObject.layer)
			{
				return false;
			}
			go.SendMessage("TakeDamage", new DamageInformation(damage, EDamageReason.Enemy, _ownWorldObject), SendMessageOptions.DontRequireReceiver);
			return true;
		}
	}
}
