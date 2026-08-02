using System;
using System.Runtime.CompilerServices;

namespace Rhizomatic.LoggyLogger
{
	public class CallbackTransport : Transport
	{
		public event Action<Log> onLog
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public CallbackTransport(Action<Log> onLog)
		{
		}

		protected override void Log(Log log)
		{
		}

		public override void Dispose()
		{
		}
	}
}
