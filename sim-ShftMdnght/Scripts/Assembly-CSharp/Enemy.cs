using Mirror;
using UnityEngine;

public class Enemy : NetworkBehaviour
{
	public Transform leaveLocation;

	public bool leaving;

	public virtual void Leave()
	{
	}

	public virtual void CheckIfNearBarricade()
	{
	}

	public virtual void ChaseNonPlayerTarget(Vector3 targPosition)
	{
	}

	public override bool Weaved()
	{
		return true;
	}
}
