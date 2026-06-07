using Bolt;
using Ludiq;
using UnityEngine;

[UnitTitle("Bring Cars Together")]
[TypeIcon(typeof(TrainCar))]
[UnitCategory("Trains")]
[UnitSubtitle("Bring two train cars close enough to couple")]
public class BringCarsToCoupling : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public TrainCar car1;

		public TrainCar car2;
	}

	[DoNotSerialize]
	public ValueInput carA;

	[DoNotSerialize]
	public ValueInput carB;

	protected override string DoneFieldName => "Parked";

	protected override void InternalDefinition()
	{
		carA = ValueInput<GameObject>("Car A", null);
		carB = ValueInput<GameObject>("Car B", null);
	}

	public override object PrepareContext(Flow flow)
	{
		return new Context
		{
			car1 = TrainCar.Resolve(flow.GetValue<GameObject>(carA)),
			car2 = TrainCar.Resolve(flow.GetValue<GameObject>(carB))
		};
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		return CheckCouplerDistances(context2.car1, context2.car2);
	}

	private static bool CheckCouplerDistances(TrainCar a, TrainCar b, float maxDistance = 0.4f)
	{
		if (a.GetAbsSpeed() > 0.01f)
		{
			return false;
		}
		if (b.GetAbsSpeed() > 0.01f)
		{
			return false;
		}
		for (int i = 0; i < a.couplers.Length; i++)
		{
			for (int j = 0; j < b.couplers.Length; j++)
			{
				if (Vector3.Distance(a.couplers[i].transform.position, b.couplers[j].transform.position) < maxDistance)
				{
					return true;
				}
			}
		}
		return false;
	}
}
