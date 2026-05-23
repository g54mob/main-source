using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class EnumValueHelper<TEnum>
	{
		private static EnumValueHelper<TEnum> LDwDTzcqSaJaAJzktFPjtpIxftC;

		private TEnum[] qmzoTsMXQWlxxgxeInzhrPetPQC;

		private ReadOnlyCollection<TEnum> YgWgqvfDaLAUvToXaMeGzDpfYTM;

		private string[] UAasLUUzIiPwRgQMDNyfbAjKCfY;

		private ReadOnlyCollection<string> WDnuHRLSYsJKhjlgmxoAFpHXGBb;

		public static EnumValueHelper<TEnum> Default
		{
			get
			{
				return LDwDTzcqSaJaAJzktFPjtpIxftC ?? (LDwDTzcqSaJaAJzktFPjtpIxftC = new EnumValueHelper<TEnum>());
			}
		}

		public IList<TEnum> values
		{
			get
			{
				return YgWgqvfDaLAUvToXaMeGzDpfYTM;
			}
		}

		public IList<string> names
		{
			get
			{
				if (WDnuHRLSYsJKhjlgmxoAFpHXGBb == null)
				{
					while (true)
					{
						int num = 1469714968;
						while (true)
						{
							switch (num ^ 0x579A121B)
							{
							case 2:
								break;
							case 3:
								UAasLUUzIiPwRgQMDNyfbAjKCfY = Enum.GetNames(typeof(TEnum));
								num = 1469714971;
								continue;
							case 0:
								WDnuHRLSYsJKhjlgmxoAFpHXGBb = new ReadOnlyCollection<string>(UAasLUUzIiPwRgQMDNyfbAjKCfY);
								num = 1469714970;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
						}
						continue;
						end_IL_0008:
						break;
					}
				}
				return WDnuHRLSYsJKhjlgmxoAFpHXGBb;
			}
		}

		public EnumValueHelper()
		{
			if (!EnumTools.IsEnum(typeof(TEnum)))
			{
				throw new ArgumentException("TEnum must be an enum type.");
			}
			qmzoTsMXQWlxxgxeInzhrPetPQC = (TEnum[])Enum.GetValues(typeof(TEnum));
			YgWgqvfDaLAUvToXaMeGzDpfYTM = new ReadOnlyCollection<TEnum>(qmzoTsMXQWlxxgxeInzhrPetPQC);
		}
	}
}
