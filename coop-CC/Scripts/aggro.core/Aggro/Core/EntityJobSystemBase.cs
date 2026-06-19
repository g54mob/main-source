using Unity.Jobs;

namespace Aggro.Core
{
	public abstract class EntityJobSystemBase : EntitySystemBase
	{
		protected sealed override void OnUpdateSystem()
		{
			base.entityManager.dependency = OnUpdateJobSystem(base.entityManager.dependency);
		}

		protected abstract JobHandle OnUpdateJobSystem(JobHandle dependency);
	}
}
