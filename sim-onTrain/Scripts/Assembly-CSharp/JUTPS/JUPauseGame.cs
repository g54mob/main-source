using JUTPS.FX;
using JUTPS.InputEvents;
using JUTPSEditor.JUHeader;
using UnityEngine;
using UnityEngine.Events;

namespace JUTPS
{
	[AddComponentMenu("JU TPS/Utilities/JU Pause Game")]
	public class JUPauseGame : MonoBehaviour
	{
		public static JUPauseGame instance;

		public static bool Paused;

		[JUHeader("Pause Input")]
		public MultipleActionEvent PauseInputs;

		[JUHeader("On Pause Events")]
		public UnityEvent OnPause;

		public UnityEvent OnUnpause;

		private JUSlowmotion SlowmotionInstance;

		private void Start()
		{
			instance = this;
			SlowmotionInstance = Object.FindObjectOfType<JUSlowmotion>();
			PauseInputs.OnButtonsDown.AddListener(Pause);
		}

		private void OnEnable()
		{
			PauseInputs.Enable();
		}

		private void OnDisable()
		{
			PauseInputs.Disable();
		}

		public static void Pause()
		{
			Paused = !Paused;
			Time.timeScale = ((!Paused) ? 1 : 0);
			if (Paused)
			{
				instance.OnPause.Invoke();
			}
			else
			{
				instance.OnUnpause.Invoke();
			}
			instance.SlowmotionInstance.EnableSlowmotion = !Paused;
		}
	}
}
