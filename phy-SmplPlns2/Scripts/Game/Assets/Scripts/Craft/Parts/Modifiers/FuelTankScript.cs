using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class FuelTankScript : PartModifierScript
	{
		private PartDamageEffect _damageEffect;

		public float? FuelLeak { get; private set; }

		public FuelTankData FuelTank { get; set; }

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level <= PartDamageLevel.Light || !(Random.value < 0.85f))
			{
				return;
			}
			if (!FuelLeak.HasValue && FuelTank.Fuel > 0f)
			{
				if (Random.value < 0.25f)
				{
					_damageEffect = base.PartScript.Aircraft.DamageEffects.CreateFire(base.PartScript, null);
					StartCoroutine(DelayedExplosionCoroutine());
				}
				else
				{
					_damageEffect = base.PartScript.Aircraft.DamageEffects.CreateFuelLeak(base.PartScript, lastDamagePosition, lastDamageDirection);
				}
			}
			FuelLeak = FuelLeak.GetValueOrDefault() + Random.value * (float)(level - 1);
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightLocalUnpaused);
		}

		private IEnumerator DelayedExplosionCoroutine()
		{
			yield return new WaitForSeconds(5f + 15f * Random.value);
			if (FuelTank.Fuel > 0f && _damageEffect != null && !_damageEffect.Destroyed)
			{
				_damageEffect.DestroyEffect();
				base.PartScript.Body.ExplodePart(base.PartScript);
			}
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (FuelLeak.HasValue && FuelTank.Fuel > 0f)
			{
				frame.Craft.UseFuel(FuelLeak.Value, FuelTank);
				if (FuelTank.Fuel < 0.1f)
				{
					_damageEffect = null;
				}
			}
		}
	}
}
