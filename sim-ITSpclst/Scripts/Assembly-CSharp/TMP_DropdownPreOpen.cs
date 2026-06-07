using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TMP_DropdownPreOpen : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public TMP_Dropdown dropdown;

	public UnityEvent Actions;

	public void OnPointerClick(PointerEventData eventData)
	{
	}
}
