namespace Namotion.Reflection
{
	public class XmlDocsOptions
	{
		public static XmlDocsOptions Default { get; } = new XmlDocsOptions();

		public bool ResolveExternalXmlDocs { get; set; } = true;

		public XmlDocsFormattingMode FormattingMode { get; set; }
	}
}
