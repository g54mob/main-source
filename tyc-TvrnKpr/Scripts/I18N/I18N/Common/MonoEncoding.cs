using System;
using System.Text;

namespace I18N.Common
{
	[Serializable]
	public abstract class MonoEncoding : Encoding
	{
		private readonly int win_code_page;

		public override int WindowsCodePage => 0;

		public MonoEncoding(int codePage)
		{
		}

		public MonoEncoding(int codePage, int windowsCodePage)
		{
		}

		public unsafe void HandleFallback(ref EncoderFallbackBuffer buffer, char* chars, ref int charIndex, ref int charCount, byte* bytes, ref int byteIndex, ref int byteCount)
		{
		}

		public override int GetByteCount(char[] chars, int index, int count)
		{
			return 0;
		}

		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			return 0;
		}

		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			return 0;
		}

		public unsafe override int GetByteCount(char* chars, int count)
		{
			return 0;
		}

		public unsafe override int GetBytes(char* chars, int charCount, byte* bytes, int byteCount)
		{
			return 0;
		}

		public unsafe abstract int GetByteCountImpl(char* chars, int charCount);

		public unsafe abstract int GetBytesImpl(char* chars, int charCount, byte* bytes, int byteCount);
	}
}
