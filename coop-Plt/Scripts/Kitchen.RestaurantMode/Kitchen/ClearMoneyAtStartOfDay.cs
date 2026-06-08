using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class ClearMoneyAtStartOfDay : StartOfDaySystem
	{
		private EntityQuery _SingletonEntityQuery_SMoney_5;

		protected override void OnUpdate()
		{
			if (HasStatus(RestaurantStatus.ClearMoneyAtStartOfDay))
			{
				_SingletonEntityQuery_SMoney_5.SetSingleton(default(SMoney));
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SMoney_5 = GetEntityQuery(ComponentType.ReadWrite<SMoney>());
		}
	}
}
