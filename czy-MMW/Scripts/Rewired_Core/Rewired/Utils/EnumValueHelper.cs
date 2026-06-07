using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class EnumValueHelper<TEnum>
	{
		private static EnumValueHelper<TEnum> GzVUqHYqqMAHskNwKgrphLbQpHgBb;

		private TEnum[] gyJpCfNCUSWMghhjqgcnLDsRsIIN;

		private ReadOnlyCollection<TEnum> WbHhSbaysuSSCQLOXHdnpZicyRQE;

		private string[] aPCpbnqqSFUvqLvfXakWzJYnxVHd;

		private ReadOnlyCollection<string> LtZDLmXtjEjrCfynHvNhWnJDvIOS;

		public static EnumValueHelper<TEnum> Default => GzVUqHYqqMAHskNwKgrphLbQpHgBb ?? (GzVUqHYqqMAHskNwKgrphLbQpHgBb = new EnumValueHelper<TEnum>());

		public IList<TEnum> values => WbHhSbaysuSSCQLOXHdnpZicyRQE;

		public IList<string> names
		{
			get
			{
				if (LtZDLmXtjEjrCfynHvNhWnJDvIOS == null)
				{
					aPCpbnqqSFUvqLvfXakWzJYnxVHd = Enum.GetNames(typeof(TEnum));
					LtZDLmXtjEjrCfynHvNhWnJDvIOS = new ReadOnlyCollection<string>(aPCpbnqqSFUvqLvfXakWzJYnxVHd);
				}
				return LtZDLmXtjEjrCfynHvNhWnJDvIOS;
			}
		}

		public EnumValueHelper()
		{
			if (!EnumTools.IsEnum(typeof(TEnum)))
			{
				throw new ArgumentException("TEnum must be an enum type.");
			}
			gyJpCfNCUSWMghhjqgcnLDsRsIIN = (TEnum[])Enum.GetValues(typeof(TEnum));
			WbHhSbaysuSSCQLOXHdnpZicyRQE = new ReadOnlyCollection<TEnum>(gyJpCfNCUSWMghhjqgcnLDsRsIIN);
		}
	}
}
