using UnityEngine;

namespace Restory.Data.PC
{
	[CreateAssetMenu(fileName = "HackingAppSettings - name", menuName = "Restory/PC/HackingAppSettings")]
	public class DeviceHackingAppSettings : ScriptableObject
	{
		[Header("Progress")]
		[SerializeField]
		[Range(0f, 0.5f)]
		[Tooltip("Hack progress gained on first valid keystroke.")]
		private float initialHackingProgress = 0.08f;

		[SerializeField]
		[Range(0.001f, 0.4f)]
		[Tooltip("Hack progress gained per valid keystroke.")]
		private float hackingSpeed = 0.008f;

		[SerializeField]
		[Range(0.001f, 0.4f)]
		[Tooltip("Hack progress drained per second when regressing.")]
		private float regressSpeed = 0.02f;

		[SerializeField]
		[Range(0f, 4f)]
		[Tooltip("Seconds with no regression after finishing hacking event.")]
		private float regressCooldown = 2f;

		[Space(10f)]
		[Header("Upgrades")]
		[SerializeField]
		[Tooltip("Skips delay event popups.")]
		private bool skipDelay;

		[SerializeField]
		[Tooltip("Skips decision event popups.")]
		private bool skipDecision;

		[SerializeField]
		[Tooltip("Fully automated hacking process.")]
		private bool autoHacking;

		[SerializeField]
		[Range(0.05f, 0.4f)]
		[Tooltip("Speed of autonomous typing. Not used while auto hacking option disabled.")]
		private float autoHackingSpeed = 0.1f;

		[Space(10f)]
		[SerializeField]
		private HackingTimelineSettings timelineSettings;

		[Space(10f)]
		[SerializeField]
		private TypingSettings typingSettings;

		[Space(10f)]
		[SerializeField]
		private ConnectionSettings connectionSettings;

		[Space(10f)]
		[SerializeField]
		private HackingEffectsSettings hackingEffectsSettings;

		public float InitialHackingProgress => initialHackingProgress;

		public float HackingSpeed => hackingSpeed;

		public float RegressSpeed => regressSpeed;

		public float RegressCooldown => regressCooldown;

		public bool SkipDelay => skipDelay;

		public bool SkipDecision => skipDecision;

		public bool AutoHacking => autoHacking;

		public float AutoHackingSpeed => autoHackingSpeed;

		public HackingTimelineSettings TimelineSettings => timelineSettings;

		public TypingSettings TypingSettings => typingSettings;

		public ConnectionSettings ConnectionSettings => connectionSettings;

		public HackingEffectsSettings HackingEffectsSettings => hackingEffectsSettings;
	}
}
