using System.Reflection;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public class LabelProperty : ConfigurableProperty
	{
		public TextWidget Label { get; private set; }

		public TextWidget Value { get; private set; }

		public LabelProperty(MemberInfo member, DesignerPropertyAttribute attribute)
			: base(member, attribute)
		{
		}

		public override void CreateUI(Widget parent)
		{
			DesignerPropertyLabelAttribute designerPropertyLabelAttribute = base.Attribute as DesignerPropertyLabelAttribute;
			if (designerPropertyLabelAttribute.Type == DesignerPropertyLabelAttribute.LabelType.LabelOnly)
			{
				base.RootWidget = CreateWidgetFromTemplate("property-label", parent);
			}
			else if (designerPropertyLabelAttribute.Type == DesignerPropertyLabelAttribute.LabelType.LabelAndValue)
			{
				base.RootWidget = CreateWidgetFromTemplate("property-label-value", parent);
				Value = base.RootWidget.FindWidget<TextWidget>("value-text");
				Value.Text = string.Empty;
			}
			base.RootWidget.name = GetDefaultLabel();
			Label = base.RootWidget.FindWidget<TextWidget>("label-text");
			Label.Text = designerPropertyLabelAttribute.Label;
		}

		public override void RefreshUI()
		{
			if (base.CurrentPartModifier != null)
			{
				string text = GetValue() as string;
				if (Value != null)
				{
					Value.Text = text;
				}
				else
				{
					Label.Text = text;
				}
			}
		}
	}
}
