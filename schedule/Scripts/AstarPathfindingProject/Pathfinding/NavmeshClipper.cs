using System;
using System.Collections.Generic;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding
{
	public abstract class NavmeshClipper : VersionedMonoBehaviour
	{
		private static Action<NavmeshClipper> OnEnableCallback;

		private static Action<NavmeshClipper> OnDisableCallback;

		private static readonly List<NavmeshClipper> all;

		private int listIndex;

		public GraphMask graphMask;

		public static List<NavmeshClipper> allEnabled => null;

		public static void AddEnableCallback(Action<NavmeshClipper> onEnable, Action<NavmeshClipper> onDisable)
		{
		}

		public static void RemoveEnableCallback(Action<NavmeshClipper> onEnable, Action<NavmeshClipper> onDisable)
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		internal abstract void NotifyUpdated();

		public abstract Rect GetBounds(GraphTransform transform);

		public abstract bool RequiresUpdate();

		public abstract void ForceUpdate();
	}
}
