using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class IntPtrWrapper
	{
		private IntPtr KpdbvMMIiyahCGEzhMeQQGgKEzcKA;

		public bool IsValid => KpdbvMMIiyahCGEzhMeQQGgKEzcKA != IntPtr.Zero;

		public IntPtrWrapper(IntPtr P_0)
		{
			KpdbvMMIiyahCGEzhMeQQGgKEzcKA = P_0;
		}

		public void Clear()
		{
			KpdbvMMIiyahCGEzhMeQQGgKEzcKA = IntPtr.Zero;
		}

		public static implicit operator IntPtr(IntPtrWrapper obj)
		{
			return obj?.KpdbvMMIiyahCGEzhMeQQGgKEzcKA ?? IntPtr.Zero;
		}
	}
}
