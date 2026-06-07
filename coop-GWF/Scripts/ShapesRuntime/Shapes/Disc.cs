using System;
using UnityEngine;

namespace Shapes
{
	[ExecuteAlways]
	[AddComponentMenu("Shapes/Disc")]
	public class Disc : ShapeRenderer, IDashable
	{
		public enum DiscColorMode
		{
			Single = 0,
			Radial = 1,
			Angular = 2,
			Bilinear = 3
		}

		[SerializeField]
		private DiscType type;

		[SerializeField]
		private DiscColorMode colorMode;

		[SerializeField]
		[ShapesColorField(true)]
		private Color colorOuterStart = Color.white;

		[SerializeField]
		[ShapesColorField(true)]
		private Color colorInnerEnd = Color.white;

		[SerializeField]
		[ShapesColorField(true)]
		private Color colorOuterEnd = Color.white;

		[SerializeField]
		private DiscGeometry geometry;

		[SerializeField]
		private AngularUnit angUnitInput = AngularUnit.Degrees;

		[SerializeField]
		private float angRadiansStart;

		[SerializeField]
		private float angRadiansEnd = MathF.PI * 3f / 4f;

		[SerializeField]
		private float radius = 1f;

		[SerializeField]
		private ThicknessSpace radiusSpace;

		[SerializeField]
		private float thickness = 0.5f;

		[SerializeField]
		private ThicknessSpace thicknessSpace;

		[SerializeField]
		private ArcEndCap arcEndCaps;

		[SerializeField]
		private bool matchDashSpacingToSize = true;

		[SerializeField]
		private bool dashed;

		[SerializeField]
		private DashStyle dashStyle = DashStyle.defaultDashStyleRing;

		public bool HasThickness => type.HasThickness();

		public bool HasSector => type.HasSector();

		public DiscType Type
		{
			get
			{
				return type;
			}
			set
			{
				type = value;
				UpdateMaterial();
				ApplyProperties();
			}
		}

		public DiscColorMode ColorMode
		{
			get
			{
				return colorMode;
			}
			set
			{
				colorMode = value;
				ApplyProperties();
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
				SetColor(ShapesMaterialUtils.propColorOuterStart, colorOuterStart = value);
				SetColor(ShapesMaterialUtils.propColorInnerEnd, colorInnerEnd = value);
				SetColorNow(ShapesMaterialUtils.propColorOuterEnd, colorOuterEnd = value);
			}
		}

		public Color ColorInnerStart
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

		public Color ColorOuterStart
		{
			get
			{
				return colorOuterStart;
			}
			set
			{
				SetColorNow(ShapesMaterialUtils.propColorOuterStart, colorOuterStart = value);
			}
		}

		public Color ColorInnerEnd
		{
			get
			{
				return colorInnerEnd;
			}
			set
			{
				SetColorNow(ShapesMaterialUtils.propColorInnerEnd, colorInnerEnd = value);
			}
		}

		public Color ColorOuterEnd
		{
			get
			{
				return colorOuterEnd;
			}
			set
			{
				SetColorNow(ShapesMaterialUtils.propColorOuterEnd, colorOuterEnd = value);
			}
		}

		public Color ColorOuter
		{
			get
			{
				return ColorOuterStart;
			}
			set
			{
				SetColor(ShapesMaterialUtils.propColorOuterStart, colorOuterStart = value);
				SetColorNow(ShapesMaterialUtils.propColorOuterEnd, colorOuterEnd = value);
			}
		}

		public Color ColorInner
		{
			get
			{
				return color;
			}
			set
			{
				SetColor(ShapesMaterialUtils.propColor, color = value);
				SetColorNow(ShapesMaterialUtils.propColorInnerEnd, colorInnerEnd = value);
			}
		}

		public Color ColorStart
		{
			get
			{
				return base.Color;
			}
			set
			{
				SetColor(ShapesMaterialUtils.propColor, color = value);
				SetColorNow(ShapesMaterialUtils.propColorOuterStart, colorOuterStart = value);
			}
		}

