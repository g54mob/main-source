using System;
using System.Collections.Generic;
using NSEipix.Model;
using NSEipix.View.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI.ScenarioEditor
{
	public class ScenarioEditEntryView : UIView
	{
		[SerializeField]
		private SoundButton deleteButton;

		[SerializeField]
		private SoundButton moreInfoButton;

		[SerializeField]
		private TMP_Text entryLabel;

		public SoundButton DeleteButton => deleteButton;

		public event Action<ScenarioEditEntryView> DeleteEntry;

		public void SetDefaults(string labelText)
		{
			entryLabel.SetText(labelText);
		}

		public void SetInfo(string nameKey, string infoKey)
		{
			moreInfoButton.gameObject.SetActive(value: true);
			moreInfoButton.GetComponent<LocalizedTextTooltipView>().TextKeys = new List<string> { nameKey, infoKey };
			LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
		}

		protected virtual void Awake()
		{
			DeleteButton.onClick.AddListener(OnDelete);
			moreInfoButton.gameObject.SetActive(value: false);
		}

		protected static int Clamp(string value, IntRange range)
		{
			int.TryParse(value, out var result);
			return Clamp(result, range);
		}

		protected static IntRange ClampMin(string minvalue, string maxValue, IntRange range)
		{
			int num = Clamp(minvalue, range);
			int num2 = Clamp(maxValue, range);
			if (num > num2)
			{
				num = num2;
			}
			return new IntRange(num, num2);
		}

		protected static IntRange ClampMax(string minvalue, string maxValue, IntRange range)
		{
			int num = Clamp(minvalue, range);
			int num2 = Clamp(maxValue, range);
			if (num2 < num)
			{
				num2 = num;
			}
			return new IntRange(num, num2);
		}

		private static int Clamp(int value, IntRange range)
		{
			return Mathf.Clamp(value, range.Min, range.Max);
		}

		private void OnDelete()
		{
			this.DeleteEntry?.Invoke(this);
			Hide();
		}
	}
}
