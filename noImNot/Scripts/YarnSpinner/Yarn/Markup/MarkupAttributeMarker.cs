using System.Collections.Generic;

namespace Yarn.Markup
{
	internal struct MarkupAttributeMarker
	{
		public string Name { get; private set; }

		public int Position { get; private set; }

		public List<MarkupProperty> Properties { get; private set; }

		public TagType Type { get; private set; }

		internal int SourcePosition { get; set; }

		internal MarkupAttributeMarker(string name, int position, int sourcePosition, List<MarkupProperty> properties, TagType type)
		{
			Name = null;
			Position = 0;
			Properties = null;
			Type = default(TagType);
			SourcePosition = 0;
		}

		public bool TryGetProperty(string name, out MarkupValue result)
		{
			result = default(MarkupValue);
			return false;
		}
	}
}
