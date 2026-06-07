using Unity.Collections;

namespace LitMotion
{
	internal readonly struct RichTextSymbol128Bytes
	{
		public readonly RichTextSymbolType Type;

		public readonly FixedString128Bytes Text;

		public RichTextSymbol128Bytes(RichTextSymbolType type, in FixedString128Bytes text)
		{
			Type = type;
			Text = text;
		}
	}
}
