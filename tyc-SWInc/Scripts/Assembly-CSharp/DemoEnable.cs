using UnityEngine;

public class DemoEnable : MonoBehaviour
{
	private void Start()
	{
		GetComponent<Renderer>().enabled = false;
		base.enabled = false;
	}

	private void Update()
	{
	}
}
