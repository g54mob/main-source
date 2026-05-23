using System.Collections.Generic;
using Data.TechTree.Behaviours;

namespace Events.UI
{
	public class TechTreeInfoPanelDto : InfoPanelDto
	{
		public string Title { get; private set; }

		public string Text { get; private set; }

		public bool HasEnoughDataShards { get; private set; }

		public bool HasEnoughRank { get; private set; }

		public bool HasAllIncomingNodesUnlocked { get; private set; }

		public bool ShowTitle { get; private set; }

		public List<AbstractTechTreeNodeBehaviour> NodeBehaviours { get; private set; }

		public TechTreeInfoPanelDto(string title, string text, bool hasEnoughDataShards, bool hasEnoughRank, bool hasAllIncomingNodesUnlockedUnlocked, bool showTitle, List<AbstractTechTreeNodeBehaviour> nodeBehaviours = null)
		{
			Title = title;
			Text = text;
			HasEnoughDataShards = hasEnoughDataShards;
			HasEnoughRank = hasEnoughRank;
			HasAllIncomingNodesUnlocked = hasAllIncomingNodesUnlockedUnlocked;
			ShowTitle = showTitle;
			NodeBehaviours = nodeBehaviours;
		}
	}
}
