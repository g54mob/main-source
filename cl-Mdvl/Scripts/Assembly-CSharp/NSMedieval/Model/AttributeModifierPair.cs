using System;
using NSMedieval.StatsSystem;

namespace NSMedieval.Model
{
	[Serializable]
	public class AttributeModifierPair : SerializablePair<AttributeType, float>
	{
		public AttributeModifierPair()
		{
		}

		public AttributeModifierPair(AttributeType stat, float value)
			: base(stat, value)
		{
		}
	}
}
