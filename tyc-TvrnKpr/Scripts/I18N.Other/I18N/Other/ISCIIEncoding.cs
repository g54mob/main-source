using System;
using I18N.Common;

namespace I18N.Other
{
	[Serializable]
	public abstract class ISCIIEncoding : MonoEncoding
	{
		private int shift;

		private string encodingName;

		private string webName;

		public override string BodyName => null;

		public override string EncodingName => null;

		public override string HeaderName => null;

		public override string WebName => null;

		protected ISCIIEncoding(int codePage, int shift, string encodingName, string webName)
			: base(0)
		{
		}

		public override int GetByteCount(char[] chars, int index, int count)
		{
			return 0;
		}

		public override int GetByteCount(string s)
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
	}
}
