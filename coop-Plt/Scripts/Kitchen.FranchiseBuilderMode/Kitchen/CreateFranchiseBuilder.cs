using System.Linq;
using Kitchen.Layouts;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(ChangeModeGroup))]
	public class CreateFranchiseBuilder : GenericSystemBase
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SCreateScene_8;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SEndgameStats_9;

		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SCreateScene>();
		}

		protected override void OnUpdate()
		{
			if (_SingletonEntityQuery_SCreateScene_8.GetSingleton<SCreateScene>().Type == SceneType.FranchiseBuilder)
			{
				Entity singletonEntity = _SingletonEntityQuery_SCreateScene_8.GetSingletonEntity();
				base.EntityManager.DestroyEntity(singletonEntity);
				MarkTransitionStageCompleted();
				base.EntityManager.CreateEntity(typeof(SFranchiseBuilderMarker), typeof(SGameplayMarker), typeof(CGamePauseBlock));
				Entity ent = base.EntityManager.CreateEntity(typeof(SLayout), typeof(CLayoutOccupant), typeof(CLayoutRoomTile), typeof(CLayoutFeature));
				NativeArray<CEndgameUnlock> nativeArray = GetBuffer<CEndgameUnlock>(_SingletonEntityQuery_SEndgameStats_9.GetSingletonEntity()).ToNativeArray(Allocator.Temp);
				int num = nativeArray.Count((CEndgameUnlock c) => !c.FromFranchise);
				nativeArray.Dispose();
				int height = 15 + ((num > 30) ? 10 : 0);
				LayoutBlueprint.Blank(num * 2 + 8, height, RoomType.Unassigned).ToEntity(base.EntityManager, ent);
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
			_SingletonEntityQuery_SCreateScene_8 = GetEntityQuery(ComponentType.ReadOnly<SCreateScene>());
			_SingletonEntityQuery_SEndgameStats_9 = GetEntityQuery(ComponentType.ReadOnly<SEndgameStats>());
		}
	}
}
