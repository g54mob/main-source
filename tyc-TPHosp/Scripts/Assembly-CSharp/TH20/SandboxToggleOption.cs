using UnityEngine;

namespace TH20
{
	public class SandboxToggleOption : SandboxOption
	{
		[SerializeField]
		private LocalisedString LocalisedDisplayName;

		public string DisplayName => LocalisedDisplayName.Translation;

		public string AnalyticsName => LocalisedDisplayName.ToAnalyticsTermString();

		public LocalisedString LocalisedName => LocalisedDisplayName;
	}
}
