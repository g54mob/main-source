using System;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	public class FaithModifier : ModifierInstance
	{
		private AttributeInstance faithAttribute;

		private StatInstance faithStatInstance;

		public FaithModifier()
			: base(ModifierType.Praying)
		{
		}

		public override bool PreInitChecks(StatsInstance instance, ModifierInstanceStack stack)
		{
			return stack.Instances.Count == 1;
		}

		public override void Init(StatsInstance instance)
		{
			base.Init(instance);
			faithAttribute = instance.GetAttributeInstance(AttributeType.FaithNeed);
			base.AffectedAttributes.Add(faithAttribute);
			faithStatInstance = instance.GetStat(StatType.Faith);
		}

		public override void Apply()
		{
			faithAttribute?.SetMultiplier(faithAttribute.Multiplier * -1f);
		}
	}
}
