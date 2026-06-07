using System.Collections.Generic;
using Bolt;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(TrainCar))]
[UnitCategory("Trains")]
[UnitSubtitle("Enter the target zone and stop the car")]
[UnitTitle("Park Train Car")]
public class CarParkedUnit : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public bool Derailed;

		public bool Invert;

		public GameObject ZoneObject;

		public ParkingDetector Detector;

		public List<TrainCar> CarsToCheck;

		public TrainCar SpecificCar;

		public GameObject SpecificCarObject;

		public float ParkedTimer;
	}

	[DoNotSerialize]
	public ControlOutput derailedTrigger;

	[DoNotSerialize]
	public ValueInput parkingZone;

	[DoNotSerialize]
	public ValueInput specificCarValue;

	[DoNotSerialize]
	public ValueInput invertCondition;

	protected override string DoneFieldName => "Parked";

	protected override void InternalDefinition()
	{
		derailedTrigger = ControlOutput("Derailed");
		parkingZone = ValueInput<GameObject>("Zone", null);
		specificCarValue = ValueInput<GameObject>("Car", null);
		invertCondition = ValueInput("Invert", @default: false);
	}

	public override object PrepareContext(Flow flow)
	{
		Context context = new Context();
		context.ZoneObject = flow.GetValue<GameObject>(parkingZone);
		context.Detector = context.ZoneObject.GetComponent<ParkingDetector>();
		context.CarsToCheck = new List<TrainCar>();
		context.SpecificCarObject = flow.GetValue<GameObject>(specificCarValue);
		context.Invert = flow.GetValue<bool>(invertCondition);
		if ((bool)context.SpecificCarObject)
		{
			context.SpecificCar = TrainCar.Resolve(context.SpecificCarObject);
		}
		context.Detector.Clear();
		if ((bool)context.SpecificCar)
		{
			context.CarsToCheck.Add(context.SpecificCar);
			context.Detector.AddDesiredCar(context.SpecificCar);
		}
		else if (PlayerManager.Car != null && PlayerManager.Car.IsLoco)
		{
			context.CarsToCheck.Add(PlayerManager.Car);
			context.Detector.AddDesiredCar(PlayerManager.Car);
		}
		return context;
	}

	public override bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		context2.Detector.CheckNow();
		if (!context2.Invert)
		{
			return context2.Detector.IsCarParked;
		}
		return !context2.Detector.IsCarParked;
	}

	public override ControlOutput GetOutputTrigger(Flow flow, object context)
	{
		if (!((Context)context).Derailed)
		{
			return doneTrigger;
		}
		return derailedTrigger;
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (context2.SpecificCar == null && PlayerManager.Car != null && PlayerManager.Car.IsLoco)
		{
			context2.CarsToCheck.Add(PlayerManager.Car);
			context2.Detector.AddDesiredCar(PlayerManager.Car);
		}
		foreach (TrainCar item in context2.CarsToCheck)
		{
			if ((bool)item && item.derailed)
			{
				context2.Derailed = true;
				return !context2.Invert;
			}
		}
		if (context2.Detector.IsCarParked)
		{
			context2.ParkedTimer += Time.deltaTime;
		}
		else
		{
			context2.ParkedTimer = 0f;
		}
		if (!context2.Invert)
		{
			if (context2.Detector.IsCarParked)
			{
				return context2.ParkedTimer >= 1f;
			}
			return false;
		}
		return !context2.Detector.IsCarParked;
	}
}
