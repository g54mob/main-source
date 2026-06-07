using UnityEngine;
using UnityEngine.InputSystem;

namespace MyStuff.Environment
{
	public class TimeOfDayDevCommands : MonoBehaviour
	{
		[Header("Quick Time Controls (Dev Hotkeys)")]
		[Tooltip("Enable developer hotkeys")]
		[SerializeField]
		private bool enableDevHotkeys;

		[Header("Input System Keys")]
		[Tooltip("Fast forward (hold)")]
		[SerializeField]
		private Key fastForwardKey;

		[Tooltip("Rewind (hold)")]
		[SerializeField]
		private Key rewindKey;

		[Tooltip("Pause/Resume")]
		[SerializeField]
		private Key pauseKey;

		[Tooltip("Jump to dawn")]
		[SerializeField]
		private Key dawnKey;

		[Tooltip("Jump to noon")]
		[SerializeField]
		private Key noonKey;

		[Tooltip("Jump to dusk")]
		[SerializeField]
		private Key duskKey;

		[Tooltip("Jump to midnight")]
		[SerializeField]
		private Key midnightKey;

		private TimeOfDayManager manager;

		private float originalTimeScale;

		private Keyboard keyboard;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void SetHour(int hour)
		{
		}

		public void AdvanceHours(float hours)
		{
		}

		public void SetSpeed(float multiplier)
		{
		}

		public void TogglePause()
		{
		}

		public void PrintTimeInfo()
		{
		}
	}
}
