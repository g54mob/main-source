using System.Collections.Generic;
using Assets.Code.GUI.General;
using PajamaLlama.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UI.PajamaLlama;

public class TechTreePanel : Panel, IFocusTarget, ISelectableMoveHandler, ScrollRectZoomHandler.IHandler
{
	[Header("Tech Tree Panel")]
	[SerializeField]
	private TechTreePanelInfo _infoPanel;

	[SerializeField]
	private TechTreePanelNode _panelNodePrefab;

	[SerializeField]
	private Transform _nodeParent;

	[SerializeField]
	private TechTreePanelEdge _panelEdgePrefab;

	[SerializeField]
	private Transform _edgeParent;

	[SerializeField]
	private ScrollRect _scrollRect;

	[SerializeField]
	private ScrollRectSelectionScroller _scrollRectSelectionScroller;

	[SerializeField]
	private RectTransform _scrollRectContentContainer;

	[SerializeField]
	private RectOffset _contentPadding;

	[SerializeField]
	private Vector2 _nodeOffset;

	[Header("Focus Target")]
	[SerializeField]
	[Tooltip("The input types for which this SelectableGroup should be initialized.")]
	private InputFlags _supportedInputTypes = InputFlags.Joystick;

	[Header("Zooming")]
	[SerializeField]
	private ScrollRectZoomHandler _zoomHandler;

	[SerializeField]
	private float _intitalZoom = 0.75f;

	[SerializeField]
	private float _zoomSpeed = 1f;

	private TechTree _techTree;

	private List<TechTreePanelNode> _nodes;

	private List<TechTreePanelEdge> _edges;

	private TechTreePanelNode _selectedNode;

	private Rect _contentContainerRect;

	private float _contentContainerScale;

	private float _contentContainerMinScale;

	private float _zoom;

	public int Priority => 1;

	public GameObject SelectedGameObject
	{
		get
		{
			if (!_selectedNode)
			{
				return null;
			}
			return _selectedNode.gameObject;
		}
	}

	public bool SelectedGameObjectIsActiveAndEnabled
	{
		get
		{
			if ((bool)_selectedNode)
			{
				return _selectedNode.isActiveAndEnabled;
			}
			return false;
		}
	}

