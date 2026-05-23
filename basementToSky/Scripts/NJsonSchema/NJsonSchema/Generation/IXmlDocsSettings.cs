using Namotion.Reflection;

namespace NJsonSchema.Generation
{
	public interface IXmlDocsSettings
	{
		bool UseXmlDocumentation { get; }

		bool ResolveExternalXmlDocumentation { get; }

		XmlDocsFormattingMode XmlDocumentationFormatting { get; set; }
	}
}
