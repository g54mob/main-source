using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.InfoHandles
{
	public class ValueSliderHandle : InfoSliderHandle
	{
		[Header("Value References", order = 1)]
		[SerializeField]
		private RectTransform fill;

		protected override void OnValueChange()
		{
			base.OnValueChange();
			float x = ScaledX(value);
			fill.sizeDelta = new Vector2(x, 0f);
		}

		protected override void UpdatePixelUnitRatio(float ratio)
		{
			base.UpdatePixelUnitRatio(ratio);
			fill.GetComponent<Image>().pixelsPerUnitMultiplier = ratio;
		}
	}
}
