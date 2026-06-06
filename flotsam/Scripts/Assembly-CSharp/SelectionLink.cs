using System;
using System.Collections.Generic;
using PajamaLlama.Debugs;
using UnityEngine;
using UnityEngine.Events;

public class SelectionLink : SceneBehaviour
{
	[Serializable]
	private class OnSelectedEvent : UnityEvent<bool>
	{
	}

	[SerializeField]
	[Tooltip("The default cursor stated used when no listeners have been assigned to the OnUnderCursor event.")]
	private CursorState _defaultUnderCursorState = CursorState.Select;

	[SerializeField]
	private UnityEvent _onCursorEnter = new UnityEvent();

	[SerializeField]
	private UnityEvent _onCursorStay = new UnityEvent();

	[SerializeField]
	private UnityEvent _onCursorExit = new UnityEvent();

	[SerializeField]
	[Tooltip("Flag that determines of _onShowTooltip is invoked when SelectionLink.ShowTooltip is called.")]
	private bool _invokeOnShowTooltip;

	[SerializeField]
	private UnityEvent _onShowTooltip = new UnityEvent();

	[SerializeField]
	private OnSelectedEvent _onSelected = new OnSelectedEvent();

	[SerializeField]
	private UnityEvent _onDeselected = new UnityEvent();

	[HideInInspector]
	public ObjectType Type;

	public static List<SelectionLink> SelectionLinks = new List<SelectionLink>();

	private ISelectable[] _selectables;

	private bool _isHovered;

	public GameObject ObjectToSelect { get; private set; }

	public bool IsSelectable => WorldManager.IsInInteractionRadius(base.transform.position);

	public OutlineRendererComponent OutlineRenderer { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		OutlineRenderer = GetComponentInParent<OutlineRendererComponent>();
		if (ObjectToSelect == null)
		{
			base.enabled = false;
		}
		SelectionLinks.Add(this);
	}

	private void OnDestroy()
	{
		Selector.Deselect(this);
		SelectionLinks.Remove(this);
		_onCursorStay.RemoveAllListeners();
		_onCursorExit.RemoveAllListeners();
		_onShowTooltip.RemoveAllListeners();
		_onSelected.RemoveAllListeners();
		_onDeselected.RemoveAllListeners();
	}

	public void UpdateCursor(bool hasHit)
	{
		if (hasHit)
		{
			if (_isHovered)
			{
				if (_onCursorStay.GetPersistentEventCount() == 0)
				{
					CursorManager.SetCursorState(_defaultUnderCursorState);
				}
				else
				{
					_onCursorStay.Invoke();
				}
				return;
			}
			if (_onCursorEnter.GetPersistentEventCount() == 0)
			{
				CursorManager.SetCursorState(_defaultUnderCursorState);
			}
			else
			{
				_onCursorEnter.Invoke();
			}
			_isHovered = true;
		}
		else if (_isHovered)
		{
			if (_onCursorExit.GetPersistentEventCount() == 0)
			{
				CursorManager.SetCursorState(_defaultUnderCursorState);
			}
			else
			{
				_onCursorExit.Invoke();
			}
			_isHovered = false;
		}
	}

	public void ShowTooltip()
	{
		if (_invokeOnShowTooltip)
		{
			_onShowTooltip.Invoke();
		}
	}

	public void Select(bool playSelectionSound)
	{
		_onSelected.Invoke(playSelectionSound);
	}

	public void Deselect()
	{
		_onDeselected.Invoke();
	}

	public void SetObjectToSelect(GameObject objectToSelect, ObjectType objectType, bool changeInitialObject = false)
	{
		if (!(ObjectToSelect != null) || changeInitialObject)
		{
			ObjectToSelect = objectToSelect;
			Type = objectType;
			_selectables = objectToSelect.GetComponentsInChildren<ISelectable>();
			base.enabled = ObjectToSelect != null;
		}
	}

	public void SetOnCursorStayListener(UnityAction listener)
	{
		if (0 < _onCursorStay.GetPersistentEventCount())
		{
			Debugger.Warning("OnCursorStay listener is being set at runtime, but there is already a persistent listener set.");
		}
		_onCursorStay.AddListener(listener);
	}

	public void SetOnShowTooltipListener(UnityAction listener)
	{
		if (0 < _onShowTooltip.GetPersistentEventCount())
		{
			Debugger.Warning("OnShowTooltip listener is being set at runtime, but there is already a persistent listener set.");
		}
		_onShowTooltip.AddListener(listener);
	}

	public void SetOnSelectedListener(UnityAction<bool> listener)
	{
		if (0 < _onSelected.GetPersistentEventCount())
		{
			Debug.LogWarningFormat("The OnSelected listener for Selection Link '{0}' with object-to-select '{1}' is being set at runtime, but there is already a persistent listener set.", base.name, ObjectToSelect ? ObjectToSelect.name : "null");
		}
		_onSelected.AddListener(listener);
	}

	public void SetOnDeselectedListener(UnityAction listener)
	{
		if (0 < _onDeselected.GetPersistentEventCount())
		{
			Debugger.Warning("OnDeselected listener is being set at runtime, but there is already a persistent listener set.");
		}
		_onDeselected.AddListener(listener);
	}

	public new T GetComponent<T>() where T : Component
	{
		if (ObjectToSelect == null)
		{
			return null;
		}
		return ObjectToSelect.GetComponent<T>();
	}

	public T ReturnSelectable<T>() where T : UnityEngine.Object, ISelectable
	{
		if (_selectables.IsNullOrEmpty())
		{
			return null;
		}
		int num = _selectables.Length;
		while (0 < num--)
		{
			T val = _selectables[num] as T;
			if ((bool)val)
			{
				return val;
			}
		}
		return null;
	}
}
