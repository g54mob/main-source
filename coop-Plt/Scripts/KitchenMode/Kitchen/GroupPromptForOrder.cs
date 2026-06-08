using Unity.Entities;

namespace Kitchen
{
	public class GroupPromptForOrder : ItemInteractionSystem
	{
		private COccupiedByGroup Group;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CPartOfTableSet>(data.Target, out CPartOfTableSet comp))
			{
				return false;
			}
			if (!Has<CTableSet>(comp))
			{
				return false;
			}
			if (!Require<COccupiedByGroup>((Entity)comp, out Group))
			{
				return false;
			}
			if (!Has<CGroupReadyToOrder>(Group))
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			data.Context.Add<CGroupPromptedForOrder>(Group);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
