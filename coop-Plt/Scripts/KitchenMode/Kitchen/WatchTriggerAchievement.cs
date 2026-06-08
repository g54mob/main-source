using Unity.Entities;

namespace Kitchen
{
	public abstract class WatchTriggerAchievement<T> : AchievementManager where T : struct, IComponentData
	{
		public virtual bool ClearFlag { get; } = true;

		protected override void OnUpdate()
		{
			if (Has<T>())
			{
				Unlock();
				if (ClearFlag)
				{
					Clear<T>();
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
