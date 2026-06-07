using UnityEngine;
using UnityEngine.Events;

namespace SkyBrave_Toolkit.Scripts.Components
{
	public class TimerComponent : MonoBehaviour
	{
		[Header("Logic")]
		public bool IsTimerActive = true;

		public float RemainingSeconds;

		[SerializeField]
		private UnityEvent _onTimerEnd;

		[Header("Parameters")]
		public float minRandomTime = 0.1f;

		public float maxRandomTime = 1f;

		private void Update()
		{
			if (IsTimerActive && RemainingSeconds != 0f)
			{
				RemainingSeconds -= Time.deltaTime;
				CheckForTimerEnd();
			}
		}

		public void StartTimer(float duration)
		{
			if (!(RemainingSeconds > 0f))
			{
				RemainingSeconds = duration;
				ActivateTimer();
			}
		}

		public void ResetTimer()
		{
			RemainingSeconds = 0f;
		}

		public void ToggleTimer()
		{
			IsTimerActive = !IsTimerActive;
		}

		public void ActivateTimer()
		{
			IsTimerActive = true;
		}

		public void DeactivateTimer()
		{
			IsTimerActive = false;
		}

		private void CheckForTimerEnd()
		{
			if (!(RemainingSeconds > 0f))
			{
				ResetTimer();
				_onTimerEnd.Invoke();
			}
		}

		public void StartRandomTimer()
		{
			StartTimer(Random.Range(minRandomTime, maxRandomTime));
		}
	}
}
