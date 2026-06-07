using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Presence
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct PresenceModificationSetRawRichTextOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_RichText;

		public string RichText
		{
			set
			{
			}
		}

		public void Set(PresenceModificationSetRawRichTextOptions other)
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
