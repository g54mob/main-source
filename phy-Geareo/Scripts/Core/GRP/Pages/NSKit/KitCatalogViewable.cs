using System.Collections.Generic;
using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP.Pages.NSKit
{
	public class KitCatalogViewable : Viewable
	{
		[ListLoaderCrew]
		public List<KitPartViewable> parts;

		public Kit kit;

		public KitCatalogViewable(Kit kit)
		{
		}
	}
}
