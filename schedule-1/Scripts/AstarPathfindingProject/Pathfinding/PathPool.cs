using System;
using System.Collections.Generic;

namespace Pathfinding
{
	public static class PathPool
	{
		private static readonly Dictionary<Type, Stack<Path>> pool;

		private static readonly Dictionary<Type, int> totalCreated;

		public static void Pool(Path path)
		{
		}

		public static int GetTotalCreated(Type type)
		{
			return 0;
		}

		public static int GetSize(Type type)
		{
			return 0;
		}

		public static T GetPath<T>() where T : Path, new()
		{
			return null;
		}
	}
}
