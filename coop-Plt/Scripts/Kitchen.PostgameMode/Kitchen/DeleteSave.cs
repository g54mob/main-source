using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class DeleteSave : PostgameCleanupSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct SGranted : IComponentData
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct SApplyEndOfGameActions : IComponentData
		{
		}

		public EntityQuery NewsItems;

		public EntityQuery ExpChanges;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SSelectedLocation_0;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SPlayerLevel_1;

		private EntityQuery _SingletonEntityQuery_SPlayerLevel_2;

		protected override void Initialise()
		{
			base.Initialise();
			NewsItems = GetEntityQuery(typeof(CNewsItem));
			ExpChanges = GetEntityQuery(typeof(CExpChange), typeof(CreateEndgameExpReward.SEndgameExpRewarded));
		}

		protected override void OnUpdate()
		{
			if (!Has<SApplyEndOfGameActions>())
			{
				return;
			}
			SEndgameStats comp;
			bool flag = Require<SEndgameStats>(out comp) && comp.IsFranchiseCreation;
			if (HasSingleton<SSelectedLocation>())
			{
				if (flag)
				{
					Set<CSceneChangeData>(_SingletonEntityQuery_SSelectedLocation_0.GetSingletonEntity());
				}
				else
				{
					int slot = _SingletonEntityQuery_SSelectedLocation_0.GetSingleton<SSelectedLocation>().Selected.Slot;
					Persistence.FullWorld.Clear(slot);
					base.EntityManager.DestroyEntity(_SingletonEntityQuery_SSelectedLocation_0.GetSingletonEntity());
				}
			}
			if (HasSingleton<SGranted>() || !HasSingleton<SPlayerLevel>())
			{
				return;
			}
			Set(default(SGranted));
			using NativeArray<CExpChange> nativeArray = ExpChanges.ToComponentDataArray<CExpChange>(Allocator.Temp);
			SPlayerLevel current = _SingletonEntityQuery_SPlayerLevel_1.GetSingleton<SPlayerLevel>();
			foreach (CExpChange item in nativeArray)
			{
				current.AdvanceByExp(item.ExpGranted);
			}
			_SingletonEntityQuery_SPlayerLevel_2.SetSingleton(current);
			using NativeArray<CNewsItem> nativeArray2 = NewsItems.ToComponentDataArray<CNewsItem>(Allocator.Temp);
			foreach (CNewsItem item2 in nativeArray2)
			{
				if (item2.Reward != 0)
				{
					Entity entity = base.EntityManager.CreateEntity();
					base.EntityManager.AddComponentData(entity, default(CPersistThroughSceneChanges));
					base.EntityManager.AddComponentData(entity, new CUpgrade
					{
						ID = item2.Reward,
						IsFromLevel = true
					});
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SSelectedLocation_0 = GetEntityQuery(ComponentType.ReadOnly<SSelectedLocation>());
			_SingletonEntityQuery_SPlayerLevel_1 = GetEntityQuery(ComponentType.ReadOnly<SPlayerLevel>());
			_SingletonEntityQuery_SPlayerLevel_2 = GetEntityQuery(ComponentType.ReadWrite<SPlayerLevel>());
		}
	}
}
