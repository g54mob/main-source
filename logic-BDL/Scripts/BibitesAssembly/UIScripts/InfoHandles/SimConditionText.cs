using System;
using SettingsScripts;
using TMPro;
using UnityEngine;

namespace UIScripts.InfoHandles
{
	public class SimConditionText : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI label;

		public SimCondition simCondition;

		public void Initialize(SimCondition simCondition)
		{
			this.simCondition = simCondition;
			this.simCondition.onEvaluate.AddListener(UpdateText);
			UpdateText();
		}

		public void UpdateText()
		{
			float num = Mathf.Abs(simCondition.rightValue.lastVal - simCondition.leftValue.lastVal);
			Comparator val = simCondition.comparator.val;
			if (val == Comparator.GreaterThan || val == Comparator.LessThan)
			{
				num += 1f;
			}
			if (simCondition.CheckParadigm(SimMetric.Time, SimMetric.Constant))
			{
				label.text = $"{TimeSpan.FromSeconds(Mathf.Round(num)):g} remaining";
			}
			else if (simCondition.CheckParadigm(SimMetric.MaterialCount, SimMetric.Constant))
			{
				label.text = string.Format("{0:F0} {1}{2} remaining", num, simCondition.leftValue.argument.val, (num < 1.5f) ? "" : "s");
			}
			else if (simCondition.CheckParadigm(SimMetric.TagCount, SimMetric.Constant))
			{
				label.text = string.Format("{0:F0} {1} tag{2} remaining", num, simCondition.leftValue.argument.val, (num < 1.5f) ? "" : "s");
			}
			else if (simCondition.CheckParadigm(SimMetric.SpeciesCount, SimMetric.Constant))
			{
				label.text = string.Format("{0:F0} {1}{2} remaining", num, simCondition.leftValue.argument.val, (num < 1.5f) ? "" : "s");
			}
			else if (simCondition.CheckParadigm(SimMetric.MaterialBiomass, SimMetric.Constant))
			{
				label.text = $"{num:F0} {simCondition.leftValue.argument.val} Energy remaining";
			}
			else if (simCondition.CheckParadigm(SimMetric.TagBiomass, SimMetric.Constant))
			{
				label.text = $"{num:F0} {simCondition.leftValue.argument.val} tag Energy remaining";
			}
			else if (simCondition.CheckParadigm(SimMetric.SpeciesBiomass, SimMetric.Constant))
			{
				label.text = $"{num:F0} {simCondition.leftValue.argument.val} Energy remaining";
			}
		}

		private void OnDestroy()
		{
			if (simCondition != null)
			{
				simCondition.onEvaluate.RemoveListener(UpdateText);
			}
		}
	}
}
