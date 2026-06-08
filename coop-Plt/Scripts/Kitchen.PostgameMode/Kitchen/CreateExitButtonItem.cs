using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(ChangeModeGroup), OrderLast = true)]
	public class CreateExitButtonItem : PostgameInitialisationSystem
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_Marker_10;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SEndgameStats_11;

		protected override void OnUpdate()
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(CPosition), typeof(CNewsItem), typeof(CRequiresView));
			base.EntityManager.SetComponentData(entity, new CRequiresView
			{
				Type = ViewType.NewsItem
			});
			GetBuffer<SNewsList>(_SingletonEntityQuery_Marker_10.GetSingletonEntity()).Add(new SNewsList
			{
				Item = entity
			});
			if (_SingletonEntityQuery_SEndgameStats_11.GetSingleton<SEndgameStats>().IsFranchiseCreation)
			{
				base.EntityManager.SetComponentData(entity, new CNewsItem
				{
					Type = NewsItemType.CreateFranchise
				});
			}
			else
			{
				base.EntityManager.SetComponentData(entity, new CNewsItem
				{
					Type = NewsItemType.ExitButton
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_Marker_10 = GetEntityQuery(ComponentType.ReadOnly<SNewsList.Marker>());
			_SingletonEntityQuery_SEndgameStats_11 = GetEntityQuery(ComponentType.ReadOnly<SEndgameStats>());
		}
	}
}
