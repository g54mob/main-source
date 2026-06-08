using System;
using System.Collections.Generic;
using System.Reflection;

namespace Rhizomatic.Reactive
{
	public class Viewable : IViewable
	{
		private static Dictionary<Type, FieldInfo[]> allFields;

		private static Dictionary<Type, PropertyInfo[]> allProperties;

		public void GetStates(List<State> states)
		{
		}

		public static void GetStates(object target, List<State> states)
		{
		}
	}
}
