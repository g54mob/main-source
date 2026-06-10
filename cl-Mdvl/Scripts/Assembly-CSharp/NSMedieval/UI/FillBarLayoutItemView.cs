using System.Collections.Generic;
using System.Linq;
using NSMedieval.Enums;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class FillBarLayoutItemView : LayoutGroupItemView
	{
		private readonly int textIndex;

		private readonly int sliderIndex = 2;

		private readonly int leftArrowIndex = 3;

		private readonly int rightArrowIndex = 4;

		private readonly int thresholdParent = 5;

		private readonly int targetIndex = 6;

		private readonly int labelIndex = 7;

		private readonly int disabledOverlayIndex = 8;

		[SerializeField]
		private Image fillBarImage;

		private Slider slider;

		private TMP_Text sliderText;

		private readonly List<LayoutGroupItemView> thresholdBars = new List<LayoutGroupItemView>();

		private readonly string defaultFill = "fill_bar_inner_part";

		private readonly string lockedFill = "fill_bar_inner_part_orange";

		private static int ImageIndex => 1;

		public Slider GetSlider
		{
			get
			{
				if (sliderIndex < 0 || sliderIndex >= base.GroupItems.Count)
				{
					return null;
				}
				return slider = ((slider == null) ? base.GroupItems[sliderIndex].GetComponent<Slider>() : slider);
			}
		}

		public TMP_Text GetSliderText
		{
			get
			{
				if (GetSlider == null)
				{
					return null;
				}
				return sliderText = ((base.GroupItems[labelIndex] == null) ? GetSlider.GetComponentInChildren<TMP_Text>() : base.GroupItems[labelIndex].GetComponent<TMP_Text>());
			}
		}

		private StatTooltipView TooltipView => base.TooltipNew as StatTooltipView;

		public override void SetTextColor(string colorStyle)
		{
			SetTextColor(textIndex, colorStyle);
		}

		public void SetDataText(string text)
		{
			SetText(textIndex, text);
		}

		public void SetDataText(string text, int index)
		{
			SetText(index, text);
		}

		public void SetDataText(string text, string id)
		{
			SetText(textIndex, text, id);
		}

		public void SetDataText(string text, string id, HumanoidInstance humanoid)
		{
			SetText(textIndex, text, id, humanoid);
		}

		public void SetImageData(string path, string imageKey = "")
		{
			if (!(path == string.Empty) || !(imageKey == string.Empty))
			{
				SetImage(ImageIndex, path);
			}
		}

		public void SetLocked(string text, string textId, List<float> values, List<KeyValuePair<string, string>> tooltipKeys)
		{
			SetDataText(text + " (" + base.Localize.GetText("lock_state_locked") + ")", textId);
			GetSliderText.text = string.Empty;
			SetSliderTooltip(tooltipKeys);
			SetDisabledOverlayActive(active: false);
			HandleLockedStateChange(isLocked: true);
			SetValues(values);
			SetThresholds(new List<float>());
			base.GroupItems[leftArrowIndex].SetActive(value: false);
			base.GroupItems[rightArrowIndex].SetActive(value: false);
			base.GroupItems[targetIndex].SetActive(value: false);
		}

		public void SetDisabled(string text, string textId, List<KeyValuePair<string, string>> tooltipKeys)
		{
			SetDataText(text, textId);
			SetTextColor("DarkGray");
			SetSliderTooltip(tooltipKeys);
			SetDisabledOverlayActive(active: true);
			HandleLockedStateChange(isLocked: false);
			SetValues(new List<float> { 0f, 1f, 0f });
			SetThresholds(new List<float>());
			base.GroupItems[leftArrowIndex].SetActive(value: false);
			base.GroupItems[rightArrowIndex].SetActive(value: false);
			base.GroupItems[targetIndex].SetActive(value: false);
		}

		public void SetBasicData(string text, string textId, string path, string imageKey = "")
		{
			SetDataText(text, textId);
			SetImageData(path, imageKey);
			SetTextColor("Normal");
			SetDisabledOverlayActive(active: false);
			HandleLockedStateChange(isLocked: false);
		}

		public void SetBasicData(string text, string textId, string path, string imageKey, List<KeyValuePair<string, string>> tooltipKeys, StatTrend trend, List<float> values, List<float> thresholdPercents, float? target, bool invertArrows, string barLabelText)
		{
			SetBasicData(text, textId, path, imageKey);
			SetSliderTooltip(tooltipKeys);
			SetArrows(trend, invertArrows);
			GetSliderText.text = barLabelText;
			if (values != null)
			{
				SetValues(values);
			}
			if (thresholdPercents != null)
			{
				SetThresholds(thresholdPercents);
			}
			if (!(base.GroupItems[targetIndex] == null))
			{
				if (!target.HasValue)
				{
					base.GroupItems[targetIndex].SetActive(value: false);
				}
				else
				{
					SetTarget(target.Value);
				}
			}
		}

		private void SetTarget(float target)
		{
			target = Mathf.Clamp(target, 0f, 100f);
			base.GroupItems[targetIndex].SetActive(value: true);
			base.GroupItems[targetIndex].GetComponent<RectTransform>().anchoredPosition = new Vector2(target / 100f * FillbarRect().width, 0f);
		}

		private void SetThresholds(IEnumerable<float> thresholdPercents)
		{
			foreach (LayoutGroupItemView thresholdBar2 in thresholdBars)
			{
				thresholdBar2.gameObject.SetActive(value: false);
			}
			foreach (float thresholdPercent in thresholdPercents)
			{
				LayoutGroupItemView thresholdBar = GetThresholdBar();
				thresholdBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(thresholdPercent * FillbarRect().width, 0f);
				thresholdBar.gameObject.SetActive(value: true);
			}
		}

		private LayoutGroupItemView GetThresholdBar()
		{
			LayoutGroupItemView layoutGroupItemView = thresholdBars.FirstOrDefault((LayoutGroupItemView b) => !b.gameObject.activeSelf);
			if (layoutGroupItemView == null)
			{
				layoutGroupItemView = Object.Instantiate(base.GroupItems[thresholdParent].GetComponent<LayoutGroupView>().Prefab, base.GroupItems[thresholdParent].transform).GetComponent<LayoutGroupItemView>();
				thresholdBars.Add(layoutGroupItemView);
			}
			return layoutGroupItemView;
		}

		private void SetValues(List<float> values)
		{
			GetSlider.minValue = values[0];
			GetSlider.maxValue = values[1];
			GetSlider.value = values[2];
		}

		public void SetSliderTooltip(List<KeyValuePair<string, string>> tooltipKeys)
		{
			if (!(TooltipView == null))
			{
				TooltipView.SetTooltipData(tooltipKeys);
				TooltipView.RefreshTooltip();
			}
		}

		private void SetArrows(StatTrend trend, bool invertArrows)
		{
			switch (trend)
			{
			case StatTrend.Up:
				base.GroupItems[leftArrowIndex].SetActive(value: false);
				base.GroupItems[rightArrowIndex].SetActive(value: true);
				break;
			case StatTrend.Down:
				base.GroupItems[leftArrowIndex].SetActive(value: true);
				base.GroupItems[rightArrowIndex].SetActive(value: false);
				break;
			default:
				if (base.GroupItems[leftArrowIndex] != null)
				{
					base.GroupItems[leftArrowIndex].SetActive(value: false);
				}
				if (base.GroupItems[rightArrowIndex] != null)
				{
					base.GroupItems[rightArrowIndex].SetActive(value: false);
				}
				break;
			}
			if (invertArrows)
			{
				Sprite sprite = AssetUtils.GetSprite("green_arrow_l");
				Sprite sprite2 = AssetUtils.GetSprite("red_arrow_r");
				base.GroupItems[leftArrowIndex].GetComponent<Image>().sprite = sprite;
				base.GroupItems[rightArrowIndex].GetComponent<Image>().sprite = sprite2;
			}
		}

		private Rect FillbarRect()
		{
			return base.GroupItems[thresholdParent].GetComponent<RectTransform>().rect;
		}

		private void HandleLockedStateChange(bool isLocked)
		{
			if (!(fillBarImage == null))
			{
				if (isLocked)
				{
					fillBarImage.sprite = AssetUtils.GetSprite(lockedFill);
				}
				else
				{
					fillBarImage.sprite = AssetUtils.GetSprite(defaultFill);
				}
			}
		}

		private void SetDisabledOverlayActive(bool active)
		{
			if (base.GroupItems.Count > disabledOverlayIndex)
			{
				base.GroupItems[disabledOverlayIndex]?.SetActive(active);
			}
		}
	}
}
