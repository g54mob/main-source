using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(LowPriorityInteractionGroup))]
	public class PseudoInteractProcess : ItemInteractionSystem
	{
		private CItemHolder Holder;

		private CItemUndergoingProcess Process;

		protected override bool RequirePress => false;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CItemHolder>(data.Target, out Holder))
			{
				return false;
			}
			if (!Require<CItemUndergoingProcess>((Entity)Holder, out Process))
			{
				return false;
			}
			if (Require<CAutomatedInteractorProcessRestriction>(data.Interactor, out CAutomatedInteractorProcessRestriction comp) && comp.Process != Process.Process)
			{
				return false;
			}
			if (Process.IsAutomatic)
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			data.Attempt.Process = Process.Process;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
