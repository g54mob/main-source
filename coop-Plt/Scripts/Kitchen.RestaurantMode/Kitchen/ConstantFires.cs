using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class ConstantFires : DaySystem
	{
		private struct STimeTracker : IComponentData
		{
			public float LastTime;

			public float Delay;
		}

		private const float TimeBetween = 25f;

		private EntityQuery FlammableAppliances;

		protected override void Initialise()
		{
			base.Initialise();
			FlammableAppliances = GetEntityQuery(new QueryHelper().All(typeof(CAppliance), typeof(CIsInteractive)).None(typeof(CFireImmune), typeof(CApplianceTable), typeof(CApplianceChair), typeof(CIsOnFire)));
		}

		protected override void OnUpdate()
		{
			if (!HasStatus(RestaurantStatus.HalloweenTrickRandomFires))
			{
				return;
			}
			STimeTracker orCreate = GetOrCreate<STimeTracker>();
			float totalTime = base.Time.TotalTime;
			if (totalTime - orCreate.LastTime < orCreate.Delay)
			{
				return;
			}
			orCreate.LastTime = totalTime;
			orCreate.Delay = Random.Range(0.75f, 1.5f) * 25f;
			using NativeArray<Entity> list = FlammableAppliances.ToEntityArray(Allocator.Temp);
			list.ShuffleInPlace();
			foreach (Entity item in list)
			{
				if (Require<CAppliance>(item, out CAppliance comp) && comp.Layer == OccupancyLayer.Default)
				{
					base.EntityManager.AddComponent<CIsOnFire>(item);
					Set(orCreate);
					break;
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
