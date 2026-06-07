using System;
using I18N.Common;

namespace I18N.CJK
{
	[Serializable]
	public class ISO2022JPEncoding : MonoEncoding
	{
		private readonly bool allow_1byte_kana;

		private readonly bool allow_shift_io;

		public override string BodyName => null;

		public override string HeaderName => null;

		public override string WebName => null;

		public ISO2022JPEncoding(int codePage, bool allow1ByteKana, bool allowShiftIO)
			: base(0)
		{
		}

		public override int GetMaxByteCount(int charCount)
		{
			return 0;
		}

		public override int GetMaxCharCount(int byteCount)
		{
			return 0;
		}

		public override int GetByteCount(char[] chars, int charIndex, int charCount)
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
	}
}
