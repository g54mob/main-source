using System.Collections.Generic;
using UnityEngine;

public class Thruster : BaseComponentView
{
	private LogicIO activeInput;

	private LogicIO fuelOutput;

	private Rigidbody rb;

	private Vector3 thrustDirection;

	private float currentVelocity;

	private float maxFuel;

	private float currentFuel;

	private List<LiquidPropellant> liquidPropellants;

	public float MaxThrust { get; private set; }

	public float CurrentThrust { get; private set; }

	private void Update()
	{
		if (currentFuel > 0f && CurrentThrust > 0f)
		{
			float num = Time.deltaTime * (CurrentThrust / MaxThrust);
			int num2 = 0;
			for (int i = 0; i < liquidPropellants.Count; i++)
			{
				if (!(liquidPropellants[i].BlockBodyView.GroupLeaderBlockBodyView != base.BlockBodyView.GroupLeaderBlockBodyView) && !(liquidPropellants[i].CurrentFuel <= 0f))
				{
					num2++;
				}
			}
			for (int j = 0; j < liquidPropellants.Count; j++)
			{
				if (!(liquidPropellants[j].BlockBodyView.GroupLeaderBlockBodyView != base.BlockBodyView.GroupLeaderBlockBodyView) && !(liquidPropellants[j].CurrentFuel <= 0f))
				{
					liquidPropellants[j].CurrentFuel -= num / (float)num2;
					if (liquidPropellants[j].CurrentFuel < 0f)
					{
						liquidPropellants[j].CurrentFuel = 0f;
					}
				}
			}
			if (num2 == 0)
			{
				currentFuel -= num;
				if (currentFuel < 0f)
				{
					currentFuel = 0f;
				}
			}
		}
		fuelOutput.SetSignal(currentFuel / maxFuel);
	}

	private void FixedUpdate()
	{
		float num = activeInput.ReadAnalogSignal();
		if (currentFuel <= 0f)
		{
			num = 0f;
		}
		CurrentThrust = Mathf.SmoothDamp(CurrentThrust, num * MaxThrust, ref currentVelocity, 1f, float.PositiveInfinity, Time.fixedDeltaTime);
		rb.AddRelativeForce(thrustDirection * CurrentThrust, ForceMode.Force);
	}

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		CurrentThrust = 0f;
		currentVelocity = 0f;
		currentFuel = maxFuel;
		liquidPropellants.Clear();
		foreach (BlockView allInterconnectedBlock in base.BlockBodyView.ParentBlockView.GetAllInterconnectedBlocks())
		{
			LiquidPropellant componentView = allInterconnectedBlock.GetComponentView<LiquidPropellant>();
			if (componentView != null)
			{
				liquidPropellants.Add(componentView);
			}
		}
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		liquidPropellants = new List<LiquidPropellant>();
		MaxThrust = properties.GetPropertyAsFloat("thrust");
		thrustDirection = properties.GetPropertyAsVector3("direction");
		maxFuel = properties.GetPropertyAsFloat("fuel");
		rb = GetComponent<Rigidbody>();
		CurrentThrust = 0f;
		base.gameObject.AddComponent<ThrusterStylesApplier>();
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		activeInput = base.BlockBodyView.AddLogicIO(new LogicIO("thruster_active", LogicIODirection.Input, 0f));
		fuelOutput = base.BlockBodyView.AddLogicIO(new LogicIO("thruster_fuel", LogicIODirection.Output, 0f));
	}

	protected override void InternalInitializeGizmos<ThrusterModel>(ThrusterModel componentModel)
	{
		base.InternalInitializeGizmos(componentModel);
		InstantiateGizmoObject("ThrusterGizmo");
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		CurrentThrust = 0f;
	}

	public override string GetComponentName()
	{
		return typeof(Thruster).Name;
	}
}
