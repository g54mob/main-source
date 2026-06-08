using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateAfter(typeof(CreateNewspaperItem))]
	[UpdateAfter(typeof(CreateCardList))]
	public class CreateEndgameExpReward : PostgameInitialisationSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct SEndgameExpRewarded : IComponentData
		{
		}

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SEndgameStats_3;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SPlayerLevel_4;

		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SEndgameStats>();
			RequireSingletonForUpdate<SPlayerLevel>();
		}

		protected override void OnUpdate()
		{
			if (HasSingleton<SEndgameExpRewarded>())
			{
				return;
			}
			Entity singletonEntity = _SingletonEntityQuery_SEndgameStats_3.GetSingletonEntity();
			SEndgameStats singleton = _SingletonEntityQuery_SEndgameStats_3.GetSingleton<SEndgameStats>();
			Entity entity = base.EntityManager.CreateEntity(typeof(SEndgameExpRewarded), typeof(CExpChange));
			if (!singleton.IsExpGrant)
			{
				base.EntityManager.AddComponentData(entity, new CRequiresView
				{
					Type = ViewType.MultiplayerGrantExp
				});
			}
			SPlayerLevel current = _SingletonEntityQuery_SPlayerLevel_4.GetSingleton<SPlayerLevel>();
			CExpChange componentData = new CExpChange
			{
				Old = current,
				ExpIdentifier = Random.Range(int.MinValue, int.MaxValue)
			};
			DynamicBuffer<CEndgameUnlock> buffer = GetBuffer<CEndgameUnlock>(singletonEntity);
			int num = singleton.ExpGrant;
			float num2 = 1f;
			foreach (CEndgameUnlock item in buffer)
			{
				if (!item.FromFranchise && base.Data.TryGet<GameDataObject>(item.UnlockID, out var output, warn_if_fail: true))
				{
					if (output is ICard card)
					{
						num = (int)(num + card.ExpReward);
					}
					if (output is Contract contract)
					{
						num2 += contract.ExperienceMultiplier - 1f;
					}
				}
			}
			num = Mathf.RoundToInt(num2 * (float)num);
			current.AdvanceByExp(num);
			componentData.New = current;
			componentData.ExpGranted = num;
			base.EntityManager.SetComponentData(entity, componentData);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SEndgameStats_3 = GetEntityQuery(ComponentType.ReadOnly<SEndgameStats>());
			_SingletonEntityQuery_SPlayerLevel_4 = GetEntityQuery(ComponentType.ReadOnly<SPlayerLevel>());
		}
	}
}
