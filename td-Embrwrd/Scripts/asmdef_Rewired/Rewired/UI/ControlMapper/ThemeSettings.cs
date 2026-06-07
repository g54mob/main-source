using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.UI.ControlMapper
{
	[Serializable]
	public class ThemeSettings : ScriptableObject
	{
		[Serializable]
		private abstract class SelectableSettings_Base
		{
			[SerializeField]
			protected Selectable.Transition _transition;

			[SerializeField]
			protected CustomColorBlock _colors;

			[SerializeField]
			protected CustomSpriteState _spriteState;

			[SerializeField]
			protected CustomAnimationTriggers _animationTriggers;

			public Selectable.Transition transition => default(Selectable.Transition);

			public CustomColorBlock selectableColors => default(CustomColorBlock);

			public CustomSpriteState spriteState => default(CustomSpriteState);

			public CustomAnimationTriggers animationTriggers => null;

			public virtual void Apply(Selectable item)
			{
			}
		}

		[Serializable]
		private class SelectableSettings : SelectableSettings_Base
		{
			[SerializeField]
			private ImageSettings _imageSettings;

			public ImageSettings imageSettings => null;

			public override void Apply(Selectable item)
			{
			}
		}

		[Serializable]
		private class SliderSettings : SelectableSettings_Base
		{
			[SerializeField]
			private ImageSettings _handleImageSettings;

			[SerializeField]
			private ImageSettings _fillImageSettings;

			[SerializeField]
			private ImageSettings _backgroundImageSettings;

			public ImageSettings handleImageSettings => null;

			public ImageSettings fillImageSettings => null;

			public ImageSettings backgroundImageSettings => null;

			private void Apply(Slider item)
			{
			}

			public override void Apply(Selectable item)
			{
			}
		}

		[Serializable]
		private class ScrollbarSettings : SelectableSettings_Base
		{
			[SerializeField]
			private ImageSettings _handleImageSettings;

			[SerializeField]
			private ImageSettings _backgroundImageSettings;

			public ImageSettings handle => null;

			public ImageSettings background => null;

			private void Apply(Scrollbar item)
			{
			}

			public override void Apply(Selectable item)
			{
			}
		}

		[Serializable]
		private class ImageSettings
		{
			[SerializeField]
			private Color _color;

			[SerializeField]
			private Sprite _sprite;

			[SerializeField]
			private Material _materal;

			[SerializeField]
			private Image.Type _type;

			[SerializeField]
			private bool _preserveAspect;

			[SerializeField]
			private bool _fillCenter;

			[SerializeField]
			private Image.FillMethod _fillMethod;

			[SerializeField]
			private float _fillAmout;

			[SerializeField]
			private bool _fillClockwise;

			[SerializeField]
			private int _fillOrigin;

			public Color color => default(Color);

			public Sprite sprite => null;

			public Material materal => null;

			public Image.Type type => default(Image.Type);

			public bool preserveAspect => false;

			public bool fillCenter => false;

			public Image.FillMethod fillMethod => default(Image.FillMethod);

			public float fillAmout => 0f;

			public bool fillClockwise => false;

			public int fillOrigin => 0;

			public virtual void CopyTo(Image image)
			{
			}
		}

		[Serializable]
		private struct CustomColorBlock
		{
			[SerializeField]
			private float m_ColorMultiplier;

			[SerializeField]
			private Color m_DisabledColor;

			[SerializeField]
			private float m_FadeDuration;

			[SerializeField]
			private Color m_HighlightedColor;

			[SerializeField]
			private Color m_NormalColor;

			[SerializeField]
			private Color m_PressedColor;

			[SerializeField]
			private Color m_SelectedColor;

			[SerializeField]
			private Color m_DisabledHighlightedColor;

			public float colorMultiplier
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public Color disabledColor
			{
				get
				{
					return default(Color);
				}
				set
				{
				}
			}

			public float fadeDuration
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public Color highlightedColor
			{
				get
				{
					return default(Color);
				}
				set
				{
				}
			}

			public Color normalColor
			{
				get
				{
					return default(Color);
				}
				set
				{
				}
			}

			public Color pressedColor
			{
				get
				{
					return default(Color);
				}
				set
				{
				}
			}

			public Color selectedColor
			{
				get
				{
					return default(Color);
				}
				set
				{
				}
			}

			public Color disabledHighlightedColor
			{
				get
				{
					return default(Color);
				}
				set
				{
				}
			}

			public static implicit operator ColorBlock(CustomColorBlock item)
			{
				return default(ColorBlock);
			}
		}

		[Serializable]
		private struct CustomSpriteState
		{
			[SerializeField]
			private Sprite m_DisabledSprite;

			[SerializeField]
			private Sprite m_HighlightedSprite;

			[SerializeField]
			private Sprite m_PressedSprite;

			[SerializeField]
			private Sprite m_SelectedSprite;

			[SerializeField]
			private Sprite m_DisabledHighlightedSprite;

			public Sprite disabledSprite
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public Sprite highlightedSprite
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public Sprite pressedSprite
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public Sprite selectedSprite
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public Sprite disabledHighlightedSprite
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public static implicit operator SpriteState(CustomSpriteState item)
			{
				return default(SpriteState);
			}
		}

		[Serializable]
		private class CustomAnimationTriggers
		{
			[SerializeField]
			private string m_DisabledTrigger;

			[SerializeField]
			private string m_HighlightedTrigger;

			[SerializeField]
			private string m_NormalTrigger;

			[SerializeField]
			private string m_PressedTrigger;

			[SerializeField]
			private string m_SelectedTrigger;

			[SerializeField]
			private string m_DisabledHighlightedTrigger;

			public string disabledTrigger
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public string highlightedTrigger
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public string normalTrigger
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public string pressedTrigger
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public string selectedTrigger
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public string disabledHighlightedTrigger
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public static implicit operator AnimationTriggers(CustomAnimationTriggers item)
			{
				return null;
			}
		}

		[Serializable]
		private class TextSettings
		{
			[SerializeField]
			private Color _color;

			[SerializeField]
			private TMP_FontAsset _font;

			[SerializeField]
			private FontStyleOverride _style;

			[SerializeField]
			private float _sizeMultiplier;

			[SerializeField]
			private float _lineSpacing;

			[SerializeField]
			private float _characterSpacing;

			[SerializeField]
			private float _wordSpacing;

			public Color color => default(Color);

			public TMP_FontAsset font => null;

			public FontStyleOverride style => default(FontStyleOverride);

			public float sizeMultiplier => 0f;

			public float lineSpacing => 0f;

			public float chracterSpacing => 0f;

			public float wordSpacing => 0f;
		}

		private enum FontStyleOverride
		{
			Default = 0,
			Normal = 1,
			Bold = 2,
			Italic = 3,
			BoldAndItalic = 4
		}

		[SerializeField]
		private ImageSettings _mainWindowBackground;

		[SerializeField]
		private ImageSettings _popupWindowBackground;

		[SerializeField]
		private ImageSettings _areaBackground;

		[SerializeField]
		private SelectableSettings _selectableSettings;

		[SerializeField]
		private SelectableSettings _buttonSettings;

		[SerializeField]
		private SelectableSettings _inputGridFieldSettings;

		[SerializeField]
		private ScrollbarSettings _scrollbarSettings;

		[SerializeField]
		private SliderSettings _sliderSettings;

		[SerializeField]
		private ImageSettings _invertToggle;

		[SerializeField]
		private Color _invertToggleDisabledColor;

		[SerializeField]
		private ImageSettings _calibrationBackground;

		[SerializeField]
		private ImageSettings _calibrationValueMarker;

		[SerializeField]
		private ImageSettings _calibrationRawValueMarker;

		[SerializeField]
		private ImageSettings _calibrationZeroMarker;

		[SerializeField]
		private ImageSettings _calibrationCalibratedZeroMarker;

		[SerializeField]
		private ImageSettings _calibrationDeadzone;

		[SerializeField]
		private ImageSettings _calibrationUpperDeadzone;

		[SerializeField]
		private TextSettings _textSettings;

		[SerializeField]
		private TextSettings _buttonTextSettings;

		[SerializeField]
		private TextSettings _inputGridFieldTextSettings;

		public void Apply(ThemedElement.ElementInfo[] elementInfo)
		{
		}

		private void Apply(string themeClass, Component component)
		{
		}

		private void Apply(string themeClass, Selectable item)
		{
		}

		private void Apply(string themeClass, Image item)
		{
		}

		private void Apply(string themeClass, TMP_Text item)
		{
		}

		private void Apply(string themeClass, UIImageHelper item)
		{
		}

		private static FontStyles GetFontStyle(FontStyleOverride style)
		{
			return default(FontStyles);
		}
	}
}
