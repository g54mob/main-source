using System.Runtime.InteropServices;
using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class CreateCraneExplainer : NightSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct SAppliance : IComponentData
		{
		}

		private EntityQuery Upgrade;

		protected override void Initialise()
		{
			base.Initialise();
			Upgrade = GetEntityQuery(typeof(CUpgradeAdvancedBuildMode));
		}

		protected override void OnUpdate()
		{
			bool flag = !Upgrade.IsEmpty;
			if (Has<SKitchenMarker>() && flag && !HasSingleton<SAppliance>())
			{
				Vector3 frontDoor = GetFrontDoor();
				Entity entity = base.EntityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(SAppliance));
				base.EntityManager.SetComponentData(entity, new CCreateAppliance
				{
					ID = AssetReference.AdvancedBuildModeIndicatorIngame
				});
				int num = ((!(frontDoor.x > 0f)) ? 1 : (-1));
				base.EntityManager.SetComponentData(entity, new CPosition(frontDoor + new Vector3(num, 0f, -3f)));
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
