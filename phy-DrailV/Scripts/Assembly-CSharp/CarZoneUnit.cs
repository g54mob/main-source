using Bolt;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(TrainCar))]
[UnitSubtitle("Train car enters or exits a zone")]
[UnitCategory("Trains")]
[UnitTitle("Train Car Zone")]
public class CarZoneUnit : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public TrainCar TargetCar;

		public ParkingDetector Detector;

		public bool StartingOutside;

		public bool Entered;

		public bool Exited;

		public bool EnterConnected;

		public bool ExitConnected;

		public bool CheckDetector()
		{
			if (EnterConnected && Detector.IsCarInside && StartingOutside)
			{
				Entered = true;
				return true;
			}
			if (ExitConnected && !Detector.IsCarInside && !StartingOutside)
			{
				Exited = true;
				return true;
			}
			return false;
		}
	}

	[DoNotSerialize]
	public ControlOutput exitedTrigger;

	[DoNotSerialize]
	public ValueInput parkingZone;

	[DoNotSerialize]
	public ValueInput targetCar;

	[DoNotSerialize]
	public ValueInput startsOutside;

	protected override string DoneFieldName => "Entered";

	protected override void InternalDefinition()
	{
		parkingZone = ValueInput<GameObject>("Zone", null);
		targetCar = ValueInput<GameObject>("Car", null);
		startsOutside = ValueInput("Starts outside", @default: true);
		exitedTrigger = ControlOutput("Exited");
	}

	public override object PrepareContext(Flow flow)
	{
		Context context = new Context();
		GameObject value = flow.GetValue<GameObject>(parkingZone);
		context.Detector = value.GetComponent<ParkingDetector>();
		context.TargetCar = TrainCar.Resolve(flow.GetValue<GameObject>(targetCar));
		context.StartingOutside = flow.GetValue<bool>(startsOutside);
		context.EnterConnected = doneTrigger.hasValidConnection;
		context.ExitConnected = exitedTrigger.hasValidConnection;
		return context;
	}

	public override void Initialize(Flow flow, object context, bool silent = false)
	{
		base.Initialize(flow, context, silent);
		Context context2 = (Context)context;
		if (context2.TargetCar == null && PlayerManager.Car != null)
		{
			context2.TargetCar = PlayerManager.Car;
		}
		if (context2.TargetCar != null)
		{
			context2.Detector.AddDesiredCar(context2.TargetCar);
		}
	}

	public override bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (context2.TargetCar != null)
		{
			context2.Detector.CheckNow();
			if (context2.CheckDetector())
			{
				return true;
			}
		}
		return false;
	}

	public override ControlOutput GetOutputTrigger(Flow flow, object context)
	{
		if (!((Context)context).Exited)
		{
			return doneTrigger;
		}
		return exitedTrigger;
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (context2.TargetCar == null && PlayerManager.Car != null)
		{
			context2.TargetCar = PlayerManager.Car;
			context2.Detector.AddDesiredCar(context2.TargetCar);
		}
		return context2.CheckDetector();
	}
}
