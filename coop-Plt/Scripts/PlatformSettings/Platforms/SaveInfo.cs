using System;
using System.Text;

namespace Platforms
{
	public class SaveInfo<T> : IComparable<SaveInfo<T>> where T : IComparable<T>
	{
		public byte[] Data;

		public T Extra;

		public DateTime LastWriteTime;

		public string Name;

		public int CompareTo(SaveInfo<T> other)
		{
			int num;
			if (Extra != null && other.Extra != null)
			{
				ref T extra = ref Extra;
				T extra2 = other.Extra;
				num = extra.CompareTo(extra2);
				if (num != 0)
				{
					return num;
				}
			}
			num = LastWriteTime.CompareTo(other.LastWriteTime);
			if (num != 0)
			{
				return num;
			}
			return string.Compare(Name, other.Name, StringComparison.Ordinal);
		}

		public string Text()
		{
			if (Data == null)
			{
				return "";
			}
			return Encoding.UTF8.GetString(Data);
		}
	}
}
