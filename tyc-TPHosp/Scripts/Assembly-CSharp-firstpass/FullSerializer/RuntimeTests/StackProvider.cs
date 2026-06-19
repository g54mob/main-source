using System.Collections.Generic;
using System.Linq;

namespace FullSerializer.RuntimeTests
{
	public class StackProvider : TestProvider<Stack<int>>
	{
		public override bool Compare(Stack<int> before, Stack<int> after)
		{
			if (before.Except(after).Count() == 0)
			{
				return after.Except(before).Count() == 0;
			}
			return false;
		}

		public override IEnumerable<Stack<int>> GetValues()
		{
			yield return new Stack<int>();
			Stack<int> stack = new Stack<int>();
			stack.Push(1);
			yield return stack;
			stack = new Stack<int>();
			stack.Push(1);
			stack.Push(5);
			stack.Push(3);
			yield return stack;
		}
	}
}
