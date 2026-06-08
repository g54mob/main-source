using Dorfromantik;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class FloatInput : MonoBehaviour
{
	[SerializeField]
	private InputActionReference inputAction;

	[FormerlySerializedAs("OnAxis")]
	[SerializeField]
	private FloatEvent OnInput;

	[SerializeField]
	private UnityEvent OnInputStopped;

	[SerializeField]
	private float multiplier = 1f;

	[SerializeField]
	private bool snapToOne;

	[SerializeField]
	private float minInterval;

	[SerializeField]
	private InputActionReference modificationKey;

	[FormerlySerializedAs("keyPressedMultiplier")]
	[SerializeField]
	private float modifiedMultiplier = 1f;

	private float targetMultiplier;

	private bool receivingInput;

	private float timeSinceLastInvoke;

	[SerializeField]
	private bool smoothInput = true;

	[SerializeField]
	private float inputDecceleration = 3f;

	[SerializeField]
	private float inputAcceleration = 3f;

	[SerializeField]
	private InputMultiplierType additionalMultiplierType;

	[SerializeField]
	private AnimationCurve speedMultiplierBySettingsValue;

	[SerializeField]
	private SettingsRouter settingsRouter;

	private float currentInputValue;

	private float additionalMultiplier = 1f;

	private void Start()
	{
		SetModificationMultiplier(modificationEnabled: false);
		if ((bool)modificationKey)
		{
			modificationKey.action.started += delegate
			{
				SetModificationMultiplier(modificationEnabled: true);
			};
			modificationKey.action.canceled += delegate
			{
				SetModificationMultiplier(modificationEnabled: false);
			};
		}
		switch (additionalMultiplierType)
		{
		case InputMultiplierType.CameraPanningSpeed:
			settingsRouter.OnCameraSpeedLevelChanged += UpdateAdditionalMultiplier;
			UpdateAdditionalMultiplier(settingsRouter.CameraSpeedLevel);
			break;
		case InputMultiplierType.CameraRotationSpeed:
			settingsRouter.OnCameraRotationSpeedLevelChanged += UpdateAdditionalMultiplier;
			UpdateAdditionalMultiplier(settingsRouter.CameraRotationSpeedLevel);
			break;
		case InputMultiplierType.CameraZoomSpeed:
			settingsRouter.OnCameraZoomSpeedLevelChanged += UpdateAdditionalMultiplier;
			UpdateAdditionalMultiplier(settingsRouter.CameraZoomSpeedLevel);
			break;
		}
	}

	private void UpdateAdditionalMultiplier(int speedLevel)
	{
		additionalMultiplier = speedMultiplierBySettingsValue.Evaluate(speedLevel);
	}

	private void SetModificationMultiplier(bool modificationEnabled)
	{
		targetMultiplier = (modificationEnabled ? modifiedMultiplier : multiplier);
	}

	private void Update()
	{
		float num = inputAction.action.ReadValue<float>();
		timeSinceLastInvoke += Time.deltaTime;
		if (smoothInput)
		{
			currentInputValue = Mathf.MoveTowards(currentInputValue, num, ((Mathf.Abs(num) < 0.01f) ? inputDecceleration : inputAcceleration) * Time.deltaTime);
		}
		else
		{
			currentInputValue = num;
		}
		if (Mathf.Abs(num) > 0.1f)
		{
			if (!(timeSinceLastInvoke < minInterval))
			{
				float num2 = num * targetMultiplier;
				if (snapToOne)
				{
					num2 /= Mathf.Abs(num2);
				}
				receivingInput = true;
				OnInput?.Invoke(num2 * additionalMultiplier);
				timeSinceLastInvoke = 0f;
			}
		}
		else if (receivingInput)
		{
			OnInputStopped?.Invoke();
			receivingInput = false;
			timeSinceLastInvoke = minInterval;
		}
	}

	private void _003CStart_003Eb__19_0(InputAction.CallbackContext _)
	{
		SetModificationMultiplier(modificationEnabled: true);
	}

	private void _003CStart_003Eb__19_1(InputAction.CallbackContext _)
	{
		SetModificationMultiplier(modificationEnabled: false);
	}
}
