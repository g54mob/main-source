using UnityEngine;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets.Extra
{
	public class WidgetBorder
	{
		private Color _color = new Color(0f, 0f, 0f, 0f);

		private Image _image;

		private RectTransform _imageRect;

		private RectOffset _padding = new RectOffset();

		private bool _paddingDirty;

		private string _sprite;

		private bool _spriteDirty;

		private Image.Type _spriteType = Image.Type.Sliced;

		private Widget _widget;

		public ColorProperty Color { get; private set; }

		public RectOffset Padding
		{
			get
			{
				return _padding;
			}
			set
			{
				_padding = value;
				_paddingDirty = true;
				UpdateBorder();
			}
		}

		public string Sprite
		{
			get
			{
				return _sprite;
			}
			set
			{
				if (_sprite != value)
				{
					_sprite = value;
					_spriteDirty = true;
					UpdateBorder();
				}
			}
		}

		public Image.Type SpriteType
		{
			get
			{
				return _spriteType;
			}
			set
			{
				if (_spriteType != value)
				{
					_spriteType = value;
					_spriteDirty = true;
					UpdateBorder();
				}
			}
		}

		public WidgetBorder(Widget widget)
		{
			_widget = widget;
			Color = new ColorProperty(new Color(0f, 0f, 0f, 0f), delegate(Color c)
			{
				_color = c;
				UpdateBorder();
			});
		}

		public void OnAddChildWidget()
		{
			if (_imageRect != null)
			{
				_imageRect.SetAsLastSibling();
			}
		}

		private void UpdateBorder()
		{
			if (_color.a > 0f)
			{
				if (_image == null)
				{
					GameObject gameObject = _widget.Context.ResourceLoader.LoadWidgetGameObject("Accessories/Border");
					_image = gameObject.GetComponent<Image>();
					_imageRect = gameObject.GetComponent<RectTransform>();
					_imageRect.SetParent(_widget.Rect, worldPositionStays: false);
				}
				else
				{
					_image.gameObject.SetActive(value: true);
				}
				_image.type = SpriteType;
				_image.color = _color;
				if (_widget is ImageWidget imageWidget)
				{
					_image.pixelsPerUnitMultiplier = imageWidget.Image.pixelsPerUnitMultiplier;
				}
				if (_spriteDirty)
				{
					_spriteDirty = false;
					_image.sprite = _widget.Context.ResourceLoader.LoadSprite(_sprite);
				}
				if (_paddingDirty)
				{
					_paddingDirty = false;
					_imageRect.offsetMin = new Vector2(-Padding.left, -Padding.top);
					_imageRect.offsetMax = new Vector2(Padding.right, Padding.bottom);
				}
			}
			else if (_image != null)
			{
				_image.gameObject.SetActive(value: false);
			}
		}
	}
}
