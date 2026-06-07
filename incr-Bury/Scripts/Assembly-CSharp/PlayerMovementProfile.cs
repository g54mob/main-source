using UnityEngine;

public class PlayerMovementProfile : MonoBehaviour
{
	public bool disableMovement;

	public bool disableJump;

	[Header("Acceleration")]
	public float accel_Grounded;

	public float accel_Grounded_Running;

	public float accel_Grounded_Crouching;

	public float accel_Airborne;

	public float minAirControl;

	[Header("Speed Limits")]
	public float maxMoveSpeed;

	public float maxMoveSpeed_Running;

	public float maxMoveSpeed_Crouching;

	[Header("Drag")]
	public float drag_Grounded;

	public float drag_Airborne;

	[Header("Jumping")]
	public float jumpPower;

	[Header("Stamina")]
	public float staminaMax;

	public float staminaRegenDelay;

	public float staminaRegenRate;

	public float staminaDrainRate;
}
