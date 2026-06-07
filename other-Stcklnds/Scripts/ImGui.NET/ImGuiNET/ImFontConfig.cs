using UnityEngine;

namespace ImGuiNET
{
	public struct ImFontConfig
	{
		public unsafe void* FontData;

		public int FontDataSize;

		public byte FontDataOwnedByAtlas;

		public int FontNo;

		public float SizePixels;

		public int OversampleH;

		public int OversampleV;

		public byte PixelSnapH;

		public Vector2 GlyphExtraSpacing;

		public Vector2 GlyphOffset;

		public unsafe ushort* GlyphRanges;

		public float GlyphMinAdvanceX;

		public float GlyphMaxAdvanceX;

		public byte MergeMode;

		public uint FontBuilderFlags;

		public float RasterizerMultiply;

		public ushort EllipsisChar;

		public unsafe fixed byte Name[40];

		public unsafe ImFont* DstFont;
	}
}
