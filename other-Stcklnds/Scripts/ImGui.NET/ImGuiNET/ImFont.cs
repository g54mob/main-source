namespace ImGuiNET
{
	public struct ImFont
	{
		public ImVector IndexAdvanceX;

		public float FallbackAdvanceX;

		public float FontSize;

		public ImVector IndexLookup;

		public ImVector Glyphs;

		public unsafe ImFontGlyph* FallbackGlyph;

		public unsafe ImFontAtlas* ContainerAtlas;

		public unsafe ImFontConfig* ConfigData;

		public short ConfigDataCount;

		public ushort FallbackChar;

		public ushort EllipsisChar;

		public ushort DotChar;

		public byte DirtyLookupTables;

		public float Scale;

		public float Ascent;

		public float Descent;

		public int MetricsTotalSurface;

		public unsafe fixed byte Used4kPagesMap[2];
	}
}
