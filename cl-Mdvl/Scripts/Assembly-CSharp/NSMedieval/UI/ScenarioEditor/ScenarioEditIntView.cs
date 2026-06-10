using System;
using NSEipix.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI.ScenarioEditor
{
	public class ScenarioEditIntView : ScenarioEditEntryView
	{
		[SerializeField]
		private TMP_InputField intInput;

		[SerializeField]
		private TMP_Text suffixLabel;

		private IntRange minMaxRange;

		protected IntRange MinMaxRange => minMaxRange;

		protected TMP_InputField IntInput => intInput;

		public event Action<int, ScenarioEditEntryView> ValueChanged;

		protected override void Awake()
		{
			base.Awake();
			IntInput.onEndEdit.AddListener(OnInputValueChanged);
		}

		public int GetValue()
		{
			return ScenarioEditEntryView.Clamp(intInput.text, minMaxRange);
		}

		public void SetDefaults(string label, IntRange minMaxRange, int currentValue, string suffix = "")
		{
			SetDefaults(label);
			this.minMaxRange = new IntRange(minMaxRange.Min, minMaxRange.Max);
			suffixLabel.gameObject.SetActive(!suffix.Equals(string.Empty));
			if (!suffix.Equals(string.Empty))
			{
				suffixLabel.SetText(suffix);
			}
			intInput.SetTextWithoutNotify(currentValue.ToString());
			LayoutRebuilder.MarkLayoutForRebuild(GetComponent<RectTransform>());
		}

		protected virtual void OnInputValueChanged(string value)
		{
			int arg = ScenarioEditEntryView.Clamp(value, minMaxRange);
			IntInput.SetTextWithoutNotify(arg.ToString());
			this.ValueChanged?.Invoke(arg, this);
		}
	}
}
