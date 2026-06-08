using Unity.Entities;

namespace Kitchen
{
	public class RequestTableUpdateAtNight : NightSystem
	{
		private EntityQuery _SingletonEntityQuery_SPerformTableUpdate_64;

		protected override void OnUpdate()
		{
			if (!HasSingleton<SPerformTableUpdate>())
			{
				base.EntityManager.CreateEntity(typeof(SPerformTableUpdate));
			}
			bool flag = HasSingleton<SIsNightFirstUpdate>();
			bool flag2 = HasSingleton<CreateNewKitchen.SKitchenFirstFrame>();
			SPerformTableUpdate singleton = new SPerformTableUpdate
			{
				EnforcePaths = true,
				ReplaceWithDisabledGhosts = (flag && !flag2),
				PathingSource = SPerformTableUpdate.DefaultPathingSource
			};
			_SingletonEntityQuery_SPerformTableUpdate_64.SetSingleton(singleton);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SPerformTableUpdate_64 = GetEntityQuery(ComponentType.ReadWrite<SPerformTableUpdate>());
		}
	}
}
