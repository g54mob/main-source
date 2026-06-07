using System;

namespace I18N.CJK
{
	[Serializable]
	public class CP50220 : ISO2022JPEncoding
	{
		public override string EncodingName
		{
			get
			{
				return "Japanese (JIS)";
			}
		}

		public CP50220()
			: base(50220, false, false)
		{
		}
	}
}
