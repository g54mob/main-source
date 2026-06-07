using System;
using System.Text;

namespace I18N.CJK
{
	[Serializable]
	internal class CP936 : DbcsEncoding
	{
		private const int GB2312_CODE_PAGE = 936;

		public override string BodyName => null;

		public override string EncodingName => null;

		public override string HeaderName => null;

		public override bool IsBrowserDisplay => false;

		public override bool IsBrowserSave => false;

		public override bool IsMailNewsDisplay => false;

		public override bool IsMailNewsSave => false;

		public override string WebName => null;

		public CP936()
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
