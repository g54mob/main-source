using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FirstSelection : MonoBehaviour
{
	public Transform parentObject;

	public bool onlyGamepad;

	public bool autoInvoke;

	public float delayBeforeSelection = 0.1f;

	private void OnEnable()
	{
		if (autoInvoke)
		{
			StartCoroutine(DelayedSelectFirst());
		}
	}

	private IEnumerator DelayedSelectFirst()
	{
		yield return new WaitForSeconds(delayBeforeSelection);
		SelectFirst();
	}

	public void SelectFirst()
	{
		if (InputDetection.Instance != null)
		{
			if (onlyGamepad && !InputDetection.Instance.GamepadEnabled)
			{
				return;
			}
		}
		else
		{
			Debug.LogWarning("Input Detection Instance is null");
		}
		if (parentObject == null)
		{
			Debug.LogWarning("Parent object is not assigned");
		}
		else
		{
			if (parentObject.childCount == 0)
			{
				return;
			}
			EventSystem current = EventSystem.current;
			if (current == null)
			{
				Debug.LogWarning("EventSystem is not present in the scene");
				return;
			}
			Selectable selectable = null;
			foreach (Transform item in parentObject)
			{
				if (item.gameObject.activeInHierarchy)
				{
					selectable = item.GetComponentInChildren<Selectable>(includeInactive: true);
					if (selectable != null && selectable.gameObject.activeInHierarchy && selectable.interactable)
					{
						break;
					}
				}
			}
			if (selectable == null)
			{
				Debug.LogWarning("No active Selectable found under parentObject.");
			}
			else
			{
				current.SetSelectedGameObject(selectable.gameObject);
			}
		}
	}
}
