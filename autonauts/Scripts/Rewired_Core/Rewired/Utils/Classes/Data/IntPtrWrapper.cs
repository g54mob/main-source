using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class IntPtrWrapper
	{
		private IntPtr qacaPtGoWzCRchZeGrFneNECwXep;

		public bool IsValid
		{
			get
			{
				return qacaPtGoWzCRchZeGrFneNECwXep != IntPtr.Zero;
			}
		}

		public IntPtrWrapper(IntPtr pointer)
		{
			qacaPtGoWzCRchZeGrFneNECwXep = pointer;
		}

		public void Clear()
		{
			qacaPtGoWzCRchZeGrFneNECwXep = IntPtr.Zero;
		}

		public static implicit operator IntPtr(IntPtrWrapper obj)
		{
			if (obj == null)
			{
				return IntPtr.Zero;
			}
			return obj.qacaPtGoWzCRchZeGrFneNECwXep;
		}
	}
}
