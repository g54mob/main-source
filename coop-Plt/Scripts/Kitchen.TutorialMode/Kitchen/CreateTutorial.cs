using Kitchen.Layouts;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(ChangeModeGroup))]
	public class CreateTutorial : GenericSystemBase
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SCreateScene_1;

		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SCreateScene>();
		}

		protected override void OnUpdate()
		{
			if (_SingletonEntityQuery_SCreateScene_1.GetSingleton<SCreateScene>().Type == SceneType.Tutorial)
			{
				Entity singletonEntity = _SingletonEntityQuery_SCreateScene_1.GetSingletonEntity();
				base.EntityManager.DestroyEntity(singletonEntity);
				MarkTransitionStageCompleted();
				base.EntityManager.CreateEntity(typeof(STutorialSystemMarker), typeof(STutorialMarker), typeof(SGameplayMarker), typeof(CGamePauseBlock));
				Entity ent = base.EntityManager.CreateEntity(typeof(SLayout), typeof(CLayoutOccupant), typeof(CLayoutRoomTile), typeof(CLayoutFeature));
				LayoutBlueprint layoutBlueprint = LayoutBlueprint.Blank(12, 8, RoomType.Unassigned);
				layoutBlueprint.ToEntity(base.EntityManager, ent);
				EntityManager entityManager = base.EntityManager;
				Entity entity = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition));
				entityManager.SetComponentData(entity, new CCreateAppliance
				{
					ID = AssetReference.TutorialFloor
				});
				entityManager.SetComponentData(entity, new CPosition(Vector3.zero));
				Bounds worldBounds = layoutBlueprint.GetWorldBounds();
				worldBounds.Expand(1f);
				AddBoundPoint(worldBounds.center + new Vector3(worldBounds.extents.x + 1f, 0f, worldBounds.extents.z));
				AddBoundPoint(worldBounds.center + new Vector3(worldBounds.extents.x + 1f, 0f, 0f - worldBounds.extents.z + 1f));
				AddBoundPoint(worldBounds.center + new Vector3(0f - worldBounds.extents.x - 1f, 0f, worldBounds.extents.z));
				AddBoundPoint(worldBounds.center + new Vector3(0f - worldBounds.extents.x - 1f, 0f, 0f - worldBounds.extents.z + 1f));
				Set<KeepOutsideEntitiesInView.SLockView>();
			}
		}

		protected Entity Create(Appliance appliance, Vector3 location, Vector3 facing)
		{
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition));
			entityManager.SetComponentData(entity, new CCreateAppliance
			{
				ID = appliance.ID
			});
			entityManager.SetComponentData(entity, new CPosition(location, quaternion.LookRotation(facing, new float3(0f, 1f, 0f))));
			base.TileManager.SetOccupant(location, entity);
			return entity;
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
			_SingletonEntityQuery_SCreateScene_1 = GetEntityQuery(ComponentType.ReadOnly<SCreateScene>());
		}
	}
}
