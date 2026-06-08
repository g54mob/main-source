using System.Collections.Generic;

namespace Stonescript
{
	public interface IFunction
	{
		string Name { get; }

		List<string> ParameterNames { get; }

		object Invoke(List<object> parameters = null, InvocationContext ctx = null);
	}
}
