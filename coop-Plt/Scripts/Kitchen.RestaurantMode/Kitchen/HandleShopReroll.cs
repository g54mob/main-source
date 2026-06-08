using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class HandleShopReroll : GameSystemBase
	{
		private EntityQuery Requests;

		private EntityQuery Blueprints;

		protected override void Initialise()
		{
			base.Initialise();
			Requests = GetEntityQuery(typeof(CShopRerollRequest));
			Blueprints = GetEntityQuery(new QueryHelper().Any(typeof(CLetterBlueprint), typeof(CApplianceBlueprint)));
		}

		protected override void OnUpdate()
		{
			if (Requests.IsEmpty)
			{
				return;
			}
			base.EntityManager.DestroyEntity(Requests);
			ShoppingTags tags = ((GetOrDefault<SDay>().Day % 5 != 0) ? ShoppingTagsExtensions.DefaultShoppingTag : ShoppingTags.Decoration);
			using NativeArray<Entity> nativeArray = Blueprints.ToEntityArray(Allocator.Temp);
			foreach (Entity item in nativeArray)
			{
				if ((Require<CHeldBy>(item, out CHeldBy comp) && Has<CPlayer>(comp)) || !Require<CPosition>(item, out CPosition comp2))
				{
					CreateShop(fixed_location: false, default(Vector3), tags);
				}
				else
				{
					CreateShop(fixed_location: true, comp2, tags);
				}
				base.EntityManager.DestroyEntity(item);
			}
		}

		private void CreateShop(bool fixed_location, Vector3 location, ShoppingTags tags)
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(CNewShop));
			base.EntityManager.AddComponentData(entity, new CNewShop
			{
				Tags = tags,
				Location = location,
				FixedLocation = fixed_location,
				StartOpen = true
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
