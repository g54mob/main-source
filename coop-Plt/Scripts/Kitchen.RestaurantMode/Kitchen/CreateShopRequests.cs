using System;
using Kitchen.ShopBuilder;
using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(EndOfDayProgressionGroup), OrderFirst = true)]
	public class CreateShopRequests : StartOfNightSystem
	{
		private EntityQuery ShopRemover;

		private EntityQuery ShopOptions;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SDay_51;

		protected override void Initialise()
		{
			base.Initialise();
			ShopRemover = GetEntityQuery(typeof(CRemovesShopBlueprint));
			ShopOptions = GetEntityQuery(typeof(CShopBuilderOption));
		}

		protected override void OnUpdate()
		{
			if (HasSingleton<SIsRestartedDay>())
			{
				return;
			}
			int day = _SingletonEntityQuery_SDay_51.GetSingleton<SDay>().Day;
			if (day > 0 && day % 5 == 0)
			{
				for (int i = 0; i < 8; i++)
				{
					AddShop(ShoppingTags.Decoration);
				}
				for (int j = 0; j < 2; j++)
				{
					AddShop(ShoppingTags.SpecialEvent);
				}
				for (int k = 0; k < 6; k++)
				{
					AddDecorShop();
				}
				return;
			}
			int num = 0;
			using NativeArray<CRemovesShopBlueprint> nativeArray = ShopRemover.ToComponentDataArray<CRemovesShopBlueprint>(Allocator.Temp);
			foreach (CRemovesShopBlueprint item in nativeArray)
			{
				num += item.Count;
			}
			ShoppingTags defaultShoppingTag = ShoppingTagsExtensions.DefaultShoppingTag;
			using NativeArray<CShopBuilderOption> nativeArray2 = ShopOptions.ToComponentDataArray<CShopBuilderOption>(Allocator.Temp);
			int num2 = 0;
			foreach (CShopBuilderOption item2 in nativeArray2)
			{
				if (item2.TakesStapleSlot)
				{
					num2++;
				}
			}
			int num3 = Math.Max(1, DifficultyHelpers.TotalShopCount(day) - num);
			int num4 = Math.Max(0, Math.Min(DifficultyHelpers.StapleCount(day), num3));
			if (num4 > num2)
			{
				num4 = num2;
			}
			int num5 = Math.Max(0, num3 - num4);
			for (int l = 0; l < num4; l++)
			{
				AddShop(ShoppingTags.Basic);
			}
			for (int m = 0; m < num5; m++)
			{
				AddShop(defaultShoppingTag);
			}
		}

		private void AddShop(ShoppingTags tags)
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(CNewShop));
			base.EntityManager.AddComponentData(entity, new CNewShop
			{
				Tags = tags
			});
		}

		private void AddDecorShop()
		{
			base.EntityManager.CreateEntity(typeof(CNewDecorShop));
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SDay_51 = GetEntityQuery(ComponentType.ReadOnly<SDay>());
		}
	}
}
