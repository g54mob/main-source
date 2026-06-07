using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.UI;
using Jundroo.Common.Attributes;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public class ToggleButtonProperty : ConfigurableProperty
	{
		private TextWidget _label;

		private string _outOfRangeText = "Error";

		private bool _valueIsFunky;

		public ButtonWidget Button { get; private set; }

		public DesignerPropertyToggleButtonAttribute ButtonAttribute => (DesignerPropertyToggleButtonAttribute)base.Attribute;

		public TextWidget ButtonLabel { get; private set; }

		public List<string> EnumNames { get; set; } = new List<string>();

		public ToggleButtonProperty(MemberInfo member, DesignerPropertyAttribute attribute)
			: base(member, attribute)
		{
			DesignerPropertyToggleButtonAttribute designerPropertyToggleButtonAttribute = (DesignerPropertyToggleButtonAttribute)attribute;
			Type type = base.FieldType;
			if (base.IsList)
			{
				type = (type.IsArray ? type.GetElementType() : type.GenericTypeArguments[0]);
			}
			if (type.IsEnum)
			{
				EnumNames = new List<string>(Enum.GetNames(type));
			}
			if (designerPropertyToggleButtonAttribute.AllowFunkyInput)
			{
				if (type != typeof(string))
				{
					designerPropertyToggleButtonAttribute.AllowFunkyInput = false;
				}
				else
				{
					_outOfRangeText = "Funky";
				}
			}
			if (designerPropertyToggleButtonAttribute.Values.Count == 0)
			{
				if (type.IsEnum)
				{
					designerPropertyToggleButtonAttribute.Values.AddRange(EnumNames);
				}
				else if (type == typeof(bool))
				{
					designerPropertyToggleButtonAttribute.Values.Add("No");
					designerPropertyToggleButtonAttribute.Values.Add("Yes");
				}
				else
				{
					Debug.LogErrorFormat("No values were specified or could be automatically determined for the toggle button on field '{0}' for modifier type '{1}'.", member.Name, member.DeclaringType.FullName);
				}
			}
			else if (type.IsEnum && EnumNames.Count != designerPropertyToggleButtonAttribute.Values.Count && !designerPropertyToggleButtonAttribute.SilenceEnumCountMismatch)
			{
				Debug.LogError("The number of specified values for the toggle button does not match the number of values specified in the enumeration");
			}
			else if (type == typeof(bool) && designerPropertyToggleButtonAttribute.Values.Count != 2)
			{
				Debug.LogErrorFormat("Boolean field '{0}' for modifier type '{1}' has a toggle button with {2} specified", member.Name, member.DeclaringType.FullName, (designerPropertyToggleButtonAttribute.Values.Count == 1) ? "only one value" : "more than two values");
			}
		}

		public override void CreateUI(Widget parent)
		{
			base.RootWidget = CreateWidgetFromTemplate("control-spinner-button", parent);
			Button = base.RootWidget.FindWidget<ButtonWidget>("next-button");
			ButtonLabel = base.RootWidget.FindWidget<TextWidget>("value-text");
			_label = base.RootWidget.FindWidget<TextWidget>("label-text");
			_label.name = GetDefaultLabel();
			_label.Text = GetDefaultLabel();
			Button.Clicked += OnClick;
		}

		public override void RefreshUI()
		{
			PartModifierData currentPartModifier = base.CurrentPartModifier;
			if (currentPartModifier != null)
			{
				_label.Text = currentPartModifier.GetGenericDesignerPropertyNameLabel(this);
				int currentValueIndex = GetCurrentValueIndex(currentPartModifier);
				bool flag = currentValueIndex < 0 || currentValueIndex >= ButtonAttribute.Values.Count;
				ButtonLabel.Text = (flag ? _outOfRangeText : GetDisplayValue(ButtonAttribute.Values[currentValueIndex]));
				_valueIsFunky = ButtonAttribute.AllowFunkyInput && flag;
			}
		}

		private int GetCurrentValueIndex(PartModifierData modifier)
		{
			string text = (GetValue() ?? string.Empty).ToString();
			int num = (base.FieldType.IsEnum ? EnumNames.IndexOf(text) : ((!(base.FieldType == typeof(bool))) ? ButtonAttribute.Values.IndexOf(text) : ((!(text == bool.FalseString)) ? 1 : 0)));
			if (num >= 0 && num < ButtonAttribute.Values.Count)
			{
				return num;
			}
			return -1;
		}

		private string GetDisplayValue(string value)
		{
			string text = base.CurrentPartModifier?.GetGenericDesignerPropertyToggleButtonValueLabel(base.Member.Name, value);
			if (text != null)
			{
				return text;
			}
			if (base.FieldType.IsEnum)
			{
				FieldInfo field = base.FieldType.GetField(value);
				if (field != null)
				{
					DescriptionAttribute customAttribute = field.GetCustomAttribute<DescriptionAttribute>();
					if (customAttribute != null)
					{
						string description = customAttribute.Description;
						if (!string.IsNullOrWhiteSpace(description))
						{
							return description;
						}
					}
					Jundroo.Common.Attributes.DisplayNameAttribute customAttribute2 = field.GetCustomAttribute<Jundroo.Common.Attributes.DisplayNameAttribute>();
					if (customAttribute2 != null)
					{
						string displayName = customAttribute2.DisplayName;
						if (!string.IsNullOrWhiteSpace(displayName))
						{
							return displayName;
						}
					}
				}
			}
			return value;
		}

		private void OnClick(Widget widget)
		{
			PartModifierData modifier = base.CurrentPartModifier;
			if (modifier == null)
			{
				return;
			}
			if (ButtonAttribute.AllowFunkyInput && (_valueIsFunky || UnityEngine.Input.GetKey(KeyCode.LeftControl) || UnityEngine.Input.GetKey(KeyCode.RightControl)))
			{
				InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
				inputDialogScript.InputDialogStyle = InputDialogStyle.Large;
				inputDialogScript.MessageText = "Enter input expression.";
				inputDialogScript.InputText = (GetValue() as string) ?? string.Empty;
				inputDialogScript.OkayClicked += delegate(InputDialogScript d)
				{
					if (!string.IsNullOrWhiteSpace(d.InputText))
					{
						SetValue(d.InputText, convertType: false);
						RaiseValueCommitted();
					}
					else
					{
						SetCurrentValue(modifier, 0);
					}
					RefreshUI();
					d.Close();
				};
				return;
			}
			int currentValueIndex = GetCurrentValueIndex(modifier);
			int num;
			if (currentValueIndex == -1)
			{
				if (ButtonAttribute.Values.Count <= 0)
				{
					ButtonLabel.Text = "Error";
					return;
				}
				num = 0;
			}
			else if (UnityEngine.Input.GetMouseButtonUp(1))
			{
				num = currentValueIndex - 1;
				if (num < 0)
				{
					num = ButtonAttribute.Values.Count - 1;
				}
			}
			else
			{
				num = currentValueIndex + 1;
				if (num == ButtonAttribute.Values.Count)
				{
					num = 0;
				}
			}
			SetCurrentValue(modifier, num);
		}

		private void SetCurrentValue(PartModifierData modifier, int valueIndex)
		{
			string text = ButtonAttribute.Values[valueIndex];
			foreach (var symmetricModifier in GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier.PartModifier.OnGenericDesignerPropertyChanging(base.Member.Name, text);
			}
			if (base.FieldType.IsEnum)
			{
				string value = EnumNames[valueIndex];
				object value2 = Enum.Parse(base.FieldType, value);
				SetValue(value2, convertType: false);
			}
			else if (base.FieldType == typeof(bool))
			{
				SetValue((valueIndex != 0) ? true : false, convertType: false);
			}
			else if (base.FieldType == typeof(string))
			{
				SetValue(text, convertType: false);
			}
			else
			{
				object value3 = Convert.ChangeType(text, base.FieldType);
				SetValue(value3, convertType: false);
			}
			foreach (var symmetricModifier2 in GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier2.PartModifier.OnGenericDesignerPropertyChanged(base.Member.Name, text);
			}
			ButtonLabel.Text = GetDisplayValue(text);
			RaiseValueCommitted();
		}
	}
}
