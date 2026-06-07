using System.Collections.Generic;
using System.Text;
using DG.Tweening;
using FullSerializer;
using TMPro;
using UnityEngine;

public class MinigamePanelResearch : MinigamePanel
{
	private List<List<ResearchNode>> nodes = new List<List<ResearchNode>>();

	private readonly List<ResearchNode> actualPath = new List<ResearchNode>();

	private readonly List<ResearchOutlet> actualPathConnections = new List<ResearchOutlet>();

	private readonly Queue<ResearchNode> queue = new Queue<ResearchNode>();

	private readonly List<ResearchConnection> connections = new List<ResearchConnection>();

	private readonly List<ResearchConnection> tempConnectionList = new List<ResearchConnection>();

	private List<ResearchNode> tempRandomList = new List<ResearchNode>();

	public GameObject researchNodePrefab;

	public GameObject researchConnectionPrefab;

	public Transform nodeParent;

	public TextMeshProUGUI attemptsRemainingLabel;

	private ResearchNode start;

	private ResearchNode end;

	private int numPathNodes;

	private int colCount;

	private ResearchNode selectedNode;

	private ResearchConnection proposedConnection;

	private float revealTimer;

	private const float revealMaxTime = 0.3f;

	private const float victoryAnimationTimerMax = 0.1f;

	private ResearchNode queuedNode;

	private bool isRunningVictoryAnimation;

	private int victoryIndex;

	private float victoryAnimationCountdown;

	private TextFlashAnimation textAnimationAttempts;

	public override void Initialize()
	{
		base.Initialize();
		textAnimationAttempts = new TextFlashAnimation(attemptsRemainingLabel);
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		attemptsRemainingLabel.text = "AttemptsRemaining".Localized();
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		foreach (ResearchConnection connection in connections)
		{
			connection.UpdateDynamicDisplay();
		}
		foreach (List<ResearchNode> node in nodes)
		{
			foreach (ResearchNode item in node)
			{
				item.UpdateDynamicDisplay();
			}
		}
		if (revealTimer > 0f)
		{
			revealTimer -= TimeManager.MenuDelta;
			if (revealTimer <= 0f)
			{
				RevealQueuedNode();
			}
		}
		if (isRunningVictoryAnimation)
		{
			victoryAnimationCountdown -= TimeManager.MenuDelta;
			if (victoryAnimationCountdown <= 0f)
			{
				AdvanceVictoryAnimation();
			}
		}
	}

	public override void ResetMinigame()
	{
		base.ResetMinigame();
		if (null != selectedNode)
		{
			selectedNode.isNodeSelected = false;
			selectedNode = null;
		}
		ClearNodes();
		start = null;
		end = null;
		if (null != proposedConnection)
		{
			proposedConnection.isProposed = false;
			proposedConnection = null;
		}
		ClearConnections();
		revealTimer = 0f;
		queuedNode = null;
		ClearPathInfo();
		tempConnectionList.Clear();
		isRunningVictoryAnimation = false;
		victoryIndex = 0;
		victoryAnimationCountdown = 0f;
		base.ResetMinigame();
	}

	private void ClearPathInfo()
	{
		actualPath.Clear();
		actualPathConnections.Clear();
		queue.Clear();
		foreach (List<ResearchNode> node in nodes)
		{
			foreach (ResearchNode item in node)
			{
				item.ClearPathInfo();
			}
		}
	}

