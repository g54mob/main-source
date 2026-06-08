using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateAfter(typeof(CreateNewspaperItem))]
	public class CreateCardList : PostgameInitialisationSystem
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SEndgameStats_8;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_Marker_9;

		protected override void OnUpdate()
		{
			if (_SingletonEntityQuery_SEndgameStats_8.GetSingleton<SEndgameStats>().IsExpGrant)
			{
				return;
			}
			DynamicBuffer<CEndgameUnlock> buffer = GetBuffer<CEndgameUnlock>(_SingletonEntityQuery_SEndgameStats_8.GetSingletonEntity());
			bool flag = false;
			for (int i = 0; i < buffer.Length; i++)
			{
				if (!buffer[i].FromFranchise && buffer[i].Type == CardType.Default && buffer[i].Type == CardType.HalloweenTreat && buffer[i].Type == CardType.HalloweenTrick)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				Entity entity = base.EntityManager.CreateEntity(typeof(CPosition), typeof(CNewsItem), typeof(CNewsCards), typeof(CRequiresView));
				base.EntityManager.SetComponentData(entity, new CNewsItem
				{
					Type = NewsItemType.CardList
				});
				base.EntityManager.SetComponentData(entity, new CRequiresView
				{
					Type = ViewType.NewsItem
				});
				GetBuffer<SNewsList>(_SingletonEntityQuery_Marker_9.GetSingletonEntity()).Add(new SNewsList
				{
					Item = entity
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SEndgameStats_8 = GetEntityQuery(ComponentType.ReadOnly<SEndgameStats>());
			_SingletonEntityQuery_Marker_9 = GetEntityQuery(ComponentType.ReadOnly<SNewsList.Marker>());
		}
	}
}
