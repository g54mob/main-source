using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(ChangeModeGroup))]
	public class CreatePostgame : GenericSystemBase
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SCreateScene_15;

		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SCreateScene>();
		}

		protected override void OnUpdate()
		{
			if (_SingletonEntityQuery_SCreateScene_15.GetSingleton<SCreateScene>().Type == SceneType.Postgame)
			{
				Entity singletonEntity = _SingletonEntityQuery_SCreateScene_15.GetSingletonEntity();
				base.EntityManager.DestroyEntity(singletonEntity);
				Entity e = base.EntityManager.CreateEntity(typeof(SPostgameFirstFrameMarker));
				GetCommandBuffer(ECB.End).DestroyEntity(e);
				MarkTransitionStageCompleted();
				Set<SPreventSaving>();
				Entity entity = base.EntityManager.CreateEntity(typeof(CRequiresView), typeof(CPosition), typeof(CNewsUIView), typeof(CCaptureInput), typeof(CGamePauseBlock));
				base.EntityManager.SetComponentData(entity, new CRequiresView
				{
					Type = ViewType.NewsUI,
					ViewMode = ViewMode.Screen
				});
				base.EntityManager.SetComponentData(entity, new CPosition(new Vector3(0.5f, 0f, 0f)));
				base.EntityManager.SetComponentData(entity, new CCaptureInput
				{
					AllUsers = true
				});
				base.EntityManager.CreateEntity(typeof(SLayout), typeof(CLayoutOccupant), typeof(CLayoutRoomTile), typeof(CLayoutFeature));
				base.EntityManager.CreateEntity(typeof(SPostgameMarker));
				base.EntityManager.CreateEntity(typeof(SNewsList.Marker), typeof(SNewsList));
				AddBoundPoint(new Vector3(4f, 0f, 4f));
				AddBoundPoint(new Vector3(-4f, 0f, 4f));
				AddBoundPoint(new Vector3(4f, 0f, -4f));
				AddBoundPoint(new Vector3(-4f, 0f, -4f));
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
			_SingletonEntityQuery_SCreateScene_15 = GetEntityQuery(ComponentType.ReadOnly<SCreateScene>());
		}
	}
}
