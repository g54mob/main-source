using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public abstract class GameSystemBase : GenericSystemBase
	{
		protected EntityArchetype DefaultArchetype;

		private EntityQuery _SingletonEntityQuery_SGlobalStatusList_13;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SWeatherPrecipitation_14;

		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SGameplayMarker>();
			DefaultArchetype = base.EntityManager.CreateArchetype();
		}

		public void UnlockIngredient(int menu_item, int ingredient)
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(CAvailableIngredient));
			base.EntityManager.SetComponentData(entity, new CAvailableIngredient(menu_item, ingredient));
		}

		public void AddPossibleExtra(int menu_item, int ingredient)
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(CPossibleExtra));
			base.EntityManager.SetComponentData(entity, new CPossibleExtra(menu_item, ingredient));
		}

		public void UnlockIngredient(Dish.IngredientUnlock unlock)
		{
			UnlockIngredient(unlock.MenuItem.ID, unlock.Ingredient.ID);
		}

		protected void SetDecorationValue(DecorationType theme, int set_to_value)
		{
			Entity entity = GetEntity<SGlobalStatusList>();
			if (!base.EntityManager.HasComponent<CDecorationScore>(entity))
			{
				base.EntityManager.AddBuffer<CDecorationScore>(entity);
			}
			DynamicBuffer<CDecorationScore> buffer = GetBuffer<CDecorationScore>(entity);
			for (int i = 0; i < buffer.Length; i++)
			{
				if ((DecorationType)buffer[i] == theme)
				{
					buffer[i] = new CDecorationScore
					{
						Theme = theme,
						Value = set_to_value
					};
					break;
				}
			}
		}

		protected int GetDecorationValue(DecorationType theme)
		{
			Entity entity = GetEntity<SGlobalStatusList>();
			if (!base.EntityManager.HasComponent<CDecorationScore>(entity))
			{
				base.EntityManager.AddBuffer<CDecorationScore>(entity);
			}
			DynamicBuffer<CDecorationScore> buffer = GetBuffer<CDecorationScore>(entity);
			for (int i = 0; i < buffer.Length; i++)
			{
				CDecorationScore cDecorationScore = buffer[i];
				if ((DecorationType)cDecorationScore == theme)
				{
					return cDecorationScore;
				}
			}
			return 0;
		}

		protected DynamicBuffer<CDecorationScore> GetDecorationValue()
		{
			Entity entity = GetEntity<SGlobalStatusList>();
			if (!base.EntityManager.HasComponent<CDecorationScore>(entity))
			{
				base.EntityManager.AddBuffer<CDecorationScore>(entity);
			}
			return GetBuffer<CDecorationScore>(entity);
		}

		protected void SetTheme(DecorationType theme)
		{
			SGlobalStatusList orCreate = GetOrCreate<SGlobalStatusList>();
			orCreate.Theme |= theme;
			_SingletonEntityQuery_SGlobalStatusList_13.SetSingleton(orCreate);
		}

		protected void AddStatus(RestaurantStatus status)
		{
			SGlobalStatusList orCreate = GetOrCreate<SGlobalStatusList>();
			orCreate.Add(status);
			_SingletonEntityQuery_SGlobalStatusList_13.SetSingleton(orCreate);
		}

		protected void RemoveStatus(RestaurantStatus status)
		{
			SGlobalStatusList orCreate = GetOrCreate<SGlobalStatusList>();
			orCreate.Remove(status);
			_SingletonEntityQuery_SGlobalStatusList_13.SetSingleton(orCreate);
		}

		protected void SetStatus(RestaurantStatus status, bool active)
		{
			if (active)
			{
				AddStatus(status);
			}
			else
			{
				RemoveStatus(status);
			}
		}

		protected bool HasStatus(RestaurantStatus status)
		{
			return GetOrCreate<SGlobalStatusList>().Has(status);
		}

		protected WeatherMode GetWeather()
		{
			if (HasSingleton<SWeatherPrecipitation>())
			{
				SWeatherPrecipitation singleton = _SingletonEntityQuery_SWeatherPrecipitation_14.GetSingleton<SWeatherPrecipitation>();
				if (singleton.IsActive)
				{
					return singleton.Mode;
				}
			}
			return WeatherMode.None;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SGlobalStatusList_13 = GetEntityQuery(ComponentType.ReadWrite<SGlobalStatusList>());
			_SingletonEntityQuery_SWeatherPrecipitation_14 = GetEntityQuery(ComponentType.ReadOnly<SWeatherPrecipitation>());
		}
	}
}
