using UnityEngine;

namespace HQFPSTemplate
{
	[RequireComponent(typeof(Entity))]
	public class EntityDamageDealer : EntityComponent
	{
		private void Start()
		{
			base.Entity.DealDamage.SetTryer(DealDamage);
		}

		protected virtual bool DealDamage(DamageInfo damageInfo, IDamageable damageable = null)
		{
			if (damageable != null)
			{
				DealDamage(damageable, damageInfo);
				return true;
			}
			if (damageInfo.HitObject.TryGetComponent<IDamageable>(out var component))
			{
				DealDamage(component, damageInfo);
				return true;
			}
			return false;
		}

		protected virtual void DealDamage(IDamageable damageable, DamageInfo damageInfo)
		{
			damageable.TakeDamage(damageInfo);
		}
	}
}
