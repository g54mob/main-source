using System.Collections.Generic;

namespace Stateless.Reflection
{
	public class DynamicStateInfos : List<DynamicStateInfo>
	{
		public void Add(string destinationState, string criterion)
		{
			Add(new DynamicStateInfo(destinationState, criterion));
		}

		public void Add<TState>(TState destinationState, string criterion)
		{
			Add(new DynamicStateInfo(destinationState.ToString(), criterion));
		}
	}
}
