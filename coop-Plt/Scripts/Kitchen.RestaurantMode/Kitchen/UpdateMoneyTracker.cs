using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class UpdateMoneyTracker : StartOfDaySystem
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SMoney_6;

		private EntityQuery _SingletonEntityQuery_SMoneyEarningsTracker_7;

		protected override void OnUpdate()
		{
			if (!HasSingleton<SMoneyEarningsTracker>())
			{
				base.EntityManager.CreateEntity(typeof(SMoneyEarningsTracker));
			}
			int amount = _SingletonEntityQuery_SMoney_6.GetSingleton<SMoney>().Amount;
			_SingletonEntityQuery_SMoneyEarningsTracker_7.SetSingleton(new SMoneyEarningsTracker
			{
				OldAmount = amount
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SMoney_6 = GetEntityQuery(ComponentType.ReadOnly<SMoney>());
			_SingletonEntityQuery_SMoneyEarningsTracker_7 = GetEntityQuery(ComponentType.ReadWrite<SMoneyEarningsTracker>());
		}
	}
}
