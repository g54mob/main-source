using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(EndOfFrameGroup), OrderFirst = true)]
	public class ManageTransitions : GenericSystemBase
	{
		public struct STransitionPopup : IComponentData
		{
			public bool IsComplete;
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct CTransitionStageMarker : IComponentData
		{
		}

		private EntityQuery StageMarkers;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SPerformSceneTransition_1;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_STransitionPopup_2;

		private EntityQuery _SingletonEntityQuery_SCurrentScene_3;

		private EntityQuery _SingletonEntityQuery_SPerformSceneTransition_4;

		protected override void Initialise()
		{
			base.Initialise();
			StageMarkers = GetEntityQuery(typeof(CTransitionStageMarker));
		}

		protected override void OnUpdate()
		{
			if (TryGetSingletonEntity<STransitionPopup>(out var value))
			{
				if (Require<CDeleteTransitionAfterFrames>(value, out CDeleteTransitionAfterFrames comp))
				{
					if (comp.Frames > 0)
					{
						comp.Frames--;
						Set(value, comp);
					}
					else
					{
						base.EntityManager.DestroyEntity(value);
					}
				}
				else if (!HasSingleton<SPerformSceneTransition>())
				{
					base.EntityManager.DestroyEntity(value);
				}
			}
			if (!HasSingleton<SPerformSceneTransition>())
			{
				return;
			}
			SPerformSceneTransition singleton = _SingletonEntityQuery_SPerformSceneTransition_1.GetSingleton<SPerformSceneTransition>();
			Entity singletonEntity = _SingletonEntityQuery_SPerformSceneTransition_1.GetSingletonEntity();
			SceneType type = ((singleton.NextScene == SceneType.LoadFullAutosave) ? SceneType.Kitchen : singleton.NextScene);
			base.EntityManager.DestroyEntity(StageMarkers);
			if (!singleton.StageComplete && singleton.Stage != TransitionStage.Request)
			{
				return;
			}
			singleton.StageComplete = false;
			switch (singleton.Stage)
			{
			case TransitionStage.Request:
				if (!HasSingleton<STransitionPopup>())
				{
					CreatePopup();
					return;
				}
				if (!_SingletonEntityQuery_STransitionPopup_2.GetSingleton<STransitionPopup>().IsComplete)
				{
					return;
				}
				Set(_SingletonEntityQuery_STransitionPopup_2.GetSingletonEntity(), new CDeleteTransitionAfterFrames
				{
					Frames = 5
				});
				base.EntityManager.CreateEntity(typeof(SClearScene), typeof(CTransitionStageMarker));
				singleton.Stage = TransitionStage.Clear;
				break;
			case TransitionStage.Clear:
			{
				Entity entity = base.EntityManager.CreateEntity(typeof(SCreateScene), typeof(CTransitionStageMarker));
				base.EntityManager.SetComponentData(entity, new SCreateScene
				{
					Type = singleton.NextScene
				});
				singleton.Stage = TransitionStage.Create;
				break;
			}
			case TransitionStage.Create:
			case TransitionStage.Complete:
				if (!HasSingleton<SCurrentScene>())
				{
					base.World.Add<SCurrentScene>();
				}
				_SingletonEntityQuery_SCurrentScene_3.SetSingleton(new SCurrentScene
				{
					Type = type
				});
				base.EntityManager.CreateEntity(typeof(CSceneFirstFrame));
				base.EntityManager.DestroyEntity(singletonEntity);
				return;
			}
			_SingletonEntityQuery_SPerformSceneTransition_4.SetSingleton(singleton);
		}

		protected void CreatePopup()
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(CRequiresView), typeof(STransitionPopup), typeof(CPosition), typeof(CPersistThroughSceneChanges));
			base.EntityManager.SetComponentData(entity, new CRequiresView
			{
				Type = ViewType.TransitionPopup,
				ViewMode = ViewMode.Screen
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SPerformSceneTransition_1 = GetEntityQuery(ComponentType.ReadOnly<SPerformSceneTransition>());
			_SingletonEntityQuery_STransitionPopup_2 = GetEntityQuery(ComponentType.ReadOnly<STransitionPopup>());
			_SingletonEntityQuery_SCurrentScene_3 = GetEntityQuery(ComponentType.ReadWrite<SCurrentScene>());
			_SingletonEntityQuery_SPerformSceneTransition_4 = GetEntityQuery(ComponentType.ReadWrite<SPerformSceneTransition>());
		}
	}
}
