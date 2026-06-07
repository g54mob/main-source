using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResearchNode : MenuButton
{
	public TextMeshProUGUI label;

	[NonSerialized]
	public readonly List<ResearchOutlet> connections = new List<ResearchOutlet>();

	[NonSerialized]
	public readonly List<ResearchOutlet> shuffledConnections = new List<ResearchOutlet>();

	public Image researchImage;

	public MinigamePanelResearch parentPanel;

	public int x;

	public int y;

	public float offsetX;

	public float offsetY;

	public RectTransform rectTransform;

	public bool pathExcludeFlag;

	public int distance;

	public ResearchNode searchParent;

	public bool isQueued;

	public int weight;

	public bool isHovered;

	public bool isNodeSelected;

	public bool isHighlighted;

	public bool isRevealed;

	public int correctPathIndex;

	protected override void Awake()
	{
		base.Awake();
		rectTransform = GetComponent<RectTransform>();
	}

	public void ResetNode()
	{
		isHighlighted = false;
		isRevealed = false;
		isNodeSelected = false;
		isHovered = false;
		correctPathIndex = -1;
	}

	public void UpdateDynamicDisplay()
	{
		_ = isNodeSelected;
	}

	public void Shuffle()
	{
		shuffledConnections.Clear();
		shuffledConnections.AddRange(connections);
		GameUtility.Shuffle(shuffledConnections);
	}

	public void UpdatePosition()
	{
		rectTransform.SetPosX(offsetX * 70f);
		rectTransform.SetPosY(offsetY * 70f);
	}

	public bool TryGetOutletToNode(ResearchNode other, out ResearchOutlet connection)
	{
		foreach (ResearchOutlet connection2 in connections)
		{
			if (connection2.outboundNode == other)
			{
				connection = connection2;
				return true;
			}
		}
		connection = null;
		return false;
	}

	public bool TryGetConnectionToNode(ResearchNode other, out ResearchConnection connection)
	{
		if (TryGetOutletToNode(other, out var connection2))
		{
			connection = connection2.connection;
			return true;
		}
		connection = null;
		return false;
	}

	public void OnClickedNode()
	{
		parentPanel.OnClickedNode(this);
	}

	public void ClearPathInfo()
	{
		distance = 0;
		searchParent = null;
		isQueued = false;
		pathExcludeFlag = false;
		weight = 0;
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		parentPanel.OnHoveredNode(this);
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		base.OnPointerExit(eventData);
		parentPanel.OnHoverOutNode(this);
	}

	public void Reveal()
	{
		isRevealed = true;
		CalcState();
		ReloadLabel();
	}

	public void ReloadLabel()
	{
		if (isRevealed)
		{
			if (correctPathIndex >= 0)
			{
				TextDisplay.SetNumber(label, correctPathIndex);
			}
			else
			{
				label.text = "X";
			}
		}
		else
		{
			label.text = string.Empty;
		}
	}

	public void CalcState()
	{
		if (isRevealed)
		{
			if (correctPathIndex >= 0)
			{
				base.buttonState = CustomButtonState.Default;
			}
			else
			{
				base.buttonState = CustomButtonState.Invalid;
			}
		}
		else if (isNodeSelected)
		{
			base.buttonState = CustomButtonState.Default;
		}
		else if (isHighlighted)
		{
			base.buttonState = CustomButtonState.HighlightFlashing;
		}
		else
		{
			base.buttonState = CustomButtonState.Disabled;
		}
	}

	public void ClearConnectionHighlights()
	{
		foreach (ResearchOutlet connection in connections)
		{
			connection.outboundNode.isHighlighted = false;
			connection.outboundNode.CalcState();
			connection.connection.isHighlighted = false;
			connection.connection.CalcState();
		}
	}

	public void SetConnectionHighlights()
	{
		foreach (ResearchOutlet connection in connections)
		{
			if (!connection.connection.isAvailable || connection.connection.isRuledOut)
			{
				continue;
			}
			if (!connection.outboundNode.isHighlighted && !connection.outboundNode.isRevealed)
			{
				if (GameManager.Instance.gameState == GameState.InGame)
				{
					connection.outboundNode.DoPunchAnimation();
					connection.outboundNode.transform.DOShakeRotation(1f, 20f);
				}
				connection.outboundNode.isHighlighted = true;
				connection.outboundNode.CalcState();
			}
			connection.connection.isHighlighted = true;
			connection.connection.CalcState();
		}
	}

	public bool HasRevealedConnections(int testNum)
	{
		int num = 0;
		foreach (ResearchOutlet connection in connections)
		{
			if (connection.connection.isInCorrectPath && connection.outboundNode.isRevealed)
			{
				num++;
				if (num >= testNum)
				{
					return true;
				}
			}
		}
		return false;
	}

	public void DebugPrintConnections()
	{
		foreach (ResearchOutlet connection in connections)
		{
			_ = connection;
		}
	}

	public override string ToString()
	{
		if (correctPathIndex >= 0)
		{
			return "[Research Node " + correctPathIndex + "]";
		}
		return "[Research Node x " + x + " y " + y + "]";
	}
}
