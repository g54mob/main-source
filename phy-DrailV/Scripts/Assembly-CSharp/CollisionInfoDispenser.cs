using DV;
using DV.Utils;
using UnityEngine;

public class CollisionInfoDispenser : MonoBehaviour
{
	public delegate void CollisionInfo(Collision collision, bool becausePause);

	public event CollisionInfo CollisionEnterInfo;

	public event CollisionInfo CollisionStayInfo;

	public event CollisionInfo CollisionExitInfo;

	private void OnCollisionEnter(Collision collision)
	{
		this.CollisionEnterInfo?.Invoke(collision, SingletonBehaviour<PausePhysicsHandler>.Instance.IgnorePhysicsEvents);
	}

	private void OnCollisionStay(Collision collision)
	{
		this.CollisionStayInfo?.Invoke(collision, SingletonBehaviour<PausePhysicsHandler>.Instance.IgnorePhysicsEvents);
	}

	private void OnCollisionExit(Collision collision)
	{
		this.CollisionExitInfo?.Invoke(collision, SingletonBehaviour<PausePhysicsHandler>.Instance.IgnorePhysicsEvents);
	}
}
