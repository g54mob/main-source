using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class CreateGarage : FranchiseFirstFrameSystem
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
			Create(GameData.Main.Get<Appliance>(AssetReference.GarageDecorations), LobbyPositionAnchors.Garage, Vector3.forward);
			Entity entity = default(Entity);
			entity = Create(GameData.Main.Get<Appliance>(AssetReference.LoadoutPedestal), LobbyPositionAnchors.Garage + new Vector3(-0.5f, 0f, -2f), Vector3.right);
			base.EntityManager.AddComponent<CItemPedestal>(entity);
			entity = Create(GameData.Main.Get<Appliance>(AssetReference.LoadoutPedestal), LobbyPositionAnchors.Garage + new Vector3(-1.5f, 0f, -2f), Vector3.right);
			base.EntityManager.AddComponent<CItemPedestal>(entity);
			if (Upgrades.IsEmpty && Crates.IsEmpty)
			{
				return;
			}
			for (int i = 0; i < 6; i++)
			{
				if (i == 2)
				{
					continue;
				}
				for (int j = 0; j < 7; j++)
				{
					Vector3 facing = ((j % 2 == 1) ? Vector3.forward : Vector3.back);
					Entity entity2 = Create(GameData.Main.Get<Appliance>(AssetReference.GarageShelf), LobbyPositionAnchors.Garage + new Vector3(3 - i, 0f, 5 - j), facing);
					base.EntityManager.AddComponentData(entity2, new CPersistentItemStorageLocation
					{
						Type = PersistentStorageType.Crate
					});
					if (j % 2 == 1)
					{
						Entity entity3 = Create(GameData.Main.Get<Appliance>(AssetReference.GarageDivider), LobbyPositionAnchors.Garage + new Vector3(3 - i, 0f, 5 - j), Vector3.forward);
						base.EntityManager.AddComponent<CDoesNotOccupy>(entity3);
					}
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
