using System;

namespace I18N.CJK
{
	[Serializable]
	public class CP50221 : ISO2022JPEncoding
	{
		public override string EncodingName => null;

		public CP50221()
			: base(0, allow1ByteKana: false, allowShiftIO: false)
		{
		}
	}
}
