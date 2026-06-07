using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeselectDropdown : MonoBehaviour, IDeselectHandler, IEventSystemHandler
{
	public Dropdown dropdown;

	public void OnDeselect(BaseEventData eventData)
	{
		dropdown.Hide();
	}
}
