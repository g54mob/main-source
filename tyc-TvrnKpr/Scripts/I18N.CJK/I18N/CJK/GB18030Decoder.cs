namespace I18N.CJK
{
	internal class GB18030Decoder : DbcsEncoding.DbcsDecoder
	{
		private static DbcsConvert gb2312;

		public GB18030Decoder()
			: base(null)
		{
		}

		public override int GetCharCount(byte[] bytes, int start, int len)
		{
			return 0;
		}

		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			return 0;
		}
	}
}
