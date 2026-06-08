using System.Collections.Generic;
using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class EnsureBasicUpgrades : GenericSystemBase
	{
		private EntityQuery Upgrades;

		private List<int> BasicUpgrades = new List<int>
		{
			AssetReference.DishSteak,
			AssetReference.LayoutBasic,
			AssetReference.DefaultSetting
		};

		protected override void Initialise()
		{
			Upgrades = GetEntityQuery(typeof(CUpgrade));
		}

		protected override void OnUpdate()
		{
			NativeArray<CUpgrade> existing = Upgrades.ToComponentDataArray<CUpgrade>(Allocator.Temp);
			foreach (int basicUpgrade in BasicUpgrades)
			{
				EnsureUpgrade(basicUpgrade, existing);
			}
			existing.Dispose();
		}

		protected void EnsureUpgrade(int new_id, NativeArray<CUpgrade> existing)
		{
			foreach (CUpgrade item in existing)
			{
				if (item.ID == new_id)
				{
					return;
				}
			}
			Entity entity = base.EntityManager.CreateEntity(typeof(CUpgrade), typeof(CPersistThroughSceneChanges));
			base.EntityManager.AddComponentData(entity, new CUpgrade
			{
				ID = new_id
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
