using System.Collections.Generic;

namespace Brewery.NPC.Simple
{
	internal class NPCBarSelectionBehavior
	{
		private readonly NPCContext ctx;

		public NPCBarSelectionBehavior(NPCContext context)
		{
		}

		public SimpleBarLocation SelectBarByFactionAttraction()
		{
			return null;
		}

		private SimpleBarLocation SelectBar(List<SimpleBarLocation> bars)
		{
			return null;
		}

		private T SelectWeightedRandom<T>(List<T> items, float[] weights)
		{
			return default(T);
		}
	}
}
