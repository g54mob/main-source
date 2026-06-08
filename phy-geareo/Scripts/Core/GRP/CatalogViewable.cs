using System.Collections.Generic;
using GRP.Pages.NSProjectFrame;
using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP
{
	public class CatalogViewable : Viewable
	{
		[ListLoaderCrew]
		public StateSelector<List<ModuleItemViewable>> modules;

		[ListLoaderCrew]
		public List<PartCategoryItemViewable> categories;

		public State<PartCategory> selectedCategory;

		public List<PartDefinition> allParts;

		public CatalogViewable(Catalog catalog)
		{
		}

		public void Append(Catalog catalog)
		{
		}
	}
}
