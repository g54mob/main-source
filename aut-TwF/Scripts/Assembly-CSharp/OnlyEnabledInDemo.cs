using UnityEngine;

public class OnlyEnabledInDemo : MonoBehaviour
{
	private void Awake()
	{
		base.gameObject.SetActive(value: false);
	}
}
