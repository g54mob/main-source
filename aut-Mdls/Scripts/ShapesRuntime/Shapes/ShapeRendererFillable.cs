using System;
using UnityEngine;

namespace Shapes
{
	[Obsolete("Shapes now use the IFillable interface instead of inheriting from ShapeRendererFillable", true)]
	public abstract class ShapeRendererFillable : ShapeRenderer
	{
		private const string OBSOLETE = "Shapes now use the IFillable interface instead of inheriting from ShapeRendererFillable";

		[Obsolete("Shapes now use the IFillable interface instead of inheriting from ShapeRendererFillable", true)]
		private protected GradientFill fill;

		[Obsolete("Shapes now use the IFillable interface instead of inheriting from ShapeRendererFillable", true)]
		private protected bool useFill;

		[Obsolete("Shapes now use the IFillable interface instead of inheriting from ShapeRendererFillable", true)]
		private int FillTypeShaderInt
		{
			get
			{
				if (!useFill)
				{
					return -1;
				}
				return (int)fill.type;
			}
		}

		[Obsolete("Shapes now use the IFillable interface instead of inheriting from ShapeRendererFillable", true)]
		public bool UseFill
		{
			get
			{
				return useFill;
			}
			set
			{
				useFill = value;
				SetIntNow(ShapesMaterialUtils.propFillType, FillTypeShaderInt);
			}
		}

		[Obsolete("Shapes now use the IFillable interface instead of inheriting from ShapeRendererFillable", true)]
		public FillType FillType
		{
			get
			{
				return FillType.LinearGradient;
			}
			set
			{
			}
		}

		[Obsolete("Shapes now use the IFillable interface instead of inheriting from ShapeRendererFillable", true)]
		public FillSpace FillSpace
		{
			get
			{
				return FillSpace.Local;
			}
			set
			{
			}
		}

		[Obsolete("Shapes now use the IFillable interface instead of inheriting from ShapeRendererFillable", true)]
		public Vector3 FillRadialOrigin
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		[Obsolete("Shapes now use the IFillable interface instead of inheriting from ShapeRendererFillable", true)]
		public float FillRadialRadius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[Obsolete("Shapes now use the IFillable interface instead of inheriting from ShapeRendererFillable", true)]
		public Vector3 FillLinearStart
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		[Obsolete("Shapes now use the IFillable interface instead of inheriting from ShapeRendererFillable", true)]
		public Vector3 FillLinearEnd
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		[Obsolete("Shapes now use the IFillable interface instead of inheriting from ShapeRendererFillable", true)]
		public Color FillColorStart
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		[Obsolete("Shapes now use the IFillable interface instead of inheriting from ShapeRendererFillable", true)]
		public Color FillColorEnd
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		[Obsolete("Shapes now use the IFillable interface instead of inheriting from ShapeRendererFillable", true)]
		private protected void SetFillProperties()
		{
		}
	}
}
