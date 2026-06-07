using System;
using UnityEngine;
using UnityEngine.UI;

namespace MPUIKIT
{
	[AddComponentMenu("UI/MPUI/MPImageBasic")]
	public class MPImageBasic : Image
	{
		[SerializeField]
		private DrawShape m_DrawShape;

		[SerializeField]
		private Type m_ImageType;

		[SerializeField]
		private float m_StrokeWidth;

		[SerializeField]
		private float m_FalloffDistance = 0.5f;

		[SerializeField]
		private float m_OutlineWidth;

		[SerializeField]
		private Color m_OutlineColor = Color.black;

		[SerializeField]
		private float m_ShapeRotation;

		[SerializeField]
		private bool m_ConstrainRotation = true;

		[SerializeField]
		private bool m_FlipHorizontal;

		[SerializeField]
		private bool m_FlipVertical;

		[SerializeField]
		private CornerStyleType m_CornerStyle;

		[SerializeField]
		private Vector4 m_RectangleCornerRadius;

		[SerializeField]
		private Vector3 m_TriangleCornerRadius;

		[SerializeField]
		private bool m_TriangleUniformCornerRadius = true;

		[SerializeField]
		private bool m_RectangleUniformCornerRadius = true;

		[SerializeField]
		private float m_CircleRadius;

		[SerializeField]
		private bool m_CircleFitToRect = true;

		[SerializeField]
		private int m_NStarPolygonSideCount = 3;

		[SerializeField]
		private float m_NStarPolygonInset = 2f;

		[SerializeField]
		private float m_NStarPolygonCornerRadius;

		public DrawShape Shape
		{
			get
			{
				return m_DrawShape;
			}
			set
			{
				m_DrawShape = value;
				m_Material = null;
				base.SetMaterialDirty();
				base.SetVerticesDirty();
			}
		}

		public float StrokeWidth
		{
			get
			{
				return m_StrokeWidth;
			}
			set
			{
				Vector2 size = GetPixelAdjustedRect().size;
				m_StrokeWidth = Mathf.Clamp(value, 0f, Mathf.Min(size.x, size.y) * 0.5f);
				base.SetVerticesDirty();
			}
		}

		public float FallOffDistance
		{
			get
			{
				return m_FalloffDistance;
			}
			set
			{
				m_FalloffDistance = Mathf.Max(0f, value);
				base.SetVerticesDirty();
			}
		}

		public float OutlineWidth
		{
			get
			{
				return m_OutlineWidth;
			}
			set
			{
				m_OutlineWidth = Mathf.Max(0f, value);
				base.SetVerticesDirty();
			}
		}

		public Color OutlineColor
		{
			get
			{
				return m_OutlineColor;
			}
			set
			{
				m_OutlineColor = value;
				base.SetVerticesDirty();
			}
		}

		public float ShapeRotation
		{
			get
			{
				return m_ShapeRotation;
			}
			set
			{
				m_ShapeRotation = value % 360f;
				ConstrainRotationValue();
				base.SetVerticesDirty();
			}
		}

		public bool ConstrainRotation
		{
			get
			{
				return m_ConstrainRotation;
			}
			set
			{
				m_ConstrainRotation = value;
				ConstrainRotationValue();
				base.SetVerticesDirty();
			}
		}

		public bool FlipHorizontal
		{
			get
			{
				return m_FlipHorizontal;
			}
			set
			{
				m_FlipHorizontal = value;
				base.SetVerticesDirty();
			}
		}

		public bool FlipVertical
		{
			get
			{
				return m_FlipVertical;
			}
			set
			{
				m_FlipVertical = value;
				base.SetVerticesDirty();
			}
		}

		public new Type type
		{
			get
			{
				return m_ImageType;
			}
			set
			{
				if (m_ImageType != value)
				{
					switch (value)
					{
					case Type.Simple:
					case Type.Filled:
						if ((bool)base.sprite)
						{
							m_ImageType = value;
						}
						break;
					default:
						throw new ArgumentOutOfRangeException(value.ToString(), value, null);
					case Type.Sliced:
					case Type.Tiled:
						break;
					}
				}
				if (base.type != m_ImageType)
				{
					base.type = m_ImageType;
				}
				base.SetAllDirty();
			}
		}

