using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[CreateAssetMenu(fileName = "StoryHelperReferences", menuName = "ScriptableObjects/StoryHelperReferences", order = 1)]
	public class StoryHelperReferences : ScriptableObject
	{
		public List<string> gameItemTemplateIds;

		public List<string> unlockableGameItemTemplateIds;

		public List<string> weaponTemplateIds;

		public List<string> templateIds;

		public List<string> zoneIds;

		public List<string> storyFlags;

		public List<string> conversationSpawnableItems;

		public List<string> conversationThemeIds;

		public List<string> vipConversationThemeIds;

		public List<string> randomStoryGroupIds;

		public List<string> greenbackRewardIds;
	}
}
