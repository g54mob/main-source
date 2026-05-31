using UnityEngine;

public class KillInventory : MonoBehaviour
{
	private void Start()
	{
		Object.Destroy(GameObject.FindGameObjectWithTag("InvManager"));
	}

	private void Update()
	{
	}
}
