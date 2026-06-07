using System;

namespace I18N.CJK
{
	[Serializable]
	internal class CP949 : KoreanEncoding
	{
		private const int UHC_CODE_PAGE = 949;

		public override string BodyName => null;

		public override string EncodingName => null;

		public override string HeaderName => null;

		public override string WebName => null;

		public CP949()
			: base(0, useUHC: false)
		{
		}
	}
}
