using Dorfromantik;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Vector2Input : MonoBehaviour
{
	[SerializeField]
	private InputActionReference inputAction;

	[SerializeField]
	private Vector2Event OnInput;

	[SerializeField]
	private UnityEvent OnInputStopped;

	[SerializeField]
	private bool noInputWhileOnConfirmationScreen;

	[SerializeField]
	private float multiplier = 1f;

	[SerializeField]
	private InputActionReference modificationKey;

	[SerializeField]
	private float modifiedMultiplier = 1f;

	[FormerlySerializedAs("modifierType")]
	[SerializeField]
	private InputMultiplierType additionalMultiplier;

	[SerializeField]
	private AnimationCurve speedMultiplierBySettingsValue;

	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private bool smoothInput = true;

	[SerializeField]
	private float inputDecceleration = 3f;

	[SerializeField]
	private float inputAcceleration = 3f;

	private float targetMultiplier;

	private float additionalMultiplierValue = 1f;

	private bool receivingInput;

	private Vector2 currentInputValue;

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
		switch (additionalMultiplier)
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
		additionalMultiplierValue = speedMultiplierBySettingsValue.Evaluate(speedLevel);
	}

	private void SetModificationMultiplier(bool modificationEnabled)
	{
		targetMultiplier = (modificationEnabled ? modifiedMultiplier : multiplier);
	}

	private void Update()
	{
		Vector2 vector = inputAction.action.ReadValue<Vector2>();
		if (smoothInput)
		{
			if (Vector3.Dot(vector, currentInputValue.normalized) < 0f)
			{
				currentInputValue = Vector2.zero;
			}
			currentInputValue.x = Mathf.MoveTowards(currentInputValue.x, vector.x, ((Mathf.Abs(vector.x) < 0.01f) ? inputDecceleration : inputAcceleration) * Time.deltaTime);
			currentInputValue.y = Mathf.MoveTowards(currentInputValue.y, vector.y, ((Mathf.Abs(vector.y) < 0.01f) ? inputDecceleration : inputAcceleration) * Time.deltaTime);
		}
		else
		{
			currentInputValue = vector;
		}
		if (!noInputWhileOnConfirmationScreen || !Singleton<MainMenuUi>.Instance.ActiveConfirmationScreen)
		{
			if (vector.magnitude > 0.01f)
			{
				receivingInput = true;
				OnInput?.Invoke(currentInputValue * (targetMultiplier * additionalMultiplierValue));
			}
			else if (receivingInput)
			{
				OnInputStopped?.Invoke();
				receivingInput = false;
			}
		}
	}

	private void _003CStart_003Eb__17_0(InputAction.CallbackContext _)
	{
		SetModificationMultiplier(modificationEnabled: true);
	}

	private void _003CStart_003Eb__17_1(InputAction.CallbackContext _)
	{
		SetModificationMultiplier(modificationEnabled: false);
	}
}
