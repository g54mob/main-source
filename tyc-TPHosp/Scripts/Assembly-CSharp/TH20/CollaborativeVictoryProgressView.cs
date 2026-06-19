using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class CollaborativeVictoryProgressView : MonoBehaviour
	{
		[SerializeField]
		private CollaborativeVictoryComponentItem[] _victoryComponentItems;

		[SerializeField]
		private GameObject[] _victoryItemGameObjects;

		[SerializeField]
		private Image[] _victoryItemImages;

		[SerializeField]
		private GameObject _victoryParentNode;

		private ResearchNetwork _network;

		private IResearchNetworkState _networkState;

		private void Start()
		{
		}

		public void Setup(ResearchNetwork network, IResearchNetworkState networkState)
		{
			_network = network;
			_networkState = networkState;
			List<CollaborativeNode> list = ResearchNetworkUtils.FindVictoryNodes(_network);
			for (int i = 0; i < list.Count && i < _victoryComponentItems.Length; i++)
			{
				GameObjectUtils.SetActive(_victoryComponentItems[i].gameObject, isActive: true);
				_victoryComponentItems[i].Setup(list[i], networkState);
			}
			for (int j = list.Count; j < _victoryComponentItems.Length; j++)
			{
				GameObjectUtils.SetActive(_victoryComponentItems[j].gameObject, isActive: false);
				_victoryComponentItems[j].Setup(null, null);
			}
			CollaborativeProjectDefinition collaborativeProjectDefinition = _networkState.GetProject()?.LocalPlayerData?.Definition;
			if (collaborativeProjectDefinition != null)
			{
				int num = 0;
				for (int k = 0; k < collaborativeProjectDefinition.CompletionRewards.Length && k < _victoryItemImages.Length; k++)
				{
					if (collaborativeProjectDefinition.CompletionRewards[k] is RewardRoomItemMetagame rewardRoomItemMetagame)
					{
						GameObjectUtils.SetActive(_victoryItemGameObjects[k], isActive: true);
						_victoryItemImages[k].overrideSprite = rewardRoomItemMetagame.Definition.Instance.GetIconWithoutBacking();
						num++;
					}
				}
				for (int l = num; l < _victoryItemImages.Length; l++)
				{
					GameObjectUtils.SetActive(_victoryItemGameObjects[l], isActive: false);
				}
			}
			else
			{
				for (int m = 0; m < _victoryItemImages.Length; m++)
				{
					GameObjectUtils.SetActive(_victoryItemGameObjects[m], isActive: false);
				}
			}
		}

		public void Refresh()
		{
			if (_network == null)
			{
				GameObjectUtils.SetActive(base.gameObject, isActive: false);
				return;
			}
			CollaborativeVictoryComponentItem[] victoryComponentItems = _victoryComponentItems;
			for (int i = 0; i < victoryComponentItems.Length; i++)
			{
				victoryComponentItems[i].Refresh();
			}
		}
	}
}
