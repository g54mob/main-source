using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class UpdateQueuePatience : GameSystemBase
	{
		public struct CQueuePatienceBoost : IComponentData
		{
			public float Seconds;
		}

		private EntityQuery Tables;

		private EntityQuery Players;

		private EntityQuery Boosts;

		private EntityQuery Queuers;

		private EntityQuery SPopUps;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SQueueMarker_5;

		protected override void Initialise()
		{
			base.Initialise();
			Tables = GetEntityQuery(typeof(CTableSetModifier));
			Players = GetEntityQuery(typeof(CPlayer));
			Boosts = GetEntityQuery(typeof(CQueuePatienceBoost));
			Queuers = GetEntityQuery(typeof(CQueuePosition));
			SPopUps = GetEntityQuery(typeof(RestartDayPopup.SPopup));
		}

		protected override void OnUpdate()
		{
			if (Has<SCheatNoPatienceDecrease>() || !SPopUps.IsEmpty)
			{
				return;
			}
			bool flag = HasStatus(RestaurantStatus.NoQueueReset);
			NativeArray<CQueuePatienceBoost> nativeArray = Boosts.ToComponentDataArray<CQueuePatienceBoost>(Allocator.Temp);
			float num = 0f;
			foreach (CQueuePatienceBoost item in nativeArray)
			{
				num += item.Seconds;
			}
			nativeArray.Dispose();
			base.EntityManager.DestroyEntity(Boosts);
			int num2 = Queuers.CalculateEntityCount();
			float num3 = Mathf.Min(5f, Mathf.Pow(1.1f, num2));
			float num4 = DifficultyHelpers.PatiencePlayerCountModifier(Players.CalculateEntityCount());
			float num5 = (HasStatus(RestaurantStatus.HasQueuePatienceBoost) ? 0.75f : 1f);
			Entity singletonEntity = _SingletonEntityQuery_SQueueMarker_5.GetSingletonEntity();
			DynamicBuffer<CQueue> buffer = GetBuffer<CQueue>(singletonEntity);
			bool flag2 = false;
			Vector3 frontDoor = GetFrontDoor(get_external_tile: true);
			foreach (CQueue item2 in buffer)
			{
				if (Require<CPosition>(item2.Member, out CPosition comp) && (comp - frontDoor).Chebyshev() < 3f)
				{
					flag2 = true;
					break;
				}
			}
			Factor factor = 0f;
			if (RequireBuffer(singletonEntity, out DynamicBuffer<CAffectedBy> comp2))
			{
				foreach (CAffectedBy item3 in comp2)
				{
					if (Require<CQueueModifier>((Entity)item3, out CQueueModifier comp3))
					{
						factor += comp3.PatienceFactor;
					}
				}
			}
			CPatience component = GetComponent<CPatience>(singletonEntity);
			if (component.Active)
			{
				if (!flag2)
				{
					if (!flag)
					{
						component = new CPatience(PatienceReason.Queue);
					}
				}
				else
				{
					float num6 = base.Time.DeltaTime - num;
					float num7 = ((!HasSingleton<SWeatherDarkness>()) ? 1 : 2);
					float num8 = num7;
					num7 = num8 * GetWeather() switch
					{
						WeatherMode.None => 1f, 
						WeatherMode.Rain => 1.5f, 
						WeatherMode.Snow => 2f, 
						_ => 1f, 
					};
					num7 *= num5;
					num7 /= GameData.Main.Difficulty.QueuePatienceTime;
					component.RemainingTime -= num6 * num7 * num4 * num3 / factor;
				}
			}
			else if (flag2)
			{
				if (!flag || component.StartTime == 0f)
				{
					CPatience cPatience = new CPatience(PatienceReason.Queue);
					cPatience.Active = true;
					component = cPatience;
				}
				else
				{
					component.Active = true;
				}
			}
			if (component.RemainingTime < 0f)
			{
				component = new CPatience(PatienceReason.Queue);
				base.EntityManager.CreateEntity(typeof(CLoseLifeEvent));
			}
			SetComponent(singletonEntity, component);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SQueueMarker_5 = GetEntityQuery(ComponentType.ReadOnly<SQueueMarker>());
		}
	}
}
