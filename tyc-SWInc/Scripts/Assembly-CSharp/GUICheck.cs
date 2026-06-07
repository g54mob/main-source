using UnityEngine;
using UnityEngine.EventSystems;

public class GUICheck : MonoBehaviour
{
	public static bool OverGUI = true;

	private void Update()
	{
		EventSystem current = EventSystem.current;
		if (current != null)
		{
			OverGUI = current.IsPointerOverGameObject();
		}
	}
}
