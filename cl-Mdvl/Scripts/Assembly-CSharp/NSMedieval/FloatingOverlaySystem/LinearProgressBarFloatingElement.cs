using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.FloatingOverlaySystem
{
	public class LinearProgressBarFloatingElement : ProgressBarFloatingElement
	{
		[SerializeField]
		private Image fillImage;

		[SerializeField]
		private GameObject trailFill;

		[SerializeField]
		private Slider fillSlider;

		[SerializeField]
		private Slider trailSlider;

		[SerializeField]
		private float trailRefreshDelay = 1f;

		[SerializeField]
		private float trailRefreshDelayIncrease = 0.4f;

		private float trailRefreshDelayTimer;

		private bool isTrailEnabled;

		public void SetTrailEnabled(bool enabled)
		{
			isTrailEnabled = enabled;
			trailFill.SetActive(enabled);
			trailSlider.gameObject.SetActive(enabled);
			trailRefreshDelayTimer = 0f;
		}

		protected override void OnSetup()
		{
			fillSlider.minValue = 0f;
			fillSlider.maxValue = 1f;
			trailSlider.minValue = 0f;
			trailSlider.maxValue = 1f;
		}

		protected override void OnValueUpdated()
		{
			float value = fillSlider.value;
			if (isTrailEnabled)
			{
				if (trailRefreshDelayTimer <= 0.1f)
				{
					trailSlider.value = value;
					trailRefreshDelayTimer = trailRefreshDelay;
				}
				else
				{
					trailRefreshDelayIncrease += trailRefreshDelayIncrease;
					trailRefreshDelayTimer = Mathf.Min(trailRefreshDelayTimer, trailRefreshDelay);
				}
			}
			fillSlider.value = base.Value;
		}

		protected override void Update()
		{
			base.Update();
			if (isTrailEnabled)
			{
				trailRefreshDelayTimer -= Time.unscaledDeltaTime;
				if (trailRefreshDelayTimer <= 0f - trailRefreshDelay)
				{
					trailSlider.value = fillSlider.value;
				}
			}
		}
	}
}
