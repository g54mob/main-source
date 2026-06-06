using Unity.Collections;

namespace LitMotion
{
	internal readonly struct RichTextSymbol32Bytes
	{
		public readonly RichTextSymbolType Type;

		public readonly FixedString32Bytes Text;

		public RichTextSymbol32Bytes(RichTextSymbolType type, in FixedString32Bytes text)
		{
			Type = type;
			Text = text;
		}
	}
}
