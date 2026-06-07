using UnityEngine;

public class SimpleMotor : MotorView
{
	private float targetForce;

	private float targetBrake;

	private float targetVelocity;

	[SerializeField]
	private AnimationCurve torqueCurve;

	private bool isMotorJointThrottleInputActive;

	private bool isSteerableJointPositionInputActive;

	private bool isStepperJointThrottleInputActive;

	public string Type { get; private set; }

	public float Velocity { get; private set; }

	public float Force { get; private set; }

	public float Brake { get; private set; }

	public float HingeAccelerationTime { get; private set; }

	public float Spring { get; private set; }

	public float Damper { get; private set; }

	public float Fuel { get; private set; }

	public float CurrentInputSignal { get; private set; }

	protected override void MotorJointStart(HingeJointView hingeJointView)
	{
		hingeJointView.MotorJointView.hingeMotor = new JointMotor
		{
			force = 0f
		};
		hingeJointView.MotorJointView.currentForce = 0f;
		if (hingeJointView.MotorJointView.Wheel != null)
		{
			hingeJointView.MotorJointView.Wheel.WheelMotor.MotorTorque = 0f;
			hingeJointView.MotorJointView.Wheel.WheelMotor.BrakeTorque = 0f;
		}
		isMotorJointThrottleInputActive = hingeJointView.MotorJointView.ThrottleInput.HasWritableAndActiveSocketIOs();
		hingeJointView.ParentBlockBodyView.SetIOKeysOverwritability(new string[2]
		{
			hingeJointView.MotorJointView.ForwardInput.Name,
			hingeJointView.MotorJointView.BackwardInput.Name
		}, isMotorJointThrottleInputActive);
	}

	protected override bool MotorJointHandler(HingeJointView hingeJointView, bool isAxisConnected = true)
	{
		MotorJointView motorJointView = hingeJointView.MotorJointView;
		HingeJoint hingeJoint = hingeJointView.HingeJoint;
		float num2;
		float num3;
		if (isMotorJointThrottleInputActive)
		{
			float num = motorJointView.ThrottleInput.ReadAnalogSignal();
			num2 = ((num >= 0f) ? Mathf.Clamp(num, 0f, 1f) : 0f);
			num3 = ((num < 0f) ? Mathf.Clamp(0f - num, 0f, 1f) : 0f);
		}
		else
		{
			num2 = motorJointView.ForwardInput.ReadAnalogSignal();
			num3 = motorJointView.BackwardInput.ReadAnalogSignal();
		}
		bool flag = motorJointView.BrakeInput.ReadDigitalSignal();
		bool flag2 = num2 > 0f;
		bool flag3 = num3 > 0f;
		bool result = flag2 || flag3;
		if (!isAxisConnected)
		{
			if (hingeJointView.MotorJointView.Wheel != null)
			{
				WheelMotorIdle(hingeJointView.MotorJointView.Wheel.WheelMotor);
			}
			else
			{
				HingeMotorIdle(motorJointView, hingeJoint);
			}
			return result;
		}
		if (flag)
		{
			if (hingeJointView.MotorJointView.Wheel != null)
			{
				WheelMotorBreaking(hingeJointView.MotorJointView.Wheel.WheelMotor);
			}
			else
			{
				HingeMotorBreaking(motorJointView, hingeJoint);
			}
		}
		else if (flag2 || flag3)
		{
			CurrentInputSignal = (flag2 ? num2 : num3);
			if (hingeJointView.MotorJointView.Wheel != null)
			{
				WheelMotorAccelerating(motorJointView, hingeJointView.MotorJointView.Wheel.WheelMotor, flag2, CurrentInputSignal);
			}
			else
			{
				HingeMotorAccelerating(motorJointView, hingeJoint, flag2, CurrentInputSignal);
			}
		}
		else if (hingeJointView.MotorJointView.Wheel != null)
		{
			WheelMotorIdle(hingeJointView.MotorJointView.Wheel.WheelMotor);
		}
		else
		{
			HingeMotorIdle(motorJointView, hingeJoint);
		}
		return result;
	}

	private void HingeMotorBreaking(MotorJointView motorJointView, HingeJoint hingeJointObject)
	{
		motorJointView.hingeMotor.force = targetForce;
		motorJointView.hingeMotor.targetVelocity = 0f;
		hingeJointObject.useMotor = true;
		hingeJointObject.motor = motorJointView.hingeMotor;
	}

	public void WheelMotorBreaking(WheelMotorWrapper wheelMotor)
	{
		wheelMotor.MotorTorque = 0f;
		wheelMotor.BrakeTorque = targetBrake;
	}

