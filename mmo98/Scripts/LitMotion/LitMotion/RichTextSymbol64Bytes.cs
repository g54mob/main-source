using Unity.Collections;

namespace LitMotion
{
	internal readonly struct RichTextSymbol64Bytes
	{
		public readonly RichTextSymbolType Type;

		public readonly FixedString64Bytes Text;

		public RichTextSymbol64Bytes(RichTextSymbolType type, in FixedString64Bytes text)
		{
			Type = type;
			Text = text;
		}
	}
}
