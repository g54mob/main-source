using System;
using UnityEngine;

public class LinearStage : BaseComponentView
{
	private LogicIO rightInput;

	private LogicIO leftInput;

	private LogicIO positionInput;

	private LogicIO positionOutput;

	private ConfigurableJoint configurableJoint;

	private float leftMaxReach;

	private float rightMaxReach;

	private bool isInvertedButtons;

	private float speedPerSecond;

	private float currentPosition;

	private float targetDirection;

	private bool isLinearMovement;

	private bool isMiddleMovement;

	private bool isTotalMovement;

	private bool isTotalMovementExecuting;

	private bool shouldApplyJoint;

	private GameObject braceObject;

	private bool isPositionInputActive;

	private float positionSignal;

	private float rightSignal;

	private float leftSignal;

	private bool isRightKeyPressed;

	private bool isLeftKeyPressed;

	private bool isRightFullPressed;

	private bool isLeftFullPressed;

	private float lastPosition;

	public event Action OnPositionChangingEvent;

	public event Action OnNotPositionChangingEvent;

	private void Awake()
	{
		Transform transform = base.transform.parent.FindChildRecursively("BracePivot");
		if (transform != null)
		{
			braceObject = transform.gameObject;
		}
	}

	private void Update()
	{
		if (isPositionInputActive)
		{
			positionSignal = positionInput.ReadAnalogSignal();
		}
		else
		{
			rightSignal = rightInput.ReadAnalogSignal();
			leftSignal = leftInput.ReadAnalogSignal();
			if (isInvertedButtons)
			{
				float num = rightSignal;
				rightSignal = leftSignal;
				leftSignal = num;
			}
			isRightKeyPressed = rightSignal > 0f;
			isLeftKeyPressed = leftSignal > 0f;
			isRightFullPressed = rightSignal >= 0.5f;
			isLeftFullPressed = leftSignal >= 0.5f;
		}
		if (shouldApplyJoint && braceObject != null)
		{
			braceObject.transform.localRotation = Quaternion.Euler(new Vector3(currentPosition / leftMaxReach * 360f, 0f, 0f));
		}
		if (currentPosition != lastPosition)
		{
			this.OnPositionChangingEvent?.Invoke();
			lastPosition = currentPosition;
		}
		else
		{
			this.OnNotPositionChangingEvent?.Invoke();
		}
		if (rightMaxReach == 0f || leftMaxReach == 0f)
		{
			positionOutput.SetSignal(currentPosition / (leftMaxReach - rightMaxReach));
		}
		else
		{
			positionOutput.SetSignal((leftMaxReach - currentPosition) / (leftMaxReach + rightMaxReach));
		}
	}

