using UnityEngine;

public class KeyDisappear : MonoBehaviour
{
	[SerializeField]
	private GameObject uiToDeactivate;

	[SerializeField]
	private KeyCode deactivationKey;

	[SerializeField]
	private float permananceDuration = 3f;

	private float time;

	private void Update()
	{
		time += Time.deltaTime;
		if (time > permananceDuration && uiToDeactivate != null && Input.GetKeyDown(deactivationKey))
		{
			uiToDeactivate.SetActive(value: false);
			Object.Destroy(this);
		}
	}
}
