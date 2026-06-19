using UnityEngine;

public class DemoMovement : MonoBehaviour
{
	public float Acceleration = 5f;

	private Vector3 Speed;

	private void Update()
	{
		Vector3 vector = base.transform.right * Input.GetAxis("Horizontal");
		vector += base.transform.up * Input.GetAxis("Vertical");
		if (Input.GetKey(KeyCode.LeftShift))
		{
			vector += base.transform.forward;
		}
		if (Input.GetKey(KeyCode.Space))
		{
			vector -= base.transform.forward;
		}
		Speed *= Mathf.Pow(0.4f, Time.deltaTime);
		Speed += vector * Acceleration * Time.deltaTime;
		base.transform.position += Speed * Time.deltaTime;
		Vector3 speed = Speed;
		Debug.Log("speed: " + speed.ToString());
	}
}
