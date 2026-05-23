#define ENABLE_DEBUG_LOGS
#define ENABLE_DEBUG_ERRORS
#define ENABLE_DEBUG_WARNINGS
using System.Collections.Generic;
using System.Linq;
using Data.FactoryFloor.Resources;
using Data.SaveData.PersistentSOs;
using Data.TechTree.Behaviours;
using Data.TechTree.Validators;
using Data.Variables;
using DefaultNamespace.Data.TechTree;
using Events.Analytics;
using Events.UI.TechTree;
using GameAnalyticsSDK;
using Presentation.Locators;
using Presentation.UI.Menus.FullscreenPage;
using UnityEngine;
using Utils;

public class TechTreeManager : FullPage
{
	[SerializeField]
	private TechTreeManagerLocator _techTreeManagerLocator;

	[SerializeField]
	private TechTreeUI _techTreeView;

	[SerializeField]
	private UnlockedTechTreeNodesPersistentSO _unlockedTechTreeNodesPersistentSO;

	[SerializeField]
	private TechTreeRefunableDatabase _techTreeRefunableDatabase;

	[SerializeField]
	private ResourceDatabaseSO _resourceDatabase;

	[SerializeField]
	private CurrencyPersistentSO _currencySO;

	[SerializeField]
	private NodeUnlockedEvent _nodeUnlockedEvent;

	[SerializeField]
	private AnalyticsProgressionEvent _analyticsProgressionEvent;

	[SerializeField]
	private AnalyticsDesignEvent _analyticsDesignEvent;

	[SerializeField]
	private SaveInfoPersistentSO _saveInfoPersistentSo;

	private TechTreeSO _techTreeSO;

	[SerializeField]
	private IntVariableSO _lastUnlockedNodeID;

	private bool _didFocusOnNode;

	private int _techTreeUnlockedCount;

	public TechTreeUI TechTreeView => _techTreeView;

	public bool IsFullyCompleted
	{
		get
		{
			foreach (TechTreeNodeSO node in _techTreeSO.Nodes)
			{
				if (!node.IsUnlocked)
				{
					return false;
				}
			}
			return true;
		}
	}

	public override void Initialize()
	{
		_techTreeManagerLocator.TechTreeManager = this;
		_techTreeSO = _unlockedTechTreeNodesPersistentSO.TechTreeSo;
		SubscribeToEvents();
		InitTreeNodeStates();
	}

	public override void ShowPage()
	{
		base.gameObject.SetActive(value: true);
		ShowTechTree();
	}

	public override void HidePage()
	{
		base.gameObject.SetActive(value: false);
	}

	private void OnDestroy()
	{
		UnsubscribeFromEvents();
	}

	private void SubscribeToEvents()
	{
		_unlockedTechTreeNodesPersistentSO.OnApplyLoadedSaveData += HandleSaveLoaded;
		_unlockedTechTreeNodesPersistentSO.OnResetToDefaults += HandleResetToDefaults;
	}

	private void UnsubscribeFromEvents()
	{
		_unlockedTechTreeNodesPersistentSO.OnApplyLoadedSaveData -= HandleSaveLoaded;
		_unlockedTechTreeNodesPersistentSO.OnResetToDefaults -= HandleResetToDefaults;
	}

	private void HandleSaveLoaded(TechTreeSaveData saveData)
	{
		UnlockNodes(saveData);
	}

	private void HandleResetToDefaults()
	{
		_didFocusOnNode = false;
		LockAllNodes();
	}

	public void ShowTechTree()
	{
		_techTreeView.ShowTree(_techTreeSO);
		if (!_didFocusOnNode)
		{
			_didFocusOnNode = true;
			_techTreeView.PositionAtFocusedNode();
		}
	}

	public void RefreshTree()
	{
		ShowTechTree();
	}

