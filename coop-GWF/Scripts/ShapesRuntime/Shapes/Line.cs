using UnityEngine;

namespace Shapes
{
	[ExecuteAlways]
	[AddComponentMenu("Shapes/Line")]
	public class Line : ShapeRenderer, IDashable
	{
		public enum LineColorMode
		{
			Single = 0,
			Double = 1
		}

		[SerializeField]
		private LineGeometry geometry = LineGeometry.Billboard;

		[SerializeField]
		private LineColorMode colorMode;

		[SerializeField]
		[ShapesColorField(true)]
		private Color colorEnd = Color.white;

		[SerializeField]
		private Vector3 start = Vector3.zero;

		[SerializeField]
		private Vector3 end = Vector3.right;

		[SerializeField]
		private float thickness = 0.125f;

		[SerializeField]
		private ThicknessSpace thicknessSpace;

		[SerializeField]
		private LineEndCap endCaps = LineEndCap.Round;

		[SerializeField]
		private bool matchDashSpacingToSize = true;

		[SerializeField]
		private bool dashed;

		[SerializeField]
		private DashStyle dashStyle = DashStyle.defaultDashStyleLine;

		public Vector3 this[int i]
		{
			get
			{
				if (i <= 0)
				{
					return Start;
				}
				return End;
			}
			set
			{
				if (i <= 0)
				{
					Vector3 vector = (Start = value);
				}
				else
				{
					Vector3 vector = (End = value);
				}
			}
		}

		public LineGeometry Geometry
		{
			get
			{
				return geometry;
			}
			set
			{
				geometry = value;
				SetIntNow(ShapesMaterialUtils.propAlignment, (int)geometry);
				UpdateMesh(force: true);
				UpdateMaterial();
				ApplyProperties();
			}
		}

		public LineColorMode ColorMode
		{
			get
			{
				return colorMode;
			}
			set
			{
				SetColorNow(ShapesMaterialUtils.propColorEnd, ((colorMode = value) == LineColorMode.Double) ? colorEnd : base.Color);
			}
		}

		public override Color Color
		{
			get
			{
				return color;
			}
			set
			{
				SetColor(ShapesMaterialUtils.propColor, color = value);
				SetColorNow(ShapesMaterialUtils.propColorEnd, colorEnd = value);
			}
		}

		public Color ColorStart
		{
			get
			{
				return color;
			}
			set
			{
				SetColorNow(ShapesMaterialUtils.propColor, color = value);
			}
		}

		public Color ColorEnd
		{
			get
			{
				return colorEnd;
			}
			set
			{
				SetColorNow(ShapesMaterialUtils.propColorEnd, colorEnd = value);
			}
		}

		public Vector3 Start
		{
			get
			{
				return start;
			}
			set
			{
				SetVector3Now(ShapesMaterialUtils.propPointStart, start = value);
			}
		}

		public Vector3 End
		{
			get
			{
				return end;
			}
			set
			{
				SetVector3Now(ShapesMaterialUtils.propPointEnd, end = value);
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
				if (dashed && dashStyle.space == DashSpace.Relative)
				{
					SetAllDashValues(now: true);
				}
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

		public LineEndCap EndCaps
		{
			get
			{
				return endCaps;
			}
			set
			{
				endCaps = value;
				UpdateMaterial();
			}
		}

		internal override bool HasDetailLevels => true;

		public bool MatchDashSpacingToSize
		{
			get
			{
				return matchDashSpacingToSize;
			}
			set
			{
				matchDashSpacingToSize = value;
				SetAllDashValues(now: true);
			}
		}

		public bool Dashed
		{
			get
			{
				return dashed;
			}
			set
			{
				dashed = value;
				SetAllDashValues(now: true);
			}
		}

		public float DashSize
		{
			get
			{
				return dashStyle.size;
			}
			set
			{
				dashStyle.size = value;
				float netAbsoluteSize = dashStyle.GetNetAbsoluteSize(dashed, thickness);
				if (matchDashSpacingToSize)
				{
					SetFloat(ShapesMaterialUtils.propDashSpacing, GetNetDashSpacing());
				}
				SetFloatNow(ShapesMaterialUtils.propDashSize, netAbsoluteSize);
			}
		}

		public float DashSpacing
		{
			get
			{
				if (!matchDashSpacingToSize)
				{
					return dashStyle.spacing;
				}
				return dashStyle.size;
			}
			set
			{
				dashStyle.spacing = value;
				SetFloatNow(ShapesMaterialUtils.propDashSpacing, GetNetDashSpacing());
			}
		}

		public float DashOffset
		{
			get
			{
				return dashStyle.offset;
			}
			set
			{
				SetFloatNow(ShapesMaterialUtils.propDashOffset, dashStyle.offset = value);
			}
		}

		public DashSpace DashSpace
		{
			get
			{
				return dashStyle.space;
			}
			set
			{
				SetInt(ShapesMaterialUtils.propDashSpace, (int)(dashStyle.space = value));
				SetFloatNow(ShapesMaterialUtils.propDashSize, dashStyle.GetNetAbsoluteSize(dashed, thickness));
			}
		}

		public DashSnapping DashSnap
		{
			get
			{
				return dashStyle.snap;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propDashSnap, (int)(dashStyle.snap = value));
			}
		}

		public DashType DashType
		{
			get
			{
				return dashStyle.type;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propDashType, (int)(dashStyle.type = value));
			}
		}

		public float DashShapeModifier
		{
			get
			{
				return dashStyle.shapeModifier;
			}
			set
			{
				SetFloatNow(ShapesMaterialUtils.propDashShapeModifier, dashStyle.shapeModifier = value);
			}
		}

		private protected override void SetAllMaterialProperties()
		{
			SetVector3(ShapesMaterialUtils.propPointStart, start);
			SetVector3(ShapesMaterialUtils.propPointEnd, end);
			SetFloat(ShapesMaterialUtils.propThickness, thickness);
			SetInt(ShapesMaterialUtils.propThicknessSpace, (int)thicknessSpace);
			SetInt(ShapesMaterialUtils.propAlignment, (int)geometry);
			SetColor(ShapesMaterialUtils.propColorEnd, (colorMode == LineColorMode.Double) ? colorEnd : base.Color);
			SetAllDashValues(now: false);
		}

		private protected override Bounds GetUnpaddedLocalBounds_Internal()
		{
			float num = ((thicknessSpace == ThicknessSpace.Meters) ? thickness : 0f);
			Vector3 center = (start + end) / 2f;
			Vector3 size = ShapesMath.Abs(start - end) + new Vector3(num, num, num);
			return new Bounds(center, size);
		}

		private protected override void GetMaterials(Material[] mats)
		{
			mats[0] = ShapesMaterialUtils.GetLineMat(geometry, endCaps)[base.BlendMode];
		}

		private protected override Mesh GetInitialMeshAsset()
		{
			return ShapesMeshUtils.GetLineMesh(geometry, endCaps, detailLevel);
		}

		private protected override void ShapeClampRanges()
		{
			thickness = Mathf.Max(0f, thickness);
			DashSpacing = ((DashSpace == DashSpace.FixedCount) ? Mathf.Clamp01(DashSpacing) : Mathf.Max(0f, DashSpacing));
		}

		private void SetAllDashValues(bool now)
		{
			SetAllDashValues(dashStyle, Dashed, matchDashSpacingToSize, thickness, Geometry != LineGeometry.Volumetric3D, now);
		}

		private float GetNetDashSpacing()
		{
			return GetNetDashSpacing(dashStyle, dashed, matchDashSpacingToSize, thickness);
		}
	}
}
