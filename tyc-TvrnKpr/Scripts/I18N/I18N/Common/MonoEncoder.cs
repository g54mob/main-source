using System.Text;

namespace I18N.Common
{
	public abstract class MonoEncoder : Encoder
	{
		private MonoEncoding encoding;

		public MonoEncoder(MonoEncoding encoding)
		{
		}

		public override int GetByteCount(char[] chars, int index, int count, bool refresh)
		{
			return 0;
		}

		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, bool flush)
		{
			return 0;
		}

		public unsafe abstract int GetByteCountImpl(char* chars, int charCount, bool refresh);

		public unsafe abstract int GetBytesImpl(char* chars, int charCount, byte* bytes, int byteCount, bool refresh);

		public unsafe override int GetBytes(char* chars, int charCount, byte* bytes, int byteCount, bool flush)
		{
			return 0;
		}

		public unsafe void HandleFallback(char* chars, ref int charIndex, ref int charCount, byte* bytes, ref int byteIndex, ref int byteCount)
		{
		}
	}
}
