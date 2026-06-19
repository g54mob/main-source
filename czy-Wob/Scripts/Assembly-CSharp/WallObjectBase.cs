using UnityEngine;

public class WallObjectBase : MonoBehaviour
{
	private Joint selfJoint;

	private void Start()
	{
		selfJoint = GetComponent<Joint>();
		if (selfJoint == null)
		{
			selfJoint = GetComponentInChildren<Joint>();
		}
		RefreshJoint();
	}

	private void RefreshJoint()
	{
		if (!(selfJoint == null))
		{
			selfJoint.autoConfigureConnectedAnchor = false;
			selfJoint.connectedAnchor = selfJoint.transform.TransformPoint(selfJoint.anchor);
		}
	}
}
