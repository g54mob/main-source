using UnityEngine;

public class CouplingJoint : MonoBehaviour
{
	public float BREAK_FORCE = 15000000f;

	public float BREAK_TORQUE = 100000f;

	public float jointLimit = 1.4f;

	private ConfigurableJoint cj;

	[Header("Debug")]
	public Rigidbody from;

	public Rigidbody to;

	public Vector3 fromLocalPos;

	public Vector3 toLocalPos;

	[InspectorButton("DebugCreateJoint", true, true)]
	public bool createJoint;

	private void DebugCreateJoint()
	{
		CreateJoint(from, fromLocalPos, to, toLocalPos);
	}

	private void CreateJoint(Rigidbody from, Vector3 fromLocalPos, Rigidbody to, Vector3 toLocalPos)
	{
		if (cj != null)
		{
			Debug.LogError("There's an existing joint, will not create new one, aborting.", this);
			return;
		}
		if (from == null || to == null)
		{
			Debug.LogError("Must provide non-null rigidbodies", this);
			return;
		}
		cj = from.gameObject.AddComponent<ConfigurableJoint>();
		cj.xMotion = ConfigurableJointMotion.Free;
		cj.yMotion = ConfigurableJointMotion.Limited;
		cj.zMotion = ConfigurableJointMotion.Limited;
		cj.angularXMotion = ConfigurableJointMotion.Limited;
		cj.angularYMotion = ConfigurableJointMotion.Limited;
		cj.angularZMotion = ConfigurableJointMotion.Limited;
		cj.connectedBody = to;
		cj.autoConfigureConnectedAnchor = false;
		cj.anchor = fromLocalPos;
		cj.connectedAnchor = toLocalPos;
		SoftJointLimit softJointLimit = new SoftJointLimit
		{
			limit = jointLimit
		};
		cj.linearLimit = softJointLimit;
		softJointLimit.limit = -40f;
		cj.lowAngularXLimit = softJointLimit;
		softJointLimit.limit = 40f;
		cj.highAngularXLimit = softJointLimit;
		cj.angularYLimit = softJointLimit;
		cj.angularZLimit = softJointLimit;
		cj.breakForce = BREAK_FORCE;
		cj.breakTorque = BREAK_TORQUE;
		cj.enableCollision = true;
	}

	private void DestroyJoint()
	{
		if (cj == null)
		{
			Debug.LogWarning("Joint is already null", this);
		}
		else
		{
			Object.Destroy(cj);
		}
	}

	private void OnDrawGizmos()
	{
		if ((bool)cj)
		{
			Gizmos.color = Color.magenta;
			Debug.DrawLine(cj.transform.TransformPoint(cj.anchor), cj.connectedBody.transform.TransformPoint(cj.connectedAnchor));
		}
	}
}
