using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class EnumValueHelper<TEnum>
	{
		private static EnumValueHelper<TEnum> NsGEioaOmaBNobdbukRVCkFCuYKO;

		private TEnum[] cGuwlHOGRinWrMccSxezoCQuzuz;

		private ReadOnlyCollection<TEnum> GNPDBGCjmvtSrFhRsXaUjcHyOabv;

		private string[] UZlWHlKHAWBNDiSAHLLhRyHDzxfc;

		private ReadOnlyCollection<string> SXySJmDSWMCBjFoeoFvUWobIZxY;

		public static EnumValueHelper<TEnum> Default => NsGEioaOmaBNobdbukRVCkFCuYKO ?? (NsGEioaOmaBNobdbukRVCkFCuYKO = new EnumValueHelper<TEnum>());

		public IList<TEnum> values => GNPDBGCjmvtSrFhRsXaUjcHyOabv;

		public IList<string> names
		{
			get
			{
				if (SXySJmDSWMCBjFoeoFvUWobIZxY == null)
				{
					UZlWHlKHAWBNDiSAHLLhRyHDzxfc = Enum.GetNames(typeof(TEnum));
					SXySJmDSWMCBjFoeoFvUWobIZxY = new ReadOnlyCollection<string>(UZlWHlKHAWBNDiSAHLLhRyHDzxfc);
				}
				return SXySJmDSWMCBjFoeoFvUWobIZxY;
			}
		}

		public EnumValueHelper()
		{
			if (!EnumTools.IsEnum(typeof(TEnum)))
			{
				throw new ArgumentException("TEnum must be an enum type.");
			}
			cGuwlHOGRinWrMccSxezoCQuzuz = (TEnum[])Enum.GetValues(typeof(TEnum));
			GNPDBGCjmvtSrFhRsXaUjcHyOabv = new ReadOnlyCollection<TEnum>(cGuwlHOGRinWrMccSxezoCQuzuz);
		}
	}
}
