using I2.Loc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TooltipButton : RewiredButtonDeprecated, IGraphicStatesProvider
{
	private readonly string[] STATES = new string[5] { "Normal", "Highlighted", "Pressed", "Selected", "Disabled" };

	[Header("Tooltip")]
	[SerializeField]
	private TooltipButtonTooltip _tooltipPrefab;

	[SerializeField]
	protected LocalizedString _tooltipMessage = null;

	private bool _pointerIsOver;

	private GraphicStates[] _graphicStates;

	private SelectionState _graphicState;

	public string[] States => STATES;

	protected override void Awake()
	{
		base.Awake();
		_graphicStates = GetComponentsInChildren<GraphicStates>();
		SetGraphicState(base.currentSelectionState, initialize: true);
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		if (Application.isPlaying && base.interactable)
		{
			_tooltipPrefab.Close(this);
		}
		SetGraphicState(base.currentSelectionState);
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		if (Application.isPlaying)
		{
			_tooltipPrefab.Close(this);
		}
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		base.OnPointerClick(eventData);
		if (!base.interactable && _pointerIsOver)
		{
			_tooltipPrefab.Display(ReturnTooltip(), this, eventData.position);
		}
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		_pointerIsOver = true;
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		base.OnPointerExit(eventData);
		_pointerIsOver = false;
		_tooltipPrefab.Close(this);
	}

	public void SetTooltipMessage(LocalizedString message)
	{
		_tooltipMessage = message;
	}

	public virtual string ReturnTooltip()
	{
		return _tooltipMessage;
	}

	public void PreviewState(string state)
	{
		GraphicStates[] componentsInChildren = GetComponentsInChildren<GraphicStates>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].PreviewState(state, propagate: false);
		}
	}

	private void SetGraphicState(SelectionState selectionState, bool initialize = false)
	{
		if (_graphicState != selectionState || initialize)
		{
			string state = STATES[(int)selectionState];
			GraphicStates[] graphicStates = _graphicStates;
			for (int i = 0; i < graphicStates.Length; i++)
			{
				graphicStates[i].SetState(state);
			}
			_graphicState = selectionState;
		}
	}
}
