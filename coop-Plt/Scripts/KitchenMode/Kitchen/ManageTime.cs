using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(GameTransitionsCreateGroup))]
	public class ManageTime : GameSystemBase
	{
		private EntityQuery _SingletonEntityQuery_STime_20;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SDay_21;

		private EntityQuery _SingletonEntityQuery_SDay_22;

		protected override void OnUpdate()
		{
			if (!HasSingleton<STime>())
			{
				base.EntityManager.CreateEntity(typeof(STime));
				_SingletonEntityQuery_STime_20.SetSingleton(new STime
				{
					DayLength = ProgressionHelpers.GetDayLength(0)
				});
			}
			if (!HasSingleton<SDay>())
			{
				base.EntityManager.CreateEntity(typeof(SDay));
			}
			if (_SingletonEntityQuery_SDay_21.GetSingleton<SDay>().Day == 0 && HasStatus(RestaurantStatus.StartWithDay4))
			{
				_SingletonEntityQuery_SDay_22.SetSingleton(new SDay
				{
					Day = 3
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_STime_20 = GetEntityQuery(ComponentType.ReadWrite<STime>());
			_SingletonEntityQuery_SDay_21 = GetEntityQuery(ComponentType.ReadOnly<SDay>());
			_SingletonEntityQuery_SDay_22 = GetEntityQuery(ComponentType.ReadWrite<SDay>());
		}
	}
}
