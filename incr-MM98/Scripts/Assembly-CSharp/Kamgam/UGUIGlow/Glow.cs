using System;
using UnityEngine;
using UnityEngine.UI;

namespace Kamgam.UGUIGlow
{
	[ExecuteAlways]
	public class Glow : Graphic
	{
		public static Glow LastSelectedGlowObject;

		[Header("Glow Config")]
		[Tooltip("You can reference a config from an asset. If set then this will override the local config.")]
		[SerializeField]
		protected GlowConfigAsset _configAsset;

		protected GlowConfigAsset _configAssetInstance;

		[SerializeField]
		[ShowIf("_configAsset", null, ShowIfAttribute.DisablingType.ReadOnly, false, null)]
		protected GlowConfig _config;

		[Header("Animation")]
		public bool PreviewAnimation = true;

		private const float WidthDefault = 30f;

		protected float _width = 30f;

		private const float OverlapWidthDefault = 0.2f;

		protected float _overlapWidth = 0.2f;

		private const bool SplitWidthDefault = false;

		protected bool _splitWidth;

		private const float WidthLeftDefault = 30f;

		protected float _widthLeft = 30f;

		private const float WidthTopDefault = 30f;

		protected float _widthTop = 30f;

		private const float WidthRightDefault = 30f;

		protected float _widthRight = 30f;

		private const float WidthBottomDefault = 30f;

		protected float _widthBottom = 30f;

		private static readonly Color InnerColorDefault = new Color(0f, 1f, 1f, 0.5f);

		protected Color _innerColor = InnerColorDefault;

		private static readonly Color OuterColorDefault = new Color(0f, 1f, 1f, 0f);

		protected Color _outerColor = OuterColorDefault;

		private const float OffsetXDefault = 0f;

		protected float _offsetX;

		private const float OffsetYDefault = 0f;

		protected float _offsetY;

		private const bool OffsetEverythingDefault = false;

		protected bool _offsetEverything;

		private const float ScaleXDefault = 1f;

		protected float _scaleX = 1f;

		private const float ScaleYDefault = 1f;

		protected float _scaleY = 1f;

		private const bool ForceSubdivisionDefault = false;

		protected bool _forceSubdivision;

		private const bool PreserveHardCornersDefault = false;

		protected bool _preserveHardCorners;

		private const bool FillCenterDefault = false;

		protected bool _fillCenter;

		private const float VertexDistanceDefault = 15f;

		protected float _vertexDistance = 15f;

		[NonSerialized]
		public IGlowAnimation Animation;

		[NonSerialized]
		public MeshCreator MeshCreator;

		public GlowConfigAsset ConfigAsset
		{
			get
			{
				return _configAsset;
			}
			set
			{
				_configAsset = value;
				ClearConfigAssetInstance();
				SetVerticesDirty();
			}
		}

		public GlowConfig Config
		{
			get
			{
				if (ConfigAsset != null)
				{
					if (_configAssetInstance == null)
					{
						unregisterOnValueChanged(_config);
						_configAssetInstance = UnityEngine.Object.Instantiate(ConfigAsset);
						GlowConfig config = ConfigAsset.Config;
						config.OnValueChanged = (Action)Delegate.Remove(config.OnValueChanged, new Action(onValueChanged));
						GlowConfig config2 = ConfigAsset.Config;
						config2.OnValueChanged = (Action)Delegate.Combine(config2.OnValueChanged, new Action(onValueChanged));
						registerOnValueChanged(_configAssetInstance.Config);
					}
					return _configAssetInstance.Config;
				}
				if (_config == null)
				{
					_config = createGlowConfig();
					registerOnValueChanged(_config);
				}
				return _config;
			}
			set
			{
				if (_config != value)
				{
					unregisterOnValueChanged(_config);
					_config = value;
					registerOnValueChanged(_config);
				}
			}
		}

		public float width
		{
			get
			{
				return _width;
			}
			set
			{
				if (_width != value)
				{
					_width = value;
					Config.Width = _width;
				}
			}
		}

		public float overlapWidth
		{
			get
			{
				return _overlapWidth;
			}
			set
			{
				if (_overlapWidth != value)
				{
					_overlapWidth = value;
					Config.OverlapWidth = _overlapWidth;
				}
			}
		}

