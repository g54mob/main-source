using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UI.PajamaLlama;

public class TechTreePanelNode : Selectable, IPointerClickHandler, IEventSystemHandler, ISubmitHandler, IGraphicStatesProvider
{
	public enum NodeStates
	{
		None = 0,
		Locked = 1,
		Researchable = 2,
		Researched = 3
	}

	[Header("Components")]
	[SerializeField]
	private TextMeshProUGUI _title;

	[SerializeField]
	private Image _icon;

	[SerializeField]
	private TechTreePanelRequirement _requirmentIconPrefab;

	[SerializeField]
	private TechTreePanelUnlockable _unlockableIconPrefab;

	[SerializeField]
	private ChildBehaviourCache<TechTreePanelUnlockable> _unlockableIconCache;

	[SerializeField]
	private ImageSegmentBar _progressBar;

	[Header("Positioning")]
	[SerializeField]
	[Tooltip("Used to compensate for differences in the orientation of the axis between the Tech Tree Editor and the Tech Tree Panel.")]
	private Vector2 _axisMultiplier = new Vector2(1f, -1f);

	[SerializeField]
	[Tooltip("Used to scale the positions in the Tech Tree Editor to better work in the Tech Tree Panel.")]
	private float _positionMultiplier = 1.25f;

	[Header("Edges")]
	[SerializeField]
	private Transform _edgeStart;

	[SerializeField]
	private Image _edgeStartVisual;

	[SerializeField]
	private Transform _edgeEnd;

	[Header("Animation")]
	[SerializeField]
	private string _interactTrigger = "Interact";

	[SerializeField]
	private string _researchingParameter = "Researching";

	[SerializeField]
	private string _researchSpeedParameter = "ResearchSpeed";

	[SerializeField]
	[Tooltip("This value multiplied by the amount of research stations working on this nodes research equals the animation speed.")]
	private float _researchSpeedMultiplier = 0.5f;

	[Header("Unknown")]
	[SerializeField]
	private string _unknownCharacter = "?";

	[SerializeField]
	private Sprite _unknowIcon;

	private ISelectableMoveHandler _moveHandler;

	private Animator _animator;

	private CommunityResearch _communityResearch;

	private GraphicStates[] _graphicStates;

	private NodeStates _state;

	private bool _update;

	public string[] States { get; } = Enum.GetNames(typeof(NodeStates));

	public TechTreeNode Node { get; private set; }

	public Vector2 EdgeStart { get; private set; }

	public Vector2 EdgeEnd { get; private set; }

	public UnityEvent<TechTreePanelNode> OnClick { get; private set; } = new UnityEvent<TechTreePanelNode>();

	public UnityEvent OnUpdated { get; private set; } = new UnityEvent();

	protected override void Awake()
	{
		base.Awake();
		_animator = GetComponent<Animator>();
	}

	protected override void OnEnable()
	{
		_state = NodeStates.None;
		if (_update)
		{
			UpdateTitleIconAndUnlockables();
		}
		OnResearchEvent();
		base.OnEnable();
	}

	private void LateUpdate()
	{
		if (_update)
		{
			UpdateTitleIconAndUnlockables();
		}
	}

