using System;
using System.Reflection;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public class SpinnerProperty : ConfigurableProperty
	{
		private TextWidget _headerLabel;

		public ButtonWidget DecreaseButton { get; private set; }

		public ButtonWidget IncreaseButton { get; private set; }

		public InputWidget InputField { get; private set; }

		public DesignerPropertySpinnerAttribute SpinnerAttribute => (DesignerPropertySpinnerAttribute)base.Attribute;

		public SpinnerProperty(MemberInfo member, DesignerPropertyAttribute attribute)
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
			InputField.Input.onValueChanged.AddListener(delegate
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
				_headerLabel.Text = currentPartModifier.GetGenericDesignerPropertyNameLabel(this);
				decimal decimalValue = GetDecimalValue();
				string genericDesignerPropertySpinnerValueLabel = currentPartModifier.GetGenericDesignerPropertySpinnerValueLabel(base.Member.Name, (float)decimalValue);
				InputField.Text = genericDesignerPropertySpinnerValueLabel;
				UpdateButtonStates(currentPartModifier);
			}
		}

		private void CustomizeAppearance()
		{
		}

		private decimal GetDecimalValue()
		{
			return Convert.ToDecimal(GetValue());
		}

		private void OnDecreaseClick()
		{
			PartModifierData currentPartModifier = base.CurrentPartModifier;
			if (currentPartModifier == null)
			{
				return;
			}
			decimal decimalValue = GetDecimalValue();
			if (decimalValue - SpinnerAttribute.StepSize > SpinnerAttribute.MinValue)
			{
				decimalValue -= SpinnerAttribute.StepSize;
				foreach (var symmetricModifier in GetSymmetricModifiers(includeCurrentModifier: true))
				{
					symmetricModifier.PartModifier.OnGenericDesignerPropertyChanging(base.Member.Name, decimalValue.ToString());
				}
				SetValue(decimalValue, convertType: true);
				string genericDesignerPropertySpinnerValueLabel = currentPartModifier.GetGenericDesignerPropertySpinnerValueLabel(base.Member.Name, (float)decimalValue);
				InputField.Text = genericDesignerPropertySpinnerValueLabel;
				string value = decimalValue.ToString();
				foreach (var symmetricModifier2 in GetSymmetricModifiers(includeCurrentModifier: true))
				{
					symmetricModifier2.PartModifier.OnGenericDesignerPropertyChanged(base.Member.Name, value);
				}
				RaiseValueCommitted();
			}
			UpdateButtonStates(currentPartModifier);
		}

		private void OnIncreaseClick()
		{
			PartModifierData currentPartModifier = base.CurrentPartModifier;
			if (currentPartModifier == null)
			{
				return;
			}
			decimal decimalValue = GetDecimalValue();
			if (decimalValue + SpinnerAttribute.StepSize < SpinnerAttribute.MaxValue)
			{
				decimalValue += SpinnerAttribute.StepSize;
				foreach (var symmetricModifier in GetSymmetricModifiers(includeCurrentModifier: true))
				{
					symmetricModifier.PartModifier.OnGenericDesignerPropertyChanging(base.Member.Name, decimalValue.ToString());
				}
				SetValue(decimalValue, convertType: true);
				string genericDesignerPropertySpinnerValueLabel = currentPartModifier.GetGenericDesignerPropertySpinnerValueLabel(base.Member.Name, (float)decimalValue);
				InputField.Text = genericDesignerPropertySpinnerValueLabel;
				string value = decimalValue.ToString();
				foreach (var symmetricModifier2 in GetSymmetricModifiers(includeCurrentModifier: true))
				{
					symmetricModifier2.PartModifier.OnGenericDesignerPropertyChanged(base.Member.Name, value);
				}
				RaiseValueCommitted();
			}
			UpdateButtonStates(currentPartModifier);
		}

		private void OnInputFieldChanged()
		{
			PartModifierData currentPartModifier = base.CurrentPartModifier;
			if (currentPartModifier == null || !decimal.TryParse(InputField.Text, out var result))
			{
				return;
			}
			if (!SpinnerAttribute.ManualEntryIgnoresRange)
			{
				if (result < SpinnerAttribute.MinValue)
				{
					result = SpinnerAttribute.MinValue;
				}
				else if (result > SpinnerAttribute.MaxValue)
				{
					result = SpinnerAttribute.MaxValue;
				}
			}
			foreach (var symmetricModifier in GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier.PartModifier.OnGenericDesignerPropertyChanging(base.Member.Name, result.ToString());
			}
			SetValue(result, convertType: true);
			foreach (var symmetricModifier2 in GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier2.PartModifier.OnGenericDesignerPropertyChanged(base.Member.Name, result.ToString());
			}
			RaiseValueCommitted();
			UpdateButtonStates(currentPartModifier);
		}

		private void OnInputFieldDeselected()
		{
			PartModifierData currentPartModifier = base.CurrentPartModifier;
			if (currentPartModifier != null)
			{
				decimal decimalValue = GetDecimalValue();
				string genericDesignerPropertySpinnerValueLabel = currentPartModifier.GetGenericDesignerPropertySpinnerValueLabel(base.Member.Name, (float)decimalValue);
				InputField.Text = genericDesignerPropertySpinnerValueLabel;
			}
		}

		private void OnInputFieldSelected()
		{
			if (base.CurrentPartModifier != null)
			{
				string text = GetDecimalValue().ToString();
				InputField.Text = text;
			}
		}

		private void UpdateButtonStates(PartModifierData modifier)
		{
			decimal decimalValue = GetDecimalValue();
			DecreaseButton.Selectable.interactable = decimalValue > SpinnerAttribute.MinValue;
			IncreaseButton.Selectable.interactable = decimalValue < SpinnerAttribute.MaxValue;
		}
	}
}