	private void HingeMotorAccelerating(MotorJointView motorJointView, HingeJoint hingeJointObject, bool isForwardKeyPressed, float signal)
	{
		motorJointView.hingeMotor.force = Mathf.SmoothDamp(motorJointView.hingeMotor.force, targetForce, ref motorJointView.currentForce, HingeAccelerationTime, float.PositiveInfinity, Time.fixedDeltaTime);
		float num = Velocity * signal;
		if (isForwardKeyPressed)
		{
			targetVelocity = (motorJointView.IsClockwiseRotation ? num : (0f - num));
			if (motorJointView.hingeMotor.targetVelocity != targetVelocity)
			{
				motorJointView.hingeMotor.force = 0f;
			}
			motorJointView.hingeMotor.targetVelocity = targetVelocity;
		}
		else
		{
			targetVelocity = (motorJointView.IsClockwiseRotation ? (0f - num) : num);
			if (motorJointView.hingeMotor.targetVelocity != targetVelocity)
			{
				motorJointView.hingeMotor.force = 0f;
			}
			motorJointView.hingeMotor.targetVelocity = targetVelocity;
		}
		hingeJointObject.useMotor = true;
		hingeJointObject.motor = motorJointView.hingeMotor;
	}

	public void WheelMotorAccelerating(MotorJointView motorJointView, WheelMotorWrapper wheelMotor, bool isForwardKeyPressed, float signal)
	{
		int num = ((!isForwardKeyPressed) ? ((!motorJointView.IsClockwiseRotation) ? 1 : (-1)) : (motorJointView.IsClockwiseRotation ? 1 : (-1)));
		float num2 = Velocity * signal + 1f;
		float time = Mathf.Clamp(Mathf.Abs(wheelMotor.RPM) / num2, 0f, 1f);
		wheelMotor.MotorTorque = (float)num * targetForce * torqueCurve.Evaluate(time);
		wheelMotor.BrakeTorque = 0f;
	}

	private void HingeMotorIdle(MotorJointView motorJointView, HingeJoint hingeJointObject)
	{
		hingeJointObject.useMotor = false;
		motorJointView.hingeMotor.force = 0f;
	}

	public void WheelMotorIdle(WheelMotorWrapper wheelMotor)
	{
		wheelMotor.MotorTorque = 0f;
		wheelMotor.BrakeTorque = 0f;
	}

	protected override void SteerableJointStart(HingeJointView hingeJointView)
	{
		hingeJointView.SteerableJointView.jointSpring = new JointSpring
		{
			targetPosition = 0f,
			spring = Spring / (float)JointsCount(),
			damper = Damper / (float)JointsCount()
		};
		hingeJointView.HingeJoint.useSpring = true;
		hingeJointView.HingeJoint.spring = hingeJointView.SteerableJointView.jointSpring;
		hingeJointView.SteerableJointView.isForwardActivated = false;
		hingeJointView.SteerableJointView.isBackwardActivated = false;
		hingeJointView.SteerableJointView.isForwardKeyPressedDown = false;
		hingeJointView.SteerableJointView.isBackwardKeyPressedDown = false;
		hingeJointView.SteerableJointView.targetPosition = 0f;
		hingeJointView.SteerableJointView.movementSpeed = 0f;
		hingeJointView.SteerableJointView.currentVelocity = 0f;
		isSteerableJointPositionInputActive = hingeJointView.SteerableJointView.PositionInput.HasWritableAndActiveSocketIOs();
		hingeJointView.ParentBlockBodyView.SetIOKeysOverwritability(new string[2]
		{
			hingeJointView.SteerableJointView.ForwardInput.Name,
			hingeJointView.SteerableJointView.BackwardInput.Name
		}, isSteerableJointPositionInputActive);
	}

