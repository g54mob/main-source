using System;
using System.Collections.Generic;

namespace Lean.Pool
{
	public static class LeanClassPool<T> where T : class
	{
		private static List<T> cache;

		public static T Spawn()
		{
			return null;
		}

		public static T Spawn(Action<T> onSpawn)
		{
			return null;
		}

		public static bool TrySpawn(Action<T> onSpawn, ref T instance)
		{
			return false;
		}

		public static T Spawn(Predicate<T> match)
		{
			return null;
		}

		public static bool TrySpawn(Predicate<T> match, ref T instance)
		{
			return false;
		}

		public static T Spawn(Predicate<T> match, Action<T> onSpawn)
		{
			return null;
		}

		public static bool TrySpawn(Predicate<T> match, Action<T> onSpawn, ref T instance)
		{
			return false;
		}

		public static void Despawn(T instance)
		{
		}

		public static void Despawn(T instance, Action<T> onDespawn)
		{
		}
	}
}
