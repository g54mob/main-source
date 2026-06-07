using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.MPUIKIT;

namespace MPUIKIT
{
	[AddComponentMenu("UI/MPUI/MPImage")]
	public class MPImage : Image
	{
		public const string MpShaderName = "MPUI/Procedural Image";

		[SerializeField]
		private DrawShape m_DrawShape;

		[SerializeField]
		private Type m_ImageType;

		[SerializeField]
		private MaterialMode m_MaterialMode;

		[SerializeField]
		private float m_StrokeWidth;

		[SerializeField]
		private float m_OutlineWidth;

		[SerializeField]
		private Color m_OutlineColor;

		[SerializeField]
		private float m_FalloffDistance = 0.5f;

		[SerializeField]
		private bool m_ConstrainRotation = true;

		[SerializeField]
		private float m_ShapeRotation;

		[SerializeField]
		private bool m_FlipHorizontal;

		[SerializeField]
		private bool m_FlipVertical;

		[SerializeField]
		private Triangle m_Triangle;

		[SerializeField]
		private Rectangle m_Rectangle;

		[SerializeField]
		private Circle m_Circle;

		[SerializeField]
		private Pentagon m_Pentagon;

		[SerializeField]
		private Hexagon m_Hexagon;

		[SerializeField]
		private NStarPolygon m_NStarPolygon;

		[SerializeField]
		private GradientEffect m_GradientEffect;

		private Material _dynamicMaterial;

		private static readonly int SpPixelWorldScale = Shader.PropertyToID("_PixelWorldScale");

		private static readonly int SpDrawShape = Shader.PropertyToID("_DrawShape");

		private static readonly int SpStrokeWidth = Shader.PropertyToID("_StrokeWidth");

		private static readonly int SpOutlineWidth = Shader.PropertyToID("_OutlineWidth");

		private static readonly int SpOutlineColor = Shader.PropertyToID("_OutlineColor");

		private static readonly int SpFalloffDistance = Shader.PropertyToID("_FalloffDistance");

		private static readonly int SpShapeRotation = Shader.PropertyToID("_ShapeRotation");

		private static readonly int SpConstrainedRotation = Shader.PropertyToID("_ConstrainRotation");

		private static readonly int SpFlipHorizontal = Shader.PropertyToID("_FlipHorizontal");

		private static readonly int SpFlipVertical = Shader.PropertyToID("_FlipVertical");

		public DrawShape DrawShape
		{
			get
			{
				return m_DrawShape;
			}
			set
			{
				m_DrawShape = value;
				if (material == m_Material)
				{
					m_Material.SetInt(SpDrawShape, (int)m_DrawShape);
				}
				base.SetMaterialDirty();
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
				m_StrokeWidth = value;
				m_StrokeWidth = ((m_StrokeWidth < 0f) ? 0f : m_StrokeWidth);
				if (material == m_Material)
				{
					m_Material.SetFloat(SpStrokeWidth, m_StrokeWidth);
				}
				base.SetMaterialDirty();
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
				m_OutlineWidth = value;
				m_OutlineWidth = ((m_OutlineWidth < 0f) ? 0f : m_OutlineWidth);
				if (m_Material == material)
				{
					m_Material.SetFloat(SpOutlineWidth, m_OutlineWidth);
				}
				base.SetMaterialDirty();
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
				if (m_Material == material)
				{
					m_Material.SetColor(SpOutlineColor, m_OutlineColor);
				}
				base.SetMaterialDirty();
			}
		}

		public float FalloffDistance
		{
			get
			{
				return m_FalloffDistance;
			}
			set
			{
				m_FalloffDistance = Mathf.Max(value, 0f);
				if (material == m_Material)
				{
					m_Material.SetFloat(SpFalloffDistance, m_FalloffDistance);
				}
				base.SetMaterialDirty();
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
				if (m_Material == material)
				{
					m_Material.SetInt(SpConstrainedRotation, value ? 1 : 0);
				}
				if (value)
				{
					m_ShapeRotation = ConstrainRotationValue(m_ShapeRotation);
				}
				base.SetVerticesDirty();
				base.SetMaterialDirty();
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
				m_ShapeRotation = (m_ConstrainRotation ? ConstrainRotationValue(value) : value);
				if (m_Material == material)
				{
					m_Material.SetFloat(SpShapeRotation, m_ShapeRotation);
				}
				base.SetMaterialDirty();
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
				if (m_Material == material)
				{
					m_Material.SetInt(SpFlipHorizontal, m_FlipHorizontal ? 1 : 0);
				}
				base.SetMaterialDirty();
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
				if (m_Material == material)
				{
					m_Material.SetInt(SpFlipVertical, m_FlipVertical ? 1 : 0);
				}
				base.SetMaterialDirty();
			}
		}

