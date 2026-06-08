using Unity.Entities;

namespace Kitchen
{
	public class TransitionUtilities : Kitchen.Utility
	{
		public Entity StartTransition(SceneType next_scene_type)
		{
			if (HasSingleton<SPerformSceneTransition>())
			{
				return default(Entity);
			}
			Entity entity = base.EntityManager.CreateEntity(typeof(SPerformSceneTransition), typeof(CDoNotPersist));
			base.EntityManager.SetComponentData(entity, new SPerformSceneTransition
			{
				NextScene = next_scene_type
			});
			return entity;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
