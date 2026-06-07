using Bolt;
using DV.HUD;
using DV.Simulation.Cars;
using DV.Simulation.Controllers;
using Ludiq;
using UnityEngine;

[UnitTitle("Cab Control Operation")]
[UnitSubtitle("Wait for player to get a cab control to a target value range")]
[UnitCategory("Trains")]
[TypeIcon(typeof(TrainCar))]
public class CabControlUnit : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public TrainCar car;

		public InteriorControlsManager.ControlType controlType;

		public Vector2 range;

		public bool autoDo;

		public InteriorControlsManager controls;

		public BaseControlsOverrider overrider;

		public InteriorControlsManager.ControlReference interiorControl;

		public OverridableBaseControl baseControl;
	}

	[DoNotSerialize]
	public ValueInput trainCar;

	[DoNotSerialize]
	public ValueInput controlTypeValue;

	[DoNotSerialize]
	public ValueInput rangeValue;

	[DoNotSerialize]
	public ValueInput autoPerform;

	protected override string AnchorFieldName => string.Empty;

	protected override string OffsetFieldName => string.Empty;

	protected override void InternalDefinition()
	{
		trainCar = ValueInput<GameObject>("Car", null);
		controlTypeValue = ValueInput("Control", InteriorControlsManager.ControlType.Handbrake);
		rangeValue = ValueInput("Range", new Vector2(0.5f, 1f));
		autoPerform = ValueInput("Auto", @default: false);
	}

	public override object PrepareContext(Flow flow)
	{
		Context context = new Context();
		context.car = TrainCar.Resolve(flow.GetValue<GameObject>(trainCar));
		context.controlType = flow.GetValue<InteriorControlsManager.ControlType>(controlTypeValue);
		context.range = flow.GetValue<Vector2>(rangeValue);
		context.autoDo = flow.GetValue<bool>(autoPerform);
		context.controls = context.car.interior.GetComponentInChildren<InteriorControlsManager>();
		context.overrider = context.car.GetComponentInChildren<BaseControlsOverrider>(includeInactive: true);
		if (context.controls == null || context.overrider == null)
		{
			Debug.LogError("This car doesn't have a control manager or overrider!");
			return context;
		}
		context.baseControl = null;
		if (context.controls.TryGetControl(context.controlType, out context.interiorControl))
		{
			context.baseControl = context.overrider.GetControl(context.controlType);
		}
		if (context.baseControl == null)
		{
			Debug.LogError($"Control {context.controlType} not found on this car!");
		}
		return context;
	}

	public override bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (context2.controls == null || context2.overrider == null || context2.baseControl == null)
		{
			return true;
		}
		if (context2.autoDo)
		{
			context2.baseControl.Set((context2.range.x + context2.range.y) * 0.5f);
			return true;
		}
		return base.EarlyOutCheck(flow, context);
	}

	protected override GameObject GetMessageAnchor(Flow flow, object context)
	{
		Context context2 = (Context)context;
		if (!(context2.interiorControl.controlImplBase != null))
		{
			return null;
		}
		return context2.interiorControl.controlImplBase.gameObject;
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (context2.baseControl.Value >= context2.range.x)
		{
			return context2.baseControl.Value <= context2.range.y;
		}
		return false;
	}
}
