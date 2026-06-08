using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class ManageDarknessWeather : RestaurantSystem
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_STime_11;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SWeatherDarkness_12;

		protected override void OnUpdate()
		{
			STime singleton = _SingletonEntityQuery_STime_11.GetSingleton<STime>();
			bool flag = false;
			if (RequireEntity<SLayout>(out var comp) && Require<CSetting>(comp, out CSetting comp2) && GameData.Main.TryGet<RestaurantSetting>(comp2.RestaurantSetting, out var output))
			{
				flag = output.AlwaysLight;
			}
			if ((double)singleton.TimeOfDay > 0.75 && !flag)
			{
				if (!HasSingleton<SWeatherDarkness>())
				{
					base.EntityManager.CreateEntity(typeof(SWeatherDarkness));
				}
			}
			else if (HasSingleton<SWeatherDarkness>())
			{
				base.EntityManager.DestroyEntity(_SingletonEntityQuery_SWeatherDarkness_12.GetSingletonEntity());
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_STime_11 = GetEntityQuery(ComponentType.ReadOnly<STime>());
			_SingletonEntityQuery_SWeatherDarkness_12 = GetEntityQuery(ComponentType.ReadOnly<SWeatherDarkness>());
		}
	}
}
