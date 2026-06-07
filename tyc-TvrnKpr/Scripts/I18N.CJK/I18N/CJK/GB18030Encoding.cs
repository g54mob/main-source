using System;
using System.Text;
using I18N.Common;

namespace I18N.CJK
{
	[Serializable]
	public class GB18030Encoding : MonoEncoding
	{
		public override string EncodingName => null;

		public override string HeaderName => null;

		public override string BodyName => null;

		public override string WebName => null;

		public override bool IsMailNewsDisplay => false;

		public override bool IsMailNewsSave => false;

		public override bool IsBrowserDisplay => false;

		public override bool IsBrowserSave => false;

		public GB18030Encoding()
			: base(0)
		{
		}

		public override int GetMaxByteCount(int len)
		{
			return 0;
		}

		public override int GetMaxCharCount(int len)
		{
			return 0;
		}

		public override int GetByteCount(char[] chars, int index, int length)
		{
			return 0;
		}

		public unsafe override int GetByteCountImpl(char* chars, int count)
		{
			return 0;
		}

		public unsafe override int GetBytesImpl(char* chars, int charCount, byte* bytes, int byteCount)
		{
			return 0;
		}

		public override int GetCharCount(byte[] bytes, int start, int len)
		{
			return 0;
		}

		public override int GetChars(byte[] bytes, int byteIdx, int srclen, char[] chars, int charIdx)
		{
			return 0;
		}

		public override Encoder GetEncoder()
		{
			return null;
		}

		public override Decoder GetDecoder()
		{
			return null;
		}
	}
}
