using PajamaLlama.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class TooltipTriggerBase : MonoBehaviour, IPointerMoveHandler, IEventSystemHandler, ISelectHandler, IDeselectHandler
{
	[SerializeField]
	private bool _triggerOnSelect;

	[SerializeField]
	private float _triggerOnSelectDuration;

	private bool _hasPointerOver;

	private bool _hasSelection;

	private bool _selectedWhilePaused;

	private float _selectionTime;

	protected virtual void Update()
	{
		if (_hasSelection && 0f < _triggerOnSelectDuration)
		{
			if (_selectedWhilePaused)
			{
				_selectionTime += Time.unscaledDeltaTime;
			}
			else
			{
				_selectionTime += GameSpeedManager.PausableUnscaledDeltaTime;
			}
			if (_triggerOnSelectDuration <= _selectionTime)
			{
				OnDeselect();
			}
		}
	}

	private void OnDisable()
	{
		OnDeselect();
	}

	public void OnPointerMove(PointerEventData eventData)
	{
		if (eventData.IsPointerOver(base.gameObject, checkIsParent: true))
		{
			if (!_hasPointerOver)
			{
				OnPointerEnter();
				_hasPointerOver = true;
			}
		}
		else if (_hasPointerOver)
		{
			OnPointerExit();
			_hasPointerOver = false;
		}
	}

	public void OnSelect(BaseEventData eventData = null)
	{
		if (_triggerOnSelect)
		{
			SetPointerOver(pointerIsOver: true);
			_hasSelection = true;
			_selectedWhilePaused = GameManager.Gamepaused;
			_selectionTime = 0f;
		}
	}

	public void OnDeselect(BaseEventData eventDate = null)
	{
		if (_hasPointerOver)
		{
			SetPointerOver(pointerIsOver: false);
			_hasSelection = false;
		}
	}

	private void SetPointerOver(bool pointerIsOver)
	{
		if (pointerIsOver)
		{
			if (!_hasPointerOver)
			{
				OnPointerEnter();
				_hasPointerOver = true;
				GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
			}
		}
		else if (_hasPointerOver)
		{
			OnPointerExit();
			_hasPointerOver = false;
			GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
		}
	}

	private void OnActiveInputUpdated(GameEvent gameEvent)
	{
		SetPointerOver(pointerIsOver: false);
		_hasSelection = false;
	}

	protected abstract void OnPointerEnter();

	protected abstract void OnPointerExit();
}
