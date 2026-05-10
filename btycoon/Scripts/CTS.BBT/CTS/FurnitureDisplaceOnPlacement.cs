using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public class FurnitureDisplaceOnPlacement : CTSBehaviour
	{
		[Inject(false)]
		private FurnitureController _furniture;

		private static readonly NamedLayerMask _physicsLayer = new NamedLayerMask("Customer", "Worker");

		private readonly HashSet<IFurnitureDisplacer> _displacables = new HashSet<IFurnitureDisplacer>();

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_furniture.FurniturePlaced += OnFurniturePlaced;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_furniture.FurniturePlaced -= OnFurniturePlaced;
		}

		private void OnFurniturePlaced(bool buyIt)
		{
			StartCoroutine(Displace());
		}

		private IEnumerator Displace()
		{
			if (_furniture.NavMeshObstacle.Length == 0)
			{
				yield break;
			}
			yield return null;
			yield return null;
			Collider[] array = PhysicsAllocation.Get(15);
			_displacables.Clear();
			NavMeshObstacle[] navMeshObstacle = _furniture.NavMeshObstacle;
			for (int i = 0; i < navMeshObstacle.Length; i++)
			{
				int num = navMeshObstacle[i].OverlapNonAlloc(array, _physicsLayer, QueryTriggerInteraction.Ignore);
				for (int j = 0; j < num; j++)
				{
					IFurnitureDisplacer componentInParent = array[j].GetComponentInParent<IFurnitureDisplacer>();
					if (componentInParent != null)
					{
						_displacables.Add(componentInParent);
					}
				}
			}
			foreach (IFurnitureDisplacer displacable in _displacables)
			{
				displacable.Displace();
			}
		}
	}
}
