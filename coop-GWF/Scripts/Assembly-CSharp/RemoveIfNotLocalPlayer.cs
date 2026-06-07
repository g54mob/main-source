using Mirror;
using UnityEngine;

public class RemoveIfNotLocalPlayer : NetworkBehaviour
{
	public override void OnStartClient()
	{
		if (!base.isLocalPlayer)
		{
			Object.Destroy(base.gameObject);
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
