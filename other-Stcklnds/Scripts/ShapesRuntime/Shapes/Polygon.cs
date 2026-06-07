using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Shapes
{
	[ExecuteAlways]
	[AddComponentMenu("Shapes/Polygon")]
	public class Polygon : ShapeRenderer, IFillable
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

		[SerializeField]
		private protected GradientFill fill = GradientFill.defaultFill;

		[SerializeField]
		private protected bool useFill;

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

		private protected override bool UseCamOnPreCull => true;

		internal override bool HasScaleModes => false;

		internal override bool HasDetailLevels => false;

		private protected override MeshUpdateMode MeshUpdateMode => MeshUpdateMode.SelfGenerated;

		public GradientFill Fill
		{
			get
			{
				return fill;
			}
			set
			{
				fill = value;
				SetFillProperties();
			}
		}

		public bool UseFill
		{
			get
			{
				return useFill;
			}
			set
			{
				useFill = value;
				SetIntNow(ShapesMaterialUtils.propFillType, fill.GetShaderFillTypeInt(useFill));
			}
		}

		public FillType FillType
		{
			get
			{
				return fill.type;
			}
			set
			{
				fill.type = value;
				SetIntNow(ShapesMaterialUtils.propFillType, fill.GetShaderFillTypeInt(useFill));
			}
		}

		public FillSpace FillSpace
		{
			get
			{
				return fill.space;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propFillSpace, (int)(fill.space = value));
			}
		}

		public Vector3 FillRadialOrigin
		{
			get
			{
				return fill.radialOrigin;
			}
			set
			{
				fill.radialOrigin = value;
				SetVector4Now(ShapesMaterialUtils.propFillStart, fill.GetShaderStartVector());
			}
		}

		public float FillRadialRadius
		{
			get
			{
				return fill.radialRadius;
			}
			set
			{
				fill.radialRadius = value;
				SetVector4Now(ShapesMaterialUtils.propFillStart, fill.GetShaderStartVector());
			}
		}

		public Vector3 FillLinearStart
		{
			get
			{
				return fill.linearStart;
			}
			set
			{
				fill.linearStart = value;
				SetVector4Now(ShapesMaterialUtils.propFillStart, fill.GetShaderStartVector());
			}
		}

		public Vector3 FillLinearEnd
		{
			get
			{
				return fill.linearEnd;
			}
			set
			{
				SetVector3Now(ShapesMaterialUtils.propFillEnd, fill.linearEnd = value);
			}
		}

		public Color FillColorStart
		{
			get
			{
				return fill.colorStart;
			}
			set
			{
				SetColorNow(ShapesMaterialUtils.propColor, fill.colorStart = value);
			}
		}

		public Color FillColorEnd
		{
			get
			{
				return fill.colorEnd;
			}
			set
			{
				SetColorNow(ShapesMaterialUtils.propColorEnd, fill.colorEnd = value);
			}
		}

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

		internal override void CamOnPreCull()
		{
			if (meshOutOfDate)
			{
				meshOutOfDate = false;
				UpdateMesh(force: true);
			}
		}

		private protected override void SetAllMaterialProperties()
		{
			SetFillProperties();
		}

		private protected override Material[] GetMaterials()
		{
			return new Material[1] { ShapesMaterialUtils.matPolygon[base.BlendMode] };
		}

		private protected override void GenerateMesh()
		{
			ShapesMeshGen.GenPolygonMesh(base.Mesh, points, triangulation);
		}

		private protected override Bounds GetBounds_Internal()
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

		private void SetFillProperties()
		{
			if (useFill)
			{
				SetInt(ShapesMaterialUtils.propFillSpace, (int)fill.space);
				SetVector4(ShapesMaterialUtils.propFillStart, fill.GetShaderStartVector());
				SetVector3(ShapesMaterialUtils.propFillEnd, fill.linearEnd);
				SetColor(ShapesMaterialUtils.propColor, fill.colorStart);
				SetColor(ShapesMaterialUtils.propColorEnd, fill.colorEnd);
			}
			SetInt(ShapesMaterialUtils.propFillType, fill.GetShaderFillTypeInt(useFill));
		}
	}
}
