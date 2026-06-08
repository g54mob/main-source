using System;
using UnityEngine;

namespace Shapes
{
	[ExecuteInEditMode]
	[AddComponentMenu("Shapes/Rectangle")]
	public class Rectangle : ShapeRenderer
	{
		public enum RectangleType
		{
			HardSolid = 0,
			RoundedSolid = 1,
			HardHollow = 2,
			RoundedHollow = 3
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

		[SerializeField]
		private float thickness = 0.1f;

		public bool IsHollow
		{
			get
			{
				if (type != RectangleType.HardHollow)
				{
					return type == RectangleType.RoundedHollow;
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
					return type == RectangleType.RoundedHollow;
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

		public Vector4 CornerRadiii
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

		public override bool HasDetailLevels => false;

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

		protected override void SetAllMaterialProperties()
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
		}

		protected override Material[] GetMaterials()
		{
			return new Material[1] { ShapesMaterialUtils.GetRectMaterial(type)[base.BlendMode] };
		}

		protected override Bounds GetBounds()
		{
			Vector2 vector = new Vector2(width, height);
			return new Bounds((pivot == RectPivot.Center) ? default(Vector2) : (vector / 2f), vector);
		}
	}
}
