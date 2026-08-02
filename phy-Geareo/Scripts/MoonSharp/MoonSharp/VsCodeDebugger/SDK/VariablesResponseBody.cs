using System.Collections.Generic;

namespace MoonSharp.VsCodeDebugger.SDK
{
	public class VariablesResponseBody : ResponseBody
	{
		public Variable[] variables { get; private set; }

		public VariablesResponseBody(List<Variable> vars = null)
		{
		}
	}
}
