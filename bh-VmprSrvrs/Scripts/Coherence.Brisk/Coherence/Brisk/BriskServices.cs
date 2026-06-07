using System;
using Coherence.Common;
using Coherence.Log;
using Coherence.Transport;

namespace Coherence.Brisk
{
	public class BriskServices
	{
		public static BriskServices Default { get; }

		public Func<bool> KeepAliveProvider { get; set; }

		public Func<IStopwatch> SendTimerProvider { get; set; }

		public Func<IStopwatch> ConnectionTimerProvider { get; set; }

		internal Func<Logger, ITransport> TransportFactory { get; set; }

		private static bool UseBriskKeepAlive()
		{
			return false;
		}
	}
}
