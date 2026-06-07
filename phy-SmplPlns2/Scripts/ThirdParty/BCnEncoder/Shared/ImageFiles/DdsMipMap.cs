namespace BCnEncoder.Shared.ImageFiles
{
	public class DdsMipMap
	{
		public uint Width { get; set; }

		public uint Height { get; set; }

		public uint SizeInBytes { get; }

		public byte[] Data { get; }

		public DdsMipMap(byte[] data, uint width, uint height)
		{
			Width = width;
			Height = height;
			SizeInBytes = (uint)data.Length;
			Data = data;
		}
	}
}
