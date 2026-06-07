using System;
using System.Text;
using I18N.Common;

namespace I18N.CJK
{
	[Serializable]
	public class CP51932 : MonoEncoding
	{
		private const int EUC_JP_CODE_PAGE = 51932;

		public override string BodyName => null;

		public override string EncodingName => null;

		public override string HeaderName => null;

		public override bool IsBrowserDisplay => false;

		public override bool IsBrowserSave => false;

		public override bool IsMailNewsDisplay => false;

		public override bool IsMailNewsSave => false;

		public override string WebName => null;

		public CP51932()
			: base(0)
		{
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

		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			return 0;
		}

		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			return 0;
		}

		public override int GetMaxByteCount(int charCount)
		{
			return 0;
		}

		public override int GetMaxCharCount(int byteCount)
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
