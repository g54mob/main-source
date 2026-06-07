using Namotion.Reflection;

namespace NJsonSchema.Generation
{
	internal static class XmlDocsSettingsExtensions
	{
		internal static XmlDocsOptions GetXmlDocsOptions(this IXmlDocsSettings settings)
		{
			return new XmlDocsOptions
			{
				ResolveExternalXmlDocs = settings.ResolveExternalXmlDocumentation,
				FormattingMode = settings.XmlDocumentationFormatting
			};
		}
	}
}
