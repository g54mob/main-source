using System.Collections.Generic;

namespace Yarn.Markup
{
	public struct MarkupAttribute
	{
		public int Position { get; internal set; }

		public int Length { get; internal set; }

		public string Name { get; internal set; }

		public IReadOnlyDictionary<string, MarkupValue> Properties { get; internal set; }

		internal int SourcePosition { get; private set; }

		internal MarkupAttribute(int position, int sourcePosition, int length, string name, IEnumerable<MarkupProperty> properties)
		{
			Position = 0;
			Length = 0;
			Name = null;
			Properties = null;
			SourcePosition = 0;
		}

		internal MarkupAttribute(MarkupAttributeMarker openingMarker, int length)
		{
			Position = 0;
			Length = 0;
			Name = null;
			Properties = null;
			SourcePosition = 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
