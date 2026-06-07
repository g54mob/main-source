using System.Xml.Linq;
using Jundroo.Juicy.Widgets.Serialization;

namespace Jundroo.Juicy.Widgets
{
	public class CanvasWidget : Widget
	{
		protected override AttributeSet AttributeSet => CanvasAttributes.Set;

		public override void Initialize(IWidgetContext context, XElement element)
		{
			base.Initialize(context, element);
		}
	}
}
