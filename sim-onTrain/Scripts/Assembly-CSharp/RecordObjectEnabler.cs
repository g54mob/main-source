using System.Collections.Generic;
using UnityEngine;

public class RecordObjectEnabler : MonoBehaviour
{
	public List<GameObject> objects = new List<GameObject>();

	private int lastEnabledIndex;

	private void Start()
	{
		foreach (GameObject @object in objects)
		{
			@object.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Y) && objects.Count <= lastEnabledIndex)
		{
			objects[lastEnabledIndex].gameObject.SetActive(value: true);
			lastEnabledIndex++;
		}
	}
}
