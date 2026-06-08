using KitchenData;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Kitchen
{
	public class CreateOffice : FranchiseFirstFrameSystem
	{
		protected override void OnUpdate()
		{
			CreateDrawingBoard(LobbyPositionAnchors.Office);
			Create(base.Data.Get<Appliance>(AssetReference.SettingSelector), LobbyPositionAnchors.Office + new Vector3(-4f, 0f, 0f), Vector3.forward);
		}

		private void CreateDrawingBoard(Vector3 location)
		{
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(SLayoutPedestal), typeof(SSelectedLayoutPedestal), typeof(CItemHolder));
			entityManager.SetComponentData(entity, new CCreateAppliance
			{
				ID = -760874610
			});
			entityManager.SetComponentData(entity, new CPosition(location + new Vector3(-1f, 0f, 0f), quaternion.LookRotation(new float3(0f, 0f, 1f), new float3(0f, 1f, 0f))));
			Entity entity2 = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(SSeededLayoutPedestal), typeof(CItemHolder), typeof(CPreventItemTransfer), typeof(CHideView));
			entityManager.SetComponentData(entity2, new CCreateAppliance
			{
				ID = 1363960331
			});
			entityManager.SetComponentData(entity2, new CPosition(location + new Vector3(-1f, 0f, 0f), quaternion.LookRotation(new float3(0f, 0f, 1f), new float3(0f, 1f, 0f))));
			Entity entity3 = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(SDishPedestal), typeof(CItemHolder));
			entityManager.SetComponentData(entity3, new CCreateAppliance
			{
				ID = -1528441435
			});
			entityManager.SetComponentData(entity3, new CPosition(location + new Vector3(1f, 0f, 0f), quaternion.LookRotation(new float3(0f, 0f, 1f), new float3(0f, 1f, 0f))));
			Entity entity4 = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(SFixedDishPedestal), typeof(CItemHolder), typeof(CHideView));
			entityManager.SetComponentData(entity4, new CCreateAppliance
			{
				ID = -232172209
			});
			entityManager.SetComponentData(entity4, new CPosition(location + new Vector3(1f, 0f, 0f), quaternion.LookRotation(new float3(0f, 0f, 1f), new float3(0f, 1f, 0f))));
			Entity entity5 = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition));
			entityManager.SetComponentData(entity5, new CCreateAppliance
			{
				ID = 359655899
			});
			entityManager.SetComponentData(entity5, new CPosition(location, quaternion.LookRotation(new float3(0f, 0f, 1f), new float3(0f, 1f, 0f))));
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
