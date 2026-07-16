using UnityEngine;
using UnityEngine.EventSystems;

public class StickySelection : MonoBehaviour
{
	private GameObject lastValid;

	private bool allowDeselect;

	public static StickySelection Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	public void SetLastValid(GameObject go)
	{
		lastValid = go;
	}

	public void ForceDeselect()
	{
		allowDeselect = true;
		lastValid = null;
		EventSystem.current.SetSelectedGameObject(null);
	}

	public void AllowDeselectOnce()
	{
		allowDeselect = true;
	}

	private void Update()
	{
		GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
		if (currentSelectedGameObject != null && currentSelectedGameObject.activeInHierarchy)
		{
			if (lastValid == currentSelectedGameObject)
			{
				return;
			}
			lastValid = currentSelectedGameObject;
			Debug.Log($"StickySelection set selection from: {currentSelectedGameObject} to: {lastValid}");
		}
		else if (!allowDeselect && lastValid != null && MenuManager.Instance.CurrentMenu != null && lastValid.transform.IsChildOf(MenuManager.Instance.CurrentMenu.transform))
		{
			EventSystem.current.SetSelectedGameObject(lastValid);
			Debug.Log($"StickySelection set selection from: {currentSelectedGameObject} to: {lastValid}");
		}
		allowDeselect = false;
	}
}
