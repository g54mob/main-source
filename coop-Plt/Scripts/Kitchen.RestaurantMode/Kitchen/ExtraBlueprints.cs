using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(EndOfDayProgressionGroup), OrderFirst = true)]
	public class ExtraBlueprints : StartOfNightSystem
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SDay_56;

		protected override void OnUpdate()
		{
			if (HasStatus(RestaurantStatus.HalloweenTreatExtraBlueprints) && !HasSingleton<SIsRestartedDay>() && _SingletonEntityQuery_SDay_56.GetSingleton<SDay>().Day > 0)
			{
				for (int i = 0; i < 3; i++)
				{
					Entity entity = base.EntityManager.CreateEntity(typeof(CNewShop));
					base.EntityManager.AddComponentData(entity, new CNewShop
					{
						Tags = ShoppingTagsExtensions.DefaultShoppingTag
					});
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SDay_56 = GetEntityQuery(ComponentType.ReadOnly<SDay>());
		}
	}
}
