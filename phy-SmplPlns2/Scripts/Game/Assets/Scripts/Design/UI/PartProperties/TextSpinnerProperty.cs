using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public class TextSpinnerProperty : ConfigurableProperty, ITextSpinnerProperty, IConfigurableProperty
	{
		private string _customValue;

		private TextWidget _headerLabel;

		private List<string> _values;

		public ButtonWidget DecreaseButton { get; private set; }

		public ButtonWidget IncreaseButton { get; private set; }

		public InputWidget InputField { get; private set; }

		public DesignerPropertyTextSpinnerAttribute SpinnerAttribute => (DesignerPropertyTextSpinnerAttribute)base.Attribute;

		public TextSpinnerProperty(MemberInfo member, DesignerPropertyAttribute attribute)
			: base(member, attribute)
		{
		}

		public override void CreateUI(Widget parent)
		{
			base.RootWidget = CreateWidgetFromTemplate("control-spinner-input-label", parent);
			base.RootWidget.name = GetDefaultLabel();
			_headerLabel = base.RootWidget.FindWidget<TextWidget>("label-text");
			_headerLabel.Text = GetDefaultLabel();
			InputField = base.RootWidget.FindWidget<InputWidget>("value-input");
			InputField.Input.onEndEdit.AddListener(delegate
			{
				OnInputFieldChanged();
			});
			IncreaseButton = base.RootWidget.FindWidget<ButtonWidget>("next-button");
			IncreaseButton.Clicked += delegate
			{
				OnIncreaseClick();
			};
			DecreaseButton = base.RootWidget.FindWidget<ButtonWidget>("prev-button");
			DecreaseButton.Clicked += delegate
			{
				OnDecreaseClick();
			};
		}

		public override void RefreshUI()
		{
			PartModifierData currentPartModifier = base.CurrentPartModifier;
			if (currentPartModifier != null)
			{
				_values = new List<string>(SpinnerAttribute.Values);
				currentPartModifier.GetGenericDesignerPropertyTextSpinnerValues(this, _values);
				_headerLabel.Text = currentPartModifier.GetGenericDesignerPropertyNameLabel(this);
				string text = (string)GetValue();
				if (SpinnerAttribute.AllowManualEntry && !_values.Contains(text))
				{
					_customValue = text;
				}
				string genericDesignerPropertyTextSpinnerValueLabel = currentPartModifier.GetGenericDesignerPropertyTextSpinnerValueLabel(base.Member.Name, text);
				InputField.Text = genericDesignerPropertyTextSpinnerValueLabel;
			}
		}

		private void CustomizeAppearance()
		{
		}

		private void OnDecreaseClick()
		{
			PartModifierData currentPartModifier = base.CurrentPartModifier;
			if (currentPartModifier == null)
			{
				return;
			}
			string text = (string)GetValue();
			int num = _values.IndexOf(text);
			if (num < 0)
			{
				_customValue = text;
				num = _values.Count;
			}
			num--;
			text = ((num >= 0) ? _values[num] : (string.IsNullOrWhiteSpace(_customValue) ? _values[_values.Count - 1] : _customValue));
			foreach (var symmetricModifier in GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier.PartModifier.OnGenericDesignerPropertyChanging(base.Member.Name, text);
			}
			SetValue(text, convertType: false);
			string genericDesignerPropertyTextSpinnerValueLabel = currentPartModifier.GetGenericDesignerPropertyTextSpinnerValueLabel(base.Member.Name, text);
			InputField.Text = genericDesignerPropertyTextSpinnerValueLabel;
			foreach (var symmetricModifier2 in GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier2.PartModifier.OnGenericDesignerPropertyChanged(base.Member.Name, text);
			}
			RaiseValueCommitted();
		}

		private void OnIncreaseClick()
		{
			PartModifierData currentPartModifier = base.CurrentPartModifier;
			if (currentPartModifier == null)
			{
				return;
			}
			string text = (string)GetValue();
			int num = _values.IndexOf(text);
			if (num < 0)
			{
				_customValue = text;
				num = _values.Count;
			}
			num++;
			text = ((num > _values.Count) ? _values[0] : ((num != _values.Count) ? _values[num] : (string.IsNullOrWhiteSpace(_customValue) ? _values[0] : _customValue)));
			foreach (var symmetricModifier in GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier.PartModifier.OnGenericDesignerPropertyChanging(base.Member.Name, text);
			}
			SetValue(text, convertType: false);
			string genericDesignerPropertyTextSpinnerValueLabel = currentPartModifier.GetGenericDesignerPropertyTextSpinnerValueLabel(base.Member.Name, text);
			InputField.Text = genericDesignerPropertyTextSpinnerValueLabel;
			foreach (var symmetricModifier2 in GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier2.PartModifier.OnGenericDesignerPropertyChanged(base.Member.Name, text);
			}
			RaiseValueCommitted();
		}

		private void OnInputFieldChanged()
		{
			if (base.CurrentPartModifier == null)
			{
				return;
			}
			string text = InputField.Text;
			foreach (var symmetricModifier in GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier.PartModifier.OnGenericDesignerPropertyChanging(base.Member.Name, text);
			}
			SetValue(text, convertType: true);
			foreach (var symmetricModifier2 in GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier2.PartModifier.OnGenericDesignerPropertyChanged(base.Member.Name, text);
			}
			RaiseValueCommitted();
		}

		private void OnInputFieldDeselected()
		{
			PartModifierData currentPartModifier = base.CurrentPartModifier;
			if (currentPartModifier != null)
			{
				string spinnerValue = GetValue()?.ToString();
				string genericDesignerPropertyTextSpinnerValueLabel = currentPartModifier.GetGenericDesignerPropertyTextSpinnerValueLabel(base.Member.Name, spinnerValue);
				InputField.Text = genericDesignerPropertyTextSpinnerValueLabel;
			}
		}

		private void OnInputFieldSelected()
		{
			if (base.CurrentPartModifier != null)
			{
				string text = GetValue()?.ToString();
				InputField.Text = text;
			}
		}
	}
}
