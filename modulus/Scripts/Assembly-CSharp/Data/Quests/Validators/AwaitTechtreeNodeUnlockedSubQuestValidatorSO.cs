#define ENABLE_DEBUG_ERRORS
using Events.UI.TechTree;
using UnityEngine;
using Utils;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Await Tech Tree Node Unlocked", fileName = "AwaitTechTreeNodeUnlocked", order = 11)]
	public class AwaitTechtreeNodeUnlockedSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private NodeUnlockedEvent _nodeUnlockedEvent;

		[SerializeField]
		private TechTreeNodeSO _techTreeNode;

		[SerializeField]
		private UnlockedTechTreeNodesPersistentSO _unlockedTechTreeNodes;

		private bool _isSetup;

		private bool _nodeUnlocked;

		public override bool IsValid()
		{
			if (!_isSetup)
			{
				_isSetup = true;
				if (_techTreeNode == null || !_unlockedTechTreeNodes.TechTreeSo.Nodes.Contains(_techTreeNode))
				{
					this.LogError("Linked tech tree node is null or part of an old tech tree. subquest won't work properly. Auto-completing to prevent softlock.", "IsValid", 24);
					return true;
				}
				if (_techTreeNode.IsUnlocked)
				{
					_nodeUnlocked = true;
				}
				else
				{
					_nodeUnlockedEvent.Register(OnNodeUnlocked);
				}
			}
			return _nodeUnlocked;
		}

		private void OnNodeUnlocked(TechTreeNodeSO unlockedNode)
		{
			if (_techTreeNode == unlockedNode)
			{
				_nodeUnlocked = true;
			}
		}

		public override void Reset()
		{
			_nodeUnlocked = false;
			_isSetup = false;
			_nodeUnlockedEvent.UnRegister(OnNodeUnlocked);
		}
	}
}
