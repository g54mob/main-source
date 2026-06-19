using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SuperBugObjective : MetagameObjective
	{
		public readonly int SuperBugID;

		public readonly int NodeID;

		public SuperBugObjective(Metagame metagame, ObjectiveDefinition definition, bool isReplayable, int superBugID, int nodeID)
			: base(metagame, definition, isVisible: true, isDiscovered: true, isReplayable, startImmediately: false)
		{
			SuperBugID = superBugID;
			NodeID = nodeID;
		}

		protected override void OnFinish(CompletionType completionType)
		{
			base.OnFinish(completionType);
			if (base.Metagame.App?.SuperBugManager != null)
			{
				base.Metagame.App.SuperBugManager.OnSuperBugObjectiveComplete(SuperBugID, NodeID, completionType);
			}
			if (completionType != CompletionType.Failed)
			{
				base.Metagame.CollaborativePortfolio.OnActiveObjectiveCompleted(this, completionType);
			}
		}

		public override bool ShowGUIOnDiscover()
		{
			return true;
		}

		public override bool CanDismiss()
		{
			return true;
		}

		public override bool ReadyToDestroyOnComplete()
		{
			return false;
		}
	}
}
