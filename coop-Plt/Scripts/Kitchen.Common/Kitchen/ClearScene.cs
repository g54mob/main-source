using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(GameTransitionsCleanupGroup))]
	public class ClearScene : GenericSystemBase
	{
		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SClearScene>();
		}

		protected override void OnUpdate()
		{
			base.EntityManager.DestroyEntity(GetEntityQuery(new EntityQueryDesc
			{
				None = new ComponentType[3]
				{
					typeof(CPersistThroughSceneChanges),
					typeof(CSceneChangeData),
					typeof(SPerformSceneTransition)
				}
			}));
			base.EntityManager.RemoveComponent(GetEntityQuery(typeof(CSceneChangeData)), typeof(CSceneChangeData));
			MarkTransitionStageCompleted();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
