namespace Humanizer.Localisation.CollectionFormatters
{
	internal class OxfordStyleCollectionFormatter : DefaultCollectionFormatter
	{
		public OxfordStyleCollectionFormatter(string defaultSeparator)
			: base(null)
		{
		}

		protected override string GetConjunctionFormatString(int itemCount)
		{
			return null;
		}
	}
}
