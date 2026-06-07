using System;
using System.Collections.Generic;
using Assets.Scripts.UI.Controls;
using UnityEngine;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public class GearRatiosWidget : CustomPartPropertyWidget
	{
		private List<float> _originalRatios;

		private List<NumericSpinnerControl> _ratioWidgets = new List<NumericSpinnerControl>();

		public List<float> GetRatios()
		{
			List<float> list = new List<float>(_originalRatios.Count);
			for (int i = 0; i < _originalRatios.Count; i++)
			{
				if (i < _ratioWidgets.Count && _ratioWidgets[i].Visible)
				{
					list.Add(_ratioWidgets[i].Value);
				}
				else
				{
					list.Add(_originalRatios[i]);
				}
			}
			return list;
		}

		public void SetRatios(List<float> ratios, int numGears)
		{
			_originalRatios = ratios;
			int num = Mathf.Min(numGears, 10);
			int num2 = 0;
			for (num2 = 0; num2 < num; num2++)
			{
				float value = ratios[num2];
				if (num2 >= _ratioWidgets.Count)
				{
					_ratioWidgets.Add(CreateInputWidget($"Gear Ratio: {num2 + 1}"));
				}
				_ratioWidgets[num2].Visible = true;
				_ratioWidgets[num2].Value = value;
			}
			for (int i = num2; i < _ratioWidgets.Count; i++)
			{
				_ratioWidgets[i].Visible = false;
			}
		}

		private NumericSpinnerControl CreateInputWidget(string label)
		{
			NumericSpinnerControl numericSpinnerControl = new NumericSpinnerControl(base.Widget.Context.CreateWidgetFromTemplate("control-spinner-input-label", base.Widget));
			numericSpinnerControl.LabelText.Text = label;
			numericSpinnerControl.MinValue = 0f;
			numericSpinnerControl.MaxValue = 100f;
			numericSpinnerControl.StepSize = 0.1f;
			numericSpinnerControl.NumericFormat = "0.00";
			numericSpinnerControl.OnValueChanged = (OnValueChanged<float>)Delegate.Combine(numericSpinnerControl.OnValueChanged, (OnValueChanged<float>)delegate
			{
				OnValueChanged();
			});
			return numericSpinnerControl;
		}

		private void OnValueChanged()
		{
			List<float> ratios = GetRatios();
			string text = ratios?.ToString();
			foreach (var symmetricModifier in base.ConfigurableProperty.GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier.PartModifier.OnGenericDesignerPropertyChanging(base.ConfigurableProperty.Member.Name, text);
			}
			base.ConfigurableProperty.SetValue(ratios, convertType: true);
			foreach (var symmetricModifier2 in base.ConfigurableProperty.GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier2.PartModifier.OnGenericDesignerPropertyChanged(base.ConfigurableProperty.Member.Name, text);
			}
			base.ConfigurableProperty.RaiseValueCommitted();
		}
	}
}
