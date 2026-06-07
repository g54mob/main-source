using Bolt;
using DV.Tutorial.QT;
using Ludiq;

[TypeIcon(typeof(TrainCar))]
[UnitSubtitle("Show the player how to access the in-game manual")]
[UnitTitle("Manual Tutorial")]
[UnitCategory("Player")]
public class ExecuteManualTutorial : ExecuteLocoTutorial
{
	protected override QuickTutorial ConstructTutorial(Flow flow)
	{
		return QuickTutorialFactory.ManualTutorial();
	}
}
