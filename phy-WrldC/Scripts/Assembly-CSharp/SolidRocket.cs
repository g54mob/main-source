using System;
using UnityEngine;

public class SolidRocket : BaseComponentView
{
	private LogicIO activeInput;

	private LogicIO fuelOutput;

	private Rigidbody rb;

	private float currentThrust;

	private float maxThrust;

	private float currentFuel;

	private float initialFuel;

	private bool isStarted;

	private float currentVelocity;

	private float initialMass;

	public float CurrentThrust => currentThrust;

	public float MaxThrust => maxThrust;

	public event Action OnStartEvent;

	private void Update()
	{
		if (activeInput.ReadDigitalSignal() && !isStarted)
		{
			isStarted = true;
			this.OnStartEvent?.Invoke();
		}
		float num = currentFuel / initialFuel;
		fuelOutput.SetSignal(num);
		rb.mass = initialMass * 0.3f + num * initialMass * 0.7f;
	}

	private void FixedUpdate()
	{
		if (isStarted && currentFuel > 0f)
		{
			currentThrust = Mathf.SmoothDamp(currentThrust, maxThrust, ref currentVelocity, 0.1f, float.PositiveInfinity, Time.fixedDeltaTime);
			rb.AddRelativeForce(Vector3.right * currentThrust, ForceMode.Force);
			currentFuel -= Time.fixedDeltaTime * (currentThrust / maxThrust);
			if (currentFuel <= 0f)
			{
				currentFuel = 0f;
			}
		}
		else
		{
			currentThrust = Mathf.SmoothDamp(currentThrust, 0f, ref currentVelocity, 0.8f, float.PositiveInfinity, Time.fixedDeltaTime);
		}
	}

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		rb.mass = initialMass;
		currentFuel = initialFuel;
		currentThrust = 0f;
		currentVelocity = 0f;
		isStarted = false;
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		rb = GetComponent<Rigidbody>();
		initialMass = rb.mass;
		maxThrust = properties.GetPropertyAsFloat("thrust");
		initialFuel = properties.GetPropertyAsFloat("fuel");
		currentThrust = 0f;
		base.gameObject.AddComponent<SolidRocketStylesApplier>();
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		activeInput = base.BlockBodyView.AddLogicIO(new LogicIO("sr_active", LogicIODirection.Input, digitalSignal: false));
		fuelOutput = base.BlockBodyView.AddLogicIO(new LogicIO("sr_fuel", LogicIODirection.Output, 0f));
	}

	protected override void InternalInitializeGizmos<SolidRocketModel>(SolidRocketModel componentModel)
	{
		base.InternalInitializeGizmos(componentModel);
		InstantiateGizmoObject("SolidRocketGizmo");
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		currentThrust = 0f;
	}

	public override void SetBlockDestroyed()
	{
		base.SetBlockDestroyed();
		fuelOutput.SetSignal(0f);
	}

	public override string GetComponentName()
	{
		return typeof(SolidRocket).Name;
	}
}
