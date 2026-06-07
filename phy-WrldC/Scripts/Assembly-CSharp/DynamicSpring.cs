using System;
using UnityEngine;

public class DynamicSpring : BaseComponentView
{
	private LogicIO releaseInput;

	private LogicIO releasedOutput;

	private ConfigurableJoint configurableJoint;

	private float targetPosition;

	private bool releaseSignal;

	private bool wasSpringReleased;

	public event Action OnReleasedEvent;

	private void Update()
	{
		releaseSignal = releaseInput.ReadDigitalSignal();
		releasedOutput.SetSignal(wasSpringReleased);
	}

	private void FixedUpdate()
	{
		if (releaseSignal && !wasSpringReleased)
		{
			configurableJoint.yMotion = ConfigurableJointMotion.Limited;
			configurableJoint.targetPosition = new Vector3(0f, targetPosition, 0f);
			wasSpringReleased = true;
			this.OnReleasedEvent?.Invoke();
		}
	}

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		configurableJoint.yMotion = ConfigurableJointMotion.Locked;
		releaseSignal = false;
		wasSpringReleased = false;
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		targetPosition = properties.GetPropertyAsFloat("targetPosition");
		float propertyAsFloat = properties.GetPropertyAsFloat("spring");
		float propertyAsFloat2 = properties.GetPropertyAsFloat("damper");
		configurableJoint = GetComponent<ConfigurableJoint>();
		configurableJoint.linearLimitSpring = new SoftJointLimitSpring
		{
			spring = propertyAsFloat,
			damper = propertyAsFloat2
		};
		configurableJoint.yDrive = new JointDrive
		{
			positionSpring = propertyAsFloat,
			positionDamper = propertyAsFloat2,
			maximumForce = float.PositiveInfinity
		};
		base.gameObject.AddComponent<DynamicSpringStylerApplier>();
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		releaseInput = base.BlockBodyView.AddLogicIO(new LogicIO("dspring_release", LogicIODirection.Input, digitalSignal: false));
		releasedOutput = base.BlockBodyView.AddLogicIO(new LogicIO("dspring_released", LogicIODirection.Output, 0f));
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		configurableJoint.targetPosition = Vector3.zero;
	}

	public override string GetComponentName()
	{
		return typeof(DynamicSpring).Name;
	}
}
