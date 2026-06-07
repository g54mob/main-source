using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class EnumValueHelper<TEnum>
	{
		private static EnumValueHelper<TEnum> gePIlGMmtUuQJnaTMLFTWnhtmcu;

		private TEnum[] RPfEUpsuWWkQAYqzoyvrYHgxnBX;

		private ReadOnlyCollection<TEnum> jBCtTuRSoHllKvjACkJWUInhCOT;

		private string[] jaycnBgMUyfmoOrXxJPpIOvGENVG;

		private ReadOnlyCollection<string> vDxdGGxFIshcGNArIlnEkNVDRLi;

		public static EnumValueHelper<TEnum> Default
		{
			get
			{
				return gePIlGMmtUuQJnaTMLFTWnhtmcu ?? (gePIlGMmtUuQJnaTMLFTWnhtmcu = new EnumValueHelper<TEnum>());
			}
		}

		public IList<TEnum> values
		{
			get
			{
				return jBCtTuRSoHllKvjACkJWUInhCOT;
			}
		}

		public IList<string> names
		{
			get
			{
				if (vDxdGGxFIshcGNArIlnEkNVDRLi == null)
				{
					jaycnBgMUyfmoOrXxJPpIOvGENVG = Enum.GetNames(typeof(TEnum));
					vDxdGGxFIshcGNArIlnEkNVDRLi = new ReadOnlyCollection<string>(jaycnBgMUyfmoOrXxJPpIOvGENVG);
				}
				return vDxdGGxFIshcGNArIlnEkNVDRLi;
			}
		}

		public EnumValueHelper()
		{
			while (true)
			{
				switch (-448750020 ^ -448750019)
				{
				case 0:
					continue;
				case 1:
					if (!EnumTools.IsEnum(typeof(TEnum)))
					{
						throw new ArgumentException("TEnum must be an enum type.");
					}
					break;
				}
				break;
			}
			RPfEUpsuWWkQAYqzoyvrYHgxnBX = (TEnum[])Enum.GetValues(typeof(TEnum));
			jBCtTuRSoHllKvjACkJWUInhCOT = new ReadOnlyCollection<TEnum>(RPfEUpsuWWkQAYqzoyvrYHgxnBX);
		}
	}
}
