using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class ProvideTreatMoney : RestaurantSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct SProvided : IComponentData
		{
		}

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SMoney_57;

		private EntityQuery _SingletonEntityQuery_SMoney_58;

		protected override void OnUpdate()
		{
			if (!HasSingleton<SProvided>() && HasStatus(RestaurantStatus.HalloweenTreatFreeMoney) && HasSingleton<SMoney>())
			{
				SMoney singleton = _SingletonEntityQuery_SMoney_57.GetSingleton<SMoney>();
				_SingletonEntityQuery_SMoney_58.SetSingleton(new SMoney
				{
					Amount = (int)singleton + 250
				});
				base.World.Add<SProvided>();
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SMoney_57 = GetEntityQuery(ComponentType.ReadOnly<SMoney>());
			_SingletonEntityQuery_SMoney_58 = GetEntityQuery(ComponentType.ReadWrite<SMoney>());
		}
	}
}
