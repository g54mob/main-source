namespace NSMedieval.StatsSystem
{
	public class CustomAttributeAdderModifierInstance : ModifierInstance
	{
		private readonly float value;

		private readonly AttributeType attributeType;

		private AttributeInstance attributeInstance;

		public CustomAttributeAdderModifierInstance(AttributeType attributeType, float value, string tag)
			: base(ModifierType.CustomAttributeAdder, tag)
		{
			this.attributeType = attributeType;
			this.value = value;
		}

		public override bool PreInitChecks(StatsInstance instance, ModifierInstanceStack stack)
		{
			return true;
		}

		public override void Init(StatsInstance instance)
		{
			base.Init(instance);
			attributeInstance = instance.GetAttributeInstance(attributeType);
			base.AffectedAttributes.Add(attributeInstance);
		}

		public override void Apply()
		{
			attributeInstance?.SetMultiplier(attributeInstance.Multiplier + value);
		}
	}
}
