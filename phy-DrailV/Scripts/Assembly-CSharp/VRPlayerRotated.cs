using Bolt;
using Ludiq;
using UnityEngine;

[UnitTitle("VR Player Rotated")]
[UnitSubtitle("Wait for player to rotate in VR")]
[UnitCategory("Input")]
[TypeIcon(typeof(CharacterController))]
public class VRPlayerRotated : GenericWaitForCondition
{
	private class Context
	{
		public int Count;

		public void RotatePlayerOnRotatedPlayer()
		{
			Count--;
		}
	}

	[DoNotSerialize]
	public ValueInput requiredMoves;

	protected override string DoneFieldName => "Rotated";

	protected override void InternalDefinition()
	{
		requiredMoves = ValueInput("Required Moves", 0);
	}

	public override object PrepareContext(Flow flow)
	{
		Context obj = new Context
		{
			Count = flow.GetValue<int>(requiredMoves)
		};
		RotatePlayer.RotatedPlayer += obj.RotatePlayerOnRotatedPlayer;
		return obj;
	}

	public override void CleanupContext(Flow flow, object context)
	{
		RotatePlayer.RotatedPlayer -= ((Context)context).RotatePlayerOnRotatedPlayer;
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		return ((Context)context).Count <= 0;
	}
}
