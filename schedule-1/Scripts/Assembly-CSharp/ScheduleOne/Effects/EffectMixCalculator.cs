using System.Collections.Generic;
using ScheduleOne.Product;

namespace ScheduleOne.Effects
{
	public static class EffectMixCalculator
	{
		private class Reaction
		{
			public Effect Existing;

			public Effect Output;
		}

		public const int MAX_PROPERTIES = 8;

		public const float MAX_DELTA_DIFFERENCE = 0.5f;

		public static List<Effect> MixProperties(List<Effect> existingProperties, Effect newProperty, EDrugType drugType)
		{
			return null;
		}

		public static void Shuffle<T>(List<T> list, int seed)
		{
		}
	}
}
