using Bolt;
using Ludiq;

[UnitTitle("Set Junction")]
[TypeIcon(typeof(TrainCar))]
[UnitCategory("Trains")]
[UnitSubtitle("Set junction to desired position")]
public class SetJunctionUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput switchedTrigger;

	[DoNotSerialize]
	public ValueInput desiredBranch;

	[DoNotSerialize]
	public ValueInput junctionObject;

	protected override void Definition()
	{
		switchedTrigger = ControlOutput("Switched");
		desiredBranch = ValueInput("Branch", 0);
		junctionObject = ValueInput<JunctionSwitchRemoteControllable>("Junction", null);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			int value = flow.GetValue<int>(desiredBranch);
			Junction componentInChildren = flow.GetValue<JunctionSwitchRemoteControllable>(junctionObject).transform.parent.GetComponentInChildren<Junction>();
			for (int i = 0; i < componentInChildren.outBranches.Count; i++)
			{
				if (componentInChildren.selectedBranch == value)
				{
					break;
				}
				componentInChildren.Switch(Junction.SwitchMode.FORCED);
			}
			return switchedTrigger;
		});
	}
}
