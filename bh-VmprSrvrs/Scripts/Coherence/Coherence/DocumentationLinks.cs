using System.Collections.Generic;

namespace Coherence
{
	internal static class DocumentationLinks
	{
		private static Dictionary<DocumentationKeys, string> documentationLinks;

		public static IEnumerable<DocumentationKeys> ActiveKeys => null;

		public static string GetDocsUrl(DocumentationKeys key = DocumentationKeys.None)
		{
			return null;
		}

		private static string GetDocsBaseUrl()
		{
			return null;
		}

		private static string GetUnpublishedDocsBaseUrl()
		{
			return null;
		}
	}
}
