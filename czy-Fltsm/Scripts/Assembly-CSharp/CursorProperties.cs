using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;

public abstract class CursorProperties : PersistentProperties
{
	private const int MAXIMUM_BUTTON_COUNT = 5;

	[SerializeField]
	[Tooltip("The type of the cursor.")]
	[FormerlySerializedAs("Cursor")]
	public CursorState _defaultCursor = CursorState.Salvage;

	[SerializeField]
	private RewiredAction _interact = new RewiredAction(93, "UI_Interact");

	[SerializeField]
	private RewiredAction _cancel = new RewiredAction(102, "UI_Cancel");

	[SerializeField]
	private bool _dialogBlocksInteraction;

	public UnityEvent OnChangeCanBeDeactivated;

	[NonSerialized]
	private float[] clickTimes;

	[NonSerialized]
	protected bool _canBeDeactivated = true;

	public override Types Type => Types.CursorProperties;

	public CursorState Cursor { get; protected set; }

	public bool CanBeDeactivated => _canBeDeactivated;

	public RewiredAction Interact => _interact;

	public RewiredAction Cancel => _cancel;

	public virtual void ActivateRewiredActions()
	{
		_interact.ActivateWait();
		_cancel.ActivateWait();
	}

	public abstract void Activate();

	public abstract void UpdateCursor(CursorManager cursor);

	public abstract void DeactivateImmediately();

	public virtual bool TryToDeactivate(CursorManager cursor)
	{
		if (GetCancel())
		{
			cursor.Deactivate(cancelled: true);
			return true;
		}
		return false;
	}

	public virtual bool DisplayExitPanel()
	{
		return false;
	}

	public void InitializeCursorState()
	{
		Cursor = _defaultCursor;
	}

	public bool GetInteract()
	{
		if (!EventSystem.current.IsPointerOverGameObject() && _interact.GetButtonUp())
		{
			return IsBlockedByDialog();
		}
		return false;
	}

	public bool GetCancelDown()
	{
		if (_cancel.GetButtonDown())
		{
			return IsBlockedByDialog();
		}
		return false;
	}

	public bool GetCancel()
	{
		if (_cancel.GetButtonUp())
		{
			return IsBlockedByDialog();
		}
		return false;
	}

	private bool IsBlockedByDialog()
	{
		if (_dialogBlocksInteraction)
		{
			return PopUpDialog.Instance.CanPopup;
		}
		return true;
	}

	public virtual void DrawGizmos()
	{
	}
}
