using System;
using System.Reflection;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.UI;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public class TextProperty : ConfigurableProperty
	{
		private bool _refreshingUI;

		public InputWidget Input { get; private set; }

		public DesignerPropertyTextInputAttribute TextInputAttribute => (DesignerPropertyTextInputAttribute)base.Attribute;

		public TextProperty(MemberInfo member, DesignerPropertyAttribute attribute)
			: base(member, attribute)
		{
		}

		public override void CreateUI(Widget parent)
		{
			string templateID = (TextInputAttribute.SupportsInputDialog ? "property-input-dialog" : "property-input");
			base.RootWidget = CreateWidgetFromTemplate(templateID, parent);
			base.RootWidget.name = GetDefaultLabel();
			Input = base.RootWidget.FindWidget<InputWidget>("value-input");
			Input.Input.onEndEdit.AddListener(delegate
			{
				OnValueChanged();
			});
			Input.Input.onValueChanged.AddListener(delegate
			{
				OnValueChanged();
			});
			Input.Placeholder.text = GetDefaultLabel();
			if (TextInputAttribute.SupportsInputDialog)
			{
				base.RootWidget.FindWidget("edit-button").Clicked += OnEditClicked;
			}
		}

		public override void RefreshUI()
		{
			PartModifierData currentPartModifier = base.CurrentPartModifier;
			if (currentPartModifier != null)
			{
				_refreshingUI = true;
				Input.Placeholder.text = currentPartModifier.GetGenericDesignerPropertyNameLabel(this);
				string text = Convert.ToString(GetValue());
				Input.Text = text;
				_refreshingUI = false;
			}
		}

		private void OnEditClicked(Widget widget)
		{
			InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
			inputDialogScript.MessageText = "Enter text.";
			inputDialogScript.InputText = Input.Text;
			inputDialogScript.InputDialogStyle = InputDialogStyle.Large;
			inputDialogScript.SelectTextOnStart = false;
			inputDialogScript.OkayClicked += delegate(InputDialogScript d)
			{
				Input.Text = d.InputText;
				OnValueChanged();
				d.Close();
			};
		}

		private void OnValueChanged()
		{
			if (_refreshingUI || base.CurrentPartModifier == null)
			{
				return;
			}
			string text = Input.Text;
			foreach (var symmetricModifier in GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier.PartModifier.OnGenericDesignerPropertyChanging(base.Member.Name, text.ToString());
			}
			SetValue(text, convertType: true);
			foreach (var symmetricModifier2 in GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier2.PartModifier.OnGenericDesignerPropertyChanged(base.Member.Name, text.ToString());
			}
			RaiseValueCommitted();
		}
	}
}
