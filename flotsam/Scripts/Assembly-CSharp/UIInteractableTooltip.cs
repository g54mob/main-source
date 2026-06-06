using System;
using I2.Loc;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInteractableTooltip : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerMoveHandler, IPointerClickHandler
{
	private enum PointerEvents
	{
		None = 0,
		PointerEnter = 1,
		PointerExit = 2,
		PointerMove = 3,
		PointerClick = 4
	}

	[Serializable]
	private class TooltipTrigger : ITooltipProvider
	{
		public LocalizedString Text;

		public bool Delayed;

		public TooltipButtonTooltip TooltipPrefab;

		public PointerEvents _showEvent;

		public PointerEvents _hideEvent;

		private UIInteractable _uiInteractable;

		public void Initialize(UIInteractable uiInteractable)
		{
			_uiInteractable = uiInteractable;
		}

		public void OnPointerEvent(PointerEvents pointerEvent, PointerEventData pointerEventData)
		{
			if (pointerEvent == _showEvent)
			{
				if ((bool)TooltipPrefab)
				{
					TooltipPrefab.Display(Text, this, pointerEventData.position);
				}
				else
				{
					TooltipPanel.ShowTooltip(this, Delayed);
				}
			}
			else if (pointerEvent == _hideEvent)
			{
				HideTooltip();
			}
		}

		public void HideTooltip()
		{
			if ((bool)TooltipPrefab)
			{
				TooltipPrefab.Close(this);
			}
			else
			{
				TooltipPanel.HideTooltip(this);
			}
		}

		public string GetTooltip(TooltipBuilder tooltipBuilder)
		{
			string text = (((string)Text == null) ? Text.mTerm : Text.ToString());
			int actionId = ((_uiInteractable == null) ? (-1) : _uiInteractable.RewiredAction);
			return TextManager.ReplaceVariables(text, FlotsamInputManager.RewiredPlayer.controllers.maps.GetFirstButtonMapWithAction(actionId, skipDisabledMaps: true));
		}
	}

	[SerializeField]
	private UIInteractable _target;

	[SerializeField]
	private TooltipTrigger _interableTooltip;

	[SerializeField]
	private TooltipTrigger _nonInteractableTooltip;

	private void OnValidate()
	{
		Awake();
	}

	private void Awake()
	{
		if (_target == null)
		{
			_target = GetComponent<UIInteractable>();
		}
		base.enabled = _target != null;
		_interableTooltip.Initialize(_target);
		_nonInteractableTooltip.Initialize(_target);
	}

	private void Update()
	{
		if (_target.IsInteractable)
		{
			_nonInteractableTooltip.HideTooltip();
		}
		else
		{
			_interableTooltip.HideTooltip();
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		OnPointerEvent(PointerEvents.PointerEnter, eventData);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		OnPointerEvent(PointerEvents.PointerExit, eventData);
	}

	public void OnPointerMove(PointerEventData eventData)
	{
		OnPointerEvent(PointerEvents.PointerMove, eventData);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		OnPointerEvent(PointerEvents.PointerClick, eventData);
	}

	private void OnPointerEvent(PointerEvents pointerEvent, PointerEventData eventData)
	{
		if (_target.IsInteractable)
		{
			_interableTooltip?.OnPointerEvent(pointerEvent, eventData);
		}
		else
		{
			_nonInteractableTooltip?.OnPointerEvent(pointerEvent, eventData);
		}
	}
}
