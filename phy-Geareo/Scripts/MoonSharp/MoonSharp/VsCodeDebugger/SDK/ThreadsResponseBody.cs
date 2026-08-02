using System.Collections.Generic;

namespace MoonSharp.VsCodeDebugger.SDK
{
	public class ThreadsResponseBody : ResponseBody
	{
		public Thread[] threads { get; private set; }

		public ThreadsResponseBody(List<Thread> vars = null)
		{
		}
	}
}
