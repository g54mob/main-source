using UnityEngine;

namespace Shapes
{
	public abstract class ShapeRendererFillable : ShapeRenderer
	{
		[SerializeField]
		protected ShapeFill fill = new ShapeFill();

		[SerializeField]
		protected bool useFill;

		protected int FillTypeShaderInt
		{
			get
			{
				if (!useFill)
				{
					return -1;
				}
				return fill.GetShaderFillModeInt();
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
				SetIntNow(ShapesMaterialUtils.propFillType, FillTypeShaderInt);
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
				SetIntNow(ShapesMaterialUtils.propFillType, FillTypeShaderInt);
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

		protected void SetFillProperties()
		{
			if (useFill)
			{
				SetInt(ShapesMaterialUtils.propFillSpace, (int)fill.space);
				SetVector4(ShapesMaterialUtils.propFillStart, fill.GetShaderStartVector());
				SetVector3(ShapesMaterialUtils.propFillEnd, fill.linearEnd);
				SetColor(ShapesMaterialUtils.propColor, fill.colorStart);
				SetColor(ShapesMaterialUtils.propColorEnd, fill.colorEnd);
			}
			SetInt(ShapesMaterialUtils.propFillType, FillTypeShaderInt);
		}
	}
}
