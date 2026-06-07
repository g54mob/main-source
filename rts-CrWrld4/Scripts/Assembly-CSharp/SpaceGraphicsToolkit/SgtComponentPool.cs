using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	public static class SgtComponentPool<T> where T : Component
	{
		private static SgtPoolComponent pool;

		public static int Count => 0;

		public static T Add(T entry)
		{
			return null;
		}

		public static T Add(T element, Action<T> onAdd)
		{
			return null;
		}

		public static void Cache()
		{
		}

		public static T Pop(Transform parent, string name, int layer)
		{
			return null;
		}

		public static T Pop()
		{
			return null;
		}

		public static T Pop(Predicate<T> match)
		{
			return null;
		}

		private static void UpdateComponent(bool allowCreation)
		{
		}
	}
}
