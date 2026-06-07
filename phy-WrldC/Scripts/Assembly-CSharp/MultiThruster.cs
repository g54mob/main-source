using System.Collections.Generic;
using UnityEngine;

public class MultiThruster : BaseComponentView
{
	private LogicIO activePXInput;

	private LogicIO activePYInput;

	private LogicIO activePZInput;

	private LogicIO activeNXInput;

	private LogicIO activeNYInput;

	private LogicIO activeNZInput;

	private LogicIO fuelOutput;

	private Rigidbody rb;

	private float currentPXThrust;

	private float currentPYThrust;

	private float currentPZThrust;

	private float currentNZThrust;

	private float currentNXThrust;

	private float currentNYThrust;

	private float currentPXVelocity;

	private float currentPYVelocity;

	private float currentPZVelocity;

	private float currentNXVelocity;

	private float currentNYVelocity;

	private float currentNZVelocity;

	private float maxFuel;

	private float currentFuel;

	private List<LiquidPropellant> liquidPropellants;

	public float MaxThrust { get; private set; }

	public Vector3 CurrentThrustVector { get; private set; }

	private void Update()
	{
		float num = currentPXThrust + currentPYThrust + currentPZThrust + currentNXThrust + currentNYThrust + currentNZThrust;
		if (currentFuel > 0f && num > 0f)
		{
			float num2 = Time.deltaTime * (num / MaxThrust);
			int num3 = 0;
			for (int i = 0; i < liquidPropellants.Count; i++)
			{
				if (!(liquidPropellants[i].BlockBodyView.GroupLeaderBlockBodyView != base.BlockBodyView.GroupLeaderBlockBodyView) && !(liquidPropellants[i].CurrentFuel <= 0f))
				{
					num3++;
				}
			}
			for (int j = 0; j < liquidPropellants.Count; j++)
			{
				if (!(liquidPropellants[j].BlockBodyView.GroupLeaderBlockBodyView != base.BlockBodyView.GroupLeaderBlockBodyView) && !(liquidPropellants[j].CurrentFuel <= 0f))
				{
					liquidPropellants[j].CurrentFuel -= num2 / (float)num3;
					if (liquidPropellants[j].CurrentFuel < 0f)
					{
						liquidPropellants[j].CurrentFuel = 0f;
					}
				}
			}
			if (num3 == 0)
			{
				currentFuel -= num2;
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
		float num = GetInputValue(activePXInput);
		float num2 = GetInputValue(activePYInput);
		float num3 = GetInputValue(activePZInput);
		float num4 = GetInputValue(activeNXInput);
		float num5 = GetInputValue(activeNYInput);
		float num6 = GetInputValue(activeNZInput);
		if (currentFuel <= 0f)
		{
			num = (num2 = (num3 = 0f));
			num4 = (num5 = (num6 = 0f));
		}
		currentPXThrust = Mathf.SmoothDamp(currentPXThrust, num * MaxThrust, ref currentPXVelocity, 1f, float.PositiveInfinity, Time.fixedDeltaTime);
		currentPYThrust = Mathf.SmoothDamp(currentPYThrust, num2 * MaxThrust, ref currentPYVelocity, 1f, float.PositiveInfinity, Time.fixedDeltaTime);
		currentPZThrust = Mathf.SmoothDamp(currentPZThrust, num3 * MaxThrust, ref currentPZVelocity, 1f, float.PositiveInfinity, Time.fixedDeltaTime);
		currentNXThrust = Mathf.SmoothDamp(currentNXThrust, num4 * MaxThrust, ref currentNXVelocity, 1f, float.PositiveInfinity, Time.fixedDeltaTime);
		currentNYThrust = Mathf.SmoothDamp(currentNYThrust, num5 * MaxThrust, ref currentNYVelocity, 1f, float.PositiveInfinity, Time.fixedDeltaTime);
		currentNZThrust = Mathf.SmoothDamp(currentNZThrust, num6 * MaxThrust, ref currentNZVelocity, 1f, float.PositiveInfinity, Time.fixedDeltaTime);
		CurrentThrustVector = new Vector3(currentPXThrust - currentNXThrust, currentPYThrust - currentNYThrust, currentPZThrust - currentNZThrust);
		rb.AddRelativeForce(CurrentThrustVector, ForceMode.Force);
		float GetInputValue(LogicIO input)
		{
			return input?.ReadAnalogSignal() ?? 0f;
		}
	}

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		currentPXThrust = (currentPYThrust = (currentPZThrust = 0f));
		currentNXThrust = (currentNYThrust = (currentNZThrust = 0f));
		currentPXVelocity = (currentPYVelocity = (currentPZVelocity = 0f));
		currentNXVelocity = (currentNYVelocity = (currentNZVelocity = 0f));
		currentFuel = maxFuel;
		CurrentThrustVector = Vector3.zero;
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
		maxFuel = properties.GetPropertyAsFloat("fuel");
		rb = GetComponent<Rigidbody>();
		base.gameObject.AddComponent<MultiThrusterStylesApplier>();
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		Vector3 propertyAsVector = properties.GetPropertyAsVector3("dirPos");
		Vector3 propertyAsVector2 = properties.GetPropertyAsVector3("dirNeg");
		if (propertyAsVector.x > 0f)
		{
			activePXInput = base.BlockBodyView.AddLogicIO(new LogicIO("m_thruster_active_px", LogicIODirection.Input, 0f));
		}
		if (propertyAsVector.y > 0f)
		{
			activePYInput = base.BlockBodyView.AddLogicIO(new LogicIO("m_thruster_active_py", LogicIODirection.Input, 0f));
		}
		if (propertyAsVector.z > 0f)
		{
			activePZInput = base.BlockBodyView.AddLogicIO(new LogicIO("m_thruster_active_pz", LogicIODirection.Input, 0f));
		}
		if (propertyAsVector2.x > 0f)
		{
			activeNXInput = base.BlockBodyView.AddLogicIO(new LogicIO("m_thruster_active_nx", LogicIODirection.Input, 0f));
		}
		if (propertyAsVector2.y > 0f)
		{
			activeNYInput = base.BlockBodyView.AddLogicIO(new LogicIO("m_thruster_active_ny", LogicIODirection.Input, 0f));
		}
		if (propertyAsVector2.z > 0f)
		{
			activeNZInput = base.BlockBodyView.AddLogicIO(new LogicIO("m_thruster_active_nz", LogicIODirection.Input, 0f));
		}
		fuelOutput = base.BlockBodyView.AddLogicIO(new LogicIO("m_thruster_fuel", LogicIODirection.Output, 0f));
	}

	protected override void InternalInitializeGizmos<T>(T componentModel)
	{
		base.InternalInitializeGizmos(componentModel);
		GameObject gameObject = InstantiateGizmoObject("MultiThrusterGizmo");
		string id = base.BlockBodyView.ParentBlockView.Schematic.Id;
		if (id == "double_thruster")
		{
			gameObject.transform.FindChildRecursively("ArrowPY").gameObject.SetActive(value: false);
			gameObject.transform.FindChildRecursively("ArrowNY").gameObject.SetActive(value: false);
		}
		else if (id == "single_thruster")
		{
			gameObject.transform.FindChildRecursively("ArrowPX").gameObject.SetActive(value: false);
			gameObject.transform.FindChildRecursively("ArrowNX").gameObject.SetActive(value: false);
			gameObject.transform.FindChildRecursively("ArrowPY").gameObject.SetActive(value: false);
			gameObject.transform.FindChildRecursively("ArrowNY").gameObject.SetActive(value: false);
			gameObject.transform.FindChildRecursively("ArrowNX_2").gameObject.SetActive(value: true);
		}
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		currentPXThrust = (currentPYThrust = (currentPZThrust = 0f));
		currentNXThrust = (currentNYThrust = (currentNZThrust = 0f));
		CurrentThrustVector = Vector3.zero;
		activePXInput = (activePYInput = (activePZInput = null));
		activeNXInput = (activeNYInput = (activeNZInput = null));
	}

	public override string GetComponentName()
	{
		return typeof(MultiThruster).Name;
	}
}
