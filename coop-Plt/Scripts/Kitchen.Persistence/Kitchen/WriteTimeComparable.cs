using System;
using Platforms;

namespace Kitchen
{
	internal struct WriteTimeComparable : IComparable<WriteTimeComparable>
	{
		public FileReference FileInfo;

		public IComparable Comparable;

		public int CompareTo(WriteTimeComparable other)
		{
			if (Comparable != null && other.Comparable == null)
			{
				return 1;
			}
			if (Comparable == null && other.Comparable != null)
			{
				return -1;
			}
			if (Comparable != null && other.Comparable != null)
			{
				int num = Comparable.CompareTo(other.Comparable);
				if (num != 0)
				{
					return num;
				}
			}
			int num2 = FileInfo.LastWriteTime.CompareTo(other.FileInfo.LastWriteTime);
			if (num2 != 0)
			{
				return num2;
			}
			return string.Compare(FileInfo.FileName, other.FileInfo.FileName, StringComparison.Ordinal);
		}
	}
}