		public bool splitWidth
		{
			get
			{
				return _splitWidth;
			}
			set
			{
				if (_splitWidth != value)
				{
					_splitWidth = value;
					Config.SplitWidth = _splitWidth;
				}
			}
		}

		public float widthLeft
		{
			get
			{
				return _widthLeft;
			}
			set
			{
				if (_widthLeft != value)
				{
					_widthLeft = value;
					GlowConfig.DirectionValues widths = Config.Widths;
					widths.Left = _widthLeft;
					Config.Widths = widths;
				}
			}
		}

		public float widthTop
		{
			get
			{
				return _widthTop;
			}
			set
			{
				if (_widthTop != value)
				{
					_widthTop = value;
					GlowConfig.DirectionValues widths = Config.Widths;
					widths.Top = _widthTop;
					Config.Widths = widths;
				}
			}
		}

		public float widthRight
		{
			get
			{
				return _widthRight;
			}
			set
			{
				if (_widthRight != value)
				{
					_widthRight = value;
					GlowConfig.DirectionValues widths = Config.Widths;
					widths.Right = _widthRight;
					Config.Widths = widths;
				}
			}
		}

		public float widthBottom
		{
			get
			{
				return _widthBottom;
			}
			set
			{
				if (_widthBottom != value)
				{
					_widthBottom = value;
					GlowConfig.DirectionValues widths = Config.Widths;
					widths.Bottom = _widthBottom;
					Config.Widths = widths;
				}
			}
		}

		public Color innerColor
		{
			get
			{
				return _innerColor;
			}
			set
			{
				if (!(_innerColor == value))
				{
					_innerColor = value;
					Config.InnerColor = _innerColor;
				}
			}
		}

		public Color outerColor
		{
			get
			{
				return _outerColor;
			}
			set
			{
				if (!(_outerColor == value))
				{
					_outerColor = value;
					Config.OuterColor = _outerColor;
				}
			}
		}

		public float offsetX
		{
			get
			{
				return _offsetX;
			}
			set
			{
				if (_offsetX != value)
				{
					_offsetX = value;
					Vector2 offset = Config.Offset;
					offset.x = _offsetX;
					Config.Offset = offset;
				}
			}
		}

		public float offsetY
		{
			get
			{
				return _offsetY;
			}
			set
			{
				if (_offsetY != value)
				{
					_offsetY = value;
					Vector2 offset = Config.Offset;
					offset.y = _offsetY;
					Config.Offset = offset;
				}
			}
		}

		public bool offsetEverything
		{
			get
			{
				return _offsetEverything;
			}
			set
			{
				if (_offsetEverything != value)
				{
					_offsetEverything = value;
					Config.OffsetEverything = _offsetEverything;
				}
			}
		}

		public float scaleX
		{
			get
			{
				return _scaleX;
			}
			set
			{
				if (_scaleX != value)
				{
					_scaleX = value;
					Vector2 scale = Config.Scale;
					scale.x = _scaleX;
					Config.Scale = scale;
				}
			}
		}

		public float scaleY
		{
			get
			{
				return _scaleY;
			}
			set
			{
				if (_scaleY != value)
				{
					_scaleY = value;
					Vector2 scale = Config.Scale;
					scale.y = _scaleY;
					Config.Scale = scale;
				}
			}
		}

		public bool forceSubdivision
		{
			get
			{
				return _forceSubdivision;
			}
			set
			{
				if (_forceSubdivision != value)
				{
					_forceSubdivision = value;
					Config.ForceSubdivision = _forceSubdivision;
				}
			}
		}

		public bool preserveHardCorners
		{
			get
			{
				return _preserveHardCorners;
			}
			set
			{
				if (_preserveHardCorners != value)
				{
					_preserveHardCorners = value;
					Config.PreserveHardCorners = _preserveHardCorners;
				}
			}
		}

		public bool fillCenter
		{
			get
			{
				return _fillCenter;
			}
			set
			{
				if (_fillCenter != value)
				{
					_fillCenter = value;
					Config.FillCenter = _fillCenter;
				}
			}
		}

		public float vertexDistance
		{
			get
			{
				return _vertexDistance;
			}
			set
			{
				if (_vertexDistance != value)
				{
					value = Mathf.Max(value, 1f);
					_vertexDistance = value;
					Config.VertexDistance = _vertexDistance;
				}
			}
		}

