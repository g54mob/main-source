using System.Security;

namespace System.Text
{
	[Serializable]
	public class BinaryEncoding : Encoding
	{
		public override bool IsSingleByte => false;

		[SecuritySafeCritical]
		public override int GetByteCount(char[] chars, int index, int count)
		{
			return 0;
		}

		[SecuritySafeCritical]
		public override int GetByteCount(string chars)
		{
			return 0;
		}

		[SecurityCritical]
		public unsafe override int GetByteCount(char* chars, int count)
		{
			return 0;
		}

		[SecuritySafeCritical]
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			return 0;
		}

		[SecurityCritical]
		public unsafe override int GetBytes(char* chars, int charCount, byte* bytes, int byteCount)
		{
			return 0;
		}

		[SecuritySafeCritical]
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			return 0;
		}

		[SecurityCritical]
		public unsafe override int GetCharCount(byte* bytes, int count)
		{
			return 0;
		}

		[SecuritySafeCritical]
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			return 0;
		}

		[SecurityCritical]
		public unsafe override int GetChars(byte* bytes, int byteCount, char* chars, int charCount)
		{
			return 0;
		}

		internal unsafe static string CreateStringFromEncoding(byte* bytes, int byteLength, Encoding encoding)
		{
			return null;
		}

		public static string GetStringFromBytes(byte[] bytes)
		{
			return null;
		}

		public static byte[] GetBytesFromString(string str)
		{
			return null;
		}

		[SecuritySafeCritical]
		public override string GetString(byte[] bytes, int byteIndex, int byteCount)
		{
			return null;
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