		public MaterialMode MaterialMode
		{
			get
			{
				return m_MaterialMode;
			}
			set
			{
				if (m_MaterialMode != value)
				{
					m_MaterialMode = value;
					InitializeComponents();
					if (material == m_Material)
					{
						InitValuesFromSharedMaterial();
					}
					base.SetMaterialDirty();
				}
			}
		}

		public override Material material
		{
			get
			{
				if ((bool)m_Material && m_MaterialMode == MaterialMode.Shared)
				{
					return m_Material;
				}
				return DynamicMaterial;
			}
			set
			{
				m_Material = value;
				if ((bool)m_Material && m_MaterialMode == MaterialMode.Shared && m_Material.shader.name == "MPUI/Procedural Image")
				{
					InitValuesFromSharedMaterial();
				}
				InitializeComponents();
				base.SetMaterialDirty();
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
						m_ImageType = value;
						break;
					default:
						throw new ArgumentOutOfRangeException(value.ToString(), value, null);
					case Type.Sliced:
					case Type.Tiled:
						break;
					}
					base.type = m_ImageType;
				}
			}
		}

		public Triangle Triangle
		{
			get
			{
				return m_Triangle;
			}
			set
			{
				m_Triangle = value;
				SetMaterialDirty();
			}
		}

		public Rectangle Rectangle
		{
			get
			{
				return m_Rectangle;
			}
			set
			{
				m_Rectangle = value;
				SetMaterialDirty();
			}
		}

		public Circle Circle
		{
			get
			{
				return m_Circle;
			}
			set
			{
				m_Circle = value;
				SetMaterialDirty();
			}
		}

		public Pentagon Pentagon
		{
			get
			{
				return m_Pentagon;
			}
			set
			{
				m_Pentagon = value;
				SetMaterialDirty();
			}
		}

		public Hexagon Hexagon
		{
			get
			{
				return m_Hexagon;
			}
			set
			{
				m_Hexagon = value;
				SetMaterialDirty();
			}
		}

		public NStarPolygon NStarPolygon
		{
			get
			{
				return m_NStarPolygon;
			}
			set
			{
				m_NStarPolygon = value;
				SetMaterialDirty();
			}
		}

		public GradientEffect GradientEffect
		{
			get
			{
				return m_GradientEffect;
			}
			set
			{
				m_GradientEffect = value;
				SetMaterialDirty();
			}
		}

		private Material DynamicMaterial
		{
			get
			{
				if (_dynamicMaterial == null)
				{
					_dynamicMaterial = new Material(Shader.Find("MPUI/Procedural Image"));
					_dynamicMaterial.name += " [Dynamic]";
				}
				return _dynamicMaterial;
			}
		}

		private Sprite ActiveSprite
		{
			get
			{
				Sprite sprite = base.overrideSprite;
				if (!(sprite != null))
				{
					return base.sprite;
				}
				return sprite;
			}
		}

		private float ConstrainRotationValue(float val)
		{
			float num = val - val % 90f;
			if (Mathf.Abs(num) >= 360f)
			{
				num = 0f;
			}
			return num;
		}

		private void InitializeComponents()
		{
			m_Circle.Init(m_Material, material, base.rectTransform);
			m_Triangle.Init(m_Material, material, base.rectTransform);
			m_Rectangle.Init(m_Material, material, base.rectTransform);
			m_Pentagon.Init(m_Material, material, base.rectTransform);
			m_Hexagon.Init(m_Material, material, base.rectTransform);
			m_NStarPolygon.Init(m_Material, material, base.rectTransform);
			m_GradientEffect.Init(m_Material, material, base.rectTransform);
		}

		private void FixAdditionalShaderChannelsInCanvas()
		{
			Canvas canvas = base.canvas;
			if (!(base.canvas == null))
			{
				AdditionalCanvasShaderChannels additionalShaderChannels = canvas.additionalShaderChannels;
				additionalShaderChannels |= AdditionalCanvasShaderChannels.TexCoord1;
				additionalShaderChannels |= AdditionalCanvasShaderChannels.TexCoord2;
				canvas.additionalShaderChannels = additionalShaderChannels;
			}
		}

		private void Reset()
		{
			InitializeComponents();
		}

		protected override void Awake()
		{
			base.Awake();
			Init();
		}

		protected void Init()
		{
			InitializeComponents();
			FixAdditionalShaderChannelsInCanvas();
			if ((bool)m_Material && MaterialMode == MaterialMode.Shared)
			{
				InitValuesFromSharedMaterial();
			}
			ListenToComponentChanges(toggle: true);
			base.SetAllDirty();
		}

		protected override void OnDestroy()
		{
			ListenToComponentChanges(toggle: false);
			base.OnDestroy();
		}

		protected void ListenToComponentChanges(bool toggle)
		{
			if (toggle)
			{
				m_Circle.OnComponentSettingsChanged += OnComponentSettingsChanged;
				m_Triangle.OnComponentSettingsChanged += OnComponentSettingsChanged;
				m_Rectangle.OnComponentSettingsChanged += OnComponentSettingsChanged;
				m_Pentagon.OnComponentSettingsChanged += OnComponentSettingsChanged;
				m_Hexagon.OnComponentSettingsChanged += OnComponentSettingsChanged;
				m_NStarPolygon.OnComponentSettingsChanged += OnComponentSettingsChanged;
				m_GradientEffect.OnComponentSettingsChanged += OnComponentSettingsChanged;
			}
			else
			{
				m_Circle.OnComponentSettingsChanged -= OnComponentSettingsChanged;
				m_Triangle.OnComponentSettingsChanged -= OnComponentSettingsChanged;
				m_Rectangle.OnComponentSettingsChanged -= OnComponentSettingsChanged;
				m_Pentagon.OnComponentSettingsChanged -= OnComponentSettingsChanged;
				m_Hexagon.OnComponentSettingsChanged -= OnComponentSettingsChanged;
				m_NStarPolygon.OnComponentSettingsChanged -= OnComponentSettingsChanged;
				m_GradientEffect.OnComponentSettingsChanged += OnComponentSettingsChanged;
			}
		}

		protected override void OnTransformParentChanged()
		{
			base.OnTransformParentChanged();
			FixAdditionalShaderChannelsInCanvas();
		}

		private void OnComponentSettingsChanged(object sender, EventArgs e)
		{
			base.SetMaterialDirty();
		}

		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			m_Circle.UpdateCircleRadius(base.rectTransform);
			base.SetMaterialDirty();
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			switch (type)
			{
			case Type.Simple:
			case Type.Sliced:
			case Type.Tiled:
				MPImageHelper.GenerateSimpleSprite(vh, base.preserveAspect, base.canvas, base.rectTransform, ActiveSprite, color, m_FalloffDistance);
				break;
			case Type.Filled:
				MPImageHelper.GenerateFilledSprite(vh, base.preserveAspect, base.canvas, base.rectTransform, ActiveSprite, color, base.fillMethod, base.fillAmount, base.fillOrigin, base.fillClockwise, m_FalloffDistance);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		public override Material GetModifiedMaterial(Material baseMaterial)
		{
			Material modifiedMaterial = base.GetModifiedMaterial(baseMaterial);
			if ((bool)m_Material && MaterialMode == MaterialMode.Shared)
			{
				InitValuesFromSharedMaterial();
			}
			DisableAllMaterialKeywords(modifiedMaterial);
			_ = base.rectTransform;
			if (DrawShape != DrawShape.None)
			{
				modifiedMaterial.SetFloat(SpOutlineWidth, m_OutlineWidth);
				modifiedMaterial.SetFloat(SpStrokeWidth, m_StrokeWidth);
				modifiedMaterial.SetColor(SpOutlineColor, OutlineColor);
				modifiedMaterial.SetFloat(SpFalloffDistance, FalloffDistance);
				float value = 1f / Mathf.Max(0f, FalloffDistance);
				modifiedMaterial.SetFloat(SpPixelWorldScale, Mathf.Clamp(value, 0f, 999999f));
				if (m_StrokeWidth > 0f && m_OutlineWidth > 0f)
				{
					modifiedMaterial.EnableKeyword("OUTLINED_STROKE");
				}
				else if (m_StrokeWidth > 0f)
				{
					modifiedMaterial.EnableKeyword("STROKE");
				}
				else if (m_OutlineWidth > 0f)
				{
					modifiedMaterial.EnableKeyword("OUTLINED");
				}
				else
				{
					modifiedMaterial.DisableKeyword("OUTLINED_STROKE");
					modifiedMaterial.DisableKeyword("STROKE");
					modifiedMaterial.DisableKeyword("OUTLINED");
				}
			}
			m_Triangle.ModifyMaterial(ref modifiedMaterial);
			m_Circle.ModifyMaterial(ref modifiedMaterial, m_FalloffDistance);
			m_Rectangle.ModifyMaterial(ref modifiedMaterial);
			m_Pentagon.ModifyMaterial(ref modifiedMaterial);
			m_Hexagon.ModifyMaterial(ref modifiedMaterial);
			m_NStarPolygon.ModifyMaterial(ref modifiedMaterial);
			m_GradientEffect.ModifyMaterial(ref modifiedMaterial);
			switch (DrawShape)
			{
			case DrawShape.None:
				modifiedMaterial.DisableKeyword("CIRCLE");
				modifiedMaterial.DisableKeyword("TRIANGLE");
				modifiedMaterial.DisableKeyword("RECTANGLE");
				modifiedMaterial.DisableKeyword("PENTAGON");
				modifiedMaterial.DisableKeyword("HEXAGON");
				modifiedMaterial.DisableKeyword("NSTAR_POLYGON");
				break;
			case DrawShape.Circle:
				modifiedMaterial.EnableKeyword("CIRCLE");
				break;
			case DrawShape.Triangle:
				modifiedMaterial.EnableKeyword("TRIANGLE");
				break;
			case DrawShape.Rectangle:
				modifiedMaterial.EnableKeyword("RECTANGLE");
				break;
			case DrawShape.Pentagon:
				modifiedMaterial.EnableKeyword("PENTAGON");
				break;
			case DrawShape.NStarPolygon:
				modifiedMaterial.EnableKeyword("NSTAR_POLYGON");
				break;
			case DrawShape.Hexagon:
				modifiedMaterial.EnableKeyword("HEXAGON");
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			modifiedMaterial.SetInt(SpDrawShape, (int)DrawShape);
			modifiedMaterial.SetInt(SpFlipHorizontal, m_FlipHorizontal ? 1 : 0);
			modifiedMaterial.SetInt(SpFlipVertical, m_FlipVertical ? 1 : 0);
			modifiedMaterial.SetFloat(SpShapeRotation, m_ShapeRotation);
			modifiedMaterial.SetInt(SpConstrainedRotation, m_ConstrainRotation ? 1 : 0);
			return modifiedMaterial;
		}

		private void DisableAllMaterialKeywords(Material mat)
		{
			mat.DisableKeyword("PROCEDURAL");
			mat.DisableKeyword("HYBRID");
			mat.DisableKeyword("CIRCLE");
			mat.DisableKeyword("TRIANGLE");
			mat.DisableKeyword("RECTANGLE");
			mat.DisableKeyword("PENTAGON");
			mat.DisableKeyword("HEXAGON");
			mat.DisableKeyword("NSTAR_POLYGON");
			mat.DisableKeyword("STROKE");
			mat.DisableKeyword("OUTLINED");
			mat.DisableKeyword("OUTLINED_STROKE");
			mat.DisableKeyword("ROUNDED_CORNERS");
			mat.DisableKeyword("GRADIENT_LINEAR");
			mat.DisableKeyword("GRADIENT_CORNER");
			mat.DisableKeyword("GRADIENT_RADIAL");
		}

		public void InitValuesFromSharedMaterial()
		{
			if (!(m_Material == null))
			{
				Material material = m_Material;
				m_DrawShape = (DrawShape)material.GetInt(SpDrawShape);
				m_StrokeWidth = material.GetFloat(SpStrokeWidth);
				m_FalloffDistance = material.GetFloat(SpFalloffDistance);
				m_OutlineWidth = material.GetFloat(SpOutlineWidth);
				m_OutlineColor = material.GetColor(SpOutlineColor);
				m_FlipHorizontal = material.GetInt(SpFlipHorizontal) == 1;
				m_FlipVertical = material.GetInt(SpFlipVertical) == 1;
				m_ConstrainRotation = material.GetInt(SpConstrainedRotation) == 1;
				m_ShapeRotation = material.GetFloat(SpShapeRotation);
				m_Triangle.InitValuesFromMaterial(ref material);
				m_Circle.InitValuesFromMaterial(ref material);
				m_Rectangle.InitValuesFromMaterial(ref material);
				m_Pentagon.InitValuesFromMaterial(ref material);
				m_Hexagon.InitValuesFromMaterial(ref material);
				m_NStarPolygon.InitValuesFromMaterial(ref material);
				m_GradientEffect.InitValuesFromMaterial(ref material);
			}
		}
	}
}
