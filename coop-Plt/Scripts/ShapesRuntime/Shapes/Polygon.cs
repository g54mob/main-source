using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Shapes
{
	[ExecuteInEditMode]
	[AddComponentMenu("Shapes/Polygon")]
	public class Polygon : ShapeRendererFillable
	{
		[FormerlySerializedAs("polyPoints")]
		[SerializeField]
		public List<Vector2> points = new List<Vector2>
		{
			new Vector2(1f, 0f),
			new Vector2(0.5f, 0.86602545f),
			new Vector2(-0.5f, 0.8660254f),
			new Vector2(-1f, 0f),
			new Vector2(-0.5f, -0.86602545f),
			new Vector2(0.5f, -0.86602545f)
		};

		[SerializeField]
		private PolygonTriangulation triangulation = PolygonTriangulation.EarClipping;

		public PolygonTriangulation Triangulation
		{
			get
			{
				return triangulation;
			}
			set
			{
				triangulation = value;
				meshOutOfDate = true;
			}
		}

		public int Count => points.Count;

		public Vector2 this[int i]
		{
			get
			{
				return points[i];
			}
			set
			{
				points[i] = value;
				meshOutOfDate = true;
			}
		}

		protected override bool UseCamOnPreCull => true;

		public override bool HasScaleModes => false;

		public override bool HasDetailLevels => false;

		protected override MeshUpdateMode MeshUpdateMode => MeshUpdateMode.SelfGenerated;

		public void SetPointPosition(int index, Vector2 position)
		{
			if (index < 0 || index >= Count)
			{
				throw new IndexOutOfRangeException();
			}
			points[index] = position;
			meshOutOfDate = true;
		}

		public void SetPoints(IEnumerable<Vector2> points)
		{
			this.points.Clear();
			AddPoints(points);
		}

		public void AddPoints(IEnumerable<Vector2> points)
		{
			this.points.AddRange(points);
			meshOutOfDate = true;
		}

		public void AddPoint(Vector2 point)
		{
			points.Add(point);
			meshOutOfDate = true;
		}

		protected override void CamOnPreCull()
		{
			if (meshOutOfDate)
			{
				meshOutOfDate = false;
				UpdateMesh(force: true);
			}
		}

		protected override void SetAllMaterialProperties()
		{
			SetFillProperties();
		}

		protected override Material[] GetMaterials()
		{
			return new Material[1] { ShapesMaterialUtils.matPolygon[base.BlendMode] };
		}

		protected override void GenerateMesh()
		{
			ShapesMeshGen.GenPolygonMesh(base.Mesh, points, triangulation);
		}

		protected override Bounds GetBounds()
		{
			if (points.Count < 2)
			{
				return default(Bounds);
			}
			Vector3 vector = Vector3.one * float.MaxValue;
			Vector3 vector2 = Vector3.one * float.MinValue;
			foreach (Vector2 point in points)
			{
				Vector3 rhs = point;
				vector = Vector3.Min(vector, rhs);
				vector2 = Vector3.Max(vector2, rhs);
			}
			return new Bounds((vector2 + vector) * 0.5f, vector2 - vector);
		}
	}
}
