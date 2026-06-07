using System.Reflection;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public class ButtonProperty : ConfigurableProperty
	{
		public DesignerPropertyButtonAttribute ButtonAttribute => (DesignerPropertyButtonAttribute)base.Attribute;

		public ButtonProperty(MemberInfo member, DesignerPropertyAttribute attribute)
			: base(member, attribute)
		{
		}

		public override void CreateUI(Widget parent)
		{
			string templateID = "property-button";
			base.RootWidget = CreateWidgetFromTemplate(templateID, parent);
			base.RootWidget.name = GetDefaultLabel();
			base.RootWidget.FindWidget("button").Clicked += OnButtonClicked;
			if (ButtonAttribute.Style == ButtonStyle.Default)
			{
				base.RootWidget.AddClass("btn-default");
			}
			else if (ButtonAttribute.Style == ButtonStyle.Primary)
			{
				base.RootWidget.AddClass("btn-primary");
			}
			else if (ButtonAttribute.Style == ButtonStyle.Danger)
			{
				base.RootWidget.AddClass("btn-danger");
			}
			base.RootWidget.FindWidget<TextWidget>("button-text").Text = GetDefaultLabel();
		}

		private void OnButtonClicked(Widget widget)
		{
			base.CurrentPartModifier.OnGenericDesignerPropertyButtonClicked(this);
		}
	}
}
