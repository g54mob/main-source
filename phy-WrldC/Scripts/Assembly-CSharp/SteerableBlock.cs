using System;
using UnityEngine;

public class SteerableBlock : BaseComponentView
{
	public HingeJoint hingeJointObject;

	public Rigidbody hingeJointConnectedBody;

	private LogicIO forwardInput;

	private LogicIO backwardInput;

	private LogicIO positionInput;

	private LogicIO positionOutput;

	public float forwardTarget;

	public float backwardTarget;

	private JointSpring jointSpring;

	private bool shouldApplyJoint;

	private SteerableBlockGizmo steerableGizmo;

	private OverridablePropertyModel directionProperty;

	private bool isPositionInputActive;

	private bool isInvertedDirection;

	private float forwardSignal;

	private float backwardSignal;

	private bool isForwardKeyPressed;

	private bool isBackwardKeyPressed;

	private float lastForwardSignal;

	private float lastBackwardSignal;

	private float currentPosition;

	private float currentVelocity;

	public event Action OnPositionChangedEvent;

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		isPositionInputActive = positionInput.HasWritableAndActiveSocketIOs();
		base.BlockBodyView.SetIOKeysOverwritability(new string[2] { forwardInput.Name, backwardInput.Name }, isPositionInputActive);
		bool propertyAsBool = base.BlockBodyView.OverridableProperties.GetPropertyAsBool("steerb_free_spin");
		jointSpring.targetPosition = 0f;
		jointSpring.spring = 5000f;
		jointSpring.damper = 50f;
		hingeJointObject.useSpring = !propertyAsBool;
		hingeJointObject.spring = jointSpring;
		shouldApplyJoint = false;
		isInvertedDirection = base.BlockBodyView.OverridableProperties.GetPropertyAsBool("steerb_invert_direction");
		forwardSignal = 0f;
		backwardSignal = 0f;
		lastForwardSignal = 0f;
		lastBackwardSignal = 0f;
		currentPosition = 0f;
		currentVelocity = 0f;
	}

	private void Update()
	{
		if (hingeJointObject.useSpring)
		{
			if (isPositionInputActive)
			{
				float num = positionInput.ReadAnalogSignal();
				forwardSignal = ((num >= 0.5f) ? ((num - 0.5f) / 0.5f) : 0f);
				backwardSignal = ((num < 0.5f) ? (1f - num / 0.5f) : 0f);
			}
			else
			{
				forwardSignal = forwardInput.ReadAnalogSignal();
				backwardSignal = backwardInput.ReadAnalogSignal();
			}
			if (isInvertedDirection)
			{
				float num2 = forwardSignal;
				forwardSignal = backwardSignal;
				backwardSignal = num2;
			}
			isForwardKeyPressed = forwardSignal > 0f;
			isBackwardKeyPressed = backwardSignal > 0f;
			bool flag = false;
			if (lastForwardSignal <= 0.1f && forwardSignal > 0.1f)
			{
				flag = true;
			}
			else if (lastForwardSignal >= 0.9f && forwardSignal < 0.9f)
			{
				flag = true;
			}
			if (lastBackwardSignal <= 0.1f && backwardSignal > 0.1f)
			{
				flag = true;
			}
			else if (lastBackwardSignal >= 0.9f && backwardSignal < 0.9f)
			{
				flag = true;
			}
			if (flag)
			{
				this.OnPositionChangedEvent?.Invoke();
			}
			lastForwardSignal = forwardSignal;
			lastBackwardSignal = backwardSignal;
			if (isInvertedDirection)
			{
				positionOutput.SetSignal((forwardTarget - currentPosition) / (forwardTarget + backwardTarget));
			}
			else
			{
				positionOutput.SetSignal(1f + (currentPosition - forwardTarget) / (forwardTarget + backwardTarget));
			}
		}
	}

	private void FixedUpdate()
	{
		if (!hingeJointObject.useSpring)
		{
			return;
		}
		currentPosition = hingeJointObject.spring.targetPosition;
		if (isForwardKeyPressed || isBackwardKeyPressed)
		{
			if (isForwardKeyPressed && !isBackwardKeyPressed)
			{
				if (currentPosition != forwardTarget * forwardSignal)
				{
					jointSpring.targetPosition = Mathf.SmoothDamp(currentPosition, forwardTarget * forwardSignal, ref currentVelocity, 0.15f, float.PositiveInfinity, Time.fixedDeltaTime);
				}
			}
			else if (isBackwardKeyPressed && !isForwardKeyPressed && currentPosition != (0f - backwardTarget) * backwardSignal)
			{
				jointSpring.targetPosition = Mathf.SmoothDamp(currentPosition, (0f - backwardTarget) * backwardSignal, ref currentVelocity, 0.15f, float.PositiveInfinity, Time.fixedDeltaTime);
			}
			shouldApplyJoint = true;
		}
		else if (currentPosition != 0f)
		{
			jointSpring.targetPosition = Mathf.SmoothDamp(currentPosition, 0f, ref currentVelocity, 0.15f, float.PositiveInfinity, Time.fixedDeltaTime);
			shouldApplyJoint = true;
		}
		if (shouldApplyJoint)
		{
			hingeJointObject.spring = jointSpring;
			shouldApplyJoint = false;
		}
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		forwardTarget = properties.GetPropertyAsFloat("forwardTarget");
		backwardTarget = properties.GetPropertyAsFloat("backwardTarget");
		hingeJointObject = GetComponent<HingeJoint>();
		hingeJointConnectedBody = hingeJointObject.connectedBody;
		base.gameObject.AddComponent<SteerableBlockStylesApplier>();
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		forwardInput = base.BlockBodyView.AddLogicIO(new LogicIO("steerb_forward", LogicIODirection.Input, 0f));
		backwardInput = base.BlockBodyView.AddLogicIO(new LogicIO("steerb_backward", LogicIODirection.Input, 0f));
		positionInput = base.BlockBodyView.AddLogicIO(new LogicIO("steerb_position_in", LogicIODirection.Input, 0.5f)
		{
			IsInputWithoutKey = true
		});
		positionOutput = base.BlockBodyView.AddLogicIO(new LogicIO("steerb_position_out", LogicIODirection.Output, 0.5f));
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		hingeJointObject.connectedBody = hingeJointConnectedBody;
	}

	protected override void InternalInitializeGizmos<SteerableBlockModel>(SteerableBlockModel componentModel)
	{
		base.InternalInitializeGizmos(componentModel);
		GameObject gameObject = InstantiateGizmoObject("SteerableBlockGizmo");
		steerableGizmo = gameObject.GetComponent<SteerableBlockGizmo>();
	}

	protected override void SetGizmosConfiguration<SteerableBlockModel>(SteerableBlockModel componentModel)
	{
		base.SetGizmosConfiguration(componentModel);
		directionProperty = componentModel.ParentBlockBodyModel.GetOverridableProperty("steerb_invert_direction");
		steerableGizmo.SetArrowDirection(directionProperty.ValueAsBool);
		directionProperty.NotifyChangeEvent += DirectionPropertyEventHandler;
	}

	protected override void InternalResetGizmos()
	{
		base.InternalResetGizmos();
		if (directionProperty != null)
		{
			directionProperty.NotifyChangeEvent -= DirectionPropertyEventHandler;
		}
		directionProperty = null;
	}

	private void DirectionPropertyEventHandler(string eventName, object[] data)
	{
		if (!(steerableGizmo == null) && eventName == "OverridablePropertyModel.ValueChangeEvent")
		{
			OverridablePropertyModel overridablePropertyModel = data[0] as OverridablePropertyModel;
			steerableGizmo.SetArrowDirection(overridablePropertyModel.ValueAsBool);
		}
	}

	public override string GetComponentName()
	{
		return typeof(SteerableBlock).Name;
	}
}
