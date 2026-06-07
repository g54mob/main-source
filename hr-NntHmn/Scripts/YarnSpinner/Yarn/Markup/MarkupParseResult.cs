using System.Collections.Generic;

namespace Yarn.Markup
{
	public struct MarkupParseResult
	{
		public string Text;

		public List<MarkupAttribute> Attributes;

		internal MarkupParseResult(string text, List<MarkupAttribute> attributes)
		{
			Text = null;
			Attributes = null;
		}

		public bool TryGetAttributeWithName(string name, out MarkupAttribute attribute)
		{
			attribute = default(MarkupAttribute);
			return false;
		}

		public string TextForAttribute(MarkupAttribute attribute)
		{
			return null;
		}

		public MarkupParseResult DeleteRange(MarkupAttribute attributeToDelete)
		{
			return default(MarkupParseResult);
		}
	}
}
