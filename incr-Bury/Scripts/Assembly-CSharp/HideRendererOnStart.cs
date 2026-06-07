using UnityEngine;

public class HideRendererOnStart : MonoBehaviour
{
	private void Start()
	{
		GetComponent<Renderer>().enabled = false;
	}
}
