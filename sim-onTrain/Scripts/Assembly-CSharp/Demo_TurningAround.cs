using UnityEngine;

public class Demo_TurningAround : MonoBehaviour
{
	public float rotSpeed_X;

	public float rotSpeed_Y;

	public float rotSpeed_Z;

	public float globalSpeed = 1f;

	private void Update()
	{
		base.transform.Rotate(new Vector3(rotSpeed_X, rotSpeed_Y, rotSpeed_Z) * globalSpeed * Time.deltaTime);
	}
}
