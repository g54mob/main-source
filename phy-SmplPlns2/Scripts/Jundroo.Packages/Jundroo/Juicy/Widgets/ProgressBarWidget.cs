using System.Xml.Linq;
using Jundroo.Juicy.Widgets.Extra;
using Jundroo.Juicy.Widgets.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets
{
	public class ProgressBarWidget : Widget
	{
		[SerializeField]
		private Image _backgroundImage;

		[SerializeField]
		private Slider _slider;

		public ColorProperty BackgroundColor { get; private set; }

		public Image BackgroundImage => _backgroundImage;

		public ColorProperty FillColor { get; private set; }

		public Image FillImage { get; private set; }

		public float Value
		{
			get
			{
				return _slider.value;
			}
			set
			{
				_slider.value = value;
			}
		}

		protected override AttributeSet AttributeSet => ProgressBarAttributes.Set;

		public override void Initialize(IWidgetContext context, XElement element)
		{
			base.Initialize(context, element);
			FillImage = _slider.fillRect.GetComponent<Image>();
			BackgroundColor = new ColorProperty(BackgroundImage.color, delegate(Color x)
			{
				BackgroundImage.color = x;
			});
			FillColor = new ColorProperty(FillImage.color, delegate(Color x)
			{
				FillImage.color = x;
			});
		}
	}
}
