using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class EnumValueHelper<TEnum>
	{
		private static EnumValueHelper<TEnum> bPGhEsCmNTbAPJBiQCMCWwkESCog;

		private TEnum[] WcsSbDkbQXyTAgdKmuecERjWzjVW;

		private ReadOnlyCollection<TEnum> srLaEAHyeQmaYXprQElBKswKAyZZ;

		private string[] elhIQtusGttxqcRsnCIoCzmtldPm;

		private ReadOnlyCollection<string> yOuKVypMKrfJGrnYAqDDeeMmjtmM;

		public static EnumValueHelper<TEnum> Default => bPGhEsCmNTbAPJBiQCMCWwkESCog ?? (bPGhEsCmNTbAPJBiQCMCWwkESCog = new EnumValueHelper<TEnum>());

		public IList<TEnum> values => srLaEAHyeQmaYXprQElBKswKAyZZ;

		public IList<string> names
		{
			get
			{
				if (yOuKVypMKrfJGrnYAqDDeeMmjtmM == null)
				{
					elhIQtusGttxqcRsnCIoCzmtldPm = Enum.GetNames(typeof(TEnum));
					yOuKVypMKrfJGrnYAqDDeeMmjtmM = new ReadOnlyCollection<string>(elhIQtusGttxqcRsnCIoCzmtldPm);
				}
				return yOuKVypMKrfJGrnYAqDDeeMmjtmM;
			}
		}

		public EnumValueHelper()
		{
			if (!EnumTools.IsEnum(typeof(TEnum)))
			{
				throw new ArgumentException("TEnum must be an enum type.");
			}
			WcsSbDkbQXyTAgdKmuecERjWzjVW = (TEnum[])Enum.GetValues(typeof(TEnum));
			srLaEAHyeQmaYXprQElBKswKAyZZ = new ReadOnlyCollection<TEnum>(WcsSbDkbQXyTAgdKmuecERjWzjVW);
		}
	}
}
