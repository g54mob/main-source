using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class FocusConsoleInputField : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	[SerializeField]
	private TMP_InputField inputField;

	public void OnPointerDown(PointerEventData eventData)
	{
		EventSystem.current.SetSelectedGameObject(inputField.gameObject);
		inputField.ActivateInputField();
		inputField.Select();
		inputField.MoveTextEnd(shift: false);
	}
}