	private void DebugPrintPath()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (ResearchNode item in actualPath)
		{
			stringBuilder.Append(item.label.text);
			stringBuilder.Append(", ");
		}
	}

	private bool TryFindPathFrom(ResearchNode source)
	{
		actualPath.Add(source);
		numPathNodes++;
		DebugPrintPath();
		source.isQueued = true;
		int num = 10;
		foreach (ResearchOutlet shuffledConnection in source.shuffledConnections)
		{
			if (shuffledConnection.connection.isAvailable)
			{
				ResearchNode outboundNode = shuffledConnection.outboundNode;
				if (outboundNode == end)
				{
					actualPath.Add(end);
					return true;
				}
				if (!outboundNode.pathExcludeFlag && !outboundNode.isQueued && numPathNodes <= num && TryFindPathFrom(outboundNode))
				{
					return true;
				}
			}
		}
		source.isQueued = false;
		numPathNodes--;
		actualPath.Remove(source);
		return false;
	}

	private ResearchConnection ConnectionForNodes(ResearchNode n1, ResearchNode n2)
	{
		foreach (ResearchConnection connection in connections)
		{
			if (connection.n1 == n1 && connection.n2 == n2)
			{
				return connection;
			}
			if (connection.n1 == n2 && connection.n2 == n1)
			{
				return connection;
			}
		}
		return null;
	}

	private void FlagCorrectNodesFromActualPath()
	{
		for (int i = 0; i < actualPath.Count - 1; i++)
		{
			ResearchNode researchNode = actualPath[i];
			ResearchNode other = actualPath[i + 1];
			researchNode.correctPathIndex = i;
			if (researchNode.TryGetOutletToNode(other, out var connection))
			{
				actualPathConnections.Add(connection);
				connection.connection.isInCorrectPath = true;
			}
		}
		end.correctPathIndex = actualPath.Count - 1;
	}

	private void ReloadNodeLabels()
	{
		foreach (List<ResearchNode> node in nodes)
		{
			foreach (ResearchNode item in node)
			{
				item.ReloadLabel();
			}
		}
	}

	private void CalcNodeStates()
	{
		foreach (List<ResearchNode> node in nodes)
		{
			foreach (ResearchNode item in node)
			{
				item.UpdatePosition();
				item.CalcState();
			}
		}
	}

	private void CalcConnectionStates()
	{
		foreach (ResearchConnection connection in connections)
		{
			connection.CalcState();
		}
	}

	public void DebugDisplayAllPossiblePaths()
	{
		foreach (ResearchConnection connection in connections)
		{
			connection.lineRenderer.enabled = connection.isAvailable;
		}
	}

	public void FindRandomPath()
	{
		foreach (List<ResearchNode> node in nodes)
		{
			foreach (ResearchNode item in node)
			{
				item.Shuffle();
			}
		}
		List<ResearchNode> list = nodes[3];
		List<ResearchNode> list2 = nodes[4];
		for (int i = 0; i < list.Count - 1; i++)
		{
			if (Random.Range(0f, 100f) < 50f)
			{
				ResearchNode researchNode = list[i];
				ResearchNode other = list2[i + 1];
				if (researchNode.TryGetConnectionToNode(other, out var connection))
				{
					connection.isAvailable = false;
				}
			}
			else
			{
				ResearchNode researchNode2 = list[i + 1];
				ResearchNode other2 = list2[i];
				if (researchNode2.TryGetConnectionToNode(other2, out var connection2))
				{
					connection2.isAvailable = false;
				}
			}
		}
		numPathNodes = 0;
		start.pathExcludeFlag = true;
		if (!TryFindPathFrom(start))
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (ResearchNode item2 in actualPath)
		{
			stringBuilder.Append(item2.label.text);
			stringBuilder.Append(", ");
		}
	}

	public override void CreateItems()
	{
		levelStat = MenuPanel.gm.minigameResearch;
		energyTracker = MenuPanel.gm.energyResearch;
		rewardEntities.AddItem(ItemType.ResearchTomeGeneral, 10.0);
		rewardEntities.AddItem(ItemType.ResearchTomeIndustry1, 6.0);
		rewardEntities.AddItem(ItemType.ResearchTomeIndustry2, 3.0);
		rewardEntities.AddItem(ItemType.ResearchTomeIndustry3, 1.0);
		rewardEntities.AddItem(ItemType.ResearchTomeMagic1, 6.0);
		rewardEntities.AddItem(ItemType.ResearchTomeMagic2, 3.0);
		rewardEntities.AddItem(ItemType.ResearchTomeMagic3, 1.0);
		base.CreateItems();
	}

	private void CreateNodes()
	{
		float num = (float)(colCount - 1) * 0.5f;
		for (int i = 0; i < colCount; i++)
		{
			List<ResearchNode> list = new List<ResearchNode>();
			int num2 = 1;
			switch (i)
			{
			case 1:
			case 6:
				num2 = 3;
				break;
			case 2:
			case 5:
				num2 = 4;
				break;
			case 3:
			case 4:
				num2 = 5;
				break;
			}
			float num3 = (float)(num2 - 1) * 0.5f;
			for (int j = 0; j < num2; j++)
			{
				ResearchNode researchNode = AddNode(i, j);
				researchNode.offsetX = (float)i - num;
				researchNode.offsetY = (float)j - num3;
				list.Add(researchNode);
			}
			nodes.Add(list);
		}
	}

	private void DeriveStartAndEnd()
	{
		if (nodes.Count >= 1)
		{
			List<ResearchNode> list = nodes[0];
			if (list.Count > 0)
			{
				start = list[0];
			}
			List<ResearchNode> list2 = nodes[nodes.Count - 1];
			if (list2.Count > 0)
			{
				end = list2[0];
			}
		}
		if (null == start)
		{
			Debug.LogError("Did not derive start node");
		}
		if (null == end)
		{
			Debug.LogError("Did not derive end node");
		}
	}

	private ResearchNode LoadNode(int x, int y)
	{
		ResearchNode researchNode = AddNode(x, y);
		while (x >= nodes.Count)
		{
			nodes.Add(new List<ResearchNode>());
		}
		List<ResearchNode> list = nodes[x];
		while (y >= list.Count)
		{
			list.Add(null);
		}
		list[y] = researchNode;
		return researchNode;
	}

	private ResearchNode NodeAtCoord(Coord c)
	{
		if (c.x < nodes.Count)
		{
			List<ResearchNode> list = nodes[c.x];
			if (c.y < list.Count)
			{
				return list[c.y];
			}
		}
		return null;
	}

	private void DeriveAllConnections()
	{
		for (int i = 0; i < nodes.Count - 1; i++)
		{
			List<ResearchNode> list = nodes[i];
			List<ResearchNode> list2 = nodes[i + 1];
			foreach (ResearchNode item in list)
			{
				if (item.y > 0)
				{
					int index = item.y - 1;
					Connect(item, list[index]);
				}
				int num = item.y + 1;
				if (num < list.Count)
				{
					Connect(item, list[num]);
				}
				foreach (ResearchNode item2 in list2)
				{
					if (ShouldConnect(item, item2))
					{
						Connect(item, item2);
					}
				}
			}
		}
	}

	private bool ShouldConnect(ResearchNode n1, ResearchNode n2)
	{
		if (n1 == n2)
		{
			return false;
		}
		if (Mathf.Abs(n2.offsetX - n1.offsetX) <= 1f)
		{
			return Mathf.Abs(n2.offsetY - n1.offsetY) <= 1f;
		}
		return false;
	}

	private void Connect(ResearchNode n1, ResearchNode n2)
	{
		ResearchConnection researchConnection = null;
		ResearchConnection connection2;
		if (n1.TryGetConnectionToNode(n2, out var connection))
		{
			researchConnection = connection;
		}
		else if (n2.TryGetConnectionToNode(n1, out connection2))
		{
			researchConnection = connection2;
		}
		else
		{
			researchConnection = MenuManager.GetMenuObject(researchConnectionPrefab, nodeParent).GetComponent<ResearchConnection>();
			researchConnection.n1 = n1;
			researchConnection.n2 = n2;
			connections.Add(researchConnection);
			researchConnection.gameObject.SetActive(value: false);
		}
		if (!n1.TryGetConnectionToNode(n2, out var _))
		{
			n1.connections.Add(new ResearchOutlet(n2, researchConnection));
		}
		if (!n2.TryGetConnectionToNode(n1, out var _))
		{
			n2.connections.Add(new ResearchOutlet(n1, researchConnection));
		}
	}

	private ResearchNode AddNode(int x, int y)
	{
		ResearchNode component = MenuManager.GetMenuObject(researchNodePrefab, nodeParent).GetComponent<ResearchNode>();
		component.ResetNode();
		component.x = x;
		component.y = y;
		component.parentPanel = this;
		component.AddPointerClickTrigger(component.OnClickedNode);
		return component;
	}

	public void OnHoveredNode(ResearchNode node)
	{
		node.isHovered = true;
		node.CalcState();
		if (null != selectedNode && selectedNode.TryGetConnectionToNode(node, out var connection))
		{
			connection.isProposed = true;
			connection.CalcState();
			proposedConnection = connection;
		}
	}

	public void OnHoverOutNode(ResearchNode node)
	{
		node.isHovered = false;
		node.CalcState();
		if (null != proposedConnection)
		{
			proposedConnection.isProposed = false;
			proposedConnection.CalcState();
			proposedConnection = null;
		}
	}

	public void TestForVictory()
	{
		foreach (ResearchNode item in actualPath)
		{
			if (!item.isRevealed)
			{
				return;
			}
		}
		foreach (ResearchOutlet actualPathConnection in actualPathConnections)
		{
			if (!actualPathConnection.connection.isRevealed)
			{
				return;
			}
		}
		DeclareVictory();
	}

	protected override void DeclareVictory()
	{
		base.DeclareVictory();
		SetSelectedNode(null);
		SetPerfect();
		foreach (ResearchConnection connection in connections)
		{
			if (!connection.isInCorrectPath)
			{
				connection.isRuledOut = true;
				connection.CalcState();
			}
		}
		isRunningVictoryAnimation = true;
		victoryIndex = 0;
		AdvanceVictoryAnimation();
	}

	protected override void SetPerfect()
	{
		base.SetPerfect();
		float num = RewardPerNode() * (float)actualPath.Count;
		if (MenuPanel.gm.gameState == GameState.InGame)
		{
			EarnReward(num);
			minigameFooter.SetPerfect(num, animated: false);
		}
		else
		{
			minigameFooter.SetPerfect(num, animated: false);
		}
	}

	protected override void DeclareFailure()
	{
		base.DeclareFailure();
		if (MenuPanel.gm.gameState == GameState.InGame)
		{
			AnimateFailure();
			DisplayFinalCompletionState();
		}
	}

	protected override void DisplayFinalCompletionState()
	{
		base.DisplayFinalCompletionState();
		SetSelectedNode(null);
		foreach (ResearchConnection connection in connections)
		{
			if (!connection.isInCorrectPath)
			{
				connection.isRuledOut = true;
				connection.CalcState();
			}
		}
	}

	public void AnimateFailure()
	{
		textAnimationAttempts.Run();
	}

	protected override void CalcYield()
	{
		base.CalcYield();
		yieldBaselineUpgraded = yieldBaseline * MenuPanel.gm.MultiplierForGlobalUpgrade(UpgradeType.MinigameResearchYield);
	}

	private float RewardPerNode()
	{
		return yieldBaselineUpgraded * yieldMultiplier;
	}

	private void AdvanceVictoryAnimation()
	{
		ResearchNode researchNode = actualPath[victoryIndex];
		MenuManager.Instance.PlayStarParticles(researchNode.transform.position);
		researchNode.DoPunchAnimation();
		if (victoryIndex < actualPath.Count - 1)
		{
			MenuManager.Instance.PlayChargePathParticles(researchNode.transform.position, actualPath[victoryIndex + 1].transform.position, 0.1f);
		}
		float num = RewardPerNode();
		EarnReward(num);
		AnimateItemGain(researchNode.transform, num);
		victoryAnimationCountdown += 0.1f;
		victoryIndex++;
		if (victoryIndex >= actualPath.Count)
		{
			isRunningVictoryAnimation = false;
		}
	}

	protected override void CalcReward()
	{
		rewardAmount = (float)RevealedPathLength() * RewardPerNode();
		if (IsPerfect())
		{
			rewardAmount *= MultiplierForPerfect();
		}
	}

	private int RevealedPathLength()
	{
		int num = 0;
		using (List<ResearchNode>.Enumerator enumerator = actualPath.GetEnumerator())
		{
			while (enumerator.MoveNext() && enumerator.Current.isRevealed)
			{
				num++;
			}
		}
		return num;
	}

	protected override bool IsPerfect()
	{
		return RevealedPathLength() >= actualPath.Count;
	}

	protected override bool IsReadyToDisplayFinalResult()
	{
		if (base.IsReadyToDisplayFinalResult())
		{
			return !isRunningVictoryAnimation;
		}
		return false;
	}

	private void SetSelectedNode(ResearchNode node)
	{
		if (!(node == selectedNode))
		{
			if (null != selectedNode)
			{
				selectedNode.isNodeSelected = false;
				selectedNode.CalcState();
				selectedNode.ClearConnectionHighlights();
			}
			selectedNode = node;
			if (null != node)
			{
				node.isNodeSelected = true;
				node.CalcState();
				node.SetConnectionHighlights();
			}
		}
	}

	private void AdvanceSelectionFrom(bool animate)
	{
		if (null == selectedNode || selectedNode.correctPathIndex < 0)
		{
			return;
		}
		ResearchOutlet researchOutlet = actualPathConnections[selectedNode.correctPathIndex];
		if (!researchOutlet.outboundNode.isRevealed)
		{
			return;
		}
		if (animate)
		{
			AnimateReveal(researchOutlet.connection);
		}
		else
		{
			researchOutlet.connection.Reveal();
		}
		if (researchOutlet.outboundNode == end)
		{
			DeclareVictory();
			return;
		}
		if (GameManager.Instance.gameState == GameState.InGame)
		{
			MenuManager.Instance.PlayStarParticles(researchOutlet.outboundNode.transform.position);
		}
		SetSelectedNode(researchOutlet.outboundNode);
		AdvanceSelectionFrom(animate);
	}

	public void TryEliminateConnections(ResearchNode node, int numToRemove)
	{
		tempConnectionList.Clear();
		foreach (ResearchOutlet connection in node.connections)
		{
			if (connection.connection.IsEliminationCandidate())
			{
				tempConnectionList.Add(connection.connection);
			}
		}
		GameUtility.Shuffle(tempConnectionList);
		foreach (ResearchConnection tempConnection in tempConnectionList)
		{
			tempConnection.BecomeUnavailable();
			numToRemove--;
			if (numToRemove <= 0)
			{
				break;
			}
		}
	}

	public void RuleOutAllInvalidConnections()
	{
		foreach (List<ResearchNode> node in nodes)
		{
			foreach (ResearchNode item in node)
			{
				RuleOutConnections(item);
			}
		}
	}

	private float XpForRevealingCorrectNode()
	{
		return 5f * GameManager.Instance.MultiplierForGlobalPerk(PerkType.MinigameXPGainSpeed);
	}

	private void RevealQueuedNode()
	{
		revealTimer = 0f;
		if (null == queuedNode)
		{
			return;
		}
		ResearchNode researchNode = queuedNode;
		bool flag = false;
		researchNode.Reveal();
		if (researchNode.correctPathIndex >= 0)
		{
			float amount = XpForRevealingCorrectNode();
			AnimateToExperience(researchNode.transform, levelStat.iconItem, amount);
			float num = RewardPerNode();
			EarnReward(num);
			AnimateItemGain(researchNode.transform, num, 2);
			MenuManager.Instance.PlayStarParticles(researchNode.transform.position);
			foreach (ResearchOutlet connection in researchNode.connections)
			{
				if (connection.outboundNode.isRevealed && connection.connection.isInCorrectPath)
				{
					AnimateReveal(connection.connection);
				}
			}
		}
		else
		{
			flag = true;
			researchNode.transform.DOShakePosition(2f);
		}
		RuleOutAllInvalidConnections();
		AdvanceSelectionFrom(animate: true);
		CalcNodeStates();
		CalcConnectionStates();
		if (flag && minigameState == MinigameState.Running)
		{
			ConsumeAttempt();
		}
	}

	public void OnClickedNode(ResearchNode node)
	{
		if (node.isRevealed || revealTimer > 0f || minigameState == MinigameState.Success)
		{
			return;
		}
		if (minigameState == MinigameState.Failure)
		{
			AnimateFailure();
			return;
		}
		queuedNode = node;
		bool flag = false;
		if (null != selectedNode)
		{
			foreach (ResearchOutlet connection in selectedNode.connections)
			{
				if (connection.outboundNode == node)
				{
					flag = true;
					break;
				}
			}
		}
		if (flag)
		{
			revealTimer = 0.3f;
			MenuManager.Instance.PlayChargePathParticles(selectedNode.transform.position, node.transform.position, 0.3f);
		}
		else
		{
			RevealQueuedNode();
		}
	}

	private void ClearNodes()
	{
		foreach (List<ResearchNode> node in nodes)
		{
			foreach (ResearchNode item in node)
			{
				item.connections.Clear();
				item.shuffledConnections.Clear();
				Object.Destroy(item.gameObject);
			}
		}
		nodes.Clear();
	}

	private void ClearConnections()
	{
		foreach (List<ResearchNode> node in nodes)
		{
			foreach (ResearchNode item in node)
			{
				item.connections.Clear();
				item.shuffledConnections.Clear();
			}
		}
		actualPathConnections.Clear();
		tempConnectionList.Clear();
		foreach (ResearchConnection connection in connections)
		{
			Object.Destroy(connection.gameObject);
		}
		connections.Clear();
	}

	protected override void LoadNewMinigame()
	{
		base.LoadNewMinigame();
		colCount = 8;
		CreateNodes();
		DeriveStartAndEnd();
		DeriveAllConnections();
		foreach (ResearchConnection connection in connections)
		{
			connection.isAvailable = true;
		}
		maxNumAttempts = 3;
		DisplayAttemptIcons(maxNumAttempts);
		FindRandomPath();
		FlagCorrectNodesFromActualPath();
		ReloadNodeLabels();
		CalcNodeStates();
		CalcConnectionStates();
		start.Reveal();
		end.Reveal();
		TryEliminateConnections(start, 1);
		TryEliminateConnections(end, 1);
		ResearchOutlet researchOutlet = actualPathConnections[3];
		researchOutlet.connection.Reveal();
		researchOutlet.connection.n1.Reveal();
		researchOutlet.connection.n2.Reveal();
		if (actualPath.Count > 10)
		{
			actualPath[8].Reveal();
		}
		tempConnectionList.Clear();
		tempConnectionList.AddRange(connections);
		GameUtility.Shuffle(tempConnectionList);
		int num = 25;
		foreach (ResearchConnection tempConnection in tempConnectionList)
		{
			if (tempConnection.IsEliminationCandidate())
			{
				tempConnection.BecomeUnavailable();
				num--;
				if (num <= 0)
				{
					break;
				}
			}
		}
		RuleOutAllInvalidConnections();
		SetSelectedNode(start);
		minigameState = MinigameState.Running;
	}

	private void AnimateReveal(ResearchConnection c)
	{
		if (!c.isRevealed && c.isInCorrectPath)
		{
			_ = c.n1.correctPathIndex;
			_ = c.n2.correctPathIndex;
		}
		c.Reveal();
	}

	private void RuleOutConnections(ResearchNode testNode)
	{
		if (minigameState == MinigameState.Success)
		{
			foreach (ResearchOutlet connection in testNode.connections)
			{
				if (!connection.connection.isInCorrectPath)
				{
					connection.connection.RuleOut();
				}
			}
			return;
		}
		if (!testNode.isRevealed)
		{
			return;
		}
		if (testNode.correctPathIndex < 0)
		{
			if (!testNode.isRevealed)
			{
				return;
			}
			{
				foreach (ResearchOutlet connection2 in testNode.connections)
				{
					connection2.connection.RuleOut();
				}
				return;
			}
		}
		int testNum = 2;
		if (testNode == start || testNode == end)
		{
			testNum = 1;
		}
		if (testNode.HasRevealedConnections(testNum))
		{
			foreach (ResearchOutlet connection3 in testNode.connections)
			{
				if (connection3.connection.isInCorrectPath && connection3.outboundNode.isRevealed)
				{
					connection3.connection.Reveal();
				}
				else
				{
					connection3.connection.RuleOut();
				}
			}
		}
		else
		{
			foreach (ResearchOutlet connection4 in testNode.connections)
			{
				if (connection4.connection.isInCorrectPath && connection4.outboundNode.isRevealed)
				{
					connection4.connection.Reveal();
				}
			}
		}
		if (!testNode.isRevealed)
		{
			return;
		}
		foreach (ResearchOutlet connection5 in testNode.connections)
		{
			if (connection5.outboundNode.isRevealed && !connection5.connection.isInCorrectPath)
			{
				connection5.connection.RuleOut();
			}
		}
	}

	public override fsData GetData()
	{
		Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
		StoreCommonData(dictionary);
		dictionary["count"] = new fsData(colCount);
		List<fsData> list = new List<fsData>();
		foreach (List<ResearchNode> node in nodes)
		{
			foreach (ResearchNode item in node)
			{
				list.Add(GetNodeData(item));
			}
		}
		dictionary["Items"] = new fsData(list);
		List<fsData> list2 = new List<fsData>();
		foreach (ResearchConnection connection in connections)
		{
			if (connection.isAvailable)
			{
				list2.Add(GetConnectionData(connection));
			}
		}
		dictionary["Connections"] = new fsData(list2);
		return new fsData(dictionary);
	}

	protected override void LoadFromDictionary(Dictionary<string, fsData> dataDictionary)
	{
		base.LoadFromDictionary(dataDictionary);
		if (dataDictionary.TryGetValue("count", out var value) && value.TryAsInt(out var i))
		{
			colCount = i;
			for (int j = 0; j < colCount; j++)
			{
				nodes.Add(new List<ResearchNode>());
			}
		}
		if (dataDictionary.TryGetValue("Items", out var value2) && value2.TryAsList(out var result))
		{
			foreach (fsData item in result)
			{
				if (item.TryAsDictionary(out var result2) && result2.TryGetValue("Coord", out var value3) && result2.TryGetValue("xPos", out var value4) && value4.TryAsDouble(out var f) && result2.TryGetValue("yPos", out var value5) && value5.TryAsDouble(out var f2))
				{
					Coord coord = SaveFile.CoordFromData(value3);
					ResearchNode researchNode = LoadNode(coord.x, coord.y);
					researchNode.offsetX = (float)f;
					researchNode.offsetY = (float)f2;
					if (result2.TryGetValue("index", out var value6) && value6.TryAsInt(out var i2))
					{
						researchNode.correctPathIndex = i2;
					}
					if (result2.ContainsKey("revealed"))
					{
						researchNode.isRevealed = true;
					}
				}
			}
		}
		if (!dataDictionary.TryGetValue("Connections", out var value7) || !value7.TryAsList(out var result3))
		{
			return;
		}
		foreach (fsData item2 in result3)
		{
			if (item2.TryAsDictionary(out var result4) && result4.TryGetValue("start", out var value8) && result4.TryGetValue("end", out var value9))
			{
				Coord c = SaveFile.CoordFromData(value8);
				Coord c2 = SaveFile.CoordFromData(value9);
				ResearchNode researchNode2 = NodeAtCoord(c);
				ResearchNode researchNode3 = NodeAtCoord(c2);
				if (null != researchNode2 && null != researchNode3)
				{
					Connect(researchNode2, researchNode3);
				}
			}
		}
	}

	protected override void PostProcessLoadedData()
	{
		foreach (ResearchConnection connection in connections)
		{
			connection.isAvailable = true;
		}
		if (minigameState == MinigameState.Running || minigameState == MinigameState.Failure || minigameState == MinigameState.Success)
		{
			DeriveStartAndEnd();
			ClearPathInfo();
			LoadActualPathFrom(start);
			RuleOutAllInvalidConnections();
			if (minigameState == MinigameState.Success)
			{
				SetSelectedNode(null);
			}
			else
			{
				SetSelectedNode(start);
				AdvanceSelectionFrom(animate: false);
			}
			ReloadNodeLabels();
			CalcNodeStates();
			CalcConnectionStates();
		}
		base.PostProcessLoadedData();
	}

	private void LoadActualPathFrom(ResearchNode n)
	{
		if (null == n)
		{
			return;
		}
		actualPath.Add(n);
		foreach (ResearchOutlet connection in n.connections)
		{
			if (connection.outboundNode.correctPathIndex == n.correctPathIndex + 1)
			{
				actualPathConnections.Add(connection);
				connection.connection.isInCorrectPath = true;
				LoadActualPathFrom(connection.outboundNode);
			}
		}
	}

	private fsData GetNodeData(ResearchNode node)
	{
		Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
		dictionary["Coord"] = SaveFile.DataFromCoord(new Coord(node.x, node.y));
		dictionary["xPos"] = new fsData(node.offsetX);
		dictionary["yPos"] = new fsData(node.offsetY);
		if (node.correctPathIndex >= 0)
		{
			dictionary["index"] = new fsData(node.correctPathIndex);
		}
		if (node.isRevealed)
		{
			dictionary["revealed"] = fsData.True;
		}
		return new fsData(dictionary);
	}

	private fsData GetConnectionData(ResearchConnection c)
	{
		Dictionary<string, fsData> dict = new Dictionary<string, fsData>
		{
			["start"] = SaveFile.DataFromCoord(new Coord(c.n1.x, c.n1.y)),
			["end"] = SaveFile.DataFromCoord(new Coord(c.n2.x, c.n2.y))
		};
		_ = c.isRuledOut;
		return new fsData(dict);
	}

	public override bool ShouldBeAvailable()
	{
		return false;
	}
}
