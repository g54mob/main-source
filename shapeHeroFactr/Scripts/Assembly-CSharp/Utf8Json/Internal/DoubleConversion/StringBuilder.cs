namespace Utf8Json.Internal.DoubleConversion
{
	internal struct StringBuilder
	{
		public byte[] buffer;

		public int offset;

		public StringBuilder(byte[] buffer, int position)
		{
			this.buffer = null;
			offset = 0;
		}

		public void AddCharacter(byte str)
		{
		}

		public void AddString(byte[] str)
		{
		}

		public void AddSubstring(byte[] str, int length)
		{
		}

		public void AddSubstring(byte[] str, int start, int length)
		{
		}

		public void AddPadding(byte c, int count)
		{
		}

		public void AddStringSlow(string str)
		{
		}
	}
}