		public CornerStyleType CornerStyle
		{
			get
			{
				return m_CornerStyle;
			}
			set
			{
				m_CornerStyle = value;
				base.SetVerticesDirty();
			}
		}

		public Vector3 TriangleCornerRadius
		{
			get
			{
				return m_TriangleCornerRadius;
			}
			set
			{
				Vector2 size = GetPixelAdjustedRect().size;
				float max = size.x * 0.5f;
				m_TriangleCornerRadius.z = Mathf.Clamp(value.z, 0f, max);
				float max2 = Mathf.Min(size.x, size.y) * 0.3f;
				m_TriangleCornerRadius.x = Mathf.Clamp(value.x, 0f, max2);
				m_TriangleCornerRadius.y = Mathf.Clamp(value.y, 0f, max2);
				base.SetVerticesDirty();
			}
		}

		public Vector4 RectangleCornerRadius
		{
			get
			{
				return m_RectangleCornerRadius;
			}
			set
			{
				m_RectangleCornerRadius = value;
				base.SetVerticesDirty();
			}
		}

		public float CircleRadius
		{
			get
			{
				return m_CircleRadius;
			}
			set
			{
				m_CircleRadius = Mathf.Clamp(value, 0f, GetMinSize());
				base.SetVerticesDirty();
			}
		}

		public bool CircleFitToRect
		{
			get
			{
				return m_CircleFitToRect;
			}
			set
			{
				m_CircleFitToRect = value;
				base.SetVerticesDirty();
			}
		}

		public float NStarPolygonCornerRadius
		{
			get
			{
				return m_NStarPolygonCornerRadius;
			}
			set
			{
				float max = GetPixelAdjustedRect().height * 0.5f;
				m_NStarPolygonCornerRadius = Mathf.Clamp(value, (m_NStarPolygonSideCount == 2) ? 0.1f : 0f, max);
				base.SetVerticesDirty();
			}
		}

		public float NStarPolygonInset
		{
			get
			{
				return m_NStarPolygonInset;
			}
			set
			{
				m_NStarPolygonInset = Mathf.Clamp(value, 2f, m_NStarPolygonSideCount);
				base.SetVerticesDirty();
			}
		}

		public int NStarPolygonSideCount
		{
			get
			{
				return m_NStarPolygonSideCount;
			}
			set
			{
				m_NStarPolygonSideCount = Mathf.Clamp(value, 2, 10);
				base.SetVerticesDirty();
			}
		}

