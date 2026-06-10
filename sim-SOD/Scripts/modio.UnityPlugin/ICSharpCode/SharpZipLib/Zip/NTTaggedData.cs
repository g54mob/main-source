using System;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class NTTaggedData : ITaggedData
	{
		private DateTime _lastAccessTime;

		private DateTime _lastModificationTime;

		private DateTime _createTime;

		public short TagID => 0;

		public DateTime LastModificationTime
		{
			get
			{
				return default(DateTime);
			}
			set
			{
			}
		}

		public DateTime CreateTime
		{
			get
			{
				return default(DateTime);
			}
			set
			{
			}
		}

		public DateTime LastAccessTime
		{
			get
			{
				return default(DateTime);
			}
			set
			{
			}
		}

		public void SetData(byte[] data, int index, int count)
		{
		}

		public byte[] GetData()
		{
			return null;
		}

		public static bool IsValidValue(DateTime value)
		{
			return false;
		}
	}
}
