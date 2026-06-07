using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Shapes
{
	[ExecuteAlways]
	[AddComponentMenu("Shapes/RegularPolygon")]
	public class RegularPolygon : ShapeRenderer, IDashable, IFillable
	{
		[FormerlySerializedAs("hollow")]
		[SerializeField]
		private bool border;

		[SerializeField]
		private int sides = 3;

		[SerializeField]
		[Range(0f, 1f)]
		private float roundness;

		[SerializeField]
		private float angle = MathF.PI / 2f;

		[SerializeField]
		private float radius = 1f;

		[SerializeField]
		private AngularUnit angUnitInput = AngularUnit.Degrees;

		[SerializeField]
		private RegularPolygonGeometry geometry;

		[SerializeField]
		private ThicknessSpace radiusSpace;

		[SerializeField]
		private float thickness = 0.5f;

		[SerializeField]
		private ThicknessSpace thicknessSpace;

		[SerializeField]
		private bool matchDashSpacingToSize = true;

		[SerializeField]
		private bool dashed;

		[SerializeField]
		private DashStyle dashStyle = DashStyle.defaultDashStyleRing;

		[SerializeField]
		private protected GradientFill fill = GradientFill.defaultFill;

		[SerializeField]
		private protected bool useFill;

		public bool Border
		{
			get
			{
				return border;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propBorder, (border = value).AsInt());
			}
		}

		[Obsolete("Please use RegularPolygon.Border instead", true)]
		public bool Hollow
		{
			get
			{
				return Border;
			}
			set
			{
				Border = value;
			}
		}

		public int Sides
		{
			get
			{
				return sides;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propSides, sides = Mathf.Max(3, value));
			}
		}

		public float Roundness
		{
			get
			{
				return roundness;
			}
			set
			{
				SetFloatNow(ShapesMaterialUtils.propRoundness, roundness = Mathf.Clamp01(value));
			}
		}

		public float Angle
		{
			get
			{
				return angle;
			}
			set
			{
				SetFloatNow(ShapesMaterialUtils.propAng, angle = value);
			}
		}

		public float Radius
		{
			get
			{
				return radius;
			}
			set
			{
				SetFloatNow(ShapesMaterialUtils.propRadius, radius = Mathf.Max(0f, value));
			}
		}

		public RegularPolygonGeometry Geometry
		{
			get
			{
				return geometry;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propAlignment, (int)(geometry = value));
			}
		}

		public ThicknessSpace RadiusSpace
		{
			get
			{
				return radiusSpace;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propRadiusSpace, (int)(radiusSpace = value));
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
				SetFloatNow(ShapesMaterialUtils.propThickness, thickness = Mathf.Max(0f, value));
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

		internal override bool HasDetailLevels => false;

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
				SetAllMaterialProperties();
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

		private protected override void SetAllMaterialProperties()
		{
			SetFillProperties();
			SetIntNow(ShapesMaterialUtils.propBorder, border.AsInt());
			SetInt(ShapesMaterialUtils.propAlignment, (int)geometry);
			SetFloat(ShapesMaterialUtils.propRadius, radius);
			SetInt(ShapesMaterialUtils.propRadiusSpace, (int)radiusSpace);
			SetFloat(ShapesMaterialUtils.propThickness, thickness);
			SetInt(ShapesMaterialUtils.propThicknessSpace, (int)thicknessSpace);
			SetFloat(ShapesMaterialUtils.propAng, angle);
			SetFloat(ShapesMaterialUtils.propSides, sides);
			SetFloat(ShapesMaterialUtils.propRoundness, roundness);
			SetAllDashValues(now: false);
		}

		private protected override void GetMaterials(Material[] mats)
		{
			mats[0] = ShapesMaterialUtils.matRegularPolygon[base.BlendMode];
		}

		private protected override Bounds GetUnpaddedLocalBounds_Internal()
		{
			if (radiusSpace != ThicknessSpace.Meters)
			{
				return new Bounds(Vector3.zero, Vector3.zero);
			}
			float num = ((radiusSpace == ThicknessSpace.Meters) ? (radius * 2f) : 0f);
			num += ((thicknessSpace == ThicknessSpace.Meters) ? thickness : 0f);
			return new Bounds(Vector3.zero, new Vector3(num, num, 0f));
		}

		private void SetAllDashValues(bool now)
		{
			SetAllDashValues(dashStyle, Dashed, matchDashSpacingToSize, thickness, setType: true, now);
		}

		private float GetNetDashSpacing()
		{
			return GetNetDashSpacing(dashStyle, dashed, matchDashSpacingToSize, thickness);
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
