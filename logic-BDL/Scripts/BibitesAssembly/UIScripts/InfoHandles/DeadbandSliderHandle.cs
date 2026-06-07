using UnityEngine;

namespace UIScripts.InfoHandles
{
	public class DeadbandSliderHandle : ValueSliderHandle
	{
		[Header("Progress References", order = 1)]
		public RectTransform startIndicator;

		public RectTransform endIndicator;

		public float startValue;

		public float endValue;

		private void Awake()
		{
			OnScaleRaised.AddListener(UpdateIndicators);
			UpdatePixelUnitRatio(targetppu);
		}

		public void SetDeadband(float deadbandStart, float deadbandEnd)
		{
			startValue = deadbandStart;
			endValue = deadbandEnd;
			UpdatePixelUnitRatio(targetppu);
			UpdateIndicators();
		}

		public void InitDeadbandHandle(float valScale, float deadbandStart, float deadbandEnd, bool updatableScale = true)
		{
			base.InitSliderHandle(valScale, updatableScale);
			SetDeadband(deadbandStart, deadbandEnd);
		}

		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			UpdateIndicators();
		}

		private void UpdateIndicators(float arg = 0f)
		{
			float x = ScaledX(startValue) - 4f * pixelLength;
			startIndicator.anchoredPosition = new Vector2(x, 0f);
			startIndicator.sizeDelta = new Vector2(2f * pixelLength, 4f * pixelLength);
			x = ScaledX(endValue) - 4f * pixelLength;
			endIndicator.anchoredPosition = new Vector2(x, 0f);
			endIndicator.sizeDelta = new Vector2(2f * pixelLength, 4f * pixelLength);
		}
	}
}
