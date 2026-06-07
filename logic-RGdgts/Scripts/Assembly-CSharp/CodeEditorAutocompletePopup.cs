using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CodeEditorAutocompletePopup : CodeEditorPopup, IScrollHandler, IEventSystemHandler
{
	public Transform root;

	public Scrollbar scrollbar;

	public int maxLines;

	public float scrollSpeed;

	[NonSerialized]
	[HideInInspector]
	public RetroUICodeEditor codeEditor;

	private LayoutHelper<AutocompletePopupLine> layout;

	public RectTransform selector;

	public int selectedI;

	private RectTransform rectTransform;

	private float lineHeight;

	private VerticalLayoutGroup verticalLayout;

	private Stack<AutocompletePopupLine> linePooler;

	private int lastScrollOffset;

	private string filter;

	private RetroUIText.TextCoord autocompleteBeginCoord;

	private List<AutocompleteEntry> filteredEntries;

	public Action<AutocompleteEntry, RetroUIText.TextCoord, int> onSeletion;

	public Action onCancel;

	public float Width => 0f;

	public float Height => 0f;

	public override bool OnLeft()
	{
		return false;
	}

	public override bool OnRight()
	{
		return false;
	}

	public override bool OnDown()
	{
		return false;
	}

	public override bool OnUp()
	{
		return false;
	}

	public override bool OnSubmit()
	{
		return false;
	}

	public override bool OnTab()
	{
		return false;
	}

	public override bool OnCancel()
	{
		return false;
	}

	private void Awake()
	{
	}

	private void LateUpdate()
	{
	}

	public void CheckCaretPosition()
	{
	}

	private void Clear()
	{
	}

	private AutocompletePopupLine AddLine(string name)
	{
		return null;
	}

	public void Refresh(AutocompleteResult result, string filter, RetroUIText.TextCoord autocompleteBeginCoord)
	{
	}

	public bool IsActive()
	{
		return false;
	}

	public void Show(AutocompleteResult result, string filter, RetroUIText.TextCoord autocompleteBeginCoord)
	{
	}

	public void Hide()
	{
	}

	public void OnScroll(PointerEventData eventData)
	{
	}

	public void MoveSelection(int direction)
	{
	}

	public void ConfirmSelection()
	{
	}

	public void OnSelection(AutocompleteEntry entry)
	{
	}
}
