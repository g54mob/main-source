using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class SetSeededRunOverride : FranchiseSystem
	{
		private EntityQuery SeedFixers;

		private EntityQuery SettingSelectors;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SSeededLayoutPedestal_9;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SLayoutPedestal_10;

		protected override void Initialise()
		{
			base.Initialise();
			SeedFixers = GetEntityQuery(typeof(CSeededRunInfo));
			SettingSelectors = GetEntityQuery(typeof(CSettingSelector));
		}

		protected override void OnUpdate()
		{
			if (SeedFixers.IsEmpty || !Has<SLayoutPedestal>() || !Has<SSeededLayoutPedestal>())
			{
				return;
			}
			EntityContext entityContext = new EntityContext(base.EntityManager);
			CSeededRunInfo cSeededRunInfo = SeedFixers.First<CSeededRunInfo>();
			Entity singletonEntity = _SingletonEntityQuery_SSeededLayoutPedestal_9.GetSingletonEntity();
			Entity singletonEntity2 = _SingletonEntityQuery_SLayoutPedestal_10.GetSingletonEntity();
			bool isSeedOverride = cSeededRunInfo.IsSeedOverride;
			entityContext.Ensure<CHideView>(singletonEntity2, isSeedOverride);
			entityContext.Ensure<CPreventItemTransfer>(singletonEntity2, isSeedOverride);
			entityContext.Ensure<CHideView>(singletonEntity, !isSeedOverride);
			entityContext.Ensure<SSelectedLayoutPedestal>(singletonEntity, isSeedOverride);
			entityContext.Ensure<SSelectedLayoutPedestal>(singletonEntity2, !isSeedOverride);
			if (!isSeedOverride || !Require<CItemHolder>(singletonEntity, out CItemHolder comp))
			{
				return;
			}
			Seed fixedSeed = cSeededRunInfo.FixedSeed;
			int num = CSettingSelector.IDFromQuery(SettingSelectors);
			if (Require<CSetting>((Entity)comp, out CSetting comp2))
			{
				if (comp2.FixedSeed == fixedSeed && comp2.RestaurantSetting == num)
				{
					return;
				}
				base.EntityManager.DestroyEntity(comp.HeldItem);
			}
			Entity entity = new LayoutSeed(fixedSeed).GenerateMap(base.EntityManager, num);
			base.EntityManager.SetComponentData(singletonEntity, (CItemHolder)entity);
			base.EntityManager.SetComponentData(entity, (CHeldBy)singletonEntity);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SSeededLayoutPedestal_9 = GetEntityQuery(ComponentType.ReadOnly<SSeededLayoutPedestal>());
			_SingletonEntityQuery_SLayoutPedestal_10 = GetEntityQuery(ComponentType.ReadOnly<SLayoutPedestal>());
		}
	}
}