	protected override bool SteerableJointHandler(HingeJointView hingeJointView, bool isAxisConnected = true)
	{
		SteerableJointView steerableJointView = hingeJointView.SteerableJointView;
		HingeJoint hingeJoint = hingeJointView.HingeJoint;
		float num = steerableJointView.ForwardInput.ReadAnalogSignal();
		float num2 = steerableJointView.BackwardInput.ReadAnalogSignal();
		bool flag = num > 0f;
		bool flag2 = num2 > 0f;
		bool flag3 = num >= 0.5f;
		bool flag4 = num2 >= 0.5f;
		bool result = flag || flag2;
		float targetPosition = hingeJoint.spring.targetPosition;
		float num3 = 0.03f;
		if (!isAxisConnected)
		{
			if (hingeJoint.spring.targetPosition != 0f)
			{
				steerableJointView.jointSpring.targetPosition = 0f;
				hingeJoint.spring = steerableJointView.jointSpring;
			}
			return result;
		}
		if (steerableJointView.IsToggleActivationType && !isSteerableJointPositionInputActive)
		{
			if (flag3 && !steerableJointView.isForwardKeyPressedDown)
			{
				CurrentInputSignal = 1f;
				steerableJointView.isForwardKeyPressedDown = true;
				steerableJointView.isForwardActivated = !steerableJointView.isForwardActivated;
				steerableJointView.isBackwardActivated = false;
				if (steerableJointView.isForwardActivated)
				{
					if (hingeJoint.spring.targetPosition != 0f - steerableJointView.forwardTarget)
					{
						steerableJointView.targetPosition = 0f - steerableJointView.forwardTarget;
						steerableJointView.movementSpeed = num3 * steerableJointView.forwardTarget / 30f;
					}
				}
				else if (hingeJoint.spring.targetPosition != 0f)
				{
					steerableJointView.targetPosition = 0f;
					steerableJointView.movementSpeed = num3 * steerableJointView.forwardTarget / 30f;
				}
			}
			else if (!flag3)
			{
				steerableJointView.isForwardKeyPressedDown = false;
			}
			if (flag4 && !steerableJointView.isBackwardKeyPressedDown)
			{
				CurrentInputSignal = 1f;
				steerableJointView.isBackwardKeyPressedDown = true;
				steerableJointView.isBackwardActivated = !steerableJointView.isBackwardActivated;
				steerableJointView.isForwardActivated = false;
				if (steerableJointView.isBackwardActivated)
				{
					if (hingeJoint.spring.targetPosition != steerableJointView.backwardTarget)
					{
						steerableJointView.targetPosition = steerableJointView.backwardTarget;
						steerableJointView.movementSpeed = num3 * steerableJointView.backwardTarget / 30f;
					}
				}
				else if (hingeJoint.spring.targetPosition != 0f)
				{
					steerableJointView.targetPosition = 0f;
					steerableJointView.movementSpeed = num3 * steerableJointView.backwardTarget / 30f;
				}
			}
			else if (!flag4)
			{
				steerableJointView.isBackwardKeyPressedDown = false;
			}
		}
		else if (!isSteerableJointPositionInputActive)
		{
			if (flag || flag2)
			{
				CurrentInputSignal = (flag ? num : num2);
				if (flag && !flag2)
				{
					if (targetPosition != (0f - steerableJointView.forwardTarget) * CurrentInputSignal)
					{
						steerableJointView.targetPosition = (0f - steerableJointView.forwardTarget) * CurrentInputSignal;
						steerableJointView.movementSpeed = num3 * steerableJointView.forwardTarget / 30f;
					}
				}
				else if (flag2 && !flag && targetPosition != steerableJointView.backwardTarget * CurrentInputSignal)
				{
					steerableJointView.targetPosition = steerableJointView.backwardTarget * CurrentInputSignal;
					steerableJointView.movementSpeed = num3 * steerableJointView.backwardTarget / 30f;
				}
			}
			else if (targetPosition != 0f)
			{
				steerableJointView.targetPosition = 0f;
				steerableJointView.movementSpeed = num3 * steerableJointView.forwardTarget / 30f;
			}
		}
		if (isSteerableJointPositionInputActive)
		{
			float num4 = steerableJointView.PositionInput.ReadAnalogSignal();
			if (num4 > 0.5f)
			{
				steerableJointView.targetPosition = (0f - steerableJointView.forwardTarget) * (num4 - 0.5f) / 0.5f;
				steerableJointView.movementSpeed = num3 * steerableJointView.forwardTarget / 30f;
			}
			else if (num4 < 0.5f)
			{
				steerableJointView.targetPosition = steerableJointView.backwardTarget * (0.5f - num4) / 0.5f;
				steerableJointView.movementSpeed = num3 * steerableJointView.backwardTarget / 30f;
			}
			else
			{
				steerableJointView.targetPosition = 0f;
				steerableJointView.movementSpeed = num3 * steerableJointView.forwardTarget / 30f;
			}
		}
		if (targetPosition != steerableJointView.targetPosition)
		{
			steerableJointView.jointSpring.targetPosition = Mathf.SmoothDamp(targetPosition, steerableJointView.targetPosition, ref steerableJointView.currentVelocity, steerableJointView.movementSpeed, float.PositiveInfinity, Time.fixedDeltaTime);
			hingeJoint.spring = steerableJointView.jointSpring;
		}
		if (steerableJointView.jointSpring.targetPosition <= 0f)
		{
			steerableJointView.PositionOutput.SetSignal((0f - steerableJointView.jointSpring.targetPosition) / steerableJointView.forwardTarget * 0.5f + 0.5f);
		}
		else
		{
			steerableJointView.PositionOutput.SetSignal(0.5f - steerableJointView.jointSpring.targetPosition / steerableJointView.backwardTarget * 0.5f);
		}
		return result;
	}

