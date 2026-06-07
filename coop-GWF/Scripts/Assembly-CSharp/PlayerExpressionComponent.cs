using Mirror;
using UnityEngine;

public class PlayerExpressionComponent : NetworkBehaviour
{
	[SerializeField]
	private NetworkAnimator networkAnimator;

	public override void OnStartClient()
	{
		if (!base.isLocalPlayer)
		{
			base.enabled = false;
		}
		else
		{
			networkAnimator = GetComponent<NetworkAnimator>();
		}
	}

	public void SetHandAnimationTrigger(string triggerName)
	{
		networkAnimator.SetTrigger(triggerName);
	}

	public override bool Weaved()
	{
		return true;
	}
}
