using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class EnumValueHelper<TEnum>
	{
		private static EnumValueHelper<TEnum> OSUilHTDlimidkmpamAmpwBHBpYx;

		private TEnum[] kEOcsxIHPmKnvjieWdRspzSCLkiV;

		private ReadOnlyCollection<TEnum> AiOyhlxybGtcJAxKzemqJZflYHeL;

		private string[] mmXeAjfIrtCfzBNanzTXXYhqCDlw;

		private ReadOnlyCollection<string> XPUuCyAOccvSFtdwpKgeqkdQLeqy;

		public static EnumValueHelper<TEnum> Default => OSUilHTDlimidkmpamAmpwBHBpYx ?? (OSUilHTDlimidkmpamAmpwBHBpYx = new EnumValueHelper<TEnum>());

		public IList<TEnum> values => AiOyhlxybGtcJAxKzemqJZflYHeL;

		public IList<string> names
		{
			get
			{
				if (XPUuCyAOccvSFtdwpKgeqkdQLeqy == null)
				{
					mmXeAjfIrtCfzBNanzTXXYhqCDlw = Enum.GetNames(typeof(TEnum));
					XPUuCyAOccvSFtdwpKgeqkdQLeqy = new ReadOnlyCollection<string>(mmXeAjfIrtCfzBNanzTXXYhqCDlw);
				}
				return XPUuCyAOccvSFtdwpKgeqkdQLeqy;
			}
		}

		public EnumValueHelper()
		{
			if (!EnumTools.IsEnum(typeof(TEnum)))
			{
				throw new ArgumentException("TEnum must be an enum type.");
			}
			kEOcsxIHPmKnvjieWdRspzSCLkiV = (TEnum[])Enum.GetValues(typeof(TEnum));
			AiOyhlxybGtcJAxKzemqJZflYHeL = new ReadOnlyCollection<TEnum>(kEOcsxIHPmKnvjieWdRspzSCLkiV);
		}
	}
}
