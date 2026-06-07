using UnityEngine;
using UnityEngine.Events;

public class InteractObject : MonoBehaviour
{
	[SerializeField]
	private string requiredItem;

	public bool interactable;

	public UnityEvent action;

	private bool clearedPersistentListener;

	public void InvokeEvent()
	{
		if (!interactable)
		{
			return;
		}
		if (requiredItem == "")
		{
			action?.Invoke();
		}
		else if (requiredItem == "/")
		{
			if (PlayerManager.instance.GetItem() != null)
			{
				GameObject.Find("Warning").GetComponent<Animator>().Play("Display");
			}
			else
			{
				action?.Invoke();
			}
		}
		else if (PlayerManager.instance.CheckItem(requiredItem))
		{
			PlayerManager.instance.RemoveItem();
			action?.Invoke();
		}
	}

	public void ChangeRequiredItem(string name)
	{
		requiredItem = name;
	}

	public void AddEvent(UnityAction a)
	{
		if (!clearedPersistentListener)
		{
			action.SetPersistentListenerState(0, UnityEventCallState.Off);
			clearedPersistentListener = true;
		}
		action.RemoveAllListeners();
		action.AddListener(a);
	}
}
