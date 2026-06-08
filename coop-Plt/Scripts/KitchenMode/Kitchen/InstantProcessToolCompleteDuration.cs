using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(HighPriorityInteractionGroup))]
	[UpdateBefore(typeof(UpdateTakesDuration))]
	public class InstantProcessToolCompleteDuration : InteractionSystem
	{
		private CTakesDuration Duration;

		private CToolUser Tool;

		protected override bool RequirePress => false;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CToolUser>(data.Interactor, out Tool))
			{
				return false;
			}
			if (!Has<CInstantProcessTool>(Tool.CurrentTool))
			{
				return false;
			}
			if (Has<CInstantProcessToolOnCooldown>(Tool.CurrentTool))
			{
				return false;
			}
			if (Has<CRequiresActivation>(data.Target) && Has<CIsInactive>(data.Target))
			{
				return false;
			}
			if (!Require<CTakesDuration>(data.Target, out Duration))
			{
				return false;
			}
			if (Duration.IsLocked)
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			Set<CInstantlyCompleteDuration>(data.Target);
			Set<CInstantProcessToolOnCooldown>(Tool.CurrentTool);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
