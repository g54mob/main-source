using System;

namespace I18N.CJK
{
	[Serializable]
	internal class CP949 : KoreanEncoding
	{
		private const int UHC_CODE_PAGE = 949;

		public override string BodyName
		{
			get
			{
				return "ks_c_5601-1987";
			}
		}

		public override string EncodingName
		{
			get
			{
				return "Korean (UHC)";
			}
		}

		public override string HeaderName
		{
			get
			{
				return "ks_c_5601-1987";
			}
		}

		public override string WebName
		{
			get
			{
				return "ks_c_5601-1987";
			}
		}

		public CP949()
			: base(949, true)
		{
		}
	}
}
