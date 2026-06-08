using Kitchen.Layouts;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(ChangeModeGroup))]
	public class CreateResearch : GenericSystemBase
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SCreateScene_0;

		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SCreateScene>();
		}

		protected override void OnUpdate()
		{
			if (_SingletonEntityQuery_SCreateScene_0.GetSingleton<SCreateScene>().Type == SceneType.Research)
			{
				Entity singletonEntity = _SingletonEntityQuery_SCreateScene_0.GetSingletonEntity();
				base.EntityManager.DestroyEntity(singletonEntity);
				MarkTransitionStageCompleted();
				base.EntityManager.CreateEntity(typeof(SResearchSystemMarker), typeof(SGameplayMarker), typeof(CGamePauseBlock));
				Entity ent = base.EntityManager.CreateEntity(typeof(SLayout), typeof(CLayoutOccupant), typeof(CLayoutRoomTile), typeof(CLayoutFeature));
				LayoutBlueprint.Blank(20, 15, RoomType.Unassigned).ToEntity(base.EntityManager, ent);
				EntityManager entityManager = base.EntityManager;
				Entity entity = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition));
				entityManager.SetComponentData(entity, new CCreateAppliance
				{
					ID = AssetReference.BuilderFloor
				});
				entityManager.SetComponentData(entity, new CPosition(Vector3.zero));
			}
		}

		private void AddBoundPoint(Vector3 p)
		{
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CRequiresView), typeof(CMaintainInView), typeof(CPosition));
			entityManager.SetComponentData(entity, new CRequiresView
			{
				Type = ViewType.Marker
			});
			entityManager.SetComponentData(entity, new CPosition(p));
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SCreateScene_0 = GetEntityQuery(ComponentType.ReadOnly<SCreateScene>());
		}
	}
}
