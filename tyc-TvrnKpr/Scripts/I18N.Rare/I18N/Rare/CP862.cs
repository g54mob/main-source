using System;
using I18N.Common;

namespace I18N.Rare
{
	[Serializable]
	public class CP862 : ByteEncoding
	{
		private static readonly char[] ToChars;

		public CP862()
			: base(0, null, null, null, null, null, isBrowserDisplay: false, isBrowserSave: false, isMailNewsDisplay: false, isMailNewsSave: false, 0)
		{
		}

		protected unsafe override void ToBytes(char* chars, int charCount, byte* bytes, int byteCount)
		{
		}
	}
}
