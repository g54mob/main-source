using UnityEngine;

public class UIArmController : MonoBehaviour
{
	public float inTorque = -100f;

	public float outTorque = 200f;

	private Vector3 baseTorque = new Vector3(0f, 0f, 1f);

	private Rigidbody selfBody;

	private void Awake()
	{
		selfBody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.RightArrow))
		{
			TorqueBody(inTorque);
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			TorqueBody(outTorque);
		}
	}

	private void TorqueBody(float torque)
	{
		selfBody.AddRelativeTorque(baseTorque * torque);
	}
}
