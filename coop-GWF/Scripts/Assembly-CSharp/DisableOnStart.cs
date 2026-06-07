using UnityEngine;

public class DisableOnStart : MonoBehaviour
{
	private void Awake()
	{
		base.gameObject.SetActive(value: false);
	}
}
