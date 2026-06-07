using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.UI
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct OnDisplaySettingsUpdatedCallbackInfoInternal : ICallbackInfoInternal
	{
		private IntPtr m_ClientData;

		private int m_IsVisible;

		private int m_IsExclusiveInput;

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public bool IsVisible => false;

		public bool IsExclusiveInput => false;
	}
}
