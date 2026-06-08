using System;
using System.Collections.Generic;
using System.Linq;

namespace Moq
{
	internal static class HandleWellKnownMethods
	{
		private static Dictionary<string, Func<Invocation, Mock, bool>> specialMethods = new Dictionary<string, Func<Invocation, Mock, bool>>
		{
			["Equals"] = HandleEquals,
			["GetHashCode"] = HandleGetHashCode,
			["get_Mock"] = HandleMockGetter,
			["ToString"] = HandleToString
		};

		public static bool Handle(Invocation invocation, Mock mock)
		{
			if (specialMethods.TryGetValue(invocation.Method.Name, out Func<Invocation, Mock, bool> value))
			{
				return value(invocation, mock);
			}
			return false;
		}

		private static bool HandleEquals(Invocation invocation, Mock mock)
		{
			if (IsObjectMethodWithoutSetup(invocation, mock))
			{
				invocation.ReturnValue = invocation.Arguments.First() == mock.Object;
				return true;
			}
			return false;
		}

		private static bool HandleGetHashCode(Invocation invocation, Mock mock)
		{
			if (IsObjectMethodWithoutSetup(invocation, mock))
			{
				invocation.ReturnValue = mock.GetHashCode();
				return true;
			}
			return false;
		}

		private static bool HandleToString(Invocation invocation, Mock mock)
		{
			if (IsObjectMethodWithoutSetup(invocation, mock))
			{
				invocation.ReturnValue = mock.ToString() + ".Object";
				return true;
			}
			return false;
		}

		private static bool HandleMockGetter(Invocation invocation, Mock mock)
		{
			if (typeof(IMocked).IsAssignableFrom(invocation.Method.DeclaringType))
			{
				invocation.ReturnValue = mock;
				return true;
			}
			return false;
		}

		private static bool IsObjectMethodWithoutSetup(Invocation invocation, Mock mock)
		{
			if (invocation.Method.DeclaringType == typeof(object))
			{
				return mock.MutableSetups.FindLast((Setup setup) => setup.Matches(invocation)) == null;
			}
			return false;
		}
	}
}
