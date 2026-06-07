using System;
using System.Text;
using I18N.Common;

namespace I18N.CJK
{
	[Serializable]
	internal abstract class DbcsEncoding : MonoEncoding
	{
		internal abstract class DbcsDecoder : Decoder
		{
			protected DbcsConvert convert;

			public DbcsDecoder(DbcsConvert convert)
			{
			}

			internal void CheckRange(byte[] bytes, int index, int count)
			{
			}

			internal void CheckRange(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
			{
			}
		}

		public override bool IsBrowserDisplay => false;

		public override bool IsBrowserSave => false;

		public override bool IsMailNewsDisplay => false;

		public override bool IsMailNewsSave => false;

		public DbcsEncoding(int codePage)
			: base(0)
		{
		}

		public DbcsEncoding(int codePage, int windowsCodePage)
			: base(0)
		{
		}

		internal abstract DbcsConvert GetConvert();

		public override int GetByteCount(char[] chars, int index, int count)
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
