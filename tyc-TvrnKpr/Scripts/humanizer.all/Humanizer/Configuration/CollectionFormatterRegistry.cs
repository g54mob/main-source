using Humanizer.Localisation.CollectionFormatters;

namespace Humanizer.Configuration
{
	internal class CollectionFormatterRegistry : LocaliserRegistry<ICollectionFormatter>
	{
		public CollectionFormatterRegistry()
			: base((ICollectionFormatter)default(_00210))
		{
		}
	}
}
