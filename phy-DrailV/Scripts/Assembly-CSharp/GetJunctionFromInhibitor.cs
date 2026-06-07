using Bolt;
using Ludiq;
using UnityEngine;

[UnitSubtitle("Scan for a junction in inhibitor's area, or the closest one to an object")]
[TypeIcon(typeof(TrainCar))]
[UnitCategory("Trains")]
[UnitTitle("Get Junction From Inhibitor")]
public class GetJunctionFromInhibitor : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput outputTrigger;

	[DoNotSerialize]
	public ValueInput inhibitorInput;

	[DoNotSerialize]
	public ValueOutput junctionOutput;

	protected override void Definition()
	{
		outputTrigger = ControlOutput("Got it");
		inhibitorInput = ValueInput<GameObject>("Inhibitor", null);
		junctionOutput = ValueOutput<JunctionSwitchRemoteControllable>("Output");
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			GameObject value = flow.GetValue<GameObject>(inhibitorInput);
			if (value == null)
			{
				flow.SetValue(junctionOutput, null);
				return outputTrigger;
			}
			TutorialSwitchInhibitor component = value.GetComponent<TutorialSwitchInhibitor>();
			if (component == null)
			{
				int layerMask = 1 << LayerMask.NameToLayer("Laser_Pointer_Target");
				Collider[] array = new Collider[8];
				int num = Physics.OverlapSphereNonAlloc(value.transform.position, 15f, array, layerMask, QueryTriggerInteraction.Collide);
				for (int i = 0; i < num; i++)
				{
					Junction componentInChildren = array[i].transform.parent.GetComponentInChildren<Junction>(includeInactive: true);
					if (componentInChildren != null && componentInChildren.GetComponentInChildren<JunctionSwitchRemoteControllable>() != null)
					{
						flow.SetValue(junctionOutput, componentInChildren);
						return outputTrigger;
					}
				}
				flow.SetValue(junctionOutput, null);
				return outputTrigger;
			}
			flow.SetValue(junctionOutput, component.junctionSwitch);
			return outputTrigger;
		});
	}
}
