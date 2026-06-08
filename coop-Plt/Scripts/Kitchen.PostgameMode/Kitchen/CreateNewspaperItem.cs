using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class CreateNewspaperItem : PostgameInitialisationSystem
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SEndgameStats_12;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SGameLossReason_13;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_Marker_14;

		protected override void OnUpdate()
		{
			SEndgameStats singleton = _SingletonEntityQuery_SEndgameStats_12.GetSingleton<SEndgameStats>();
			LossReason lossReason = (HasSingleton<SGameLossReason>() ? _SingletonEntityQuery_SGameLossReason_13.GetSingleton<SGameLossReason>().Reason : LossReason.Patience);
			Entity entity = base.EntityManager.CreateEntity(typeof(CPosition), typeof(CNewsItem), typeof(CNewsItemActive), typeof(CRequiresView));
			NewsItemType type = NewsItemType.Newspaper;
			if (singleton.IsExpGrant)
			{
				type = NewsItemType.MultiplayerExpGrant;
			}
			if (singleton.IsFranchiseScrap)
			{
				type = NewsItemType.ScrapFranchise;
			}
			base.EntityManager.SetComponentData(entity, new CNewsItem
			{
				Type = type,
				LossReason = lossReason
			});
			base.EntityManager.SetComponentData(entity, new CRequiresView
			{
				Type = ViewType.NewsItem
			});
			GetBuffer<SNewsList>(_SingletonEntityQuery_Marker_14.GetSingletonEntity()).Add(new SNewsList
			{
				Item = entity
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SEndgameStats_12 = GetEntityQuery(ComponentType.ReadOnly<SEndgameStats>());
			_SingletonEntityQuery_SGameLossReason_13 = GetEntityQuery(ComponentType.ReadOnly<SGameLossReason>());
			_SingletonEntityQuery_Marker_14 = GetEntityQuery(ComponentType.ReadOnly<SNewsList.Marker>());
		}
	}
}
