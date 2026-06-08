using System.Collections.Generic;

namespace MoonSharp.VsCodeDebugger.SDK
{
	public class SetBreakpointsResponseBody : ResponseBody
	{
		public Breakpoint[] breakpoints { get; private set; }

		public SetBreakpointsResponseBody(List<Breakpoint> bpts = null)
		{
		}
	}
}
