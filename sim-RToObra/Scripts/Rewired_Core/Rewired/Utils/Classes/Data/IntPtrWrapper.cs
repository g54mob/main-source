using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class IntPtrWrapper
	{
		private IntPtr JJifUugMIpsoPkhpunJtcaIHyInN;

		public bool IsValid
		{
			get
			{
				return JJifUugMIpsoPkhpunJtcaIHyInN != IntPtr.Zero;
			}
		}

		public IntPtrWrapper(IntPtr pointer)
		{
			while (true)
			{
				int num = -898030284;
				while (true)
				{
					switch (num ^ -898030282)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0024;
					case 1:
						return;
					}
					break;
					IL_0024:
					JJifUugMIpsoPkhpunJtcaIHyInN = pointer;
					num = -898030281;
				}
			}
		}

		public void Clear()
		{
			JJifUugMIpsoPkhpunJtcaIHyInN = IntPtr.Zero;
		}

		public static implicit operator IntPtr(IntPtrWrapper obj)
		{
			if (obj == null)
			{
				return IntPtr.Zero;
			}
			return obj.JJifUugMIpsoPkhpunJtcaIHyInN;
		}
	}
}
