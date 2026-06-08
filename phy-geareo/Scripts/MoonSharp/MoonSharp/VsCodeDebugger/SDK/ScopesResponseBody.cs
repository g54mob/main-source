using System.Collections.Generic;

namespace MoonSharp.VsCodeDebugger.SDK
{
	public class ScopesResponseBody : ResponseBody
	{
		public Scope[] scopes { get; private set; }

		public ScopesResponseBody(List<Scope> scps = null)
		{
		}
	}
}
