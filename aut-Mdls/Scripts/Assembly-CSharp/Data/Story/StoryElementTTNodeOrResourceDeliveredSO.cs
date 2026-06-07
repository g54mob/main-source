#define ENABLE_DEBUG_ERRORS
using Data.FactoryFloor.Resources;
using Data.Statistics;
using Events.FactoryFloor;
using Events.UI.TechTree;
using UnityEngine;
using Utils;

namespace Data.Story
{
	[CreateAssetMenu(fileName = "StoryElementTTNodeOrResourceDeliveredSO", menuName = "Story/StoryElementTTNodeOrResourceDeliveredSO")]
	public class StoryElementTTNodeOrResourceDeliveredSO : StoryElementSO
	{
		[SerializeField]
		private StatisticsSO _statisticsSO;

		[SerializeField]
		private ResourceDataSO _resourceData;

		[SerializeField]
		private int _targetResourcesDelivered = 1;

		[SerializeField]
		private ResourceDeliveredEventSO _resourceDelivered;

		[SerializeField]
		private NodeUnlockedEvent _nodeUnlockedEvent;

		[SerializeField]
		private TechTreeNodeSO _techTreeNode;

		[SerializeField]
		private UnlockedTechTreeNodesPersistentSO _unlockedTechTreeNodes;

		public override void Initialize()
		{
			if (_techTreeNode == null || !_unlockedTechTreeNodes.TechTreeSo.Nodes.Contains(_techTreeNode))
			{
				this.LogError("Linked tech tree node is null or part of an old tech tree. story won't work properly. Auto-completing to prevent softlock.", "Initialize", 26);
				TryExecute();
			}
			else if (HasDeliveredEnoughResources(_resourceData, _targetResourcesDelivered) || _techTreeNode.IsUnlocked)
			{
				TryExecute();
			}
			else
			{
				_resourceDelivered.RegisterMainThread(OnResourceDelivered);
				_nodeUnlockedEvent.Register(OnNodeUnlocked);
			}
		}

		private void OnNodeUnlocked(TechTreeNodeSO unlockedNode)
		{
			if (_techTreeNode == unlockedNode)
			{
				TryExecute();
				_nodeUnlockedEvent.UnRegister(OnNodeUnlocked);
				_resourceDelivered.UnRegisterMainThread(OnResourceDelivered);
			}
		}

		private void OnResourceDelivered(Resource resource)
		{
			if (HasDeliveredEnoughResources(_resourceData, _targetResourcesDelivered))
			{
				TryExecute();
				_nodeUnlockedEvent.UnRegister(OnNodeUnlocked);
				_resourceDelivered.UnRegisterMainThread(OnResourceDelivered);
			}
		}

		private bool HasDeliveredEnoughResources(ResourceDataSO resourceData, int targetResourcesDelivered)
		{
			return _statisticsSO.GetDeliveredStatistic(resourceData.ID) >= targetResourcesDelivered;
		}

		public override void Destroy()
		{
			_resourceDelivered.UnRegisterMainThread(OnResourceDelivered);
			_nodeUnlockedEvent.UnRegister(OnNodeUnlocked);
		}
	}
}
