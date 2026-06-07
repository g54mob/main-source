using Unity.Components.Logs;
using UnityEngine;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour
{
	private const float ETHALON_TIME = 1f / 60f;

	public bool moveWithRMB = true;

	public float mouseSensitivity = 15f;

	public float gamepadSensitivity = 15f;

	public float minimumX = -360f;

	public float maximumX = 360f;

	public float minimumY = -60f;

	public float maximumY = 60f;

	private float rotationX;

	private float rotationY;

	private Quaternion originalRotation;

	private string GamepadX = "RStickMouse_X";

	private string GamepadY = "RStickMouse_Y";

	private bool IsGamepadPresent()
	{
		string[] joystickNames = Input.GetJoystickNames();
		if (joystickNames != null)
		{
			return joystickNames.Length != 0;
		}
		return false;
	}

	private bool IsMousePresent()
	{
		if (!moveWithRMB || !Input.GetMouseButton(1))
		{
			return !moveWithRMB;
		}
		return true;
	}

	private void Awake()
	{
		if (Application.platform != RuntimePlatform.WindowsPlayer && Application.platform != RuntimePlatform.LinuxPlayer)
		{
			return;
		}
		string[] joystickNames = Input.GetJoystickNames();
		for (int i = 0; i < joystickNames.Length; i++)
		{
			string text = joystickNames[i].ToLowerInvariant();
			if (text.Contains("xbox") || text.Contains("ps4") || text.Contains("ps3") || text.Contains("playstation") || text.Contains("bigben") || text.Contains("big"))
			{
				GamepadX = "RStickMouse_X_XBOX_WIN_LIN";
				GamepadY = "RStickMouse_Y_XBOX_WIN_LIN";
				Log.Debug("switching to xbox controller axis");
				break;
			}
		}
	}

	private void Update()
	{
		float num = 0f;
		float num2 = 0f;
		if (IsMousePresent())
		{
			num = Input.GetAxis("Mouse X") * mouseSensitivity;
			num2 = Input.GetAxis("Mouse Y") * mouseSensitivity;
		}
		else if (IsGamepadPresent())
		{
			num = Input.GetAxis(GamepadX);
			num2 = Input.GetAxis(GamepadY);
			num *= gamepadSensitivity;
			num2 *= gamepadSensitivity;
		}
		if (num != 0f || num2 != 0f)
		{
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			rotationX += num * (unscaledDeltaTime / (1f / 60f));
			rotationY += num2 * (unscaledDeltaTime / (1f / 60f));
			rotationX = ClampAngle(rotationX, minimumX, maximumX);
			rotationY = ClampAngle(rotationY, minimumY, maximumY);
			Quaternion quaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
			Quaternion quaternion2 = Quaternion.AngleAxis(rotationY, Vector3.left);
			base.transform.localRotation = originalRotation * quaternion * quaternion2;
		}
	}

	private void Start()
	{
		if ((bool)GetComponent<Rigidbody>())
		{
			GetComponent<Rigidbody>().freezeRotation = true;
		}
		originalRotation = Quaternion.identity;
		if (Application.isEditor)
		{
			moveWithRMB = true;
		}
	}

	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360f)
		{
			angle += 360f;
		}
		if (angle > 360f)
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}
}
