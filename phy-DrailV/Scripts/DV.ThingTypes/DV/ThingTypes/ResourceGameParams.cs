namespace DV.ThingTypes
{
	public class ResourceGameParams
	{
		public float ConsumablesPriceModifier { get; private set; }

		public float DamageablePriceModifier { get; private set; }

		public float CargoDamagePriceModifier { get; private set; }

		public float EnvironmentDamagePriceModifier { get; private set; }

		public ResourceGameParams(float consumablesPriceModifier, float damageablePriceModifier, float cargoDamagePriceModifier, float environmentDamagePriceModifier)
		{
			OverrideGameParams(consumablesPriceModifier, damageablePriceModifier, cargoDamagePriceModifier, environmentDamagePriceModifier);
		}

		public void OverrideGameParams(float consumablesPriceModifier, float damageablePriceModifier, float cargoDamagePriceModifier, float environmentDamagePriceModifier)
		{
			ConsumablesPriceModifier = consumablesPriceModifier;
			DamageablePriceModifier = damageablePriceModifier;
			CargoDamagePriceModifier = cargoDamagePriceModifier;
			EnvironmentDamagePriceModifier = environmentDamagePriceModifier;
		}
	}
}
