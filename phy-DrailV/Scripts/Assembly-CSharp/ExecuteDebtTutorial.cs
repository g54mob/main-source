using Bolt;
using DV.Tutorial.QT;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(TrainCar))]
[UnitSubtitle("Execute debt paying tutorial on a Career Manager")]
[UnitTitle("Debt Tutorial")]
[UnitCategory("Player")]
public class ExecuteDebtTutorial : ExecuteLocoTutorial
{
	[DoNotSerialize]
	public ValueInput careerManager;

	[DoNotSerialize]
	public ValueInput targetLoco;

	protected override void Definition()
	{
		base.Definition();
		careerManager = ValueInput<GameObject>("Career Manager", null);
		targetLoco = ValueInput<GameObject>("Loco", null);
	}

	protected override QuickTutorial ConstructTutorial(Flow flow)
	{
		return QuickTutorialFactory.CareerDebtPayingTutorial(flow.GetValue<GameObject>(careerManager), TrainCar.Resolve(flow.GetValue<GameObject>(targetLoco)).ID);
	}
}
