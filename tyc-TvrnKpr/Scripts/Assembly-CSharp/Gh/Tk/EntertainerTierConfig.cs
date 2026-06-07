using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	public class EntertainerTierConfig
	{
		public int tier;

		public int amountToGenerate;

		public int cost;

		public Dictionary<string, string> EffectDescriptions { get; set; }

		public Action<Actor> ApplyEntertainerEffectAction { get; set; }
	}
}
