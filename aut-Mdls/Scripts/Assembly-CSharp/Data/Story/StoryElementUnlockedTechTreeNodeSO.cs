#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using Events.UI.TechTree;
using UnityEngine;
using Utils;

namespace Data.Story
{
	[CreateAssetMenu(fileName = "StoryElementUnlockedTechTreeNodeSO", menuName = "Story/StoryElementUnlockedTechTreeNodeSO")]
	public class StoryElementUnlockedTechTreeNodeSO : StoryElementSO
	{
		[SerializeField]
		private NodeUnlockedEvent _nodeUnlockedEvent;

		[SerializeField]
		private List<TechTreeNodeSO> _techTreeNodes = new List<TechTreeNodeSO>();

		[SerializeField]
		private UnlockedTechTreeNodesPersistentSO _unlockedTechTreeNodes;

		public override void Initialize()
		{
			if (AllNodesUnlocked())
			{
				TryExecute();
			}
			else
			{
				_nodeUnlockedEvent.Register(OnNodeUnlocked);
			}
		}

		private void OnNodeUnlocked(TechTreeNodeSO unlockedNode)
		{
			if (AllNodesUnlocked())
			{
				TryExecute();
				_nodeUnlockedEvent.UnRegister(OnNodeUnlocked);
			}
		}

		private bool AllNodesUnlocked()
		{
			foreach (TechTreeNodeSO techTreeNode in _techTreeNodes)
			{
				if (techTreeNode == null || !_unlockedTechTreeNodes.TechTreeSo.Nodes.Contains(techTreeNode))
				{
					this.LogError("Linked tech tree node is null or part of an old tech tree. story won't work properly. Auto-completing to prevent softlock.", "AllNodesUnlocked", 38);
					TryExecute();
					return true;
				}
				if (!techTreeNode.IsUnlocked)
				{
					return false;
				}
			}
			return true;
		}

		public override void Destroy()
		{
			_nodeUnlockedEvent.UnRegister(OnNodeUnlocked);
		}
	}
}
