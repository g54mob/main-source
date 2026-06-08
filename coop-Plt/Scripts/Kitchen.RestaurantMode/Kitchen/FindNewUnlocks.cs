using System.Collections.Generic;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateBefore(typeof(HandleNewShop))]
	[UpdateAfter(typeof(CreateShopRequests))]
	[UpdateInGroup(typeof(EndOfDayProgressionGroup))]
	public class FindNewUnlocks : RestaurantSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct SHasRun : IComponentData
		{
		}

		private EntityQuery CurrentUnlocks;

		private EntityQuery CurrentOptions;

		private HashSet<int> CurrentUnlockIDs;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SLayout_49;

		protected override void Initialise()
		{
			base.Initialise();
			CurrentUnlocks = GetEntityQuery(typeof(CProgressionUnlock));
			CurrentOptions = GetEntityQuery(typeof(CProgressionOption));
			CurrentUnlockIDs = new HashSet<int>();
		}

		protected override void OnUpdate()
		{
			if (!Has<SIsNightTime>())
			{
				Clear<SHasRun>();
			}
			else
			{
				if (Has<SHasRun>() || !CurrentOptions.IsEmpty)
				{
					return;
				}
				Set<SHasRun>();
				int activeUnlockPack = GetOrDefault<CUnlockPack>().ActiveUnlockPack;
				activeUnlockPack = ((activeUnlockPack == 0) ? AssetReference.DefaultUnlockPack : activeUnlockPack);
				int instance = 1;
				if (Require<SDay>(out var comp))
				{
					instance = comp.Day;
				}
				using FixedSeedContext fixedSeedContext = Seed(848292, instance);
				using NativeArray<CProgressionUnlock> nativeArray = CurrentUnlocks.ToComponentDataArray<CProgressionUnlock>(Allocator.Temp);
				CurrentUnlockIDs.Clear();
				foreach (CProgressionUnlock item in nativeArray)
				{
					CurrentUnlockIDs.Add(item.ID);
				}
				int tier = 0;
				Entity singletonEntity = _SingletonEntityQuery_SLayout_49.GetSingletonEntity();
				if (HasComponent<CFranchiseTier>(singletonEntity))
				{
					tier = GetComponent<CFranchiseTier>(singletonEntity).Tier;
				}
				if (!GameData.Main.TryGet<UnlockPack>(activeUnlockPack, out var output))
				{
					Debug.LogError($"Couldn't find UnlockPack with ID {activeUnlockPack}");
					return;
				}
				using (fixedSeedContext.UseSubcontext(1))
				{
					UnlockOptions options = output.GetOptions(CurrentUnlockIDs, new UnlockRequest(comp.Day, tier));
					if (options.Unlock1 != null)
					{
						AddOption(options.Unlock1.ID);
					}
					if (options.Unlock2 != null)
					{
						AddOption(options.Unlock2.ID);
					}
				}
			}
		}

		private void AddOption(int id)
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(CProgressionOption));
			base.EntityManager.SetComponentData(entity, new CProgressionOption
			{
				ID = id
			});
			Set(entity, new CUnlockSelectPopupType
			{
				RewardType = UnlockRewardType.Standard
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SLayout_49 = GetEntityQuery(ComponentType.ReadOnly<SLayout>());
		}
	}
}
