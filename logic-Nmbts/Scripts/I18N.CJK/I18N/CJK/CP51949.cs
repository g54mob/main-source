using System;

namespace I18N.CJK
{
	[Serializable]
	internal class CP51949 : KoreanEncoding
	{
		private const int EUCKR_CODE_PAGE = 51949;

		public override string BodyName
		{
			get
			{
				return "euc-kr";
			}
		}

		public override string EncodingName
		{
			get
			{
				return "Korean (EUC)";
			}
		}

		public override string HeaderName
		{
			get
			{
				return "euc-kr";
			}
		}

		public override string WebName
		{
			get
			{
				return "euc-kr";
			}
		}

		public CP51949()
			: base(51949, false)
		{
		}
	}
}
