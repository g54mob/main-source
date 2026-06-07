using Bolt;
using DV.Simulation.Brake;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(TrainCar))]
[UnitCategory("Trains")]
[UnitTitle("Release Handbrake")]
[UnitSubtitle("Show the external handbrake and wait for release or apply")]
public class ReleaseHandbrakeUnit : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public TrainCar Car;

		public HandbrakeFeedersController Controller;

		public Transform Target;

		public bool AutoPerform;

		public bool ApplyMode;
	}

	[DoNotSerialize]
	public ValueInput trainCar;

	[DoNotSerialize]
	public ValueInput autoPerform;

	[DoNotSerialize]
	public ValueInput invertValue;

	protected override string DoneFieldName => "Released";

	protected override string AnchorFieldName => string.Empty;

	protected override void InternalDefinition()
	{
		trainCar = ValueInput<GameObject>("Car", null);
		invertValue = ValueInput("Invert (apply)", @default: false);
		autoPerform = ValueInput("Auto", @default: false);
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
		context.Car = TrainCar.Resolve(flow.GetValue<GameObject>(trainCar));
		context.ApplyMode = flow.GetValue<bool>(invertValue);
		context.AutoPerform = flow.GetValue<bool>(autoPerform);
		context.Controller = context.Car.interior.GetComponentInChildren<HandbrakeFeedersController>();
		if (context.Controller.entries.Length == 1 || PlayerManager.PlayerTransform == null)
		{
			context.Target = context.Controller.entries[0].transform;
		}
		else if (context.Controller.entries.Length != 0)
		{
			Vector3 vector = PlayerManager.PlayerTransform.position;
			int num = 0;
			float num2 = (context.Controller.entries[num].transform.position - vector).sqrMagnitude;
			for (int i = 1; i < context.Controller.entries.Length; i++)
			{
				float sqrMagnitude = (context.Controller.entries[i].transform.position - vector).sqrMagnitude;
				if (sqrMagnitude < num2)
				{
					num = i;
					num2 = sqrMagnitude;
				}
			}
			context.Target = context.Controller.entries[num].transform;
		}
		else
		{
			context.Target = null;
		}
		return context;
	}

	public override bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (!context2.Car.brakeSystem.hasHandbrake || context2.Target == null)
		{
			return true;
		}
		if (context2.AutoPerform)
		{
			context2.Car.brakeSystem.SetHandbrakePosition(context2.ApplyMode ? 1f : 0f);
			return true;
		}
		if (context2.Controller.entries == null || context2.Controller.entries.Length == 0)
		{
			Debug.LogError("There are no handbrakes on this car!", context2.Car);
			return true;
		}
		return base.EarlyOutCheck(flow, context, silent);
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (!context2.ApplyMode)
		{
			return context2.Car.brakeSystem.handbrakePosition <= 0f;
		}
		return context2.Car.brakeSystem.handbrakePosition >= 1f;
	}
}
