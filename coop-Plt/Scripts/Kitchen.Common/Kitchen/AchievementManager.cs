using Unity.Entities;

namespace Kitchen
{
	public abstract class AchievementManager : GenericSystemBase, IAchievementSystem
	{
		private float LastAchieveTime;

		protected abstract string Identifier { get; }

		protected bool IsUnlocked => Achievements.Has(Identifier);

		protected virtual bool SkipRateLimit => false;

		protected void Unlock(string id = null)
		{
			if (id == null)
			{
				id = Identifier;
			}
			if (SkipRateLimit || !(LastAchieveTime > base.Time.TotalTime - 20f))
			{
				LastAchieveTime = base.Time.TotalTime;
				Entity entity = base.EntityManager.CreateEntity(typeof(CRequiresView), typeof(CPosition), typeof(CAchievementUnlockEvent));
				base.EntityManager.SetComponentData(entity, new CRequiresView
				{
					Type = ViewType.AchievementEvent
				});
				base.EntityManager.SetComponentData(entity, new CAchievementUnlockEvent
				{
					Name = id
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
	public abstract class AchievementManager<T> : AchievementManager where T : struct, IComponentData
	{
		protected T GetData()
		{
			return GetOrCreate<T>();
		}

		protected void SetData(T data)
		{
			Set(data);
		}

		protected abstract void HandleUpdate(ref T data);

		protected override void OnUpdate()
		{
			T data = GetData();
			HandleUpdate(ref data);
			SetData(data);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
