using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	public static class SgtObjectPool<T> where T : UnityEngine.Object
	{
		private static SgtPoolObject pool;

		static SgtObjectPool()
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

		private static void UpdateComponent(bool allowCreation)
		{
		}
	}
}
