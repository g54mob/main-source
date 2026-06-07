using UnityEngine;

public class OVRHeadsetEmulator : MonoBehaviour
{
	public enum OpMode
	{
		Off = 0,
		EditorOnly = 1,
		AlwaysOn = 2
	}

	public OpMode opMode = OpMode.EditorOnly;

	public bool resetHmdPoseOnRelease = true;

	public bool resetHmdPoseByMiddleMouseButton = true;

	public KeyCode[] activateKeys = new KeyCode[2]
	{
		KeyCode.LeftControl,
		KeyCode.RightControl
	};

	public KeyCode[] pitchKeys = new KeyCode[2]
	{
		KeyCode.LeftAlt,
		KeyCode.RightAlt
	};

	private OVRManager manager;

	private const float MOUSE_SCALE_X = -2f;

	private const float MOUSE_SCALE_X_PITCH = -2f;

	private const float MOUSE_SCALE_Y = 2f;

	private const float MOUSE_SCALE_HEIGHT = 1f;

	private const float MAX_ROLL = 85f;

	private bool lastFrameEmulationActivated;

	private Vector3 recordedHeadPoseRelativeOffsetTranslation;

	private Vector3 recordedHeadPoseRelativeOffsetRotation;

	private bool hasSentEvent;

	private bool emulatorHasInitialized;

	private CursorLockMode previousCursorLockMode;

	private void Start()
	{
	}

	private void Update()
	{
		if (!emulatorHasInitialized)
		{
			if (!OVRManager.OVRManagerinitialized)
			{
				return;
			}
			previousCursorLockMode = Cursor.lockState;
			manager = OVRManager.instance;
			recordedHeadPoseRelativeOffsetTranslation = manager.headPoseRelativeOffsetTranslation;
			recordedHeadPoseRelativeOffsetRotation = manager.headPoseRelativeOffsetRotation;
			emulatorHasInitialized = true;
			lastFrameEmulationActivated = false;
		}
		bool flag = IsEmulationActivated();
		if (flag)
		{
			if (!lastFrameEmulationActivated)
			{
				previousCursorLockMode = Cursor.lockState;
				Cursor.lockState = CursorLockMode.Locked;
			}
			if (!lastFrameEmulationActivated && resetHmdPoseOnRelease)
			{
				manager.headPoseRelativeOffsetTranslation = recordedHeadPoseRelativeOffsetTranslation;
				manager.headPoseRelativeOffsetRotation = recordedHeadPoseRelativeOffsetRotation;
			}
			if (resetHmdPoseByMiddleMouseButton && Input.GetMouseButton(2))
			{
				manager.headPoseRelativeOffsetTranslation = Vector3.zero;
				manager.headPoseRelativeOffsetRotation = Vector3.zero;
			}
			else
			{
				Vector3 headPoseRelativeOffsetTranslation = manager.headPoseRelativeOffsetTranslation;
				float num = Input.GetAxis("Mouse ScrollWheel") * 1f;
				headPoseRelativeOffsetTranslation.y += num;
				manager.headPoseRelativeOffsetTranslation = headPoseRelativeOffsetTranslation;
				float axis = Input.GetAxis("Mouse X");
				float axis2 = Input.GetAxis("Mouse Y");
				Vector3 headPoseRelativeOffsetRotation = manager.headPoseRelativeOffsetRotation;
				float num2 = headPoseRelativeOffsetRotation.x;
				float num3 = headPoseRelativeOffsetRotation.y;
				float num4 = headPoseRelativeOffsetRotation.z;
				if (IsTweakingPitch())
				{
					num4 += axis * -2f;
				}
				else
				{
					num2 += axis2 * 2f;
					num3 += axis * -2f;
				}
				manager.headPoseRelativeOffsetRotation = new Vector3(num2, num3, num4);
			}
			if (!hasSentEvent)
			{
				OVRPlugin.SendEvent("headset_emulator", "activated");
				hasSentEvent = true;
			}
		}
		else if (lastFrameEmulationActivated)
		{
			Cursor.lockState = previousCursorLockMode;
			recordedHeadPoseRelativeOffsetTranslation = manager.headPoseRelativeOffsetTranslation;
			recordedHeadPoseRelativeOffsetRotation = manager.headPoseRelativeOffsetRotation;
			if (resetHmdPoseOnRelease)
			{
				manager.headPoseRelativeOffsetTranslation = Vector3.zero;
				manager.headPoseRelativeOffsetRotation = Vector3.zero;
			}
		}
		lastFrameEmulationActivated = flag;
	}

	private bool IsEmulationActivated()
	{
		if (opMode == OpMode.Off)
		{
			return false;
		}
		if (opMode == OpMode.EditorOnly && !Application.isEditor)
		{
			return false;
		}
		KeyCode[] array = activateKeys;
		for (int i = 0; i < array.Length; i++)
		{
			if (Input.GetKey(array[i]))
			{
				return true;
			}
		}
		return false;
	}

	private bool IsTweakingPitch()
	{
		if (!IsEmulationActivated())
		{
			return false;
		}
		KeyCode[] array = pitchKeys;
		for (int i = 0; i < array.Length; i++)
		{
			if (Input.GetKey(array[i]))
			{
				return true;
			}
		}
		return false;
	}
}
