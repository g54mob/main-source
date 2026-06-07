using System.Reflection;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.UI.Controls;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public class ColorProperty : ConfigurableProperty
	{
		private ColorButtonControl _colorButton;

		public ColorProperty(MemberInfo member, DesignerPropertyAttribute attribute)
			: base(member, attribute)
		{
		}

		public override void CreateUI(Widget parent)
		{
			DesignerPropertyColorAttribute designerPropertyColorAttribute = base.Attribute as DesignerPropertyColorAttribute;
			base.RootWidget = CreateWidgetFromTemplate("property-color", parent);
			base.RootWidget.name = GetDefaultLabel();
			_colorButton = new ColorButtonControl(base.RootWidget);
			_colorButton.ColorChanged += OnColorChanged;
			_colorButton.AllowTransparency = designerPropertyColorAttribute.AllowTransparency;
			_colorButton.LabelText = designerPropertyColorAttribute.Label;
		}

		public override void RefreshUI()
		{
			if (base.CurrentPartModifier != null)
			{
				Color modifierColor = GetModifierColor();
				_colorButton.Color = modifierColor;
			}
		}

		private Color GetModifierColor()
		{
			return (GetValue() as Color?) ?? Color.white;
		}

		private void OnColorChanged(object sender, ColorButtonControl.ColorChangedEventArgs e)
		{
			SetValue((Color)e.Color, convertType: false);
			foreach (var symmetricModifier in GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier.PartModifier.OnGenericDesignerPropertyChanged(base.Member.Name, e.Color.ToString());
			}
			RaiseValueCommitted();
		}
	}
}
