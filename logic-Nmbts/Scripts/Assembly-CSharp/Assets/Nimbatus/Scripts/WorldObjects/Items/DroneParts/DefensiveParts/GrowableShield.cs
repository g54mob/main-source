using Assets.Nimbatus.Scripts.Combat;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Projectiles;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.DefensiveParts
{
	public class GrowableShield : MonoBehaviour
	{
		public NimbatusParticleEffect ShieldDeflectEffect;

		private EnergyShield _shield;

		private LayerMask _mask;

		public void Init(EnergyShield shield, LayerMask detectionLayer)
		{
			_shield = shield;
			_mask = detectionLayer;
		}

		public void OnTriggerEnter(Collider other)
		{
			if (other.isTrigger || (int)_mask != ((int)_mask | (1 << other.gameObject.layer)))
			{
				return;
			}
			Projectile component = other.GetComponent<Projectile>();
			if (component != null)
			{
				if (ShieldDeflectEffect != null)
				{
					ShieldDeflectEffect.PlayEffect(other.gameObject.transform.position, other.gameObject.transform.rotation);
				}
				component.HandleCollision(other.gameObject, other.gameObject.transform.position, other.gameObject.transform.rotation, Vector3.zero);
				Vector3 vector = _shield.transform.position - component.transform.position;
				_shield.Rigidbody.AddForce(vector.normalized * _shield.ImpactForce, ForceMode.Impulse);
				_shield.TakeShieldDamage(component.GetDamage());
			}
		}
	}
}
