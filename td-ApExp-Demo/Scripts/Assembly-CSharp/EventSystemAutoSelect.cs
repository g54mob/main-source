using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventSystemAutoSelect : MonoBehaviour
{
	public static void CheckAndSelectClosest()
	{
		EventSystem current = EventSystem.current;
		if (!(current == null) && !(current.currentSelectedGameObject != null))
		{
			GameObject gameObject = FindClosestSelectable();
			if (gameObject != null)
			{
				current.SetSelectedGameObject(gameObject);
				Debug.Log("Auto-selected: " + gameObject.name);
			}
		}
	}

	private static GameObject FindClosestSelectable()
	{
		Selectable[] array = Object.FindObjectsByType<Selectable>(FindObjectsSortMode.None);
		if (array.Length == 0)
		{
			return null;
		}
		Vector2 a = (Input.mousePresent ? ((Vector2)Input.mousePosition) : new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f));
		Selectable selectable = null;
		float num = float.MaxValue;
		Selectable[] array2 = array;
		foreach (Selectable selectable2 in array2)
		{
			if (selectable2.IsInteractable() && selectable2.gameObject.activeInHierarchy)
			{
				RectTransform component = selectable2.GetComponent<RectTransform>();
				Vector3 vector;
				if (component != null)
				{
					vector = component.position;
				}
				else
				{
					Camera main = Camera.main;
					vector = ((!(main != null)) ? selectable2.transform.position : main.WorldToScreenPoint(selectable2.transform.position));
				}
				float num2 = Vector2.Distance(a, vector);
				if (num2 < num)
				{
					num = num2;
					selectable = selectable2;
				}
			}
		}
		if (!(selectable != null))
		{
			return null;
		}
		return selectable.gameObject;
	}

	public static void CheckAndSelectFirstAvailable()
	{
		EventSystem current = EventSystem.current;
		if (!(current == null) && !(current.currentSelectedGameObject != null))
		{
			Selectable selectable = Object.FindObjectsByType<Selectable>(FindObjectsSortMode.None).FirstOrDefault((Selectable s) => s.IsInteractable() && s.gameObject.activeInHierarchy);
			if (selectable != null)
			{
				current.SetSelectedGameObject(selectable.gameObject);
				Debug.Log("Auto-selected first available: " + selectable.name);
			}
		}
	}

	public static void Update()
	{
		CheckAndSelectClosest();
	}
}
