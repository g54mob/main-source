using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class SuperBugNetworkView : MonoBehaviour, IResearchNetworkState
	{
		[SerializeField]
		private GameObject _nodePrefab;

		[SerializeField]
		private GameObject _connectorPrefab;

		[SerializeField]
		private ScrollRect _scroller;

		[SerializeField]
		private Transform _connectorParentTransform;

		[SerializeField]
		private Transform _nodeParentTransform;

		[SerializeField]
		private Button _backgroundButton;

		[SerializeField]
		private Sprite _defaultRootIcon;

		[SerializeField]
		private float _horizontalPadding = 20f;

		[SerializeField]
		private float _verticalPadding = 20f;

		[SerializeField]
		private Sprite _victorySpriteYellow;

		[SerializeField]
		private Sprite _victorySpriteGreen;

		[SerializeField]
		private Sprite _victorySpriteBlue;

		[SerializeField]
		private Sprite _victorySpritePurple;

		[SerializeField]
		private Sprite _victorySpriteOrange;

		public Action<CollaborativeNode> OnNetworkNodeSelected;

		private readonly Dictionary<CollaborativeNode.VictoryNodeType, Sprite> _victorySpriteMap = new Dictionary<CollaborativeNode.VictoryNodeType, Sprite>();

		private readonly List<ResearchNetworkNodeItem> _nodeItems = new List<ResearchNetworkNodeItem>();

		private bool _showAllNodes;

		private SuperBugData _projectData;

		private CollaborativePortfolio _portfolio;

		private ResearchNetwork _network;

		private int _selectedNodeId = -1;

		public ResearchNetwork Network => _network;

		private void Start()
		{
			_backgroundButton.onClick.AddListener(OnBackgroundPressed);
		}

		private void OnEnable()
		{
			if (_network != null)
			{
				Refresh();
			}
		}

		private void OnDisable()
		{
			foreach (ResearchNetworkNodeItem nodeItem in _nodeItems)
			{
				GameObjectUtils.SetActive(nodeItem.gameObject, isActive: false);
			}
		}

		private void OnDestroy()
		{
			_backgroundButton.onClick.RemoveListener(OnBackgroundPressed);
			foreach (ResearchNetworkNodeItem nodeItem in _nodeItems)
			{
				nodeItem.OnClicked = (Action<CollaborativeNode>)Delegate.Remove(nodeItem.OnClicked, new Action<CollaborativeNode>(OnNodeSelected));
				UnityEngine.Object.Destroy(nodeItem);
			}
			_nodeItems.Clear();
		}

		public void Setup(SuperBugData data, CollaborativePortfolio portfolio, ResearchNetworkInteractionView interactionView, bool showAllNodes = false)
		{
			_projectData = data;
			_portfolio = portfolio;
			_showAllNodes = showAllNodes;
			if (_victorySpriteMap.Count <= 0)
			{
				_victorySpriteMap.Add(CollaborativeNode.VictoryNodeType.Yellow, _victorySpriteYellow);
				_victorySpriteMap.Add(CollaborativeNode.VictoryNodeType.Green, _victorySpriteGreen);
				_victorySpriteMap.Add(CollaborativeNode.VictoryNodeType.Blue, _victorySpriteBlue);
				_victorySpriteMap.Add(CollaborativeNode.VictoryNodeType.Purple, _victorySpritePurple);
				_victorySpriteMap.Add(CollaborativeNode.VictoryNodeType.Orange, _victorySpriteOrange);
			}
			_network = new ResearchNetwork(_projectData.Definition.Network.Cast<ResearchNetwork.Node>().ToList());
			InstantiateRequiredPrefabs();
		}

		public void Setup(SuperBugDefinition definition, CollaborativePortfolio portfolio, ResearchNetworkInteractionView interactionView)
		{
			_projectData = null;
			_portfolio = portfolio;
			_showAllNodes = true;
			_network = new ResearchNetwork(definition.Network.Cast<ResearchNetwork.Node>().ToList());
			InstantiateRequiredPrefabs();
		}

		public void Refresh()
		{
			RefreshNodes();
			SuperBugObjective superBugObjective = _portfolio?.PortfolioDataController?.PortfolioData?.ActiveObjective as SuperBugObjective;
			for (int i = 0; i < _network.GetNodeCount(); i++)
			{
				ResearchNetworkNodeItem researchNetworkNodeItem = _nodeItems[i];
				if (!(researchNetworkNodeItem == null))
				{
					if (!(_network[i] is SuperBugNode superBugNode))
					{
						researchNetworkNodeItem.Refresh(isInProgress: false);
						continue;
					}
					bool isInProgress = superBugObjective != null && superBugObjective.NodeID == superBugNode.NodeID;
					researchNetworkNodeItem.Refresh(isInProgress);
				}
			}
		}

		private void InstantiateRequiredPrefabs()
		{
			InstantiateNodes();
		}

		private void InstantiateNodes()
		{
			int nodeCount = _network.GetNodeCount();
			int num = nodeCount - _nodeItems.Count;
			for (int i = 0; i < num; i++)
			{
				ResearchNetworkNodeItem component = UnityEngine.Object.Instantiate(_nodePrefab).GetComponent<ResearchNetworkNodeItem>();
				component.transform.SetParent(_nodeParentTransform, worldPositionStays: false);
				component.OnClicked = (Action<CollaborativeNode>)Delegate.Combine(component.OnClicked, new Action<CollaborativeNode>(OnNodeSelected));
				_nodeItems.Add(component);
			}
			float graphWidth;
			float graphHeight;
			Vector2 vector = CalculateNodeGraphCentreAdjustmentVector(out graphWidth, out graphHeight);
			_scroller.content.sizeDelta = new Vector2(graphWidth + _horizontalPadding * 2f, graphHeight + _verticalPadding * 2f);
			for (int j = 0; j < nodeCount; j++)
			{
				ResearchNetworkNodeItem researchNetworkNodeItem = _nodeItems[j];
				if (!(researchNetworkNodeItem == null))
				{
					if (!(_network[j] is SuperBugNode superBugNode))
					{
						GameObjectUtils.SetActive(researchNetworkNodeItem.gameObject, isActive: false);
						continue;
					}
					superBugNode.RefreshStatus(this);
					GameObjectUtils.SetActive(researchNetworkNodeItem.gameObject, isActive: true);
					researchNetworkNodeItem.transform.localPosition = superBugNode.Position + vector;
					researchNetworkNodeItem.Initialise(null, this, _connectorParentTransform);
					researchNetworkNodeItem.Setup(superBugNode, this);
				}
			}
			for (int k = nodeCount; k < _nodeItems.Count; k++)
			{
				GameObjectUtils.SetActive(_nodeItems[k].gameObject, isActive: false);
			}
			for (int l = 0; l < nodeCount; l++)
			{
				ResearchNetworkNodeItem researchNetworkNodeItem2 = _nodeItems[l];
				if (!(researchNetworkNodeItem2 == null))
				{
					researchNetworkNodeItem2.SetupConnectors(this);
				}
			}
		}

		private void RefreshNodes()
		{
			for (int i = 0; i < _network.GetNodeCount(); i++)
			{
				if (_network[i] is CollaborativeNode collaborativeNode)
				{
					collaborativeNode.RefreshStatus(this);
				}
			}
			RefreshNodeSelectionStates();
		}

		public void CentreOnNode(int nodeId)
		{
			if (nodeId < 0 || nodeId >= _network.GetNodeCount())
			{
				return;
			}
			ResearchNetworkNodeItem researchNetworkNodeItem = null;
			foreach (ResearchNetworkNodeItem nodeItem in _nodeItems)
			{
				if (nodeItem?.Node != null && nodeItem.Node.NodeID == nodeId)
				{
					researchNetworkNodeItem = nodeItem;
					break;
				}
			}
			if (!(researchNetworkNodeItem == null))
			{
				RectTransform rectTransform = researchNetworkNodeItem.transform as RectTransform;
				if (!(rectTransform == null))
				{
					Vector2 vector = new Vector2(0f - rectTransform.localPosition.x, 0f - rectTransform.localPosition.y);
					_scroller.content.transform.localPosition = vector;
				}
			}
		}

		public bool IsNodeCompleted(int nodeID)
		{
			CollaborativeNode collaborativeNode = _network.GetNode(nodeID) as CollaborativeNode;
			if (collaborativeNode?.Definition == null)
			{
				return false;
			}
			return GetNumNodeCompletions(nodeID) >= collaborativeNode.Definition.CompletionsRequired;
		}

		public bool IsNodeCompletedByLocalPlayer(int nodeID)
		{
			if (_projectData == null)
			{
				return false;
			}
			_projectData.NodeCompletedByLocalPlayer.TryGetValue(nodeID, out var value);
			return value;
		}

		public int GetNumNodeCompletions(int nodeID)
		{
			if (_projectData == null)
			{
				return 0;
			}
			_projectData.NodeCompletionData.TryGetValue(nodeID, out var value);
			return value;
		}

		public List<int> GetCompletableNodesForLocalPlayer()
		{
			List<int> list = new List<int>();
			for (int i = 0; i < _network.GetNodeCount(); i++)
			{
				if (_network.GetNode(i) is SuperBugNode { IsRoot: false } superBugNode && superBugNode.Status == CollaborativeNode.State.Discovered && !IsNodeCompletedByLocalPlayer(superBugNode.NodeID))
				{
					list.Add(superBugNode.NodeID);
				}
			}
			return list;
		}

		public int GetNumCompletionsRequired(int nodeID)
		{
			CollaborativeNode collaborativeNode = _network.GetNode(nodeID) as CollaborativeNode;
			if (collaborativeNode?.Definition == null)
			{
				return -1;
			}
			return collaborativeNode.Definition.CompletionsRequired;
		}

		public void GetAllNodeParents(int nodeID, ref List<ResearchNetwork.Node> parentList)
		{
			_network.GetAllParents(_network.GetNode(nodeID), ref parentList);
		}

		public void GetAllNodeChildren(int nodeID, ref List<ResearchNetwork.Node> childList)
		{
			_network.GetAllChildren(_network.GetNode(nodeID), ref childList);
		}

		public int GetNodeCompletionCountForPlayer(OnlinePlayerID onlinePlayerID)
		{
			return 0;
		}

		public List<OnlinePlayerID> GetPlayerAttemptingNode(int nodeID)
		{
			return null;
		}

		public bool IsLocalPlayerAttemptingNode(int nodeID)
		{
			if (!(_portfolio?.PortfolioDataController?.PortfolioData?.ActiveObjective is SuperBugObjective superBugObjective))
			{
				return false;
			}
			if (superBugObjective.SuperBugID != _projectData.Definition.SuperBugID)
			{
				return false;
			}
			return superBugObjective.NodeID == nodeID;
		}

		public Sprite GetRootNodeSprite()
		{
			return _defaultRootIcon;
		}

		public Sprite GetVictoryNodeSprite(int nodeID)
		{
			CollaborativeNode collaborativeNode = _network.GetNode(nodeID) as CollaborativeNode;
			_victorySpriteMap.TryGetValue(collaborativeNode.VictoryType, out var value);
			return value;
		}

		public bool IsShowAllMode()
		{
			return _showAllNodes;
		}

		public bool IsAllCompletedMode()
		{
			return _portfolio.DebugAllNodesCompleted;
		}

		public bool IsAllDiscoveredMode()
		{
			return _portfolio.DebugAllNodesDiscovered;
		}

		public int GetSelectedNodeID()
		{
			return _selectedNodeId;
		}

		public CollaborativePortfolio GetPortfolio()
		{
			return _portfolio;
		}

		public CollaborativeProject GetProject()
		{
			return null;
		}

		public ResearchNetwork.Node GetParentNode(int nodeID)
		{
			if (!(_network.GetNode(nodeID) is CollaborativeNode { IsRoot: false } collaborativeNode))
			{
				return null;
			}
			return _network.GetNode(collaborativeNode.Parent);
		}

		public ResearchNetworkNodeItem GetNodeUIItem(int nodeID)
		{
			return _nodeItems[nodeID];
		}

		private void RefreshNodeSelectionStates()
		{
			for (int i = 0; i < _nodeItems.Count; i++)
			{
				_nodeItems[i].RefreshSelectedState();
			}
		}

		private void OnNodeSelected(CollaborativeNode node)
		{
			_selectedNodeId = node?.NodeID ?? (-1);
			OnNetworkNodeSelected.InvokeSafe(node);
			RefreshNodeSelectionStates();
		}

		private void OnBackgroundPressed()
		{
			OnNetworkNodeSelected.InvokeSafe(null);
		}

		private Vector2 CalculateNodeGraphCentreAdjustmentVector(out float graphWidth, out float graphHeight)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			for (int i = 0; i < _network.GetNodeCount(); i++)
			{
				SuperBugNode superBugNode = (SuperBugNode)_network[i];
				if (superBugNode != null)
				{
					num = Mathf.Min(num, superBugNode.Position.x);
					num2 = Mathf.Max(num2, superBugNode.Position.x);
					num3 = Mathf.Min(num3, superBugNode.Position.y);
					num4 = Mathf.Max(num4, superBugNode.Position.y);
				}
			}
			graphWidth = num2 - num;
			graphHeight = num4 - num3;
			return new Vector2((0f - graphWidth) * 0.5f - num, (0f - graphHeight) * 0.5f - num3);
		}
	}
}
