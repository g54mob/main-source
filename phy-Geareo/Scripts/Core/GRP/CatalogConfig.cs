using System.Collections.Generic;
using Rhizomatic;

namespace GRP
{
	public class CatalogConfig : Config
	{
		public List<PartDefinitionConfig> parts;

		public List<PartCategoryConfig> categories;

		public bool _fetch;

		private void OnValidate()
		{
		}
	}
}
