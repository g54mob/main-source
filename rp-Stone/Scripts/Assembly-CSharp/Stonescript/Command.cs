using System.Collections.Generic;
using Stonescript.Runtime;

namespace Stonescript
{
	public delegate bool Command(string command, List<StonescriptResult> results, ExecutionContext ctx);
}
