using System.Collections.Generic;
using System.Runtime.InteropServices;
using KitchenData;
using Platforms;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateAfter(typeof(CreateOffice))]
	public class CreateLayoutSlots : FranchiseFirstFrameSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct CLayoutSlot : IComponentData
		{
		}

		private EntityQuery LayoutSizeUpgrades;

		protected override void Initialise()
		{
			base.Initialise();
			LayoutSizeUpgrades = GetEntityQuery(typeof(CUpgradeExtraLayout));
		}

		protected override void OnUpdate()
		{
			if (!PlatformSettings.DebugQuickLoadLobby)
			{
				Vector3 office = LobbyPositionAnchors.Office;
				List<Vector3> list = new List<Vector3>
				{
					new Vector3(-2f, 0f, -5f),
					new Vector3(-3f, 0f, -5f),
					new Vector3(-4f, 0f, -5f),
					new Vector3(-4f, 0f, -4f)
				};
				for (int i = 0; i < Mathf.Min(4, 2 + LayoutSizeUpgrades.CalculateEntityCount()); i++)
				{
					CreateMapSource(office + list[i]);
				}
			}
		}

		private void CreateMapSource(Vector3 location)
		{
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(CItemHolder), typeof(CLayoutSlot));
			entityManager.SetComponentData(entity, new CCreateAppliance
			{
				ID = AssetReference.LayoutPedestal
			});
			entityManager.SetComponentData(entity, new CPosition(location));
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
