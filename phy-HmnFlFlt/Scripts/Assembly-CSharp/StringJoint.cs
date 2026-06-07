using UnityEngine;

public class StringJoint : MonoBehaviour
{
	public Rigidbody connectedBody;

	public Vector3 anchor;

	public bool autoConfigureConnectedAnchor;

	public Vector3 connectedAnchor;

	public bool autoconfigureStringLength;

	public float stringLength;

	private void Awake()
	{
		Vector3 vector = base.transform.TransformPoint(anchor);
		if (autoConfigureConnectedAnchor)
		{
			connectedAnchor = connectedBody.transform.InverseTransformPoint(vector);
		}
		Vector3 vector2 = connectedBody.transform.TransformPoint(connectedAnchor);
		if (autoconfigureStringLength)
		{
			stringLength = (vector - vector2).magnitude;
		}
		ConfigurableJoint configurableJoint = base.gameObject.AddComponent<ConfigurableJoint>();
		configurableJoint.anchor = anchor;
		configurableJoint.autoConfigureConnectedAnchor = false;
		configurableJoint.connectedBody = connectedBody;
		configurableJoint.connectedAnchor = connectedAnchor;
		SoftJointLimit linearLimit = new SoftJointLimit
		{
			limit = stringLength
		};
		configurableJoint.linearLimit = linearLimit;
		ConfigurableJointMotion configurableJointMotion = (configurableJoint.zMotion = ConfigurableJointMotion.Limited);
		configurableJointMotion = (configurableJoint.yMotion = configurableJointMotion);
		configurableJoint.xMotion = configurableJointMotion;
		configurableJointMotion = (configurableJoint.angularZMotion = ConfigurableJointMotion.Free);
		configurableJointMotion = (configurableJoint.angularYMotion = configurableJointMotion);
		configurableJoint.angularXMotion = configurableJointMotion;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawCube(base.transform.TransformPoint(anchor), Vector3.one * 0.2f);
		Gizmos.color = Color.red;
		Gizmos.DrawCube(connectedBody.transform.TransformPoint(connectedAnchor), Vector3.one * 0.2f);
	}
}
