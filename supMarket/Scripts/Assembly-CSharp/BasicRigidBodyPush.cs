using UnityEngine;

public class BasicRigidBodyPush : MonoBehaviour
{
	public LayerMask pushLayers;

	public bool canPush;

	[Range(0.5f, 5f)]
	public float strength;

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
	}

	private void PushRigidBodies(ControllerColliderHit hit)
	{
	}
}
