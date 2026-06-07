using System;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class ExtendedUnixData : ITaggedData
	{
		[Flags]
		public enum Flags : byte
		{
			ModificationTime = 1,
			AccessTime = 2,
			CreateTime = 4
		}

		private Flags _flags;

		private DateTime _modificationTime;

		private DateTime _lastAccessTime;

		private DateTime _createTime;

		public short TagID => 0;

		public DateTime ModificationTime
		{
			get
			{
				return default(DateTime);
			}
			set
			{
			}
		}

		public DateTime AccessTime
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

		private Flags Include
		{
			get
			{
				return default(Flags);
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
