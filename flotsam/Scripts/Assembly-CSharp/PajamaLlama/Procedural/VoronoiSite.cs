using System;
using System.Collections.Generic;
using External.Zalgo2462.VoronoiLib.Structures;
using PajamaLlama.Math;
using UnityEngine;

namespace PajamaLlama.Procedural
{
	public class VoronoiSite : FortuneSite
	{
		private static readonly Vector2 AXIS_MULTIPLIER = new Vector2(1f, -1f);

		private Mesh _mesh;

		public Vector2 Position { get; private set; }

		public List<Vector2> Vertices { get; private set; }

		public bool HasEdgesOnBounds { get; private set; }

		public Polygon Polygon { get; private set; }

		public Color DEBUG_Color { get; private set; }

		public VoronoiSite(Vector2 position)
			: base(position.x, position.y)
		{
			Position = position;
		}

		public VoronoiSite(float x, float y)
			: this(new Vector2(x, y))
		{
		}

		public void AddEdge(VEdge edge)
		{
			base.Cell.Add(edge);
		}

		public void ConstructPolygon(Rect bounds)
		{
			if (base.Cell.Count == 0)
			{
				return;
			}
			using (PooledList<VEdge> pooledList = PooledList<VEdge>.Get(base.Cell.Count))
			{
				VEdge nextEdge = GetCellStartEdge(base.Cell, bounds);
				VEdge vEdge = null;
				do
				{
					base.Cell.Remove(nextEdge);
					pooledList.Add(nextEdge);
					vEdge = nextEdge;
				}
				while (TryGetNextEdge(out nextEdge, vEdge, base.Cell, bounds));
				base.Cell.Clear();
				base.Cell.AddRange(pooledList);
			}
			HasEdgesOnBounds = VoronoiLibFunctions.AddBoundsEdgesToCell(base.Cell, bounds);
			if (Vertices == null)
			{
				Vertices = new List<Vector2>(base.Cell.Count);
			}
			else
			{
				Vertices.Clear();
			}
			if (0f <= base.Cell[0].SignedAngle(base.Cell[1]))
			{
				foreach (VEdge item in base.Cell)
				{
					Vertices.Add(item.Start.ToVector2());
				}
			}
			else
			{
				int count = base.Cell.Count;
				while (0 < count--)
				{
					Vertices.Add(base.Cell[count].Start.ToVector2());
				}
			}
			Polygon = new Polygon(Vertices);
		}

		public void SetPositionToCellCenterAndReset()
		{
			if (!base.Cell.IsNullOrEmpty())
			{
				Position = GetCentroid();
				base.X = Position.x;
				base.Y = Position.y;
			}
			base.Cell.Clear();
			base.Neighbors.Clear();
		}

		private bool TryGetNextEdge(out VEdge nextEdge, VEdge previousEdge, List<VEdge> edges, Rect bounds)
		{
			Vector2 collision;
			bool flag = previousEdge.End.TryGetBoundsCollision(bounds, out collision);
			VEdge vEdge = null;
			nextEdge = null;
			if (edges.Count == 0)
			{
				return false;
			}
			for (int i = 0; i < base.Cell.Count; i++)
			{
				nextEdge = base.Cell[i];
				if (previousEdge.End == nextEdge.Start)
				{
					return true;
				}
				if (previousEdge.End == nextEdge.End)
				{
					nextEdge.Flip();
					return true;
				}
				if (flag)
				{
					if (nextEdge.Start.TryGetBoundsCollision(bounds, out var collision2) && collision == collision2)
					{
						vEdge = new VEdge(previousEdge.End, this, null)
						{
							End = nextEdge.Start
						};
					}
					else if (nextEdge.End.TryGetBoundsCollision(bounds, out collision2) && collision == collision2)
					{
						vEdge = new VEdge(previousEdge.End, this, null)
						{
							End = nextEdge.End
						};
					}
				}
			}
			nextEdge = vEdge ?? throw new NotSupportedException("Huh?");
			return true;
		}

		public float ComputeSurface()
		{
			using ListPool<Vector3>.List list = ListPool<Vector3>.Get();
			using ListPool<int>.List list2 = ListPool<int>.Get();
			using ListPool<Vector2>.List uvs = ListPool<Vector2>.Get();
			float num = 0f;
			GenerateMeshTriangles(list, list2, uvs, Vector2.zero);
			for (int i = 0; i < list2.Count; i += 3)
			{
				Vector3 vector = list[list2[i]];
				Vector3 vector2 = list[list2[i + 1]];
				Vector3 vector3 = list[list2[i + 2]];
				float magnitude = (vector2 - vector).magnitude;
				float magnitude2 = (vector3 - vector2).magnitude;
				float magnitude3 = (vector - vector3).magnitude;
				float num2 = (magnitude + magnitude2 + magnitude3) / 2f;
				num += Mathf.Sqrt(num2 * (num2 - magnitude) * (num2 - magnitude2) * (num2 - magnitude3));
			}
			return num;
		}

		public VEdge GetCellStartEdge(List<VEdge> cell, Rect bounds)
		{
			foreach (VEdge item in cell)
			{
				if (item.Start.IsOnOrOutsideBounds(bounds))
				{
					return item;
				}
				if (item.End.IsOnOrOutsideBounds(bounds))
				{
					item.Flip();
					return item;
				}
			}
			return cell[0];
		}

		public Vector2 GetCentroid()
		{
			if (base.Cell.IsNullOrEmpty())
			{
				return Vector2.zero;
			}
			double num = 0.0;
			double num2 = 0.0;
			int num3 = 0;
			foreach (VEdge item in base.Cell)
			{
				num += item.Start.X + item.End.X;
				num2 += item.Start.Y + item.End.Y;
				num3 += 2;
			}
			return new Vector2((float)num / (float)num3, (float)num2 / (float)num3);
		}

		public Mesh GetMesh(out Vector2 centroid)
		{
			centroid = GetCentroid();
			if (_mesh == null)
			{
				int count = Vertices.Count;
				int num = count + 1;
				Vector3[] array = new Vector3[num];
				int[] array2 = new int[count * 3];
				array[0] = Vector2.zero;
				for (int i = 0; i < count; i++)
				{
					array[i + 1] = (Vertices[i] - centroid) * AXIS_MULTIPLIER;
					int num2 = i * 3;
					array2[num2] = 0;
					array2[num2 + 1] = PajamaLlama.Math.Math.IncrementIndexWrapped(i, num);
					array2[num2 + 2] = PajamaLlama.Math.Math.IncrementIndexWrapped(i, num, 2);
				}
				array2[^1] = 1;
				_mesh = new Mesh();
				_mesh.SetVertices(array);
				_mesh.SetTriangles(array2, 0);
			}
			return _mesh;
		}

		public void GenerateMeshTriangles(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Vector2 uvOffset)
		{
			int count = Vertices.Count;
			int maxIndex = count + 1;
			int count2 = vertices.Count;
			vertices.Add(GetCentroid());
			uvs.Add(uvOffset);
			for (int i = 0; i < count; i++)
			{
				vertices.Add(Vertices[i]);
				uvs.Add(uvOffset);
				triangles.Add(count2);
				triangles.Add(count2 + PajamaLlama.Math.Math.IncrementIndexWrapped(i, maxIndex));
				triangles.Add(count2 + PajamaLlama.Math.Math.IncrementIndexWrapped(i, maxIndex, 2));
			}
			triangles[triangles.Count - 1] = count2 + 1;
		}
	}
}
