using Bolt;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(TrainCar))]
[UnitCategory("Trains")]
[UnitTitle("Car Speed Condition")]
[UnitSubtitle("Wait for train car's speed to be in a specified range")]
public class CarSpeedUnit : GenericWaitForCondition
{
	private class Context
	{
		public TrainCar car;

		public float minSpeed;

		public float maxSpeed;

		public bool abs;
	}

	[DoNotSerialize]
	public ValueInput carObjectValue;

	[DoNotSerialize]
	public ValueInput minSpeedValue;

	[DoNotSerialize]
	public ValueInput maxSpeedValue;

	[DoNotSerialize]
	public ValueInput absoluteValue;

	protected override string DoneFieldName => "Output";

	protected override void InternalDefinition()
	{
		carObjectValue = ValueInput<GameObject>("Car", null);
		minSpeedValue = ValueInput("Min", 0f);
		maxSpeedValue = ValueInput("Max", 0f);
		absoluteValue = ValueInput("Absolute", @default: true);
	}

	public override object PrepareContext(Flow flow)
	{
		Context context = new Context();
		context.car = TrainCar.Resolve(flow.GetValue<GameObject>(carObjectValue));
		if (context.car == null)
		{
			if (PlayerManager.Car != null)
			{
				context.car = PlayerManager.Car;
			}
			else if (PlayerManager.LastLoco != null)
			{
				context.car = PlayerManager.LastLoco;
			}
			else
			{
				Debug.LogError("No car was specified, and can't get anything from the player, skipping.");
			}
		}
		context.minSpeed = flow.GetValue<float>(minSpeedValue);
		context.maxSpeed = flow.GetValue<float>(maxSpeedValue);
		context.abs = flow.GetValue<bool>(absoluteValue);
		return context;
	}

	public override bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		if (((Context)context).car == null)
		{
			return true;
		}
		return base.EarlyOutCheck(flow, context);
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		float num = (context2.abs ? context2.car.GetAbsSpeed() : context2.car.GetForwardSpeed());
		if (num >= context2.minSpeed)
		{
			return num <= context2.maxSpeed;
		}
		return false;
	}
}
