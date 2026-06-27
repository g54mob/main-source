using System;
using Restory.Gameplay.TimeSystems;
using TMPro;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	public class SonicBathTimer : MonoBehaviour, ITimeChangeReceiver
	{
		[SerializeField]
		private TextMeshProUGUI timeText;

		[SerializeField]
		private string timeFormat = "hh' : 'mm";

		[SerializeField]
		private string cleaningDoneDisplayMessage = "DONE";

		private GameCalendar gameCalendar;

		private bool isCountdown;

		private DateTime targetDateTime;

		private TimeSpan nextTimeToDisplay;

		public bool IsCountdown => isCountdown;

		public event Action OnCountdownStarted;

		public event Action OnCountdownComplete;

		[Inject]
		private void Construct(GameCalendar gameCalendar)
		{
			this.gameCalendar = gameCalendar;
		}

		private void OnEnable()
		{
			if (!isCountdown)
			{
				TextMeshProUGUI textMeshProUGUI = timeText;
				TimeSpan zero = TimeSpan.Zero;
				textMeshProUGUI.text = zero.ToString(timeFormat);
			}
			else
			{
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

		public bool TryStartCountdown(TimeSpan duration)
		{
			if (isCountdown)
			{
				Debug.LogError("Countdown timer has launched already");
				return false;
			}
			isCountdown = true;
			StartCountdown(duration);
			return true;
		}

		public bool TryStopCountdown()
		{
			if (!isCountdown)
			{
				Debug.LogError("Countdown timer has not launched");
				return false;
			}
			StopCountdown();
			return true;
		}

		public void ProcessTimeChanged()
		{
			if (!isCountdown)
			{
				gameCalendar.RemoveSubscriber(this);
				return;
			}
			DateTime currentDateTime = gameCalendar.CurrentDateTime;
			if (currentDateTime >= targetDateTime)
			{
				CompleteCountdown();
			}
			else
			{
				UpdateDisplay(currentDateTime);
			}
		}

		public void OutputDoneMessage()
		{
			timeText.text = cleaningDoneDisplayMessage;
		}

		public void SkipTimer()
		{
			TextMeshProUGUI textMeshProUGUI = timeText;
			TimeSpan zero = TimeSpan.Zero;
			textMeshProUGUI.text = zero.ToString(timeFormat);
		}

		public SonicBathTimerData Capture()
		{
			return new SonicBathTimerData
			{
				IsCountdown = IsCountdown,
				TargetDateTime = targetDateTime
			};
		}

		public void Restore(SonicBathTimerData data)
		{
			if (data != null && data.IsCountdown)
			{
				targetDateTime = data.TargetDateTime;
				isCountdown = true;
			}
		}

		public void PostRestore()
		{
			if (isCountdown)
			{
				TimeSpan timeSpan = targetDateTime - gameCalendar.CurrentDateTime;
				if (timeSpan < TimeSpan.Zero)
				{
					CompleteCountdown();
				}
				else
				{
					StartCountdown(timeSpan);
				}
			}
		}

		private void StartCountdown(TimeSpan duration)
		{
			DateTime currentDateTime = gameCalendar.CurrentDateTime;
			targetDateTime = currentDateTime.Add(duration);
			nextTimeToDisplay = targetDateTime - currentDateTime;
			UpdateDisplay(currentDateTime);
			gameCalendar.AddSubscriber(this);
			this.OnCountdownStarted?.Invoke();
		}

		private void UpdateDisplay(DateTime currentDateTime)
		{
			TimeSpan timeSpan = targetDateTime - currentDateTime;
			if (timeSpan.TotalSeconds <= 0.0)
			{
				TextMeshProUGUI textMeshProUGUI = timeText;
				TimeSpan zero = TimeSpan.Zero;
				textMeshProUGUI.text = zero.ToString(timeFormat);
			}
			else if (!(nextTimeToDisplay < timeSpan))
			{
				timeText.text = nextTimeToDisplay.ToString(timeFormat);
				nextTimeToDisplay -= TimeSpan.FromMinutes(1.0);
			}
		}

		private void CompleteCountdown()
		{
			StopCountdown();
			this.OnCountdownComplete?.Invoke();
		}

		private void StopCountdown()
		{
			TextMeshProUGUI textMeshProUGUI = timeText;
			TimeSpan zero = TimeSpan.Zero;
			textMeshProUGUI.text = zero.ToString(timeFormat);
			gameCalendar.RemoveSubscriber(this);
			isCountdown = false;
		}
	}
}
