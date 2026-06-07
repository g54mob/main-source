using System.Xml.Linq;
using Jundroo.Juicy.Widgets.Extra;
using Jundroo.Juicy.Widgets.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets
{
	public class ImageWidget : Widget
	{
		private ImageWidgetMaskType _maskType;

		public ColorProperty Color { get; private set; }

		public Image Image { get; private set; }

		public ImageWidgetMaskType MaskType
		{
			get
			{
				return _maskType;
			}
			set
			{
				if (_maskType == value)
				{
					return;
				}
				_maskType = value;
				Mask mask = base.gameObject.GetComponent<Mask>();
				if (value == ImageWidgetMaskType.Disabled)
				{
					if (mask != null)
					{
						Object.Destroy(mask);
					}
					return;
				}
				if (mask == null)
				{
					mask = base.gameObject.AddComponent<Mask>();
				}
				mask.showMaskGraphic = value == ImageWidgetMaskType.EnabledAndShown;
			}
		}

		protected override AttributeSet AttributeSet => ImageAttributes.Set;

		public override void Initialize(IWidgetContext context, XElement element)
		{
			base.Initialize(context, element);
			Image = GetComponent<Image>();
			Color = new ColorProperty(Image.color, delegate(Color x)
			{
				Image.color = x;
			});
		}
	}
}
