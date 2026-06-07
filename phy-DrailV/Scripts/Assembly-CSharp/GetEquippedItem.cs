using System.Linq;
using Bolt;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitSubtitle("Gets a reference to an item held in hand")]
[UnitTitle("Get Equipped Item")]
[TypeIcon(typeof(BoxCollider))]
[UnitCategory("Items")]
public class GetEquippedItem : Unit
{
	public enum Hand
	{
		Any = 0,
		Left = 1,
		Right = 2
	}

	[DoNotSerialize]
	public ValueInput handValue;

	[DoNotSerialize]
	public ValueOutput outputValue;

	protected override void Definition()
	{
		handValue = ValueInput("Hand", Hand.Any);
		outputValue = ValueOutput("Output", delegate(Flow flow)
		{
			switch (flow.GetValue<Hand>(handValue))
			{
			case Hand.Left:
				return SingletonBehaviour<TutorialHelper>.Instance.GrabbedObjectLeftHand;
			case Hand.Right:
				return SingletonBehaviour<TutorialHelper>.Instance.GrabbedObjectRightHand;
			default:
				return SingletonBehaviour<TutorialHelper>.Instance.GrabbedObjects.FirstOrDefault((GameObject o) => o != null);
			}
		});
	}
}
