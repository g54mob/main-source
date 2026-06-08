using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class CreateExpGrants : FranchiseFirstFrameSystem
	{
		private EntityQuery Grants;

		protected override void Initialise()
		{
			base.Initialise();
			Grants = GetEntityQuery(typeof(CExpGrant));
		}

		protected override void OnUpdate()
		{
			if (!HasSingleton<CSceneFirstFrame>())
			{
				return;
			}
			NativeArray<CExpGrant> nativeArray = Grants.ToComponentDataArray<CExpGrant>(Allocator.Temp);
			int num = 0;
			foreach (CExpGrant item in nativeArray)
			{
				if (!item.IsGranted)
				{
					num += item.Amount;
				}
			}
			if (Debug.isDebugBuild)
			{
				num += 1000;
			}
			if (num > 0)
			{
				Entity entity = base.EntityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(CExpGrantAppliance));
				base.EntityManager.SetComponentData(entity, new CCreateAppliance
				{
					ID = AssetReference.ExpGranter
				});
				base.EntityManager.SetComponentData(entity, new CPosition
				{
					Position = new Vector3(4f, 0f, 6f)
				});
				base.EntityManager.SetComponentData(entity, new CExpGrantAppliance
				{
					Amount = num
				});
			}
			nativeArray.Dispose();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
