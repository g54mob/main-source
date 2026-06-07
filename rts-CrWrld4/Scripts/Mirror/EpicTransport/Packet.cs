namespace EpicTransport
{
	public struct Packet
	{
		public const int headerSize = 9;

		public int id;

		public int fragment;

		public bool moreFragments;

		public byte[] data;

		public int size => 0;

		public byte[] ToBytes()
		{
			return null;
		}

		public void FromBytes(byte[] array)
		{
		}
	}
}
