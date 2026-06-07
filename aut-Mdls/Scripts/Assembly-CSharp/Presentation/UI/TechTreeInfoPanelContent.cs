using System.Collections.Generic;
using Data.TechTree.Behaviours;
using Events.UI;
using UnityEngine;

namespace Presentation.UI
{
	public class TechTreeInfoPanelContent : InfoPanelContent
	{
		[SerializeField]
		private UpdateInfoPanelEvent _updateTechTreeInfoPanelEvent;

		[SerializeField]
		private string _title;

		[SerializeField]
		private string _text;

		private bool _hasEnoughDataShards = true;

		private bool _hasEnoughRank = true;

		private bool _hasAllIncomingNodesUnlocked = true;

		private bool _showTitle;

		private List<AbstractTechTreeNodeBehaviour> _nodeBehaviours;

		public void UpdateContent(string title, string text, List<AbstractTechTreeNodeBehaviour> nodeBehaviours)
		{
			_text = text;
			_title = title;
			_nodeBehaviours = nodeBehaviours;
		}

		public void UpdateWarnings(bool hasEnoughDataShards, bool hasEnoughRank, bool hasAllIncomingNodesUnlocked)
		{
			_hasEnoughDataShards = hasEnoughDataShards;
			_hasEnoughRank = hasEnoughRank;
			_hasAllIncomingNodesUnlocked = hasAllIncomingNodesUnlocked;
			_updateTechTreeInfoPanelEvent.Fire(GetInfoPanelDto());
		}

		public void UpdateDoShowTitle(bool showTitle, bool hasEnoughDataShards, bool hasEnoughRank)
		{
			_showTitle = showTitle;
			_hasEnoughDataShards = hasEnoughDataShards;
			_hasEnoughRank = hasEnoughRank;
			_updateTechTreeInfoPanelEvent.Fire(GetInfoPanelDto());
		}

		protected override InfoPanelDto GetInfoPanelDto()
		{
			return new TechTreeInfoPanelDto(_title, _text, _hasEnoughDataShards, _hasEnoughRank, _hasAllIncomingNodesUnlocked, _showTitle, _nodeBehaviours);
		}
	}
}
