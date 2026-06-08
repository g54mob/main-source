using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(LowPriorityInteractionGroup))]
	public class PetCatInteraction : ItemInteractionSystem
	{
		protected override bool RequireHold => true;

		protected override bool RequirePress => false;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CCanBePetted>(data.Target, out CCanBePetted _))
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
