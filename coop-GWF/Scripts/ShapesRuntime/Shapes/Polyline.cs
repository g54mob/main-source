using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Shapes
{
	[ExecuteAlways]
	[AddComponentMenu("Shapes/Polyline")]
	public class Polyline : ShapeRenderer
	{
		[FormerlySerializedAs("polyPoints")]
		[SerializeField]
		public List<PolylinePoint> points = new List<PolylinePoint>
		{
			new PolylinePoint(new Vector3(0f, 1f, 0f), Color.white),
			new PolylinePoint(new Vector3(0.8660254f, -0.5f, 0f), Color.white),
			new PolylinePoint(new Vector3(-0.8660254f, -0.5f, 0f), Color.white)
		};

		[SerializeField]
		private PolylineGeometry geometry;

		[SerializeField]
		private PolylineJoins joins = PolylineJoins.Miter;

		[SerializeField]
		private bool closed = true;

		[SerializeField]
		private float thickness = 0.125f;

		[SerializeField]
		private ThicknessSpace thicknessSpace;

		public PolylineGeometry Geometry
		{
			get
			{
				return geometry;
			}
			set
			{
				geometry = value;
				SetIntNow(ShapesMaterialUtils.propAlignment, (int)geometry);
				UpdateMaterial();
				ApplyProperties();
			}
		}

		public PolylineJoins Joins
		{
			get
			{
				return joins;
			}
			set
			{
				joins = value;
				meshOutOfDate = true;
				UpdateMaterial();
			}
		}

		public bool Closed
		{
			get
			{
				return closed;
			}
			set
			{
				closed = value;
				meshOutOfDate = true;
			}
		}

		public float Thickness
		{
			get
			{
				return thickness;
			}
			set
			{
				SetFloatNow(ShapesMaterialUtils.propThickness, thickness = value);
			}
		}

		public ThicknessSpace ThicknessSpace
		{
			get
			{
				return thicknessSpace;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propThicknessSpace, (int)(thicknessSpace = value));
			}
		}

		public int Count => points.Count;

		public PolylinePoint this[int i]
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

		private protected override bool UseCamOnPreCull => true;

		private protected override MeshUpdateMode MeshUpdateMode => MeshUpdateMode.SelfGenerated;

		private protected override int MaterialCount
		{
			get
			{
				if (!joins.HasJoinMesh())
				{
					return 1;
				}
				return 2;
			}
		}

		public void SetPointPosition(int index, Vector3 position)
		{
			if (index < 0 || index >= Count)
			{
				throw new IndexOutOfRangeException();
			}
			PolylinePoint value = points[index];
			value.point = position;
			points[index] = value;
			meshOutOfDate = true;
		}

		public void SetPointColor(int index, Color color)
		{
			if (index < 0 || index >= Count)
			{
				throw new IndexOutOfRangeException();
			}
			PolylinePoint value = points[index];
			value.color = color;
			points[index] = value;
			meshOutOfDate = true;
		}

		public void SetPointThickness(int index, float thickness)
		{
			if (index < 0 || index >= Count)
			{
				throw new IndexOutOfRangeException();
			}
			PolylinePoint value = points[index];
			value.thickness = thickness;
			points[index] = value;
			meshOutOfDate = true;
		}

		public void SetPoints(IReadOnlyCollection<Vector3> points, IReadOnlyCollection<Color> colors = null)
		{
			this.points.Clear();
			if (colors == null)
			{
				AddPoints(points.Select((Vector3 p) => new PolylinePoint(p, Color.white)));
				return;
			}
			if (points.Count != colors.Count)
			{
				throw new ArgumentException("point.Count != color.Count");
			}
			AddPoints(points.Zip(colors, (Vector3 p, Color c) => new PolylinePoint(p, c)));
		}

		public void SetPoints(IReadOnlyCollection<Vector2> points, IReadOnlyCollection<Color> colors = null)
		{
			meshOutOfDate = true;
			this.points.Clear();
			if (colors == null)
			{
				AddPoints(points.Select((Vector2 p) => new PolylinePoint(p, Color.white)));
				return;
			}
			if (points.Count != colors.Count)
			{
				throw new ArgumentException("point.Count != color.Count");
			}
			AddPoints(points.Zip(colors, (Vector2 p, Color c) => new PolylinePoint(p, c)));
		}

		public void SetPoints(IEnumerable<PolylinePoint> points)
		{
			this.points.Clear();
			AddPoints(points);
		}

		public void AddPoints(IEnumerable<PolylinePoint> points)
		{
			this.points.AddRange(points);
			meshOutOfDate = true;
		}

		public void AddPoint(Vector3 position)
		{
			AddPoint(new PolylinePoint(position));
		}

		public void AddPoint(Vector3 position, Color color)
		{
			AddPoint(new PolylinePoint(position, color));
		}

		public void AddPoint(Vector3 position, Color color, float thickness)
		{
			AddPoint(new PolylinePoint(position, color, thickness));
		}

		public void AddPoint(Vector3 position, float thickness)
		{
			AddPoint(new PolylinePoint(position, Color.white, thickness));
		}

		public void AddPoint(PolylinePoint point)
		{
			points.Add(point);
			meshOutOfDate = true;
		}

		internal override void CamOnPreCull()
		{
			if (meshOutOfDate)
			{
				meshOutOfDate = false;
				UpdateMesh(force: true);
			}
		}

		private protected override void GenerateMesh()
		{
			ShapesMeshGen.GenPolylineMesh(base.Mesh, points, closed, joins, geometry == PolylineGeometry.Flat2D, useColors: true);
		}

		private protected override void SetAllMaterialProperties()
		{
			SetFloat(ShapesMaterialUtils.propThickness, thickness);
			SetInt(ShapesMaterialUtils.propThicknessSpace, (int)thicknessSpace);
			SetInt(ShapesMaterialUtils.propAlignment, (int)geometry);
		}

		private protected override void ShapeClampRanges()
		{
			thickness = Mathf.Max(0f, thickness);
		}

		private protected override void GetMaterials(Material[] mats)
		{
			mats[0] = ShapesMaterialUtils.GetPolylineMat(joins)[base.BlendMode];
			if (MaterialCount == 2)
			{
				mats[1] = ShapesMaterialUtils.GetPolylineJoinsMat(joins)[base.BlendMode];
			}
		}

		private protected override Bounds GetUnpaddedLocalBounds_Internal()
		{
			if (points.Count < 2)
			{
				return default(Bounds);
			}
			Vector3 vector = Vector3.one * float.MaxValue;
			Vector3 vector2 = Vector3.one * float.MinValue;
			foreach (Vector3 item in points.Select((PolylinePoint p) => p.point))
			{
				vector = Vector3.Min(vector, item);
				vector2 = Vector3.Max(vector2, item);
			}
			if (geometry == PolylineGeometry.Flat2D)
			{
				vector.z = (vector2.z = 0f);
			}
			float num = ((joins == PolylineJoins.Miter) ? 2.4142137f : 1f);
			float num2 = ((thicknessSpace == ThicknessSpace.Meters) ? (thickness * num) : 0f);
			return new Bounds((vector2 + vector) * 0.5f, vector2 - vector + Vector3.one * num2);
		}
	}
}
