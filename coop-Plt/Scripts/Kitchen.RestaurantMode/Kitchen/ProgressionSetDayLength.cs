using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(EndOfDayProgressionGroup))]
	public class ProgressionSetDayLength : StartOfNightSystem
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SDay_43;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_STime_44;

		private EntityQuery _SingletonEntityQuery_STime_45;

		protected override void OnUpdate()
		{
			int day = _SingletonEntityQuery_SDay_43.GetSingleton<SDay>().Day;
			STime singleton = _SingletonEntityQuery_STime_44.GetSingleton<STime>();
			singleton.DayLength = ProgressionHelpers.GetDayLength(day);
			if (HasStatus(RestaurantStatus.PreparationTime))
			{
				singleton.DayLength *= 1.2f;
			}
			_SingletonEntityQuery_STime_45.SetSingleton(singleton);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SDay_43 = GetEntityQuery(ComponentType.ReadOnly<SDay>());
			_SingletonEntityQuery_STime_44 = GetEntityQuery(ComponentType.ReadOnly<STime>());
			_SingletonEntityQuery_STime_45 = GetEntityQuery(ComponentType.ReadWrite<STime>());
		}
	}
}