	public void UnlockNode(TechTreeNodeSO techTreeNode, bool fromSave = false)
	{
		if (techTreeNode.IsUnlocked)
		{
			return;
		}
		_lastUnlockedNodeID.SetValue(techTreeNode.ID);
		techTreeNode.IsUnlocked = true;
		techTreeNode.UnlockedIndex = _techTreeUnlockedCount++;
		techTreeNode.IsDirty = true;
		RecalculateIsUnlockableStateForAffectedNodes(techTreeNode);
		_nodeUnlockedEvent.Fire(techTreeNode);
		if (!fromSave)
		{
			_analyticsDesignEvent.Fire(("TechTreeUnlock:" + techTreeNode.LocaKey, (float)_saveInfoPersistentSo.GetUpdatedTotalPlaytime()));
			if (techTreeNode.SendGAEvent)
			{
				_analyticsProgressionEvent.Fire((GAProgressionStatus.Start, "TechTreeUnlock", techTreeNode.LocaKey, "-"));
				_analyticsProgressionEvent.Fire((GAProgressionStatus.Complete, "TechTreeUnlock", techTreeNode.LocaKey, "-"));
			}
		}
	}

	public void UnlockNode(int nodeIndex)
	{
		if (TryGetNodeByID(nodeIndex, out var node))
		{
			UnlockNode(node);
		}
		else
		{
			this.LogWarning("Node not found", "UnlockNode", 147);
		}
	}

	public void UnlockNodes(TechTreeSaveData saveData)
	{
		List<TechTreeSaveDataNode> unlockedNodes = saveData.UnlockedNodes;
		unlockedNodes.Sort();
		bool flag = !_techTreeSO.VersionGuid.Equals(saveData.TechTreeGuid);
		if (flag)
		{
			_techTreeRefunableDatabase.SetAllVariablesToDefault();
		}
		_techTreeUnlockedCount = 0;
		foreach (TechTreeSaveDataNode item in unlockedNodes)
		{
			if (!TryGetNodeByID(item.ID, out var node))
			{
				this.LogWarning($"TechTreeNode with index {item.ID} not found", "UnlockNodes", 167);
				RefundSaveDataNode(item);
				continue;
			}
			UnlockNode(node, fromSave: true);
			if (!flag)
			{
				continue;
			}
			foreach (AbstractTechTreeNodeBehaviour behavior in node.Behaviors)
			{
				if (behavior == null)
				{
					this.LogError("Missing behaviour in TechTreeNode: " + node.name + " (" + node.LocaKey + ")", "UnlockNodes", 179);
				}
				else
				{
					behavior.RefunableReUnlock();
				}
			}
		}
	}

	private void RefundSaveDataNode(TechTreeSaveDataNode saveDataNode)
	{
		if (saveDataNode.PaidCosts != null)
		{
			this.Log($"Refunding node '{saveDataNode.ID}'", "RefundSaveDataNode", 197);
			ResourceCost resourceCost = saveDataNode.PaidCosts.ToResourceCost(_resourceDatabase);
			_currencySO.AddResources(resourceCost);
		}
	}

	public void LockAllNodes()
	{
		foreach (TechTreeNodeSO node in _techTreeSO.Nodes)
		{
			node.IsUnlocked = false;
			node.IsUnlockable = node.IncomingNodes.Count == 0;
			node.IsDirty = true;
		}
		_techTreeUnlockedCount = 0;
		foreach (TechTreeNodeSO node2 in _techTreeSO.Nodes)
		{
			if (node2.UnlockByDefault)
			{
				UnlockNode(node2, fromSave: true);
			}
		}
	}

	private void InitTreeNodeStates()
	{
		foreach (TechTreeNodeSO node in _techTreeSO.Nodes)
		{
			node.IsUnlockable = node.IncomingNodes.Count == 0;
			node.IsDirty = true;
		}
	}

