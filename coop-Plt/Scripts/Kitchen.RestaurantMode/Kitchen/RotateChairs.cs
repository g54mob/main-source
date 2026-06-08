using Unity.Entities;

namespace Kitchen
{
	public class RotateChairs : ApplianceInteractionSystem
	{
		private CApplianceGhostChair Ghost;

		private DynamicBuffer<CGhostChairTableCandidates> Candidates;

		private CPosition Position;

		protected override InteractionType RequiredType => InteractionType.Grab;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CApplianceGhostChair>(data.Attempt.Target, out Ghost))
			{
				return false;
			}
			if (!Require<CPosition>(data.Attempt.Target, out Position))
			{
				return false;
			}
			if (!RequireBuffer(data.Attempt.Target, out Candidates))
			{
				return false;
			}
			if (Require<CItemHolder>(data.Interactor, out CItemHolder comp) && comp.HeldItem != default(Entity))
			{
				return false;
			}
			if (Candidates.Length <= 1)
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			for (int i = 0; i < Candidates.Length; i++)
			{
				if (Candidates[i].Table == Ghost.Table)
				{
					CGhostChairTableCandidates cGhostChairTableCandidates = Candidates[(i + 1 + Candidates.Length) % Candidates.Length];
					Position.Rotation = cGhostChairTableCandidates.Rotation;
					Ghost.Table = cGhostChairTableCandidates.Table;
					Set(data.Attempt.Target, Ghost);
					Set(data.Attempt.Target, Position);
					break;
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
