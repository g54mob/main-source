using System;
using UnityEngine;

namespace Kamgam.UGUIGlow
{
	[Serializable]
	public class GlowConfig
	{
		[Serializable]
		public struct DirectionValues
		{
			public float Top;

			public float Right;

			public float Bottom;

			public float Left;

			public DirectionValues(float top, float right, float bottom, float left)
			{
				Top = top;
				Right = right;
				Bottom = bottom;
				Left = left;
			}

			public bool Equals(DirectionValues other)
			{
				if (Mathf.Approximately(Top, other.Top) && Mathf.Approximately(Right, other.Right) && Mathf.Approximately(Bottom, other.Bottom))
				{
					return Mathf.Approximately(Left, other.Left);
				}
				return false;
			}
		}

		[NonSerialized]
		public Action OnValueChanged;

		[Header("Width")]
		[SerializeField]
		[ShowIf("_splitWidth", false, ShowIfAttribute.DisablingType.ReadOnly, false, null)]
		[Tooltip("Width of pixels outwards.")]
		protected float _width;

		[SerializeField]
		protected bool _splitWidth;

		[SerializeField]
		[ShowIf("_splitWidth", true, ShowIfAttribute.DisablingType.DontDraw, false, null)]
		protected DirectionValues _widths;

		[SerializeField]
		[Tooltip("Overlap defines how much the outline will overlap on the inside.\nAn overlap of 0.2 is recommended to make up for float inacurracies and the (still) missing anti aliasing.")]
		protected float _overlapWidth = 0.2f;

		[Header("Corners")]
		[ShowIf("SplitCorerRadius", false, ShowIfAttribute.DisablingType.ReadOnly, false, null)]
		[Min(0f)]
		public float CornerRadius;

		public bool SplitCorerRadius;

		[ShowIf("SplitCorerRadius", true, ShowIfAttribute.DisablingType.DontDraw, false, null)]
		[Min(0f)]
		public float CornerRadiusTopLeft;

		[ShowIf("SplitCorerRadius", true, ShowIfAttribute.DisablingType.DontDraw, false, null)]
		[Min(0f)]
		public float CornerRadiusTopRight;

		[ShowIf("SplitCorerRadius", true, ShowIfAttribute.DisablingType.DontDraw, false, null)]
		[Min(0f)]
		public float CornerRadiusBottomLeft;

		[ShowIf("SplitCorerRadius", true, ShowIfAttribute.DisablingType.DontDraw, false, null)]
		[Min(0f)]
		public float CornerRadiusBottomRight;

		[Header("Scale")]
		[SerializeField]
		[Tooltip("Useful for shadows. Scales the effect.")]
		protected Vector2 _scale = Vector2.one;

		[Header("Colors")]
		[SerializeField]
		[Tooltip("If enabled then you can specify color gradients. They are wound around the element in clock-wise direction, starting top left.")]
		protected bool _useRadialGradients;

		[ShowIf("_useRadialGradients", false, ShowIfAttribute.DisablingType.DontDraw, false, null)]
		[Tooltip("Shadow start color at the closes points to the element.")]
		[SerializeField]
		protected Color _innerColor = new Color(0f, 0f, 0f, 0.3f);

		[ShowIf("_useRadialGradients", false, ShowIfAttribute.DisablingType.DontDraw, false, null)]
		[Tooltip("Shadow end color at the fartest points.")]
		[SerializeField]
		protected Color _outerColor = new Color(0f, 0f, 0f, 0f);

		[SerializeField]
		[ShowIf("_useRadialGradients", true, ShowIfAttribute.DisablingType.DontDraw, false, null)]
		protected Gradient _innerColors;

		[ShowIf("_useRadialGradients", true, ShowIfAttribute.DisablingType.DontDraw, false, null)]
		[SerializeField]
		protected Gradient _outerColors;

		[Header("Offset")]
		[SerializeField]
		protected Vector2 _offset;

		[SerializeField]
		[Tooltip("Should the offset affect every vertex of the glow mesh or only the outer ones?\nFor glow you usually want to keep this turned OFF while for shadows you may want to turn this ON.")]
		protected bool _offsetEverything;

		[Header("Advanced Settings")]
		[SerializeField]
		[Tooltip("Force a uniform distance between vertices. Useful to smooth animations.\nThis is always ON if UseRadialGradients is enabled.")]
		protected bool _forceSudvision;

		[SerializeField]
		[Tooltip("Should hard corners be kept hard or should they be rounded off as the glow extends outwards?")]
		protected bool _preserveHardCorners;

		[SerializeField]
		[Tooltip("Fills the center with inner color triangles. Useful for shadow generation.")]
		protected bool _fillCenter;

		[SerializeField]
		[Range(10f, 300f)]
		public float _vertexDistance = 15f;

		[Header("Animation")]
		public GlowAnimationAsset AnimationConfig;

		public float Width
		{
			get
			{
				return _width;
			}
			set
			{
				if (!Mathf.Approximately(value, _width))
				{
					_width = value;
					TriggerValueChanged();
				}
			}
		}

