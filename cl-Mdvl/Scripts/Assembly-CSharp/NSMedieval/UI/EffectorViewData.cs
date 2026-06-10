using System.Collections.Generic;
using NSMedieval.Model;

namespace NSMedieval.UI
{
	public readonly struct EffectorViewData
	{
		public string Name { get; }

		public float Value { get; }

		public int StackCount { get; }

		public float MinutesLeft { get; }

		public LocKeys[] LocKeys { get; }

		public Dictionary<string, string> Attributes { get; }

		public EffectorViewData(string name, float value, int stackCount, float minutesLeft, Dictionary<string, string> attributes, LocKeys[] locKeys)
		{
			Name = name;
			Value = value;
			StackCount = stackCount;
			MinutesLeft = minutesLeft;
			Attributes = attributes;
			LocKeys = locKeys;
		}
	}
}
