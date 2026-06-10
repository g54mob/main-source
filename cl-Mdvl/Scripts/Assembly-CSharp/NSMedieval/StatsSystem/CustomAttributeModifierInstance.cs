using UnityEngine;

namespace NSMedieval.StatsSystem
{
	public class CustomAttributeModifierInstance : ModifierInstance
	{
		private readonly float value;

		private readonly bool negativeStacking;

		private readonly AttributeType attributeType;

		protected AttributeInstance attributeInstance;

		public CustomAttributeModifierInstance(AttributeType attributeType, float value, string tag, bool negativeStacking = false)
			: base(ModifierType.CustomAttribute, tag)
		{
			this.attributeType = attributeType;
			this.negativeStacking = negativeStacking;
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
			if (attributeInstance == null)
			{
				return;
			}
			float num = value;
			if (base.Effector is StatEffectorWound)
			{
				int firstIndexOfEffector = base.Owner.GetFirstIndexOfEffector(base.Effector.GetID());
				if (firstIndexOfEffector != -1)
				{
					ActiveEffectorInfo effectorByIndex = base.Owner.GetEffectorByIndex(firstIndexOfEffector);
					if (num < 1f)
					{
						float num2 = 1f - num;
						num += num2 * effectorByIndex.ExpirationPercentage();
					}
					else
					{
						float num3 = num - 1f;
						num -= num3 * effectorByIndex.ExpirationPercentage();
					}
				}
			}
			if (negativeStacking && !Mathf.Approximately(base.StackMultiplier, 1f))
			{
				float num4 = Mathf.Pow(num, base.StackMultiplier);
				attributeInstance.SetMultiplier(attributeInstance.Multiplier * num4);
			}
			else
			{
				attributeInstance.SetMultiplier(attributeInstance.Multiplier * num * base.StackMultiplier);
			}
		}
	}
}
