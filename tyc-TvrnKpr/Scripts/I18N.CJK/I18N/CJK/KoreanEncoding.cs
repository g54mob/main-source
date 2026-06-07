using System;
using System.Text;

namespace I18N.CJK
{
	[Serializable]
	internal class KoreanEncoding : DbcsEncoding
	{
		private sealed class KoreanDecoder : DbcsDecoder
		{
			private bool useUHC;

			private int last_byte_count;

			private int last_byte_conv;

			public KoreanDecoder(DbcsConvert convert, bool useUHC)
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

		private bool useUHC;

		public KoreanEncoding(int codepage, bool useUHC)
			: base(0)
		{
		}

		internal override DbcsConvert GetConvert()
		{
			return null;
		}

		public unsafe override int GetByteCountImpl(char* chars, int count)
		{
			return 0;
		}

		public unsafe override int GetBytesImpl(char* chars, int charCount, byte* bytes, int byteCount)
		{
			return 0;
		}

		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			return 0;
		}

		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			return 0;
		}

		public override Decoder GetDecoder()
		{
			return null;
		}
	}
}
