using System;
using UnityEngine;

public class Piston : BaseComponentView
{
	private ConfigurableJoint configurableJoint;

	private LogicIO activeInput;

	private LogicIO extendedOutput;

	private bool isPistonActive;

	private bool isToggleMode;

	private bool isToggleChanged;

	private bool isLogicInverted;

	private float activatedPosition;

	private float deactivatedPosition;

	private float targetPosition;

	private bool activeSignal;

	private bool lastActiveSignal;

	private float currentVelocity;

	public event Action OnPositionChangedEvent;

	private void Update()
	{
		activeSignal = activeInput.ReadDigitalSignal();
		if (activeSignal != lastActiveSignal)
		{
			this.OnPositionChangedEvent?.Invoke();
		}
		lastActiveSignal = activeSignal;
		extendedOutput.SetSignal(isPistonActive);
	}

	protected void FixedUpdate()
	{
		if (activeSignal)
		{
			if (isToggleMode)
			{
				if (!isToggleChanged)
				{
					isPistonActive = !isPistonActive;
					isToggleChanged = true;
				}
			}
			else
			{
				isPistonActive = !isLogicInverted;
			}
		}
		else if (isToggleMode)
		{
			isToggleChanged = false;
		}
		else
		{
			isPistonActive = isLogicInverted;
		}
		if (isPistonActive)
		{
			targetPosition = activatedPosition;
		}
		else
		{
			targetPosition = deactivatedPosition;
		}
		if (configurableJoint.targetPosition.y != targetPosition)
		{
			float y = Mathf.SmoothDamp(configurableJoint.targetPosition.y, targetPosition, ref currentVelocity, 0.0022f, float.PositiveInfinity, Time.fixedDeltaTime);
			configurableJoint.targetPosition = new Vector3(0f, y, 0f);
		}
	}

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		isLogicInverted = base.BlockBodyView.OverridableProperties.GetPropertyAsBool("piston_invert_logic");
		isPistonActive = isLogicInverted;
		int propertyAsInt = base.BlockBodyView.OverridableProperties.GetPropertyAsInt("piston_btn_type");
		isToggleMode = propertyAsInt != 0;
		activeSignal = false;
		lastActiveSignal = false;
		activatedPosition = -0.5f - 0.5f * configurableJoint.linearLimitSpring.spring / 1000f;
		deactivatedPosition = 0f;
		currentVelocity = 0f;
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		configurableJoint = GetComponent<ConfigurableJoint>();
		base.gameObject.AddComponent<PistonStylesApplier>();
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		activeInput = base.BlockBodyView.AddLogicIO(new LogicIO("piston_active", LogicIODirection.Input, digitalSignal: false));
		extendedOutput = base.BlockBodyView.AddLogicIO(new LogicIO("piston_extended_out", LogicIODirection.Output, 0f));
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		configurableJoint.targetPosition = Vector3.zero;
	}

	public override void SetBlockDestroyed()
	{
		base.SetBlockDestroyed();
	}

	protected override void InternalInitializeGizmos<PistonModel>(PistonModel componentModel)
	{
		base.InternalInitializeGizmos(componentModel);
		GameObject gameObject = InstantiateGizmoObject("PistonGizmo");
		string id = base.BlockBodyView.ParentBlockView.Schematic.Id;
		if (id == "piston")
		{
			gameObject.transform.FindChildRecursively("TopSmall").gameObject.SetActive(value: false);
		}
		else if (id == "small_piston")
		{
			gameObject.transform.FindChildRecursively("TopNormal").gameObject.SetActive(value: false);
		}
	}

	public override string GetComponentName()
	{
		return typeof(Piston).Name;
	}
}
