using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedObjectDisabler : MonoBehaviour
{
	public List<GameObject> objectsToDisable = new List<GameObject>();

	public float delay = 3f;

	public bool setActiveTrue;

	private void Start()
	{
		StartCoroutine(DisableObjectsAfterDelay());
	}

	public IEnumerator DisableObjectsAfterDelay()
	{
		yield return new WaitForSeconds(delay);
		foreach (GameObject item in objectsToDisable)
		{
			if (item != null)
			{
				item.SetActive(setActiveTrue);
			}
		}
	}
}
