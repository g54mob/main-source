using System;
using System.Collections.Generic;

namespace SpaceGraphicsToolkit
{
	public static class SgtPoolClass<T> where T : class
	{
		private static List<T> pool;

		public static int Count => 0;

		static SgtPoolClass()
		{
		}

		public static T Add(T entry)
		{
			return null;
		}

		public static T Add(T element, Action<T> onAdd)
		{
			return null;
		}

		public static T Pop()
		{
			return null;
		}
	}
}
