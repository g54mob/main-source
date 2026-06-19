using UnityEngine;

public class ObjectNameTag : MonoBehaviour
{
	public GameObject container;

	public PugText text;

	private void Awake()
	{
		text.transform.parent.localPosition = new Vector3(0f, 5f, -5f);
		UpdateTextVisibility();
	}

	private void LateUpdate()
	{
		UpdateTextVisibility();
	}

	private void UpdateTextVisibility()
	{
		if (Manager.prefs.hideInGameUI && container.activeSelf)
		{
			container.SetActive(value: false);
		}
		else if (!Manager.prefs.hideInGameUI && !container.activeSelf)
		{
			container.SetActive(value: true);
		}
	}
}
