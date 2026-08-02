using UnityEngine;

public class Spin : MonoBehaviour
{
	public float speed = 10f;

	private void Update()
	{
		base.transform.Rotate(Vector3.up, speed * Time.deltaTime);
	}
}
