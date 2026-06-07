using System;
using UnityEngine;
using UnityEngine.Events;

namespace UIScripts.InfoHandles
{
	public class ProgressSliderHandle : ValueSliderHandle
	{
		[Header("Progress Parameters", order = 0)]
		public float targetValue;

		[Header("Progress References", order = 1)]
		public RectTransform targetIndicator;

		public FloatValueTextHandle targetValueText;

		private bool targetReached;

		[NonSerialized]
		public UnityEvent<bool> OnTargetReachedChange = new UnityEvent<bool>();

		private void Awake()
		{
			OnScaleRaised.AddListener(UpdateIndicator);
			UpdatePixelUnitRatio(targetppu);
		}

		public void SetTargetValue(float targetVal)
		{
			targetValue = targetVal;
			UpdatePixelUnitRatio(targetppu);
			UpdateTargetReached();
		}

		public void InitProgressHandle(float valScale, float targetVal, bool updatableScale = true)
		{
			base.InitSliderHandle(valScale, updatableScale);
			SetTargetValue(targetVal);
		}

		protected override void OnValueChange()
		{
			base.OnValueChange();
			if (!targetReached)
			{
				UpdateTargetReached();
			}
		}

		public override void UpdateScale(float newScale)
		{
			base.UpdateScale(newScale);
			UpdateIndicator();
		}

		private void UpdateTargetReached()
		{
			bool num = targetReached;
			targetReached = value >= targetValue;
			if (num != targetReached)
			{
				OnTargetReachedChange.Invoke(targetReached);
			}
		}

		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			UpdateIndicator();
		}

		private void UpdateIndicator(float arg = 0f)
		{
			float x = ScaledX(targetValue) - 4f * pixelLength;
			targetIndicator.anchoredPosition = new Vector2(x, 0f);
			targetIndicator.sizeDelta = new Vector2(2f * pixelLength, 4f * pixelLength);
			if (targetValueText != null)
			{
				targetValueText.UpdateValue(targetValue);
			}
		}

		protected override void UpdatePixelUnitRatio(float ratio)
		{
			base.UpdatePixelUnitRatio(ratio);
			UpdateIndicator();
		}
	}
}