	protected override void StepperJointStart(HingeJointView hingeJointView)
	{
		hingeJointView.StepperJointView.jointSpring = new JointSpring
		{
			targetPosition = 0f,
			spring = Spring / (float)JointsCount(),
			damper = Damper / (float)JointsCount()
		};
		hingeJointView.HingeJoint.useSpring = true;
		hingeJointView.HingeJoint.spring = hingeJointView.StepperJointView.jointSpring;
		hingeJointView.StepperJointView.shouldApplyJoint = false;
		isStepperJointThrottleInputActive = hingeJointView.StepperJointView.ThrottleInput.HasWritableAndActiveSocketIOs();
		hingeJointView.ParentBlockBodyView.SetIOKeysOverwritability(new string[2]
		{
			hingeJointView.StepperJointView.ForwardInput.Name,
			hingeJointView.StepperJointView.BackwardInput.Name
		}, isStepperJointThrottleInputActive);
		hingeJointView.StepperJointView.StepSpeedInput.SetSignal(hingeJointView.StepperJointView.degreesPerSecond);
	}

	protected override bool StepperJointHandler(HingeJointView hingeJointView, bool isAxisConnected = true)
	{
		StepperJointView stepperJointView = hingeJointView.StepperJointView;
		HingeJoint hingeJoint = hingeJointView.HingeJoint;
		bool flag;
		bool flag2;
		if (isStepperJointThrottleInputActive)
		{
			float num = stepperJointView.ThrottleInput.ReadAnalogSignal();
			flag = num > 0f;
			flag2 = num < 0f;
		}
		else
		{
			flag = stepperJointView.ForwardInput.ReadDigitalSignal();
			flag2 = stepperJointView.BackwardInput.ReadDigitalSignal();
		}
		bool result = flag || flag2;
		if (!isAxisConnected)
		{
			return result;
		}
		if (flag || flag2)
		{
			if (flag && !flag2)
			{
				if (stepperJointView.isClockwiseRotation)
				{
					StepperJointDecreaseAngle(stepperJointView);
				}
				else
				{
					StepperJointIncreaseAngle(stepperJointView);
				}
			}
			else if (flag2 && !flag)
			{
				if (stepperJointView.isClockwiseRotation)
				{
					StepperJointIncreaseAngle(stepperJointView);
				}
				else
				{
					StepperJointDecreaseAngle(stepperJointView);
				}
			}
			hingeJointView.StepperJointView.shouldApplyJoint = true;
		}
		if (hingeJointView.StepperJointView.shouldApplyJoint)
		{
			hingeJoint.spring = stepperJointView.jointSpring;
			hingeJointView.StepperJointView.shouldApplyJoint = false;
		}
		return result;
	}

	private void StepperJointDecreaseAngle(StepperJointView stepperJointView)
	{
		float num = Mathf.Clamp(stepperJointView.StepSpeedInput.ReadAnalogSignal(), 0f, 1000f);
		stepperJointView.jointSpring.targetPosition -= num * Time.fixedDeltaTime;
		if (stepperJointView.jointSpring.targetPosition < -180f)
		{
			stepperJointView.jointSpring.targetPosition = 180f;
		}
	}

	private void StepperJointIncreaseAngle(StepperJointView stepperJointView)
	{
		float num = Mathf.Clamp(stepperJointView.StepSpeedInput.ReadAnalogSignal(), 0f, 1000f);
		stepperJointView.jointSpring.targetPosition += num * Time.fixedDeltaTime;
		if (stepperJointView.jointSpring.targetPosition > 180f)
		{
			stepperJointView.jointSpring.targetPosition = -180f;
		}
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		Type = properties.GetProperty("type", "combustion_1");
		maxJoints = properties.GetPropertyAsInt("maxJoints");
		Velocity = properties.GetPropertyAsFloat("velocity");
		Force = properties.GetPropertyAsFloat("force");
		Brake = properties.GetPropertyAsFloat("brake");
		Vector2 propertyAsVector = properties.GetPropertyAsVector2("acceleration");
		Spring = properties.GetPropertyAsFloat("spring");
		Damper = properties.GetPropertyAsFloat("damper");
		HingeAccelerationTime = properties.GetPropertyAsFloat("hingeAccelerationTime");
		Fuel = properties.GetPropertyAsFloat("fuel");
		torqueCurve = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 0f));
		torqueCurve.AddKey(propertyAsVector.x, propertyAsVector.y);
		base.gameObject.AddComponent<SimpleMotorStylesApplier>();
	}

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		targetForce = Force / (float)JointsCount();
		targetBrake = Brake / (float)JointsCount();
	}

	public override string GetComponentName()
	{
		return typeof(SimpleMotor).Name;
	}
}
