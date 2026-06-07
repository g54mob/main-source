namespace I18N.CJK
{
	internal sealed class CP936Decoder : DbcsEncoding.DbcsDecoder
	{
		private int last_byte_count;

		private int last_byte_bytes;

		public CP936Decoder(DbcsConvert convert)
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
