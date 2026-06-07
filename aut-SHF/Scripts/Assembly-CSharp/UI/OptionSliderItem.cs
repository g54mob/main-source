using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class OptionSliderItem : OptionItemBase
	{
		[SerializeField]
		private Slider slider;

		[SerializeField]
		private TMP_Text itemName;

		[SerializeField]
		private TMP_Text minText;

		[SerializeField]
		private TMP_Text middleText;

		[SerializeField]
		private TMP_Text maxText;

		[Header("Separator")]
		[SerializeField]
		private GameObject separatorPrefab;

		[SerializeField]
		private RectTransform separatorParent;

		[SerializeField]
		private int defaultSplitCount;

		private Color textColor;

		private void Awake()
		{
		}

		public void Init(OptionSettings.OptionSliderSettings settings, UnityAction<OptionItemBase> onChangeValueAction)
		{
		}

		public override void Init(UnityAction<OptionItemBase> onChangeValueAction)
		{
		}

		public void Init(UnityAction<OptionItemBase> onChangeValueAction, int splitCount)
		{
		}

		public override int GetValue()
		{
			return 0;
		}

		public override void SetValue(int value)
		{
		}

		public void SetMinMaxValue(int min, int max)
		{
		}

		public void SetMinMaxValue(int min, int max, string minText, string midText, string maxText)
		{
		}

		public void SetMinMaxValue(OptionSettings.OptionSliderSettings settings)
		{
		}

		private void SplitGauge(int splitCount)
		{
		}

		public void OnChangeValue(float value)
		{
		}

		public override void DisableItem(bool disable)
		{
		}
	}
}