		public Color ColorEnd
		{
			get
			{
				return colorInnerEnd;
			}
			set
			{
				SetColor(ShapesMaterialUtils.propColorInnerEnd, colorInnerEnd = value);
				SetColorNow(ShapesMaterialUtils.propColorOuterEnd, colorOuterEnd = value);
			}
		}

		public DiscGeometry Geometry
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

		public float AngRadiansStart
		{
			get
			{
				return angRadiansStart;
			}
			set
			{
				SetFloatNow(ShapesMaterialUtils.propAngStart, angRadiansStart = value);
			}
		}

		public float AngRadiansEnd
		{
			get
			{
				return angRadiansEnd;
			}
			set
			{
				SetFloatNow(ShapesMaterialUtils.propAngEnd, angRadiansEnd = value);
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

		[Obsolete("this property is obsolete, this was a typo! please use Thickness instead!", true)]
		public float RadiusInner
		{
			get
			{
				return Thickness;
			}
			set
			{
				Thickness = value;
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
				if (HasThickness && dashed && dashStyle.space == DashSpace.Relative)
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

		public ArcEndCap ArcEndCaps
		{
			get
			{
				return arcEndCaps;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propRoundCaps, (int)(arcEndCaps = value));
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

		private protected override void SetAllMaterialProperties()
		{
			SetInt(ShapesMaterialUtils.propAlignment, (int)geometry);
			SetFloat(ShapesMaterialUtils.propRadius, radius);
			SetInt(ShapesMaterialUtils.propRadiusSpace, (int)radiusSpace);
			SetFloat(ShapesMaterialUtils.propThickness, thickness);
			SetInt(ShapesMaterialUtils.propThicknessSpace, (int)thicknessSpace);
			SetInt(ShapesMaterialUtils.propRoundCaps, (int)arcEndCaps);
			SetFloat(ShapesMaterialUtils.propAngStart, angRadiansStart);
			SetFloat(ShapesMaterialUtils.propAngEnd, angRadiansEnd);
			switch (ColorMode)
			{
			case DiscColorMode.Single:
				SetColor(ShapesMaterialUtils.propColorOuterStart, base.Color);
				SetColor(ShapesMaterialUtils.propColorInnerEnd, base.Color);
				SetColor(ShapesMaterialUtils.propColorOuterEnd, base.Color);
				break;
			case DiscColorMode.Radial:
				SetColor(ShapesMaterialUtils.propColorOuterStart, ColorOuterStart);
				SetColor(ShapesMaterialUtils.propColorInnerEnd, base.Color);
				SetColor(ShapesMaterialUtils.propColorOuterEnd, ColorOuterStart);
				break;
			case DiscColorMode.Angular:
				SetColor(ShapesMaterialUtils.propColorOuterStart, base.Color);
				SetColor(ShapesMaterialUtils.propColorInnerEnd, ColorInnerEnd);
				SetColor(ShapesMaterialUtils.propColorOuterEnd, ColorInnerEnd);
				break;
			case DiscColorMode.Bilinear:
				SetColor(ShapesMaterialUtils.propColorOuterStart, ColorOuterStart);
				SetColor(ShapesMaterialUtils.propColorInnerEnd, ColorInnerEnd);
				SetColor(ShapesMaterialUtils.propColorOuterEnd, ColorOuterEnd);
				break;
			}
			SetAllDashValues(now: false);
		}

		private protected override void GetMaterials(Material[] mats)
		{
			mats[0] = ShapesMaterialUtils.GetDiscMaterial(type)[base.BlendMode];
		}

		private protected override Bounds GetUnpaddedLocalBounds_Internal()
		{
			float num = ((radiusSpace == ThicknessSpace.Meters) ? (2f * radius) : 0f);
			num += ((HasThickness && thicknessSpace == ThicknessSpace.Meters) ? thickness : 0f);
			return new Bounds(Vector3.zero, new Vector3(num, num, (geometry == DiscGeometry.Billboard) ? num : 0f));
		}

		private void SetAllDashValues(bool now)
		{
			SetAllDashValues(dashStyle, Dashed, matchDashSpacingToSize, thickness, setType: true, now);
		}

		private float GetNetDashSpacing()
		{
			return GetNetDashSpacing(dashStyle, dashed, matchDashSpacingToSize, thickness);
		}
	}
}
