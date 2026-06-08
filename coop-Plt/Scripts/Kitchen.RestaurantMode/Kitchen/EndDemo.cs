using Platforms;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class EndDemo : RestaurantSystem
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SDay_34;

		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SDay>();
		}

		protected override void OnUpdate()
		{
			if (PlatformSettings.IsDemoMode && !HasSingleton<SGameOver>() && _SingletonEntityQuery_SDay_34.GetSingleton<SDay>().Day >= 7)
			{
				Entity entity = base.EntityManager.CreateEntity(typeof(SGameOver));
				base.EntityManager.SetComponentData(entity, new SGameOver
				{
					Reason = LossReason.Demo
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SDay_34 = GetEntityQuery(ComponentType.ReadOnly<SDay>());
		}
	}
}
