using Restory.TimeSystems;
using TMPro;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.InteractiveObjects
{
	public class ClockDisplayColorSwitcher : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI timeText;

		[SerializeField]
		private Color defaultColor;

		[SerializeField]
		private Color nightColor;

		private MainDayTimeSwitchingService mainDayTimeSwitchingService;

		[Inject]
		private void Construct(MainDayTimeSwitchingService mainDayTimeSwitchingService)
		{
			this.mainDayTimeSwitchingService = mainDayTimeSwitchingService;
			if (base.isActiveAndEnabled)
			{
				UpdateColor();
				this.mainDayTimeSwitchingService.OnDayTimeChanged += ResolveDayTimeChanged;
			}
		}

		private void OnEnable()
		{
			if ((bool)mainDayTimeSwitchingService)
			{
				UpdateColor();
				mainDayTimeSwitchingService.OnDayTimeChanged += ResolveDayTimeChanged;
			}
		}

		private void OnDisable()
		{
			if ((bool)mainDayTimeSwitchingService)
			{
				mainDayTimeSwitchingService.OnDayTimeChanged -= ResolveDayTimeChanged;
			}
		}

		private void ResolveDayTimeChanged()
		{
			UpdateColor();
		}

		private void UpdateColor()
		{
			timeText.color = ((mainDayTimeSwitchingService.CurrentDayTime == MainDayTimes.AfterWork) ? nightColor : defaultColor);
		}
	}
}
