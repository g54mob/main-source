using Bolt;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitSubtitle("Wait for player to teleport a couple of times")]
[UnitCategory("Movement")]
[UnitTitle("Player teleported")]
[TypeIcon(typeof(CharacterController))]
public class PlayerTeleportedUnit : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public int Count;

		public void OnTeleported()
		{
			if (Count > 0)
			{
				Count--;
			}
		}
	}

	[DoNotSerialize]
	public ValueInput requiredCount;

	protected override string DoneFieldName => "Teleported";

	protected override string AnchorFieldName => string.Empty;

	protected override string OffsetFieldName => string.Empty;

	protected override void InternalDefinition()
	{
		requiredCount = ValueInput("Count", 1);
	}

	public override object PrepareContext(Flow flow)
	{
		Context context = new Context();
		context.Count = flow.GetValue<int>(requiredCount);
		TeleportPointerController[] teleportControllers = SingletonBehaviour<TutorialHelper>.Instance.TeleportControllers;
		foreach (TeleportPointerController teleportPointerController in teleportControllers)
		{
			if ((bool)teleportPointerController)
			{
				teleportPointerController.Teleported += context.OnTeleported;
			}
		}
		return context;
	}

	public override void CleanupContext(Flow flow, object context)
	{
		Context context2 = (Context)context;
		TeleportPointerController[] teleportControllers = SingletonBehaviour<TutorialHelper>.Instance.TeleportControllers;
		foreach (TeleportPointerController teleportPointerController in teleportControllers)
		{
			if ((bool)teleportPointerController)
			{
				teleportPointerController.Teleported -= context2.OnTeleported;
			}
		}
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		return ((Context)context).Count <= 0;
	}
}
