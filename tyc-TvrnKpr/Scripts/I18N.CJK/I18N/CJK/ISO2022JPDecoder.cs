using System.Text;

namespace I18N.CJK
{
	internal class ISO2022JPDecoder : Decoder
	{
		private static JISConvert convert;

		private readonly bool allow_shift_io;

		private ISO2022JPMode m;

		private bool shifted_in_conv;

		private bool shifted_in_count;

		public ISO2022JPDecoder(bool allow1ByteKana, bool allowShiftIO)
		{
		}

		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			return 0;
		}

		private int ToChar(int value)
		{
			return 0;
		}

		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			return 0;
		}

		public override void Reset()
		{
		}
	}
}
