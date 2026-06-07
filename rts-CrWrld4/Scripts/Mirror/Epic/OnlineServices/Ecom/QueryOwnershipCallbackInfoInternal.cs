using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 40)]
	internal struct QueryOwnershipCallbackInfoInternal : ICallbackInfoInternal
	{
		private Result m_ResultCode;

		private IntPtr m_ClientData;

		private IntPtr m_LocalUserId;

		private IntPtr m_ItemOwnership;

		private uint m_ItemOwnershipCount;

		public Result ResultCode => default(Result);

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public EpicAccountId LocalUserId => null;

		public ItemOwnership[] ItemOwnership => null;
	}
}
