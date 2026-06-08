using Unity.Entities;

namespace Kitchen
{
	[UpdateBefore(typeof(ItemTransferGroup))]
	public class SwitchVariableProvider : ItemInteractionSystem
	{
		private CVariableProvider VariableProvider;

		private CItemProvider Provider;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CVariableProvider>(data.Target, out VariableProvider))
			{
				return false;
			}
			if (!Require<CItemProvider>(data.Target, out Provider))
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			VariableProvider.Current = (VariableProvider.Current + 1) % 3;
			int provide = VariableProvider.Provide;
			SetComponent(data.Target, VariableProvider);
			Provider.SetAsItem(provide);
			SetComponent(data.Target, Provider);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
