using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class EnumValueHelper<TEnum>
	{
		private static EnumValueHelper<TEnum> OYQiqncsATCGrosbfEmmNOJBdCuX;

		private TEnum[] dFcotYScmXiduBwcFOBGNUGZfPDg;

		private ReadOnlyCollection<TEnum> BoBfTLkhOQAVkSgZzIRtCDVJwcNHA;

		private string[] FUbtPmAkovASQLgASdcCVVJoDlBAA;

		private ReadOnlyCollection<string> VyiWBpDQwvwEoGcirPGlxIndSnuT;

		public static EnumValueHelper<TEnum> Default => OYQiqncsATCGrosbfEmmNOJBdCuX ?? (OYQiqncsATCGrosbfEmmNOJBdCuX = new EnumValueHelper<TEnum>());

		public IList<TEnum> values => BoBfTLkhOQAVkSgZzIRtCDVJwcNHA;

		public IList<string> names
		{
			get
			{
				if (VyiWBpDQwvwEoGcirPGlxIndSnuT == null)
				{
					FUbtPmAkovASQLgASdcCVVJoDlBAA = Enum.GetNames(typeof(TEnum));
					VyiWBpDQwvwEoGcirPGlxIndSnuT = new ReadOnlyCollection<string>(FUbtPmAkovASQLgASdcCVVJoDlBAA);
				}
				return VyiWBpDQwvwEoGcirPGlxIndSnuT;
			}
		}

		public EnumValueHelper()
		{
			if (!EnumTools.IsEnum(typeof(TEnum)))
			{
				throw new ArgumentException("TEnum must be an enum type.");
			}
			dFcotYScmXiduBwcFOBGNUGZfPDg = (TEnum[])Enum.GetValues(typeof(TEnum));
			BoBfTLkhOQAVkSgZzIRtCDVJwcNHA = new ReadOnlyCollection<TEnum>(dFcotYScmXiduBwcFOBGNUGZfPDg);
		}
	}
}
