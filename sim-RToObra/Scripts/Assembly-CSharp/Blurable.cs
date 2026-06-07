using UnityEngine;

public class Blurable : MonoBehaviour
{
	[HideInInspector]
	public GameObject blurGo;

	private void OnEnable()
	{
		if (blurGo != null)
		{
			blurGo.SetActive(true);
		}
	}

	private void OnDisable()
	{
		if (blurGo != null)
		{
			blurGo.SetActive(false);
		}
	}
}
