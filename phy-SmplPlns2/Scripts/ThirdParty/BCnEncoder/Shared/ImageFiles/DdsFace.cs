namespace BCnEncoder.Shared.ImageFiles
{
	public class DdsFace
	{
		public uint Width { get; set; }

		public uint Height { get; set; }

		public uint SizeInBytes { get; }

		public DdsMipMap[] MipMaps { get; }

		public DdsFace(uint width, uint height, uint sizeInBytes, int numMipMaps)
		{
			Width = width;
			Height = height;
			SizeInBytes = sizeInBytes;
			MipMaps = new DdsMipMap[numMipMaps];
		}
	}
}
