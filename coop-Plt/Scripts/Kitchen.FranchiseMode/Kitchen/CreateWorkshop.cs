using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class CreateWorkshop : FranchiseFirstFrameSystem
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
			if (Crates.IsEmpty && Upgrades.IsEmpty)
			{
				Create(GameData.Main.Get<Appliance>(AssetReference.WorkshopLock), LobbyPositionAnchors.Workshop + new Vector3(-2.5f, 0f, 1f), Vector3.forward);
				return;
			}
			Create(AssetReference.WorkshopWall, LobbyPositionAnchors.Workshop + new Vector3(0f, 0f, 0.5f), Vector3.forward);
			Create(AssetReference.WorkshopWall, LobbyPositionAnchors.Workshop + new Vector3(-1f, 0f, 0.5f), Vector3.forward);
			Create(AssetReference.WorkshopGate, LobbyPositionAnchors.Workshop + new Vector3(-2f, 0f, 0.5f), Vector3.forward);
			Create(AssetReference.WorkshopWall, LobbyPositionAnchors.Workshop + new Vector3(-3f, 0f, 0.5f), Vector3.forward);
			Create(AssetReference.WorkshopWall, LobbyPositionAnchors.Workshop + new Vector3(-4f, 0f, 0.5f), Vector3.forward);
			Create(AssetReference.WorkshopWall, LobbyPositionAnchors.Workshop + new Vector3(-5f, 0f, 0.5f), Vector3.forward);
			Entity entity = default(Entity);
			entity = Create(GameData.Main.Get<Appliance>(AssetReference.WorkshopInputSlot), LobbyPositionAnchors.Workshop + new Vector3(-4f, 0f, 2f), Vector3.forward);
			base.EntityManager.AddComponentData(entity, new CWorkshopInput
			{
				Index = 0
			});
			entity = Create(GameData.Main.Get<Appliance>(AssetReference.WorkshopInputSlot), LobbyPositionAnchors.Workshop + new Vector3(-3f, 0f, 2f), Vector3.forward);
			base.EntityManager.AddComponentData(entity, new CWorkshopInput
			{
				Index = 1
			});
			entity = Create(GameData.Main.Get<Appliance>(AssetReference.WorkshopInputSlot), LobbyPositionAnchors.Workshop + new Vector3(-2f, 0f, 2f), Vector3.forward);
			base.EntityManager.AddComponentData(entity, new CWorkshopInput
			{
				Index = 2
			});
			entity = Create(GameData.Main.Get<Appliance>(AssetReference.WorkshopOutputSlot), LobbyPositionAnchors.Workshop + new Vector3(-1f, 0f, 2f), Vector3.forward);
			base.EntityManager.AddComponent<SWorkshopOutput>(entity);
			entity = Create(GameData.Main.Get<Appliance>(AssetReference.WorkshopMachine), LobbyPositionAnchors.Workshop + new Vector3(-2.5f, 0f, 3f), Vector3.right);
			base.EntityManager.AddComponent<CWorkshopMachine>(entity);
			entity = Create(GameData.Main.Get<Appliance>(AssetReference.WorkshopCraftButton), LobbyPositionAnchors.Workshop + new Vector3(-4f, 0f, 0f), Vector3.right);
			base.EntityManager.AddComponent<CWorkshopActivateButton>(entity);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
