using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class CreateSelectors : FranchiseBuilderFirstFrameSystem
	{
		protected override void OnUpdate()
		{
			CreateSelector(is_claim: false, new Vector3(3f, 0f, -2f));
			CreateSelector(is_claim: true, new Vector3(-3f, 0f, -2f));
		}

		private void CreateSelector(bool is_claim, Vector3 position)
		{
			Entity entity = base.EntityManager.CreateEntity();
			base.EntityManager.AddComponentData(entity, new CGroupSelector
			{
				Bounds = new Bounds(position, new Vector3(4f, 10f, 3f))
			});
			base.EntityManager.AddComponentData(entity, new CMaintainInView
			{
				Radius = 4f
			});
			base.EntityManager.AddComponentData(entity, new CRequiresView
			{
				Type = ViewType.GroupSelector
			});
			Entity entity2 = base.EntityManager.CreateEntity();
			base.EntityManager.AddComponentData(entity2, new CCreateAppliance
			{
				ID = AssetReference.FranchiseBuilderText
			});
			base.EntityManager.AddComponentData(entity2, new CPosition(position));
			if (is_claim)
			{
				base.EntityManager.AddComponent<CSelectorEnabled>(entity);
				base.EntityManager.AddComponentData(entity2, new SClaimExpSelector
				{
					Selector = entity
				});
			}
			else
			{
				base.EntityManager.AddComponentData(entity2, new SCreateFranchiseSelector
				{
					Selector = entity
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
