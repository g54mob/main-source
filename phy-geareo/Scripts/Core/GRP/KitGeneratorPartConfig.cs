using System.Collections.Generic;
using Rhizomatic;
using Rhizomatic.Pooling;

namespace GRP
{
	public class KitGeneratorPartConfig : PartConfig
	{
		public HighlightConfig kitGreyHighlight;

		public HighlightConfig kitHighlight;

		public PoolObject arrow;

		public List<KitSortOrder> sortOrders;

		public override Thing CreateThing()
		{
			return null;
		}
	}
}
