using UnityEngine;
using UnityEngine.Serialization;

public class FreelookCamera : MonoBehaviour
{
	[Tooltip("Default speed in m/s")]
	public float Speed;

	[FormerlySerializedAs("EnableFastSpeed")]
	[Tooltip("Whether to use the faster speed option while holding the boost key")]
	public bool EnableBoostSpeed;

	[Tooltip("Speed in m/s while holding the boost key")]
	[FormerlySerializedAs("FastSpeed")]
	public float BoostSpeed;

	[Tooltip("Hotkey used to boost movement speed")]
	public KeyCode BoostKey;

	[Tooltip("The speed at which your camera rotates when moving the mouse")]
	public float MouseSensitivity;

	[Tooltip("Whether the freelook is initially enabled")]
	public bool IsEnabled;

	[Tooltip("Whether to lock the cursor while using the freelook camera")]
	public bool LockCursor;

	[Tooltip("The hotkey used to enable or disable the freelook camera script")]
	public KeyCode ToggleKey;

	[Tooltip("Hotkey used to move upwards on the vertical world axis")]
	public KeyCode UpKey;

	[Tooltip("Hotkey used to move downwards on the vertical world axis")]
	public KeyCode DownKey;

	private Quaternion originalRotation;

	private float rotationX;

	private float rotationY;

	private Transform myTransform;

	private bool wasUsingKinematic;

	public void Start()
	{
	}

	public void OnEnable()
	{
	}

	public void OnDisable()
	{
	}

	public void Update()
	{
	}

	private void EnableNoClip()
	{
	}

	private void DisableNoClip()
	{
	}
}
