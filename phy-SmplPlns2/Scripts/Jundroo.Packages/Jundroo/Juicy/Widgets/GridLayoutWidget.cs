using System.Xml.Linq;
using Jundroo.Common.Extensions;
using Jundroo.Juicy.Widgets.Extra;
using Jundroo.Juicy.Widgets.Serialization;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets
{
	public class GridLayoutWidget : Widget
	{
		private LayoutWidget.SizeFitterOption _sizeFitter;

		public GridLayoutGroup GridLayout { get; private set; }

		public LayoutWidget.SizeFitterOption SizeFitter
		{
			get
			{
				return _sizeFitter;
			}
			set
			{
				_sizeFitter = value;
				WidgetSizeFitter widgetSizeFitter = WidgetSizeFitter;
				switch (value)
				{
				case LayoutWidget.SizeFitterOption.Horizontal:
					widgetSizeFitter.verticalFit = ContentSizeFitter.FitMode.Unconstrained;
					widgetSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
					break;
				case LayoutWidget.SizeFitterOption.Vertical:
					widgetSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
					widgetSizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
					break;
				case LayoutWidget.SizeFitterOption.Both:
					widgetSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
					widgetSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
					break;
				}
			}
		}

		protected override AttributeSet AttributeSet => GridLayoutAttributes.Set;

		private WidgetSizeFitter WidgetSizeFitter => base.gameObject.AddMissingComponent<WidgetSizeFitter>();

		public override void Initialize(IWidgetContext context, XElement element)
		{
			base.Initialize(context, element);
			GridLayout = base.gameObject.GetComponent<GridLayoutGroup>();
		}
	}
}
