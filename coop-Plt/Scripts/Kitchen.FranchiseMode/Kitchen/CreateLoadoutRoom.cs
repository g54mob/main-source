using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class CreateLoadoutRoom : FranchiseFirstFrameSystem
	{
		private EntityQuery Upgrade;

		protected override void Initialise()
		{
			base.Initialise();
			Upgrade = GetEntityQuery(typeof(CUpgradeAdvancedBuildMode));
		}

		protected override void OnUpdate()
		{
			CreateStartSelector();
			if (!Upgrade.IsEmpty)
			{
				CreateAdvancedBuildModeCrane(new Vector3(-7f, 0f, -5f));
			}
		}

		private void CreateAdvancedBuildModeCrane(Vector3 location)
		{
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition));
			entityManager.SetComponentData(entity, new CCreateAppliance
			{
				ID = AssetReference.AdvancedBuildModeIndicator
			});
			entityManager.SetComponentData(entity, new CPosition(location));
		}

		private void CreateStartSelector()
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(SBeginGameSelector));
			base.EntityManager.AddComponentData(entity, new CGroupSelector
			{
				Bounds = new Bounds(LobbyPositionAnchors.StartMarker, new Vector3(6f, 10f, 2f))
			});
			base.EntityManager.AddComponentData(entity, new CMaintainInView
			{
				Radius = 4f
			});
			base.EntityManager.AddComponentData(entity, new CRequiresView
			{
				Type = ViewType.GroupSelector
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
