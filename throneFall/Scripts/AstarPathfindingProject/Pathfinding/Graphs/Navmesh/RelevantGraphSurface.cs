using Pathfinding.Drawing;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	[AddComponentMenu("Pathfinding/Navmesh/RelevantGraphSurface")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/relevantgraphsurface.html")]
	public class RelevantGraphSurface : VersionedMonoBehaviour
	{
		private static RelevantGraphSurface root;

		public float maxRange = 1f;

		private RelevantGraphSurface prev;

		private RelevantGraphSurface next;

		private Vector3 position;

		public Vector3 Position => position;

		public RelevantGraphSurface Next => next;

		public RelevantGraphSurface Prev => prev;

		public static RelevantGraphSurface Root => root;

		public void UpdatePosition()
		{
			position = base.transform.position;
		}

		private void OnEnable()
		{
			UpdatePosition();
			if (root == null)
			{
				root = this;
				return;
			}
			next = root;
			root.prev = this;
			root = this;
		}

		private void OnDisable()
		{
			if (root == this)
			{
				root = next;
				if (root != null)
				{
					root.prev = null;
				}
			}
			else
			{
				if (prev != null)
				{
					prev.next = next;
				}
				if (next != null)
				{
					next.prev = prev;
				}
			}
			prev = null;
			next = null;
		}

		public static void UpdateAllPositions()
		{
			RelevantGraphSurface relevantGraphSurface = root;
			while (relevantGraphSurface != null)
			{
				relevantGraphSurface.UpdatePosition();
				relevantGraphSurface = relevantGraphSurface.Next;
			}
		}

		public static void FindAllGraphSurfaces()
		{
			RelevantGraphSurface[] array = UnityCompatibility.FindObjectsByTypeUnsorted<RelevantGraphSurface>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnDisable();
				array[i].OnEnable();
			}
		}

		public override void DrawGizmos()
		{
			Color color = new Color(19f / 85f, 0.827451f, 0.18039216f);
			if (!GizmoContext.InActiveSelection(this))
			{
				color.a *= 0.4f;
			}
			Draw.Line(base.transform.position - Vector3.up * maxRange, base.transform.position + Vector3.up * maxRange, color);
		}
	}
}
