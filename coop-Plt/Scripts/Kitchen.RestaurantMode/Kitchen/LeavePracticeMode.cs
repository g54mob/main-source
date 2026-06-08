using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class LeavePracticeMode : GameSystemBase
	{
		public struct SLeavePracticeView : IComponentData
		{
			public bool Ready;
		}

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SLeavePracticeView_40;

		protected override void OnUpdate()
		{
			if (Has<SPracticeMode>())
			{
				if (!Has<SLeavePracticeView>())
				{
					Entity entity = base.EntityManager.CreateEntity(typeof(CPosition), typeof(CRequiresView), typeof(SLeavePracticeView), typeof(CCaptureInput), typeof(CCapturePassthrough));
					base.EntityManager.AddComponentData(entity, new CCaptureInput
					{
						AllUsers = true
					});
					base.EntityManager.SetComponentData(entity, new CPosition(0.5f, 0.95f));
					base.EntityManager.SetComponentData(entity, new CRequiresView
					{
						Type = ViewType.EndPractice,
						ViewMode = ViewMode.Screen
					});
				}
				if (_SingletonEntityQuery_SLeavePracticeView_40.GetSingleton<SLeavePracticeView>().Ready)
				{
					Entity e = Set<CPreservePlayerPositionFlag>();
					Set<CPersistThroughSceneChanges>(e);
					base.EntityManager.DestroyEntity(_SingletonEntityQuery_SLeavePracticeView_40.GetSingletonEntity());
					base.TransitionUtilities.StartTransition(SceneType.LoadFullAutosave);
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SLeavePracticeView_40 = GetEntityQuery(ComponentType.ReadOnly<SLeavePracticeView>());
		}
	}
}
