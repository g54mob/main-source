using UnityEngine;

public class AutoDisableInDemo : MonoBehaviour
{
	private void Awake()
	{
		base.gameObject.SetActive(value: false);
	}
}
