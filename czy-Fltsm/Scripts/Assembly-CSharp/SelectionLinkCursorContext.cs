using System;
using System.Collections;
using PajamaLlama.UI;
using UnityEngine;
using UnityEngine.PajamaLlama;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Flotsam/Cursor Properties/Contexts/SelectionLinkCursorContext")]
public class SelectionLinkCursorContext : CursorContext
{
	[Serializable]
	public class ObjectTypeActions
	{
		public ObjectType ObjectType;

		public Sprite Sprite;

		public SelectionLinkActionBase[] Actions;

		public void SetContext(SelectionLink selectionLink)
		{
			if (!Actions.IsNullOrEmpty())
			{
				SelectionLinkActionBase[] actions = Actions;
				for (int i = 0; i < actions.Length; i++)
				{
					actions[i].SetContext(selectionLink);
				}
			}
		}
	}

	[SerializeField]
	[FormerlySerializedAs("_objectTypeActions")]
	[NamedArrayElement(new string[] { "ObjectType" })]
	private ObjectTypeActions[] _objectTypeSettings;

	[SerializeField]
	private RewiredAction _selectAction = new RewiredAction(93, null);

	[SerializeField]
	private RewiredAction _contextMenuAction = new RewiredAction(93, null);

	private SelectionLink _selectionLink;

	private ObjectTypeActions _actions;

	private SelectionLink _interactSelectionLink;

	public override SelectionLink SelectionLink => _selectionLink;

	public override ActionBase[] Actions => (_actions == null) ? null : _actions.Actions;

	public override Sprite CrosshairIcon
	{
		get
		{
			if (_actions != null)
			{
				return _actions.Sprite;
			}
			return null;
		}
	}

	public override bool TryActivate(CursorManager cursorManager)
	{
		if ((bool)cursorManager.SelectionLink)
		{
			if (_selectionLink != cursorManager.SelectionLink)
			{
				if ((bool)_selectionLink)
				{
					_selectionLink.UpdateCursor(hasHit: false);
				}
				_selectionLink = cursorManager.SelectionLink;
				_actions = ReturnObjectTypeSettings(_selectionLink);
				if (GameManager.UIManager.UIState == UIState.Architect)
				{
					_actions = null;
				}
				else
				{
					cursorManager.StartCoroutine(TooltipCoroutine(_selectionLink, cursorManager.Settings.TooltipDelay));
				}
				GameManager.HighlightManager.ResetOutlineHover();
				GameManager.HighlightManager.AddOutlineHover(_selectionLink);
			}
			if (Actions.IsNullOrEmpty())
			{
				UIManager.AddRewiredActionInfoToContext(this, _selectAction);
			}
			else
			{
				UIManager.AddRewiredActionInfoToContext(this, _selectAction, _contextMenuAction);
			}
			_selectionLink.UpdateCursor(hasHit: true);
			return true;
		}
		ClearSelectionLink();
		_interactSelectionLink = null;
		return false;
	}

	public override void Deactivate()
	{
		ClearSelectionLink();
	}

	public override void EnableRadialMenu()
	{
		if (!RadialMenu.IsEnabled)
		{
			if (_selectAction.GetButtonDown())
			{
				_interactSelectionLink = SelectionLink;
			}
			else if (FlotsamInputManager.GetButtonShortPress(93))
			{
				RadialMenu.Enable(this);
			}
			else if (_selectAction.GetButtonUp() && (bool)_interactSelectionLink && _interactSelectionLink == SelectionLink)
			{
				Selector.Select(SelectionLink);
			}
		}
	}

	private IEnumerator TooltipCoroutine(SelectionLink tooltipSelectionLink, float delay)
	{
		yield return new WaitForSecondsRealtime(delay);
		if ((bool)tooltipSelectionLink && _selectionLink == tooltipSelectionLink)
		{
			tooltipSelectionLink.ShowTooltip();
			while ((bool)tooltipSelectionLink && _selectionLink == tooltipSelectionLink)
			{
				yield return null;
			}
			TooltipPanel.HideTooltip();
		}
	}

	private void ClearSelectionLink()
	{
		if ((bool)_selectionLink)
		{
			_selectionLink.UpdateCursor(hasHit: false);
			_selectionLink = null;
			_actions = null;
			UIManager.DisableRewiredActionInfoContext(this);
			GameManager.HighlightManager.ResetOutlineHover();
		}
	}

	public ObjectTypeActions ReturnObjectTypeSettings(SelectionLink selectionLink)
	{
		ObjectTypeActions[] objectTypeSettings = _objectTypeSettings;
		foreach (ObjectTypeActions objectTypeActions in objectTypeSettings)
		{
			if (objectTypeActions.ObjectType == selectionLink.Type)
			{
				objectTypeActions.SetContext(selectionLink);
				return objectTypeActions;
			}
		}
		return null;
	}
}
