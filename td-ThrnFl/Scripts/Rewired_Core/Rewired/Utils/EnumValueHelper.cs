using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class EnumValueHelper<TEnum>
	{
		private static EnumValueHelper<TEnum> xhyUhHNYeRmoStMkXoXwstfuRpKl;

		private TEnum[] TpcFRrEtYZflSombbIbkgbsbgAadA;

		private ReadOnlyCollection<TEnum> lsoiHjnhwbpbaJAZWaGgdOPKWmywA;

		private string[] XghNDjpIyYJdMIqlYcbFCYZHdlfbA;

		private ReadOnlyCollection<string> gewlnwOBlNQvymtxMWFmtTPbAMcm;

		public static EnumValueHelper<TEnum> Default => xhyUhHNYeRmoStMkXoXwstfuRpKl ?? (xhyUhHNYeRmoStMkXoXwstfuRpKl = new EnumValueHelper<TEnum>());

		public IList<TEnum> values => lsoiHjnhwbpbaJAZWaGgdOPKWmywA;

		public IList<string> names
		{
			get
			{
				if (gewlnwOBlNQvymtxMWFmtTPbAMcm == null)
				{
					XghNDjpIyYJdMIqlYcbFCYZHdlfbA = Enum.GetNames(typeof(TEnum));
					gewlnwOBlNQvymtxMWFmtTPbAMcm = new ReadOnlyCollection<string>(XghNDjpIyYJdMIqlYcbFCYZHdlfbA);
				}
				return gewlnwOBlNQvymtxMWFmtTPbAMcm;
			}
		}

		public EnumValueHelper()
		{
			if (!EnumTools.IsEnum(typeof(TEnum)))
			{
				throw new ArgumentException("TEnum must be an enum type.");
			}
			TpcFRrEtYZflSombbIbkgbsbgAadA = (TEnum[])Enum.GetValues(typeof(TEnum));
			lsoiHjnhwbpbaJAZWaGgdOPKWmywA = new ReadOnlyCollection<TEnum>(TpcFRrEtYZflSombbIbkgbsbgAadA);
		}
	}
}
