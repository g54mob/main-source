using System;

namespace I18N.CJK
{
	[Serializable]
	public class CP50222 : ISO2022JPEncoding
	{
		public override string EncodingName
		{
			get
			{
				return "Japanese (JIS-Allow 1 byte Kana - SO/SI)";
			}
		}

		public CP50222()
			: base(50222, true, true)
		{
		}
	}
}
