using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class IntPtrWrapper
	{
		private IntPtr cPXMBWWUIUKdzHVnOsdGrrYHjrWS;

		public bool IsValid => cPXMBWWUIUKdzHVnOsdGrrYHjrWS != IntPtr.Zero;

		public IntPtrWrapper(IntPtr P_0)
		{
			cPXMBWWUIUKdzHVnOsdGrrYHjrWS = P_0;
		}

		public void Clear()
		{
			cPXMBWWUIUKdzHVnOsdGrrYHjrWS = IntPtr.Zero;
		}

		public static implicit operator IntPtr(IntPtrWrapper obj)
		{
			return obj?.cPXMBWWUIUKdzHVnOsdGrrYHjrWS ?? IntPtr.Zero;
		}
	}
}
