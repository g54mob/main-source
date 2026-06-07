namespace BestHTTP.Decompression
{
	public struct DecompressedData
	{
		public readonly byte[] Data;

		public readonly int Length;

		internal DecompressedData(byte[] data, int length)
		{
			Data = null;
			Length = 0;
		}
	}
}
