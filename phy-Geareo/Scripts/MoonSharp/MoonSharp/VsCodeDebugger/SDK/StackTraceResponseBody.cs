using System.Collections.Generic;

namespace MoonSharp.VsCodeDebugger.SDK
{
	public class StackTraceResponseBody : ResponseBody
	{
		public StackFrame[] stackFrames { get; private set; }

		public StackTraceResponseBody(List<StackFrame> frames = null)
		{
		}
	}
}
