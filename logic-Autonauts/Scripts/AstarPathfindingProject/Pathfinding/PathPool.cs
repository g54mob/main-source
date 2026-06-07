using System;
using System.Collections.Generic;

namespace Pathfinding
{
	public static class PathPool
	{
		private static readonly Dictionary<Type, Stack<Path>> pool = new Dictionary<Type, Stack<Path>>();

		private static readonly Dictionary<Type, int> totalCreated = new Dictionary<Type, int>();

		public static void Pool(Path path)
		{
			lock (pool)
			{
				if (((IPathInternals)path).Pooled)
				{
					throw new ArgumentException("The path is already pooled.");
				}
				Stack<Path> value;
				if (!pool.TryGetValue(path.GetType(), out value))
				{
					value = new Stack<Path>();
					pool[path.GetType()] = value;
				}
				((IPathInternals)path).Pooled = true;
				((IPathInternals)path).OnEnterPool();
				value.Push(path);
			}
		}

		public static int GetTotalCreated(Type type)
		{
			int value;
			if (totalCreated.TryGetValue(type, out value))
			{
				return value;
			}
			return 0;
		}

		public static int GetSize(Type type)
		{
			Stack<Path> value;
			if (pool.TryGetValue(type, out value))
			{
				return value.Count;
			}
			return 0;
		}

		public static T GetPath<T>() where T : Path, new()
		{
			lock (pool)
			{
				Stack<Path> value;
				T val;
				if (pool.TryGetValue(typeof(T), out value) && value.Count > 0)
				{
					val = value.Pop() as T;
				}
				else
				{
					val = new T();
					if (!totalCreated.ContainsKey(typeof(T)))
					{
						totalCreated[typeof(T)] = 0;
					}
					totalCreated[typeof(T)]++;
				}
				((IPathInternals)val).Pooled = false;
				((IPathInternals)val).Reset();
				return val;
			}
		}
	}
}
