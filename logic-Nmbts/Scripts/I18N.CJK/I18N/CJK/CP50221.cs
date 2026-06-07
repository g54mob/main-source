using System;

namespace I18N.CJK
{
	[Serializable]
	public class CP50221 : ISO2022JPEncoding
	{
		public override string EncodingName
		{
			get
			{
				return "Japanese (JIS-Allow 1 byte Kana)";
			}
		}

		public CP50221()
			: base(50221, true, false)
		{
		}
	}
}
