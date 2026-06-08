using System.Runtime.InteropServices;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class ExpandBoundsAtNight : RestaurantSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct CNightBound : IComponentData
		{
		}

		private EntityQuery BoundPoints;

		protected override void Initialise()
		{
			base.Initialise();
			BoundPoints = GetEntityQuery(typeof(CNightBound));
		}

		protected override void OnUpdate()
		{
			if (BoundPoints.IsEmpty)
			{
				Bounds bounds = base.Bounds;
				bounds.Expand(3f);
				CreateBoundPoint(new Vector3(bounds.min.x - 1f, 0f, bounds.min.z - 2f));
				CreateBoundPoint(new Vector3(bounds.min.x - 1f, 0f, bounds.max.z));
				CreateBoundPoint(new Vector3(bounds.max.x + 1f, 0f, bounds.min.z - 2f));
				CreateBoundPoint(new Vector3(bounds.max.x + 1f, 0f, bounds.max.z));
			}
			if (Has<SIsDayTime>())
			{
				base.EntityManager.RemoveComponent<CMaintainInView>(BoundPoints);
			}
			else
			{
				base.EntityManager.AddComponent<CMaintainInView>(BoundPoints);
			}
		}

		private void CreateBoundPoint(Vector3 location)
		{
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CRequiresView), typeof(CPosition), typeof(CNightBound));
			entityManager.SetComponentData(entity, new CRequiresView
			{
				Type = ViewType.Marker
			});
			entityManager.SetComponentData(entity, new CPosition(location));
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
