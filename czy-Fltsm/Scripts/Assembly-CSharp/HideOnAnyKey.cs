using UnityEngine;

public class HideOnAnyKey : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		if (Input.anyKeyDown)
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
