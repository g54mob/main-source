using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class FurnitureDirtOverride : CTSBehaviour
	{
		[SerializeField]
		private LayerMask _physicsMask = -1;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			FurnitureController.StaticFurniturePlaced += OnFurniturePlaced;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			FurnitureController.StaticFurniturePlaced -= OnFurniturePlaced;
		}

		private void OnFurniturePlaced(FurnitureController obj)
		{
			BoxCollider placementCollider = obj.Furniture.Bounds.PlacementCollider;
			if (!placementCollider)
			{
				return;
			}
			Collider[] array = PhysicsAllocation.Get(10);
			int num = placementCollider.OverlapNonAlloc(array, _physicsMask);
			for (int i = 0; i < num; i++)
			{
				Collider collider = array[i];
				JunkObject componentInParent = collider.GetComponentInParent<JunkObject>();
				if ((bool)componentInParent)
				{
					componentInParent.ForceDiscard();
					continue;
				}
				Drink componentInParent2 = collider.GetComponentInParent<Drink>();
				if ((bool)componentInParent2 && componentInParent2.ClearChore != null && componentInParent2.ClearChore.Status != AgentAction.EStatus.Completed)
				{
					componentInParent2.Clear();
				}
			}
		}
	}
}
