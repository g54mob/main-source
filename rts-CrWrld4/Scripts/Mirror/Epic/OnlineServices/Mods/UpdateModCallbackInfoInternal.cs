using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Mods
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct UpdateModCallbackInfoInternal : ICallbackInfoInternal
	{
		private Result m_ResultCode;

		private IntPtr m_LocalUserId;

		private IntPtr m_ClientData;

		private IntPtr m_Mod;

		public Result ResultCode => default(Result);

		public EpicAccountId LocalUserId => null;

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public ModIdentifier Mod => null;
	}
}
