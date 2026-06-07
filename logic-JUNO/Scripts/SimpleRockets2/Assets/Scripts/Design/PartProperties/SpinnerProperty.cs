using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Assets.Scripts.Ui;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design;
using ModApi.Design.PartProperties;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design.PartProperties
{
	public class SpinnerProperty : ConfigurableProperty, ISpinnerProperty, IConfigurableProperty
	{
		private TextMeshProUGUI _label;

		private List<string> _originalValues;

		public bool IsTextSpinner { get; private set; }

		public string LabelValue
		{
			get
			{
				return _label.text;
			}
			set
			{
				_label.text = value;
			}
		}

		public decimal MaxValue { get; private set; }

		public decimal MinValue { get; private set; }

		public decimal NumericValue => GetDecimalValue();

		public DesignerPropertySpinnerAttribute SpinnerAttribute => (DesignerPropertySpinnerAttribute)base.Attribute;

		public SpinnerScript SpinnerScript { get; set; }

		public decimal StepSize { get; private set; }

		public string TextValue => SpinnerScript.Value;

		IReadOnlyList<string> ISpinnerProperty.Values => Values;

		protected List<string> Values { get; private set; }

		public SpinnerProperty(FieldInfo field, DesignerPropertyAttribute attribute)
			: base(field, attribute)
		{
			DesignerPropertySpinnerAttribute designerPropertySpinnerAttribute = (DesignerPropertySpinnerAttribute)attribute;
			IsTextSpinner = designerPropertySpinnerAttribute.IsTextSpinner;
			if (IsTextSpinner)
			{
				if (designerPropertySpinnerAttribute.Values == null)
				{
					Values = new List<string>();
				}
				else
				{
					Values = new List<string>(designerPropertySpinnerAttribute.Values);
				}
				if (field.FieldType.IsEnum)
				{
					string[] names = Enum.GetNames(field.FieldType);
					if (Values.Count == 0)
					{
						Values.AddRange(names);
					}
					else
					{
						bool flag = true;
						foreach (string value in Values)
						{
							if (!names.Contains(value))
							{
								flag = false;
								break;
							}
						}
						if (!flag)
						{
							Debug.LogError("One or more of the values specified for the spinner do not exactly match a name in the underlying enumeration field type.");
						}
					}
				}
				_originalValues = new List<string>(Values);
			}
			else
			{
				UpdateNumericSpinnerSettings(designerPropertySpinnerAttribute.MinValue, designerPropertySpinnerAttribute.MaxValue, designerPropertySpinnerAttribute.StepSize, refreshUI: false);
			}
		}

		public override void RefreshUI()
		{
			IDesignerPartModifierData currentPartModifier = base.CurrentPartModifier;
			if (currentPartModifier == null)
			{
				return;
			}
			IDesignerPartPropertiesDesignerInterface designerPartProperties = currentPartModifier.DesignerPartProperties;
			if (IsTextSpinner)
			{
				int currentValueIndex = GetCurrentValueIndex();
				if (currentValueIndex < 0 || currentValueIndex >= Values.Count)
				{
					SetCurrentValue(designerPartProperties, 0);
					return;
				}
				string valueLabel = designerPartProperties.GetValueLabel(base.Field, Values[currentValueIndex]);
				SetSpinnerTextLabel(valueLabel);
			}
			else
			{
				object value = Convert.ChangeType(GetDecimalValue(), base.Field.FieldType);
				string valueLabel2 = designerPartProperties.GetValueLabel(base.Field, value);
				SetSpinnerTextLabel(valueLabel2);
				UpdateButtonStates();
			}
		}

		public void UpdateNumericSpinnerSettings(decimal minValue, decimal maxValue, decimal stepSize)
		{
			UpdateNumericSpinnerSettings(minValue, maxValue, stepSize, refreshUI: true);
		}

		public void UpdateValues()
		{
			base.CurrentPartModifier.DesignerPartProperties.UpdateSpinnerValues(base.Field, Values);
		}

		protected override GameObject OnCreateUI(GameObject parent, PartPropertiesFlyoutScript flyout)
		{
			bool flag = SpinnerAttribute.AllowManualInput;
			if (flag && Device.IsMobileBuild && !Game.Instance.Settings.Game.Designer.EnableTinkerPanel.Value)
			{
				flag = false;
			}
			XmlElement xmlElement = flyout.CloneTemplateElement(flag ? "template-spinner-input" : "template-spinner", parent.transform, "PartProperties." + base.FieldName);
			_label = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			_label.text = base.FieldName;
			SpinnerScript = xmlElement.GetElementByInternalId<SpinnerScript>("spinner");
			SpinnerScript.PrevButton.onClick.AddListener(OnDecreaseClick);
			SpinnerScript.NextButton.onClick.AddListener(OnIncreaseClick);
			SpinnerScript.OnValueChanged = ValueManuallyChanged;
			return xmlElement.gameObject;
		}

		protected override void OnPartSelected()
		{
			if (!IsTextSpinner)
			{
				return;
			}
			Values.Clear();
			Values.AddRange(_originalValues);
			UpdateValues();
			if (base.Field.FieldType != typeof(bool))
			{
				string item = (GetValue() ?? string.Empty).ToString();
				if (!Values.Contains(item))
				{
					Values.Add(item);
				}
			}
		}

		private void ChangeTextSpinnerValue(int direction)
		{
			IDesignerPartModifierData currentPartModifier = base.CurrentPartModifier;
			if (currentPartModifier == null)
			{
				return;
			}
			int currentValueIndex = GetCurrentValueIndex();
			int num;
			if (currentValueIndex == -1)
			{
				if (Values.Count <= 0)
				{
					SetSpinnerTextLabel("Error");
					return;
				}
				num = 0;
			}
			else
			{
				num = currentValueIndex + direction;
				if (num >= Values.Count)
				{
					num = 0;
				}
				else if (num < 0)
				{
					num = Values.Count - 1;
				}
			}
			SetCurrentValue(currentPartModifier.DesignerPartProperties, num);
		}

		private string FormatTextLabel(string text)
		{
			bool flag = false;
			switch (SpinnerAttribute.TextFormat)
			{
			case DesignerPropertySpinnerTextFormat.Auto:
				flag = true;
				break;
			case DesignerPropertySpinnerTextFormat.InputAuto:
			{
				string text2 = text ?? string.Empty;
				if (typeof(CraftControls).GetProperty(text2) != null)
				{
					flag = true;
				}
				else if (text2.Length >= 3 && text2.Length <= 4 && text2.StartsWith("AG"))
				{
					text = "AG " + text2.Substring(2);
				}
				break;
			}
			}
			if (flag)
			{
				text = Regex.Replace(text, "([A-Z]+|[0-9|\\.]+)", " $1").TrimStart();
			}
			return text;
		}

		private int GetCurrentValueIndex()
		{
			return GetValueIndex((GetValue() ?? string.Empty).ToString(), ignoreCaseAndFormat: false);
		}

		private decimal GetDecimalValue()
		{
			return Convert.ToDecimal(GetValue());
		}

		private int GetStringValueIndex(string value)
		{
			string text = value.ToLower();
			int count = Values.Count;
			for (int i = 0; i < count; i++)
			{
				string text2 = Values[i];
				if (text == text2.ToLower())
				{
					return i;
				}
				string valueLabel = base.CurrentPartModifier.DesignerPartProperties.GetValueLabel(base.Field, text2);
				if (valueLabel != text2 && text == valueLabel.ToLower())
				{
					return i;
				}
				string text3 = FormatTextLabel(valueLabel);
				if (text == text3.ToLower())
				{
					return i;
				}
			}
			return -1;
		}

		private int GetValueIndex(string value, bool ignoreCaseAndFormat)
		{
			int num = ((!(base.Field.FieldType == typeof(bool))) ? (ignoreCaseAndFormat ? GetStringValueIndex(value) : Values.IndexOf(value)) : (((!ignoreCaseAndFormat) ? (!(value == bool.FalseString)) : (!(value.ToLower() == bool.FalseString.ToLower()))) ? 1 : 0));
			if (num >= 0 && num < Values.Count)
			{
				return num;
			}
			return -1;
		}

		private void OnDecreaseClick()
		{
			IDesignerPartModifierData currentPartModifier = base.CurrentPartModifier;
			if (currentPartModifier == null)
			{
				return;
			}
			if (IsTextSpinner)
			{
				ChangeTextSpinnerValue(-1);
				return;
			}
			decimal decimalValue = GetDecimalValue();
			if (decimalValue > MinValue)
			{
				decimalValue -= StepSize;
				object value = Convert.ChangeType(decimalValue, base.Field.FieldType);
				string valueLabel = currentPartModifier.DesignerPartProperties.GetValueLabel(base.Field, value);
				SetSpinnerTextLabel(valueLabel);
				SetValue(value);
			}
			UpdateButtonStates();
		}

		private void OnIncreaseClick()
		{
			IDesignerPartModifierData currentPartModifier = base.CurrentPartModifier;
			if (currentPartModifier == null)
			{
				return;
			}
			if (IsTextSpinner)
			{
				ChangeTextSpinnerValue(1);
				return;
			}
			decimal decimalValue = GetDecimalValue();
			if (decimalValue < MaxValue)
			{
				decimalValue += StepSize;
				object value = Convert.ChangeType(decimalValue, base.Field.FieldType);
				string valueLabel = currentPartModifier.DesignerPartProperties.GetValueLabel(base.Field, value);
				SetSpinnerTextLabel(valueLabel);
				SetValue(value);
			}
			UpdateButtonStates();
		}

		private void SetCurrentValue(IDesignerPartPropertiesDesignerInterface modifier, int valueIndex)
		{
			string value = ((valueIndex < Values.Count) ? Values[valueIndex] : "Error");
			if (base.Field.FieldType.IsEnum)
			{
				object value2 = Enum.Parse(base.Field.FieldType, value);
				SetValue(value2);
			}
			else if (base.Field.FieldType == typeof(bool))
			{
				SetValue((valueIndex != 0) ? true : false);
			}
			else if (base.Field.FieldType == typeof(string))
			{
				SetValue(value);
			}
			else
			{
				object value3 = Convert.ChangeType(value, base.Field.FieldType);
				SetValue(value3);
			}
			value = modifier.GetValueLabel(base.Field, value);
			SetSpinnerTextLabel(value);
		}

		private void SetSpinnerTextLabel(string text)
		{
			if (IsTextSpinner)
			{
				text = FormatTextLabel(text);
			}
			SpinnerScript.Value = text;
		}

		private void UpdateButtonStates()
		{
			decimal decimalValue = GetDecimalValue();
			SpinnerScript.PrevButton.interactable = decimalValue > MinValue;
			SpinnerScript.NextButton.interactable = decimalValue < MaxValue;
		}

		private void UpdateNumericSpinnerSettings(decimal minValue, decimal maxValue, decimal stepSize, bool refreshUI)
		{
			MinValue = minValue;
			MaxValue = maxValue;
			StepSize = stepSize;
			if (refreshUI)
			{
				decimal num = GetDecimalValue();
				decimal num2 = num;
				if (num > MaxValue)
				{
					num = MaxValue;
				}
				else if (num < MinValue)
				{
					num = minValue;
				}
				if (num != num2)
				{
					object value = Convert.ChangeType(num, base.Field.FieldType);
					SetValue(value);
				}
				RefreshUI();
			}
		}

		private void ValueManuallyChanged(string value)
		{
			bool validateManualInput = SpinnerAttribute.ValidateManualInput;
			IDesignerPartPropertiesDesignerInterface designerPartProperties = base.CurrentPartModifier.DesignerPartProperties;
			if (IsTextSpinner)
			{
				int valueIndex = GetValueIndex(value, ignoreCaseAndFormat: true);
				if (valueIndex == -1)
				{
					if (!validateManualInput && base.Field.FieldType == typeof(string))
					{
						SetValue(value);
						string valueLabel = designerPartProperties.GetValueLabel(base.Field, value);
						SetSpinnerTextLabel(valueLabel);
					}
					else if (Values.Count > 0)
					{
						SetCurrentValue(designerPartProperties, 0);
					}
					else
					{
						SetSpinnerTextLabel("Error");
					}
				}
				else
				{
					SetCurrentValue(designerPartProperties, valueIndex);
				}
				return;
			}
			object value2;
			if (decimal.TryParse(value, out var result))
			{
				if (validateManualInput)
				{
					if (result > MaxValue)
					{
						result = MaxValue;
					}
					else if (result < MinValue)
					{
						result = MinValue;
					}
				}
				value2 = Convert.ChangeType(result, base.Field.FieldType);
			}
			else
			{
				value2 = GetValue();
			}
			string valueLabel2 = designerPartProperties.GetValueLabel(base.Field, value2);
			SetSpinnerTextLabel(valueLabel2);
			SetValue(value2);
			UpdateButtonStates();
		}
	}
}
