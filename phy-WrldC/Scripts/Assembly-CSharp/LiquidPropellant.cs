using UnityEngine;

public class LiquidPropellant : BaseComponentView
{
	private LogicIO fuelOutput;

	private float maxFuel;

	private float initialMass;

	private Rigidbody rb;

	public float CurrentFuel { get; set; }

	private void Update()
	{
		float num = CurrentFuel / maxFuel;
		fuelOutput.SetSignal(num);
		rb.mass = initialMass * 0.25f + num * initialMass * 0.75f;
	}

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		CurrentFuel = maxFuel;
		rb.mass = initialMass;
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		maxFuel = properties.GetPropertyAsFloat("fuel");
		rb = GetComponent<Rigidbody>();
		initialMass = rb.mass;
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		fuelOutput = base.BlockBodyView.AddLogicIO(new LogicIO("lpropellant_fuel", LogicIODirection.Output, 0f));
	}

	public override string GetComponentName()
	{
		return typeof(LiquidPropellant).Name;
	}
}
