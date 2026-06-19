using UnityEngine;

public class DebugMovement : MonoBehaviour
{
	public Vector3 torque = Vector3.zero;

	public KeyCode positiveTorqueKey;

	public KeyCode negativeTorqueKey;

	public Vector3 movement = Vector3.zero;

	public KeyCode positiveMovementKey;

	public KeyCode negativeMovementKey;

	private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		HandleInput();
	}

	private void HandleInput()
	{
		if (Input.GetKey(positiveTorqueKey))
		{
			RotateObj(torque);
		}
		else if (Input.GetKey(negativeTorqueKey))
		{
			RotateObj(torque * -1f);
		}
		if (Input.GetKey(positiveMovementKey))
		{
			MoveObj(movement);
		}
		else if (Input.GetKey(negativeMovementKey))
		{
			MoveObj(movement * -1f);
		}
	}

	private void RotateObj(Vector3 torque)
	{
		if (rb == null)
		{
			base.transform.Rotate(torque * Time.fixedDeltaTime);
		}
		else
		{
			rb.AddTorque(torque);
		}
	}

	private void MoveObj(Vector3 movement)
	{
		if (rb == null)
		{
			base.transform.Translate(movement * Time.fixedDeltaTime);
		}
		else
		{
			rb.AddForce(movement);
		}
	}
}
