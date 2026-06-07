using Stateless.Reflection;

namespace Stateless.Graph
{
	public class Decision : State
	{
		public InvocationInfo Method { get; private set; }

		public Decision(InvocationInfo method, int num)
			: base("Decision" + num)
		{
			Method = method;
		}
	}
}
