namespace VoxelBusters.EssentialKit
{
	public class RawMediaData
	{
		public byte[] Bytes { get; private set; }

		public string Mime { get; private set; }

		internal RawMediaData(byte[] bytes, string mime)
		{
		}
	}
}
