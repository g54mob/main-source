using Bolt;
using Ludiq;
using UnityEngine;

[UnitCategory("Movement")]
[UnitTitle("Player moved")]
[UnitSubtitle("Wait for player to move")]
[TypeIcon(typeof(CharacterController))]
public class PlayerMovedUnit : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public bool Moved;

		public float StartTime;

		public float MinimumTime;
	}

	[DoNotSerialize]
	public ValueInput minimumTime;

	protected override string DoneFieldName => "Moved";

	protected override string AnchorFieldName => string.Empty;

	protected override string OffsetFieldName => string.Empty;

	protected override void InternalDefinition()
	{
		minimumTime = ValueInput("Min. time", 5f);
	}

	public override object PrepareContext(Flow flow)
	{
		return new Context
		{
			MinimumTime = flow.GetValue<float>(minimumTime),
			StartTime = Time.time
		};
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (!context2.Moved)
		{
			LocomotionInputWrapper component = PlayerManager.PlayerTransform.GetComponent<LocomotionInputWrapper>();
			if ((bool)component && component.speed.sqrMagnitude > 0.1f)
			{
				context2.Moved = true;
				context2.StartTime = Time.time;
			}
		}
		if (context2.Moved)
		{
			return Time.time >= context2.StartTime + context2.MinimumTime;
		}
		return false;
	}
}
