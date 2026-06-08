using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class CreatePermanentGarageUpgrade : FranchiseSystem
	{
		private EntityQuery Crates;

		private EntityQuery Upgrades;

		protected override void Initialise()
		{
			base.Initialise();
			Crates = GetEntityQuery(typeof(CCrateAppliance));
			Upgrades = GetEntityQuery(typeof(CUpgradeHasGarage));
		}

		protected override void OnUpdate()
		{
			if (!Crates.IsEmpty && Upgrades.IsEmpty)
			{
				Entity entity = base.EntityManager.CreateEntity(typeof(CUpgrade), typeof(CPersistThroughSceneChanges));
				base.EntityManager.AddComponentData(entity, new CUpgrade
				{
					ID = AssetReference.PermanentGarageUpgrade
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
