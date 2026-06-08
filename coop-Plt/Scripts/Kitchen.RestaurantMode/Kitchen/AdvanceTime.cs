using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(TimeManagementGroup))]
	public class AdvanceTime : RestaurantSystem
	{
		private EntityQuery CustomerGroups;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_STime_1;

		private EntityQuery _SingletonEntityQuery_STime_2;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SIsDayTime_3;

		protected override void Initialise()
		{
			base.Initialise();
			CustomerGroups = GetEntityQuery(typeof(CCustomerGroup));
		}

		protected override void OnUpdate()
		{
			base.EntityManager.DestroyEntity(GetEntityQuery(typeof(SIsRestartedDay)));
			base.EntityManager.DestroyEntity(GetEntityQuery(typeof(SIsNightFirstUpdate)));
			base.EntityManager.DestroyEntity(GetEntityQuery(typeof(SIsDayFirstUpdate)));
			if (!Has<SGameOver>() && !Has<SPracticeMode>())
			{
				STime singleton = _SingletonEntityQuery_STime_1.GetSingleton<STime>();
				float dayLength = singleton.DayLength;
				if (!singleton.ForcePause && Has<SIsDayTime>())
				{
					singleton.TimeOfDayUnbounded += base.Time.DeltaTime / dayLength;
					singleton.SecondsSinceDayBegan += base.Time.DeltaTime;
				}
				singleton.TimeOfDay = Mathf.Clamp01(singleton.TimeOfDayUnbounded);
				if ((singleton.TimeOfDayUnbounded >= 1f && CustomerGroups.IsEmpty) || (Has<SIsDebugSpeedrun>() && Has<SIsDayTime>()))
				{
					singleton = new STime
					{
						DayLength = dayLength
					};
					BecomeNight();
				}
				_SingletonEntityQuery_STime_2.SetSingleton(singleton);
			}
		}

		protected void BecomeNight()
		{
			base.EntityManager.CreateEntity(typeof(SIsNightFirstUpdate));
			if (!HasSingleton<SIsNightTime>())
			{
				base.EntityManager.CreateEntity(typeof(SIsNightTime));
			}
			if (HasSingleton<SIsDayTime>())
			{
				base.EntityManager.RemoveComponent<SIsDayTime>(_SingletonEntityQuery_SIsDayTime_3.GetSingletonEntity());
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_STime_1 = GetEntityQuery(ComponentType.ReadOnly<STime>());
			_SingletonEntityQuery_STime_2 = GetEntityQuery(ComponentType.ReadWrite<STime>());
			_SingletonEntityQuery_SIsDayTime_3 = GetEntityQuery(ComponentType.ReadOnly<SIsDayTime>());
		}
	}
}
