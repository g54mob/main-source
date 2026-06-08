using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class UpdateLoadoutStatus : FranchiseSystem
	{
		private EntityQuery _SingletonEntityQuery_SLoadoutStatus_15;

		protected override void OnUpdate()
		{
			SLoadoutStatus.RequiredActions requiredActions = SLoadoutStatus.RequiredActions.None;
			if (!TryGetSingleton<SSelectedLocation>(out var value) || !value.Valid)
			{
				requiredActions |= SLoadoutStatus.RequiredActions.PickSaveSlot;
			}
			if (!GetComponentOfSingletonHolder<CItemLayoutMap, SSelectedLayoutPedestal>(out var _))
			{
				requiredActions |= SLoadoutStatus.RequiredActions.AddLayout;
			}
			if ((!Require<SFranchiseSelector>(out var comp) || !(comp.SelectedFranchise != default(Entity)) || comp.RequiresAdditionalBase) && !GetComponentOfSingletonHolder<CSpeedrun, SSelectedLayoutPedestal>(out var _) && (!GetComponentOfSingletonHolder<CDishChoice, SFixedDishPedestal>(out var result3) || result3.Reason != FixedDishReason.Setting))
			{
				CFranchiseItem comp2;
				if (!GetComponentOfSingletonHolder<CDishChoice, SDishPedestal>(out var result4))
				{
					requiredActions |= SLoadoutStatus.RequiredActions.AddDish;
				}
				else if (Require<CFranchiseItem>(comp.SelectedFranchise, out comp2))
				{
					foreach (int card in comp2.Cards)
					{
						if (base.Data.TryGet<Dish>(card, out var output) && result4.Dish == output.ID)
						{
							requiredActions |= SLoadoutStatus.RequiredActions.DuplicateDishFranchise;
							break;
						}
					}
				}
			}
			_SingletonEntityQuery_SLoadoutStatus_15.SetSingleton((SLoadoutStatus)requiredActions);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SLoadoutStatus_15 = GetEntityQuery(ComponentType.ReadWrite<SLoadoutStatus>());
		}
	}
}
