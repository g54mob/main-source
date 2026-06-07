using System;
using System.Collections.Generic;

namespace Gh
{
	public static class ActivatorHelper
	{
		private static readonly Dictionary<Type, Func<object>> _simpleConstructors;

		public static object CreateInstanceFast(Type type)
		{
			return null;
		}

		private static Func<object> CreateInstanceFastConstructor(Type type)
		{
			return null;
		}
	}
}
