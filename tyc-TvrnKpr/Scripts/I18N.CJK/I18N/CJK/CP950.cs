using System;
using System.Text;

namespace I18N.CJK
{
	[Serializable]
	internal class CP950 : DbcsEncoding
	{
		private sealed class CP950Decoder : DbcsDecoder
		{
			private int last_byte_count;

			private int last_byte_conv;

			public CP950Decoder(DbcsConvert convert)
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

		private const int BIG5_CODE_PAGE = 950;

		public override string BodyName => null;

		public override string EncodingName => null;

		public override string HeaderName => null;

		public override string WebName => null;

		public CP950()
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