		public override Material material
		{
			get
			{
				switch (m_DrawShape)
				{
				case DrawShape.None:
					return Canvas.GetDefaultCanvasMaterial();
				case DrawShape.Circle:
				case DrawShape.Triangle:
				case DrawShape.Rectangle:
					return MPMaterials.GetMaterial((int)(m_DrawShape - 1), m_StrokeWidth > 0f, m_OutlineWidth > 0f);
				case DrawShape.Pentagon:
				case DrawShape.Hexagon:
				case DrawShape.NStarPolygon:
					return MPMaterials.GetMaterial(3, m_StrokeWidth > 0f, m_OutlineWidth > 0f);
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
			set
			{
				Debug.LogWarning("Setting Material of MPImageBasic has no effect.");
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			MPImageUtility.FixAdditionalShaderChannelsInCanvas(base.canvas);
			if (base.sprite == null)
			{
				base.sprite = MPImageUtility.EmptySprite;
			}
		}

		private float GetMinSizeHalf()
		{
			return GetMinSize() * 0.5f;
		}

		private float GetMinSize()
		{
			Vector2 size = GetPixelAdjustedRect().size;
			return Mathf.Min(size.x, size.y);
		}

		private void ConstrainRotationValue()
		{
			if (m_ConstrainRotation)
			{
				float num = m_ShapeRotation - m_ShapeRotation % 90f;
				if (Mathf.Abs(num) >= 360f)
				{
					num = 0f;
				}
				m_ShapeRotation = num;
			}
		}

		protected override void OnTransformParentChanged()
		{
			base.OnTransformParentChanged();
			MPImageUtility.FixAdditionalShaderChannelsInCanvas(base.canvas);
			base.SetVerticesDirty();
		}

		private MPVertexStream CreateVertexStream()
		{
			MPVertexStream result = default(MPVertexStream);
			RectTransform rectTransform = base.rectTransform;
			result.RectTransform = rectTransform;
			Rect pixelAdjustedRect = GetPixelAdjustedRect();
			result.Uv1 = new Vector2(pixelAdjustedRect.width + m_FalloffDistance, pixelAdjustedRect.height + m_FalloffDistance);
			float x = PackRotationData(m_ShapeRotation, m_ConstrainRotation, m_FlipHorizontal, m_FlipVertical);
			result.Uv3 = new Vector2(x, (float)m_CornerStyle);
			result.Tangent = ((QualitySettings.activeColorSpace == ColorSpace.Linear) ? m_OutlineColor.linear : m_OutlineColor);
			Vector3 normal = new Vector3
			{
				x = m_OutlineWidth,
				y = m_StrokeWidth,
				z = m_FalloffDistance
			};
			Vector2 uv = m_DrawShape switch
			{
				DrawShape.Circle => new Vector2(m_CircleRadius, m_CircleFitToRect ? 1 : 0), 
				DrawShape.Triangle => MPImageUtility.Encode_0_1_16((Vector4)m_TriangleCornerRadius / Mathf.Min(pixelAdjustedRect.width, pixelAdjustedRect.height)), 
				DrawShape.Rectangle => MPImageUtility.Encode_0_1_16(FixRadius(m_RectangleCornerRadius) / Mathf.Min(pixelAdjustedRect.width, pixelAdjustedRect.height)), 
				DrawShape.NStarPolygon => MPImageUtility.Encode_0_1_16(new Vector4(m_NStarPolygonSideCount, m_NStarPolygonCornerRadius, m_NStarPolygonInset) / Mathf.Min(pixelAdjustedRect.width, pixelAdjustedRect.height)), 
				_ => Vector2.zero, 
			};
			result.Uv2 = uv;
			result.Normal = normal;
			return result;
		}

		private float PackRotationData(float rotation, bool constrainRotation, bool flipH, bool flipV)
		{
			int num = (constrainRotation ? 1 : 0);
			num += (flipH ? 10 : 0);
			num += (flipV ? 100 : 0);
			float num2 = rotation % 360f;
			float num3 = ((num2 >= 0f) ? 1 : (-1));
			return (Mathf.Abs(num2) / 360f + (float)num) * num3;
		}

		private void UnPackRotation(float f)
		{
			float num = ((f >= 0f) ? 1 : (-1));
			f = Mathf.Abs(f);
			fract(f);
			f = Mathf.Floor(f);
			float num2 = f / 100f;
			Mathf.Floor(num2);
			float num3 = fract(num2) * 10f;
			Mathf.Floor(num3);
			Mathf.Round(fract(num3) * 10f);
			static float fract(float val)
			{
				val = Mathf.Abs(val);
				return val - Mathf.Floor(val);
			}
		}

		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			base.SetVerticesDirty();
		}

		private Vector4 FixRadius(Vector4 radius)
		{
			Rect rect = base.rectTransform.rect;
			radius = Vector4.Max(radius, Vector4.zero);
			radius = Vector4.Min(radius, Vector4.one * Mathf.Min(rect.width, rect.height));
			float num = Mathf.Min(Mathf.Min(Mathf.Min(Mathf.Min(rect.width / (radius.x + radius.y), rect.width / (radius.z + radius.w)), rect.height / (radius.x + radius.w)), rect.height / (radius.z + radius.y)), 1f);
			return radius * num;
		}

		protected override void OnPopulateMesh(VertexHelper toFill)
		{
			base.OnPopulateMesh(toFill);
			MPVertexStream mPVertexStream = CreateVertexStream();
			UIVertex vertex = default(UIVertex);
			for (int i = 0; i < toFill.currentVertCount; i++)
			{
				toFill.PopulateUIVertex(ref vertex, i);
				vertex.uv1 = mPVertexStream.Uv1;
				vertex.uv2 = mPVertexStream.Uv2;
				vertex.uv3 = mPVertexStream.Uv3;
				vertex.normal = mPVertexStream.Normal;
				vertex.tangent = mPVertexStream.Tangent;
				toFill.SetUIVertex(vertex, i);
			}
		}

		private void Reset()
		{
			if (base.sprite == null)
			{
				base.sprite = MPImageUtility.EmptySprite;
			}
		}
	}
}
