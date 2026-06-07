using System;
using System.Text;
using I18N.Common;

namespace I18N.CJK
{
	[Serializable]
	public class GB18030Encoding : MonoEncoding
	{
		public override string EncodingName
		{
			get
			{
				return "Chinese Simplified (GB18030)";
			}
		}

		public override string HeaderName
		{
			get
			{
				return "GB18030";
			}
		}

		public override string BodyName
		{
			get
			{
				return "GB18030";
			}
		}

		public override string WebName
		{
			get
			{
				return "GB18030";
			}
		}

		public override bool IsMailNewsDisplay
		{
			get
			{
				return true;
			}
		}

		public override bool IsMailNewsSave
		{
			get
			{
				return true;
			}
		}

		public override bool IsBrowserDisplay
		{
			get
			{
				return true;
			}
		}

		public override bool IsBrowserSave
		{
			get
			{
				return true;
			}
		}

		public GB18030Encoding()
			: base(54936, 936)
		{
		}

		public override int GetMaxByteCount(int len)
		{
			return len * 4;
		}

		public override int GetMaxCharCount(int len)
		{
			return len;
		}

		public override int GetByteCount(char[] chars, int index, int length)
		{
			return new GB18030Encoder(this).GetByteCount(chars, index, length, true);
		}

		public unsafe override int GetByteCountImpl(char* chars, int count)
		{
			return new GB18030Encoder(this).GetByteCountImpl(chars, count, true);
		}

		public unsafe override int GetBytesImpl(char* chars, int charCount, byte* bytes, int byteCount)
		{
			return new GB18030Encoder(this).GetBytesImpl(chars, charCount, bytes, byteCount, true);
		}

		public override int GetCharCount(byte[] bytes, int start, int len)
		{
			return new GB18030Decoder().GetCharCount(bytes, start, len);
		}

		public override int GetChars(byte[] bytes, int byteIdx, int srclen, char[] chars, int charIdx)
		{
			return new GB18030Decoder().GetChars(bytes, byteIdx, srclen, chars, charIdx);
		}

		public override Encoder GetEncoder()
		{
			return new GB18030Encoder(this);
		}

		public override Decoder GetDecoder()
		{
			return new GB18030Decoder();
		}
	}
}
