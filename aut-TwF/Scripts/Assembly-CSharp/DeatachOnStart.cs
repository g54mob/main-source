using UnityEngine;

public class DeatachOnStart : MonoBehaviour
{
	private void Start()
	{
		base.transform.SetParent(null);
	}
}