	private void RecalculateIsUnlockableStateForAffectedNodes(TechTreeNodeSO node)
	{
		foreach (TechTreeNodeSO outgoingNode in node.OutgoingNodes)
		{
			bool flag = outgoingNode.IncomingNodes.All((TechTreeNodeSO incomingNode) => incomingNode.IsUnlocked);
			if (outgoingNode.IsUnlockable != flag)
			{
				outgoingNode.IsUnlockable = flag;
				outgoingNode.IsDirty = true;
			}
		}
	}

	public bool TryGetNodeByID(int nodeId, out TechTreeNodeSO node)
	{
		node = _techTreeSO.Nodes.Find((TechTreeNodeSO so) => so.ID == nodeId);
		return node != null;
	}

	public List<int> GetAllUnlockedNodeIndexes()
	{
		List<int> list = new List<int>();
		foreach (TechTreeNodeSO node in _techTreeSO.Nodes)
		{
			if (node.IsUnlocked)
			{
				list.Add(node.ID);
			}
		}
		return list;
	}

	public List<TechTreeNodeSO> GetAllNodesInCurrentTree()
	{
		return _techTreeSO.Nodes;
	}

	public void HandleNodeClickEvent(TechTreeNodeSO clickedNode)
	{
		if (clickedNode.IsUnlocked || !clickedNode.IsUnlockable)
		{
			return;
		}
		foreach (AbstractTechTreeNodeValidator validator in clickedNode.Validators)
		{
			if (!validator.CanBuy(clickedNode))
			{
				return;
			}
		}
		foreach (AbstractTechTreeNodeValidator validator2 in clickedNode.Validators)
		{
			validator2.Buy(clickedNode);
		}
		UnlockNode(clickedNode);
		foreach (AbstractTechTreeNodeBehaviour behavior in clickedNode.Behaviors)
		{
			behavior.Unlock();
		}
		ShowTechTree();
	}

	public void DebugUnlockNode(int nodeIndex)
	{
		if (!TryGetNodeByID(nodeIndex, out var node) || node.IsUnlocked)
		{
			return;
		}
		UnlockNode(node);
		foreach (AbstractTechTreeNodeBehaviour behavior in node.Behaviors)
		{
			behavior.Unlock();
		}
		ShowTechTree();
	}

	public void DebugUnlockNextNode()
	{
		foreach (TechTreeNodeSO node in _techTreeSO.Nodes)
		{
			if (node.IsUnlocked || !node.IsUnlockable)
			{
				continue;
			}
			UnlockNode(node);
			foreach (AbstractTechTreeNodeBehaviour behavior in node.Behaviors)
			{
				behavior.Unlock();
			}
			ShowTechTree();
			break;
		}
	}

	public void DebugUnlockAllNodes()
	{
		List<int> list = new List<int>();
		bool flag;
		do
		{
			flag = false;
			foreach (TechTreeNodeSO node in _techTreeSO.Nodes)
			{
				if (node.IsUnlocked || list.Contains(node.ID) || !node.IsUnlockable)
				{
					continue;
				}
				UnlockNode(node);
				list.Add(node.ID);
				flag = true;
				foreach (AbstractTechTreeNodeBehaviour behavior in node.Behaviors)
				{
					if (!(behavior == null))
					{
						behavior.Unlock();
					}
				}
			}
		}
		while (flag);
		ShowTechTree();
	}

	public void UnlockAllNodes()
	{
		List<int> list = new List<int>();
		bool flag;
		do
		{
			flag = false;
			foreach (TechTreeNodeSO node in _techTreeSO.Nodes)
			{
				if (node.IsUnlocked || list.Contains(node.ID) || !node.IsUnlockable)
				{
					continue;
				}
				UnlockNode(node);
				list.Add(node.ID);
				flag = true;
				foreach (AbstractTechTreeNodeBehaviour behavior in node.Behaviors)
				{
					if (!(behavior == null))
					{
						behavior.Unlock();
					}
				}
			}
		}
		while (flag);
	}
}
