namespace Kitchen
{
	public class ToggleCardViewer : ItemInteractionSystem
	{
		private CFranchiseCardViewer CardViewer;

		protected override bool AllowActOrGrab => true;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CFranchiseCardViewer>(data.Target, out CardViewer))
			{
				return false;
			}
			if (!HasSingleton<SFranchiseSelector>())
			{
				return false;
			}
			if (!Has<CFranchiseItem>(GetOrCreate<SFranchiseSelector>().SelectedFranchise))
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			if (HasSingleton<SFranchiseSelector>() && Require<CFranchiseItem>(GetOrCreate<SFranchiseSelector>().SelectedFranchise, out CFranchiseItem comp))
			{
				int num = ((data.Attempt.Type == InteractionType.Grab) ? 1 : (-1));
				CardViewer.Index = (CardViewer.Index + num + comp.Cards.Count) % comp.Cards.Count;
				SetComponent(data.Target, CardViewer);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
