using Unity.Collections;

namespace LitMotion
{
	internal readonly struct RichTextSymbol512Bytes
	{
		public readonly RichTextSymbolType Type;

		public readonly FixedString512Bytes Text;

		public RichTextSymbol512Bytes(RichTextSymbolType type, in FixedString512Bytes text)
		{
			Type = type;
			Text = text;
		}
	}
}
