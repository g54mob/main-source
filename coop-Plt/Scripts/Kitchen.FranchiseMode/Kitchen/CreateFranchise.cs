using Kitchen.Layouts;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(ChangeModeGroup))]
	public class CreateFranchise : GenericSystemBase
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SCreateScene_4;

		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SCreateScene>();
		}

		protected override void OnUpdate()
		{
			if (_SingletonEntityQuery_SCreateScene_4.GetSingleton<SCreateScene>().Type == SceneType.Franchise)
			{
				Entity singletonEntity = _SingletonEntityQuery_SCreateScene_4.GetSingletonEntity();
				base.EntityManager.DestroyEntity(singletonEntity);
				MarkTransitionStageCompleted();
				base.EntityManager.CreateEntity(typeof(SFranchiseMarker), typeof(SGameplayMarker), typeof(CGamePauseBlock));
				Entity entity = base.EntityManager.CreateEntity(typeof(SLoadoutStatus));
				base.EntityManager.SetComponentData(entity, new SLoadoutStatus
				{
					Required = SLoadoutStatus.RequiredActions.Check
				});
				Entity entity2 = base.EntityManager.CreateEntity(typeof(SLayout), typeof(CLayoutOccupant), typeof(CLayoutRoomTile), typeof(CLayoutFeature));
				LayoutBlueprint layoutBlueprint = base.Data.ReferableObjects.FranchiseLayout.Build();
				layoutBlueprint.ToEntity(base.EntityManager, entity2);
				if (!Has<CFrontDoorMarker>(entity2))
				{
					base.EntityManager.AddComponentData(entity2, new CFrontDoorMarker
					{
						Location = new Vector3(1f, 0f, 1f)
					});
				}
				else
				{
					base.EntityManager.SetComponentData(entity2, new CFrontDoorMarker
					{
						Location = new Vector3(1f, 0f, 1f)
					});
				}
				Bounds worldBounds = layoutBlueprint.GetWorldBounds();
				worldBounds.Expand(1f);
				AddBoundPoint(worldBounds.center + new Vector3(worldBounds.extents.x + 1f, 0f, worldBounds.extents.z - 0.5f));
				AddBoundPoint(worldBounds.center + new Vector3(worldBounds.extents.x + 1f, 0f, 0f - worldBounds.extents.z - 1.5f));
				AddBoundPoint(worldBounds.center + new Vector3(0f - worldBounds.extents.x - 1f, 0f, worldBounds.extents.z - 0.5f));
				AddBoundPoint(worldBounds.center + new Vector3(0f - worldBounds.extents.x - 1f, 0f, 0f - worldBounds.extents.z - 1.5f));
				Entity entity3 = base.EntityManager.CreateEntity();
				base.EntityManager.AddComponentData(entity3, new CLayoutView
				{
					Layout = entity2
				});
				base.EntityManager.AddComponentData(entity3, (CPosition)Vector3.zero);
				base.EntityManager.AddComponentData(entity3, (CRequiresView)ViewType.FranchiseFloorplan);
				Entity entity4 = base.EntityManager.CreateEntity();
				base.EntityManager.AddComponentData(entity4, new CRequestSave
				{
					SaveType = SaveType.Auto
				});
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

		private void CreateStartSelector()
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(SBeginGameSelector));
			base.EntityManager.AddComponentData(entity, new CGroupSelector
			{
				Bounds = new Bounds(LobbyPositionAnchors.StartMarker, new Vector3(6f, 10f, 2f))
			});
			base.EntityManager.AddComponentData(entity, new CMaintainInView
			{
				Radius = 4f
			});
			base.EntityManager.AddComponentData(entity, new CRequiresView
			{
				Type = ViewType.GroupSelector
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SCreateScene_4 = GetEntityQuery(ComponentType.ReadOnly<SCreateScene>());
		}
	}
}
