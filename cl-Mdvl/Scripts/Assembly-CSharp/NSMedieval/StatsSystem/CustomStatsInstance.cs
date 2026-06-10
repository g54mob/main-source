using System;
using System.Collections.Generic;
using NSMedieval.Serialization;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	[FVSerializableKey("CustomStatsInstance", "")]
	public class CustomStatsInstance : StatsInstance
	{
		public CustomStatsInstance(IStatsOwner owner)
			: base(owner)
		{
		}

		public void SetCustomAttributes(List<AttributeInstance> attributeInstances)
		{
			SetAttributes(new Dictionary<AttributeType, AttributeInstance>());
			if (attributeInstances == null)
			{
				return;
			}
			foreach (AttributeInstance attributeInstance in attributeInstances)
			{
				base.Attributes.Add(attributeInstance.Type, attributeInstance);
			}
		}

		public void SetCustomStats(List<StatInstance> statInstances)
		{
			if (base.IsGeneratedFromRepository)
			{
				return;
			}
			SetAttributeModifiers(new List<ModifierInstanceStack>());
			Dictionary<StatType, StatInstance> dictionary = new Dictionary<StatType, StatInstance>();
			foreach (StatInstance statInstance in statInstances)
			{
				statInstance.InitAsCustomStat();
				dictionary.Add(statInstance.Type, statInstance);
			}
			SetStats(dictionary);
		}

		public CustomStatsInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
