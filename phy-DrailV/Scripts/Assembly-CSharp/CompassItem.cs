using UnityEngine;

public class CompassItem : MonoBehaviour
{
	private readonly Vector3 NORTH = Vector3.forward;

	[SerializeField]
	private Transform needle;

	private HingeJoint needleJoint;

	private void Start()
	{
		needleJoint = needle.GetComponent<HingeJoint>();
		needleJoint.connectedBody = GetComponent<Rigidbody>();
		needle.GetComponent<Rigidbody>().isKinematic = false;
	}

	private void Update()
	{
		float num = GetNorthFacingLocalRotation().eulerAngles.y % 360f;
		if (num > 180f)
		{
			num -= 360f;
		}
		else if (num < -180f)
		{
			num += 360f;
		}
		JointSpring spring = needleJoint.spring;
		spring.targetPosition = num;
		needleJoint.spring = spring;
	}

	private Quaternion GetNorthFacingLocalRotation()
	{
		float num = Mathf.Sign(Vector3.Dot(Vector3.up, base.transform.up));
		Vector3 normalized = Vector3.ProjectOnPlane(NORTH, base.transform.up * num).normalized;
		Quaternion quaternion = ((normalized != Vector3.zero) ? Quaternion.LookRotation(normalized, base.transform.up) : Quaternion.identity);
		return Quaternion.Inverse(base.transform.rotation) * quaternion;
	}
}
