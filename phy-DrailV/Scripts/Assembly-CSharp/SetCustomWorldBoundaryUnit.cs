using Bolt;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitCategory("Interaction")]
[TypeIcon(typeof(BoxCollider))]
[UnitTitle("Set World Boundary")]
[UnitSubtitle("Set custom world boundary, or clear it")]
public class SetCustomWorldBoundaryUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	[DoNotSerialize]
	public ValueInput enabledValue;

	[DoNotSerialize]
	public ValueInput boundarySizeValue;

	[DoNotSerialize]
	public ValueInput boundaryOffsetValue;

	protected override void Definition()
	{
		doneTrigger = ControlOutput("Done");
		enabledValue = ValueInput("Enable", @default: true);
		boundarySizeValue = ValueInput("Size", Vector3.zero);
		boundaryOffsetValue = ValueInput("Offset", Vector3.zero);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			bool value = flow.GetValue<bool>(enabledValue);
			Vector3 value2 = flow.GetValue<Vector3>(boundarySizeValue);
			Vector3 value3 = flow.GetValue<Vector3>(boundaryOffsetValue);
			if (value)
			{
				SingletonBehaviour<LevelInfo>.Instance.customBoundary = true;
				SingletonBehaviour<LevelInfo>.Instance.customBoundarySize = value2;
				SingletonBehaviour<LevelInfo>.Instance.customBoundaryOffset = value3;
			}
			else
			{
				SingletonBehaviour<LevelInfo>.Instance.customBoundary = false;
			}
			return doneTrigger;
		});
	}
}
