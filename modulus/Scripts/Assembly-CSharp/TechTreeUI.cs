using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Data.TechTree.Validators;
using Data.Variables;
using Presentation.UI;
using Presentation.UI.TechTree;
using UnityEngine;
using UnityEngine.UI;

public class TechTreeUI : MonoBehaviour
{
	[SerializeField]
	private TechTreeUIConnections _techTreeConnections;

	[SerializeField]
	private TechTreeManager _techTreeManager;

	[SerializeField]
	private TechTreeUIZoom _techTreeUIZoom;

	[SerializeField]
	private TechTreeFilterView _filterView;

	[SerializeField]
	private TechTreeNodeView _techTreeNodeViewPrefab;

	[SerializeField]
	private TechTreeNodeView _techTreeNodeViewMediumPrefab;

	[SerializeField]
	private TechTreeNodeView _techTreeNodeViewLargePrefab;

	[SerializeField]
	private TechTreeNodeView _techTreeNodeViewExtraLargePrefab;

	[SerializeField]
	private ScrollRect _scrollRect;

	[SerializeField]
	private ScrollRectShortCut _scrollRectPanning;

	[SerializeField]
	private RectTransform _content;

	[SerializeField]
	private RectTransform _nodeParent;

	[SerializeField]
	private RectTransform _connectionParent;

	[SerializeField]
	private int _nodesUpdatedPerFrameWhenZooming = 16;

	[SerializeField]
	private float _sidePadding = 8f;

	[SerializeField]
	private TechTreeGrid _techTreeGrid;

	[SerializeField]
	private IntVariableSO _lastUnlockedNodeID;

	[SerializeField]
	private TechTreeUIReveal _techTreeUIReveal;

	private readonly Dictionary<TechTreeNodeSO, TechTreeNodeView> _techTreeNodeViews = new Dictionary<TechTreeNodeSO, TechTreeNodeView>();

	private Rect _boundingBox;

	private float _boundsOffset = 2000f;

	private TechTreeNodeView _focusedNode;

	private Vector2 _gridCenter;

	private Vector2Int _gridCenterInt;

	private int _currentZoomTier = -1;

	private bool _didFocusOnNode;

	private TechTreeSO _techTreeSO;

	private bool _nodeViewUpdateCoroutineIsRunning;

	private Coroutine _nodeViewUpdateCoroutine;

	private bool _revealing;

	public Dictionary<TechTreeNodeSO, TechTreeNodeView> TechTreeNodeViews => _techTreeNodeViews;

	private void OnDisable()
	{
		foreach (TechTreeNodeSO node in _techTreeSO.Nodes)
		{
			node.RevealingRunTimeValue = false;
		}
		if (_revealing)
		{
			_techTreeUIReveal.CancelReveal();
			EndReveal();
		}
	}

	public void ShowTree(TechTreeSO techTreeSO)
	{
		_techTreeSO = techTreeSO;
		InitializeDisplay();
		if (techTreeSO.Nodes.Count != 0)
		{
			CalculateGridBounds(techTreeSO, out var minBounds, out var maxBounds);
			_gridCenter = CalculateGridCenter(minBounds, maxBounds);
			_gridCenterInt = Vector2Int.RoundToInt(_gridCenter);
			UpdateBoundingBox(minBounds, maxBounds);
			CenterAndScaleParents(minBounds, maxBounds);
			PositionAllNodes(techTreeSO, _gridCenter);
		}
	}

	public void PositionAtFocusedNode()
	{
		_didFocusOnNode = true;
		_techTreeUIZoom.ResetZoomLevel();
		FocusNode(_focusedNode);
	}

	public void FocusNode(TechTreeNodeView node)
	{
		Canvas.ForceUpdateCanvases();
		_content.anchoredPosition = (Vector2)_scrollRect.transform.InverseTransformPoint(_content.position) - (Vector2)_scrollRect.transform.InverseTransformPoint(node.transform.position);
	}

	public void PanToPosition(Vector2 point, float seconds, TweenCallback onCompleteCallback = null)
	{
		Vector2 point2 = new Vector2(point.x / _scrollRect.content.sizeDelta.x, point.y / _scrollRect.content.sizeDelta.y);
		PanToNormalizedPosition(point2, seconds, onCompleteCallback);
	}

	public void Reveal(Vector2 panStartPosition, Vector2 panTargetPosition, float panTime, BoolVariableSO techTreeShowBool)
	{
		foreach (TechTreeNodeSO node in _techTreeSO.Nodes)
		{
			if (NodeHasBool(node, techTreeShowBool))
			{
				node.RevealingRunTimeValue = true;
			}
		}
		techTreeShowBool.SetValue(value: true);
		_filterView.ToggleAllOn();
		SetMinZoom();
		LockMovements(toggle: true);
		SetToPosition(panStartPosition);
		PanToPosition(panTargetPosition, panTime);
		_techTreeUIZoom.LockZoom(toggle: true);
		_revealing = true;
		_techTreeUIReveal.Reveal(panTime, techTreeShowBool, OnRevealComplete);
	}

