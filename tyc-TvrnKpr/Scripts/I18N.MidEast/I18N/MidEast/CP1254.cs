using System;
using I18N.Common;

namespace I18N.MidEast
{
	[Serializable]
	public class CP1254 : ByteEncoding
	{
		private static readonly char[] ToChars;

		public CP1254()
			: base(0, null, null, null, null, null, isBrowserDisplay: false, isBrowserSave: false, isMailNewsDisplay: false, isMailNewsSave: false, 0)
		{
		}

		protected unsafe override void ToBytes(char* chars, int charCount, byte* bytes, int byteCount)
		{
		}
	}
}
