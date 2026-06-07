using System;
using System.Collections.Generic;
using Pathfinding.Collections;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding
{
	[ExecuteAlways]
	public abstract class NavmeshClipper : VersionedMonoBehaviour
	{
		private static Action<NavmeshClipper> OnEnableCallback;

		private static Action<NavmeshClipper> OnDisableCallback;

		private static readonly List<NavmeshClipper> all;

		private int listIndex;

		public GraphMask graphMask;

		public static List<NavmeshClipper> allEnabled => null;

		internal static void RefreshEnabledList()
		{
		}

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

		public abstract void NotifyUpdated(GridLookup<NavmeshClipper>.Root previousState);

		public abstract Bounds GetBounds(GraphTransform transform, float radiusMargin);

		public abstract bool RequiresUpdate(GridLookup<NavmeshClipper>.Root previousState);

		public abstract void ForceUpdate();
	}
}
