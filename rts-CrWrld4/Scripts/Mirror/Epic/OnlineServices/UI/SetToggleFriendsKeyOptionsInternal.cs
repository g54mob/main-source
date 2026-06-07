using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.UI
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 8)]
	internal struct SetToggleFriendsKeyOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private KeyCombination m_KeyCombination;

		public KeyCombination KeyCombination
		{
			set
			{
			}
		}

		public void Set(SetToggleFriendsKeyOptions other)
		{
		}

		public void Set(object other)
		{
		}

		public void Dispose()
		{
		}
	}
}
