using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class EnumValueHelper<TEnum>
	{
		private static EnumValueHelper<TEnum> QlMbtjJizDqrVAphfiENAoESzZTGA;

		private TEnum[] mzUJqRSpXTAsPfRyVMHLwqFRKOhqA;

		private ReadOnlyCollection<TEnum> KCGHuJhqldSufkmSkayZUFichqnP;

		private string[] quPoaZhuzMSoPbuywHFiGNkfnvky;

		private ReadOnlyCollection<string> TFQUYQQkeLVRzJwIimjVjcAXIxxC;

		public static EnumValueHelper<TEnum> Default => QlMbtjJizDqrVAphfiENAoESzZTGA ?? (QlMbtjJizDqrVAphfiENAoESzZTGA = new EnumValueHelper<TEnum>());

		public IList<TEnum> values => KCGHuJhqldSufkmSkayZUFichqnP;

		public IList<string> names
		{
			get
			{
				if (TFQUYQQkeLVRzJwIimjVjcAXIxxC == null)
				{
					quPoaZhuzMSoPbuywHFiGNkfnvky = Enum.GetNames(typeof(TEnum));
					TFQUYQQkeLVRzJwIimjVjcAXIxxC = new ReadOnlyCollection<string>(quPoaZhuzMSoPbuywHFiGNkfnvky);
				}
				return TFQUYQQkeLVRzJwIimjVjcAXIxxC;
			}
		}

		public EnumValueHelper()
		{
			if (!EnumTools.IsEnum(typeof(TEnum)))
			{
				throw new ArgumentException("TEnum must be an enum type.");
			}
			mzUJqRSpXTAsPfRyVMHLwqFRKOhqA = (TEnum[])Enum.GetValues(typeof(TEnum));
			KCGHuJhqldSufkmSkayZUFichqnP = new ReadOnlyCollection<TEnum>(mzUJqRSpXTAsPfRyVMHLwqFRKOhqA);
		}
	}
}
