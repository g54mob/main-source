using System.Collections.Generic;
using Rhizomatic;

namespace GRP
{
	public class Catalog : Thing<CatalogConfig>
	{
		public List<PartDefinition> parts;

		public List<PartCategory> categories;

		public ProjectContainer projectContainer;

		public override void OnContext()
		{
		}

		public override void OnContextDispose()
		{
		}
	}
}
