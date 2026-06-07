using System.Collections.Generic;
using Stateless.Reflection;

namespace Stateless.Graph
{
	public class SuperState : State
	{
		public List<State> SubStates { get; } = new List<State>();

		public SuperState(StateInfo stateInfo)
			: base(stateInfo)
		{
		}
	}
}