		public bool SplitWidth
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
					TriggerValueChanged();
				}
			}
		}

		public DirectionValues Widths
		{
			get
			{
				return _widths;
			}
			set
			{
				if (!value.Equals(_widths))
				{
					_widths = value;
				}
			}
		}

		public float OverlapWidth
		{
			get
			{
				return _overlapWidth;
			}
			set
			{
				if (!Mathf.Approximately(_overlapWidth, value))
				{
					_overlapWidth = value;
					TriggerValueChanged();
				}
			}
		}

		public Vector2 Scale
		{
			get
			{
				return _scale;
			}
			set
			{
				if (!(_scale == value))
				{
					_scale = value;
					TriggerValueChanged();
				}
			}
		}

		public bool UseRadialGradients
		{
			get
			{
				return _useRadialGradients;
			}
			set
			{
				if (_useRadialGradients != value)
				{
					_useRadialGradients = value;
					TriggerValueChanged();
				}
			}
		}

		public Color InnerColor
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
					TriggerValueChanged();
				}
			}
		}

		public Color OuterColor
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
					TriggerValueChanged();
				}
			}
		}

		public Color Color
		{
			get
			{
				return _innerColor;
			}
			set
			{
				if (!(_innerColor == value) || !(_outerColor == value))
				{
					InnerColor = value;
					OuterColor = value;
				}
			}
		}

		public Gradient InnerColors
		{
			get
			{
				return _innerColors;
			}
			set
			{
				if (_innerColors != value)
				{
					_innerColors = value;
					TriggerValueChanged();
				}
			}
		}

		public Gradient OuterColors
		{
			get
			{
				return _outerColors;
			}
			set
			{
				if (_outerColors != value)
				{
					_outerColors = value;
					TriggerValueChanged();
				}
			}
		}

		public Vector2 Offset
		{
			get
			{
				return _offset;
			}
			set
			{
				if (!(_offset == value))
				{
					_offset = value;
				}
			}
		}

		public bool OffsetEverything
		{
			get
			{
				return _offsetEverything;
			}
			set
			{
				if (value != _offsetEverything)
				{
					_offsetEverything = value;
				}
			}
		}

		public bool ForceSubdivision
		{
			get
			{
				return _forceSudvision;
			}
			set
			{
				if (value != _forceSudvision)
				{
					_forceSudvision = value;
				}
			}
		}

		public bool PreserveHardCorners
		{
			get
			{
				return _preserveHardCorners;
			}
			set
			{
				if (value != _preserveHardCorners)
				{
					_preserveHardCorners = value;
				}
			}
		}

		public bool FillCenter
		{
			get
			{
				return _fillCenter;
			}
			set
			{
				if (value != _fillCenter)
				{
					_fillCenter = value;
				}
			}
		}

		public float VertexDistance
		{
			get
			{
				return _vertexDistance;
			}
			set
			{
				if (_vertexDistance != value)
				{
					_vertexDistance = value;
					TriggerValueChanged();
				}
			}
		}

		public GlowConfig Copy(bool copyOnValueChanged = true)
		{
			GlowConfig glowConfig = new GlowConfig();
			CopyValuesTo(glowConfig, copyOnValueChanged);
			return glowConfig;
		}

		public void CopyValuesTo(GlowConfig copy, bool copyOnValueChanged = true)
		{
			if (copyOnValueChanged)
			{
				copy.OnValueChanged = OnValueChanged;
			}
			copy._width = Width;
			copy._splitWidth = SplitWidth;
			copy._widths = Widths;
			copy._scale = Scale;
			copy.SplitCorerRadius = SplitCorerRadius;
			copy.CornerRadius = CornerRadius;
			copy.CornerRadiusTopLeft = CornerRadiusTopLeft;
			copy.CornerRadiusTopRight = CornerRadiusTopRight;
			copy.CornerRadiusBottomLeft = CornerRadiusBottomLeft;
			copy.CornerRadiusBottomRight = CornerRadiusBottomRight;
			copy._offset = Offset;
			copy._offsetEverything = OffsetEverything;
			copy._innerColor = InnerColor;
			copy._outerColor = OuterColor;
			copy._useRadialGradients = UseRadialGradients;
			copy._innerColors = InnerColors;
			copy._outerColors = OuterColors;
			copy._overlapWidth = OverlapWidth;
			copy._forceSudvision = ForceSubdivision;
			copy._preserveHardCorners = PreserveHardCorners;
			copy._fillCenter = FillCenter;
			copy._vertexDistance = VertexDistance;
			copy.AnimationConfig = AnimationConfig;
		}

		public void TriggerValueChanged()
		{
			OnValueChanged?.Invoke();
		}

		public void InitValues()
		{
			Width = 10f;
			SplitWidth = false;
			Widths = default(DirectionValues);
			Offset = Vector2.zero;
			InnerColor = new Color(0f, 0f, 0f, 0.3f);
			OuterColor = new Color(0f, 0f, 0f, 0f);
			VertexDistance = 15f;
			OverlapWidth = 0.2f;
			UseRadialGradients = false;
			InnerColors = null;
			OuterColors = null;
		}
	}
}
