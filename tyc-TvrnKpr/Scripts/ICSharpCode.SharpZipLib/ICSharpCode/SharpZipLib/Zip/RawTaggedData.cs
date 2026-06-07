namespace ICSharpCode.SharpZipLib.Zip
{
	public class RawTaggedData : ITaggedData
	{
		private short _tag;

		private byte[] _data;

		public short TagID
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte[] Data
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public RawTaggedData(short tag)
		{
		}

		public void SetData(byte[] data, int offset, int count)
		{
		}

		public byte[] GetData()
		{
			return null;
		}
	}
}
