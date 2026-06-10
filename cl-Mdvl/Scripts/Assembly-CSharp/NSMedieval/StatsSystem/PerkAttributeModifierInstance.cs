using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSMedieval.Model;
using NSMedieval.State;

namespace NSMedieval.StatsSystem
{
	public class PerkAttributeModifierInstance : ModifierInstance
	{
		private struct AttributePerkModifierPair
		{
			private AttributeInstance attribute;

			private float modifier;

			public AttributeInstance Attribute => attribute;

			public float Modifier => modifier;

			public AttributePerkModifierPair(AttributeInstance attribute, float modifier)
			{
				this.attribute = attribute;
				this.modifier = modifier;
			}
		}

		private List<AttributePerkModifierPair> modifiers = new List<AttributePerkModifierPair>();

		public PerkAttributeModifierInstance()
			: base(ModifierType.Perk)
		{
		}

		public override void Init(StatsInstance instance)
		{
			base.Init(instance);
			foreach (Perk perk in ((HumanoidInstance)instance.Owner).Perks)
			{
				foreach (AttributeModifierPair attributeModifier in perk.AttributeModifiers)
				{
					AttributeInstance attributeInstance = instance.GetAttributeInstance(attributeModifier.Key);
					if (attributeInstance == null)
					{
						Log.Error("Attribute instance for '" + attributeModifier.Key.ToString() + "' not found!", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Modifiers\\PerkAttributeModifierInstance.cs");
						return;
					}
					modifiers.Add(new AttributePerkModifierPair(attributeInstance, attributeModifier.Value));
				}
			}
		}

		public override void Apply()
		{
			foreach (AttributePerkModifierPair modifier in modifiers)
			{
				modifier.Attribute.SetMultiplier(modifier.Attribute.Multiplier * modifier.Modifier);
			}
		}

		public override bool IsHidden()
		{
			return true;
		}
	}
}
