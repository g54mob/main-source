namespace Noesis
{
	public struct ViewStats
	{
		public float FrameTime;

		public float UpdateTime;

		public float RenderTime;

		public uint Triangles;

		public uint Draws;

		public uint Batches;

		public uint Tessellations;

		public uint Flushes;

		public uint GeometrySize;

		public uint Masks;

		public uint Opacities;

		public uint RenderTargetSwitches;

		public uint UploadedRamps;

		public uint RasterizedGlyphs;

		public uint DiscardedGlyphTiles;
	}
}
