using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(TableUpdatesGroup), OrderFirst = true)]
	public class ResetTableWarning : RestaurantTableUpdateSystem
	{
		private EntityQuery _SingletonEntityQuery_SStartDayWarnings_65;

		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SStartDayWarnings>();
		}

		protected override void OnUpdate()
		{
			_SingletonEntityQuery_SStartDayWarnings_65.SetSingleton(SStartDayWarnings.Unknown);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SStartDayWarnings_65 = GetEntityQuery(ComponentType.ReadWrite<SStartDayWarnings>());
		}
	}
}
