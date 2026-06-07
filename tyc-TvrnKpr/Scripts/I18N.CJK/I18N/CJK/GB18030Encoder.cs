using I18N.Common;

namespace I18N.CJK
{
	internal class GB18030Encoder : MonoEncoder
	{
		private static DbcsConvert gb2312;

		private char incomplete_byte_count;

		private char incomplete_bytes;

		public GB18030Encoder(MonoEncoding owner)
			: base(null)
		{
		}

		public unsafe override int GetByteCountImpl(char* chars, int count, bool refresh)
		{
			return 0;
		}

		public unsafe override int GetBytesImpl(char* chars, int charCount, byte* bytes, int byteCount, bool refresh)
		{
			return 0;
		}
	}
}
