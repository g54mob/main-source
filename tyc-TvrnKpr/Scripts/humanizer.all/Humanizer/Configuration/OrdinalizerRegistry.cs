using Humanizer.Localisation.Ordinalizers;

namespace Humanizer.Configuration
{
	internal class OrdinalizerRegistry : LocaliserRegistry<IOrdinalizer>
	{
		public OrdinalizerRegistry()
			: base((IOrdinalizer)default(_00210))
		{
		}
	}
}
