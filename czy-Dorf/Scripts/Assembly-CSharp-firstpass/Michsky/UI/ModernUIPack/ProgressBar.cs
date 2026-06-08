using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class ProgressBar : MonoBehaviour
	{
		public float currentPercent;

		public int speed;

		public float maxValue = 100f;

		public Image loadingBar;

		public TextMeshProUGUI textPercent;

		public bool isOn;

		public bool restart;

		public bool invert;

		public bool isPercent = true;

		private void Start()
		{
			if (!isOn)
			{
				loadingBar.fillAmount = currentPercent / maxValue;
				textPercent.text = ((int)currentPercent).ToString("F0") + "%";
			}
		}

		private void Update()
		{
			if (isOn)
			{
				if (currentPercent <= maxValue && !invert)
				{
					currentPercent += (float)speed * Time.deltaTime;
				}
				else if (currentPercent >= 0f && invert)
				{
					currentPercent -= (float)speed * Time.deltaTime;
				}
				if (currentPercent >= maxValue && speed != 0 && restart && !invert)
				{
					currentPercent = 0f;
				}
				else if (currentPercent == 0f && speed != 0 && restart && invert)
				{
					currentPercent = maxValue;
				}
				loadingBar.fillAmount = currentPercent / maxValue;
				if (isPercent)
				{
					textPercent.text = ((int)currentPercent).ToString("F0") + "%";
				}
				else
				{
					textPercent.text = ((int)currentPercent).ToString("F0");
				}
			}
		}

		public void UpdateUI()
		{
			loadingBar.fillAmount = currentPercent / maxValue;
			textPercent.text = ((int)currentPercent).ToString("F0") + "%";
		}
	}
}
