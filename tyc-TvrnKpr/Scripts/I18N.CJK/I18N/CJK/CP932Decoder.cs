namespace I18N.CJK
{
	internal sealed class CP932Decoder : DbcsEncoding.DbcsDecoder
	{
		private new JISConvert convert;

		private int last_byte_count;

		private int last_byte_chars;

		public CP932Decoder(JISConvert convert)
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
	}
}
