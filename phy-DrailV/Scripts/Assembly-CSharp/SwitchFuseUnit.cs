using Bolt;
using DV.HUD;
using DV.Simulation.Cars;
using DV.Simulation.Fuses;
using LocoSim.Implementations;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(TrainCar))]
[UnitCategory("Trains")]
[UnitSubtitle("Turn a fuse switch on or off on a loco")]
[UnitTitle("Switch Loco Fuse")]
public class SwitchFuseUnit : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public Transform Target;

		public Fuse Fuse;

		public bool TargetValue;
	}

	[DoNotSerialize]
	public ValueInput trainCar;

	[DoNotSerialize]
	public ValueInput controlType;

	[DoNotSerialize]
	public ValueInput targetValue;

	protected override string DoneFieldName => "Switched";

	protected override string AnchorFieldName => string.Empty;

	protected override void InternalDefinition()
	{
		trainCar = ValueInput<GameObject>("Car", null);
		controlType = ValueInput("Control", InteriorControlsManager.ControlType.ElectricsFuse);
		targetValue = ValueInput("State", @default: true);
		Requirement(trainCar, inputTrigger);
	}

	protected override GameObject GetMessageAnchor(Flow flow, object context)
	{
		Context context2 = (Context)context;
		if (!context2.Target)
		{
			return null;
		}
		return context2.Target.gameObject;
	}

	public override object PrepareContext(Flow flow)
	{
		Context context = new Context();
		TrainCar trainCar = TrainCar.Resolve(flow.GetValue<GameObject>(this.trainCar));
		context.TargetValue = flow.GetValue<bool>(targetValue);
		if (trainCar == null || !trainCar.IsLoco)
		{
			Debug.LogError("Game object is not a locomotive!");
			return context;
		}
		InteriorControlsManager interiorControlsManager = trainCar.interior?.GetComponentInChildren<InteriorControlsManager>();
		if (!interiorControlsManager)
		{
			Debug.LogError("Interior controls manager not found on the car!");
			return context;
		}
		InteriorControlsManager.ControlType value = flow.GetValue<InteriorControlsManager.ControlType>(controlType);
		if (!interiorControlsManager.TryGetControl(value, out var reference))
		{
			Debug.LogError("Control not found on the car: " + value, trainCar);
			return context;
		}
		context.Target = reference.controlImplBase.transform;
		InteractableFuseFeeder component = reference.controlImplBase.GetComponent<InteractableFuseFeeder>();
		if (!component)
		{
			Debug.LogError("Fuse feeder not found on the car!", trainCar);
			return context;
		}
		string fuseId = component.fuseId;
		if (!trainCar.GetComponentInChildren<SimController>().simFlow.TryGetFuse(fuseId, out context.Fuse, canBeNull: true))
		{
			Debug.LogError("Fuse not found: " + fuseId, trainCar);
			return context;
		}
		return context;
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (context2.Fuse == null)
		{
			return true;
		}
		return context2.Fuse.State == context2.TargetValue;
	}
}
