using KitchenData;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Kitchen
{
	public class CreateFranchiseKitchen : FranchiseFirstFrameSystem
	{
		protected override void OnUpdate()
		{
			Vector3 kitchen = LobbyPositionAnchors.Kitchen;
			CreateSlot(kitchen + new Vector3(0f, 0f, 0f), Vector3.forward);
			CreateSlot(kitchen + new Vector3(1f, 0f, 0f), Vector3.forward);
			CreateSlot(kitchen + new Vector3(2f, 0f, 0f), Vector3.forward);
			CreateSlot(kitchen + new Vector3(3f, 0f, 0f), Vector3.forward);
			CreateSlot(kitchen + new Vector3(-1f, 0f, 0f), Vector3.forward);
			CreateSlot(kitchen + new Vector3(-1f, 0f, -2f), Vector3.left);
			CreateSlot(kitchen + new Vector3(-1f, 0f, -1f), Vector3.left);
			CreateSlot(kitchen + new Vector3(1f, 0f, -2f), Vector3.forward);
			CreateSlot(kitchen + new Vector3(2f, 0f, -2f), Vector3.forward);
			CreateSlot(kitchen + new Vector3(5f, 0f, 0f), Vector3.forward);
			CreateSlot(kitchen + new Vector3(5f, 0f, -1f), Vector3.forward);
			CreateSlot(kitchen + new Vector3(5f, 0f, -2f), Vector3.forward);
			CreateSlot(kitchen + new Vector3(5f, 0f, -3f), Vector3.forward);
			CreateSlot(kitchen + new Vector3(5f, 0f, -4f), Vector3.forward);
			Entity entity = Create(GameData.Main.Get<Appliance>(AssetReference.FranchiseKitchenTutorial), kitchen + new Vector3(4f, 0f, 0f), Vector3.forward);
			base.EntityManager.AddComponent<CFranchiseKitchenTutorialPrompt>(entity);
			Create(GameData.Main.Get<Appliance>(AssetReference.Sink), kitchen + new Vector3(1f, 0f, -3f), Vector3.back);
			Create(GameData.Main.Get<Appliance>(AssetReference.Counter), kitchen + new Vector3(2f, 0f, -3f), Vector3.back);
			Create(GameData.Main.Get<Appliance>(AssetReference.Counter), kitchen + new Vector3(3f, 0f, -3f), Vector3.back);
			Entity target = Create(GameData.Main.Get<Appliance>(AssetReference.TutorialTable), kitchen + new Vector3(0f, 0f, -4f), Vector3.forward);
			Entity entity2 = Create(GameData.Main.Get<Appliance>(AssetReference.Chair), kitchen + new Vector3(-1f, 0f, -4f), Vector3.left);
			Entity entity3 = Create(GameData.Main.Get<Appliance>(AssetReference.Chair), kitchen + new Vector3(1f, 0f, -4f), Vector3.right);
			base.EntityManager.AddComponentData(entity2, new CInteractionProxy
			{
				Target = target,
				IsActive = true
			});
			base.EntityManager.AddComponentData(entity3, new CInteractionProxy
			{
				Target = target,
				IsActive = true
			});
			Create(GameData.Main.Get<Appliance>(AssetReference.InfiniteBin), kitchen + new Vector3(-1f, 0f, -3f), Vector3.back);
			if (!HasSingleton<SPerformTableUpdate>())
			{
				base.EntityManager.CreateEntity(typeof(SPerformTableUpdate));
			}
			base.EntityManager.AddComponentData(base.EntityManager.CreateEntity(), new RebuildKitchen.CRebuildKitchen
			{
				Dish = AssetReference.DishSteak
			});
		}

		protected void CreateSlot(Vector3 pos, Vector3 face)
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(RebuildKitchen.CFranchiseKitchenSlot));
			base.EntityManager.AddComponentData(entity, new CPosition(pos, quaternion.LookRotation(face, new float3(0f, 1f, 0f))));
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