	private bool NodeHasBool(TechTreeNodeSO node, BoolVariableSO techTreeShowBool)
	{
		foreach (AbstractTechTreeNodeValidator showValidator in node.ShowValidators)
		{
			if (showValidator is BoolVariableValidator boolVariableValidator && boolVariableValidator.CompareBoolVariableSO(techTreeShowBool))
			{
				return true;
			}
		}
		return false;
	}

	private void OnRevealComplete()
	{
		EndReveal();
		_techTreeConnections.Clear();
		foreach (TechTreeNodeSO node in _techTreeSO.Nodes)
		{
			_techTreeConnections.DrawNodeConnections(node, _gridCenterInt);
		}
	}

	private void EndReveal()
	{
		_scrollRect.DOKill();
		foreach (TechTreeNodeSO node in _techTreeSO.Nodes)
		{
			node.RevealingRunTimeValue = false;
		}
		LockMovements(toggle: false);
		_techTreeUIZoom.LockZoom(toggle: false);
		_revealing = false;
	}

	public void LockMovements(bool toggle)
	{
		_scrollRect.enabled = !toggle;
	}

	public void SetToPosition(Vector2 point)
	{
		Vector2 normalizedPosition = new Vector2(point.x / _scrollRect.content.sizeDelta.x, point.y / _scrollRect.content.sizeDelta.y);
		_scrollRect.normalizedPosition = normalizedPosition;
	}

	public void SetMinZoom()
	{
		_techTreeUIZoom.SetMinZoom();
	}

	public void PanToNormalizedPosition(Vector2 point01, float seconds, TweenCallback onCompleteCallback = null)
	{
		_scrollRect.DONormalizedPos(point01, seconds).SetEase(Ease.InOutSine).OnComplete(onCompleteCallback);
	}

	public void ScrollZoom(float zoomScale, int zoomTier)
	{
		if (_revealing)
		{
			return;
		}
		_scrollRectPanning.ScaleSensitivityFromDefault(1f / zoomScale);
		if (_currentZoomTier == zoomTier)
		{
			return;
		}
		_currentZoomTier = zoomTier;
		_techTreeConnections.Clear();
		Dictionary<TechTreeNodeSO, TechTreeNodeView>.ValueCollection values = _techTreeNodeViews.Values;
		foreach (TechTreeNodeView item in values)
		{
			_techTreeConnections.SetZoomSize(item.TechTreeNodeSo, _gridCenterInt, zoomTier);
		}
		if (_nodeViewUpdateCoroutineIsRunning)
		{
			StopCoroutine(_nodeViewUpdateCoroutine);
		}
		if (base.gameObject.activeInHierarchy)
		{
			_nodeViewUpdateCoroutine = StartCoroutine(UpdateNodeViews(values, zoomScale, zoomTier, _nodesUpdatedPerFrameWhenZooming));
		}
	}

	private IEnumerator UpdateNodeViews(Dictionary<TechTreeNodeSO, TechTreeNodeView>.ValueCollection values, float zoomScale, int zoomTier, int nodesPerFrame = 8)
	{
		Vector3 scrollRectCenter = _scrollRect.viewport.TransformPoint(_scrollRect.viewport.rect.center);
		IOrderedEnumerable<TechTreeNodeView> orderedEnumerable = values.OrderBy((TechTreeNodeView n) => Vector2.Distance(n.transform.position, scrollRectCenter));
		_nodeViewUpdateCoroutineIsRunning = true;
		int currentIndex = 0;
		foreach (TechTreeNodeView item in orderedEnumerable)
		{
			item.transform.localScale = Vector3.one * (1f / zoomScale);
			item.SetZoomSize(zoomTier);
			currentIndex++;
			if (currentIndex >= nodesPerFrame)
			{
				currentIndex = 0;
				yield return null;
			}
		}
		_nodeViewUpdateCoroutineIsRunning = false;
	}

	public void ReShowCurrentTree()
	{
		ShowTree(_techTreeSO);
	}

	private void InitializeDisplay()
	{
		_techTreeConnections.Clear();
		_techTreeGrid.ShowGrid();
	}

	private void CalculateGridBounds(TechTreeSO techTreeSO, out Vector2 minBounds, out Vector2 maxBounds)
	{
		minBounds = new Vector2(float.MaxValue, float.MaxValue);
		maxBounds = new Vector2(float.MinValue, float.MinValue);
		foreach (TechTreeNodeSO node in techTreeSO.Nodes)
		{
			minBounds = Vector2.Min(minBounds, node.GridPosition);
			maxBounds = Vector2.Max(maxBounds, node.GridPosition);
		}
		minBounds -= new Vector2(_sidePadding, _sidePadding);
		maxBounds += new Vector2(_sidePadding, _sidePadding);
	}

