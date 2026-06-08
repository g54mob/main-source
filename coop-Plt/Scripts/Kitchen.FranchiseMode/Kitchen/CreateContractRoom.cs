using KitchenData;
using Platforms;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class CreateContractRoom : FranchiseFirstFrameSystem
	{
		private EntityQuery Franchises;

		protected override void Initialise()
		{
			base.Initialise();
			Franchises = GetEntityQuery(typeof(CFranchiseItem));
		}

		protected override void OnUpdate()
		{
			if (Franchises.IsEmpty || PlatformSettings.IsDemoMode)
			{
				Create(GameData.Main.Get<Appliance>(AssetReference.ContractLock), LobbyPositionAnchors.Contracts + new Vector3(-0.5f, 0f, 0f), Vector3.forward);
				return;
			}
			CreateProjector();
			CreateCardViewer();
			CreateScrapper();
		}

		private void CreateProjector()
		{
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(CAvailableFranchises), typeof(RebuildKitchen.CNonKitchen), typeof(SFranchiseSelector));
			entityManager.SetComponentData(entity, new CCreateAppliance
			{
				ID = AssetReference.ContractProjector
			});
			entityManager.SetComponentData(entity, new CPosition(LobbyPositionAnchors.Contracts + new Vector3(-2f, 0f, 0f)));
			DynamicBuffer<CAvailableFranchises> buffer = GetBuffer<CAvailableFranchises>(entity);
			using NativeArray<Entity> nativeArray = Franchises.ToEntityArray(Allocator.Temp);
			buffer.Add(new CAvailableFranchises
			{
				Franchise = default(Entity)
			});
			foreach (Entity item in nativeArray)
			{
				buffer.Add(new CAvailableFranchises
				{
					Franchise = item
				});
			}
		}

		private void CreateCardViewer()
		{
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(CFranchiseCardViewer), typeof(CPreventItemTransfer), typeof(RebuildKitchen.CNonKitchen));
			entityManager.SetComponentData(entity, new CCreateAppliance
			{
				ID = AssetReference.CardViewer
			});
			entityManager.SetComponentData(entity, new CPosition(LobbyPositionAnchors.Contracts + new Vector3(0f, 0f, -1f)));
		}

		private void CreateScrapper()
		{
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(CFranchiseScrapper), typeof(CPreventItemTransfer), typeof(RebuildKitchen.CNonKitchen));
			entityManager.SetComponentData(entity, new CCreateAppliance
			{
				ID = AssetReference.FranchiseShredder
			});
			entityManager.SetComponentData(entity, new CPosition(LobbyPositionAnchors.Contracts + new Vector3(0f, 0f, 0f)));
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
