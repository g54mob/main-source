using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public class BatteryDisplay : MonoBehaviour
	{
		[SerializeField]
		private Image _batteryImage;

		[SerializeField]
		private TMP_Text _batteryText;

		[SerializeField]
		private Image _batteryLightImage;

		[SerializeField]
		private Sprite _batteryEmptySprite;

		[SerializeField]
		private Sprite _batteryQuarterSprite;

		[SerializeField]
		private Sprite _batteryHalfSprite;

		[SerializeField]
		private Sprite _batteryFullSprite;

		[SerializeField]
		private Gradient _batteryLightGradient;

		private void OnEnable()
		{
			if (!(_batteryImage == null) && !(_batteryText == null))
			{
				float randomBatteryPercentage = GetRandomBatteryPercentage();
				_batteryText.text = randomBatteryPercentage + "%";
				_batteryImage.sprite = ((randomBatteryPercentage > 66f) ? _batteryFullSprite : ((randomBatteryPercentage > 33f) ? _batteryHalfSprite : ((randomBatteryPercentage >= 1f) ? _batteryQuarterSprite : _batteryEmptySprite)));
				if (_batteryLightImage != null)
				{
					_batteryLightImage.color = _batteryLightGradient.Evaluate(randomBatteryPercentage / 100f);
				}
			}
		}

		private float GetRandomBatteryPercentage()
		{
			return Mathf.Floor(Random.Range(0f, 100f) * 2f + 0.5f) / 2f;
		}
	}
}
