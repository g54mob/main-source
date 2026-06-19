using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class EnumValueHelper<TEnum>
	{
		private static EnumValueHelper<TEnum> CfOzuPjTmBfrAvDUiDgmdCpwSDhb;

		private TEnum[] gfOcoOFuvJWirjaESPIiGbLmJPxDb;

		private ReadOnlyCollection<TEnum> QBCHkQkPJzOkVCZgnkpaNFuZJndBb;

		private string[] grLucSJgFEhqvAUKfDMVXVyMvqcJA;

		private ReadOnlyCollection<string> ZKQWbHgBMJCFZadMdgdsyseeaTvJA;

		public static EnumValueHelper<TEnum> Default => CfOzuPjTmBfrAvDUiDgmdCpwSDhb ?? (CfOzuPjTmBfrAvDUiDgmdCpwSDhb = new EnumValueHelper<TEnum>());

		public IList<TEnum> values => QBCHkQkPJzOkVCZgnkpaNFuZJndBb;

		public IList<string> names
		{
			get
			{
				if (ZKQWbHgBMJCFZadMdgdsyseeaTvJA == null)
				{
					grLucSJgFEhqvAUKfDMVXVyMvqcJA = Enum.GetNames(typeof(TEnum));
					ZKQWbHgBMJCFZadMdgdsyseeaTvJA = new ReadOnlyCollection<string>(grLucSJgFEhqvAUKfDMVXVyMvqcJA);
				}
				return ZKQWbHgBMJCFZadMdgdsyseeaTvJA;
			}
		}

		public EnumValueHelper()
		{
			if (!EnumTools.IsEnum(typeof(TEnum)))
			{
				throw new ArgumentException("TEnum must be an enum type.");
			}
			gfOcoOFuvJWirjaESPIiGbLmJPxDb = (TEnum[])Enum.GetValues(typeof(TEnum));
			QBCHkQkPJzOkVCZgnkpaNFuZJndBb = new ReadOnlyCollection<TEnum>(gfOcoOFuvJWirjaESPIiGbLmJPxDb);
		}
	}
}
