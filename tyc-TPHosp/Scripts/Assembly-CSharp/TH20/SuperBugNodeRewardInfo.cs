using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Superbugs", order = 1027)]
	public class SuperBugNodeRewardInfo : ScriptableObjectWithID
	{
		public Sprite Icon;

		public LocalisedString Title;

		public LocalisedString UndiscoveredDescription;

		public LocalisedString DiscoveredDescription;

		public LocalisedString Tooltip;
	}
}
