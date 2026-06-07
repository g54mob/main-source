using System.Xml.Linq;
using Jundroo.Juicy.Widgets.Extra;
using Jundroo.Juicy.Widgets.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets
{
	public class RawImageWidget : Widget
	{
		private bool _isAdjustingAspectRatio;

		private bool _preserveAspect;

		public ColorProperty Color { get; private set; }

		public RawImage Image { get; set; }

		public bool PreserveAspect
		{
			get
			{
				return _preserveAspect;
			}
			set
			{
				if (_preserveAspect != value)
				{
					_preserveAspect = value;
					if (value)
					{
						AdjustAspectRatio();
					}
				}
			}
		}

		public Texture Texture
		{
			get
			{
				return Image.texture;
			}
			set
			{
				Image.texture = value;
				AdjustAspectRatio();
			}
		}

		protected override AttributeSet AttributeSet => RawImageAttributes.Set;

		public override void Initialize(IWidgetContext context, XElement element)
		{
			base.Initialize(context, element);
			Image = GetComponent<RawImage>();
			Color = new ColorProperty(Image.color, delegate(Color x)
			{
				Image.color = x;
			});
		}

		protected void OnRectTransformDimensionsChange()
		{
			if (!_isAdjustingAspectRatio)
			{
				AdjustAspectRatio();
			}
		}

		private void AdjustAspectRatio()
		{
			if (!PreserveAspect || Image.texture == null)
			{
				return;
			}
			try
			{
				_isAdjustingAspectRatio = true;
				Vector2 size = base.Parent.Rect.rect.size;
				Vector2 anchorMin = base.Rect.anchorMin;
				Vector2 anchorMax = base.Rect.anchorMax;
				float num = size.x * (anchorMax.x - anchorMin.x);
				float num2 = size.y * (anchorMax.y - anchorMin.y);
				float num3 = num / num2;
				float num4 = (float)Texture.width / (float)Texture.height;
				if (num3 > num4)
				{
					float size2 = num2 * num4;
					base.Rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size2);
					base.Rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num2);
				}
				else
				{
					float size3 = num / num4;
					base.Rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num);
					base.Rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size3);
				}
			}
			finally
			{
				_isAdjustingAspectRatio = false;
			}
		}
	}
}
