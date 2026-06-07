using System;

namespace I18N.CJK
{
	internal class CP51932Decoder : DbcsEncoding.DbcsDecoder
	{
		private int last_count;

		private int last_bytes;

		public CP51932Decoder()
			: base(null)
		{
		}

		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			return 0;
		}

		public override int GetCharCount(byte[] bytes, int index, int count, bool refresh)
		{
			return 0;
		}

		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			return 0;
		}

		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex, bool refresh)
		{
			return 0;
		}

		private Exception Insufficient()
		{
			return null;
		}
	}
}
