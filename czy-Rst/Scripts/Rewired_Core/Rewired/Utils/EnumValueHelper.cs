using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class EnumValueHelper<TEnum>
	{
		private static EnumValueHelper<TEnum> BTdnbuANoLFXuHqjOUnXbBPrMdeEA;

		private TEnum[] pdhaaCLRMFMlutFwwshXBPYkqwQf;

		private ReadOnlyCollection<TEnum> LbjwYIgOyvAxESQYLJMPjAnDAnIi;

		private string[] ppaaiWikeQfAyDDmLDsyLzxYvRNdA;

		private ReadOnlyCollection<string> KyfEIRkZtJVnUIrqLPFVlUvwUmWnA;

		public static EnumValueHelper<TEnum> Default => BTdnbuANoLFXuHqjOUnXbBPrMdeEA ?? (BTdnbuANoLFXuHqjOUnXbBPrMdeEA = new EnumValueHelper<TEnum>());

		public IList<TEnum> values => LbjwYIgOyvAxESQYLJMPjAnDAnIi;

		public IList<string> names
		{
			get
			{
				if (KyfEIRkZtJVnUIrqLPFVlUvwUmWnA == null)
				{
					ppaaiWikeQfAyDDmLDsyLzxYvRNdA = Enum.GetNames(typeof(TEnum));
					KyfEIRkZtJVnUIrqLPFVlUvwUmWnA = new ReadOnlyCollection<string>(ppaaiWikeQfAyDDmLDsyLzxYvRNdA);
				}
				return KyfEIRkZtJVnUIrqLPFVlUvwUmWnA;
			}
		}

		public EnumValueHelper()
		{
			if (!EnumTools.IsEnum(typeof(TEnum)))
			{
				throw new ArgumentException("TEnum must be an enum type.");
			}
			pdhaaCLRMFMlutFwwshXBPYkqwQf = (TEnum[])Enum.GetValues(typeof(TEnum));
			LbjwYIgOyvAxESQYLJMPjAnDAnIi = new ReadOnlyCollection<TEnum>(pdhaaCLRMFMlutFwwshXBPYkqwQf);
		}
	}
}
