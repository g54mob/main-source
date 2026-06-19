using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ResearchNetworkView : MonoBehaviour, IResearchNetworkState
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
		private float _horizontalSpacing = 20f;

		[SerializeField]
		private float _verticalSpacing = 20f;

		[SerializeField]
		private float _horizontalRandomNudge = 10f;

		[SerializeField]
		private float _verticalRandomNudge = 10f;

		[SerializeField]
		private Sprite _victorySprite;

		private const float NetworkScrollSpeed = 400f;

		public Action<CollaborativeNode> OnNetworkNodeSelected;

		private readonly List<ResearchNetworkNodeItem> _nodeItems = new List<ResearchNetworkNodeItem>();

		private readonly List<ResearchNetworkConnectorItem> _connectorItems = new List<ResearchNetworkConnectorItem>();

		private readonly Dictionary<OnlinePlayerID, ResearchNetworkData> _data = new Dictionary<OnlinePlayerID, ResearchNetworkData>();

		private ResearchNetwork _network;

		private CollaborativeProject _project;

		private InputManager _inputManager;

		private ResearchNetworkInteractionView _interactionView;

		private bool _showAllNodes;

		private Dictionary<int, ResearchNetworkUtils.GridData> _gridLayout;

		private readonly List<List<OnlinePlayerID>> _nodeCompletionStates = new List<List<OnlinePlayerID>>();

		private readonly List<List<OnlinePlayerID>> _nodeActiveStates = new List<List<OnlinePlayerID>>();

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
			_data.Clear();
			foreach (ResearchNetworkNodeItem nodeItem in _nodeItems)
			{
				nodeItem.gameObject.SetActive(value: false);
			}
			foreach (ResearchNetworkConnectorItem connectorItem in _connectorItems)
			{
				connectorItem.gameObject.SetActive(value: false);
			}
			if (_interactionView != null)
			{
				_interactionView.Hide();
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
			foreach (ResearchNetworkConnectorItem connectorItem in _connectorItems)
			{
				UnityEngine.Object.Destroy(connectorItem);
			}
			_connectorItems.Clear();
		}

		public void Setup(CollaborativeProject project, InputManager inputManager, [NotNull] ResearchNetwork network, ResearchNetworkInteractionView interactionView, int randomSeed, bool showAllNodes = false)
		{
			_network = network;
			_inputManager = inputManager;
			_interactionView = interactionView;
			_interactionView.Hide();
			_project = project;
			_showAllNodes = showAllNodes;
			_nodeCompletionStates.Clear();
			_nodeActiveStates.Clear();
			for (int i = 0; i < _network.GetNodeCount(); i++)
			{
				_nodeCompletionStates.Add(new List<OnlinePlayerID>());
				_nodeActiveStates.Add(new List<OnlinePlayerID>());
			}
			ResearchNetworkUtils.CreateGridLayout(_network, out _gridLayout, new Vector2(_horizontalSpacing, _verticalSpacing), new Vector2(_horizontalPadding, _verticalPadding));
			int requiredRows = _gridLayout[0].RequiredRows;
			int maxDepth = _network.GetMaxDepth();
			_scroller.content.sizeDelta = new Vector2((float)maxDepth * _horizontalSpacing + _horizontalPadding * 2f, (float)requiredRows * _verticalSpacing + _verticalPadding * 2f);
			InstantiateRequiredPrefabs(randomSeed);
			Refresh();
		}

		private void Update()
		{
			if (_inputManager != null)
			{
				if (_inputManager.GetButton(36) || _inputManager.GetKey(KeyCode.UpArrow))
				{
					Vector3 position = _scroller.content.transform.position;
					_scroller.content.transform.position = position + new Vector3(0f, 400f * (0f - Time.unscaledDeltaTime), 0f);
				}
				if (_inputManager.GetButton(37) || _inputManager.GetKey(KeyCode.DownArrow))
				{
					Vector3 position2 = _scroller.content.transform.position;
					_scroller.content.transform.position = position2 + new Vector3(0f, 400f * Time.unscaledDeltaTime, 0f);
				}
				if (_inputManager.GetButton(34) || _inputManager.GetKey(KeyCode.LeftArrow))
				{
					Vector3 position3 = _scroller.content.transform.position;
					_scroller.content.transform.position = position3 + new Vector3(400f * Time.unscaledDeltaTime, 0f, 0f);
				}
				if (_inputManager.GetButton(35) || _inputManager.GetKey(KeyCode.RightArrow))
				{
					Vector3 position4 = _scroller.content.transform.position;
					_scroller.content.transform.position = position4 + new Vector3(400f * (0f - Time.unscaledDeltaTime), 0f, 0f);
				}
			}
		}

		public void AddResearchData(OnlinePlayerID onlinePlayerID, [NotNull] ResearchNetworkData data)
		{
			_data[onlinePlayerID] = data;
		}

		public void RemoveResearchData(OnlinePlayerID onlinePlayerID)
		{
			_data.Remove(onlinePlayerID);
		}

		public void ClearResearchData()
		{
			_data.Clear();
		}

		private void InstantiateRequiredPrefabs(int randomSeed)
		{
			InstantiateNodeItems(randomSeed);
		}

		private void InstantiateNodeItems(int randomSeed)
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
			LehmerRandomGenerator randomInstance = new LehmerRandomGenerator(randomSeed);
			for (int j = 0; j < nodeCount; j++)
			{
				ResearchNetworkNodeItem researchNetworkNodeItem = _nodeItems[j];
				if (!(researchNetworkNodeItem == null))
				{
					if (!(_network[j] is CollaborativeNode collaborativeNode))
					{
						researchNetworkNodeItem.gameObject.SetActive(value: false);
						researchNetworkNodeItem.Setup(null, this);
						continue;
					}
					collaborativeNode.RefreshStatus(this);
					researchNetworkNodeItem.transform.localPosition = GetGridPosition(collaborativeNode.NodeID, randomInstance);
					researchNetworkNodeItem.Initialise(_project, this, _connectorParentTransform);
					researchNetworkNodeItem.Setup(collaborativeNode, this);
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

		public void Refresh()
		{
			RefreshNodes();
			RefreshNodeItems();
		}

		private void RefreshNodes()
		{
			for (int i = 0; i < _network.GetNodeCount(); i++)
			{
				List<OnlinePlayerID> completedList = _nodeCompletionStates[i];
				GetNodeCompletionList(i, ref completedList);
				completedList = _nodeActiveStates[i];
				GetNodeActiveList(i, ref completedList);
			}
			for (int j = 0; j < _network.GetNodeCount(); j++)
			{
				if (_network[j] is CollaborativeNode collaborativeNode)
				{
					collaborativeNode.RefreshStatus(this);
				}
			}
		}

		private void GetNodeCompletionList(int nodeID, ref List<OnlinePlayerID> completedList)
		{
			completedList.Clear();
			foreach (KeyValuePair<OnlinePlayerID, ResearchNetworkData> datum in _data)
			{
				if (datum.Value.CompletedNodeTimestamps.ContainsKey(nodeID))
				{
					completedList.Add(datum.Key);
				}
			}
		}

		private void GetNodeActiveList(int nodeID, ref List<OnlinePlayerID> activeList)
		{
			activeList.Clear();
			foreach (KeyValuePair<OnlinePlayerID, ResearchNetworkData> datum in _data)
			{
				if (datum.Value.ActiveNode == nodeID)
				{
					activeList.Add(datum.Key);
				}
			}
		}

		private void RefreshNodeItems()
		{
			int? num = null;
			Guid? guid = null;
			if (_project?.Portfolio?.PortfolioDataController?.PortfolioData?.ActiveObjective is ResearchProjectObjective researchProjectObjective)
			{
				num = researchProjectObjective.NodeID;
				guid = researchProjectObjective.ProjectID;
			}
			for (int i = 0; i < _network.GetNodeCount(); i++)
			{
				ResearchNetworkNodeItem researchNetworkNodeItem = _nodeItems[i];
				if (!(researchNetworkNodeItem == null))
				{
					if (!(_network[i] is CollaborativeNode collaborativeNode))
					{
						researchNetworkNodeItem.gameObject.SetActive(value: false);
						continue;
					}
					researchNetworkNodeItem.gameObject.SetActive(value: true);
					bool isInProgress = guid.HasValue && guid == _project.ProjectID && num == collaborativeNode.NodeID;
					researchNetworkNodeItem.Refresh(isInProgress);
				}
			}
			for (int j = _network.GetNodeCount(); j < _nodeItems.Count; j++)
			{
				_nodeItems[j].gameObject.SetActive(value: false);
			}
			RefreshNodeSelectionStates();
		}

		private void RefreshNodeSelectionStates()
		{
			for (int i = 0; i < _nodeItems.Count; i++)
			{
				_nodeItems[i].RefreshSelectedState();
			}
		}

		public bool IsNodeCompleted(int nodeID)
		{
			CollaborativeNode collaborativeNode = _network.GetNode(nodeID) as CollaborativeNode;
			if (collaborativeNode?.Definition == null)
			{
				return false;
			}
			return _nodeCompletionStates[nodeID].Count >= collaborativeNode.Definition.CompletionsRequired;
		}

		public bool IsNodeCompletedByLocalPlayer(int nodeID)
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return false;
			}
			return _nodeCompletionStates[nodeID].Contains(OnlineManager.GetLocalPlayerID());
		}

		public int GetNumNodeCompletions(int nodeID)
		{
			return _nodeCompletionStates[nodeID].Count;
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

		public ResearchNetworkNodeItem GetFirstActiveNode()
		{
			List<int> completableNodesForLocalPlayer = GetCompletableNodesForLocalPlayer();
			if (completableNodesForLocalPlayer.Count > 0)
			{
				return GetNodeItem(completableNodesForLocalPlayer[0]);
			}
			return null;
		}

		public int NodeCount()
		{
			return _network.GetNodeCount();
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
			if (!_data.TryGetValue(onlinePlayerID, out var value))
			{
				return 0;
			}
			return value.CompletedNodeTimestamps.Count;
		}

		public List<int> GetCompletableNodesForLocalPlayer()
		{
			List<int> list = new List<int>();
			for (int i = 0; i < _network.GetNodeCount(); i++)
			{
				if (_network.GetNode(i) is CollaborativeNode { IsRoot: false } collaborativeNode && collaborativeNode.Status == CollaborativeNode.State.Discovered && !IsNodeCompletedByLocalPlayer(collaborativeNode.NodeID))
				{
					list.Add(collaborativeNode.NodeID);
				}
			}
			return list;
		}

		public List<OnlinePlayerID> GetPlayerAttemptingNode(int nodeID)
		{
			List<OnlinePlayerID> list = null;
			foreach (KeyValuePair<OnlinePlayerID, ResearchNetworkData> datum in _data)
			{
				if (!(datum.Key == OnlineManager.GetLocalPlayerID()) && datum.Value.ActiveNode == nodeID)
				{
					if (list == null)
					{
						list = new List<OnlinePlayerID>();
					}
					list.Add(datum.Key);
				}
			}
			return list;
		}

		public bool IsLocalPlayerAttemptingNode(int nodeID)
		{
			return _project.LocalPlayerData.ResearchData.ActiveNode == nodeID;
		}

		public Sprite GetRootNodeSprite()
		{
			return _defaultRootIcon;
		}

		public Sprite GetVictoryNodeSprite(int nodeID)
		{
			return _victorySprite;
		}

		public bool IsShowAllMode()
		{
			return _showAllNodes;
		}

		public bool IsAllCompletedMode()
		{
			return _project.Portfolio.DebugAllNodesCompleted;
		}

		public bool IsAllDiscoveredMode()
		{
			return _project.Portfolio.DebugAllNodesDiscovered;
		}

		public int GetSelectedNodeID()
		{
			return _selectedNodeId;
		}

		public CollaborativePortfolio GetPortfolio()
		{
			return _project.Portfolio;
		}

		public CollaborativeProject GetProject()
		{
			return _project;
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
			for (int i = 0; i < _nodeItems.Count; i++)
			{
				ResearchNetworkNodeItem researchNetworkNodeItem = _nodeItems[i];
				if (researchNetworkNodeItem?.Node != null && researchNetworkNodeItem.Node.NodeID == nodeID)
				{
					return researchNetworkNodeItem;
				}
			}
			return null;
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
			RefreshNodeSelectionStates();
		}

		public ResearchNetworkNodeItem GetNodeItem(int nodeID)
		{
			return _nodeItems[nodeID];
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

		private Vector2 GetGridPosition(int nodeID, LehmerRandomGenerator randomInstance)
		{
			if (!_gridLayout.TryGetValue(nodeID, out var value))
			{
				return new Vector2(0f, 0f);
			}
			double num = randomInstance.Next(0f - _horizontalRandomNudge, _horizontalRandomNudge);
			double num2 = randomInstance.Next(0f - _verticalRandomNudge, _verticalRandomNudge);
			float num3 = _scroller.content.sizeDelta.x * 0.5f;
			float num4 = _scroller.content.sizeDelta.y * 0.5f;
			return value.LocalPosition + new Vector2(0f - num3, 0f - num4) + new Vector2((float)num, (float)num2);
		}
	}
}
