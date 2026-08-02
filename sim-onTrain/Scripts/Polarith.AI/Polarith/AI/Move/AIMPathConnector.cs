using System;
using System.Collections.Generic;
using Polarith.UnityUtils;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	public abstract class AIMPathConnector : MonoBehaviour
	{
		public Action PathChanged;

		[Tooltip("Determines the color of all vertices as well as the start color of the edges.")]
		[SerializeField]
		protected Color firstColor = Color.magenta;

		[Tooltip("Determines the end color of the edges as well as the color of the path destination.")]
		[SerializeField]
		protected Color secondColor = Color.cyan;

		[Tooltip("Resizes the visualized sphere for each path point.")]
		[SerializeField]
		protected float scale = 1f;

		[Tooltip("Specifies if path points are to be visualized or not.")]
		[SerializeField]
		protected bool enableVisualization = true;

		[SerializeField]
		[HideInInspector]
		private TabState tabState;

		[SerializeField]
		[HideInInspector]
		private bool pointsFoldout;

		protected abstract IList<Vector3> points { get; }

		public virtual IList<Vector3> GetPoints()
		{
			return new List<Vector3>(points);
		}

		public virtual void GetPointsNonAlloc(IList<Vector3> points)
		{
			Collections.CopyList(this.points, points);
		}

		public virtual IList<Vector3> GetLocalPoints()
		{
			IList<Vector3> list = new List<Vector3>(points);
			for (int i = 0; i < points.Count; i++)
			{
				list[i] = base.transform.worldToLocalMatrix.MultiplyPoint(points[i]);
			}
			return list;
		}

		public virtual void GetLocalPointsNonAlloc(IList<Vector3> points)
		{
			Collections.ResizeList(points, this.points.Count);
			for (int i = 0; i < points.Count; i++)
			{
				points[i] = base.transform.worldToLocalMatrix.MultiplyPoint(this.points[i]);
			}
		}

		protected virtual void OnDrawGizmos()
		{
			if (points != null && points.Count != 0 && enableVisualization)
			{
				for (int i = 0; i < points.Count - 1; i++)
				{
					DrawPoint(i);
					DrawEdge(i);
				}
				DrawPoint(points.Count - 1);
			}
		}

		protected virtual void DrawPoint(int index)
		{
			Gizmos.color = firstColor;
			if (index == points.Count - 1)
			{
				Gizmos.color = secondColor;
			}
			Gizmos.DrawSphere(points[index], scale);
		}

		protected virtual void DrawEdge(int startPointIndex)
		{
			Vector3 vector = points[startPointIndex];
			Vector3 vector2 = points[startPointIndex + 1];
			Vector3 normalized = (vector2 - vector).normalized;
			vector += scale * normalized;
			vector2 -= scale * normalized;
			DrawLineWithGradient(vector, vector2, firstColor, secondColor);
		}

		private static void DrawLineWithGradient(Vector3 start, Vector3 end, Color startColor, Color endColor)
		{
			Vector3 vector = end - start;
			Gizmos.color = startColor;
			float num = 0f;
			for (int i = 0; i < 10; i++)
			{
				num = (float)i / 10f;
				Gizmos.color = Color.Lerp(startColor, endColor, num);
				Vector3 vector2 = start + num * vector;
				Vector3 to = start + (float)(i + 1) / 10f * vector;
				Gizmos.DrawLine(vector2, to);
			}
		}
	}
}
