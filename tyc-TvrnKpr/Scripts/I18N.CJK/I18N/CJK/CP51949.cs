using System;

namespace I18N.CJK
{
	[Serializable]
	internal class CP51949 : KoreanEncoding
	{
		private const int EUCKR_CODE_PAGE = 51949;

		public override string BodyName => null;

		public override string EncodingName => null;

		public override string HeaderName => null;

		public override string WebName => null;

		public CP51949()
			: base(0, useUHC: false)
		{
		}
	}
}
