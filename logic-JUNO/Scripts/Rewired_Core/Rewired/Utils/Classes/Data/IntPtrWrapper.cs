using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class IntPtrWrapper
	{
		private IntPtr kwCaKWBXZysYsaFasOOHEJeCsRmnA;

		public bool IsValid => kwCaKWBXZysYsaFasOOHEJeCsRmnA != IntPtr.Zero;

		public IntPtrWrapper(IntPtr P_0)
		{
			kwCaKWBXZysYsaFasOOHEJeCsRmnA = P_0;
		}

		public void Clear()
		{
			kwCaKWBXZysYsaFasOOHEJeCsRmnA = IntPtr.Zero;
		}

		public static implicit operator IntPtr(IntPtrWrapper obj)
		{
			return obj?.kwCaKWBXZysYsaFasOOHEJeCsRmnA ?? IntPtr.Zero;
		}
	}
}
