using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class HandlePostgameQuitEvent : PostgameSystemBase
	{
		private EntityQuery Quits;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SEndgameStats_16;

		protected override void Initialise()
		{
			base.Initialise();
			Quits = GetEntityQuery(typeof(CRequestQuitEvent));
			RequireForUpdate(Quits);
		}

		protected override void OnUpdate()
		{
			base.EntityManager.DestroyEntity(Quits);
			Set<DeleteSave.SApplyEndOfGameActions>();
			if (!_SingletonEntityQuery_SEndgameStats_16.GetSingleton<SEndgameStats>().IsFranchiseCreation)
			{
				StartSceneTransition(SceneType.Franchise);
				return;
			}
			base.EntityManager.AddComponent<CSceneChangeData>(_SingletonEntityQuery_SEndgameStats_16.GetSingletonEntity());
			StartSceneTransition(SceneType.FranchiseBuilder);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SEndgameStats_16 = GetEntityQuery(ComponentType.ReadOnly<SEndgameStats>());
		}
	}
}
