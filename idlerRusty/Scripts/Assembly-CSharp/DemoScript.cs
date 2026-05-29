using UnityEngine;

public class DemoScript : MonoBehaviour
{
	private void Start()
	{
		if (!GameManager.ins.demo)
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
