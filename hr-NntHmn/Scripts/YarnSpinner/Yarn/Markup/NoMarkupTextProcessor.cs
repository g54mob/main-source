namespace Yarn.Markup
{
	internal class NoMarkupTextProcessor : IAttributeMarkerProcessor
	{
		public string ReplacementTextForMarker(MarkupAttributeMarker marker)
		{
			return null;
		}
	}
}