	private Vector2 CalculateGridCenter(Vector2 minBounds, Vector2 maxBounds)
	{
		return (minBounds + maxBounds) * 0.5f;
	}

	private void UpdateBoundingBox(Vector2 minBounds, Vector2 maxBounds)
	{
		Vector2 vector = maxBounds - minBounds;
		_boundingBox = new Rect(minBounds, vector * _techTreeGrid.CellSize);
	}

	private void CenterAndScaleParents(Vector2 minBounds, Vector2 maxBounds)
	{
		if (!(_nodeParent == null))
		{
			float x = _scrollRect.content.localScale.x;
			Vector2 parentProperties = _boundingBox.size * x;
			SetParentProperties(parentProperties);
			_content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _boundingBox.height + _boundsOffset);
			_content.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _boundingBox.width + _boundsOffset);
		}
	}

	private void SetParentProperties(Vector2 scaledSize)
	{
		_nodeParent.sizeDelta = _boundingBox.size;
		_connectionParent.sizeDelta = _boundingBox.size;
		_connectionParent.anchorMin = Vector2.one * 0.5f;
		_connectionParent.anchorMax = Vector2.one * 0.5f;
	}

	private void CenterParents(Vector2 minBounds, Vector2 maxBounds)
	{
		Vector2Int gridPosition = Vector2Int.FloorToInt(minBounds);
		Vector2Int gridPosition2 = Vector2Int.CeilToInt(maxBounds);
		Vector3 vector = _techTreeGrid.GridToCanvasPositionCenter(gridPosition);
		Vector3 vector2 = _techTreeGrid.GridToCanvasPositionCenter(gridPosition2);
		Vector3 localPosition = (vector + vector2) * 0.5f;
		_nodeParent.localPosition = localPosition;
		_connectionParent.localPosition = localPosition;
	}

	private void PositionAllNodes(TechTreeSO techTreeSO, Vector2 gridCenter)
	{
		foreach (TechTreeNodeSO node in techTreeSO.Nodes)
		{
			if (node.CanShowNode())
			{
				Vector2 position = CalculateNodePosition(node.GridPosition, _gridCenterInt);
				TechTreeNodeView orCreateNodeView = GetOrCreateNodeView(node, position);
				orCreateNodeView.IsFilteredOut = node.Tag != 0 && (_filterView.CurrentFilters & node.Tag) == 0;
				_techTreeConnections.DrawNodeConnections(node, _gridCenterInt);
				if (!_didFocusOnNode && ((_lastUnlockedNodeID.Value > 0 && node.ID == _lastUnlockedNodeID.Value) || node.IsDefaultFocused))
				{
					_focusedNode = orCreateNodeView;
				}
			}
		}
	}

	private Vector2 CalculateNodePosition(Vector2Int gridPosition, Vector2Int gridCenter)
	{
		Vector3 vector = _techTreeGrid.GridToCanvasPositionCenter(gridPosition);
		Vector3 vector2 = _techTreeGrid.GridToCanvasPositionCenter(gridCenter);
		return vector - vector2;
	}

	private TechTreeNodeView GetOrCreateNodeView(TechTreeNodeSO node, Vector2 position)
	{
		if (_techTreeNodeViews.TryGetValue(node, out var value))
		{
			UpdateExistingNodeView(value, node, position);
			return value;
		}
		return CreateNewNodeView(node, position);
	}

	private void UpdateExistingNodeView(TechTreeNodeView view, TechTreeNodeSO node, Vector2 position)
	{
		view.Show(node);
		view.transform.localPosition = position;
	}

	private TechTreeNodeView GetPrefab(NodeTier tier)
	{
		return tier switch
		{
			NodeTier.Medium => _techTreeNodeViewMediumPrefab, 
			NodeTier.Large => _techTreeNodeViewLargePrefab, 
			NodeTier.ExtraLarge => _techTreeNodeViewExtraLargePrefab, 
			_ => _techTreeNodeViewPrefab, 
		};
	}

	private TechTreeNodeView CreateNewNodeView(TechTreeNodeSO node, Vector2 position)
	{
		TechTreeNodeView techTreeNodeView = UnityEngine.Object.Instantiate(GetPrefab(node.Tier), Vector3.zero, Quaternion.identity, _nodeParent);
		techTreeNodeView.transform.localPosition = position;
		techTreeNodeView.Show(node);
		SubscribeToNodeEvents(techTreeNodeView);
		_techTreeNodeViews.Add(node, techTreeNodeView);
		return techTreeNodeView;
	}

	private void SubscribeToNodeEvents(TechTreeNodeView nodeView)
	{
		nodeView.OnClickNode = (Action<TechTreeNodeSO>)Delegate.Combine(nodeView.OnClickNode, new Action<TechTreeNodeSO>(_techTreeManager.HandleNodeClickEvent));
	}
}
