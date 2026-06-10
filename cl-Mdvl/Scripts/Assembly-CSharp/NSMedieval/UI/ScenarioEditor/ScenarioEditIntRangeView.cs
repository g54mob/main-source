using System;
using NSEipix.Model;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI.ScenarioEditor
{
	public class ScenarioEditIntRangeView : ScenarioEditEntryView
	{
		[SerializeField]
		private TMP_InputField intInputMin;

		[SerializeField]
		private TMP_InputField intInputMax;

		private IntRange currentValues;

		private IntRange minMaxRange;

		public event Action<IntRange, ScenarioEditEntryView> ValueChanged;

		protected override void Awake()
		{
			base.Awake();
			intInputMin.onEndEdit.AddListener(OnInputMinValueChanged);
			intInputMax.onEndEdit.AddListener(OnInputMaxValueChanged);
		}

		public void SetDefaults(string label, IntRange minMaxRange, IntRange currentValues)
		{
			SetDefaults(label);
			this.minMaxRange = new IntRange(minMaxRange.Min, minMaxRange.Max);
			this.currentValues = new IntRange(currentValues.Min, currentValues.Max);
			intInputMin.SetTextWithoutNotify(currentValues.Min.ToString());
			intInputMax.SetTextWithoutNotify(currentValues.Max.ToString());
		}

		private void OnInputMinValueChanged(string value)
		{
			int min = ScenarioEditEntryView.ClampMin(value, intInputMax.text, minMaxRange).Min;
			intInputMin.SetTextWithoutNotify(min.ToString());
			currentValues = new IntRange(min, currentValues.Max);
			Notify();
		}

		private void OnInputMaxValueChanged(string value)
		{
			int max = ScenarioEditEntryView.ClampMax(intInputMin.text, value, minMaxRange).Max;
			intInputMax.SetTextWithoutNotify(max.ToString());
			currentValues = new IntRange(currentValues.Min, max);
			Notify();
		}

		private void Notify()
		{
			this.ValueChanged?.Invoke(currentValues, this);
		}
	}
}
