using Unity.Entities;

namespace Kitchen
{
	public class InstantProcessToolCompleteProcess : InteractionSystem
	{
		private CItemUndergoingProcess Process;

		private CItemHolder Holder;

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
			if (!Require<CItemHolder>(data.Target, out Holder))
			{
				return false;
			}
			if (!Require<CItemUndergoingProcess>((Entity)Holder, out Process))
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			Process.IsSpecialFinish = true;
			Process.Progress = 1f;
			Set(Holder, Process);
			Set<CInstantProcessToolOnCooldown>(Tool.CurrentTool);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
