using System;
using System.Text;

namespace I18N.Common
{
	[Serializable]
	public abstract class ByteEncoding : MonoEncoding
	{
		protected char[] toChars;

		protected string encodingName;

		protected string bodyName;

		protected string headerName;

		protected string webName;

		protected bool isBrowserDisplay;

		protected bool isBrowserSave;

		protected bool isMailNewsDisplay;

		protected bool isMailNewsSave;

		protected int windowsCodePage;

		private static byte[] isNormalized;

		private static byte[] isNormalizedComputed;

		private static byte[] normalization_bytes;

		public override bool IsSingleByte => false;

		public override string BodyName => null;

		public override string EncodingName => null;

		public override string HeaderName => null;

		public override bool IsBrowserDisplay => false;

		public override bool IsBrowserSave => false;

		public override bool IsMailNewsDisplay => false;

		public override bool IsMailNewsSave => false;

		public override string WebName => null;

		public override int WindowsCodePage => 0;

		protected ByteEncoding(int codePage, char[] toChars, string encodingName, string bodyName, string headerName, string webName, bool isBrowserDisplay, bool isBrowserSave, bool isMailNewsDisplay, bool isMailNewsSave, int windowsCodePage)
			: base(0)
		{
		}

		public override bool IsAlwaysNormalized(NormalizationForm form)
		{
			return false;
		}

		public override int GetByteCount(string s)
		{
			return 0;
		}

		public unsafe override int GetByteCountImpl(char* chars, int count)
		{
			return 0;
		}

		protected unsafe abstract void ToBytes(char* chars, int charCount, byte* bytes, int byteCount);

		protected virtual void ToBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
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

		public override string GetString(byte[] bytes, int index, int count)
		{
			return null;
		}

		public override string GetString(byte[] bytes)
		{
			return null;
		}
	}
}
