using UnityEngine;

public class Spin : MonoBehaviour
{
	public Vector3 axis = new Vector3(0f, 1f, 0f);

	public float speed = 1f;

	private void Update()
	{
		base.transform.Rotate(axis, speed * Time.deltaTime);
	}
}
