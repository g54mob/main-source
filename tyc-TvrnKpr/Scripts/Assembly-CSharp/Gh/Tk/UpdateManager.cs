using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	public static class UpdateManager
	{
		private static readonly HashSet<IUpdateable> _objects;

		private static bool _frozen;

		private static readonly List<Action> _delayedActions;

		internal static bool IsFirstUpdateAfterLoading;

		public static void AddToUpdateLoop(IUpdateable obj)
		{
		}

		public static void RemoveFromUpdateLoop(IUpdateable obj)
		{
		}

		internal static void Update()
		{
		}

		private static void PrintDebugStats()
		{
		}

		public static void FirstUpdateAfterLoading()
		{
		}
	}
}