	protected override void OnDestroy()
	{
		foreach (TechTreeRequirement requirement in Node.Requirements)
		{
			if (requirement.UpdateGUIEvent != GameEventType.None)
			{
				GameEventDispatcher.RemoveListener(requirement.UpdateGUIEvent, OnUpdate);
			}
		}
		GameEventDispatcher.RemoveListener(GameEventType.ResearchProgressPointsUpdated, OnResearchEvent);
		GameEventDispatcher.RemoveListener(GameEventType.ResearchStarted, OnResearchEvent);
		GameEventDispatcher.RemoveListener(GameEventType.ResearchCancelled, OnResearchEvent);
		GameEventDispatcher.RemoveListener(GameEventType.ResearchFinished, OnResearchEvent);
		GameEventDispatcher.RemoveListener(GameEventType.ResearchStationBuilt, OnResearchEvent);
		GameEventDispatcher.RemoveListener(GameEventType.ResearchStationStart, OnResearchEvent);
		GameEventDispatcher.RemoveListener(GameEventType.ResearchStationStop, OnResearchEvent);
		GameEventDispatcher.RemoveListener(GameEventType.BuildableBuilt, OnResearchEvent);
		GameEventDispatcher.RemoveListener(GameEventType.BuildableSalvaged, OnResearchEvent);
		GameEventDispatcher.RemoveListener(GameEventType.AgentRescue, OnResearchEvent);
		GameEventDispatcher.RemoveListener(GameEventType.AgentDeath, OnResearchEvent);
		base.OnDestroy();
	}

	public override void OnMove(AxisEventData eventData)
	{
		if (_moveHandler != null)
		{
			_moveHandler.OnMove(this, eventData);
		}
		else
		{
			base.OnMove(eventData);
		}
	}

	public void OnPointerClick(PointerEventData data)
	{
		OnClick.Invoke(this);
	}

	public void OnSubmit(BaseEventData eventData)
	{
		this.ResetTriggers();
		base.animator.ResetTrigger(_interactTrigger);
		base.animator.SetTrigger(_interactTrigger);
	}

	private void OnInteract()
	{
		if (Node.IsResearchable())
		{
			if (_communityResearch.IsCurrentResearch(Node))
			{
				_communityResearch.CancelResearch();
			}
			else if (BuildingDevTools.InstantUnlock)
			{
				Node.Unlock();
				OnResearchEvent();
			}
			else if (Node.IsResearchable())
			{
				_communityResearch.StartResearch(Node);
			}
		}
	}

