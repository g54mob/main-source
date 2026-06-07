using Bolt;
using DV.UI;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitTitle("Is Panel Shown?")]
[UnitSubtitle("Branching on element's visibility")]
[TypeIcon(typeof(Canvas))]
[UnitCategory("UI")]
public class IsCanvasElementShownUnit : Unit
{
	[DoNotSerialize]
	public ControlOutput outputYes;

	[DoNotSerialize]
	public ControlOutput outputNo;

	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ValueInput targetElementValue;

	protected override void Definition()
	{
		outputYes = ControlOutput("Yes");
		outputNo = ControlOutput("No");
		targetElementValue = ValueInput("Element", CanvasController.ElementType.Inventory);
		inputTrigger = ControlInput("Input", (Flow flow) => (!SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(flow.GetValue<CanvasController.ElementType>(targetElementValue))) ? outputNo : outputYes);
	}
}
