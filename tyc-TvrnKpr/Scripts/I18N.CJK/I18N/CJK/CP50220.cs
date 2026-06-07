using System;

namespace I18N.CJK
{
	[Serializable]
	public class CP50220 : ISO2022JPEncoding
	{
		public override string EncodingName => null;

		public CP50220()
			: base(0, allow1ByteKana: false, allowShiftIO: false)
		{
		}
	}
}
