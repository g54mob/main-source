using Kitchen.Layouts;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateAfter(typeof(AssembleTableSets))]
	[UpdateInGroup(typeof(TableUpdatesGroup))]
	public class FindGrabPoints : TableUpdateSystem
	{
		private EntityQuery Parts;

		private EntityQuery GrabPoints;

		protected override void Initialise()
		{
			base.Initialise();
			Parts = GetEntityQuery(typeof(CPartOfTableSet), typeof(CPosition));
			GrabPoints = GetEntityQuery(typeof(CTableSetGrabPoints));
		}

		protected override void OnUpdate()
		{
			foreach (Entity item in GrabPoints.ToEntityArray(Allocator.Temp))
			{
				GetBuffer<CTableSetGrabPoints>(item).Clear();
			}
			NativeArray<Entity> nativeArray = Parts.ToEntityArray(Allocator.Temp);
			foreach (Entity item2 in nativeArray)
			{
				CPosition component = GetComponent<CPosition>(item2);
				CPartOfTableSet component2 = GetComponent<CPartOfTableSet>(item2);
				AddGrabPoint(component2.TableSet, item2);
				foreach (LayoutPosition direction in LayoutHelpers.Directions)
				{
					Vector3 vector = component + new Vector3(direction.x, 0f, direction.y);
					if (base.TileManager.CanReach(component, vector))
					{
						Entity occupant = base.TileManager.GetOccupant(vector);
						if (base.EntityManager.HasComponent<CApplianceGrabPoint>(occupant))
						{
							AddGrabPoint(component2.TableSet, occupant);
						}
					}
				}
			}
			nativeArray.Dispose();
		}

		protected void AddGrabPoint(Entity set, Entity grab)
		{
			DynamicBuffer<CTableSetGrabPoints> buffer = GetBuffer<CTableSetGrabPoints>(set);
			foreach (CTableSetGrabPoints item in buffer)
			{
				if (item == grab)
				{
					return;
				}
			}
			buffer.Add(grab);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
