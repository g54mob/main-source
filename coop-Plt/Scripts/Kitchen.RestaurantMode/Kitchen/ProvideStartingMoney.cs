using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class ProvideStartingMoney : RestaurantSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct SProvided : IComponentData
		{
		}

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SMoney_32;

		private EntityQuery _SingletonEntityQuery_SMoney_33;

		protected override void OnUpdate()
		{
			if (!HasSingleton<SProvided>() && HasStatus(RestaurantStatus.FreeMoneyOnStart) && HasSingleton<SMoney>())
			{
				SMoney singleton = _SingletonEntityQuery_SMoney_32.GetSingleton<SMoney>();
				_SingletonEntityQuery_SMoney_33.SetSingleton(new SMoney
				{
					Amount = (int)singleton + 50
				});
				base.World.Add<SProvided>();
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SMoney_32 = GetEntityQuery(ComponentType.ReadOnly<SMoney>());
			_SingletonEntityQuery_SMoney_33 = GetEntityQuery(ComponentType.ReadWrite<SMoney>());
		}
	}
}