	private void FixedUpdate()
	{
		if (isRightKeyPressed || isLeftKeyPressed)
		{
			if (isLinearMovement)
			{
				if (isRightKeyPressed)
				{
					currentPosition += Time.fixedDeltaTime * speedPerSecond * rightSignal;
				}
				if (isLeftKeyPressed)
				{
					currentPosition -= Time.fixedDeltaTime * speedPerSecond * leftSignal;
				}
				shouldApplyJoint = true;
			}
			else if (isTotalMovement)
			{
				if (isRightFullPressed)
				{
					targetDirection = 1f;
				}
				if (isLeftFullPressed)
				{
					targetDirection = -1f;
				}
				isTotalMovementExecuting = true;
			}
			else if (isMiddleMovement)
			{
				float num = (leftMaxReach - rightMaxReach) / 2f;
				if (isRightKeyPressed)
				{
					currentPosition = num + (leftMaxReach - num) * rightSignal;
				}
				if (isLeftKeyPressed)
				{
					currentPosition = num + (0f - rightMaxReach - num) * leftSignal;
				}
				shouldApplyJoint = true;
			}
		}
		else if (isMiddleMovement)
		{
			currentPosition = (leftMaxReach - rightMaxReach) / 2f;
			shouldApplyJoint = true;
		}
		if (isMiddleMovement)
		{
			float num2 = currentPosition;
			float x = configurableJoint.targetPosition.x;
			if (x < num2 - 0.05f)
			{
				currentPosition = x + Time.fixedDeltaTime * speedPerSecond;
			}
			else if (x > num2 + 0.05f)
			{
				currentPosition = x - Time.fixedDeltaTime * speedPerSecond;
			}
			shouldApplyJoint = true;
		}
		if (isTotalMovementExecuting)
		{
			currentPosition += Time.fixedDeltaTime * targetDirection * speedPerSecond;
			if (currentPosition <= 0f - rightMaxReach || currentPosition >= leftMaxReach)
			{
				isTotalMovementExecuting = false;
			}
			shouldApplyJoint = true;
		}
		if (isPositionInputActive)
		{
			float x2 = configurableJoint.targetPosition.x;
			float num3 = ((rightMaxReach != 0f && leftMaxReach != 0f) ? (leftMaxReach - (leftMaxReach + rightMaxReach) * positionSignal) : ((leftMaxReach - rightMaxReach) * positionSignal));
			if (x2 < num3 - 0.005f)
			{
				currentPosition = x2 + Time.fixedDeltaTime * speedPerSecond;
			}
			else if (x2 > num3 + 0.005f)
			{
				currentPosition = x2 - Time.fixedDeltaTime * speedPerSecond;
			}
			shouldApplyJoint = true;
		}
		if (shouldApplyJoint)
		{
			currentPosition = Mathf.Clamp(currentPosition, 0f - rightMaxReach, leftMaxReach);
			configurableJoint.targetPosition = new Vector3(currentPosition, 0f, 0f);
		}
	}

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		int propertyAsInt = base.BlockBodyView.OverridableProperties.GetPropertyAsInt("linear_s_type");
		isLinearMovement = propertyAsInt == 0;
		isTotalMovement = propertyAsInt == 1;
		isMiddleMovement = propertyAsInt == 2;
		speedPerSecond = base.BlockBodyView.OverridableProperties.GetPropertyAsFloat("linear_s_speed");
		isPositionInputActive = positionInput.HasWritableAndActiveSocketIOs();
		base.BlockBodyView.SetIOKeysOverwritability(new string[2] { rightInput.Name, leftInput.Name }, isPositionInputActive);
		isTotalMovementExecuting = false;
		shouldApplyJoint = false;
		positionSignal = 0f;
		rightSignal = 0f;
		leftSignal = 0f;
		currentPosition = 0f;
		lastPosition = 0f;
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		rightMaxReach = Mathf.Abs(properties.GetPropertyAsFloat("rightMaxReach"));
		leftMaxReach = Mathf.Abs(properties.GetPropertyAsFloat("leftMaxReach"));
		isInvertedButtons = properties.GetPropertyAsBool("isInvertedButtons");
		configurableJoint = GetComponent<ConfigurableJoint>();
		rightMaxReach += rightMaxReach * configurableJoint.linearLimitSpring.spring / 1000f;
		leftMaxReach += leftMaxReach * configurableJoint.linearLimitSpring.spring / 1000f;
		base.gameObject.AddComponent<LinearStageStylesApplier>();
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		rightInput = base.BlockBodyView.AddLogicIO(new LogicIO("linear_s_right", LogicIODirection.Input, 0f));
		leftInput = base.BlockBodyView.AddLogicIO(new LogicIO("linear_s_left", LogicIODirection.Input, 0f));
		positionInput = base.BlockBodyView.AddLogicIO(new LogicIO("linear_s_position_in", LogicIODirection.Input, 0f)
		{
			IsInputWithoutKey = true
		});
		positionOutput = base.BlockBodyView.AddLogicIO(new LogicIO("linear_s_position_out", LogicIODirection.Output, 0f)
		{
			ValueType = LogicIOValueType.Raw
		});
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		configurableJoint.targetPosition = Vector3.zero;
	}

	protected override void InternalInitializeGizmos<LinearStageModel>(LinearStageModel componentModel)
	{
		base.InternalInitializeGizmos(componentModel);
		GameObject gameObject = InstantiateGizmoObject("LinearStageGizmo");
		switch (base.BlockBodyView.ParentBlockView.Schematic.Id)
		{
		case "linear_stage":
			gameObject.transform.FindChildRecursively("ArrowNormal").gameObject.SetActive(value: true);
			break;
		case "small_linear_stage":
			gameObject.transform.FindChildRecursively("ArrowSmall").gameObject.SetActive(value: true);
			break;
		case "linear_stage_cube":
		case "small_linear_stage_cube":
			gameObject.transform.FindChildRecursively("ArrowCube").gameObject.SetActive(value: true);
			break;
		case "telescopic_block":
			gameObject.transform.FindChildRecursively("Telescopic").gameObject.SetActive(value: true);
			break;
		case "small_telescopic_block":
			gameObject.transform.FindChildRecursively("SmallTelescopic").gameObject.SetActive(value: true);
			break;
		}
	}

	public override string GetComponentName()
	{
		return typeof(LinearStage).Name;
	}
}
