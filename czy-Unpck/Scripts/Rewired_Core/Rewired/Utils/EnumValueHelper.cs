using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class EnumValueHelper<TEnum>
	{
		private static EnumValueHelper<TEnum> BgVAlBbqHGOjWMKDVziUeWXeAbTf;

		private TEnum[] sLrrXqOcjGJUZpChpAEeYDKuQek;

		private ReadOnlyCollection<TEnum> UfEHSznYTLleDOIrRzRRKzJmTFu;

		private string[] WemRKEYlnuFrrtekgAqkfQNBJSoa;

		private ReadOnlyCollection<string> EihLMXJoxsDjFCkSZaELxkpQJSFU;

		public static EnumValueHelper<TEnum> Default => BgVAlBbqHGOjWMKDVziUeWXeAbTf ?? (BgVAlBbqHGOjWMKDVziUeWXeAbTf = new EnumValueHelper<TEnum>());

		public IList<TEnum> values => UfEHSznYTLleDOIrRzRRKzJmTFu;

		public IList<string> names
		{
			get
			{
				if (EihLMXJoxsDjFCkSZaELxkpQJSFU == null)
				{
					WemRKEYlnuFrrtekgAqkfQNBJSoa = Enum.GetNames(typeof(TEnum));
					EihLMXJoxsDjFCkSZaELxkpQJSFU = new ReadOnlyCollection<string>(WemRKEYlnuFrrtekgAqkfQNBJSoa);
				}
				return EihLMXJoxsDjFCkSZaELxkpQJSFU;
			}
		}

		public EnumValueHelper()
		{
			if (!EnumTools.IsEnum(typeof(TEnum)))
			{
				throw new ArgumentException("TEnum must be an enum type.");
			}
			sLrrXqOcjGJUZpChpAEeYDKuQek = (TEnum[])Enum.GetValues(typeof(TEnum));
			UfEHSznYTLleDOIrRzRRKzJmTFu = new ReadOnlyCollection<TEnum>(sLrrXqOcjGJUZpChpAEeYDKuQek);
		}
	}
}
