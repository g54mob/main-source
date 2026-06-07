using System;

namespace Coherence.Plugins.NativeLauncher
{
	public class StreamDataReceivedEvent : EventArgs
	{
		private readonly string data;

		public string Data => null;

		internal StreamDataReceivedEvent(string data)
		{
		}
	}
}
