using UnityEngine;
using UnityEngine.EventSystems;

public class UiFocusManager : MonoBehaviour
{
	private GameObject lastSelected;

	private void Update()
	{
		EventSystem current = EventSystem.current;
		if (current.m_CurrentSelected == null)
		{
			if (lastSelected != null && Input.GetMouseButtonDown(0))
			{
				current.SetSelectedGameObject(lastSelected);
			}
		}
		else
		{
			lastSelected = current.m_CurrentSelected;
		}
	}
}
