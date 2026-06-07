using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class EnumValueHelper<TEnum>
	{
		private static EnumValueHelper<TEnum> pEcSNMNyRjNgkciRzMRMgPmMISw;

		private TEnum[] EnCNkppFhljEdJjOJalqCwvMojRR;

		private ReadOnlyCollection<TEnum> wGnpuwIvPcHnpkGhfOwDeeqGxqV;

		private string[] uCBkoBtbbTCeFGPcSwVsLeodxlJJ;

		private ReadOnlyCollection<string> oHYDiWsynLbibOtCplTRMXIknqc;

		public static EnumValueHelper<TEnum> Default => pEcSNMNyRjNgkciRzMRMgPmMISw ?? (pEcSNMNyRjNgkciRzMRMgPmMISw = new EnumValueHelper<TEnum>());

		public IList<TEnum> values => wGnpuwIvPcHnpkGhfOwDeeqGxqV;

		public IList<string> names
		{
			get
			{
				if (oHYDiWsynLbibOtCplTRMXIknqc == null)
				{
					uCBkoBtbbTCeFGPcSwVsLeodxlJJ = Enum.GetNames(typeof(TEnum));
					oHYDiWsynLbibOtCplTRMXIknqc = new ReadOnlyCollection<string>(uCBkoBtbbTCeFGPcSwVsLeodxlJJ);
				}
				return oHYDiWsynLbibOtCplTRMXIknqc;
			}
		}

		public EnumValueHelper()
		{
			if (!EnumTools.IsEnum(typeof(TEnum)))
			{
				throw new ArgumentException("TEnum must be an enum type.");
			}
			EnCNkppFhljEdJjOJalqCwvMojRR = (TEnum[])Enum.GetValues(typeof(TEnum));
			wGnpuwIvPcHnpkGhfOwDeeqGxqV = new ReadOnlyCollection<TEnum>(EnCNkppFhljEdJjOJalqCwvMojRR);
		}
	}
}
