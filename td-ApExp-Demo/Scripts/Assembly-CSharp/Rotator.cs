using UnityEngine;

public class Rotator : MonoBehaviour
{
	private Vector3 previousPosition;

	private void Start()
	{
		previousPosition = base.transform.position;
	}

	public void RotateTowardsPosition(Vector3 targetPos, float speed = 60f, float lookAngleOffset = 0f)
	{
		Vector3 upwards = targetPos - base.transform.position;
		Vector3 eulerAngles = Quaternion.LookRotation(Vector3.forward, upwards).eulerAngles;
		float z = base.transform.eulerAngles.z;
		float num = Mathf.DeltaAngle(z, eulerAngles.z + lookAngleOffset);
		float z2 = z + num;
		Quaternion to = Quaternion.Euler(0f, 0f, z2);
		base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, Time.deltaTime * speed);
	}

	public void SnapTowardsPosition(Vector3 targetPos, float lookAngleOffset = 0f)
	{
		Vector3 upwards = targetPos - base.transform.position;
		Quaternion rotation = Quaternion.Euler(0f, 0f, Quaternion.LookRotation(Vector3.forward, upwards).eulerAngles.z);
		base.transform.rotation = rotation;
	}

	public void RotateComponentTowardsPosition(Transform componentTf, Vector3 targetPos, float speed = 60f, float lookAngleOffset = 0f)
	{
		Vector3 upwards = targetPos - componentTf.position;
		Vector3 eulerAngles = Quaternion.LookRotation(Vector3.forward, upwards).eulerAngles;
		float z = componentTf.eulerAngles.z;
		float num = Mathf.DeltaAngle(z, eulerAngles.z + lookAngleOffset);
		float z2 = z + num;
		Quaternion to = Quaternion.Euler(0f, 0f, z2);
		componentTf.rotation = Quaternion.RotateTowards(componentTf.rotation, to, Time.deltaTime * speed);
	}

	public void SnapComponentTowardsPosition(Transform componentTf, Vector3 targetPos, float lookAngleOffset = 0f)
	{
		Vector3 upwards = targetPos - componentTf.position;
		Quaternion rotation = Quaternion.Euler(0f, 0f, Quaternion.LookRotation(Vector3.forward, upwards).eulerAngles.z + lookAngleOffset);
		componentTf.rotation = rotation;
	}

	internal void RotateTowardsMovementVector(float offset = 0f)
	{
		Vector3 vector = base.transform.position - previousPosition;
		if (!(vector == Vector3.zero))
		{
			Vector3 eulerAngles = Quaternion.LookRotation(Vector3.forward, vector).eulerAngles;
			base.transform.rotation = Quaternion.Euler(0f, 0f, eulerAngles.z + offset);
			previousPosition = base.transform.position;
		}
	}

	public void RotateToAngle(Transform componentTf, float angle, float offset = 0f, float speed = 60f)
	{
		float z = componentTf.eulerAngles.z;
		float num = Mathf.DeltaAngle(z, angle);
		float z2 = z + num;
		Quaternion to = Quaternion.Euler(0f, 0f, z2);
		componentTf.rotation = Quaternion.RotateTowards(componentTf.rotation, to, Time.deltaTime * speed);
	}
}
