using DV;
using DV.Interaction.Inputs;
using DV.Utils;
using UnityEngine;

public class TurntableControlKeyboardInput : MonoBehaviour
{
	private const float TORQUE_POWER = 1000000f;

	public GameObject leverGO;

	public CapsuleCollider interactionAreaTrigger;

	private Rigidbody leverRB;

	private void Awake()
	{
		if (VRManager.IsVREnabled())
		{
			Object.Destroy(interactionAreaTrigger);
			Object.Destroy(this);
		}
		else if (leverGO == null || interactionAreaTrigger == null)
		{
			Debug.LogError("leverGO or interactionAreaTrigger is not set. Can't function properly, destroying self!");
			Object.Destroy(this);
		}
	}

	private void FixedUpdate()
	{
		Camera playerCamera = PlayerManager.PlayerCamera;
		if (SingletonBehaviour<AppUtil>.Instance.IsTimePaused || playerCamera == null)
		{
			return;
		}
		if (!leverRB)
		{
			leverRB = leverGO.GetComponent<Rigidbody>();
			if (!leverRB)
			{
				return;
			}
		}
		Vector3 position = playerCamera.transform.position;
		if (interactionAreaTrigger.ClosestPoint(position) == position)
		{
			float axis = InputManager.NewPlayer.GetAxis(InputManager.Actions.Turntable);
			if (axis != 0f)
			{
				Move(axis);
			}
		}
	}

	public void Move(float multiplier)
	{
		if ((bool)leverRB)
		{
			leverRB.AddRelativeTorque(0f, 1000000f * multiplier, 0f, ForceMode.VelocityChange);
		}
	}
}
