using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Presenters.PC.Apps.Hacking
{
	public class GUI_DeviceHackingProgress : MonoBehaviour
	{
		[SerializeField]
		private Slider progressSlider;

		private float progressMinValue;

		private float progressMaxValue;

		private float progress;

		public float Progress => progress;

		public bool IsComplete => progress >= progressMaxValue;

		private void Awake()
		{
			progressMinValue = progressSlider.minValue;
			progressMaxValue = progressSlider.maxValue;
			progress = progressMinValue;
			progressSlider.value = progress;
		}

		public void Show()
		{
			base.gameObject.SetActive(value: true);
		}

		public void Hide()
		{
			base.gameObject.SetActive(value: false);
		}

		public void UpdateProgress(float progressDelta)
		{
			progress = Mathf.Clamp01(progress += progressDelta);
			progressSlider.value = progress;
		}
	}
}
