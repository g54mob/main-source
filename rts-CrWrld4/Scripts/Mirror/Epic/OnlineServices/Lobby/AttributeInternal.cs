using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct AttributeInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_Data;

		private LobbyAttributeVisibility m_Visibility;

		public AttributeData Data
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public LobbyAttributeVisibility Visibility
		{
			get
			{
				return default(LobbyAttributeVisibility);
			}
			set
			{
			}
		}

		public void Set(Attribute other)
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
