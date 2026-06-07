using System.Text;

namespace NAudio.Utils
{
	public class ByteEncoding : Encoding
	{
		public static readonly ByteEncoding Instance;

		private ByteEncoding()
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

		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			return 0;
		}

		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			return 0;
		}

		public override int GetMaxCharCount(int byteCount)
		{
			return 0;
		}

		public override int GetMaxByteCount(int charCount)
		{
			return 0;
		}
	}
}
