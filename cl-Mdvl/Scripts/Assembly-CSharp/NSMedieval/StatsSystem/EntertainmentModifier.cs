using System;
using System.Collections.Generic;
using NSMedieval.BuildingComponents;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	public class EntertainmentModifier : ModifierInstance
	{
		private EntertainmentComponentBlueprint entertainmentComponentBlueprint;

		private StatInstance entertainmentStatInstance;

		private Dictionary<AttributeInstance, float> modifiersCache;

		public EntertainmentModifier()
			: base(ModifierType.Entertaining)
		{
		}

		public EntertainmentModifier(EntertainmentComponentBlueprint entertainmentComponentBlueprint)
			: base(ModifierType.Entertaining)
		{
			modifiersCache = new Dictionary<AttributeInstance, float>();
			this.entertainmentComponentBlueprint = entertainmentComponentBlueprint;
		}

		public override bool PreInitChecks(StatsInstance instance, ModifierInstanceStack stack)
		{
			return stack.Instances.Count == 1;
		}

		public override void Init(StatsInstance instance)
		{
			base.Init(instance);
			foreach (KeyValuePair<string, float> item in entertainmentComponentBlueprint.StatAffect.Dictionary)
			{
				AttributeType attributeType = (AttributeType)Enum.Parse(typeof(AttributeType), item.Key);
				if (attributeType != AttributeType.None)
				{
					AttributeInstance attributeInstance = instance.GetAttributeInstance(attributeType);
					modifiersCache.TryAdd(attributeInstance, item.Value);
					base.AffectedAttributes.Add(attributeInstance);
				}
			}
			entertainmentStatInstance = instance.GetStat(StatType.Entertaiment);
		}

		public override void Apply()
		{
			foreach (KeyValuePair<AttributeInstance, float> item in modifiersCache)
			{
				item.Key?.SetMultiplier(item.Key.Multiplier * -1f * item.Value);
			}
		}
	}
}
