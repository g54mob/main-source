using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class CreateExitSelector : ResearchFirstFrameSystem
	{
		protected override void OnUpdate()
		{
			CreateSelector(is_claim: false, new Vector3(3f, 0f, -2f));
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
				ID = AssetReference.ResearchExitText
			});
			base.EntityManager.AddComponentData(entity2, new CPosition(position));
			base.EntityManager.AddComponent<CSelectorEnabled>(entity);
			base.EntityManager.AddComponent<SExitSelector>(entity);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
