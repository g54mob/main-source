using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class ReturnToFranchise : GameOverSystem
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SGameOver_35;

		protected override void OnUpdate()
		{
			new EntityContext(base.EntityManager);
			StartSceneTransition(SceneType.Postgame);
			if (!HasSingleton<SGameLossReason>())
			{
				Entity entity = base.EntityManager.CreateEntity(typeof(SGameLossReason), typeof(CSceneChangeData));
				base.EntityManager.SetComponentData(entity, new SGameLossReason
				{
					Reason = _SingletonEntityQuery_SGameOver_35.GetSingleton<SGameOver>().Reason
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SGameOver_35 = GetEntityQuery(ComponentType.ReadOnly<SGameOver>());
		}
	}
}
