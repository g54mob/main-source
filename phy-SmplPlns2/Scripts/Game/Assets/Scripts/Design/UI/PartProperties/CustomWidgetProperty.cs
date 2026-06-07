using System.Reflection;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public class CustomWidgetProperty : ConfigurableProperty
	{
		public CustomPartPropertyWidget Widget { get; private set; }

		public CustomWidgetProperty(MemberInfo member, DesignerPropertyAttribute attribute)
			: base(member, attribute)
		{
		}

		public override void CreateUI(Widget parent)
		{
			DesignerPropertyCustomWidgetAttribute designerPropertyCustomWidgetAttribute = base.Attribute as DesignerPropertyCustomWidgetAttribute;
			base.RootWidget = CreateWidgetFromTemplate(designerPropertyCustomWidgetAttribute.WidgetTemplate, parent);
			Widget = base.RootWidget.GetComponent<CustomPartPropertyWidget>();
			Widget.ConfigurableProperty = this;
		}
	}
}
