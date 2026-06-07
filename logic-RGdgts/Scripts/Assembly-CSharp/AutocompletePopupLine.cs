using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AutocompletePopupLine : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IScrollHandler
{
	public TextMeshProUGUI nameText;

	public TextMeshProUGUI typeText;

	private CodeEditorAutocompletePopup popup;

	private AutocompleteEntry entry;

	public void Setup(CodeEditorAutocompletePopup popup, AutocompleteEntry entry)
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public void OnScroll(PointerEventData eventData)
	{
	}
}
