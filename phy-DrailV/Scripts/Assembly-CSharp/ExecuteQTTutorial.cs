using Bolt;
using DV.Tutorial.QT;
using DV.Utils;
using Ludiq;

[UnitSubtitle("Show the player how to access the loco tutorial")]
[UnitTitle("QT Tutorial")]
[UnitCategory("Player")]
[TypeIcon(typeof(TrainCar))]
public class ExecuteQTTutorial : ExecuteLocoTutorial
{
	protected override QuickTutorial ConstructTutorial(Flow flow)
	{
		return QuickTutorialFactory.QTsTutorial();
	}

	protected override void PostTutorialPhase(Flow flow, QuickTutorial tutorial)
	{
		base.PostTutorialPhase(flow, tutorial);
		TrainCar trainCar = PlayerManager.Car;
		if (!trainCar)
		{
			trainCar = PlayerManager.LastLoco;
		}
		if ((bool)trainCar)
		{
			SingletonBehaviour<TutorialHelper>.Instance.RemoveImmobilizationFromLoco(trainCar);
		}
	}
}
