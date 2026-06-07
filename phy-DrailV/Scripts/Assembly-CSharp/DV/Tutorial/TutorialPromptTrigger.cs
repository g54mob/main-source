using DV.Utils;
using UnityEngine;

namespace DV.Tutorial
{
	[RequireComponent(typeof(TutorialPlayerDetector))]
	public class TutorialPromptTrigger : MonoBehaviour
	{
		public string message;

		public bool autoDeactivate = true;

		public bool floatieMode;

		private TutorialPlayerDetector detector;

		private void Awake()
		{
			detector = GetComponent<TutorialPlayerDetector>();
		}

		private void OnEnable()
		{
			detector.PlayerPresenceChanged += OnPresenceChanged;
			detector.StartChecking();
		}

		private void OnDisable()
		{
			detector.PlayerPresenceChanged -= OnPresenceChanged;
		}

		private void OnPresenceChanged(TutorialPlayerDetector sender, bool playerPresent)
		{
			if (playerPresent)
			{
				if (floatieMode)
				{
					SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(message, null);
				}
				else
				{
					SingletonBehaviour<TutorialHelper>.Instance.ShowPrompt(message, pause: false, null);
				}
				if (autoDeactivate)
				{
					base.gameObject.SetActive(value: false);
				}
			}
		}
	}
}
