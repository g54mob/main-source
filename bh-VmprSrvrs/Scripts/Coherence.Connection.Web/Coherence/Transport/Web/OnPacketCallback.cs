using System;

namespace Coherence.Transport.Web
{
	public delegate void OnPacketCallback(int id, int length, IntPtr ptr);
}
