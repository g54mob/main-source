using UnityEngine;

public class WebEnable : MonoBehaviour
{
	private void Start()
	{
		if (GetComponent<Renderer>() != null)
		{
			GetComponent<Renderer>().enabled = true;
		}
		base.enabled = true;
	}

	private void Update()
	{
	}
}
