using System;
using System.Collections.Generic;

namespace Reactivity
{
	public static class DependencyTracker
	{
		[ThreadStatic]
		private static Stack<IReactiveEffect> _effectStack;

		public static IReactiveEffect Current => null;

		public static void Push(IReactiveEffect effect)
		{
		}

		public static void Pop()
		{
		}
	}
}
