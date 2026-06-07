using System.Collections.Generic;
using UnityEngine;

namespace Drawing
{
	public static class GizmoContext
	{
		private static HashSet<Transform> selectedTransforms;

		internal static bool drawingGizmos;

		internal static bool dirty;

		private static int selectionSizeInternal;

		public static int selectionSize
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		internal static void SetDirty()
		{
		}

		private static void Refresh()
		{
		}

		public static bool InSelection(Component c)
		{
			return false;
		}

		public static bool InSelection(Transform tr)
		{
			return false;
		}

		public static bool InActiveSelection(Component c)
		{
			return false;
		}

		public static bool InActiveSelection(Transform tr)
		{
			return false;
		}
	}
}
