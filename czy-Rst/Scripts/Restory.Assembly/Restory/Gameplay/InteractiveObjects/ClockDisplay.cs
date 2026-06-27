using System;
using Restory.Gameplay.TimeSystems;
using TMPro;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.InteractiveObjects
{
	public class ClockDisplay : MonoBehaviour, ITimeChangeReceiver
	{
		[SerializeField]
		private TextMeshProUGUI timeText;

		[SerializeField]
		private string timeFormat = "HH : mm";

		private GameCalendar gameCalendar;

		private int currentMinute;

		[Inject]
		private void Construct(GameCalendar gameCalendar)
		{
			this.gameCalendar = gameCalendar;
			if (base.isActiveAndEnabled)
			{
				UpdateDisplay(gameCalendar.CurrentDateTime);
				gameCalendar.AddSubscriber(this);
			}
		}

		private void OnEnable()
		{
			if ((bool)gameCalendar)
			{
				UpdateDisplay(gameCalendar.CurrentDateTime);
				gameCalendar.AddSubscriber(this);
			}
		}

		private void OnDisable()
		{
			if ((bool)gameCalendar)
			{
				gameCalendar.RemoveSubscriber(this);
			}
		}

		private void UpdateDisplay(DateTime time)
		{
			currentMinute = time.Minute;
			timeText.text = time.ToString(timeFormat);
		}

		public void ProcessTimeChanged()
		{
			if (currentMinute != gameCalendar.CurrentDateTime.Minute)
			{
				UpdateDisplay(gameCalendar.CurrentDateTime);
			}
		}
	}
}