		public void ClearConfigAssetInstance()
		{
			if (!(this == null) && !(base.gameObject == null))
			{
				if (_configAssetInstance != null)
				{
					unregisterOnValueChanged(_configAssetInstance.Config);
				}
				_configAssetInstance = null;
				SetVerticesDirty();
			}
		}

		protected void unregisterOnValueChanged(GlowConfig config)
		{
			if (config != null)
			{
				config.OnValueChanged = (Action)Delegate.Remove(config.OnValueChanged, new Action(onValueChanged));
			}
		}

		protected void registerOnValueChanged(GlowConfig config)
		{
			if (config != null)
			{
				config.OnValueChanged = (Action)Delegate.Combine(config.OnValueChanged, new Action(onValueChanged));
			}
		}

		protected void onValueChanged()
		{
			if (!(this == null) && !(base.gameObject == null))
			{
				if (ConfigAsset != null && _configAssetInstance != null)
				{
					ConfigAsset.Config.CopyValuesTo(_configAssetInstance.Config, copyOnValueChanged: false);
				}
				SetVerticesDirty();
			}
		}

		public T GetAnimation<T>() where T : class, IGlowAnimation
		{
			return (T)Animation;
		}

		public void ClearAnimation()
		{
			if (Animation != null)
			{
				Animation.RemoveFromMeshCreator(MeshCreator);
				Animation = null;
				SetVerticesDirty();
			}
		}

		protected GlowConfig createGlowConfig()
		{
			return new GlowConfig
			{
				Width = width,
				SplitWidth = splitWidth,
				Widths = new GlowConfig.DirectionValues(widthTop, widthRight, widthBottom, widthLeft),
				Scale = new Vector2(scaleX, scaleY),
				Offset = new Vector2(offsetX, offsetY),
				OffsetEverything = offsetEverything,
				InnerColor = innerColor,
				OuterColor = outerColor,
				UseRadialGradients = false,
				InnerColors = null,
				OuterColors = null,
				OverlapWidth = overlapWidth,
				ForceSubdivision = forceSubdivision,
				PreserveHardCorners = preserveHardCorners,
				FillCenter = fillCenter,
				VertexDistance = vertexDistance
			};
		}

		public void Update()
		{
			updateAnimation();
		}

		protected void updateAnimation()
		{
			if (!IsActive())
			{
				return;
			}
			if (Config.AnimationConfig == null)
			{
				ClearAnimation();
				return;
			}
			if (Animation == null && MeshCreator != null && Config.AnimationConfig != null)
			{
				Animation = GlowAnimation.AddAnimationCopyTo(MeshCreator, Config.AnimationConfig.GetAnimation(), linkToTemplate: true);
				Animation?.Play();
			}
			if (Animation != null)
			{
				Animation.Update(Time.deltaTime);
				MeshCreator.MarkDirtyAnimation();
				SetVerticesDirty();
			}
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			if (IsActive())
			{
				if (MeshCreator == null)
				{
					MeshCreator = new MeshCreator();
				}
				MeshCreator.Config = Config;
				Rect rect = ((!(base.transform.parent != null)) ? (base.transform as RectTransform).rect : (base.transform.parent as RectTransform).rect);
				MeshCreator.RectWidth = rect.width;
				MeshCreator.RectHeight = rect.height;
				MeshCreator.CornerRadius = Config.CornerRadius;
				if (Config.SplitCorerRadius)
				{
					MeshCreator.CornerRadiusTopLeft = Config.CornerRadiusBottomLeft;
					MeshCreator.CornerRadiusTopRight = Config.CornerRadiusBottomRight;
					MeshCreator.CornerRadiusBottomLeft = Config.CornerRadiusTopLeft;
					MeshCreator.CornerRadiusBottomRight = Config.CornerRadiusTopRight;
				}
				else
				{
					MeshCreator.CornerRadiusTopLeft = null;
					MeshCreator.CornerRadiusTopRight = null;
					MeshCreator.CornerRadiusBottomLeft = null;
					MeshCreator.CornerRadiusBottomRight = null;
				}
				MeshCreator.ModifyMesh(vh);
			}
		}

		protected void Reset()
		{
			raycastTarget = false;
		}
	}
}
