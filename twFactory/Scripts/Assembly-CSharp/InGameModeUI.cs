using UnityEngine;

public abstract class InGameModeUI : HUDMenu
{
	[SerializeField]
	protected GameObject[] objectsToHide;

	protected virtual void OnEnable()
	{
		for (int i = 0; i < objectsToHide.Length; i++)
		{
			objectsToHide[i].SetActive(value: false);
		}
	}

	protected virtual void OnDisable()
	{
		for (int i = 0; i < objectsToHide.Length; i++)
		{
			objectsToHide[i].SetActive(value: true);
		}
	}
}