	public void Initialize(TechTreeNode node, Vector2 offset, ISelectableMoveHandler moveHandler)
	{
		Node = node;
		_moveHandler = moveHandler;
		RectTransform rectTransform = base.transform as RectTransform;
		rectTransform.anchoredPosition = (node.Position + offset) * _axisMultiplier * _positionMultiplier;
		EdgeStart = rectTransform.anchoredPosition + (Vector2)_edgeStart.localPosition;
		EdgeEnd = rectTransform.anchoredPosition + (Vector2)_edgeEnd.localPosition;
		foreach (TechTreeRequirement requirement in node.Requirements)
		{
			if (requirement.UpdateGUIEvent != GameEventType.None)
			{
				GameEventDispatcher.AddListener(requirement.UpdateGUIEvent, OnUpdate);
			}
			if (!requirement.Flags.HasFlag(TechTreeRequirementFlags.Hidden))
			{
				UnityEngine.Object.Instantiate(_requirmentIconPrefab, _requirmentIconPrefab.transform.parent).Initialize(requirement);
			}
		}
		UpdateTitleIconAndUnlockables();
		_communityResearch = Community.PlayerCommunity.Research;
		_graphicStates = GetComponentsInChildren<GraphicStates>(includeInactive: true);
		GameEventDispatcher.AddListener(GameEventType.ResearchProgressPointsUpdated, OnResearchEvent);
		GameEventDispatcher.AddListener(GameEventType.ResearchStarted, OnResearchEvent);
		GameEventDispatcher.AddListener(GameEventType.ResearchCancelled, OnResearchEvent);
		GameEventDispatcher.AddListener(GameEventType.ResearchFinished, OnResearchEvent);
		GameEventDispatcher.AddListener(GameEventType.ResearchStationBuilt, OnResearchEvent);
		GameEventDispatcher.AddListener(GameEventType.ResearchStationStart, OnResearchEvent);
		GameEventDispatcher.AddListener(GameEventType.ResearchStationStop, OnResearchEvent);
		GameEventDispatcher.AddListener(GameEventType.BuildableBuilt, OnResearchEvent);
		GameEventDispatcher.AddListener(GameEventType.BuildableSalvaged, OnResearchEvent);
		GameEventDispatcher.AddListener(GameEventType.AgentRescue, OnResearchEvent);
		GameEventDispatcher.AddListener(GameEventType.AgentDeath, OnResearchEvent);
		if (base.gameObject.activeInHierarchy)
		{
			OnResearchEvent();
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
	}

	public void EnableEdgeStartVisual()
	{
		_edgeStartVisual?.gameObject.SetActive(value: true);
	}

	public void PreviewState(string state)
	{
		GraphicStates[] componentsInChildren = GetComponentsInChildren<GraphicStates>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].SetState(state);
		}
	}

	private void OnUpdate(GameEvent gameEvent)
	{
		_update = true;
	}

	private void UpdateTitleIconAndUnlockables()
	{
		_title.text = Node.GetNameUnknownified(_unknownCharacter);
		if ((bool)Node.Icon)
		{
			_icon.sprite = GetIcon(Node);
		}
		_unlockableIconCache.Reset();
		foreach (ResearchUnlockable unlockable in Node.Unlockables)
		{
			_unlockableIconCache.Get(active: true).Initialize(Node, unlockable);
		}
		_unlockableIconCache.Trim();
		_update = false;
	}

	private void OnResearchEvent(GameEvent gameEvent = null)
	{
		if (!base.isActiveAndEnabled || _communityResearch == null)
		{
			return;
		}
		if (_communityResearch.IsCurrentResearch(Node))
		{
			int activeResearchStationCount = _communityResearch.GetActiveResearchStationCount();
			float num = ((activeResearchStationCount == 0) ? 0f : _researchSpeedMultiplier);
			for (int i = 1; i < activeResearchStationCount; i++)
			{
				num *= 2f;
			}
			_animator.SetBool(_researchingParameter, value: true);
			_animator.SetFloat(_researchSpeedParameter, num);
		}
		else
		{
			_animator.SetBool(_researchingParameter, value: false);
		}
		if (Node.IsUnlocked())
		{
			SetState(NodeStates.Researched);
		}
		else if (BuildingDevTools.InstantUnlock || Node.IsResearchable())
		{
			SetState(NodeStates.Researchable);
		}
		else
		{
			SetState(NodeStates.Locked);
		}
		if ((bool)_progressBar)
		{
			if (_communityResearch.TryResearchGetProgress(Node, out var progress))
			{
				_progressBar.transform.parent.gameObject.SetActive(value: true);
				_progressBar.SetValue(progress, Node.Cost);
			}
			else
			{
				_progressBar.transform.parent.gameObject.SetActive(value: false);
			}
		}
		OnUpdated.Invoke();
	}

	private void SetState(NodeStates state)
	{
		if (state != _state)
		{
			GraphicStates[] graphicStates = _graphicStates;
			for (int i = 0; i < graphicStates.Length; i++)
			{
				graphicStates[i].SetState(state.ToString());
			}
			if (_state != NodeStates.None)
			{
				_animator.SetBool(state.ToString(), value: false);
			}
			_state = state;
			if (_state != NodeStates.None)
			{
				_animator.SetBool(state.ToString(), value: true);
			}
		}
	}

	protected override void DoStateTransition(SelectionState state, bool instant)
	{
		if (base.animator.isActiveAndEnabled)
		{
			base.animator.ResetTrigger(_interactTrigger);
		}
		base.DoStateTransition(state, instant);
	}

	public override void OnSelect(BaseEventData eventData)
	{
		if (!(eventData is PointerEventData))
		{
			base.OnSelect(eventData);
		}
	}

	public override void OnDeselect(BaseEventData eventData)
	{
		if (!(eventData is PointerEventData))
		{
			base.OnDeselect(eventData);
		}
	}

	private Sprite GetIcon(TechTreeNode node)
	{
		if (!node.IsUnknown())
		{
			return node.Icon;
		}
		return _unknowIcon;
	}
}