	private void Awake()
	{
		_techTree = GameManager.Settings.TechTree;
		_nodes = new List<TechTreePanelNode>(_techTree.Nodes.Count);
		Vector2 vector = new Vector2(float.MaxValue, float.MaxValue);
		Vector2 vector2 = new Vector2(float.MinValue, float.MinValue);
		RectTransform rectTransform = _panelNodePrefab.transform as RectTransform;
		foreach (TechTreeNode node in _techTree.Nodes)
		{
			vector = Vector2.Min(vector, node.Position);
			vector2 = Vector2.Max(vector2, node.Position);
		}
		vector += rectTransform.rect.min;
		vector2 += rectTransform.rect.max;
		_contentContainerRect = new Rect(vector, vector2 - vector);
		Vector2 offset = new Vector2(0f - _contentContainerRect.min.x, 0f - _contentContainerRect.center.y);
		foreach (TechTreeNode node2 in _techTree.Nodes)
		{
			TechTreePanelNode techTreePanelNode = Object.Instantiate(_panelNodePrefab, _nodeParent);
			techTreePanelNode.Initialize(node2, offset, this);
			techTreePanelNode.OnClick.AddListener(SelectNode);
			_nodes.Add(techTreePanelNode);
		}
		_edges = new List<TechTreePanelEdge>(_techTree.Nodes.Count);
		foreach (TechTreePanelNode node3 in _nodes)
		{
			if (node3.Node.Dependencies.IsNullOrEmpty())
			{
				continue;
			}
			foreach (TechTreeNode dependency in node3.Node.Dependencies)
			{
				if (TryGetPanelNode(out var panelNode, dependency))
				{
					TechTreePanelEdge techTreePanelEdge = Object.Instantiate(_panelEdgePrefab, _edgeParent);
					techTreePanelEdge.Initialize(panelNode, node3);
					_edges.Add(techTreePanelEdge);
				}
			}
		}
		Rect rect = _scrollRect.viewport.rect;
		Rect rect2 = new Rect(rect.position.x, rect.position.y, rect.size.x - (float)_contentPadding.horizontal, rect.size.y - (float)_contentPadding.vertical);
		_contentContainerMinScale = Mathf.Max(rect2.size.x / _contentContainerRect.size.x, rect2.size.y / _contentContainerRect.size.y);
		_scrollRectContentContainer.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _contentContainerRect.size.x);
		_scrollRectContentContainer.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _contentContainerRect.size.y);
		_scrollRectContentContainer.localPosition = new Vector2(_contentPadding.left, (_contentPadding.bottom - _contentPadding.top) / 2);
		_zoomHandler.OverrideHandling(this);
		ApplyZoom(_intitalZoom);
	}

	private void OnEnable()
	{
		if (_selectedNode == null)
		{
			foreach (TechTreePanelNode node in _nodes)
			{
				if (node.Node.FirstSelected)
				{
					_selectedNode = node;
					break;
				}
			}
			if ((bool)_selectedNode && (FlotsamInputManager.ActiveInput & _supportedInputTypes) == 0)
			{
				FinalUpdate.RegisterEndOfFrameOneShot(CenterOnSelectedNode);
			}
		}
		if ((FlotsamInputManager.ActiveInput & _supportedInputTypes) != InputFlags.None)
		{
			FocusManager.RequestFocus(this);
		}
		GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, OnActiveInputChanged);
	}

	private void CenterOnSelectedNode()
	{
		_scrollRectSelectionScroller.SnapToGameObject(_selectedNode.gameObject);
	}

	private void LateUpdate()
	{
		if (FlotsamInputManager.HasActiveInput(_supportedInputTypes))
		{
			FocusManager.RequestFocus(this);
		}
	}

	private void OnDisable()
	{
		FocusManager.ReleaseFocus(this);
		GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, OnActiveInputChanged);
		_infoPanel.gameObject.SetActive(value: false);
	}

	private void OnDestroy()
	{
		foreach (TechTreePanelNode node in _nodes)
		{
			node.OnClick.RemoveListener(SelectNode);
		}
	}

	public bool TryGetPanelNode(out TechTreePanelNode panelNode, TechTreeNode techTreeNode)
	{
		int count = _nodes.Count;
		for (int i = 0; i < count; i++)
		{
			panelNode = _nodes[i];
			if (panelNode.Node == techTreeNode)
			{
				return true;
			}
		}
		panelNode = null;
		return false;
	}

	public void OnFocusGained()
	{
	}

	public void OnFocusLost()
	{
	}

	public void OnCurrentSelectedSelectableChanged(Selectable selectable)
	{
		if (selectable is TechTreePanelNode node)
		{
			SelectNode(node);
		}
	}

	private void SelectNode(TechTreePanelNode node)
	{
		if (_nodes.Contains(node))
		{
			_selectedNode = node;
			_infoPanel.SetNode(node);
		}
	}

	public void OnMove(Selectable selectable, AxisEventData eventData)
	{
		TechTreePanelNode node = selectable as TechTreePanelNode;
		switch (eventData.moveDir)
		{
		case MoveDirection.Up:
			eventData.Navigate(FindNodeOnUp(node, 250f));
			break;
		case MoveDirection.Right:
			eventData.Navigate(FindNodeOnRight(node, eventData));
			break;
		case MoveDirection.Down:
			eventData.Navigate(FindNodeOnDown(node, 250f));
			break;
		case MoveDirection.Left:
			eventData.Navigate(FindNodeOnLeft(node, eventData));
			break;
		}
	}

	private Selectable FindNodeOnUp(TechTreePanelNode node, float maxDeviationX)
	{
		TechTreePanelNode result = null;
		Transform transform = node.transform;
		float num = float.MaxValue;
		foreach (TechTreePanelNode node2 in _nodes)
		{
			Transform obj = node2.transform;
			float num2 = Mathf.Abs(obj.localPosition.x - transform.localPosition.x);
			float num3 = obj.localPosition.y - transform.localPosition.y;
			if (!(node == node2) && !(num3 < 0f) && !(maxDeviationX < num2))
			{
				num3 = Mathf.Abs(num3);
				if (num3 < num)
				{
					num = num3;
					result = node2;
				}
			}
		}
		return result;
	}

	private Selectable FindNodeOnRight(TechTreePanelNode node, AxisEventData eventData)
	{
		TechTreePanelEdge techTreePanelEdge = null;
		float num = float.MaxValue;
		foreach (TechTreePanelEdge edge in _edges)
		{
			if (edge.StartNode == node)
			{
				float num2 = Vector2.Angle(eventData.moveVector, edge.Vector);
				if (num2 < num)
				{
					techTreePanelEdge = edge;
					num = num2;
				}
			}
		}
		if (!techTreePanelEdge)
		{
			return null;
		}
		return techTreePanelEdge.EndNode;
	}

	private Selectable FindNodeOnDown(TechTreePanelNode node, float maxDeviationX)
	{
		TechTreePanelNode result = null;
		Transform transform = node.transform;
		float num = float.MaxValue;
		foreach (TechTreePanelNode node2 in _nodes)
		{
			Transform obj = node2.transform;
			float num2 = Mathf.Abs(obj.localPosition.x - transform.localPosition.x);
			float num3 = obj.localPosition.y - transform.localPosition.y;
			if (!(node == node2) && !(0f < num3) && !(maxDeviationX < num2))
			{
				num3 = Mathf.Abs(num3);
				if (num3 < num)
				{
					num = num3;
					result = node2;
				}
			}
		}
		return result;
	}

	private Selectable FindNodeOnLeft(TechTreePanelNode node, AxisEventData eventData)
	{
		TechTreePanelEdge techTreePanelEdge = null;
		float num = float.MaxValue;
		foreach (TechTreePanelEdge edge in _edges)
		{
			if (edge.EndNode == node)
			{
				float num2 = Vector2.Angle(eventData.moveVector, -edge.Vector);
				if (num2 < num)
				{
					techTreePanelEdge = edge;
					num = num2;
				}
			}
		}
		if (!techTreePanelEdge)
		{
			return null;
		}
		return techTreePanelEdge.StartNode;
	}

	private void OnActiveInputChanged(GameEvent gameEvent)
	{
		if (FlotsamInputManager.HasActiveInput(_supportedInputTypes))
		{
			FocusManager.RequestFocus(this);
			if ((bool)_selectedNode)
			{
				_infoPanel.SetNode(_selectedNode);
			}
		}
		else
		{
			FocusManager.ReleaseFocus(this);
			_infoPanel.gameObject.SetActive(value: false);
		}
	}

	public void OnScroll(PointerEventData eventData)
	{
		_ = _scrollRect.content.rect;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(_scrollRectContentContainer, eventData.position, eventData.pressEventCamera, out var localPoint);
		ApplyZoom(Mathf.Clamp(_zoom + eventData.scrollDelta.y * _zoomSpeed, 0f, 1f));
		_ = _scrollRect.content.rect;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(_scrollRectContentContainer, eventData.position, eventData.pressEventCamera, out var localPoint2);
		_scrollRect.content.anchoredPosition += (localPoint2 - localPoint) * _contentContainerScale;
	}

	private float ApplyZoom(float zoom)
	{
		_zoom = zoom;
		_contentContainerScale = Mathf.Lerp(_contentContainerMinScale, 1f, zoom);
		_scrollRectContentContainer.localScale = new Vector3(_contentContainerScale, _contentContainerScale, _contentContainerScale);
		_scrollRect.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _contentContainerRect.size.x * _contentContainerScale + (float)_contentPadding.horizontal);
		_scrollRect.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _contentContainerRect.size.y * _contentContainerScale + (float)_contentPadding.vertical);
		_scrollRect.GraphicUpdateComplete();
		return _contentContainerScale;
	}
}
