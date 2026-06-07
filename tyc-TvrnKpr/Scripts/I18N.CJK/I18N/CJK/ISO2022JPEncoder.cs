using I18N.Common;

namespace I18N.CJK
{
	internal class ISO2022JPEncoder : MonoEncoder
	{
		private static JISConvert convert;

		private readonly bool allow_1byte_kana;

		private readonly bool allow_shift_io;

		private ISO2022JPMode m;

		private bool shifted_in_count;

		private bool shifted_in_conv;

		private static readonly char[] full_width_map;

		public ISO2022JPEncoder(MonoEncoding owner, bool allow1ByteKana, bool allowShiftIO)
			: base(null)
		{
		}

		public unsafe override int GetByteCountImpl(char* chars, int charCount, bool flush)
		{
			return 0;
		}

		private unsafe void SwitchMode(byte* bytes, ref int byteIndex, ref int byteCount, ref ISO2022JPMode cur, ISO2022JPMode next)
		{
		}

		public unsafe override int GetBytesImpl(char* chars, int charCount, byte* bytes, int byteCount, bool flush)
		{
			return 0;
		}

		public override void Reset()
		{
		}
	}
}
