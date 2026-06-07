using System;
using UnityEngine;

namespace Shapes
{
	[ExecuteAlways]
	[AddComponentMenu("Shapes/Rectangle")]
	public class Rectangle : ShapeRenderer, IDashable, IFillable
	{
		public enum RectangleType
		{
			HardSolid = 0,
			RoundedSolid = 1,
			HardBorder = 2,
			RoundedBorder = 3
		}

		public enum RectangleCornerRadiusMode
		{
			Uniform = 0,
			PerCorner = 1
		}

		[SerializeField]
		private RectPivot pivot = RectPivot.Center;

		[SerializeField]
		private float width = 1f;

		[SerializeField]
		private float height = 1f;

		[SerializeField]
		private RectangleType type;

		[SerializeField]
		private RectangleCornerRadiusMode cornerRadiusMode;

		[SerializeField]
		private Vector4 cornerRadii = new Vector4(0.25f, 0.25f, 0.25f, 0.25f);

		[Tooltip("The thickness of the rectangle, in the given thickness space")]
		[SerializeField]
		private float thickness = 0.1f;

		[Tooltip("The space in which thickness is defined")]
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

		public bool IsBorder
		{
			get
			{
				if (type != RectangleType.HardBorder)
				{
					return type == RectangleType.RoundedBorder;
				}
				return true;
			}
		}

		[Obsolete("Please use IsBorder instead", true)]
		public bool IsHollow
		{
			get
			{
				if (type != RectangleType.HardBorder)
				{
					return type == RectangleType.RoundedBorder;
				}
				return true;
			}
		}

		public bool IsRounded
		{
			get
			{
				if (type != RectangleType.RoundedSolid)
				{
					return type == RectangleType.RoundedBorder;
				}
				return true;
			}
		}

		public RectPivot Pivot
		{
			get
			{
				return pivot;
			}
			set
			{
				pivot = value;
				UpdateRectPositioningNow();
			}
		}

		public float Width
		{
			get
			{
				return width;
			}
			set
			{
				width = value;
				UpdateRectPositioningNow();
			}
		}

		public float Height
		{
			get
			{
				return height;
			}
			set
			{
				height = value;
				UpdateRectPositioningNow();
			}
		}

		public RectangleType Type
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

		public RectangleCornerRadiusMode CornerRadiusMode
		{
			get
			{
				return cornerRadiusMode;
			}
			set
			{
				cornerRadiusMode = value;
			}
		}

		[Obsolete("Radius is deprecated, please use CornerRadius instead", true)]
		public float Radius
		{
			get
			{
				return CornerRadius;
			}
			set
			{
				CornerRadius = value;
			}
		}

		public float CornerRadius
		{
			get
			{
				return cornerRadii.x;
			}
			set
			{
				float num = Mathf.Max(0f, value);
				SetVector4Now(ShapesMaterialUtils.propCornerRadii, cornerRadii = new Vector4(num, num, num, num));
			}
		}

		public Vector4 CornerRadii
		{
			get
			{
				return cornerRadii;
			}
			set
			{
				SetVector4Now(ShapesMaterialUtils.propCornerRadii, cornerRadii = new Vector4(Mathf.Max(0f, value.x), Mathf.Max(0f, value.y), Mathf.Max(0f, value.z), Mathf.Max(0f, value.w)));
			}
		}

		[Obsolete("Please use CornerRadii instead because I did a typo~", true)]
		public Vector4 CornerRadiii
		{
			get
			{
				return CornerRadii;
			}
			set
			{
				CornerRadii = value;
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

		private void UpdateRectPositioningNow()
		{
			SetVector4Now(ShapesMaterialUtils.propRect, GetPositioningRect());
		}

		private void UpdateRectPositioning()
		{
			SetVector4(ShapesMaterialUtils.propRect, GetPositioningRect());
		}

		private Vector4 GetPositioningRect()
		{
			float x = ((pivot == RectPivot.Corner) ? 0f : ((0f - width) / 2f));
			float y = ((pivot == RectPivot.Corner) ? 0f : ((0f - height) / 2f));
			return new Vector4(x, y, width, height);
		}

		private protected override void SetAllMaterialProperties()
		{
			if (cornerRadiusMode == RectangleCornerRadiusMode.PerCorner)
			{
				SetVector4(ShapesMaterialUtils.propCornerRadii, cornerRadii);
			}
			else if (cornerRadiusMode == RectangleCornerRadiusMode.Uniform)
			{
				SetVector4(ShapesMaterialUtils.propCornerRadii, new Vector4(CornerRadius, CornerRadius, CornerRadius, CornerRadius));
			}
			UpdateRectPositioning();
			SetFloat(ShapesMaterialUtils.propThickness, thickness);
			SetIntNow(ShapesMaterialUtils.propThicknessSpace, (int)thicknessSpace);
			SetFillProperties();
			SetAllDashValues(now: false);
		}

		private protected override void GetMaterials(Material[] mats)
		{
			mats[0] = ShapesMaterialUtils.GetRectMaterial(type)[base.BlendMode];
		}

		private protected override Bounds GetUnpaddedLocalBounds_Internal()
		{
			Vector2 vector = new Vector2(width, height);
			return new Bounds((pivot == RectPivot.Center) ? default(Vector2) : (vector / 2f), vector);
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
