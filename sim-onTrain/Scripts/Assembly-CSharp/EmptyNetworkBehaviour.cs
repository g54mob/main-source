using Mirror;
using UnityEngine;

public class EmptyNetworkBehaviour : NetworkBehaviour
{
	public void SetParent()
	{
		base.transform.parent = Object.FindObjectOfType<GrillController>().transform;
		base.transform.localPosition = Vector3.zero;
	}

	public override bool Weaved()
	{
		return true;
	}
}
