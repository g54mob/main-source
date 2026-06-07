using I18N.Common;

namespace I18N.CJK
{
	public class CP51932Encoder : MonoEncoder
	{
		public CP51932Encoder(MonoEncoding encoding)
			: base(null)
		{
		}

		public unsafe override int GetByteCountImpl(char* chars, int count, bool refresh)
		{
			return 0;
		}

		public unsafe override int GetBytesImpl(char* chars, int charCount, byte* bytes, int byteCount, bool refresh)
		{
			return 0;
		}
	}
}
