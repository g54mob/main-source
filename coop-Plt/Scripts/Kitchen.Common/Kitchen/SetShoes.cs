using KitchenData;

namespace Kitchen
{
	public class SetShoes : InteractionSystem
	{
		private CPlayerCosmetics Cosmetics;

		private CShoeSelector Selector;

		private bool IsReturningShoes;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CPlayerCosmetics>(data.Interactor, out Cosmetics))
			{
				return false;
			}
			if (!Require<CShoeSelector>(data.Target, out Selector))
			{
				return false;
			}
			if (Selector.Available > -1)
			{
				IsReturningShoes = Cosmetics.Shoe == Selector.Shoe;
				if (Selector.Available == Selector.Max && IsReturningShoes)
				{
					return false;
				}
				if (Cosmetics.Shoe != PlayerShoe.None && !IsReturningShoes)
				{
					return false;
				}
				if (Selector.Available == 0 && !IsReturningShoes)
				{
					return false;
				}
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			bool flag = Cosmetics.Shoe != Selector.Shoe;
			Cosmetics.Shoe = (flag ? Selector.Shoe : PlayerShoe.None);
			data.Context.Set(data.Interactor, Cosmetics);
			if (Selector.Available > -1)
			{
				Selector.Available += ((!flag) ? 1 : (-1));
				data.Context.Set(data.Target, Selector);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
