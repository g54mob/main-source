using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RopeLikeJoint : MonoBehaviour
{
	public Rigidbody connectedBody;

	public float ropeLength = 5f;

	private void Start()
	{
		ConfigurableJoint configurableJoint = base.gameObject.AddComponent<ConfigurableJoint>();
		configurableJoint.connectedBody = connectedBody;
		configurableJoint.autoConfigureConnectedAnchor = false;
		configurableJoint.anchor = Vector3.zero;
		configurableJoint.connectedAnchor = Vector3.zero;
		configurableJoint.xMotion = ConfigurableJointMotion.Limited;
		configurableJoint.yMotion = ConfigurableJointMotion.Limited;
		configurableJoint.zMotion = ConfigurableJointMotion.Limited;
		configurableJoint.linearLimit = new SoftJointLimit
		{
			limit = ropeLength
		};
		configurableJoint.angularXMotion = ConfigurableJointMotion.Free;
		configurableJoint.angularYMotion = ConfigurableJointMotion.Free;
		configurableJoint.angularZMotion = ConfigurableJointMotion.Free;
	}
}
