using UnityEngine;

public class lookat : MonoBehaviour
{
	public GameObject pl;

	private void Update()
	{
		base.transform.LookAt(pl.transform.position);
	}
}
