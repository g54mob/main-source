using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.InfoHandles
{
	public class RateSliderHandle : InfoSliderHandle
	{
		[Header("Rate Parameters", order = 0)]
		public bool showDefaultTexts = true;

		[Header("Rate References", order = 1)]
		[SerializeField]
		private RectTransform divider;

		[SerializeField]
		private RectTransform positiveFill;

		[SerializeField]
		private RectTransform negativeFill;

		[SerializeField]
		private FloatValueTextHandle positiveText;

		[SerializeField]
		private FloatValueTextHandle negativeText;

		private int sign;

		private int SignOf(float v)
		{
			if (!(v > 0f))
			{
				if (!(v < 0f))
				{
					return 0;
				}
				return -1;
			}
			return 1;
		}

		public override void InitSliderHandle(float valScale, bool updatableScale = true)
		{
			base.InitSliderHandle(valScale, updatableScale);
			OnSignChange(SignOf(value));
		}

		protected override void OnValueChange()
		{
			base.OnValueChange();
			int num = sign;
			sign = SignOf(value);
			if (num != sign)
			{
				OnSignChange(sign);
			}
			if (sign == 0)
			{
				return;
			}
			float x = ScaledX(value) / 2f;
			if (sign > 0)
			{
				positiveFill.sizeDelta = new Vector2(x, 0f);
				if (showDefaultTexts)
				{
					positiveText.UpdateValue(value);
				}
			}
			else
			{
				negativeFill.sizeDelta = new Vector2(x, 0f);
				if (showDefaultTexts)
				{
					negativeText.UpdateValue(value);
				}
			}
		}

		private void OnSignChange(int v = 0)
		{
			positiveFill.gameObject.SetActive(v > 0);
			negativeFill.gameObject.SetActive(v < 0);
			positiveText.gameObject.SetActive(showDefaultTexts && v > 0);
			negativeText.gameObject.SetActive(showDefaultTexts && v < 0);
		}

		protected override void UpdatePixelUnitRatio(float ratio)
		{
			base.UpdatePixelUnitRatio(ratio);
			positiveFill.GetComponent<Image>().pixelsPerUnitMultiplier = ratio;
			negativeFill.GetComponent<Image>().pixelsPerUnitMultiplier = ratio;
			positiveText.text.margin = new Vector4(0f, pixelLength, 5f * pixelLength, pixelLength);
			negativeText.text.margin = new Vector4(5f * pixelLength, pixelLength, 0f, pixelLength);
			divider.sizeDelta = new Vector2(2f * pixelLength, divider.sizeDelta.y);
		}
	}
}
