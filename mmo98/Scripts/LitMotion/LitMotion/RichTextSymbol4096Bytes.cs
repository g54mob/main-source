using Unity.Collections;

namespace LitMotion
{
	internal struct RichTextSymbol4096Bytes
	{
		public RichTextSymbolType Type;

		public FixedString4096Bytes Text;

		public RichTextSymbol4096Bytes(RichTextSymbolType type, in FixedString4096Bytes text)
		{
			Type = type;
			Text = text;
		}
	}
}
