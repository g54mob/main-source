using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/TechTree/TechTree")]
public class TechTree : ScriptableObject
{
	[SerializeField]
	private List<TechTreeRequirementProvider> _requirementProviders;

	[SerializeField]
	private List<TechTreeNode> _nodes = new List<TechTreeNode>();

	public List<TechTreeRequirementProvider> RequirementProviders => _requirementProviders;

	public List<TechTreeNode> Nodes => _nodes;

	public bool UnlockNodeWithUnlockable(ResearchUnlockable unlockable, bool validateDependencyIntegrity)
	{
		if (TryGetUnlockableNode(unlockable, out var node))
		{
			if (node.IsUnlocked())
			{
				return false;
			}
			node.Unlock();
			if (validateDependencyIntegrity)
			{
				ValidateDependencyIntegrity(node);
			}
			return true;
		}
		return false;
	}

	private void ValidateDependencyIntegrity(TechTreeNode node)
	{
		if (node.Dependencies.IsNullOrEmpty() || !node.IsUnlocked())
		{
			return;
		}
		foreach (TechTreeNode dependency in node.Dependencies)
		{
			dependency.Unlock();
			ValidateDependencyIntegrity(dependency);
		}
	}

	public bool FindTechTreeNodeByGuid(string guid, out TechTreeNode node)
	{
		int count = Nodes.Count;
		for (int i = 0; i < count; i++)
		{
			node = Nodes[i];
			if (node.Guid == guid)
			{
				return true;
			}
		}
		node = null;
		return false;
	}

	public bool ContainsUnlockable(ResearchUnlockable unlockable)
	{
		foreach (TechTreeNode node in Nodes)
		{
			foreach (ResearchUnlockable unlockable2 in node.Unlockables)
			{
				if (unlockable2.Contains(unlockable))
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool TryGetUnlockableNode(ResearchUnlockable unlockable, out TechTreeNode node)
	{
		for (int i = 0; i < Nodes.Count; i++)
		{
			node = Nodes[i];
			if (node.Unlockables.Contains(unlockable))
			{
				return node;
			}
		}
		node = null;
		return false;
	}

	public bool IsFullyUnlocked()
	{
		foreach (TechTreeNode node in Nodes)
		{
			if (!node.IsUnlocked())
			{
				return false;
			}
		}
		return true;
	}

	public int GetRemainingCost()
	{
		int num = 0;
		foreach (TechTreeNode node in Nodes)
		{
			if (!node.IsUnlocked())
			{
				num += node.Cost;
			}
		}
		return num;
	}
}
