using System.Collections.Generic;
using System.Linq;
using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class ManagePedestalState : FranchiseBuilderSystem
	{
		private EntityQuery Pedestals;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SEndgameStats_1;

		private EntityQuery _SingletonEntityQuery_SClaimExpSelector_2;

		private EntityQuery _SingletonEntityQuery_SCreateFranchiseSelector_3;

		protected override void Initialise()
		{
			base.Initialise();
			Pedestals = GetEntityQuery(typeof(CCardPedestal), typeof(CItemHolder));
		}

		protected override void OnUpdate()
		{
			NativeArray<Entity> nativeArray = Pedestals.ToEntityArray(Allocator.Temp);
			NativeArray<CCardPedestal> nativeArray2 = Pedestals.ToComponentDataArray<CCardPedestal>(Allocator.Temp);
			NativeArray<CEndgameUnlock> nativeArray3 = GetBuffer<CEndgameUnlock>(_SingletonEntityQuery_SEndgameStats_1.GetSingletonEntity()).ToNativeArray(Allocator.Temp);
			int num = nativeArray2.Count((CCardPedestal p) => p.IsSelected && !p.IsForcedCard);
			for (int num2 = 0; num2 < nativeArray2.Length; num2++)
			{
				CCardPedestal value = nativeArray2[num2];
				value.BlockedBy = 0;
				value.UntoggleableTooManyCards = false;
				nativeArray2[num2] = value;
			}
			for (int num3 = 0; num3 < nativeArray.Length; num3++)
			{
				Entity entity = nativeArray[num3];
				CCardPedestal component = nativeArray2[num3];
				if (num >= 3)
				{
					component.UntoggleableTooManyCards = !component.IsSelected;
				}
				else
				{
					component.UntoggleableTooManyCards = false;
				}
				if (!component.IsSelected)
				{
					if (base.Data.TryGet<Unlock>(component.CardID, out var output, warn_if_fail: true))
					{
						List<Unlock> requires = output.Requires;
						component.BlockedBy = 0;
						foreach (Unlock item in requires)
						{
							if (!(from c in nativeArray3
								where !CreateCardSelectors.ShouldCreateSelector(c)
								select c.UnlockID).Contains(item.ID) && !(from c in nativeArray2
								where c.IsSelected
								select c.CardID).Contains(item.ID))
							{
								component.BlockedBy = item.ID;
								break;
							}
						}
					}
				}
				else
				{
					foreach (CCardPedestal item2 in nativeArray2)
					{
						if (item2.IsSelected && base.Data.TryGet<Unlock>(item2.CardID, out var output2, warn_if_fail: true) && output2.Requires.Select((Unlock p) => p.ID).Contains(component.CardID))
						{
							component.BlockedBy = item2.CardID;
						}
					}
				}
				SetComponent(entity, component);
			}
			if (TryGetSingleton<SClaimExpSelector>(out var value2))
			{
				value2.ExpValue = nativeArray3.Sum((CEndgameUnlock c) => (int)(base.Data.TryGet<ICard>(c.UnlockID, out var output3, warn_if_fail: true) ? output3.ExpReward : Unlock.RewardLevel.None));
				_SingletonEntityQuery_SClaimExpSelector_2.SetSingleton(value2);
			}
			if (TryGetSingleton<SCreateFranchiseSelector>(out var value3))
			{
				value3.CardCount = num;
				if (num == 3)
				{
					base.EntityManager.AddComponent<CSelectorEnabled>(value3.Selector);
				}
				else
				{
					base.EntityManager.RemoveComponent<CSelectorEnabled>(value3.Selector);
				}
				_SingletonEntityQuery_SCreateFranchiseSelector_3.SetSingleton(value3);
			}
			nativeArray.Dispose();
			nativeArray2.Dispose();
			nativeArray3.Dispose();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SEndgameStats_1 = GetEntityQuery(ComponentType.ReadOnly<SEndgameStats>());
			_SingletonEntityQuery_SClaimExpSelector_2 = GetEntityQuery(ComponentType.ReadWrite<SClaimExpSelector>());
			_SingletonEntityQuery_SCreateFranchiseSelector_3 = GetEntityQuery(ComponentType.ReadWrite<SCreateFranchiseSelector>());
		}
	}
}
